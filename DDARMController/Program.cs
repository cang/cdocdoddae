using System;
using System.IO;
using System.Windows.Forms;
using SiGlaz.Utility;

using DDARMWinUI;
using DDARecipe;

using System.Runtime.Remoting;

namespace DDARMController
{
	/// <summary>
	/// Summary description for StartUp.
	/// </summary>
	public class StartUp
	{
		public StartUp()
		{
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			if(DDAEnterpriseLook.Begin(1,"DDARMController")==false)
				return;

			SiGlaz.Utility.EventViewerLog.GlobalLog = new SiGlaz.Utility.EventViewerLog("DDA Recipe Manager");

			Application.EnableVisualStyles();
			Application.DoEvents();

			FlashDlg splash=new FlashDlg();
			splash.Show();
			splash.Update();

			SiGlaz.Common.Configuration.LoadData(System.IO.Path.Combine(SiGlaz.Common.DDA.AppData.ApplicationDataPath,"App.cfig"));
			
			//Configuration Remoting 
			try
			{
				RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
				RemotableEventController.Controler.InitRemotingObjects();

				LoadApplicationDataFromServer();

//				byte[] lpbyte = RemotableEventController.Controler.RemoteRecipeList.RequireApplicationConfig();
//				SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);

//				string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");
//				SiGlaz.DAL.ConnectionParam param = RemotableEventController.Controler.RemoteRecipeList.GetConnectionParam();
//				param.Save(configFileName);
			}
			catch(Exception ex)
			{
				RemotableEventController.ProcessFailToConnectToServices(ex);
				splash.Close();
				splash.Dispose();
				return;
			}
				
			ControllerDlg dlg=new ControllerDlg();
			try
			{
				RemotableEventController.Controler._RemoteEvent.OnRefresh+=new DDARecipeRObjects.MessageEventHandler(dlg.ReLoadSchema);

				dlg.Show();
				
				splash.Close();
				splash.Dispose();

				Application.Run(dlg);

				SiGlaz.Common.Configuration.SaveData(System.IO.Path.Combine(SiGlaz.Common.DDA.AppData.ApplicationDataPath,"App.cfig"));

				//DDARecipe.DDAExternalData.SaveApplicationData();
			}
			catch(Exception ex)
			{
				RemotableEventController.ProcessFailToConnectToServices(ex);
			}
			finally
			{
				//Chuyen vao Closing cua form
				RemotableEventController.Controler.FreeRemotingObject();
				RemotableEventController.Controler._RemoteEvent.OnRefresh-=new DDARecipeRObjects.MessageEventHandler(dlg.ReLoadSchema);
			}

		
			DDAEnterpriseLook.End();
		}

		public static void LoadApplicationDataFromServer()
		{
			try
			{
				byte[] lpbyte = RemotableEventController.Controler.RemoteRecipeList.RequireApplicationConfig();
				SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);
			}
			catch
			{
			}
		}

		
	}
}
