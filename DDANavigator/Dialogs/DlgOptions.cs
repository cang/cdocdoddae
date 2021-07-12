using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.DAL;
using SiGlaz.Utility;

namespace DDANavigator.Dialogs
{
	public class DlgOptions : FormBase
	{
		#region Members
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabControl tabOptions;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabPage pageWebService;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnTestWebService;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.TextBox txtWebService;
		private System.Windows.Forms.TabPage pageDDAPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtDDAPath;
		private System.Windows.Forms.TabPage pageQuery;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numRecordLimit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton raDDAStagingArea;
		private System.Windows.Forms.RadioButton raDDADBType;
		private System.Windows.Forms.TabPage pageExportDataConnectionInformation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.TextBox txtDatabaseName;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnTestConnection;
		private System.Windows.Forms.Label label1;
		#endregion
		
		#region Constructor & Destructor
		public DlgOptions()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgOptions));
			this.tabOptions = new System.Windows.Forms.TabControl();
			this.pageWebService = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.raDDAStagingArea = new System.Windows.Forms.RadioButton();
			this.raDDADBType = new System.Windows.Forms.RadioButton();
			this.txtWebService = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTestWebService = new System.Windows.Forms.Button();
			this.pageDDAPath = new System.Windows.Forms.TabPage();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtDDAPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pageQuery = new System.Windows.Forms.TabPage();
			this.numRecordLimit = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pageExportDataConnectionInformation = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.txtDatabaseName = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnTestConnection = new System.Windows.Forms.Button();
			this.tabOptions.SuspendLayout();
			this.pageWebService.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pageDDAPath.SuspendLayout();
			this.pageQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRecordLimit)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pageExportDataConnectionInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.pageWebService);
			this.tabOptions.Controls.Add(this.pageExportDataConnectionInformation);
			this.tabOptions.Controls.Add(this.pageDDAPath);
			this.tabOptions.Controls.Add(this.pageQuery);
			this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabOptions.ImageList = this.imgList;
			this.tabOptions.Location = new System.Drawing.Point(0, 0);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.SelectedIndex = 0;
			this.tabOptions.Size = new System.Drawing.Size(482, 196);
			this.tabOptions.TabIndex = 0;
			// 
			// pageWebService
			// 
			this.pageWebService.Controls.Add(this.groupBox1);
			this.pageWebService.Controls.Add(this.txtWebService);
			this.pageWebService.Controls.Add(this.label1);
			this.pageWebService.Controls.Add(this.btnTestWebService);
			this.pageWebService.ImageIndex = 0;
			this.pageWebService.Location = new System.Drawing.Point(4, 23);
			this.pageWebService.Name = "pageWebService";
			this.pageWebService.Size = new System.Drawing.Size(474, 169);
			this.pageWebService.TabIndex = 1;
			this.pageWebService.Text = "DDA Web Service";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raDDAStagingArea);
			this.groupBox1.Controls.Add(this.raDDADBType);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(12, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(452, 84);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Query data from:";
			// 
			// raDDAStagingArea
			// 
			this.raDDAStagingArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDDAStagingArea.Location = new System.Drawing.Point(28, 48);
			this.raDDAStagingArea.Name = "raDDAStagingArea";
			this.raDDAStagingArea.Size = new System.Drawing.Size(184, 24);
			this.raDDAStagingArea.TabIndex = 1;
			this.raDDAStagingArea.Text = "DDAStagingArea";
			// 
			// raDDADBType
			// 
			this.raDDADBType.Checked = true;
			this.raDDADBType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDDADBType.Location = new System.Drawing.Point(28, 24);
			this.raDDADBType.Name = "raDDADBType";
			this.raDDADBType.TabIndex = 0;
			this.raDDADBType.TabStop = true;
			this.raDDADBType.Text = "DDADB";
			// 
			// txtWebService
			// 
			this.txtWebService.Location = new System.Drawing.Point(88, 22);
			this.txtWebService.Name = "txtWebService";
			this.txtWebService.Size = new System.Drawing.Size(372, 20);
			this.txtWebService.TabIndex = 20;
			this.txtWebService.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 16);
			this.label1.TabIndex = 19;
			this.label1.Text = "Web Service:";
			// 
			// btnTestWebService
			// 
			this.btnTestWebService.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTestWebService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTestWebService.ImageIndex = 3;
			this.btnTestWebService.Location = new System.Drawing.Point(356, 140);
			this.btnTestWebService.Name = "btnTestWebService";
			this.btnTestWebService.Size = new System.Drawing.Size(108, 23);
			this.btnTestWebService.TabIndex = 16;
			this.btnTestWebService.Text = "&Test web service";
			this.btnTestWebService.Click += new System.EventHandler(this.btnTestWebService_Click);
			// 
			// pageDDAPath
			// 
			this.pageDDAPath.Controls.Add(this.btnBrowse);
			this.pageDDAPath.Controls.Add(this.txtDDAPath);
			this.pageDDAPath.Controls.Add(this.label2);
			this.pageDDAPath.ImageIndex = 1;
			this.pageDDAPath.Location = new System.Drawing.Point(4, 23);
			this.pageDDAPath.Name = "pageDDAPath";
			this.pageDDAPath.Size = new System.Drawing.Size(474, 169);
			this.pageDDAPath.TabIndex = 2;
			this.pageDDAPath.Text = "DDA Path";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(392, 17);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(64, 23);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtDDAPath
			// 
			this.txtDDAPath.Location = new System.Drawing.Point(76, 20);
			this.txtDDAPath.Name = "txtDDAPath";
			this.txtDDAPath.ReadOnly = true;
			this.txtDDAPath.Size = new System.Drawing.Size(312, 20);
			this.txtDDAPath.TabIndex = 1;
			this.txtDDAPath.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "DDA Path:";
			// 
			// pageQuery
			// 
			this.pageQuery.Controls.Add(this.numRecordLimit);
			this.pageQuery.Controls.Add(this.label3);
			this.pageQuery.ImageIndex = 2;
			this.pageQuery.Location = new System.Drawing.Point(4, 23);
			this.pageQuery.Name = "pageQuery";
			this.pageQuery.Size = new System.Drawing.Size(474, 169);
			this.pageQuery.TabIndex = 3;
			this.pageQuery.Text = "Query";
			// 
			// numRecordLimit
			// 
			this.numRecordLimit.Location = new System.Drawing.Point(92, 20);
			this.numRecordLimit.Maximum = new System.Decimal(new int[] {
																		   999999999,
																		   0,
																		   0,
																		   0});
			this.numRecordLimit.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numRecordLimit.Name = "numRecordLimit";
			this.numRecordLimit.Size = new System.Drawing.Size(128, 20);
			this.numRecordLimit.TabIndex = 1;
			this.numRecordLimit.Value = new System.Decimal(new int[] {
																		 10000,
																		 0,
																		 0,
																		 0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Limit Records:";
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 196);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(482, 36);
			this.panel1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(243, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(161, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabOptions);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(482, 196);
			this.panel2.TabIndex = 2;
			// 
			// pageExportDataConnectionInformation
			// 
			this.pageExportDataConnectionInformation.Controls.Add(this.btnTestConnection);
			this.pageExportDataConnectionInformation.Controls.Add(this.txtPassword);
			this.pageExportDataConnectionInformation.Controls.Add(this.txtUserName);
			this.pageExportDataConnectionInformation.Controls.Add(this.txtDatabaseName);
			this.pageExportDataConnectionInformation.Controls.Add(this.txtServerName);
			this.pageExportDataConnectionInformation.Controls.Add(this.label8);
			this.pageExportDataConnectionInformation.Controls.Add(this.label7);
			this.pageExportDataConnectionInformation.Controls.Add(this.label5);
			this.pageExportDataConnectionInformation.Controls.Add(this.label4);
			this.pageExportDataConnectionInformation.Location = new System.Drawing.Point(4, 23);
			this.pageExportDataConnectionInformation.Name = "pageExportDataConnectionInformation";
			this.pageExportDataConnectionInformation.Size = new System.Drawing.Size(474, 169);
			this.pageExportDataConnectionInformation.TabIndex = 4;
			this.pageExportDataConnectionInformation.Text = "Export Data Connection Information";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Server Name:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Database Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "User Name:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 16);
			this.label8.TabIndex = 4;
			this.label8.Text = "Password:";
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(100, 12);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new System.Drawing.Size(360, 20);
			this.txtServerName.TabIndex = 5;
			this.txtServerName.Text = "(local)";
			// 
			// txtDatabaseName
			// 
			this.txtDatabaseName.Location = new System.Drawing.Point(100, 36);
			this.txtDatabaseName.Name = "txtDatabaseName";
			this.txtDatabaseName.Size = new System.Drawing.Size(360, 20);
			this.txtDatabaseName.TabIndex = 6;
			this.txtDatabaseName.Text = "DDADB";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(100, 60);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(360, 20);
			this.txtUserName.TabIndex = 8;
			this.txtUserName.Text = "sa";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(100, 84);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(360, 20);
			this.txtPassword.TabIndex = 9;
			this.txtPassword.Text = "123456";
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTestConnection.ImageIndex = 3;
			this.btnTestConnection.Location = new System.Drawing.Point(328, 112);
			this.btnTestConnection.Name = "btnTestConnection";
			this.btnTestConnection.Size = new System.Drawing.Size(132, 23);
			this.btnTestConnection.TabIndex = 17;
			this.btnTestConnection.Text = "Test &Connection";
			this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
			// 
			// DlgOptions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(482, 232);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Options";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DlgOptions_Closing);
			this.Load += new System.EventHandler(this.DlgOptions_Load);
			this.tabOptions.ResumeLayout(false);
			this.pageWebService.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.pageDDAPath.ResumeLayout(false);
			this.pageQuery.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numRecordLimit)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pageExportDataConnectionInformation.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		private bool CheckInfo()
		{
			bool result = true;

			if (txtWebService.Text == string.Empty)
			{
				MessageBox.Show("Please enter DDA Web Service.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
			}
			else if (txtServerName.Text == string.Empty)
			{
				MessageBox.Show("Please enter Server Name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
			}
			else if (txtDatabaseName.Text == string.Empty)
			{
				MessageBox.Show("Please enter Database Name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
			}
			else if (txtUserName.Text == string.Empty)
			{
				result = false;
				MessageBox.Show("Please enter User Name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtUserName.Focus();
			}
			else if (txtPassword.Text == string.Empty)
			{
				result = false;
				MessageBox.Show("Please enter Password.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPassword.Focus();
			}

			return result;
		}
		#endregion

		#region Windows Events Handles
		private bool Test()
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				WebServiceProxy.CategoryProxy.Category proxy = new WebServiceProxy.CategoryProxy.Category();
				proxy.Url = string.Format("{0}/{1}", txtWebService.Text, SiGlaz.Common.DDA.Const.WebServiceConst.Category);

				proxy.HelloWorld();

				bool result = false;
				
				if (raDDADBType.Checked)
					result = proxy.TestConnection(WebServiceProxy.CategoryProxy.DDADBType.DDADB);
				else
					result = proxy.TestConnection(WebServiceProxy.CategoryProxy.DDADBType.DDAStagingArea);

				if (result)
				{
					MessageBox.Show("Test DDA Web Service successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);	
					return true;
				}
				else
				{
					MessageBox.Show("Web service connect to database fail\r\nPlease contact with web service administrator to re-check connection information.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);	
					return false;
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(string.Format("Test DDA web service fail: {0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);	
				return false;
			}
		}

		private void btnTestWebService_Click(object sender, System.EventArgs e)
		{
			Test();
		}

		private void DlgOptions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if(!CheckInfo())
				{
					e.Cancel = true;
					return;
				}

				AppData.Data.WebServiceList[WebServicetypeType.Root] = txtWebService.Text;
				AppData.Data.DDAPath = txtDDAPath.Text;
				AppData.Data.MaxRow = (int)numRecordLimit.Value;

				if (raDDADBType.Checked)
					AppData.Data.DBType = DDADBType.DDADB;
				else
					AppData.Data.DBType = DDADBType.DDAStagingArea;

				AppData.Data.ServerName = txtServerName.Text;
				AppData.Data.DatabaseName = txtDatabaseName.Text;
				AppData.Data.UserName = txtUserName.Text;
				
				RijndaelCrypto crypto = new RijndaelCrypto();
				AppData.Data.Password = crypto.Encrypt(txtPassword.Text);
			}
		}

		private void DlgOptions_Load(object sender, System.EventArgs e)
		{
			txtWebService.Text = AppData.Data.WebServiceList[WebServicetypeType.Root];
			txtDDAPath.Text = AppData.Data.DDAPath;
			numRecordLimit.Value = (Decimal)AppData.Data.MaxRow;

			raDDADBType.Checked = false;
			raDDAStagingArea.Checked = false;

			if (AppData.Data.DBType == DDADBType.DDADB)
				raDDADBType.Checked = true;
			else if (AppData.Data.DBType == DDADBType.DDAStagingArea)
				raDDAStagingArea.Checked = true;

			txtServerName.Text = AppData.Data.ServerName;
			txtDatabaseName.Text = AppData.Data.DatabaseName;
			txtUserName.Text = AppData.Data.UserName;

			RijndaelCrypto crypto = new RijndaelCrypto();
			txtPassword.Text = crypto.Decrypt(AppData.Data.Password);
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "(*.exe)|*.exe";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				txtDDAPath.Text = dlg.FileName;
			}
		}

		private void btnTestConnection_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			ConnectionParam param = new ConnectionParam();
			param.Server = txtServerName.Text;
			param.Database = txtDatabaseName.Text;
			param.Username = txtUserName.Text;
			param.Password = txtPassword.Text;

			if (param.TestConnection())
				MessageBox.Show("Testing connection successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show(string.Format("Testing connection fails. Please check if database: '{0}' exists or if authentication is correct.", txtDatabaseName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion
	}
}
