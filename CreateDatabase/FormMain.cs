using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Threading;

namespace CreateDDADB
{
	public class FormMain : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnExit;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnPath;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDatabaseName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ComboBox cboDatabaseType;
		private System.Windows.Forms.Label lblmsg;
		private DBFuncs db = new DBFuncs();
		#endregion
		
		#region Constructor & Destrucotr
		public FormMain()
		{
			InitializeComponent();
		}

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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDatabaseName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnPath = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.cboDatabaseType = new System.Windows.Forms.ComboBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblmsg = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server Name:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDatabaseName);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPath);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.txtServerName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnPath);
			this.groupBox1.Location = new System.Drawing.Point(4, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(436, 144);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtDatabaseName
			// 
			this.txtDatabaseName.Location = new System.Drawing.Point(120, 40);
			this.txtDatabaseName.Name = "txtDatabaseName";
			this.txtDatabaseName.Size = new System.Drawing.Size(304, 20);
			this.txtDatabaseName.TabIndex = 2;
			this.txtDatabaseName.Text = "DDAStagingArea";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Database Name:";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(120, 112);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(272, 20);
			this.txtPath.TabIndex = 5;
			this.txtPath.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Database Path:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(120, 88);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(304, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.Text = "";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(120, 64);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(304, 20);
			this.txtUserName.TabIndex = 3;
			this.txtUserName.Text = "sa";
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(120, 16);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.ReadOnly = true;
			this.txtServerName.Size = new System.Drawing.Size(304, 20);
			this.txtServerName.TabIndex = 1;
			this.txtServerName.Text = "(local)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "User Name:";
			// 
			// btnPath
			// 
			this.btnPath.Location = new System.Drawing.Point(396, 112);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(28, 20);
			this.btnPath.TabIndex = 6;
			this.btnPath.Text = "...";
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(143, 196);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(80, 24);
			this.btnCreate.TabIndex = 7;
			this.btnCreate.Text = "&Create";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(227, 196);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(80, 24);
			this.btnExit.TabIndex = 8;
			this.btnExit.Text = "C&lose";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "Create Database for:";
			// 
			// cboDatabaseType
			// 
			this.cboDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDatabaseType.Items.AddRange(new object[] {
																 "DDADB",
																 "DDAStagingArea",
																 "DDAArchives"});
			this.cboDatabaseType.Location = new System.Drawing.Point(124, 12);
			this.cboDatabaseType.Name = "cboDatabaseType";
			this.cboDatabaseType.Size = new System.Drawing.Size(172, 21);
			this.cboDatabaseType.TabIndex = 10;
			this.cboDatabaseType.SelectedIndexChanged += new System.EventHandler(this.cboDatabaseType_SelectedIndexChanged);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblmsg
			// 
			this.lblmsg.AutoSize = true;
			this.lblmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblmsg.ForeColor = System.Drawing.Color.Green;
			this.lblmsg.Location = new System.Drawing.Point(300, 16);
			this.lblmsg.Name = "lblmsg";
			this.lblmsg.Size = new System.Drawing.Size(139, 16);
			this.lblmsg.TabIndex = 11;
			this.lblmsg.Text = "This database was created";
			this.lblmsg.Visible = false;
			// 
			// FormMain
			// 
			this.AcceptButton = this.btnCreate;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(450, 232);
			this.Controls.Add(this.lblmsg);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cboDatabaseType);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create DDADB";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Main
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}
		#endregion

		#region UI Command

		private void CreateNewDatabase()
		{
			if (!db.DropConnection(txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text)) return;
			if(!db.DetachDatabase(txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text, txtPath.Text)) return;
			if (!db.CreateDatabase(txtServerName.Text,txtDatabaseName.Text,txtUserName.Text,txtPassword.Text, txtPath.Text)) return;

			if(!db.RunScript(txtServerName.Text,txtDatabaseName.Text,txtUserName.Text,txtPassword.Text,"CreateDDADB.Data.Login.sql")) return;

			if(cboDatabaseType.SelectedIndex==0)
			{
				if(!db.RunScript(txtServerName.Text,txtDatabaseName.Text,txtUserName.Text,txtPassword.Text,"CreateDDADB.Data.ScriptDatabase.sql")) return;
			}
			else
			{
				if(!db.RunScript(txtServerName.Text,txtDatabaseName.Text,txtUserName.Text,txtPassword.Text,"CreateDDADB.Data.ScriptDatabase1.sql")) return;
			}

			if(!db.RunScript(txtServerName.Text,txtDatabaseName.Text,txtUserName.Text,txtPassword.Text,"CreateDDADB.Data.InsertData.sql",cboDatabaseType.Text)) return;

			MessageBox.Show("Create database successfully.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			
			SiGlaz.Common.Configuration.SetValues(cboDatabaseType.Text,true);
			UpdateMsg();
		}

		private bool CheckInformation()
		{
			bool bResult=true;

			if(txtServerName.Text == "")
			{
				txtServerName.Focus();
				bResult = false;
				MessageBox.Show("Please enter server name.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if(txtDatabaseName.Text == "")
			{
				txtDatabaseName.Focus();
				bResult = false;
				MessageBox.Show("Please enter database name.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if (txtDatabaseName.Text.IndexOf(" ") >= 0)
			{
				txtDatabaseName.Focus();
				bResult = false;
				MessageBox.Show("Please do not use space in database name.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if(txtUserName.Text == "")
			{
				txtUserName.Focus();
				bResult = false;
				MessageBox.Show("Please enter user name.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if (txtUserName.Text.IndexOf(" ") >= 0)
			{
				txtUserName.Focus();
				bResult = false;
				MessageBox.Show("Please do not use space in user name.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if(txtPassword.Text == "")
			{
				txtPassword.Focus();
				bResult = false;
				MessageBox.Show("Please enter password.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if(txtPath.Text == "")
			{
				btnPath.Focus();
				bResult = false;
				MessageBox.Show("Please select database path.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

			return bResult;
		}

		private bool CheckDatabaseExist(string PathName)
		{
			bool bResult=false;
			string[] alFiles=Directory.GetFiles(PathName,"*.mdf");

			foreach(string strFileName in alFiles)
			{
				if(PathName.ToUpper()+"\\DDADB_Data.MDF".ToUpper()==strFileName.ToUpper())	
				{
					bResult=true;
					break;
				}
			}

			return bResult;
		}

		private bool CheckDirectoryPermission(string folder)
		{
			bool result = true;

			string filename = string.Format("{0}\\writetest.txt", folder);

			StreamWriter sw = null;
			try
			{
				sw = File.CreateText(filename);

				sw.Close();
				sw = null;

				File.Delete(filename);
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (sw != null)
				{
					sw.Close();
					sw = null;
				}
			}
		
			return result;
		}

		private void IsLocalFolder(String path, ref bool isLocalFolder)
		{
			try
			{
				if(path == "") 
				{
					isLocalFolder = true;
					return;
				}

				String root = Path.GetPathRoot(path);			
				uint driveType = GetDriveType(root);

				//It is a local folder
				if (driveType == DRIVE_FIXED)
				{
					isLocalFolder = true;
					return ;
				}

				//It can be a network folder
				//Check if the path is an UNC format

				isLocalFolder = false;
				if (path.Length < 4)
					return ;

				if (path[0] != '\\' || path[1] != '\\')
					return ;

				if (path[2] == '\\')
					return ;
			
				//End of computer name
				int pos = path.IndexOf('\\', 3);
				if (pos < 0)
					return ;

				//Check if the folder name is empty
				pos++;
				if (pos >= path.Length)
					return ;

				return ;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		#region Windows Events Handles
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();		
		}

		private void btnPath_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			FolderBrowserDialog dlg=new FolderBrowserDialog();

			if(dlg.ShowDialog()==DialogResult.OK)
			{
				bool isLocal = false;

				IsLocalFolder(dlg.SelectedPath, ref isLocal);

				if (isLocal)
				{
					if (CheckDirectoryPermission(dlg.SelectedPath))
						txtPath.Text = dlg.SelectedPath;
					else
						MessageBox.Show(String.Format("Create DDADB is not allowed to create database into folder {0}.\r\nPlease check the right to modify the folder.", dlg.SelectedPath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					MessageBox.Show("The database path must be a local path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			Cursor.Current = Cursors.Default;
		}

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (CheckInformation())
			{
				btnExit.Enabled=false;
				try
				{
					_waitForm = new FormStatus();

					// start worker thread for creating database
					ThreadPool.QueueUserWorkItem(new WaitCallback(WorkerThread));

					// start wait dialog
					_waitForm.ShowDialog(this);
				}
				catch 
				{
				}
				finally
				{
					if (_waitForm != null)
						_waitForm.Dispose();
					_waitForm = null;
				}

				btnExit.Enabled=true;
			}
			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Threading Model
		private FormStatus _waitForm = null;

		private void WorkerThread(object status)
		{
			try
			{
				CreateNewDatabase();
			}
			catch (System.Exception exp)
			{
				MessageBox.Show("Failed to create DDADB: ", exp.Message);
			}
			finally
			{
				if (_waitForm != null)
					_waitForm.Close();
			}
		}

		#endregion

		#region Win32 API
		
		const int DRIVE_UNKNOWN  =   0;
		const int DRIVE_NO_ROOT_DIR = 1;
		const int DRIVE_REMOVABLE  = 2;
		const int DRIVE_FIXED    = 3;
		const int DRIVE_REMOTE      = 4;
		const int DRIVE_CDROM       = 5;
		const int DRIVE_RAMDISK     = 6;

		[DllImport("kernel32.dll")]
		protected static extern uint GetDriveType(string driveLetter);

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			protected struct NETRESOURCE 
		{
			public uint dwScope;
			public uint dwType;  
			public uint dwDisplayType;  
			public uint dwUsage;  
			public string lpLocalName;  
			public string lpRemoteName;  
			public string lpComment;  
			public string lpProvider;
		}

		[DllImport("mpr", CharSet=CharSet.Auto)]
		protected static extern uint WNetAddConnection2(
			ref NETRESOURCE lpNetResource,
			string lpPassword,
			string lpUsername,
			uint dwFlags
			);

		#region CONNECTION_ERROR_CODE
		public const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;
		#endregion

		private void cboDatabaseType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtDatabaseName.ReadOnly = cboDatabaseType.SelectedIndex==0;
			txtDatabaseName.Text = cboDatabaseType.Text;
			UpdateMsg();
		}

		private void UpdateMsg()
		{
			lblmsg.Visible = (bool) SiGlaz.Common.Configuration.GetValues(cboDatabaseType.Text,false);
		}
	
		#endregion

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			cboDatabaseType.SelectedIndex = 0;
		}

	}
}
