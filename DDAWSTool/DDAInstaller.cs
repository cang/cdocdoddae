using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;

namespace SiGlaz.DDA.Tools.DDAWebServiceTool
{
	/// <summary>
	/// Summary description for IDADBInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class IDADBInstaller : System.Configuration.Install.Installer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IDADBInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		public override void Commit(IDictionary savedState)
		{
			try
			{
				string virtualFolder = (string)Context.Parameters["VirtualDirectory"];
				int port = Convert.ToInt32(Context.Parameters["Port"]);
				SiGlaz.DDA.Tools.DDAWebServiceTool.MainForm form = new SiGlaz.DDA.Tools.DDAWebServiceTool.MainForm(virtualFolder, port);
				form.ShowDialog();
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			

			base.Commit (savedState);
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
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
