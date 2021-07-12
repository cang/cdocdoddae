using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for PreProcessFileCtrl.
	/// </summary>
	public class PreProcessFileCtrl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PreProcessFileCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.chkCopySourceFile = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtCopyFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.txtCopyInvalid = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkCopyInvalidFile = new System.Windows.Forms.CheckBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.btnUnkown = new System.Windows.Forms.Button();
			this.txtUnknownProduct = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkCopyUnkownFile = new System.Windows.Forms.CheckBox();
			this.btnMiss = new System.Windows.Forms.Button();
			this.txtMiss = new System.Windows.Forms.TextBox();
			this.chkCopyMiss = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nudMaxTimeClass = new System.Windows.Forms.NumericUpDown();
			this.btnClass = new System.Windows.Forms.Button();
			this.txtUnknownClass = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkMissClasscopy = new System.Windows.Forms.CheckBox();
			this.pClass = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTimeClass)).BeginInit();
			this.pClass.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkCopySourceFile
			// 
			this.chkCopySourceFile.Checked = true;
			this.chkCopySourceFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopySourceFile.Location = new System.Drawing.Point(0, 0);
			this.chkCopySourceFile.Name = "chkCopySourceFile";
			this.chkCopySourceFile.Size = new System.Drawing.Size(128, 24);
			this.chkCopySourceFile.TabIndex = 7;
			this.chkCopySourceFile.Text = "Copy Source Files :";
			this.chkCopySourceFile.CheckedChanged += new System.EventHandler(this.chkCopySourceFile_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(744, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtCopyFilePath
			// 
			this.txtCopyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCopyFilePath.Location = new System.Drawing.Point(64, 24);
			this.txtCopyFilePath.Name = "txtCopyFilePath";
			this.txtCopyFilePath.Size = new System.Drawing.Size(672, 20);
			this.txtCopyFilePath.TabIndex = 10;
			this.txtCopyFilePath.Text = "";
			this.txtCopyFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtCopyFilePath_Validating);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "To Path:";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(744, 71);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(24, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtCopyInvalid
			// 
			this.txtCopyInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCopyInvalid.Location = new System.Drawing.Point(64, 72);
			this.txtCopyInvalid.Name = "txtCopyInvalid";
			this.txtCopyInvalid.Size = new System.Drawing.Size(672, 20);
			this.txtCopyInvalid.TabIndex = 14;
			this.txtCopyInvalid.Text = "";
			this.txtCopyInvalid.Validating += new System.ComponentModel.CancelEventHandler(this.txtCopyInvalid_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "To Path:";
			// 
			// chkCopyInvalidFile
			// 
			this.chkCopyInvalidFile.Checked = true;
			this.chkCopyInvalidFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopyInvalidFile.Location = new System.Drawing.Point(0, 48);
			this.chkCopyInvalidFile.Name = "chkCopyInvalidFile";
			this.chkCopyInvalidFile.Size = new System.Drawing.Size(128, 24);
			this.chkCopyInvalidFile.TabIndex = 12;
			this.chkCopyInvalidFile.Text = "Copy Invalid Files :";
			this.chkCopyInvalidFile.CheckedChanged += new System.EventHandler(this.chkCopyInvalidFile_CheckedChanged);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// btnUnkown
			// 
			this.btnUnkown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnkown.Location = new System.Drawing.Point(744, 119);
			this.btnUnkown.Name = "btnUnkown";
			this.btnUnkown.Size = new System.Drawing.Size(24, 23);
			this.btnUnkown.TabIndex = 19;
			this.btnUnkown.Text = "...";
			this.btnUnkown.Click += new System.EventHandler(this.button3_Click);
			// 
			// txtUnknownProduct
			// 
			this.txtUnknownProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnknownProduct.Location = new System.Drawing.Point(64, 120);
			this.txtUnknownProduct.Name = "txtUnknownProduct";
			this.txtUnknownProduct.Size = new System.Drawing.Size(672, 20);
			this.txtUnknownProduct.TabIndex = 18;
			this.txtUnknownProduct.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 17;
			this.label3.Text = "To Path:";
			// 
			// chkCopyUnkownFile
			// 
			this.chkCopyUnkownFile.Checked = true;
			this.chkCopyUnkownFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopyUnkownFile.Location = new System.Drawing.Point(0, 96);
			this.chkCopyUnkownFile.Name = "chkCopyUnkownFile";
			this.chkCopyUnkownFile.Size = new System.Drawing.Size(232, 24);
			this.chkCopyUnkownFile.TabIndex = 16;
			this.chkCopyUnkownFile.Text = "Copy Truncated Files :";
			this.chkCopyUnkownFile.CheckedChanged += new System.EventHandler(this.chkCopyUnkownFile_CheckedChanged);
			// 
			// btnMiss
			// 
			this.btnMiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMiss.Location = new System.Drawing.Point(744, 167);
			this.btnMiss.Name = "btnMiss";
			this.btnMiss.Size = new System.Drawing.Size(24, 23);
			this.btnMiss.TabIndex = 22;
			this.btnMiss.Text = "...";
			this.btnMiss.Click += new System.EventHandler(this.btnMiss_Click);
			// 
			// txtMiss
			// 
			this.txtMiss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMiss.Location = new System.Drawing.Point(64, 168);
			this.txtMiss.Name = "txtMiss";
			this.txtMiss.Size = new System.Drawing.Size(672, 20);
			this.txtMiss.TabIndex = 21;
			this.txtMiss.Text = "";
			// 
			// chkCopyMiss
			// 
			this.chkCopyMiss.Checked = true;
			this.chkCopyMiss.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopyMiss.Location = new System.Drawing.Point(0, 144);
			this.chkCopyMiss.Name = "chkCopyMiss";
			this.chkCopyMiss.Size = new System.Drawing.Size(232, 24);
			this.chkCopyMiss.TabIndex = 20;
			this.chkCopyMiss.Text = "Copy Unknown DiskSize Files :";
			this.chkCopyMiss.CheckedChanged += new System.EventHandler(this.chkCopyMiss_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = "To Path:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(510, 16);
			this.label5.TabIndex = 29;
			this.label5.Text = "Define the times to try to process Unknown Product Class files before they are co" +
				"pied to other folder :";
			// 
			// nudMaxTimeClass
			// 
			this.nudMaxTimeClass.Location = new System.Drawing.Point(536, 6);
			this.nudMaxTimeClass.Maximum = new System.Decimal(new int[] {
																			1000000000,
																			0,
																			0,
																			0});
			this.nudMaxTimeClass.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.nudMaxTimeClass.Name = "nudMaxTimeClass";
			this.nudMaxTimeClass.Size = new System.Drawing.Size(56, 20);
			this.nudMaxTimeClass.TabIndex = 28;
			this.nudMaxTimeClass.Value = new System.Decimal(new int[] {
																		  60,
																		  0,
																		  0,
																		  0});
			// 
			// btnClass
			// 
			this.btnClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClass.Location = new System.Drawing.Point(744, 29);
			this.btnClass.Name = "btnClass";
			this.btnClass.Size = new System.Drawing.Size(24, 23);
			this.btnClass.TabIndex = 27;
			this.btnClass.Text = "...";
			this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
			// 
			// txtUnknownClass
			// 
			this.txtUnknownClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnknownClass.Location = new System.Drawing.Point(64, 30);
			this.txtUnknownClass.Name = "txtUnknownClass";
			this.txtUnknownClass.Size = new System.Drawing.Size(672, 20);
			this.txtUnknownClass.TabIndex = 26;
			this.txtUnknownClass.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 16);
			this.label6.TabIndex = 25;
			this.label6.Text = "To Path:";
			// 
			// chkMissClasscopy
			// 
			this.chkMissClasscopy.Checked = true;
			this.chkMissClasscopy.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMissClasscopy.Location = new System.Drawing.Point(0, 192);
			this.chkMissClasscopy.Name = "chkMissClasscopy";
			this.chkMissClasscopy.Size = new System.Drawing.Size(272, 24);
			this.chkMissClasscopy.TabIndex = 24;
			this.chkMissClasscopy.Text = "Copy Unknown Product Class Files :";
			this.chkMissClasscopy.CheckedChanged += new System.EventHandler(this.chkMissClasscopy_CheckedChanged);
			// 
			// pClass
			// 
			this.pClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pClass.Controls.Add(this.label5);
			this.pClass.Controls.Add(this.nudMaxTimeClass);
			this.pClass.Controls.Add(this.btnClass);
			this.pClass.Controls.Add(this.txtUnknownClass);
			this.pClass.Controls.Add(this.label6);
			this.pClass.Location = new System.Drawing.Point(0, 224);
			this.pClass.Name = "pClass";
			this.pClass.Size = new System.Drawing.Size(768, 56);
			this.pClass.TabIndex = 30;
			// 
			// PreProcessFileCtrl
			// 
			this.Controls.Add(this.pClass);
			this.Controls.Add(this.chkMissClasscopy);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnMiss);
			this.Controls.Add(this.txtMiss);
			this.Controls.Add(this.chkCopyMiss);
			this.Controls.Add(this.btnUnkown);
			this.Controls.Add(this.txtUnknownProduct);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkCopyUnkownFile);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtCopyInvalid);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkCopyInvalidFile);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtCopyFilePath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chkCopySourceFile);
			this.Name = "PreProcessFileCtrl";
			this.Size = new System.Drawing.Size(768, 280);
			this.Load += new System.EventHandler(this.PreProcessFileCtrl_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTimeClass)).EndInit();
			this.pClass.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void PreProcessFileCtrl_Load(object sender, System.EventArgs e)
		{
		
		}

		private System.Windows.Forms.CheckBox chkCopySourceFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtCopyFilePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtCopyInvalid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkCopyInvalidFile;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.TextBox txtUnknownProduct;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkCopyUnkownFile;
		private System.Windows.Forms.Button btnUnkown;
		private System.Windows.Forms.Button btnMiss;
		private System.Windows.Forms.CheckBox chkCopyMiss;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMiss;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudMaxTimeClass;
		private System.Windows.Forms.TextBox txtUnknownClass;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkMissClasscopy;
		private System.Windows.Forms.Panel pClass;
		private System.Windows.Forms.Button btnClass;

		Modal.PreProcess _DataSource;
		public Modal.PreProcess DataSource
		{
			get
			{
				UpdateData(true);
				return _DataSource;
			}
			set
			{
				_DataSource = value;
				UpdateData(false);
			}
		}

		public void UpdateData(bool update)
		{
			if(update)
			{
				if(_DataSource==null)
					_DataSource = new DDADBManager.Modal.PreProcess();

				_DataSource.CopyFile = chkCopySourceFile.Checked;
				_DataSource.CopyInvalidFile = chkCopyInvalidFile.Checked;

				_DataSource.CopyFilePath = txtCopyFilePath.Text;
				_DataSource.CopyInvalidFilePath = txtCopyInvalid.Text;

				_DataSource.CopyUnknownProductFile = chkCopyUnkownFile.Checked;
				_DataSource.CopyUnknownProductFilePath = txtUnknownProduct.Text;

				_DataSource.CopyMissDiskSizeFile = chkCopyMiss.Checked;
				_DataSource.CopyMissDiskSizeFilePath = txtMiss.Text;

				_DataSource.CopyMissClassFile = chkMissClasscopy.Checked;
				_DataSource.CopyMissClassFilePath = txtUnknownClass.Text;
				_DataSource.MissClassMaxTime = Convert.ToInt32(nudMaxTimeClass.Value);

			}
			else
			{
				if(_DataSource==null)
				{
					chkCopySourceFile.Checked = false;
					chkCopyInvalidFile.Checked= true;
					txtCopyFilePath.Text= "";
					txtCopyInvalid.Text= "";

					chkCopyUnkownFile.Checked = true;
					chkCopyMiss.Checked= true;

					txtUnknownProduct.Text= "";
					txtMiss.Text= "";

					chkMissClasscopy.Checked = false;
					txtUnknownClass.Text = "";
					nudMaxTimeClass.Value = 60;

					return;
				}
				else
				{
					chkCopySourceFile.Checked = _DataSource.CopyFile;
					chkCopyInvalidFile.Checked= _DataSource.CopyInvalidFile;

					txtCopyFilePath.Text= _DataSource.CopyFilePath;
					txtCopyInvalid.Text= _DataSource.CopyInvalidFilePath;

					chkCopyUnkownFile.Checked= _DataSource.CopyUnknownProductFile;
					txtUnknownProduct.Text= _DataSource.CopyUnknownProductFilePath;

					 chkCopyMiss.Checked = _DataSource.CopyMissDiskSizeFile;
					 txtMiss.Text= _DataSource.CopyMissDiskSizeFilePath;

					chkMissClasscopy.Checked = _DataSource.CopyMissClassFile;
					txtUnknownClass.Text = _DataSource.CopyMissClassFilePath;
					nudMaxTimeClass.Value = _DataSource.MissClassMaxTime;

				}
			}
		}

		private void txtCopyFilePath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			if( chkCopyInvalidFile.Checked  && !System.IO.Directory.Exists(txtCopyFilePath.Text))
//			{
//				errorProvider1.SetError(sender as Control,"Invalid Destination Folder Path");
//				e.Cancel = true;
//			}
//			else
//			{
//				errorProvider1.SetError(sender as Control,string.Empty);
//			}
		}

		private void txtCopyInvalid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			if( chkCopyInvalidFile.Checked  && !System.IO.Directory.Exists(txtCopyInvalid.Text))
//			{
//				errorProvider1.SetError(sender as Control,"Invalid Destination Invalid Folder Path");
//				e.Cancel = true;
//			}
//			else
//			{
//				errorProvider1.SetError(sender as Control,string.Empty);
//			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Folder Path copy to";
			if( System.IO.Directory.Exists(txtCopyFilePath.Text))
				dlg.SelectedPath = txtCopyFilePath.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtCopyFilePath.Text = dlg.SelectedPath;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Invalid Folder Path copy to";
			if( System.IO.Directory.Exists(txtCopyInvalid.Text))
				dlg.SelectedPath = txtCopyInvalid.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtCopyInvalid.Text = dlg.SelectedPath;
			}
		}

		private void chkCopySourceFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCopyFilePath.Enabled = button1.Enabled =  chkCopySourceFile.Checked;
		}

		private void chkCopyInvalidFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCopyInvalid.Enabled = button2.Enabled =  chkCopyInvalidFile.Checked;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Truncated Folder Path copy to";
			if( System.IO.Directory.Exists(txtUnknownProduct.Text))
				dlg.SelectedPath = txtUnknownProduct.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtUnknownProduct.Text = dlg.SelectedPath;
			}
		}

		private void chkCopyUnkownFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtUnknownProduct.Enabled = btnUnkown.Enabled =  chkCopyUnkownFile.Checked;
		}

		private void btnMiss_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Unknown DiskSize Folder Path copy to";
			if( System.IO.Directory.Exists(txtMiss.Text))
				dlg.SelectedPath = txtMiss.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtMiss.Text = dlg.SelectedPath;
			}
		}

		private void chkCopyMiss_CheckedChanged(object sender, System.EventArgs e)
		{
			txtMiss.Enabled = btnMiss.Enabled =  chkCopyMiss.Checked;
		}

		private void chkMissClasscopy_CheckedChanged(object sender, System.EventArgs e)
		{
			pClass.Enabled = chkMissClasscopy.Checked;
		}

		private void btnClass_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Unknown Product Class Folder Path copy to";
			if( System.IO.Directory.Exists(txtUnknownClass.Text))
				dlg.SelectedPath = txtUnknownClass.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtUnknownClass.Text = dlg.SelectedPath;
			}
		}

		public string ValidateString
		{
			get
			{
				if( chkCopySourceFile.Checked  && !System.IO.Directory.Exists(txtCopyFilePath.Text))
					return "Invalid Destination Folder Path";
				if( chkCopyInvalidFile.Checked  && !System.IO.Directory.Exists(txtCopyInvalid.Text))
					return "Invalid Destination Invalid Folder Path";
				if( chkCopyUnkownFile.Checked  && !System.IO.Directory.Exists(txtUnknownProduct.Text))
					return "Invalid Destination Truncated Folder Path";
				if( chkCopyMiss.Checked  && !System.IO.Directory.Exists(txtMiss.Text))
					return "Invalid Destination Unknown DiskSize Folder Path";
				if( chkMissClasscopy.Checked  && !System.IO.Directory.Exists(txtUnknownClass.Text))
					return "Invalid Destination Unknown Product Class Folder Path";

				return string.Empty;
			}
		}
	}
}
