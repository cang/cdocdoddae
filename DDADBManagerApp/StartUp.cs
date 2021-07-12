using System;
using System.Windows.Forms;
using SiGlaz.Utility;

namespace DDADBManagerApp
{
	/// <summary>
	/// Summary description for StartUp.
	/// </summary>
	public class StartUp
	{
		public StartUp()
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

			if(DDAEnterpriseLook.Begin(1,"DDADBManager")==false)
				return;

			DDADBManager.Dialog.FlashDlg splash = new DDADBManager.Dialog.FlashDlg();
			splash.Show();
			splash.Update();

//			try
//			{

				DDARecipe.DDAExternalData.LoadApplicationData();
				SiGlaz.Utility.Compression.Compressor.MultiInstance = true;

				DDADBManager.MainDlg dlg = new DDADBManager.MainDlg();
				dlg.Show();
				
				splash.Close();
				splash.Dispose();

				Application.Run(dlg);
				
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.StackTrace);
//				DDAEnterpriseLook.End();
//				System.Diagnostics.Process.GetCurrentProcess().Kill();
//			}

			DDAEnterpriseLook.End();
		}

	}
}
