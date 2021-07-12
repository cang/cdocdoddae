using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;
using DDANavigator.Dialogs;

namespace DDANavigator.Controls
{
	public class ctrlTextBoxFilter : System.Windows.Forms.UserControl
	{
		#region Members
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RichTextBox txtAutoComplete;
		private DateTime _fromDate = DateTime.Now;
		private DateTime _toDate = DateTime.Now;
		private FunctionType _type = FunctionType.SingleLayer;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnHint;
		private string _fieldName = WaferConst.DiskID;
		private bool _isViewUnknownSignature = false;
		private string _fabID = string.Empty;
		#endregion
		
		#region Constructor & Destructor
		public ctrlTextBoxFilter()
		{
			InitializeComponent();
		}

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
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtAutoComplete = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnHint = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAutoComplete
			// 
			this.txtAutoComplete.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAutoComplete.Location = new System.Drawing.Point(0, 0);
			this.txtAutoComplete.Multiline = false;
			this.txtAutoComplete.Name = "txtAutoComplete";
			this.txtAutoComplete.Size = new System.Drawing.Size(368, 20);
			this.txtAutoComplete.TabIndex = 2;
			this.txtAutoComplete.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnHint);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(368, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(36, 20);
			this.panel1.TabIndex = 1;
			// 
			// btnHint
			// 
			this.btnHint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnHint.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnHint.Location = new System.Drawing.Point(0, 0);
			this.btnHint.Name = "btnHint";
			this.btnHint.Size = new System.Drawing.Size(36, 20);
			this.btnHint.TabIndex = 3;
			this.btnHint.Text = "Hint";
			this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtAutoComplete);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(368, 20);
			this.panel2.TabIndex = 0;
			// 
			// ctrlAutoCompleteTextBox
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "ctrlAutoCompleteTextBox";
			this.Size = new System.Drawing.Size(404, 20);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public string Value
		{
			get { return txtAutoComplete.Text; }
			set { txtAutoComplete.Text = value; }
		}

		public DateTime FromDate
		{
			get { return _fromDate; }
			set { _fromDate = value; }
		}

		public DateTime ToDate
		{
			get { return _toDate; }
			set { _toDate = value; }
		}

		public FunctionType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public string FieldName
		{
			get { return _fieldName; }
			set { _fieldName = value; }
		}

		public bool IsViewUnknownSignature
		{
			get { return _isViewUnknownSignature; }
			set { _isViewUnknownSignature = value; }
		}

		public string FabID
		{
			get { return _fabID; }
			set { _fabID = value; }
		}
		#endregion

		#region UI Command
		private void HintData()
		{
			Cursor.Current = Cursors.WaitCursor;
			
			DlgConditionHint dlg = new DlgConditionHint(_fabID, _fromDate, _toDate, _fieldName, _type, true, _isViewUnknownSignature);

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				if (txtAutoComplete.Text.Trim() != string.Empty)
					txtAutoComplete.AppendText(string.Format("; {0}", dlg.Condition));
				else
					txtAutoComplete.Text = dlg.Condition;
			}

			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Windows Events Handles
		private void btnHint_Click(object sender, System.EventArgs e)
		{
			HintData();		
		}
		#endregion
	}
}
