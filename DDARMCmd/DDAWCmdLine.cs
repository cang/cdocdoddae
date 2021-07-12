using System;
using System.Threading;
using System.Diagnostics;

using DDARecipe;


namespace DDAWCmd
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class DDAWCmdLine
	{
		static SiGlaz.SharedMemory.ReceivedMonitor receivedMonitor	= null;
		static SiGlaz.SharedMemory.SendMonitor sendMonitor	= null;
		static DDARecipe.DDARecipe recipe = null;
		static DDARecipe.DDAWorkingSpace working = new DDAWorkingSpace();
		static Thread workingthread = null;
		static bool	 useconsole = true;
		static int	 recipeid = 0;
		static int	 limit = 0;
		static ManualResetEvent	eventExit = new ManualResetEvent(false);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				if(args.Length==0)
					RunFromRecipeList();
				else
				{
					string scommand = args[0];
					if(scommand == "/Controler")
					{
						if(args.Length>=2)
							recipeid = Convert.ToInt32(args[1]);
						
						if(args.Length>=3)
							limit = Convert.ToInt32(args[2]);

						if(args.Length>3)
						{
							PrintHelp();
							return;
						}

						RunControler();
					}
					else if(scommand=="/file")
					{
						WriteLine("Run from recipe file... " + args[1] );
						RunRecipeFile(args[1]);
						Console.ReadLine();
					}
					else
						PrintHelp();
				}

				if(eventExit!=null)
				{
					WriteLine("WaitOne");
					eventExit.WaitOne();
				}
			}
			catch(Exception ex)
			{
				WriteLine("Error : " +  ex.ToString());
				PrintHelp();
			}

			if(receivedMonitor!=null)
				receivedMonitor.Dispose();
			if(sendMonitor!=null)
				sendMonitor.Dispose();

			#region Check re-start Cmd 
			string cmdpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DDARMCmd.exe");
			if(!working.Stop && limit>0 && recipe!=null && System.IO.File.Exists(cmdpath))
			{
				//new monitor
				SiGlaz.SharedMemory.SendMonitor send = new SiGlaz.SharedMemory.SendMonitor("R" + recipe.ID + "_M2C");

				System.Diagnostics.ProcessStartInfo proInfo = 
					new System.Diagnostics.ProcessStartInfo(cmdpath,@"/Controler " +  recipe.ID + " " + limit);

				if(!useconsole)
					proInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

				System.Diagnostics.Process.Start(proInfo);

				//send.RaiseEvent((int)eMessage.RUNRECIPE);
			}
			#endregion Check re-start Cmd 

			WriteLine("Main Thread End");
			//Console.ReadLine();
		}

		static void PrintHelp()
		{
			WriteLine("Unknown command!!!");
			Console.ReadLine();
		}

		static void WriteLine()
		{
			WriteLine(string.Empty);
		}

		static void WriteLine(string msg)
		{
			if(useconsole)
			{
				Console.WriteLine(msg);
			}
		}

		public static void RunControler()
		{
			if(recipeid<=0) return;

            //useconsole = true; //false;
			WebServiceProxy.WebProxyFactory.MessageType= WebServiceProxy.WebProxyFactory.eMessageType.SystemEvent;

			WriteLine("Run Controler...");

			receivedMonitor = new SiGlaz.SharedMemory.ReceivedMonitor("R" + recipeid + "_M2C");
			receivedMonitor.OnReceived+=new SiGlaz.SharedMemory.EventHandlerReceived(receivedMonitor_OnReceived);

			ExecRecipeFromMemory();
		}


		private static void ExecRecipeFromMemory()
		{
			WriteLine("Get recipe information from monitor process");

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			receivedMonitor.ReadBinary(shareobj);
			recipe = shareobj.recipe;

			WriteLine("Loading external data....");
			DDAExternalData.LoadApplicationData();

//			//Set date range
//			working.dtProcessedSurfaces = DateTime.MinValue;
//			if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate!=null)
//				working.dtProcessedSurfaces = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.From;

			WriteLine("Execute recipe...");
			Execute();
		}

		private static void receivedMonitor_OnReceived(SiGlaz.SharedMemory.SharedMessage msg)
		{
			WriteLine("Begin received command from monitor process");
			//			if( (DDARecipe.eMessage)msg.Message == DDARecipe.eMessage.RUNRECIPE && !running)
			//			{
			//				running = true;
			//				ExecRecipeFromMemory();
			//			}
			//			else 
			if( (DDARecipe.eMessage)msg.Message == DDARecipe.eMessage.STOPRECIPE )
			{
				//WriteLine("Waiting stop ...");
				if(working!=null && recipe!=null)
				{
					working.Stop = true;
					
					try
					{
						InterProcessRecipeEvent pe = new InterProcessRecipeEvent(recipe.ID,true);
						pe.SetEvent();
					}
					catch
					{
					}

					if(!working.IsWaiting)//Abort thread if no waiting update into database
					{
//						WriteLine("!working.IsWaiting");
//						WriteLine(workingthread.ThreadState.ToString());
//						if(workingthread!=null 
//							&& workingthread.ThreadState!=System.Threading.ThreadState.Stopped
//							&& workingthread.ThreadState!=System.Threading.ThreadState.Aborted
//							)
//						{
//							workingthread.Abort();
//							recipe_OnStop(working.CreateEventArgs(string.Empty,recipe));
//						}

						WriteLine("!working.IsWaiting");
						WriteLine(workingthread.ThreadState.ToString());

						if(workingthread!=null 
							&& workingthread.ThreadState!=System.Threading.ThreadState.Stopped
							&& workingthread.ThreadState!=System.Threading.ThreadState.Aborted
							)
						{
							if(workingthread.ThreadState==System.Threading.ThreadState.WaitSleepJoin)
								workingthread.Interrupt();
						}

					}
				}
			}
		}

		private static void ExecuteMonitorThreading()
		{
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
				recipe.OnStart+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStart);
				recipe.OnStop+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStop);

				recipe.OnBegin+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnBegin);
				recipe.OnComplete+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnComplete);
				recipe.OnException+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnException);

				if(SiGlaz.Common.DDA.AppData.Data.ShowProcessStep)
					recipe.OnBeginNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnBeginNode);

				recipe.OnExceptionNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnExceptionNode);

				if(SiGlaz.Common.DDA.AppData.Data.ShowProcessStep)
					recipe.OnCompleteNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnCompleteNode);

				recipe.OnWaitingForData+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnWaitingForData);
				recipe.OnMessage+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnMessage);
				
				if(receivedMonitor!=null)
					sendMonitor = new SiGlaz.SharedMemory.SendMonitor("R" + recipe.ID + "_C2M");

				workingthread = new Thread(new ThreadStart(ExecuteMonitorThreading));
				workingthread.Start();
			}
			catch(Exception ex)
			{
				WriteLine(ex.ToString());
			}
		}


		#region Hanlder Recipe Event

		private static void recipe_OnStart(SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Start Recipe [{0}]",recipe.Name) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = -1;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);

			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.STARTRECIPE);

		}

		private static void recipe_OnException(SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Exception at [{0}]",recipe.Name) );
			WriteLine( string.Format("\"{0}\" ",e.Message) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = -1;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);

			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.EXCEPTION);
		}

		private static void recipe_OnBegin(SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Begin Recipe [{0}]",recipe.Name) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = -1;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);

			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.BEGINRECIPE);
		}

		private static void recipe_OnStop(SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Stop process recipe [{0}]",recipe.Name) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = -1;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);

			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.STOPRECIPE);

			if(working.Stop)
				eventExit.Set();
		}

		private static void recipe_OnComplete(SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Complete process recipe [{0}]",recipe.Name) );
			WriteLine( "--------------------------------------------------------" );
			WriteLine();

			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = -1;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);


			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.COMPLETERECIPE);
		}

		private static void recipe_OnBeginNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Begin to process node [{1}] of recipe [{0}]",recipe.Name,node.Name) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = node.ID;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);
			
			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.BEGINNODE);
		}

		private static void recipe_OnExceptionNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Exception at node [{1}] of [{0}]",recipe.Name,node.Name) );
			WriteLine( string.Format("\"{0}\" ",e.Message) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = node.ID;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);
			
			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.EXCEPTIONNODE);
		}

		private static void recipe_OnCompleteNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			string msg = string.Format("Node {1} of recipe [{0}] was completely processed",recipe.Name,node.Name);
			DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
//			if(flow!=null)
//				msg +=string.Format(" --> Surface :{0}",flow.ToString());
			WriteLine(msg);

			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = node.ID;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);
			
			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.COMPLETENODE);
		}

		private static void recipe_OnWaitingForData(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			WriteLine( string.Format("Waiting new data for processing at node [{1}] of recipe [{0}]",recipe.Name,node.Name) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();
			shareobj.idCurrentNode = node.ID;
			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);
			
			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.WATINGDATA);
		}

		private static void recipe_OnMessage(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(recipe!=null && node!=null)
				WriteLine( string.Format("Message at node [{1}] of [{0}]",recipe.Name,node.Name) );

			WriteLine( string.Format("\"{0}\" ",e.Message) );
			if(sendMonitor==null) return;

			DDARecipe.DDASharedData shareobj = new DDASharedData();

			if(recipe!=null && node!=null)
				shareobj.idCurrentNode = node.ID;
			else
				shareobj.idCurrentNode = -1;

			shareobj.eventobj = e as DDARecipeEventArgs;
			sendMonitor.WriteBinary(shareobj);

			sendMonitor.RaiseEvent((int)DDARecipe.eMessage.MESSAGE);
		}


		#endregion Hanlder Recipe Event

		#region run from file
		public static void RunRecipeFile(string file)
		{
			if(!System.IO.File.Exists(file)) 
			{
				WriteLine("File is not exist.");
				return;
			}

			try
			{
				recipe = new DDARecipe.DDARecipe();
				recipe.DeserializeBinary(file);

				WriteLine("Loading external data....");
				DDAExternalData.LoadApplicationData();

				Execute();
			}
			catch(Exception ex)
			{
				WriteLine("Error read file  : "  + ex.Message);
				recipe = null;
			}
		}
		#endregion run from file

		#region run from list

		private static void RunFromRecipeList()
		{
			WriteLine("Loading external data....");
			DDAExternalData.LoadApplicationData();

			//Set date range
//			working.dtProcessedSurfaces = DateTime.MinValue;
//			if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate!=null)
//				working.dtProcessedSurfaces = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.From;

			//View recipes list and press enter to run without monitoring
			WriteLine("View recipes list and select recipe to run");

			
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = null;
				WebServiceProxy.RecipeProxy.RecipeListResult result = null;
				try
				{
					proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
					result = proxy.RecipeList();
				}
				catch
				{
					WriteLine("Cannot connect to web service.");
					return;
				}

				WriteLine("---< Recipe List >--");
				WriteLine("--------------------");
				foreach(WebServiceProxy.RecipeProxy.DDARecipe obj in result.Recipes)
				{
					string s = obj.RecipeKey + ". " + obj.RecipeName;
					WriteLine(s);
				}
				WriteLine("Please type recipeid and enter in order to run (type : 'exit' or 'e' to exit)");
				while(true)
				{
					string s = Console.ReadLine();
					if( s.ToLower()=="exit" || s.ToLower()=="e") 
						break;

					try
					{
						int recipeid = Convert.ToInt32(s);
						foreach(WebServiceProxy.RecipeProxy.DDARecipe obj in result.Recipes)
						{
							if(obj.RecipeKey == recipeid)
							{
								try
								{
									recipe = new DDARecipe.DDARecipe();
									SiGlaz.Common.DDA.DDARecipe xx = WebServiceProxy.ConvertProxy.Convert(obj,typeof(SiGlaz.Common.DDA.DDARecipe)) as SiGlaz.Common.DDA.DDARecipe;
									xx.RawData = proxy.GetRawData(obj.RecipeKey).Result;
									recipe.CommonStruct = xx;

									Execute();
									return;
								}
								catch(Exception ex)
								{
									WriteLine(ex.ToString());
									recipe = null;
									return;
								}
							}
						}
						WriteLine("Invalid recipe id, try again...");
					}
					catch
					{
						WriteLine("Recipeid must a number, try again...");
					}
				}
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = null;
				SiGlaz.Common.DDA.Result.RecipeListResult result = null;
				try
				{
					proxy  = new SiGlaz.DDA.Business.Recipe();
					result = proxy.RecipeList();
				}
				catch
				{
					WriteLine("Cannot connect to database.");
					return;
				}

				WriteLine("---< Recipe List >--");
				WriteLine("--------------------");
				foreach(SiGlaz.Common.DDA.DDARecipe obj in result.Recipes)
				{
					string s = obj.RecipeKey + ". " + obj.RecipeName;
					WriteLine(s);
				}
				WriteLine("Please type recipeid and enter in order to run (type : 'exit' or 'e' to exit)");
				while(true)
				{
					string s = Console.ReadLine();
					if( s.ToLower()=="exit" || s.ToLower()=="e") 
						break;

					try
					{
						int recipeid = Convert.ToInt32(s);
						foreach(SiGlaz.Common.DDA.DDARecipe obj in result.Recipes)
						{
							if(obj.RecipeKey == recipeid)
							{
								try
								{
									recipe = new DDARecipe.DDARecipe();
									SiGlaz.Common.DDA.DDARecipe xx = obj;
									xx.RawData = proxy.GetRawData(obj.RecipeKey).Result;
									recipe.CommonStruct = xx;

									Execute();
									return;
								}
								catch(Exception ex)
								{
									WriteLine(ex.ToString());
									recipe = null;
									return;
								}
							}
						}
						WriteLine("Invalid recipe id, try again...");
					}
					catch
					{
						WriteLine("Recipeid must a number, try again...");
					}
				}
			}

			Console.ReadLine();
		}

		#endregion run from list

		
	}
}
