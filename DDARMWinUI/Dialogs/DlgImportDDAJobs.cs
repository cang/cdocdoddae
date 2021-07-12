using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.Common.DDA.Result;
using System.Data;

namespace DDARMWinUI.Dialogs
{
	/// <summary>
	/// Summary description for DlgImportDDAJobs.
	/// </summary>
	public class DlgImportDDAJobs : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ComboBox cboTesterType;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgImportDDAJobs()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboTesterType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(150, 148);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(70, 148);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-64, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(508, 8);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// cboTesterType
			// 
			this.cboTesterType.Location = new System.Drawing.Point(20, 32);
			this.cboTesterType.Name = "cboTesterType";
			this.cboTesterType.Size = new System.Drawing.Size(252, 21);
			this.cboTesterType.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Select Tester Type for processing recipes : ";
			// 
			// DlgImportDDAJobs
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(294, 180);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboTesterType);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "DlgImportDDAJobs";
			this.Text = "Import DDA Jobs";
			this.Load += new System.EventHandler(this.DlgImportDDAJobs_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgImportDDAJobs_Load(object sender, System.EventArgs e)
		{
		}

		public void DisplayTesterTypeList()
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				DataSetResult result = cmd.TesterTypesList();

				if(result.IsSuccess)
				{
					cboTesterType.Items.Clear();
					foreach(DataRow dr in result.Result.Tables[0].Rows)
					{
						if( !dr.IsNull(1))
							cboTesterType.Items.Add(dr[1].ToString());
					}
				}

			}
			catch
			{
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
		
		}

		public string TesterType
		{
			get
			{
				return cboTesterType.Text.Trim();
			}
			set
			{
				cboTesterType.Text = value;
			}
		}

	}
}
