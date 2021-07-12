using System;
using System.Reflection;
using System.Runtime.InteropServices;
using DDADBRObjects;
using DDARecipeRObjects;

using System.Windows.Forms;

namespace DDADBManagerController
{
	/// <summary>
	/// Summary description for RemotableSchemacController.
	/// </summary>
	public class RemotableSchemacController
	{
		public static RemotableSchemacController SchemaControler = new RemotableSchemacController();

		public DDADBManager.Process.Schema Schema = new DDADBManager.Process.Schema();

		RSchema			_RemoteSchema ;
		public			RSchemaEvent	_RemoteEvent = new RSchemaEvent();

		public RRecipeList	RemoteRecipeList = null;


		public RemotableSchemacController()
		{
		}

		public RSchema			RemoteSchema
		{
			get
			{
				return _RemoteSchema;
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
				_RemoteSchema = new RSchema();
				RemoteRecipeList = new RRecipeList();

				_RemoteSchema.OnBeginProcess+=new EventHandlerProcess(_RemoteEvent.HandlerBeginProcess);
				_RemoteSchema.OnEndProcess+=new EventHandlerProcess(_RemoteEvent.HandlerEndProcess);
				_RemoteSchema.OnError+=new EventHandlerProcessError(_RemoteEvent.HandlerProcessError);
				_RemoteSchema.OnProcess+=new EventHandlerProcess(_RemoteEvent.HandlerProcess);
				_RemoteSchema.OnProcessInfo+=new EventHandlerProcessInfor(_RemoteEvent.HandlerProcessInfor);
				_RemoteSchema.OnTextAddNewLine+=new EventHandlerProcess(_RemoteEvent.HandlerTextAddNewLine);
				_RemoteSchema.OnTraceAddNewLine+=new EventHandlerProcess(_RemoteEvent.HandlerTraceAddNewLine);
				_RemoteSchema.OnStatusChange+=new EventHandlerProcessInfor(_RemoteEvent.HandlerStatusChange);

				_RemoteSchema.OnRefresh+=new MessageHandler(_RemoteEvent.HandlerOnRefresh);

				_RemoteEvent.OnBeginProcess+=new EventHandlerProcess(_RemoteEvent_OnBeginProcess);
				_RemoteEvent.OnEndProcess+=new EventHandlerProcess(_RemoteEvent_OnEndProcess);
				_RemoteEvent.OnError+=new EventHandlerProcessError(_RemoteEvent_OnError);
				_RemoteEvent.OnProcess+=new EventHandlerProcess(_RemoteEvent_OnProcess);
				_RemoteEvent.OnProcessInfo+=new EventHandlerProcessInfor(_RemoteEvent_OnProcessInfo);
				_RemoteEvent.OnTextAddNewLine+=new EventHandlerProcess(_RemoteEvent_OnTextAddNewLine);
				_RemoteEvent.OnTraceAddNewLine+=new EventHandlerProcess(_RemoteEvent_OnTraceAddNewLine);
				_RemoteEvent.OnStatusChange+=new EventHandlerProcessInfor(_RemoteEvent_OnStatusChange);
			}
			catch
			{
				throw;
			}
		}

		public void FreeRemotingObject()
		{
			try
			{
				if(_RemoteSchema==null) return;
	
				_RemoteSchema.OnBeginProcess-=new EventHandlerProcess(_RemoteEvent.HandlerBeginProcess);
				_RemoteSchema.OnEndProcess-=new EventHandlerProcess(_RemoteEvent.HandlerEndProcess);
				_RemoteSchema.OnError-=new EventHandlerProcessError(_RemoteEvent.HandlerProcessError);
				_RemoteSchema.OnProcess-=new EventHandlerProcess(_RemoteEvent.HandlerProcess);
				_RemoteSchema.OnProcessInfo-=new EventHandlerProcessInfor(_RemoteEvent.HandlerProcessInfor);
				_RemoteSchema.OnTextAddNewLine-=new EventHandlerProcess(_RemoteEvent.HandlerTextAddNewLine);
				_RemoteSchema.OnTraceAddNewLine-=new EventHandlerProcess(_RemoteEvent.HandlerTraceAddNewLine);
				_RemoteSchema.OnStatusChange-=new EventHandlerProcessInfor(_RemoteEvent.HandlerStatusChange);

				_RemoteSchema.OnRefresh-=new MessageHandler(_RemoteEvent.HandlerOnRefresh);

				_RemoteEvent.OnBeginProcess-=new EventHandlerProcess(_RemoteEvent_OnBeginProcess);
				_RemoteEvent.OnEndProcess-=new EventHandlerProcess(_RemoteEvent_OnEndProcess);
				_RemoteEvent.OnError-=new EventHandlerProcessError(_RemoteEvent_OnError);
				_RemoteEvent.OnProcess-=new EventHandlerProcess(_RemoteEvent_OnProcess);
				_RemoteEvent.OnProcessInfo-=new EventHandlerProcessInfor(_RemoteEvent_OnProcessInfo);
				_RemoteEvent.OnTextAddNewLine-=new EventHandlerProcess(_RemoteEvent_OnTextAddNewLine);
				_RemoteEvent.OnTraceAddNewLine-=new EventHandlerProcess(_RemoteEvent_OnTraceAddNewLine);
				_RemoteEvent.OnStatusChange-=new EventHandlerProcessInfor(_RemoteEvent_OnStatusChange);
			}
			catch
			{
			}
		}


		private void _RemoteEvent_OnProcess(string filepath, ProcessEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				DDADBManager.ProcessEventArgs eo = new DDADBManager.ProcessEventArgs(e.Filepath);
				eo.Abort = e.Abort;

				try
				{
						(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).HandlerProcess(filepath,eo);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		private void _RemoteEvent_OnBeginProcess(string filepath, ProcessEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				DDADBManager.ProcessEventArgs eo = new DDADBManager.ProcessEventArgs(e.Filepath);
				eo.Abort = e.Abort;

				try
				{
						(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).HandlerBeginProcess(filepath,eo);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}

				
			}
		}

		private void _RemoteEvent_OnEndProcess(string filepath, ProcessEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				DDADBManager.ProcessEventArgs eo = new DDADBManager.ProcessEventArgs(e.Filepath);
				eo.Abort = e.Abort;
				try
				{
						(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).HandlerEndProcess(filepath,eo);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		private void _RemoteEvent_OnError(string msg, FileControllerErrorEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				try
				{
						DDADBManager.FileControllerErrorEventArgs eo = new DDADBManager.FileControllerErrorEventArgs(e.obj,e.msg);
						(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).HandlerProcessError(msg,eo);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		private void _RemoteEvent_OnProcessInfo(string description, ProcessBaseEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				try
				{
					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).HandlerProcessInfor(description,EventArgs.Empty);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		private void _RemoteEvent_OnTextAddNewLine(string filepath, ProcessEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				try
				{
					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).OutputHistory.AddNewText(e.ProcessID,filepath);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		private void _RemoteEvent_OnTraceAddNewLine(string filepath, ProcessEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{
				try
				{
					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).TraceHistory.AddNewText(e.ProcessID,filepath);
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}

		}

		private void _RemoteEvent_OnStatusChange(string description, ProcessBaseEventArgs e)
		{
			if(Schema[e.ProcessID] is DDADBManager.Process.ProcessBase)
			{	
				try
				{
					bool isrunning = _RemoteSchema.RequireRunning(e.ProcessID);
					bool iswaiting = _RemoteSchema.RequireWaiting(e.ProcessID);

					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).IsWaiting=iswaiting;
					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).IsRunning = isrunning;

					(Schema[e.ProcessID] as DDADBManager.Process.ProcessBase).RaiseChangeStatus();
				}
				catch(Exception ex)
				{
					RemotableSchemacController.ProcessFailToConnectToServices(ex);
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		public void RequireSchema()
		{
			try
			{
				SchemaEvent e =_RemoteSchema.RequireSchema();
				this.Schema = e.Schema;
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
			}
		}

		public void SaveShema()
		{
			try
			{
				SchemaEvent e = new SchemaEvent();//_RemoteSchema.RequireSchema();
				e.Schema = this.Schema;
				_RemoteSchema.SaveSchema(e);
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
			}
		}

		public string RunProcess(int id)
		{
			try
			{
				return _RemoteSchema.RunProcess(id);
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
				return string.Empty;
			}
		}

		public string  RunAllProcess()
		{
			try
			{
				return _RemoteSchema.RunAllProcesses();
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
				return string.Empty;
			}
		}

		public void StopProcess(int id)
		{
			try
			{
				_RemoteSchema.StopProcess(id);
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
			}
		}

		public void StopAllProcess()
		{
			try
			{
				_RemoteSchema.StopAllProcesses();
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
			}
		}

	
	}
}
