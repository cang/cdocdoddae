using System;
using DDADBManager;
using DDADBManager.Process;
using System.IO;

namespace DDADBRObjects
{

	public class Cache
	{
		private static Cache myInstance;
//		public static IObserver Observer;
		
		private Cache()
		{
		}

//		public static void Attach(IObserver observer)
//		{
//			Observer = observer;
//		}

		public static Cache GetInstance()
		{
			if(myInstance==null)
			{
				myInstance = new Cache();
				//myInstance.LoadApplicationData();
			}
			return myInstance;
		}

//		public string MessageString
//		{
//			set 
//			{
//				Observer.Notify(value);
//			}
//		}

		public bool WhenStopService = false;

		public bool LoadApplicationData()
		{
			DDARecipe.DDAExternalData.LoadApplicationDataFromFile();
			LoadConnectionParam();

			#region Retry - TestConnection
			int retrytime = 0;
			int limittime = SiGlaz.Common.DDA.AppData.Data.WaitingToStartupSecond;
			bool testok = false;
			while(retrytime<=limittime)
			{
				try
				{
					WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
					testok = cmd.TestConnection();
					if(testok)
						break;
				}
				catch
				{
				}
				System.Threading.Thread.Sleep(1000);
				retrytime++;
			}

			if(!testok)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError("DDAServices cannot connect to database");
				return false;
			}
			#endregion Retry - TestConnection

			DDARecipe.DDAExternalData.LoadApplicationDataFromDatabase();
			LoadDefaultSchema();
			RunDefaultSchema();

			return true;
		}

		private DDADBManager.Process.Schema _Schema = new DDADBManager.Process.Schema();
		public string SchemaFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"defaultschema.dbs");

		public DDADBManager.Process.Schema Schema
		{
			get
			{
				return _Schema;
			}
			set
			{
				_Schema = value;
			}
		}

		public void StopDefaultSchema()
		{
			if(Schema==null) return;
			if(Schema.Process==null) return;
			
			try
			{
				for(int i=0;i<Schema.Process.Count;i++)
				{
					if(Schema.Process[i] is ProcessBase)
					{
						ProcessBase process = Schema.Process[i] as ProcessBase;
						if(process.IsRunning)
							process.Stop();
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		public void RunDefaultSchema()
		{
			if(Schema==null) return;
			if(Schema.Process==null) return;
			
			try
			{
				for(int i=0;i<Schema.Process.Count;i++)
				{
					if(Schema.Process[i] is ProcessBase)
					{
						ProcessBase process = Schema.Process[i] as ProcessBase;

//						if(process.ValidateString!=string.Empty)
//						{
//							process.IsWaiting = false;
//							process.IsRunning = false;
//
//							process.HandlerProcessInfor("This task stoped when the DDA Services start because at that time some task invalid, please try start again",EventArgs.Empty);
//							continue;
//						}

						if(process.IsRunning)
							process.Execute();
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		public void LoadDefaultSchema()
		{
			if(!File.Exists(SchemaFilePath))
				return;

			try
			{
				Schema.Load(SchemaFilePath);
				RegisterSeflEvent();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		public void SaveSchema(SchemaEvent e)
		{
			if(e.RawData ==null) return;
			UnregisterSeflEvent();

			Schema = e.Schema;
			RegisterSeflEvent();

			SaveDefaultSchema();
		}
		
		public void RegisterSeflEvent()
		{
			DDADBManager.Process.Schema schema = Cache.GetInstance().Schema;
			for(int i=0;i<schema.ProcessCount;i++)
			{
				DDADBManager.Process.ProcessBase seflprocess = schema.Process[i] as DDADBManager.Process.ProcessBase;
				seflprocess.ID = i;
				seflprocess.OnStateChange+=new DDADBManager.EventHandlerProcessInfor(seflprocess_OnStateChange);
			}
		}

		public void UnregisterSeflEvent()
		{
			DDADBManager.Process.Schema schema = Cache.GetInstance().Schema;
			for(int i=0;i<schema.ProcessCount;i++)
			{
				DDADBManager.Process.ProcessBase seflprocess = schema.Process[i] as DDADBManager.Process.ProcessBase;
				seflprocess.ID = i;
				seflprocess.OnStateChange-=new DDADBManager.EventHandlerProcessInfor(seflprocess_OnStateChange);
			}
		}

		private void seflprocess_OnStateChange(int id, string description, EventArgs e)
		{
			SaveDefaultSchema();
		}

		public void SaveDefaultSchema()
		{
			if(WhenStopService) return;
			lock(Schema)
			{
				try
				{
					Schema.Save(SchemaFilePath);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
					SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
				}
				//Console.WriteLine("SaveDefaultSchema");
			}
		}

		public string RunProcess(int i)
		{
			if(Schema==null) return "TaskList is null";
			if(Schema.Process==null) return "TaksList is null";
			if(Schema.Process[i] is ProcessBase)
			{
				ProcessBase process = Schema.Process[i] as ProcessBase;
				if(process.IsRunning)
					return string.Empty;
	
				if( process.ValidateString!=string.Empty)
					return process.ValidateString;

				process.Execute();
			}
			return string.Empty;
		}

		public string RunAllProcesses()
		{
			if(Schema==null) return "TaskList is null";
			if(Schema.Process==null) return "TaksList is null";
			for(int i=0;i<Schema.Process.Count;i++)
			{
				if(Schema.Process[i] is ProcessBase)
				{
					ProcessBase process = Schema.Process[i] as ProcessBase;
					if( process.IsRunning)
						continue;
					if( process.ValidateString!=string.Empty)
						return process.ValidateString;
					process.Execute();
				}
			}
			return string.Empty;
		}

		public bool AnyRun()
		{
			if(Schema==null) return false;
			if(Schema.Process==null) return false;

			for(int i=0;i<Schema.Process.Count;i++)
			{
				if(Schema.Process[i] is ProcessBase)
				{
					ProcessBase process = Schema.Process[i] as ProcessBase;
					if(process.IsRunning)
						return true;
				}
			}
			return false;
		}

		public void StopProcess(int i)
		{
			if(Schema==null) return;
			if(Schema.Process==null) return;
			if(Schema.Process[i] is ProcessBase)
			{
				ProcessBase process = Schema.Process[i] as ProcessBase;
				if(process.IsRunning)
					process.Stop();
			}
		}

		public void StopAllProcesses()
		{
			if(Schema==null) return;
			if(Schema.Process==null) return;
			for(int i=0;i<Schema.Process.Count;i++)
			{
				if(Schema.Process[i] is ProcessBase)
				{
					ProcessBase process = Schema.Process[i] as ProcessBase;
					if(process.IsRunning)
						process.Stop();
				}
			}
		}

		public SiGlaz.DAL.ConnectionParam ConnectionParam = new SiGlaz.DAL.ConnectionParam();
		public string ConnectionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Connection.cfg");

		public void LoadConnectionParam()
		{
			ConnectionParam.Load(ConnectionFilePath);
		}

		public int		NumberOfClient = 0;


	
	}
}
