using System;
using System.Windows.Forms;
using SiGlaz.Utility;

using DDARMWinUI;
using DDARecipe;

namespace DDARMWinUIApp
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
			if(DDAEnterpriseLook.Begin(1,"DDARM")==false)
				return;

			Application.EnableVisualStyles();
			Application.DoEvents();

			FlashDlg splash=new FlashDlg();
			splash.Show();
			splash.Update();

			SiGlaz.Common.Configuration.LoadData(System.IO.Path.Combine(SiGlaz.Common.DDA.AppData.ApplicationDataPath,"App.cfig"));

			DDARecipe.DDAExternalData.LoadApplicationData();
			MainForm dlg=new MainForm();

			dlg.Show();
			dlg.Update();
			splash.Close();
			splash.Dispose();

			Application.Run(dlg);

			SiGlaz.Common.Configuration.SaveData( System.IO.Path.Combine(SiGlaz.Common.DDA.AppData.ApplicationDataPath,"App.cfig"));

			DDARecipe.DDAExternalData.SaveApplicationData();

			//Seach and kill all Running Recipes
			System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDARMCmd");
			if(processes!=null)
			{
				foreach(System.Diagnostics.Process p in processes)
				{
					p.Kill();
				}
			}

			DDAEnterpriseLook.End();
		}

	}
}
