using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARMController
{
	/// <summary>
	/// Summary description for DlgConnectionConfig.
	/// </summary>
	public class DlgConnectionConfig : DDARecipe.Dialogs.DlgWebServiceConfiguration
	{
		public DlgConnectionConfig() : base()
		{
		}

		public override void btnOK_Click(object sender, EventArgs e)
		{
			if(RemotableEventController.Controler.RemoteSchema.AnyRun())
			{
				MessageBox.Show(this,"Please stop all running tasks at DDADB Manager before config new connection");
				return;
			}

			base.btnOK_Click (sender, e);
		}



	}
}
