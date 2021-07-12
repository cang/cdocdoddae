using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDADBManager.Dialog
{
	/// <summary>
	/// Summary description for PreProcessDlg.
	/// </summary>
	public class PreProcessDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private DDADBManager.View.PreProcessFileCtrl preProcessFileCtrl1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Process.LoadETestProcess	DataSource;
		public PreProcessDlg(Process.LoadETestProcess	DataSource)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.DataSource = DataSource;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PreProcessDlg));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.preProcessFileCtrl1 = new DDADBManager.View.PreProcessFileCtrl();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.preProcessFileCtrl1);
			this.groupBox2.Location = new System.Drawing.Point(4, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(688, 332);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pre Process";
			// 
			// preProcessFileCtrl1
			// 
			this.preProcessFileCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.preProcessFileCtrl1.Location = new System.Drawing.Point(3, 16);
			this.preProcessFileCtrl1.Name = "preProcessFileCtrl1";
			this.preProcessFileCtrl1.Size = new System.Drawing.Size(682, 313);
			this.preProcessFileCtrl1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(353, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(269, 352);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-108, 336);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1104, 8);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// PreProcessDlg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(696, 380);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreProcessDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PreProcess Setting";
			this.Load += new System.EventHandler(this.PreProcessDlg_Load);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void PreProcessDlg_Load(object sender, System.EventArgs e)
		{
			preProcessFileCtrl1.DataSource = DataSource.PreProcess;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if( preProcessFileCtrl1.ValidateString!=string.Empty)
			{
				MessageBox.Show(this.preProcessFileCtrl1.ValidateString,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			DataSource.PreProcess = preProcessFileCtrl1.DataSource;

			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
