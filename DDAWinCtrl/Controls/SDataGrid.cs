using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace DDAWinCtrl.Controls
{
	public class SDataGrid : DataGrid
	{
		private System.ComponentModel.IContainer components = null;

		public SDataGrid()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion



		public event ChangeRowEventHandle OnDeleteingRow;

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			Keys keyCode = (Keys)(int)msg.WParam & Keys.KeyCode;
			if(msg.Msg == 256
				&& keyCode == Keys.Delete
				&& this.CurrentRowIndex>=0 && this.IsSelected(this.CurrentRowIndex)
				)
			{
				if(OnDeleteingRow!=null)
				{
					bool delete = false;

					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.DataSource,this.DataMember];

					if(cm.Position>=0)
					{
						DataView view = (DataView)cm.List;
						DataRowView rowView = view[cm.Position];
						DataRow row = rowView.Row;

						OnDeleteingRow(row, ref delete);

						if(delete)
							return true;
					}
				}
			}

			return base.ProcessCmdKey (ref msg, keyData);
		}
	}

	public delegate void ChangeRowEventHandle(DataRow selectedrow,ref bool cancel);
}

