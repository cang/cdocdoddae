using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.DAL;

namespace DDADBManager.Dialog
{
	/// <summary>
	/// Summary description for ConnectionSettingDlg.
	/// </summary>
	public class ConnectionSettingDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnTestDDADB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConnectionSettingDlg()
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
			this.btnTestDDADB = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// btnTestDDADB
			// 
			this.btnTestDDADB.Location = new System.Drawing.Point(184, 128);
			this.btnTestDDADB.Name = "btnTestDDADB";
			this.btnTestDDADB.Size = new System.Drawing.Size(152, 23);
			this.btnTestDDADB.TabIndex = 33;
			this.btnTestDDADB.Text = "Test Connection";
			this.btnTestDDADB.Click += new System.EventHandler(this.btnTestDDADB_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 16);
			this.label4.TabIndex = 31;
			this.label4.Text = "Password";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(128, 72);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(208, 20);
			this.txtUsername.TabIndex = 30;
			this.txtUsername.Text = "DDADBUser";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 16);
			this.label3.TabIndex = 29;
			this.label3.Text = "User  name";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(128, 40);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(208, 20);
			this.txtDatabase.TabIndex = 28;
			this.txtDatabase.Text = "DDADB";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Database name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 16);
			this.label1.TabIndex = 25;
			this.label1.Text = "Database server";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(128, 104);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(208, 20);
			this.txtPassword.TabIndex = 32;
			this.txtPassword.Text = "DDADBPassword";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(128, 8);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(208, 20);
			this.txtServer.TabIndex = 26;
			this.txtServer.Text = "(local)";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(180, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 36;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(100, 184);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 35;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-40, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 8);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			// 
			// ConnectionSettingDlg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(354, 216);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnTestDDADB);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDatabase);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectionSettingDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connection Setting";
			this.Load += new System.EventHandler(this.ConnectionSettingDlg_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ConnectionSettingDlg_Load(object sender, System.EventArgs e)
		{
		
		}

		private bool test(bool skipmsg)
		{
			Cursor.Current = Cursors.WaitCursor;

			ConnectionParam param = new ConnectionParam();

			param.Server = txtServer.Text;
			param.Database = txtDatabase.Text;
			param.Username = txtUsername.Text;
			param.Password = txtPassword.Text;

			if(param.TestConnection())
			{
				if(!skipmsg)
					MessageBox.Show(this, "Connection to database: OK", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

				return true;
			}
			else
			{
				MessageBox.Show(this, "Connection to database: fails", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void btnTestDDADB_Click(object sender, System.EventArgs e)
		{
			test(false);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(test(true))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}	

		public SiGlaz.DAL.ConnectionParam DataSource
		{
			get
			{
				ConnectionParam param = new ConnectionParam();

				param.Server = txtServer.Text;
				param.Database = txtDatabase.Text;
				param.Username = txtUsername.Text;
				param.Password = txtPassword.Text;

				return param;
			}
			set
			{
				txtServer.Text = value.Server;
				txtDatabase.Text = value.Database;
				txtUsername.Text = value.Username;
				txtPassword.Text = value.Password;
			}
		}
	}
}
