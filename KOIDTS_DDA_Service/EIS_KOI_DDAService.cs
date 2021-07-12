using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace KOIDTS_DDA_Service
{
	public class EIS_KOI_DDAService : System.ServiceProcess.ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EIS_KOI_DDAService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
		}

		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new EIS_KOI_DDAService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "EIS_KOI_DDAService";
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

		ServerProcess serverProcess = null;
		private void InitServer()
		{
			SiGlaz.Utility.EventViewerLog.GlobalLog = new SiGlaz.Utility.EventViewerLog("EISKOIDDAService");

			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("EIS_KOI_DDAService Services starting...");
			try
			{
				//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("truoc new ServerProcess");

				serverProcess = new ServerProcess();//Init ,run default and listen...
				//KOIDTSSimpleMsg.Cache.ServerProcess.Init();//Su dung remote

				//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("sau new ServerProcess");

				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("EIS_KOI_DDAService Services start successfully");
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
				//serverProcess.Dispose();
			}
			catch//(Exception ex)
			{
				//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private void ExitProcesses()
		{
			try
			{
				if(serverProcess!=null)
					serverProcess.Dispose();
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
			//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("End ExitProcesses");
		}
 
		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			th = new System.Threading.Thread(new System.Threading.ThreadStart(StartThread));
			th.Start();
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			thEvent.Set();
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

	}
}
