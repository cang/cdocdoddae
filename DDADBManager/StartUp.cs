using System;
using System.Windows.Forms;

namespace DDADBManager
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

			Dialog.FlashDlg splash=new Dialog.FlashDlg();
			splash.Show();
			splash.Update();

			DDARecipe.DDAExternalData.LoadApplicationData();

			MainDlg dlg=new MainDlg();

			dlg.Show();
			dlg.Update();
			splash.Close();
			splash.Dispose();

			Application.Run(dlg);
		}

	}
}
