using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using SiGlaz.Common.DDA;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for WebServiceConfigDlg.
	/// </summary>
	public class DlgWebServiceConfiguration : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtWebSerciceLink;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label lblProcess;
		private System.Windows.Forms.Panel panelWebService;
		private System.Windows.Forms.RadioButton raBywebservice;
		private System.Windows.Forms.RadioButton rdDirectly;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgWebServiceConfiguration()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgWebServiceConfiguration));
			this.label1 = new System.Windows.Forms.Label();
			this.txtWebSerciceLink = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.lblProcess = new System.Windows.Forms.Label();
			this.panelWebService = new System.Windows.Forms.Panel();
			this.raBywebservice = new System.Windows.Forms.RadioButton();
			this.rdDirectly = new System.Windows.Forms.RadioButton();
			this.panel = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panelWebService.SuspendLayout();
			this.panel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Web Service Link";
			// 
			// txtWebSerciceLink
			// 
			this.txtWebSerciceLink.Location = new System.Drawing.Point(4, 24);
			this.txtWebSerciceLink.Name = "txtWebSerciceLink";
			this.txtWebSerciceLink.Size = new System.Drawing.Size(440, 20);
			this.txtWebSerciceLink.TabIndex = 5;
			this.txtWebSerciceLink.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-72, 184);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(848, 8);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(296, 200);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(376, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// btnTest
			// 
			this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTest.Location = new System.Drawing.Point(16, 200);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(144, 23);
			this.btnTest.TabIndex = 6;
			this.btnTest.Text = "&Test web service";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.ForeColor = System.Drawing.Color.Blue;
			this.lblProcess.Location = new System.Drawing.Point(172, 204);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(0, 16);
			this.lblProcess.TabIndex = 9;
			this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelWebService
			// 
			this.panelWebService.Controls.Add(this.label1);
			this.panelWebService.Controls.Add(this.txtWebSerciceLink);
			this.panelWebService.Location = new System.Drawing.Point(4, 40);
			this.panelWebService.Name = "panelWebService";
			this.panelWebService.Size = new System.Drawing.Size(600, 140);
			this.panelWebService.TabIndex = 10;
			// 
			// raBywebservice
			// 
			this.raBywebservice.Checked = true;
			this.raBywebservice.Location = new System.Drawing.Point(100, 8);
			this.raBywebservice.Name = "raBywebservice";
			this.raBywebservice.TabIndex = 11;
			this.raBywebservice.TabStop = true;
			this.raBywebservice.Text = "Webservice";
			this.raBywebservice.CheckedChanged += new System.EventHandler(this.raBywebservice_CheckedChanged);
			// 
			// rdDirectly
			// 
			this.rdDirectly.Location = new System.Drawing.Point(204, 8);
			this.rdDirectly.Name = "rdDirectly";
			this.rdDirectly.Size = new System.Drawing.Size(132, 24);
			this.rdDirectly.TabIndex = 12;
			this.rdDirectly.Text = "Directly Database";
			this.rdDirectly.CheckedChanged += new System.EventHandler(this.rdDirectly_CheckedChanged);
			// 
			// panel
			// 
			this.panel.Controls.Add(this.groupBox2);
			this.panel.Location = new System.Drawing.Point(4, 40);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(776, 140);
			this.panel.TabIndex = 13;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtServer);
			this.groupBox2.Controls.Add(this.txtPassword);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtDatabase);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtUsername);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(0, -4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(452, 144);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(128, 16);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(208, 20);
			this.txtServer.TabIndex = 25;
			this.txtServer.Text = "(local)";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(128, 112);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(208, 20);
			this.txtPassword.TabIndex = 31;
			this.txtPassword.Text = "DDADBPassword";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 16);
			this.label5.TabIndex = 24;
			this.label5.Text = "Database server";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "Database name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(128, 48);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(208, 20);
			this.txtDatabase.TabIndex = 27;
			this.txtDatabase.Text = "DDADB";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 16);
			this.label3.TabIndex = 28;
			this.label3.Text = "User  name";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(128, 80);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(208, 20);
			this.txtUsername.TabIndex = 29;
			this.txtUsername.Text = "DDADBUser";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Password";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Connection to:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DlgWebServiceConfiguration
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(462, 231);
			this.Controls.Add(this.panelWebService);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.rdDirectly);
			this.Controls.Add(this.raBywebservice);
			this.Controls.Add(this.lblProcess);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgWebServiceConfiguration";
			this.Text = "Connection Configuration";
			this.Load += new System.EventHandler(this.WebServiceConfigDlg_Load);
			this.panelWebService.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Members
		bool serviceok = false;
		#endregion

		#region Test Webservice
		private void TestWebService()
		{			
			string webservicelink = txtWebSerciceLink.Text.Trim();

			WebServiceProxy.WebProxyFactory.eMessageType oldstatus = 
			WebServiceProxy.WebProxyFactory.MessageType;

			try
			{
				lblProcess.Text  = "Testing....";
				lblProcess.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.None;

				WebServiceProxy.CategoryProxy.Category proxy = new WebServiceProxy.CategoryProxy.Category();
				proxy.Url = string.Format("{0}/{1}",txtWebSerciceLink.Text,SiGlaz.Common.DDA.Const.WebServiceConst.Category);
				proxy.HelloWorld();

				serviceok = proxy.TestConnection();

				if (serviceok)
				{
					if(!okandreturn)
						MessageBox.Show("Test web service successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);	
				}
				else
					MessageBox.Show("Web service connect to database fail\r\nPlease contact with web service administrator to re-check connection information.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

				lblProcess.Text  = string.Empty;
			}
			catch(Exception ex)
			{			
				serviceok = false;
				MessageBox.Show(string.Format("Test web service fail: {0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				WebServiceProxy.WebProxyFactory.MessageType = oldstatus;
			}

		}

		public string WebServiceLink
		{
			get
			{
				return txtWebSerciceLink.Text;
			}
			set
			{
				txtWebSerciceLink.Text = value;
			}
		}

		#endregion
		
		#region Test Directly

		private void TestDirectly()
		{			
			try
			{
				SiGlaz.DAL.ConnectionParam _connnect = new SiGlaz.DAL.ConnectionParam();
				_connnect.Server = txtServer.Text;
				_connnect.Database = txtDatabase.Text;
				_connnect.Username = txtUsername.Text;
				_connnect.Password = txtPassword.Text;
				serviceok = _connnect.TestConnection();

				if (serviceok )
				{
					if(!okandreturn)
						MessageBox.Show("Testing Connection to database is successful.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);	
				}
				else
					MessageBox.Show("Testing Connection to Database fails.\r\nPlease re-check connection information.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (System.Exception ex)
			{	
				serviceok=false;
				MessageBox.Show(string.Format("Testing Connection to Database fails: {0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	
		}


		private string GetConfigurationFileName()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Connection.cfg");
		}

		#endregion

		#region Windows EventHandler

		bool okandreturn = false;
		private void btnTest_Click(object sender, System.EventArgs e)
		{
			if(rdDirectly.Checked)
				TestDirectly();
			else
				TestWebService();

			okandreturn = false;
		}

		public virtual void btnOK_Click(object sender, System.EventArgs e)
		{
			okandreturn = true;

			btnTest_Click(null,EventArgs.Empty);

			if(rdDirectly.Checked)
			{
				if(serviceok)
				{
					try
					{
						SiGlaz.DAL.ConnectionParam param = new SiGlaz.DAL.ConnectionParam();
						param.Server = txtServer.Text;
						param.Database = txtDatabase.Text;
						param.Username = txtUsername.Text;
						param.Password = txtPassword.Text;
			
						string cfgFileName = GetConfigurationFileName();
						param.Save(cfgFileName);	

						AppData.Data.UseWebService = raBywebservice.Checked;

						//Save config to file 
						AppData.Data.SaveApplicationData(DDAExternalData.AppDataPath);

						DDAExternalData.SaveApplicationData();
					
						DialogResult = DialogResult.OK;
						Close();
					}
					catch (System.Exception ex)
					{
						MessageBox.Show(this, string.Format("Cannot save the configuration.\r\nError : {0}", ex.ToString()), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
					return;
			}
			else
			{
				if(serviceok)
				{
					try
					{
						AppData.Data.WebServiceList[WebServicetypeType.Root]= txtWebSerciceLink.Text;
						AppData.Data.UseWebService = raBywebservice.Checked;

						//Save config to file 
						AppData.Data.SaveApplicationData(DDAExternalData.AppDataPath);

						DialogResult = DialogResult.OK;
						Close();
					}
					catch (System.Exception ex)
					{
						MessageBox.Show(this, string.Format("Cannot save the configuration.\r\nError : {0}", ex.ToString()), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
					return;
			}
		}


		private void WebServiceConfigDlg_Load(object sender, System.EventArgs e)
		{
			//Load webservice link 
			txtWebSerciceLink.Text = AppData.Data.WebServiceList[WebServicetypeType.Root];

			raBywebservice.Checked = AppData.Data.UseWebService;
			rdDirectly.Checked = !raBywebservice.Checked;

			// Load ConnectionParam			
			SiGlaz.DAL.ConnectionParam param = new SiGlaz.DAL.ConnectionParam();
			string cfgFileName = GetConfigurationFileName();
			if(File.Exists(cfgFileName))
			{
				if ( param.Load(cfgFileName) )
				{
					txtServer.Text = param.Server;
					txtDatabase.Text = param.Database;
					txtUsername.Text = param.Username;
					txtPassword.Text = param.Password;
				}
			}			
		}

		private void raBywebservice_CheckedChanged(object sender, System.EventArgs e)
		{
			if(raBywebservice.Checked)
			{
				panelWebService.Visible=true;
				btnTest.Text = "&Test web service";
			}
			else
			{
				panelWebService.Visible=false;				
				btnTest.Text = "&Test connect Database";
			}
		}

		private void rdDirectly_CheckedChanged(object sender, System.EventArgs e)
		{
			if(raBywebservice.Checked)
				panelWebService.Visible=true;
			else
				panelWebService.Visible=false;	
		}

		#endregion
		
		
	}
}
