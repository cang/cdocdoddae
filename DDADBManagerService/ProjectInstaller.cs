using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using Microsoft.Win32;

using System.Windows.Forms;


namespace DDADBManagerService
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
		private System.ServiceProcess.ServiceInstaller serviceInstaller1;
		private System.ServiceProcess.ServiceController serviceController1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
	
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
			this.serviceController1 = new System.ServiceProcess.ServiceController();
			// 
			// serviceProcessInstaller1
			// 
			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstaller1.Password = null;
			this.serviceProcessInstaller1.Username = null;
			// 
			// serviceInstaller1
			// 
			this.serviceInstaller1.DisplayName = "DDA Services";
			this.serviceInstaller1.ServiceName = "DDAServices";
			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// serviceController1
			// 
			this.serviceController1.ServiceName = "DDAServices";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																					  this.serviceProcessInstaller1,
																					  this.serviceInstaller1});

		}
		#endregion

		protected override void OnAfterInstall(IDictionary savedState)
		{
			base.OnAfterInstall (savedState);

			//Remove Event Log
			try
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.CreateSource();

			}
			catch
			{
			}

			//default app
			try
			{
				string app_config = System.IO.Path.Combine(Context.Parameters["InstallDir"], "App.config");

				SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate = new SiGlaz.Common.DDA.Basic.TimeFilter();
				SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.Type =  SiGlaz.Common.DDA.TimeRangeType.LastNHours;
				SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.N = -1;
				SiGlaz.Common.DDA.AppData.Data.SaveApplicationData(app_config);
			}
			catch
			{
			}

			//service controller option
			try
			{
				DataInstaller.DDAServiceOptions dlg = new DataInstaller.DDAServiceOptions();
				dlg.ShowDialog();
				serviceController1.Start();
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}

		}


		public override void Install(IDictionary stateSaver)
		{
			base.Install (stateSaver);

			string DDADBManagerTrayPath = System.IO.Path.Combine(Context.Parameters["InstallDir"], "DDADBManagerTray.exe");

			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);

			key.SetValue("DDADBManagerTray", "\"" + DDADBManagerTrayPath + "\"");
	
			key.Close();

		}

		public override void Uninstall(IDictionary savedState)
		{
			string DDADBManagerTrayPath = System.IO.Path.Combine(Context.Parameters["InstallDir"], "DDADBManagerTray.exe");

			System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDADBManagerTray");
			if(processes!=null)
			{
				foreach(System.Diagnostics.Process process in processes)
				{
					process.Kill();
				}
			}

			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);

			key.DeleteValue("DDADBManagerTray",false);
	
			key.Close();

			//Remove internal files
			try
			{
				string app_config = System.IO.Path.Combine(Context.Parameters["InstallDir"], "App.config");
				SiGlaz.Utility.FileUtils.DeleteFile(app_config);

				string defaultschema_dbs = System.IO.Path.Combine(Context.Parameters["InstallDir"], "defaultschema.dbs");
				SiGlaz.Utility.FileUtils.DeleteFile(defaultschema_dbs);

				string Connection_cfg = System.IO.Path.Combine(Context.Parameters["InstallDir"], "Connection.cfg");
				SiGlaz.Utility.FileUtils.DeleteFile(Connection_cfg);
			}
			catch
			{
			}

			//Remove Event Log
			try
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.Delete();
			}
			catch
			{
			}

			base.Uninstall (savedState);
		}


		public override void Commit(IDictionary savedState)
		{
			string DDADBManagerTrayPath = System.IO.Path.Combine(Context.Parameters["InstallDir"], "DDADBManagerTray.exe");
			System.Diagnostics.Process.Start(DDADBManagerTrayPath);

			base.Commit (savedState);
			
		}

	}
}
