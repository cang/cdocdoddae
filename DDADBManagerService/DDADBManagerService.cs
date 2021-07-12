using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

using System.Runtime.Remoting;
using DDADBRObjects;
using System.Threading;


namespace DDADBManagerService
{
	public class DDADBManagerService : System.ServiceProcess.ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DDADBManagerService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
		}

		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new DDADBManagerService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// DDADBManagerService
			// 
			this.ServiceName = "DDAServices";

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			th = new System.Threading.Thread(new System.Threading.ThreadStart(StartThread));
			th.Start();
			//base.OnStart(args);
		}

	
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			thEvent.Set();
			//base.OnStop();
		}

		protected override void OnShutdown()
		{
			base.OnShutdown ();
		}

		protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
		{
			return base.OnPowerEvent (powerStatus);
		}

		protected override void OnCustomCommand(int command)
		{
			base.OnCustomCommand (command);
		}

		protected override void OnPause()
		{
			base.OnPause ();
		}

		protected override void OnContinue()
		{
			base.OnContinue ();
		}

		System.Threading.Thread th = null;
		System.Threading.ManualResetEvent thEvent = new System.Threading.ManualResetEvent(false);

		protected void StartThread()
		{
			InitServer();

			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("Server wait by service");
			thEvent.WaitOne();
			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("Server stop by service");

			FreeServer();
		}

		private void UpdatePort(int port)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;

			SiGlaz.Utility.FileUtils.FileReplaceContent( 
				System.IO.Path.Combine(path,"ServerTemplate.config"),System.IO.Path.Combine(path,"DDADBManagerService.exe.config"),"[portnumber]",port.ToString());

			SiGlaz.Utility.FileUtils.FileReplaceContent( 
				System.IO.Path.Combine(path,"ClientTemplate.config"),System.IO.Path.Combine(path,"DDADBManagerController.exe.config"),"[portnumber]",port.ToString());

			SiGlaz.Utility.FileUtils.FileReplaceContent( 
				System.IO.Path.Combine(path,"ClientTemplate.config"),System.IO.Path.Combine(path,"DDARMController.exe.config"),"[portnumber]",port.ToString());

			SiGlaz.Utility.FileUtils.FileReplaceContent( 
				System.IO.Path.Combine(path,"ProcessTemplate.config"),System.IO.Path.Combine(path,"DDARMProcess.exe.config"),"[portnumber]",port.ToString());
		}
	

		private void InitServer()
		{

			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("DDA Services starting...");
			try
			{
				SiGlaz.Common.DDA.AppData.Data.UseWebService = false;
				WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.SystemEvent;

				#region config port and remoting

				if( System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ServerTemplate.config")))
				{
					int port= 10001;
					for(;port<10999;port++)
					{
						try
						{
							UpdatePort(port);
							RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
							break;
						}
						catch
						{
						}
					}

					if(port>=10999)
						throw new Exception("DDADB Services start failed : cannot listen port from 10001  to 10999");
				}
				else
					RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
		
				#endregion config port and remoting
			
				//RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
				DDADBRObjects.Cache.GetInstance().LoadApplicationData();

				DDARecipeRObjects.Cache.GetInstance().InitRemoting();
				DDARecipeRObjects.Cache.GetInstance().LoadApplicationData();

				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("DDADB Services start successfully");
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError("MESSAGE AT SERVICE: " + ex.Message + " STACKTRACE: " + ex.StackTrace);
			}
		}

		private void FreeServer()
		{
			DeleteTemps();
			ExitProcesses();
		}


		private void DeleteTemps()
		{
			try
			{
				string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TmpImComeFiles");
				SiGlaz.Utility.FileUtils.DeleteDirectory(path);
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		int recipe_exit_timeouts = 60*3;
		private void ExitProcesses()
		{
			#region waiting and kill all tasks iof DDADB Manager
			try
			{
				DDADBRObjects.Cache.GetInstance().WhenStopService = true;
				DDADBRObjects.Cache.GetInstance().StopDefaultSchema();
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("StopDefaultSchema of DDADB Manager");
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			#endregion waiting and kill all tasks iof DDADB Manager

			#region waiting and kill all Running Recipes
			try
			{
				//Exit by call to Remoting Server
				try
				{
					DDARecipeRObjects.RRecipeList proxy = DDARecipeRObjects.Cache.GetInstance().GetRemoteSingletonObject(typeof(DDARecipeRObjects.RRecipeList)) as DDARecipeRObjects.RRecipeList;
					proxy.PrepareShutdown();
					proxy.StopAllRecipes();
					SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("StopAllRecipes by Service");
				}
				catch(Exception ex)
				{
					SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
				}

				//Waiting
				System.Diagnostics.Process[] processes = null;
				bool processeesexit = false;
				for(int i=0;i<recipe_exit_timeouts;i++)
				{
					processes = System.Diagnostics.Process.GetProcessesByName("DDARMProcess");
					if(processes==null || processes.Length<=0) 
					{
						processeesexit = true;
						break;//processes were exit
					}
					processes = null;
					System.Threading.Thread.Sleep(1000);//1 second
				}

				//Force exit when timesout
				if(!processeesexit)
				{
					processes = System.Diagnostics.Process.GetProcessesByName("DDARMProcess");
					if(processes!=null && processes.Length>0)
					{
						foreach(System.Diagnostics.Process p in processes)
						{
							p.Kill();
						}
					}
					SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("Seach and kill all Running Recipes");
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			#endregion Seach and kill all Running Recipes

			#region Seach and kill all DDARMController
			try
			{
				System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDARMController");
				if(processes!=null && processes.Length>0)
				{
					foreach(System.Diagnostics.Process p in processes)
					{
						p.Kill();
					}
				}
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("Seach and kill all DDARMController");
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			#endregion Seach and kill all DDARMController
			
			#region Seach and kill all DDADBManagerController
			try
			{
				System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDADBManagerController");
				if(processes!=null && processes.Length>0)
				{
					foreach(System.Diagnostics.Process p in processes)
					{
						p.Kill();
					}
				}
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("Seach and kill all DDADBManagerController");
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			#endregion Seach and kill all DDADBManagerController

			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("End ExitProcesses");
		}
 

	}
}
