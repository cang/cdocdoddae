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
	public class PostProcessFileCtrl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PostProcessFileCtrl()
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
			this.button2 = new System.Windows.Forms.Button();
			this.txtCopyInvalid = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkCopyInvalidFile = new System.Windows.Forms.CheckBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.nudMaxTime = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTime)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(584, 41);
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
			this.txtCopyInvalid.Location = new System.Drawing.Point(88, 42);
			this.txtCopyInvalid.Name = "txtCopyInvalid";
			this.txtCopyInvalid.Size = new System.Drawing.Size(488, 20);
			this.txtCopyInvalid.TabIndex = 14;
			this.txtCopyInvalid.Text = "";
			this.txtCopyInvalid.Validating += new System.ComponentModel.CancelEventHandler(this.txtCopyInvalid_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "To Path:";
			// 
			// chkCopyInvalidFile
			// 
			this.chkCopyInvalidFile.Checked = true;
			this.chkCopyInvalidFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCopyInvalidFile.Location = new System.Drawing.Point(16, 18);
			this.chkCopyInvalidFile.Name = "chkCopyInvalidFile";
			this.chkCopyInvalidFile.Size = new System.Drawing.Size(208, 24);
			this.chkCopyInvalidFile.TabIndex = 12;
			this.chkCopyInvalidFile.Text = "Copy Unhandle  Files :";
			this.chkCopyInvalidFile.CheckedChanged += new System.EventHandler(this.chkCopyInvalidFile_CheckedChanged);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// nudMaxTime
			// 
			this.nudMaxTime.Location = new System.Drawing.Point(472, 1);
			this.nudMaxTime.Maximum = new System.Decimal(new int[] {
																	   1000000000,
																	   0,
																	   0,
																	   0});
			this.nudMaxTime.Minimum = new System.Decimal(new int[] {
																	   1,
																	   0,
																	   0,
																	   0});
			this.nudMaxTime.Name = "nudMaxTime";
			this.nudMaxTime.Size = new System.Drawing.Size(56, 20);
			this.nudMaxTime.TabIndex = 16;
			this.nudMaxTime.Value = new System.Decimal(new int[] {
																	 60,
																	 0,
																	 0,
																	 0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(443, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "Define the times to try to process unhandled files before they are copied to othe" +
				"r folder :";
			// 
			// PostProcessFileCtrl
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudMaxTime);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtCopyInvalid);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkCopyInvalidFile);
			this.Name = "PostProcessFileCtrl";
			this.Size = new System.Drawing.Size(608, 63);
			this.Load += new System.EventHandler(this.PreProcessFileCtrl_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTime)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void PreProcessFileCtrl_Load(object sender, System.EventArgs e)
		{
		
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtCopyInvalid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkCopyInvalidFile;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.NumericUpDown nudMaxTime;
		private System.Windows.Forms.Label label1;

		Modal.PostProcess _DataSource;
		public Modal.PostProcess DataSource
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
					_DataSource = new DDADBManager.Modal.PostProcess();

				_DataSource.CopyProcessFailedFile = chkCopyInvalidFile.Checked;

				_DataSource.CopyProcessFailedFilePath = txtCopyInvalid.Text;

				_DataSource.MaxTimesRetry = (int)nudMaxTime.Value;

				
			}
			else
			{
				if(_DataSource==null)
				{
					chkCopyInvalidFile.Checked= true;
					txtCopyInvalid.Text= "";
					return;
				}
				else
				{
					chkCopyInvalidFile.Checked= _DataSource.CopyProcessFailedFile;

					txtCopyInvalid.Text= _DataSource.CopyProcessFailedFilePath;

					nudMaxTime.Value = _DataSource.MaxTimesRetry;
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

	
		private void button2_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select Destination Inhandle Folder Path copy to";
			if( System.IO.Directory.Exists(txtCopyInvalid.Text))
				dlg.SelectedPath = txtCopyInvalid.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtCopyInvalid.Text = dlg.SelectedPath;
			}
		}

		private void chkCopyInvalidFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCopyInvalid.Enabled = button2.Enabled =  chkCopyInvalidFile.Checked;
		}

		public string ValidateString
		{
			get
			{
				if( chkCopyInvalidFile.Checked  && !System.IO.Directory.Exists(txtCopyInvalid.Text))
					return "Invalid Destination Unhandle Folder Path";
					return string.Empty;
			}
		}
	}
}
