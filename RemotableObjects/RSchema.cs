using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

using System.Collections;
using System.Collections.Specialized;

namespace DDADBRObjects
{
	/// <summary>
	/// Summary description for RSchema.
	/// </summary>
	public class RSchema : RSchemaEvent, IRSchemaMethod	
	{
		public RSchema()
		{
		}
		
		#region IRSchemaMethod Members

		public SchemaEvent RequireSchema()
		{
			DDADBManager.Process.Schema schema = Cache.GetInstance().Schema;
			byte[] lpbyte = schema.SerializeBinary();
			SchemaEvent e = new SchemaEvent(lpbyte);
			return e;
		}

		public void SaveSchema(SchemaEvent e)
		{
			Cache.GetInstance().SaveSchema(e);
		}

		public string RunProcess(params int[] processid)
		{
			if(processid==null || processid.Length<=0) return "TaksList is null";
			foreach(int i in processid)
			{
				string sinvalid = Cache.GetInstance().RunProcess(i);
				if(sinvalid!=string.Empty)
				{
					return sinvalid;
				}
			}
			return string.Empty;
		}

		public void StopProcess(params int[] processid)
		{
			if(processid==null || processid.Length<=0) return;
			foreach(int i in processid)
			{
				Cache.GetInstance().StopProcess(i);
			}
		}


		public string RunAllProcesses()
		{
			return Cache.GetInstance().RunAllProcesses();
		}

		public void StopAllProcesses()
		{
			Cache.GetInstance().StopAllProcesses();
		}

		public byte[] RequireApplicationConfig()
		{
			return SiGlaz.Common.DDA.AppData.Data.SaveApplicationData();
		}

		public bool SaveApplicationConfig(byte[] lpbyte)
		{
			SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);

			//Save to disk
			DDARecipe.DDAExternalData.SaveApplicationData();

			return true;
		}

		public StringCollection RequireOutput(int processid)
		{
			return Cache.GetInstance().Schema[processid].OutputHistory._ContentLine;
		}

		public StringCollection RequireTrace(int processid)
		{
			return Cache.GetInstance().Schema[processid].TraceHistory._ContentLine;
		}

		public SiGlaz.DAL.ConnectionParam GetConnectionParam()
		{
			return Cache.GetInstance().ConnectionParam;
		}

		public void SetConnectionParam(SiGlaz.DAL.ConnectionParam param)
		{
			Cache.GetInstance().ConnectionParam = param;
			Cache.GetInstance().ConnectionParam.Save(Cache.GetInstance().ConnectionFilePath);
		}

		public bool RequireWaiting(int processid)
		{
			return Cache.GetInstance().Schema[processid].IsWaiting;
		}

		public bool RequireRunning(int processid)
		{
			return Cache.GetInstance().Schema[processid].IsRunning;
		}


		public void RegisterEvent()
		{
			if(Cache.GetInstance().NumberOfClient<=0)
			{
				DDADBManager.Process.Schema schema = Cache.GetInstance().Schema;
				for(int i=0;i<schema.ProcessCount;i++)
				{
					DDADBManager.Process.ProcessBase process = schema.Process[i] as DDADBManager.Process.ProcessBase;
					process.ID = i;

					process.OnBeginProcess+=new DDADBManager.EventHandlerProcess(process_OnBeginProcess);
					process.OnEndProcess+=new DDADBManager.EventHandlerProcess(process_OnEndProcess);
					process.OnError+=new DDADBManager.EventHandlerProcessError(process_OnError);
					process.OnProcess+=new DDADBManager.EventHandlerProcess(process_OnProcess);
					process.OnProcessInfo+=new DDADBManager.EventHandlerProcessInfor(process_OnProcessInfo);
					process.OutputHistory.OnAddNewLine+=new DDADBManager.Modal.MessageLine(OutputHistory_OnAddNewLine);
					process.TraceHistory.OnAddNewLine+=new DDADBManager.Modal.MessageLine(TraceHistory_OnAddNewLine);
					process.OnStateChange+=new DDADBManager.EventHandlerProcessInfor(process_OnStateChange);
				}
			}
			Cache.GetInstance().NumberOfClient++;
		}

		public void UnRegisterEvent()
		{
			Cache.GetInstance().NumberOfClient--;
			if(Cache.GetInstance().NumberOfClient<=0)
			{
				DDADBManager.Process.Schema schema = Cache.GetInstance().Schema;
				for(int i=0;i<schema.ProcessCount;i++)
				{
					DDADBManager.Process.ProcessBase process = schema.Process[i] as DDADBManager.Process.ProcessBase;
					process.ID = i;

					process.OnBeginProcess-=new DDADBManager.EventHandlerProcess(process_OnBeginProcess);
					process.OnEndProcess-=new DDADBManager.EventHandlerProcess(process_OnEndProcess);
					process.OnError-=new DDADBManager.EventHandlerProcessError(process_OnError);
					process.OnProcess-=new DDADBManager.EventHandlerProcess(process_OnProcess);
					process.OnProcessInfo-=new DDADBManager.EventHandlerProcessInfor(process_OnProcessInfo);
					process.OutputHistory.OnAddNewLine-=new DDADBManager.Modal.MessageLine(OutputHistory_OnAddNewLine);
					process.TraceHistory.OnAddNewLine-=new DDADBManager.Modal.MessageLine(TraceHistory_OnAddNewLine);
					process.OnStateChange-=new DDADBManager.EventHandlerProcessInfor(process_OnStateChange);
				}
			}
		}

		#endregion

		#region handler Process event 

		private void process_OnBeginProcess(int id, string filepath, DDADBManager.ProcessEventArgs e)
		{
			ProcessEventArgs eo = new ProcessEventArgs(id,filepath);
			HandlerBeginProcess(filepath,eo);
		}

		private void process_OnEndProcess(int id, string filepath, DDADBManager.ProcessEventArgs e)
		{
			ProcessEventArgs eo = new ProcessEventArgs(id,filepath);
			HandlerEndProcess(filepath,eo);
		}

		private void process_OnError(int id, string msg, DDADBManager.FileControllerErrorEventArgs e)
		{
			FileControllerErrorEventArgs eo = new FileControllerErrorEventArgs(id,e.obj,e.msg);
			HandlerProcessError(msg,eo);
		}

		private void process_OnProcess(int id, string filepath, DDADBManager.ProcessEventArgs e)
		{
			ProcessEventArgs eo = new ProcessEventArgs(id,filepath);
			HandlerProcess(filepath,eo);
		}

		private void process_OnProcessInfo(int id, string description, EventArgs e)
		{
			ProcessBaseEventArgs eo = new ProcessBaseEventArgs(id);
			HandlerProcessInfor(description,eo);
		}

		private void OutputHistory_OnAddNewLine(int id, string message)
		{
			HandlerTextAddNewLine(message,new ProcessEventArgs(id,message));
		}

		private void TraceHistory_OnAddNewLine(int id, string message)
		{
			HandlerTraceAddNewLine(message,new ProcessEventArgs(id,message));
		}

		private void process_OnStateChange(int id, string description, EventArgs e)
		{
			HandlerStatusChange(description,new ProcessEventArgs(id,description));
		}	

	

		#endregion handler Process event

		#region IRSchemaMethod Members

		public bool RefreshExternalData()
		{
			DDARecipe.DDAExternalData.DiskTypeTableLastDate = DateTime.MinValue;
			return DDARecipe.DDAExternalData.RefreshDiskType();
		}

		#endregion

		#region IRSchemaMethod Members

		public bool AnyRun()
		{
			return Cache.GetInstance().AnyRun();
		}

		#endregion
	}
}
