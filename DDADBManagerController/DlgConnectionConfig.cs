using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDADBManagerController
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
			if(RemotableSchemacController.SchemaControler.RemoteRecipeList.AnyRun())
			{
				MessageBox.Show(this,"Please stop all running recipes at DDA Recipe Manager before cofig new connection");
				return;
			}

			base.btnOK_Click (sender, e);
		}



	}
}
