using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDANavigator.Dialogs
{
	public class DlgChangeCondition : FormBase
	{
		#region Members
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RadioButton raORAND;
		private System.Windows.Forms.RadioButton raANDOR;
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor & Destructor
		public DlgChangeCondition()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgChangeCondition));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.raANDOR = new System.Windows.Forms.RadioButton();
			this.raORAND = new System.Windows.Forms.RadioButton();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raANDOR);
			this.groupBox1.Controls.Add(this.raORAND);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 72);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Simple Condition Type";
			// 
			// raANDOR
			// 
			this.raANDOR.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raANDOR.Location = new System.Drawing.Point(16, 40);
			this.raANDOR.Name = "raANDOR";
			this.raANDOR.Size = new System.Drawing.Size(120, 24);
			this.raANDOR.TabIndex = 1;
			this.raANDOR.Text = "AND OR Condition";
			// 
			// raORAND
			// 
			this.raORAND.Checked = true;
			this.raORAND.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raORAND.Location = new System.Drawing.Point(16, 16);
			this.raORAND.Name = "raORAND";
			this.raORAND.Size = new System.Drawing.Size(120, 24);
			this.raORAND.TabIndex = 0;
			this.raORAND.TabStop = true;
			this.raORAND.Text = "OR AND Condition";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(176, 92);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			// 
			// groupBox4
			// 
			this.groupBox4.Location = new System.Drawing.Point(-128, 76);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(640, 8);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(96, 92);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// DlgChangeCondition
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(346, 124);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgChangeCondition";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Change Condition";
			this.Load += new System.EventHandler(this.FilterDefectOption_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public bool UseOrAnd
		{
			get
			{
				return raORAND.Checked;
			}
			set
			{
				raORAND.Checked=value;
				raANDOR.Checked=!value;
			}
		}
		#endregion

		#region Windows Events Handle
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult=DialogResult.OK;
			Close();
		}

		private void FilterDefectOption_Load(object sender, System.EventArgs e)
		{

		}
		#endregion
	}
}
