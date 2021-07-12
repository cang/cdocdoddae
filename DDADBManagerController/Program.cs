using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.IO;

using SiGlaz.Utility;

namespace DDADBManagerController
{
	/// <summary>
	/// Summary description for Program.
	/// </summary>
	public class Program
	{
		public Program()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//			Application.EnableVisualStyles();
			//			Application.DoEvents();

			if(DDAEnterpriseLook.Begin(1,"DDADBManagerController")==false)
				return;


			DDADBManager.Dialog.FlashDlg splash = new DDADBManager.Dialog.FlashDlg();
			splash.Show();
			splash.Update();


			//Configuration Remoting 
			try
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog = new SiGlaz.Utility.EventViewerLog("DDA Database Manager");

				RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
				RemotableSchemacController.SchemaControler.InitRemotingObjects();

				LoadApplicationDataFromServer();

//				byte[] lpbyte = RemotableSchemacController.SchemaControler.RemoteSchema.RequireApplicationConfig();
//				SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);

				/*//Now, this application allow run only one computer so they same the Connection.cfg path - do not need to get connecttion param to local
				string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");
				SiGlaz.DAL.ConnectionParam param = RemotableSchemacController.SchemaControler.RemoteSchema.GetConnectionParam();
				param.Save(configFileName);
				*/
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
				splash.Close();
				splash.Dispose();
				return;
			}
	
			SiGlaz.Utility.Compression.Compressor.MultiInstance = true;
			DDADBManager.ControllerDlg dlg = new DDADBManager.ControllerDlg();
			try
			{
				RemotableSchemacController.SchemaControler._RemoteEvent.OnRefresh+=new DDADBRObjects.MessageHandler(dlg.RemoteSchema_OnRefresh);

				dlg.Show();
				
				splash.Close();
				splash.Dispose();

				Application.Run(dlg);
			}
			catch(Exception ex)
			{
				RemotableSchemacController.ProcessFailToConnectToServices(ex);
			}
			finally
			{
				RemotableSchemacController.SchemaControler.FreeRemotingObject();
				RemotableSchemacController.SchemaControler._RemoteEvent.OnRefresh-=new DDADBRObjects.MessageHandler(dlg.RemoteSchema_OnRefresh);
			}
		
			DDAEnterpriseLook.End();
		}

		public static void LoadApplicationDataFromServer()
		{
			try
			{
				byte[] lpbyte = RemotableSchemacController.SchemaControler.RemoteSchema.RequireApplicationConfig();
				SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);

			}
			catch
			{
			}
		}
	}
}
