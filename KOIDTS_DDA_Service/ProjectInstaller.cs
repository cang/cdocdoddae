using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace KOIDTS_DDA_Service
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
			this.serviceInstaller1.ServiceName = "EIS_KOI_DDAService";
			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// serviceController1
			// 
			this.serviceController1.ServiceName = "EIS_KOI_DDAService";
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

			try
			{
				serviceController1.Start();
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}

		}

		public override void Uninstall(IDictionary savedState)
		{
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


	}
}
