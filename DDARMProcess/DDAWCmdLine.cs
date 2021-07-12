using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;

using DDARecipe;


namespace DDARMProcess
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class DDAWCmdLine
	{
		static DDARecipe.DDARecipe recipe = null;
		static DDARecipe.DDAWorkingSpace working = new DDAWorkingSpace();
		static Thread workingthread = null;

		static int	 recipeid = 0;
		static int	 limit = 0;
		static int	 recipeindex =-1; 

		static bool  useconsole = false;

		static ManualResetEvent	eventExit = new ManualResetEvent(false);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if(args.Length!=3 || args[0]!="/Controler") return;

			SiGlaz.Utility.EventViewerLog.GlobalLog = new SiGlaz.Utility.EventViewerLog("DDA Recipe Process");

			try
			{
				DDAExternalData.LoadApplicationData();

				//Register Remoting
				RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
				RemotableEventController.Controler.InitRemotingObjects();

				//Load Data
				recipeid = int.Parse(args[1]);
				recipeindex = int.Parse(args[2]);
				if(!LoadRecipe()) return;

				RunControler();

				if(eventExit!=null)
				{
					WriteLine("WaitOne");
					eventExit.WaitOne();
				}

			}
			catch(Exception ex)
			{
				WriteLine(ex.Message);
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			finally
			{
				RemotableEventController.Controler.FreeRemotingObject();
			}

			WriteLine("Main Thread End");

			if(useconsole)
				Console.ReadLine();
		}

		public static void WriteLine(params string []msg)
		{
			if(useconsole)
			{
				foreach(string line in msg)
					Console.WriteLine(line);
			}
		}

		static bool LoadRecipe()
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();

				if(proxy==null)
					return false;

				try
				{
					WebServiceProxy.RecipeProxy.DDARecipe wobj = proxy.GetRecipeByKey(recipeid);
					SiGlaz.Common.DDA.DDARecipe obj = WebServiceProxy.ConvertProxy.Convert(wobj,typeof(SiGlaz.Common.DDA.DDARecipe)) as SiGlaz.Common.DDA.DDARecipe;
					recipe = new DDARecipe.DDARecipe();
					recipe.CommonStruct = obj;

					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();

				try
				{
					proxy  = new SiGlaz.DDA.Business.Recipe();
					SiGlaz.Common.DDA.DDARecipe obj = proxy.GetRecipeByKey(recipeid);
					recipe = new DDARecipe.DDARecipe();
					recipe.CommonStruct = obj;
					return true;
				}
				catch
				{
					return false;
				}
			}
		}

		public static void RunControler()
		{
			if(recipeid<=0) return;

			WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.SystemEvent;

			Execute();
		}

		public static void _RemoteEvent_OnStartCmd(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{

		}

		public static void _RemoteEvent_OnStopCmd(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(recipeindex!=RecipeIndex) return;//not me

			WriteLine("Waiting stop ...");
			if(working!=null && recipe!=null)
			{
				working.Stop = true;

				try
				{
					DDARecipe.InterProcessRecipeEvent pe = new InterProcessRecipeEvent(recipe.ID,true);
					pe.SetEvent();
				}
				catch
				{
				}

				if(!working.IsWaiting)//Abort thread if no waiting update into database
				{
					WriteLine("!working.IsWaiting");
					WriteLine(workingthread.ThreadState.ToString());

					if(workingthread!=null 
						&& workingthread.ThreadState!=System.Threading.ThreadState.Stopped
						&& workingthread.ThreadState!=System.Threading.ThreadState.Aborted
						)
					{
						if(workingthread.ThreadState==System.Threading.ThreadState.WaitSleepJoin)
							workingthread.Interrupt();

						//workingthread.Abort();
						//WriteLine("workingthread.Abort();");
						//Raise Stop 
						//recipe_OnStop(working.CreateEventArgs(string.Empty,recipe));
					}
				}
			}
		}


		private static void ExecuteMonitorThreading()
		{
            //Console.ReadLine();
			WriteLine("Execute Monitor ...");
			recipe.ExecuteMonitor(working,limit);
			WriteLine("Sub Thread End");
			eventExit.Set();
		}

		private static void Execute()
		{
			if(recipe==null) 
			{
				WriteLine("recipe is null");
				return;
			}
			try
			{
                recipe.OnStart += new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStart);
                recipe.OnStop += new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStop);

                recipe.OnBegin += new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnBegin);
                recipe.OnComplete += new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnComplete);
                recipe.OnException += new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnException);

                if (SiGlaz.Common.DDA.AppData.Data.ShowProcessStep)
                    recipe.OnBeginNode += new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnBeginNode);

                recipe.OnExceptionNode += new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnExceptionNode);

                if (SiGlaz.Common.DDA.AppData.Data.ShowProcessStep)
                    recipe.OnCompleteNode += new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnCompleteNode);

                recipe.OnWaitingForData += new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnWaitingForData);
                recipe.OnMessage += new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnMessage);
				
				workingthread = new Thread(new ThreadStart(ExecuteMonitorThreading));
				workingthread.Start();
			}
			catch(Exception ex)
			{
				WriteLine(ex.ToString());
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}


		#region Hanlder Recipe Event

		private static void recipe_OnStart(SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Start Recipe [{0}]",recipe.Name) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnStart(recipeindex,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnException(SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Exception at [{0}]",recipe.Name) );
				WriteLine( string.Format("\"{0}\" ",e.Message) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnException(recipeindex,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnBegin(SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Begin Recipe [{0}]",recipe.Name) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnBegin(recipeindex,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnStop(SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Stop processing recipe [{0}]",recipe.Name) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnStop(recipeindex,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			if(working.Stop)
				eventExit.Set();
		}

		private static void recipe_OnComplete(SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Complete process recipe [{0}]",recipe.Name) );
				WriteLine( "--------------------------------------------------------" );
				WriteLine();

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnComplete(recipeindex,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnBeginNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Begin to process node [{1}] of recipe [{0}]",recipe.Name,node.Name) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnBeginNode(recipeindex,node.ID,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnExceptionNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Exception at node [{1}] of [{0}]",recipe.Name,node.Name) );
				WriteLine( string.Format("\"{0}\" ",e.Message) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnExceptionNode(recipeindex,node.ID,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnCompleteNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Node {1} of recipe [{0}] was completely processed",recipe.Name,node.Name) );
				DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
				if(flow!=null)
					WriteLine( string.Format("-> LOT :{0} DISK :{1} ", flow.LotID,flow.DiskID ) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnCompleteNode(recipeindex,node.ID,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnWaitingForData(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				WriteLine( string.Format("Waiting new data for processing at node [{1}] of recipe [{0}]",recipe.Name,node.Name) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnWaitingForData(recipeindex,node.ID,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private static void recipe_OnMessage(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			try
			{
				if(recipe!=null && node!=null)
					WriteLine( string.Format("Message at node [{1}] of [{0}]",recipe.Name,node.Name) );

				WriteLine( string.Format("\"{0}\" ",e.Message) );

				RemotableEventController.Controler.RemoteRecipeList.HandlerOnMessage(recipeindex,node.ID,e);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}


		#endregion Hanlder Recipe Event

	
		
	}
}
