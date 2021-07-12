using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using SiGlaz.DAL;


namespace SiGlaz.DDA.Tools.DDAWebServiceTool
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Private constants
		private const string AppTitle = "DDA Portal Web Service Tool";
		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtURL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string _virtualDirectory;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnTestDDADB;
		private System.Windows.Forms.Button btnDDAStagingArea;
		private System.Windows.Forms.TextBox txtUser1;
		private System.Windows.Forms.TextBox txtDBN1;
		private System.Windows.Forms.TextBox txtPass1;
		private System.Windows.Forms.TextBox txtServer1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtUser2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDBN2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtPass2;
		private System.Windows.Forms.TextBox txtServer2;
		private System.Windows.Forms.Button btnDDADataMarts;
		private int _port;

		public MainForm() : this("DDAWebService", 80)
		{
			
		}

		public MainForm(string virtualDirectory, int port)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		

			this._virtualDirectory = virtualDirectory;
			this._port = port;
		
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnTestDDADB = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnDDAStagingArea = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtUser1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDBN1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtPass1 = new System.Windows.Forms.TextBox();
			this.txtServer1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnDDADataMarts = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.txtUser2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtDBN2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.txtPass2 = new System.Windows.Forms.TextBox();
			this.txtServer2 = new System.Windows.Forms.TextBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnTest = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(9, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(416, 192);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnTestDDADB);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.txtUsername);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtDatabase);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtPassword);
			this.tabPage1.Controls.Add(this.txtServer);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(408, 166);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "DDADB Connection";
			// 
			// btnTestDDADB
			// 
			this.btnTestDDADB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTestDDADB.Location = new System.Drawing.Point(248, 136);
			this.btnTestDDADB.Name = "btnTestDDADB";
			this.btnTestDDADB.Size = new System.Drawing.Size(144, 23);
			this.btnTestDDADB.TabIndex = 24;
			this.btnTestDDADB.Text = "Test Connection";
			this.btnTestDDADB.Click += new System.EventHandler(this.btnTestDDADB_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "Password";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(136, 80);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(256, 20);
			this.txtUsername.TabIndex = 21;
			this.txtUsername.Text = "DDADBUser";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 16);
			this.label3.TabIndex = 20;
			this.label3.Text = "User  name";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(136, 48);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(256, 20);
			this.txtDatabase.TabIndex = 19;
			this.txtDatabase.Text = "DDADB";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Database name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Database server";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(136, 112);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(256, 20);
			this.txtPassword.TabIndex = 23;
			this.txtPassword.Text = "DDADBPassword";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(136, 16);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(256, 20);
			this.txtServer.TabIndex = 17;
			this.txtServer.Text = "(local)";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnDDAStagingArea);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.txtUser1);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.txtDBN1);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.label10);
			this.tabPage3.Controls.Add(this.txtPass1);
			this.tabPage3.Controls.Add(this.txtServer1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(408, 166);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "DDAStagingArea Connection";
			// 
			// btnDDAStagingArea
			// 
			this.btnDDAStagingArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDDAStagingArea.Location = new System.Drawing.Point(256, 136);
			this.btnDDAStagingArea.Name = "btnDDAStagingArea";
			this.btnDDAStagingArea.Size = new System.Drawing.Size(136, 23);
			this.btnDDAStagingArea.TabIndex = 32;
			this.btnDDAStagingArea.Text = "Test Connection";
			this.btnDDAStagingArea.Click += new System.EventHandler(this.btnDDAStagingArea_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 116);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 16);
			this.label7.TabIndex = 30;
			this.label7.Text = "Password";
			// 
			// txtUser1
			// 
			this.txtUser1.Location = new System.Drawing.Point(136, 80);
			this.txtUser1.Name = "txtUser1";
			this.txtUser1.Size = new System.Drawing.Size(256, 20);
			this.txtUser1.TabIndex = 29;
			this.txtUser1.Text = "DDADBUser";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 84);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 16);
			this.label8.TabIndex = 28;
			this.label8.Text = "User  name";
			// 
			// txtDBN1
			// 
			this.txtDBN1.Location = new System.Drawing.Point(136, 48);
			this.txtDBN1.Name = "txtDBN1";
			this.txtDBN1.Size = new System.Drawing.Size(256, 20);
			this.txtDBN1.TabIndex = 27;
			this.txtDBN1.Text = "DDAStagingArea";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(84, 16);
			this.label9.TabIndex = 26;
			this.label9.Text = "Database name";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 16);
			this.label10.TabIndex = 24;
			this.label10.Text = "Database server";
			// 
			// txtPass1
			// 
			this.txtPass1.Location = new System.Drawing.Point(136, 112);
			this.txtPass1.Name = "txtPass1";
			this.txtPass1.PasswordChar = '*';
			this.txtPass1.Size = new System.Drawing.Size(256, 20);
			this.txtPass1.TabIndex = 31;
			this.txtPass1.Text = "DDADBPassword";
			// 
			// txtServer1
			// 
			this.txtServer1.Location = new System.Drawing.Point(136, 16);
			this.txtServer1.Name = "txtServer1";
			this.txtServer1.Size = new System.Drawing.Size(256, 20);
			this.txtServer1.TabIndex = 25;
			this.txtServer1.Text = "(local)";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnDDADataMarts);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.txtUser2);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.txtDBN2);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.txtPass2);
			this.tabPage2.Controls.Add(this.txtServer2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(408, 166);
			this.tabPage2.TabIndex = 3;
			this.tabPage2.Text = "DDADataMarts Connection";
			// 
			// btnDDADataMarts
			// 
			this.btnDDADataMarts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDDADataMarts.Location = new System.Drawing.Point(256, 136);
			this.btnDDADataMarts.Name = "btnDDADataMarts";
			this.btnDDADataMarts.Size = new System.Drawing.Size(136, 23);
			this.btnDDADataMarts.TabIndex = 41;
			this.btnDDADataMarts.Text = "Test Connection";
			this.btnDDADataMarts.Click += new System.EventHandler(this.btnDDADataMarts_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 116);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(54, 16);
			this.label11.TabIndex = 39;
			this.label11.Text = "Password";
			// 
			// txtUser2
			// 
			this.txtUser2.Location = new System.Drawing.Point(136, 80);
			this.txtUser2.Name = "txtUser2";
			this.txtUser2.Size = new System.Drawing.Size(256, 20);
			this.txtUser2.TabIndex = 38;
			this.txtUser2.Text = "DDADBUser";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(16, 84);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 16);
			this.label12.TabIndex = 37;
			this.label12.Text = "User  name";
			// 
			// txtDBN2
			// 
			this.txtDBN2.Location = new System.Drawing.Point(136, 48);
			this.txtDBN2.Name = "txtDBN2";
			this.txtDBN2.Size = new System.Drawing.Size(256, 20);
			this.txtDBN2.TabIndex = 36;
			this.txtDBN2.Text = "DDA_DATAMARTS";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(16, 52);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 16);
			this.label13.TabIndex = 35;
			this.label13.Text = "Database name";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(16, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(87, 16);
			this.label14.TabIndex = 33;
			this.label14.Text = "Database server";
			// 
			// txtPass2
			// 
			this.txtPass2.Location = new System.Drawing.Point(136, 112);
			this.txtPass2.Name = "txtPass2";
			this.txtPass2.PasswordChar = '*';
			this.txtPass2.Size = new System.Drawing.Size(256, 20);
			this.txtPass2.TabIndex = 40;
			this.txtPass2.Text = "DDADBPassword";
			// 
			// txtServer2
			// 
			this.txtServer2.Location = new System.Drawing.Point(136, 16);
			this.txtServer2.Name = "txtServer2";
			this.txtServer2.Size = new System.Drawing.Size(256, 20);
			this.txtServer2.TabIndex = 34;
			this.txtServer2.Text = "(local)";
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(48, 22);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(344, 20);
			this.txtURL.TabIndex = 4;
			this.txtURL.Text = "http://localhost:80/DDAWebService";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(27, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "URL";
			// 
			// btnTest
			// 
			this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTest.Location = new System.Drawing.Point(256, 122);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(136, 23);
			this.btnTest.TabIndex = 2;
			this.btnTest.Text = "Test Web Service";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Log";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(48, 48);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(344, 72);
			this.txtLog.TabIndex = 0;
			this.txtLog.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(220, 368);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(140, 368);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-8, 352);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 8);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnTest);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtLog);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtURL);
			this.groupBox2.Location = new System.Drawing.Point(9, 200);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(416, 152);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Test Web Service";
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(434, 400);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDA Web Service Tool";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private string GetConfigurationFileName()
		{
			DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(this.GetType().Assembly.Location));
			return Path.Combine(di.Parent.FullName, "Connection.cfg");
		}

		private string GetConfigurationFileName1()
		{
			DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(this.GetType().Assembly.Location));
			return Path.Combine(di.Parent.FullName, "ConnectionDDAStagingArea.cfg");
		}

		private string GetConfigurationFileName2()
		{
			DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(this.GetType().Assembly.Location));
			return Path.Combine(di.Parent.FullName, "ConnectionDDADataMarts.cfg");
		}

		private bool btnSave_Click()
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				ConnectionParam param = new ConnectionParam();
				param.Server = txtServer.Text;
				param.Database = txtDatabase.Text;
				param.Username = txtUsername.Text;
				param.Password = txtPassword.Text;
				if(!param.TestConnection())
					return false;

				ConnectionParam param1 = new ConnectionParam();
				param1.Server = txtServer1.Text;
				param1.Database = txtDBN1.Text;
				param1.Username = txtUser1.Text;
				param1.Password = txtPass1.Text;
				if(!param1.TestConnection())
					return false;

				ConnectionParam param2 = new ConnectionParam();
				param2.Server = txtServer2.Text;
				param2.Database = txtDBN2.Text;
				param2.Username = txtUser2.Text;
				param2.Password = txtPass2.Text;
				//if (!param2.TestConnection())
				//	return false;
			
				param.Save(GetConfigurationFileName());
				param1.Save(GetConfigurationFileName1());
				param2.Save(GetConfigurationFileName2());

				return true;
			}
			catch 
			{
				return false;
			}
		}

		bool serviceok = false;
		bool msg = true;
		private void btnTest_Click(object sender, System.EventArgs e)
		{
			serviceok = btnSave_Click();
			if(!serviceok)
			{
				MessageBox.Show(this, "Connection to database fails, or cannot save connection information into file", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string webservicelink = txtURL.Text + "/" + SiGlaz.Common.DDA.Const.WebServiceConst.Category;
			try
			{
				txtLog.Text  = "Testing....\r\n";
				txtLog.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				WebServiceProxy.CategoryProxy.Category objproxy = new WebServiceProxy.CategoryProxy.Category();
				objproxy.Url = webservicelink;
				objproxy.Timeout = 3 * 60 * 1000;
				objproxy.Discover();
				objproxy.HelloWorld();

				serviceok = objproxy.TestConnection();
				
				if(msg)
				{
					if (serviceok)
						txtLog.Text= txtLog.Text + "Test web service successfully.\r\n\r\n";	
				}
				else
					txtLog.Text= txtLog.Text + "Web service connect to database fail. Please contact with web service administrator to re-check connection information.\r\n\r\n";
			}
			catch(Exception ex)
			{
				serviceok = false;
				txtLog.Text += "Test web service fail: " + ex.Message;
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			try
			{
				ConnectionParam param = new ConnectionParam();
				string cfgFileName = GetConfigurationFileName();

				if ( param.Load(cfgFileName) )
				{
					txtServer.Text = param.Server;
					txtDatabase.Text = param.Database;
					txtUsername.Text = param.Username;
					txtPassword.Text = param.Password;
				}

				string cfgFileName1 = GetConfigurationFileName1();

				if ( param.Load(cfgFileName1) )
				{
					txtServer1.Text = param.Server;
					txtDBN1.Text = param.Database;
					txtUser1.Text = param.Username;
					txtPass1.Text = param.Password;
				}

				string cfgFileName2 = GetConfigurationFileName2();

				if (param.Load(cfgFileName2))
				{
					txtServer2.Text = param.Server;
					txtDBN2.Text = param.Database;
					txtUser2.Text = param.Username;
					txtPass2.Text = param.Password;
				}

				txtURL.Text = string.Format("http://localhost:80/DDAWebService");
				
			}
			catch (System.Exception)
			{
			}
		}

		private void btnTestDDADB_Click(object sender, System.EventArgs e)
		{
			ConnectionParam param = new ConnectionParam();
			param.Server = txtServer.Text;
			param.Database = txtDatabase.Text;
			param.Username = txtUsername.Text;
			param.Password = txtPassword.Text;

			if(param.TestConnection())
				MessageBox.Show(this, "Connection to database DDADB: OK", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show(this, "Connection to database DDADB: fails", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnDDAStagingArea_Click(object sender, System.EventArgs e)
		{
			ConnectionParam param = new ConnectionParam();
			param.Server = txtServer1.Text;
			param.Database = txtDBN1.Text;
			param.Username = txtUser1.Text;
			param.Password = txtPass1.Text;

			if(param.TestConnection())
				MessageBox.Show(this, "Connection to database DDADBStagingArea: OK", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show(this, "Connection to database DDADBStagingArea: fails", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			msg = false;
			btnTest_Click(null,null);

			if(serviceok)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnDDADataMarts_Click(object sender, EventArgs e)
		{
			ConnectionParam param = new ConnectionParam();
			param.Server = txtServer2.Text;
			param.Database = txtDBN2.Text;
			param.Username = txtUser2.Text;
			param.Password = txtPass2.Text;

			if (param.TestConnection())
				MessageBox.Show(this, "Connection to database DDA_DATAMARTS: OK", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show(this, "Connection to database DDA_DATAMARTS: fails", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
