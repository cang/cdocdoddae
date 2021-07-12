using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for DataSourceCtrl.
	/// </summary>
	public class DataSourceCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton raLocal;
		private System.Windows.Forms.RadioButton raFTP;
		private System.Windows.Forms.Panel pLocal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLocalPath;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtRemoteDir;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown nudPort;
		private System.Windows.Forms.Panel pFTP;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.CheckBox chkDeleteSourceFile;
        private System.Windows.Forms.CheckBox chkDeleteInvalid;
        private IContainer components;

		public event EventHandler OnSize;

		public DataSourceCtrl()
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.raFTP = new System.Windows.Forms.RadioButton();
            this.raLocal = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.pLocal = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pFTP = new System.Windows.Forms.Panel();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkDeleteSourceFile = new System.Windows.Forms.CheckBox();
            this.chkDeleteInvalid = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.pLocal.SuspendLayout();
            this.pFTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.raFTP);
            this.groupBox1.Controls.Add(this.raLocal);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.pLocal);
            this.groupBox1.Controls.Add(this.pFTP);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folder Type";
            // 
            // raFTP
            // 
            this.raFTP.Enabled = false;
            this.raFTP.Location = new System.Drawing.Point(208, 16);
            this.raFTP.Name = "raFTP";
            this.raFTP.Size = new System.Drawing.Size(104, 24);
            this.raFTP.TabIndex = 1;
            this.raFTP.Text = "FTP";
            this.raFTP.CheckedChanged += new System.EventHandler(this.raFTP_CheckedChanged);
            // 
            // raLocal
            // 
            this.raLocal.Checked = true;
            this.raLocal.Location = new System.Drawing.Point(8, 16);
            this.raLocal.Name = "raLocal";
            this.raLocal.Size = new System.Drawing.Size(104, 24);
            this.raLocal.TabIndex = 0;
            this.raLocal.TabStop = true;
            this.raLocal.Text = "Local";
            this.raLocal.CheckedChanged += new System.EventHandler(this.raLocal_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(96, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Test";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pLocal
            // 
            this.pLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pLocal.Controls.Add(this.button1);
            this.pLocal.Controls.Add(this.txtLocalPath);
            this.pLocal.Controls.Add(this.label1);
            this.pLocal.Location = new System.Drawing.Point(8, 40);
            this.pLocal.Name = "pLocal";
            this.pLocal.Size = new System.Drawing.Size(632, 108);
            this.pLocal.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(608, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalPath.Location = new System.Drawing.Point(88, 6);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(512, 20);
            this.txtLocalPath.TabIndex = 1;
            this.txtLocalPath.Validating += new System.ComponentModel.CancelEventHandler(this.txtLocalPath_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder Path:";
            // 
            // pFTP
            // 
            this.pFTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pFTP.Controls.Add(this.nudPort);
            this.pFTP.Controls.Add(this.label6);
            this.pFTP.Controls.Add(this.txtPassword);
            this.pFTP.Controls.Add(this.label5);
            this.pFTP.Controls.Add(this.txtUsername);
            this.pFTP.Controls.Add(this.label4);
            this.pFTP.Controls.Add(this.label3);
            this.pFTP.Controls.Add(this.txtServer);
            this.pFTP.Controls.Add(this.label2);
            this.pFTP.Controls.Add(this.txtRemoteDir);
            this.pFTP.Location = new System.Drawing.Point(8, 40);
            this.pFTP.Name = "pFTP";
            this.pFTP.Size = new System.Drawing.Size(634, 108);
            this.pFTP.TabIndex = 3;
            // 
            // nudPort
            // 
            this.nudPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPort.Location = new System.Drawing.Point(554, 6);
            this.nudPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(72, 20);
            this.nudPort.TabIndex = 3;
            this.nudPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Remote Dir:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(88, 32);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(120, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User name:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(88, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(424, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Validating += new System.ComponentModel.CancelEventHandler(this.txtServer_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "FTP Server:";
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteDir.Location = new System.Drawing.Point(88, 80);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.Size = new System.Drawing.Size(426, 20);
            this.txtRemoteDir.TabIndex = 9;
            this.txtRemoteDir.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemoteDir_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkDeleteSourceFile
            // 
            this.chkDeleteSourceFile.Checked = true;
            this.chkDeleteSourceFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteSourceFile.Location = new System.Drawing.Point(8, 176);
            this.chkDeleteSourceFile.Name = "chkDeleteSourceFile";
            this.chkDeleteSourceFile.Size = new System.Drawing.Size(128, 24);
            this.chkDeleteSourceFile.TabIndex = 5;
            this.chkDeleteSourceFile.Text = "Delete Source File";
            this.chkDeleteSourceFile.Visible = false;
            // 
            // chkDeleteInvalid
            // 
            this.chkDeleteInvalid.Checked = true;
            this.chkDeleteInvalid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteInvalid.Location = new System.Drawing.Point(216, 176);
            this.chkDeleteInvalid.Name = "chkDeleteInvalid";
            this.chkDeleteInvalid.Size = new System.Drawing.Size(120, 24);
            this.chkDeleteInvalid.TabIndex = 6;
            this.chkDeleteInvalid.Text = "Delete Invalid File";
            this.chkDeleteInvalid.Visible = false;
            // 
            // DataSourceCtrl
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkDeleteInvalid);
            this.Controls.Add(this.chkDeleteSourceFile);
            this.Name = "DataSourceCtrl";
            this.Size = new System.Drawing.Size(648, 180);
            this.groupBox1.ResumeLayout(false);
            this.pLocal.ResumeLayout(false);
            this.pLocal.PerformLayout();
            this.pFTP.ResumeLayout(false);
            this.pFTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void raLocal_CheckedChanged(object sender, System.EventArgs e)
		{
			pLocal.BringToFront();
			if(this.Height!=104)
			{
				this.Height = 104;
				if(OnSize!=null)
					OnSize(104,null);
			}
		}

		private void raFTP_CheckedChanged(object sender, System.EventArgs e)
		{
			pFTP.BringToFront();
			if(this.Height!=180)
			{
				this.Height = 180;
				if(OnSize!=null)
					OnSize(180,null);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(raLocal.Checked)
			{
				if( System.IO.Directory.Exists(txtLocalPath.Text))
					MessageBox.Show("Folder is exist.", this.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("Folder is not exist." ,this.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				try
				{
					FtpClient ftp = new FtpClient(txtServer.Text,Convert.ToInt32(nudPort.Value), txtUsername.Text,txtPassword.Text,txtRemoteDir.Text,"");
					if ( ftp.Open() )
					{
						MessageBox.Show("Test connection succeeded.", this.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Test connection failed." ,this.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				
					ftp.Close();
				}
				catch ( Exception ex )
				{
					MessageBox.Show("Test connection failed.\r\n" + ex.Message,this.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Select source path folder to listen";
			if( System.IO.Directory.Exists(txtLocalPath.Text))
				dlg.SelectedPath = txtLocalPath.Text;

			if( dlg.ShowDialog(this)== DialogResult.OK)
			{
				txtLocalPath.Text = dlg.SelectedPath;
			}
		}


		private void txtLocalPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			if( raLocal.Checked && !System.IO.Directory.Exists(txtLocalPath.Text))
//			{
//				errorProvider1.SetError(sender as Control,"Invalid Folder Path");
//				e.Cancel = true;
//			}
//			else
//			{
//				errorProvider1.SetError(sender as Control,string.Empty);
//			}
		}

		private void txtServer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if( raFTP.Checked && txtServer.Text.Trim()==string.Empty )
			{
				errorProvider1.SetError(sender as Control,"Invalid FTP Server");
				e.Cancel = true;
			}
			else
			{
				errorProvider1.SetError(sender as Control,string.Empty);
			}
		}

		private void txtRemoteDir_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if( raFTP.Checked && txtRemoteDir.Text.Trim()==string.Empty )
			{
				errorProvider1.SetError(sender as Control ,"Invalid FTP Remote Dir");
				e.Cancel = true;
			}
			else
			{
				errorProvider1.SetError(sender as Control,string.Empty);
			}
		}

		private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if( raFTP.Checked && txtUsername.Text.Trim()==string.Empty )
			{
				errorProvider1.SetError(sender as Control,"Invalid User name");
				e.Cancel = true;
			}
			else
			{
				errorProvider1.SetError(sender as Control,string.Empty);
			}
		}

		public string ValidateString
		{
			get
			{
				if( raLocal.Checked && !System.IO.Directory.Exists(txtLocalPath.Text.Trim()))
					return "Invalid Folder Path";
				if( raFTP.Checked && txtServer.Text.Trim()==string.Empty )
					return "Invalid FTP Server";
				if( raFTP.Checked && txtRemoteDir.Text.Trim()==string.Empty )
					return "Invalid FTP Remote Dir";
				if( raFTP.Checked && txtUsername.Text.Trim()==string.Empty )
					return "Invalid User name";
				return string.Empty;
			}
		}

		public void UpdateData(bool update)
		{
			if(update)
			{
				if( raLocal.Checked)
					_DataSource = new DDADBManager.Modal.SourceFolder();
				else
					_DataSource = new DDADBManager.Modal.SourceFTP();
				if(_DataSource is DDADBManager.Modal.SourceFolder)
				{
					(_DataSource as DDADBManager.Modal.SourceFolder).FolderPath = txtLocalPath.Text.Trim();
				}
				else
				{
					(_DataSource as DDADBManager.Modal.SourceFTP).Server = txtServer.Text.Trim();
					(_DataSource as DDADBManager.Modal.SourceFTP).Port = Convert.ToInt32(nudPort.Value);
					(_DataSource as DDADBManager.Modal.SourceFTP).Username = txtUsername.Text.Trim();
					(_DataSource as DDADBManager.Modal.SourceFTP).Password  = txtPassword.Text.Trim();
					(_DataSource as DDADBManager.Modal.SourceFTP).Directory = txtRemoteDir.Text.Trim();
				}

				_DataSource.DeleteAfterProcess = chkDeleteSourceFile.Checked;
				_DataSource.DeleteInvalidFile = chkDeleteInvalid.Checked;
			}
			else
			{
				if(_DataSource==null)
				{
					return;
				}
				else
				{
					if(_DataSource is DDADBManager.Modal.SourceFolder)
					{
						raLocal.Checked = true;
						txtLocalPath.Text = (_DataSource as DDADBManager.Modal.SourceFolder).FolderPath;
					}
					else
					{
						raFTP.Checked = true;
						txtServer.Text =(_DataSource as DDADBManager.Modal.SourceFTP).Server;
						nudPort.Value =(_DataSource as DDADBManager.Modal.SourceFTP).Port ;
						txtUsername.Text =(_DataSource as DDADBManager.Modal.SourceFTP).Username;
						txtPassword.Text =(_DataSource as DDADBManager.Modal.SourceFTP).Password  ;
						txtRemoteDir.Text =(_DataSource as DDADBManager.Modal.SourceFTP).Directory ;
					}
					chkDeleteSourceFile.Checked =_DataSource.DeleteAfterProcess;
					chkDeleteInvalid.Checked = DataSource.DeleteInvalidFile;
				}
			}
		}

		Modal.DataSource _DataSource;
		public Modal.DataSource DataSource
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
	}
}
