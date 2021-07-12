using System;
using System.Collections;
using SiGlaz.Recipes;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for DDARecipe.
	/// </summary>
	public class DDARecipe : Recipe
	{
		public int				PrevRecipeID = -1;
		public string			PrevRecipeName = string.Empty;

		public int				SignatureID = -1;//Euqual to SignanureKey 
		public int				SignatureCode = 0;//Equal to SignatureID in DDA Professional

		public string			SignatureName = string.Empty;

		//		public short			FabKey = 0;
		//		public string			FabID = string.Empty;//empty is all Fab

		public string			TesterType = string.Empty;

		public bool				BreakWhenFound = false;

		//Temp	field for debug
		public TextHistory		TextHistory = new TextHistory();
		public TextHistory		TraceHistory = new TextHistory();

		public InterProcessRecipeEvent			ListenEvent;
		public ArrayList						ChildrenIDList;

		public DDARecipe() : base()
		{
		}

		public SiGlaz.Common.DDA.DDARecipe	CommonStruct
		{
			get
			{
				SiGlaz.Common.DDA.DDARecipe result = new SiGlaz.Common.DDA.DDARecipe();

				result.RecipeKey = this.ID;
				result.RecipeName = this.Name;
				result.PrevRecipeKey = this.PrevRecipeID;
				result.SCKey = this.SignatureID;
				result.SignatureCode = this.SignatureCode;//new
				result.SignatureName = this.SignatureName;
				result.Description = this.Description;
				result.TesterType = this.TesterType;
				result.BreakWhenFound = this.BreakWhenFound;

				result.RawData = this.SerializeBinary();
				return result;
			}
			set
			{
				this.Clear();
				if(value!=null)
					this.DeserializeBinary(value.RawData);

				this.ID =value.RecipeKey;
				this.Name =value.RecipeName;
				this.PrevRecipeID =value.PrevRecipeKey;
				this.SignatureID= value.SCKey;
				this.SignatureCode = value.SignatureCode;
				this.SignatureName=value.SignatureName;
				this.Description=value.Description;
				this.TesterType = value.TesterType;
				this.BreakWhenFound = value.BreakWhenFound;
			}
		}

		public override Shape CreateInstanceOfShape(string objectname)
		{
			Shape obj = base.CreateInstanceOfShape (objectname);
			if(obj==null)
				obj = typeof(DDARecipe).Assembly.CreateInstance(objectname) as Shape;
			return obj;
		}

		public override bool ProcessNoteExceptionAndSkipRunToEnd(WorkingSpace workingspace, Node node, Exception ex)
		{
			if(ex is SSA.Business.Facade.BFacadeTC.NonFatalException) 
			{
				RaiseMessage(node,workingspace.CreateEventArgs(ex.ToString()));
				return false;
			}
			else
			{
				return base.ProcessNoteExceptionAndSkipRunToEnd (workingspace, node, ex);
			}
		}

		public override void ProcessOnStop(WorkingSpace workingspace, Node node)
		{
			//base.ProcessOnStop (workingspace, node);
			RestoreProcessing(workingspace,node);
		}

		private void RestoreProcessing(WorkingSpace workingspace,Node node)
		{
			if(workingspace.NoConnectToDatabase)
				return;

			//if(node is End) return;//the end 
			if(node is Begin) return;
            DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.SurfaceKey<=0) return;

			try
			{
				WebServiceProxy.SurfaceCmd  cmd = new WebServiceProxy.SurfaceCmd();
				cmd.Processed_Delete(this.ID,working.SurfaceKey);
			}
			catch//(Exception ex)
			{
//				Console.WriteLine(ex.Message);
//				Console.WriteLine(ex.StackTrace);
				//RaiseExceptionNode(node,working.CreateEventArgs(ex.Message));
			}
		}

		public override bool ExecuteBefore(WorkingSpace workingspace)
		{
			if(workingspace.NoConnectToDatabase)
				return true;

			try
			{
				WebServiceProxy.RecipeCmd cmd = new WebServiceProxy.RecipeCmd();
//				cmd.UpdateStatus(this.ID,SiGlaz.Common.DDA.eRecipeStatus.Running);
				this.ChildrenIDList = cmd.GetNextRecipeKey(this.ID,true);
				this.ListenEvent = new InterProcessRecipeEvent(this.ID);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public override bool ExecuteAfter(WorkingSpace workingspace)
		{
			if(workingspace.NoConnectToDatabase)
				return true;

			//base.ExecuteAfter ();
			if(this.ListenEvent!=null)
			{
				this.ListenEvent.Dispose();
				this.ListenEvent = null;
			}

			return true;

//			try
//			{
//				WebServiceProxy.RecipeCmd cmd = new WebServiceProxy.RecipeCmd();
//				cmd.UpdateStatus(this.ID,SiGlaz.Common.DDA.eRecipeStatus.Normal);
//
//				return true;
//			}
//			catch
//			{
//				return false;
//			}

		}

		public bool Execute(DDAWorkingSpace workingspace,SSA.SystemFrameworks.KlarfParserFile surface)
		{
			if(surface==null) 
				return false;

			if(!ExecutePrepare(workingspace))
				return false;

			workingspace.NoConnectToDatabase = true;
			workingspace.SourceMap = surface;

			Execute(workingspace);

			return true;
		}

		#region archive

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write(PrevRecipeID);
			stream.Write(PrevRecipeName);
			stream.Write(SignatureID);
			stream.Write(SignatureName);
			stream.Write(SignatureCode);
			stream.Write(TesterType);
			stream.Write(BreakWhenFound);
		}

		public override void Deserialize(System.IO.BinaryReader stream)
		{
			base.Deserialize (stream);
			PrevRecipeID = stream.ReadInt32();
			PrevRecipeName = stream.ReadString();
			SignatureID = stream.ReadInt32();
			SignatureName = stream.ReadString();
			if(VersionNumber>=5)
			{
				SignatureCode = stream.ReadInt32();
				TesterType = stream.ReadString();
				BreakWhenFound = stream.ReadBoolean();
			}

		}

		#endregion archive

		#region check syntax

		public bool	IsAutoSignatureName()
		{
			return 
				this.Shapes.GetList(typeof(PatternRecognition)).Count > 0	
				||
				this.Shapes.GetList(typeof(FunctionalSignature)).Count > 0;
		}

		//tam thoi su dung cach nay de kiem tra, sau nay se su dung rule theo cau truc
		public override bool CheckFlow(ref string msg)
		{
			bool result = base.CheckFlow (ref msg);
			if(result)
			{
				bool issingle = Root.NextFirstNode is Surface;
				if(issingle)
				{
//					if(this.Shapes.GetList(typeof(LayerRepeater)).Count > 0)
//					{
//						msg = "Layer Repeater cannot be used for Single Layer";
//						result = false; 
//					}
				}
				else
				{
//					if(this.Shapes.GetList(typeof(CategorySelection)).Count > 0)
//					{
//						msg = "Category Selectioncannot be used for Multi Layer";
//						result = false; 
//					}
				}
			}

			return result;
		}

		#endregion check syntax

		#region static 

		public static DDARecipe	CreateNew(int id)
		{
			DDARecipe result = new DDARecipe();
			result.ID = id; 
			result.Name = "Recipe" + id.ToString();
			return result;
		}

		#endregion static 

		#region handler shared event

		public SiGlaz.SharedMemory.SendMonitor send = null;
		public SiGlaz.SharedMemory.ReceivedMonitor received = null;
		public void RunRecipe()
		{
			string cmdpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DDARMCmd.exe");
			if(System.IO.File.Exists(cmdpath))
				this.RunRecipe(cmdpath);
		}

		public void RunRecipe(string iBMACmdPath)
		{
			if( !System.IO.File.Exists(iBMACmdPath) )
				throw new System.IO.IOException(string.Format("File {0} do not eixits",iBMACmdPath));

			if(send!=null && received!=null)
				return;

			if(this.TextHistory==null)
				this.TextHistory = new TextHistory();

			if(this.TraceHistory==null)
				this.TraceHistory = new TextHistory();

			//Prepare data
			DDASharedData obj = new DDASharedData();
			obj.recipe = this;

			int	maxsize = obj.LengthEx; 

			//new monitor
			send = new SiGlaz.SharedMemory.SendMonitor("R" + this.ID + "_M2C",maxsize);
			received = new SiGlaz.SharedMemory.ReceivedMonitor("R" + this.ID + "_C2M",maxsize);
			received.OnReceived+=new SiGlaz.SharedMemory.EventHandlerReceived(received_OnReceived);

			//send data
			send.WriteBinary(obj);
			obj = null;

			System.Diagnostics.ProcessStartInfo proInfo = 
				new System.Diagnostics.ProcessStartInfo(iBMACmdPath,@"/Controler " +  this.ID + " " + SiGlaz.Common.DDA.AppData.Data.NumberOfProcessToReStart);

			//proInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			System.Diagnostics.Process.Start(proInfo);
		}

		public void Stop()
		{
			if(send==null || received==null) return;
			send.RaiseEvent((int)eMessage.STOPRECIPE);
		}

		private void received_OnReceived(SiGlaz.SharedMemory.SharedMessage msg)
		{
			switch((eMessage)msg.Message)
			{
				case eMessage.STARTRECIPE:
					HandlerStartRecipe();
					break;

				case eMessage.BEGINRECIPE:
					HandlerBeginRecipe();
					break;

				case eMessage.COMPLETERECIPE:
					HandlerCompleteRecipe();
					break;

				case eMessage.STOPRECIPE:
					HandlerStopRecipe();
					break;

				case eMessage.EXCEPTIONNODE:
					HandlerExceptionNode();
					break;
					
				case eMessage.MESSAGE:
					HandlerMessegeNode();
					break;

				case eMessage.BEGINNODE:
					HandlerBeginNode();
					break;

				case eMessage.COMPLETENODE:
					HandlerCompleteNode();
					break;

				case eMessage.WATINGDATA:
					HandlerWatingNode();
					break;

				case eMessage.EXCEPTION:
					HandlerExceptionRecipe();
					break;
			}
		}

		protected void HandlerExceptionRecipe()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			RaiseException(obj.eventobj);

			if(TraceHistory!=null && obj.eventobj!=null)
			{
				string msg = string.Format("Exception at [{0}]",this.Name) + string.Format(" \"{0}\" ",obj.eventobj.Message) ;
				DDADataFlowHeader flow =  (obj.eventobj as DDARecipeEventArgs).Header;
				if(flow!=null)
					msg +=string.Format(" --> Surface :{0}",flow.ToString() );

				TraceHistory.AddNewLine(msg);
			}
		}

		protected void HandlerStartRecipe()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			RaiseStart(obj.eventobj);

			if(TextHistory!=null)
				TextHistory.AddNewLine(string.Format("Start Recipe [{0}]",this.Name));
		}


		protected void HandlerBeginRecipe()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			RaiseBegin(obj.eventobj);

			if(TextHistory!=null)
				TextHistory.AddNewLine(string.Format("Begin Recipe [{0}]",this.Name));
		}

		protected void HandlerCompleteRecipe()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);

			string msg = string.Empty;
//			if(obj.eventobj!=null)
//			{
//				DDADataFlowHeader flow =  obj.eventobj.Header;
//				if(flow!=null)
//					msg =string.Format(" --> Surface :{0}",flow.ToString() );
//			}

			RaiseComplete(obj.eventobj);

			if(TextHistory!=null)
			{
				TextHistory.AddNewLine(string.Format("Complete process recipe [{0}] {1}",this.Name,msg));
				TextHistory.AddNewLine(string.Format("-----------------------------"));
			}
		}

		protected void HandlerStopRecipe()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			RaiseStop(obj.eventobj);
			if(received!=null)
			{
				received.OnReceived-=new SiGlaz.SharedMemory.EventHandlerReceived(received_OnReceived);
				received.Dispose();
				received = null;
			}
			if(send!=null)
			{
				send.Dispose();
				send = null;
			}

			if(TextHistory!=null)
				TextHistory.AddNewLine(string.Format("Stop processing recipe [{0}]",this.Name));

			//			this.TextHistory = null;
			//			this.TraceHistory = null;
		}

		protected void HandlerBeginNode()
		{
			if(!ShowProcessStep) return;
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			Node node = Shapes.SearchById(obj.idCurrentNode) as Node;
			if(node!=null)
			{
				RaiseBeginNode(node,obj.eventobj);

				if(TextHistory!=null)
					TextHistory.AddNewLine(string.Format("Begin to process node [{1}] of recipe [{0}]",this.Name,node.Name));
			}
			else
			{
				RaiseException(new DDARecipeEventArgs("HandlerBeginNode Cannot found node " + obj.idCurrentNode));
			}
		}

		protected void HandlerCompleteNode()
		{
			if(!ShowProcessStep) return;
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			Node node = Shapes.SearchById(obj.idCurrentNode) as Node;
			if(node!=null)
			{
				RaiseCompleteNode(node,obj.eventobj);

				if(TextHistory!=null)
				{
					string msg = string.Format("Node {1} of recipe [{0}] was completely processed",this.Name,node.Name);
//					DDADataFlowHeader flow =  (obj.eventobj as DDARecipeEventArgs).Header;
//					if(flow!=null)
//						msg +=string.Format(" --> Surface :{0}",flow.ToString() );
					TextHistory.AddNewLine(msg);
				}
			}
			else
			{
				RaiseException(new DDARecipeEventArgs("HandlerCompleteNode Cannot found node " + obj.idCurrentNode));
			}
		}

		protected void HandlerWatingNode()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			Node node = Shapes.SearchById(obj.idCurrentNode) as Node;
			if(node!=null)
			{
				RaiseWaitingForData(node,obj.eventobj);
//				if(TextHistory!=null)
//					TextHistory.AddNewLine(string.Format("Waiting new data for processing at node [{1}] of recipe [{0}]",this.Name,node.Name) );
			}
			else
			{
				RaiseException(new DDARecipeEventArgs("HandlerWatingNode Cannot found node " + obj.idCurrentNode));
			}
		}

		protected void HandlerExceptionNode()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			Node node = Shapes.SearchById(obj.idCurrentNode) as Node;
			if(node!=null)
			{
				RaiseExceptionNode(node,obj.eventobj);

				if(TraceHistory!=null && obj.eventobj!=null)
				{
					string msg = string.Format("Exception at node [{1}] of [{0}]",this.Name,node.Name) + string.Format(" \"{0}\" ",obj.eventobj.Message);
					DDADataFlowHeader flow =  (obj.eventobj as DDARecipeEventArgs).Header;
					if(flow!=null)
						msg +=string.Format(" --> Surface :{0}",flow.ToString() );
					TraceHistory.AddNewLine(msg);
				}
			}
			else
			{
				RaiseException(new DDARecipeEventArgs("HandlerExceptionNode Cannot found node " + obj.idCurrentNode));
			}
		}

		
		protected void HandlerMessegeNode()
		{
			DDASharedData obj = new DDASharedData();
			received.ReadBinary(obj);
			Node node = Shapes.SearchById(obj.idCurrentNode) as Node;
			if(node!=null)
			{
				RaiseMessage(node,obj.eventobj);

				if(TextHistory!=null && obj.eventobj!=null)
				{
					string msg = string.Format("Message at node [{1}] of [{0}]",this.Name,node.Name) + string.Format(" \"{0}\" ",obj.eventobj.Message);
//					DDADataFlowHeader flow =  (obj.eventobj as DDARecipeEventArgs).Header;
//					if(flow!=null)
//						msg +=string.Format(" --> Surface :{0}",flow.ToString() );
					TextHistory.AddNewLine(msg);
				}
			}
			else
			{
				RaiseException(new DDARecipeEventArgs("HandlerMessegeNode Cannot found node " + obj.idCurrentNode));
			}
		}

		#endregion handler shared event

		#region Import 

		public void Import(SiGlaz.DDA.Framework.Automation.SignatureRecipe obj)
		{
			this.SignatureID = obj.ID;
			this.SignatureName = obj.Name;
			this.BreakWhenFound = obj.Break;//new

			//this.SignatureCode = obj.ID;//be assign out of scope

			this.Description = obj.Description;

			this.ID = obj.ID;
			this.Name = obj.Name;

			int x = 200, y = 50;

			//Add Begin Node
			Node nodeBegin = (Node)this.AddNode(typeof(Begin), x, y);

			//Add Source Node
			y += 100;
			Node nodeSource = (Node)this.AddNode(typeof(Surface), x, y);

			//Add Link
			this.AddLink(typeof(Link), nodeBegin, nodeSource);

			Node beginNode = nodeSource;

			foreach (SiGlaz.DDA	.Framework.Automation.BaseStep step in obj.Steps)
			{
				Node node = null;
				if (step.GetType() == typeof(SiGlaz.DDA	.Framework.Automation.SwitchModeStep))
					node = new SwitchMode();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByChannelStep))
					node = new ChannelFilter();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.RemoveDuplicateDefectStep))
					node = new RemoveDuplicateDefects();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByKnnMinMaxStep))
					node = new KnnMinMaxFilter();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByKnnPercentStep))
					node = new KnnPercentFilter();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterBySignature))
				{
					y += 100;
					node = new AdvancedSignature();
					node.Import(step);
					this.AddNode(node, x, y);

					//Add Link
					this.AddLink(typeof(Link), beginNode, node);
					beginNode = node;

					node = new ResultFilter();
				}
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByFlatSignature))
				{
					y += 100;
					node = new FlatViewAdvancedSignature();
					node.Import(step);
					this.AddNode(node, x, y);

					//Add Link
					this.AddLink(typeof(Link), beginNode, node);
					beginNode = node;

					node = new ResultFilter();
				}
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByZonalStep))
				{
					y += 100;
					node = new ZonalProcess();
					node.Import(step);
					this.AddNode(node, x, y);

					//Add Link
						this.AddLink(typeof(Link), beginNode, node);
					beginNode = node;

					node = new ResultFilter();
				}
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FilterByTesterNoiseStep))
				{
					y += 100;
					node = new TesterNoiseDetection();
					node.Import(step);
					this.AddNode(node, x, y);

					//Add Link
					this.AddLink(typeof(Link), beginNode, node);
					beginNode = node;

					node = new ResultFilter();
				}
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FunctionSignatureStep))
					node = new FunctionalSignature();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.LinkDefectFilterStep))
					node = new LinkDefectFilter();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.LinkDefectStep))
					node = new LinkDefect();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.PatternStep))
					node = new PatternRecognition();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.SignatureStep))
					node = new AdvancedSignature();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.FlatSignatureStep))
					node = new FlatViewAdvancedSignature();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.UnlinkDefectStep))
					node = new UnlinkDefect();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.ZonalStep))
					node = new ZonalProcess();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.SpiralSignatureStep))
					node = new SpiralSignature();
				else if (step.GetType() == typeof(SiGlaz.DDA.Framework.Automation.TesterNoiseDetectionStep))
					node = new TesterNoiseDetection();
				
				if (node != null)
				{
					y += 100;
					node.Import(step);
					this.AddNode(node, x, y);

					//Add Link
					this.AddLink(typeof(Link), beginNode, node);
					beginNode = node;
				}
			}

			//Add Decision Node
			y += 100;
			Node nodeDecision = (Node)this.AddNode(typeof(Decision), x, y);

			//Add Link
			this.AddLink(typeof(Link), beginNode, nodeDecision);

			//Add Output Node
			x -= 50;
			y += 100;
			Node nodeOutput = (Node)this.AddNode(typeof(Output), x, y);

			//Add True Link
			this.AddLink(typeof(TrueLink), nodeDecision, nodeOutput);

			//Add End Node
			x += 100;
			Node nodeEnd = (Node)this.AddNode(typeof(End), x, y);

			//Add False Link
			this.AddLink(typeof(FalseLink), nodeDecision, nodeEnd);
			this.AddLink(typeof(Link), nodeOutput, nodeEnd);
		}

		#endregion Import 

	}
}
