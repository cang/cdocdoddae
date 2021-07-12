using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Management;

namespace DataInstaller
{
	/// <summary>
	/// Summary description for DDAServiceOptions.
	/// </summary>
	public class DDAServiceOptions : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton raLocalSystem;
		private System.Windows.Forms.CheckBox chkInteractDestop;
		private System.Windows.Forms.RadioButton raLogon;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.TextBox txtPass1;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.ComboBox cboSerciceType;
		private System.Windows.Forms.Label lblServiceName;
		private System.Windows.Forms.Button btnBrowser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DDAServiceOptions()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DDAServiceOptions));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cboSerciceType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblServiceName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnBrowser = new System.Windows.Forms.Button();
			this.txtPass1 = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.raLogon = new System.Windows.Forms.RadioButton();
			this.chkInteractDestop = new System.Windows.Forms.CheckBox();
			this.raLocalSystem = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(4, 4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(460, 208);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cboSerciceType);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.txtPath);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.txtDisplayName);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.lblServiceName);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(452, 182);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// cboSerciceType
			// 
			this.cboSerciceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSerciceType.Items.AddRange(new object[] {
																"Automatic",
																"Manual",
																"Disabled"});
			this.cboSerciceType.Location = new System.Drawing.Point(116, 128);
			this.cboSerciceType.Name = "cboSerciceType";
			this.cboSerciceType.Size = new System.Drawing.Size(324, 21);
			this.cboSerciceType.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(12, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Startup type:";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(16, 92);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(420, 20);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Path to executable:";
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(116, 38);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(320, 20);
			this.txtDisplayName.TabIndex = 0;
			this.txtDisplayName.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(12, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Display  Name:";
			// 
			// lblServiceName
			// 
			this.lblServiceName.AutoSize = true;
			this.lblServiceName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblServiceName.Location = new System.Drawing.Point(116, 12);
			this.lblServiceName.Name = "lblServiceName";
			this.lblServiceName.Size = new System.Drawing.Size(72, 16);
			this.lblServiceName.TabIndex = 1;
			this.lblServiceName.Text = "DDAServices";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Service Name:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnBrowser);
			this.tabPage2.Controls.Add(this.txtPass1);
			this.tabPage2.Controls.Add(this.txtPass);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.txtUserName);
			this.tabPage2.Controls.Add(this.raLogon);
			this.tabPage2.Controls.Add(this.chkInteractDestop);
			this.tabPage2.Controls.Add(this.raLocalSystem);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(452, 182);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Log On";
			this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// btnBrowser
			// 
			this.btnBrowser.Enabled = false;
			this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowser.Location = new System.Drawing.Point(360, 87);
			this.btnBrowser.Name = "btnBrowser";
			this.btnBrowser.TabIndex = 9;
			this.btnBrowser.Text = "&Browser...";
			this.btnBrowser.Visible = false;
			this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
			// 
			// txtPass1
			// 
			this.txtPass1.Enabled = false;
			this.txtPass1.Location = new System.Drawing.Point(156, 140);
			this.txtPass1.Name = "txtPass1";
			this.txtPass1.PasswordChar = '*';
			this.txtPass1.Size = new System.Drawing.Size(200, 20);
			this.txtPass1.TabIndex = 8;
			this.txtPass1.Text = "";
			// 
			// txtPass
			// 
			this.txtPass.Enabled = false;
			this.txtPass.Location = new System.Drawing.Point(156, 116);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(200, 20);
			this.txtPass.TabIndex = 6;
			this.txtPass.Text = "";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(28, 144);
			this.label8.Name = "label8";
			this.label8.TabIndex = 7;
			this.label8.Text = "&Confirm Password:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Location = new System.Drawing.Point(28, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 16);
			this.label7.TabIndex = 5;
			this.label7.Text = "&Password:";
			// 
			// txtUserName
			// 
			this.txtUserName.Enabled = false;
			this.txtUserName.Location = new System.Drawing.Point(156, 88);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(200, 20);
			this.txtUserName.TabIndex = 4;
			this.txtUserName.Text = "";
			// 
			// raLogon
			// 
			this.raLogon.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLogon.Location = new System.Drawing.Point(12, 88);
			this.raLogon.Name = "raLogon";
			this.raLogon.Size = new System.Drawing.Size(112, 24);
			this.raLogon.TabIndex = 3;
			this.raLogon.Text = "&This Account:";
			this.raLogon.CheckedChanged += new System.EventHandler(this.raLogon_CheckedChanged);
			// 
			// chkInteractDestop
			// 
			this.chkInteractDestop.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkInteractDestop.Location = new System.Drawing.Point(28, 56);
			this.chkInteractDestop.Name = "chkInteractDestop";
			this.chkInteractDestop.Size = new System.Drawing.Size(244, 24);
			this.chkInteractDestop.TabIndex = 2;
			this.chkInteractDestop.Text = "Allow Service to interact with Desktop";
			// 
			// raLocalSystem
			// 
			this.raLocalSystem.Checked = true;
			this.raLocalSystem.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLocalSystem.Location = new System.Drawing.Point(12, 32);
			this.raLocalSystem.Name = "raLocalSystem";
			this.raLocalSystem.Size = new System.Drawing.Size(208, 24);
			this.raLocalSystem.TabIndex = 1;
			this.raLocalSystem.TabStop = true;
			this.raLocalSystem.Text = "&Local System Account";
			this.raLocalSystem.CheckedChanged += new System.EventHandler(this.raLocalSystem_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Log on as:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(300, 228);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(220, 228);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnApply
			// 
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnApply.Location = new System.Drawing.Point(380, 228);
			this.btnApply.Name = "btnApply";
			this.btnApply.TabIndex = 3;
			this.btnApply.Text = "&Apply";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// DDAServiceOptions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(470, 264);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DDAServiceOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDA Services Options";
			this.Load += new System.EventHandler(this.DDAServiceOptions_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tabPage2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void UpdateGUI()
		{
			chkInteractDestop.Enabled = raLocalSystem.Checked;
			txtUserName.Enabled = txtPass.Enabled = txtPass1.Enabled = btnBrowser.Enabled = raLogon.Checked;
		}

		private void raLocalSystem_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateGUI();

		}

		private void raLogon_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateGUI();
		}

		private void DDAServiceOptions_Load(object sender, System.EventArgs e)
		{
			try
			{
				string objPath = string.Format("Win32_Service.Name='{0}'", lblServiceName.Text);
				using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
				{
					txtDisplayName.Text = service["DisplayName"].ToString();

					string starmode = service["StartMode"].ToString();
					for(int i=0;i<cboSerciceType.Items.Count;i++)
					{
						if(starmode.Substring(0,4)==cboSerciceType.Items[i].ToString().Substring(0,4))
						{
							cboSerciceType.SelectedIndex = i;
							break;
						}
					}

					txtPath.Text =  service["PathName"].ToString();

					string StartName = service["StartName"].ToString(); 
					if( StartName == "LocalSystem" )
					{
						raLocalSystem.Checked = true;
						chkInteractDestop.Checked = (bool)service["DesktopInteract"];
					}
					else
					{
						raLogon.Checked = true;
						txtUserName.Text = StartName;
					}
				}
			}
			catch
			{
				Close();
			}
		}

		public static bool IsDisable
		{
			get
			{
				try
				{
					string objPath = string.Format("Win32_Service.Name='{0}'", "DDAServices");
					using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
					{
						string starmode = service["StartMode"].ToString();
						return starmode == "Disabled";
					}
				}
				catch
				{
					return true;
				}
			}
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			ApplySetting();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(ApplySetting())
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private bool Check()
		{
			if(raLogon.Checked)
			{
				if(txtUserName.Text.Trim() == string.Empty)
				{
					MessageBox.Show("User name cannot be null",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return false;
				}
				if(txtPass.Text.Trim()!=txtPass1.Text.Trim())
				{
					MessageBox.Show("Password mismatch",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return false;
				}
			}
			return true;
		}

		private bool ApplySetting()
		{
			if(!Check())
				return false;

			try
			{

				string objPath = string.Format("Win32_Service.Name='{0}'", lblServiceName.Text);
				using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
				{
					object[] wmiParams = new object[11];

					wmiParams[0] = txtDisplayName.Text.Trim();
					wmiParams[4] = cboSerciceType.Text.Trim();
					wmiParams[5] = chkInteractDestop.Checked && raLocalSystem.Checked;

					if(raLocalSystem.Checked)
					{
						wmiParams[6] = "LocalSystem";
						wmiParams[7] = string.Empty;
					}
					else
					{
						wmiParams[6] = txtUserName.Text.Trim();
						wmiParams[7] = txtPass.Text.Trim();
					}

					uint result = (uint)service.InvokeMethod("Change", wmiParams);

					string [] lsmsg = new string[]{
						"Success",
						"Not Supported",
						"Access Denied",
						"Dependent Services Running",
						"Invalid Service Control",
						"Service Cannot Accept Control",
						"Service Not Active",
						"Service Request Timeout",
						"Unknown Failure",
						"Path Not Found",
						"Service Already Running",
						"Service Database Locked",
						"Service Dependency Deleted",
						"Service Dependency Failure",
						"Service Disabled",
						"Service Logon Failure",
						"Service Marked For Deletion",
						"Service No Thread",
						"Status Circular Dependency",
						"Status Duplicate Name",
						"Status Invalid Name",
						"Status Invalid Parameter",
						"Status Invalid Service Account",
						"Status Service Exists",
						"Service Already Paused"
		
												  };

					if(result>=0 && result<lsmsg.Length )
					{
						MessageBox.Show(this,lsmsg[result],"DDA Setup");
					}

					return result ==0;

				}
				
			}
			catch
			{
				return false;
			}
		}

		private void btnBrowser_Click(object sender, System.EventArgs e)
		{
//			// grab the helper object
//			ObjectPickerHelper.CADObjectPicker picker = new ObjectPickerHelper.CADObjectPickerClass();
//
//			// show the dialog
//			picker.InvokeDialog(this.Handle.ToInt32());
//			
//			// somehow C# seems more picky with the types than VB, so you have to use an intermediate var.
//			ObjectPickerHelper.CADObjectColl coll = (ObjectPickerHelper.CADObjectColl)picker.ADObjectsColl;
//
//			// and walk the collection
//			int i = 0;
//			foreach (ObjectPickerHelper.CADObjectInfo InfoObject in coll)
//			{
//
//				//ListViewItem theItem = new ListViewItem(InfoObject.Name, i);//Do Van Cang
//				//theItem.SubItems.Add(InfoObject.Class);//user
//				//theItem.SubItems.Add(InfoObject.ADPath);//WINNT://TSISYS/dvcang
//				//theItem.SubItems.Add(InfoObject.UPN);//dvcang@tsisys.com.vn
//				//listViewResults.Items.Add(theItem);
//
//				txtUserName.Text = InfoObject.UPN;
//
//				i++;
//				break;
//			}
		}
	}
}
