using System;
using System.Collections;

using DDARecipeRObjects;
using DDADBRObjects;

using SiGlaz.Recipes;
using DDARecipe;

using System.Windows.Forms;

namespace DDARMController
{
	/// <summary>
	/// Summary description for RemotableEventController.
	/// </summary>
	public class RemotableEventController
	{
		public static RemotableEventController Controler = new RemotableEventController();

		RRecipeList								_RemoteRecipeList = null;
		public RRecipeListEvent					_RemoteEvent = new RRecipeListEvent();

		public RSchema							RemoteSchema = null;

		public	ArrayList						RecipeList = new ArrayList();	

		public	bool							stop = false;

		public RemotableEventController()
		{
		}

		public RRecipeList			RemoteRecipeList
		{
			get
			{
				return _RemoteRecipeList;
			}
		}

		
		public static void ProcessFailToConnectToServices(Exception ex)
		{
			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			MessageBox.Show(Application.ProductName + " Cannot connect to DDA Services. Please start the DDA Services and try again.\nError :" + ex.Message + "\nAppication exit",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

		public void InitRemotingObjects()
		{
			try
			{
				_RemoteRecipeList = new RRecipeList();
				RemoteSchema = new RSchema();

                _RemoteRecipeList.OnStart += new RecipeEventHandler(_RemoteEvent.HandlerOnStart);
                _RemoteRecipeList.OnStop += new RecipeEventHandler(_RemoteEvent.HandlerOnStop);
                _RemoteRecipeList.OnBegin += new RecipeEventHandler(_RemoteEvent.HandlerOnBegin);
                _RemoteRecipeList.OnBeginNode += new NodeEventHandler(_RemoteEvent.HandlerOnBeginNode);
                _RemoteRecipeList.OnComplete += new RecipeEventHandler(_RemoteEvent.HandlerOnComplete);
                _RemoteRecipeList.OnCompleteNode += new NodeEventHandler(_RemoteEvent.HandlerOnCompleteNode);
                _RemoteRecipeList.OnException += new RecipeEventHandler(_RemoteEvent.HandlerOnException);
                _RemoteRecipeList.OnExceptionNode += new NodeEventHandler(_RemoteEvent.HandlerOnExceptionNode);
                _RemoteRecipeList.OnMessage += new NodeEventHandler(_RemoteEvent.HandlerOnMessage);
                _RemoteRecipeList.OnWaitingForData += new NodeEventHandler(_RemoteEvent.HandlerOnWaitingForData);

				_RemoteRecipeList.OnRefresh+=new MessageEventHandler(_RemoteEvent.HandlerOnRefresh);

				_RemoteEvent.OnBegin+=new RecipeEventHandler(_RemoteEvent_OnBegin);
				_RemoteEvent.OnBeginNode+=new NodeEventHandler(_RemoteEvent_OnBeginNode);
				_RemoteEvent.OnComplete+=new RecipeEventHandler(_RemoteEvent_OnComplete);
				_RemoteEvent.OnCompleteNode+=new NodeEventHandler(_RemoteEvent_OnCompleteNode);
				_RemoteEvent.OnException+=new RecipeEventHandler(_RemoteEvent_OnException);
				_RemoteEvent.OnExceptionNode+=new NodeEventHandler(_RemoteEvent_OnExceptionNode);
				_RemoteEvent.OnMessage+=new NodeEventHandler(_RemoteEvent_OnMessage);
				_RemoteEvent.OnStart+=new RecipeEventHandler(_RemoteEvent_OnStart);
				_RemoteEvent.OnStop+=new RecipeEventHandler(_RemoteEvent_OnStop);
				_RemoteEvent.OnWaitingForData+=new NodeEventHandler(_RemoteEvent_OnWaitingForData);

			}
			catch
			{
				throw;
			}
		}

		public void FreeRemotingObject()
		{
			if(_RemoteRecipeList==null) return;

			try
			{
				_RemoteRecipeList.OnStart-=new RecipeEventHandler(_RemoteEvent.HandlerOnStart);
				_RemoteRecipeList.OnStop-=new RecipeEventHandler(_RemoteEvent.HandlerOnStop);
				_RemoteRecipeList.OnBegin-=new RecipeEventHandler(_RemoteEvent.HandlerOnBegin);
				_RemoteRecipeList.OnBeginNode-=new NodeEventHandler(_RemoteEvent.HandlerOnBeginNode);
				_RemoteRecipeList.OnComplete-=new RecipeEventHandler(_RemoteEvent.HandlerOnComplete);
				_RemoteRecipeList.OnCompleteNode-=new NodeEventHandler(_RemoteEvent.HandlerOnCompleteNode);
				_RemoteRecipeList.OnException-=new RecipeEventHandler(_RemoteEvent.HandlerOnException);
				_RemoteRecipeList.OnExceptionNode-=new NodeEventHandler(_RemoteEvent.HandlerOnExceptionNode);
				_RemoteRecipeList.OnMessage-=new NodeEventHandler(_RemoteEvent.HandlerOnMessage);
				_RemoteRecipeList.OnWaitingForData-=new NodeEventHandler(_RemoteEvent.HandlerOnWaitingForData);

				_RemoteRecipeList.OnRefresh-=new MessageEventHandler(_RemoteEvent.HandlerOnRefresh);

				_RemoteEvent.OnBegin-=new RecipeEventHandler(_RemoteEvent_OnBegin);
				_RemoteEvent.OnBeginNode-=new NodeEventHandler(_RemoteEvent_OnBeginNode);
				_RemoteEvent.OnComplete-=new RecipeEventHandler(_RemoteEvent_OnComplete);
				_RemoteEvent.OnCompleteNode-=new NodeEventHandler(_RemoteEvent_OnCompleteNode);
				_RemoteEvent.OnException-=new RecipeEventHandler(_RemoteEvent_OnException);
				_RemoteEvent.OnExceptionNode-=new NodeEventHandler(_RemoteEvent_OnExceptionNode);
				_RemoteEvent.OnMessage-=new NodeEventHandler(_RemoteEvent_OnMessage);
				_RemoteEvent.OnStart-=new RecipeEventHandler(_RemoteEvent_OnStart);
				_RemoteEvent.OnStop-=new RecipeEventHandler(_RemoteEvent_OnStop);
				_RemoteEvent.OnWaitingForData-=new NodeEventHandler(_RemoteEvent_OnWaitingForData);

			}
			catch
			{
			}
		}

		private bool CheckRecipeIndex(int recipeindex)
		{
			return this.RecipeList.Count>recipeindex;
		}

		private void _RemoteEvent_OnBegin(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
	
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			recipe.RaiseBegin(e);
			
			if(recipe.TextHistory!=null)
				recipe.TextHistory.AddNewLine(string.Format("Begin Recipe [{0}]",recipe.Name));
		}

		private void _RemoteEvent_OnBeginNode(int RecipeIndex, int nodeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			if(!recipe.ShowProcessStep) return;

			Node node = recipe.Shapes.SearchById(nodeIndex) as Node;
			if(node!=null)
			{
				recipe.RaiseBeginNode(node,e);

				if(recipe.TextHistory!=null)
					recipe.TextHistory.AddNewLine(string.Format("Begin to process node [{1}] of recipe [{0}]",recipe.Name,node.Name));
			}
			else
			{
				recipe.RaiseException(new DDARecipeEventArgs("HandlerBeginNode Cannot found node " + nodeIndex));
			}
		}

		private void _RemoteEvent_OnComplete(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;

			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			recipe.RaiseComplete(e);

			if(recipe.TextHistory!=null)
			{
				recipe.TextHistory.AddNewLine(string.Format("Complete process recipe [{0}]",recipe.Name));
				recipe.TextHistory.AddNewLine(string.Format("-----------------------------"));
			}
		}

		private void _RemoteEvent_OnException(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;

			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			recipe.RaiseException(e);

			if(recipe.TraceHistory!=null)
			{
				string msg = string.Format("Exception at [{0}]",recipe.Name) + string.Format(" \"{0}\" ",e.Message) ;
				DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
				if(flow!=null)
					msg +=string.Format(" --> Surface :{0}",flow.ToString() );

				recipe.TraceHistory.AddNewLine(msg);
			}
		}

		private void _RemoteEvent_OnCompleteNode(int RecipeIndex, int nodeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			if(!recipe.ShowProcessStep) return;
	
			Node node = recipe.Shapes.SearchById(nodeIndex) as Node;
			if(node!=null)
			{
				recipe.RaiseCompleteNode(node,e);

				if(recipe.TextHistory!=null)
				{
					string msg = string.Format("Node {1} of recipe [{0}] was completely processed",recipe.Name,node.Name);
					recipe.TextHistory.AddNewLine(msg);

//					recipe.TextHistory.AddNewLine(string.Format("Node {1} of recipe [{0}] was completely processed",recipe.Name,node.Name));
//					DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
//					if(flow!=null)
//						recipe.TextHistory.AddNewLine(string.Format(" --> LOT :{0} DISK :{1} ", flow.LotID,flow.DiskID));
				}

			}
			else
			{
				recipe.RaiseException(new DDARecipeEventArgs("HandlerCompleteNode Cannot found node " + nodeIndex));
			}
		}

		private void _RemoteEvent_OnExceptionNode(int RecipeIndex, int nodeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
	
			Node node = recipe.Shapes.SearchById(nodeIndex) as Node;
			if(node!=null)
			{
				recipe.RaiseExceptionNode(node,e);

				if(recipe.TraceHistory!=null)
				{
					string msg = string.Format("Exception at node [{1}] of [{0}]",recipe.Name,node.Name) + string.Format(" \"{0}\" ",e.Message);
					DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
					if(flow!=null)
						msg +=string.Format(" --> Surface :{0}",flow.ToString() );
					recipe.TraceHistory.AddNewLine(msg);
//					recipe.TraceHistory.AddNewLine(string.Format("Exception at node [{1}] of [{0}]",recipe.Name,node.Name) );
//					recipe.TraceHistory.AddNewLine(string.Format("\"{0}\" ",e.Message) );
//					DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
//					if(flow!=null)
//						recipe.TraceHistory.AddNewLine(string.Format(" --> LOT :{0} DISK :{1} ", flow.LotID,flow.DiskID) );
				}
			}
			else
			{
				recipe.RaiseException(new DDARecipeEventArgs("HandlerExceptionNode Cannot found node " + nodeIndex));
			}
		}

		private void _RemoteEvent_OnMessage(int RecipeIndex, int nodeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
			
			Node node = recipe.Shapes.SearchById(nodeIndex) as Node;
			if(node!=null)
			{
				recipe.RaiseMessage(node,e);

				if(recipe.TextHistory!=null)
				{
					string msg = string.Format("Message at node [{1}] of [{0}]",recipe.Name,node.Name) + string.Format(" \"{0}\" ",e.Message);
					//					DDADataFlowHeader flow =  (obj.eventobj as DDARecipeEventArgs).Header;
					//					if(flow!=null)
					//						msg +=string.Format(" --> Surface :{0}",flow.ToString() );
					recipe.TextHistory.AddNewLine(msg);
//
//					recipe.TextHistory.AddNewLine(string.Format("Message at node [{1}] of [{0}]",recipe.Name,node.Name) );
//					recipe.TextHistory.AddNewLine(string.Format("\"{0}\" ",e.Message) );
//					DDADataFlowHeader flow =  (e as DDARecipeEventArgs).Header;
//					if(flow!=null)
//						recipe.TextHistory.AddNewLine(string.Format(" --> LOT :{0} DISK :{1} ", flow.LotID,flow.DiskID ) );
				}
			}
			else
			{
				recipe.RaiseException(new DDARecipeEventArgs("HandlerMessegeNode Cannot found node " + nodeIndex));
			}
		}

		private void _RemoteEvent_OnStart(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;

			recipe.WaitingToRun = false;
			recipe.RaiseStart(e);

			if(recipe.TextHistory!=null)
				recipe.TextHistory.AddNewLine(string.Format("Start Recipe [{0}]",recipe.Name));
		}

		private void _RemoteEvent_OnStop(int RecipeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;

			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;

			recipe.WaitingToStop = false;
			recipe.RaiseStop(e);

			if(recipe.TextHistory!=null)
				recipe.TextHistory.AddNewLine(string.Format("Stop processing recipe [{0}]",recipe.Name));
		}

		private void _RemoteEvent_OnWaitingForData(int RecipeIndex, int nodeIndex, SiGlaz.Recipes.RecipeEventArgs e)
		{
			if(stop) return;
			if(!CheckRecipeIndex(RecipeIndex)) return;
			DDARecipe.DDARecipe recipe = this.RecipeList[RecipeIndex] as DDARecipe.DDARecipe;
	
			Node node = recipe.Shapes.SearchById(nodeIndex) as Node;
			if(node!=null)
			{
				recipe.RaiseWaitingForData(node,e);

//				if(recipe.TextHistory!=null)
//					recipe.TextHistory.AddNewLine(string.Format("Waiting new data for processing at node [{1}] of recipe [{0}]",recipe.Name,node.Name) );
			}
			else
			{
				recipe.RaiseException(new DDARecipeEventArgs("HandlerWatingNode Cannot found node " + nodeIndex));
			}
		}

	
	}
}
