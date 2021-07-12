using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using SiGlaz.Common.DDA;
using SiGlaz.Utility.Wind32;
using SiGlaz.Common;
using SiGlaz.DAL;

using System.Threading;

namespace KOIDTSMonitor
{	
	public class DlgSettings : System.Windows.Forms.Form
	{
		private KOIDTSMonitor.ctrSettings ctrSettings1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private string PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");
		private System.ComponentModel.Container components = null;		
		private string fileName = string.Empty ;
		private System.Windows.Forms.Button btnTestConnect;
		SiGlaz.Utility.RijndaelCrypto Crypto = new SiGlaz.Utility.RijndaelCrypto();
		Settings setting = null;
		public DlgSettings()
		{			
			InitializeComponent();
			MyInit();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ctrSettings1 = new KOIDTSMonitor.ctrSettings();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnTestConnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ctrSettings1
			// 
			this.ctrSettings1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ctrSettings1.Location = new System.Drawing.Point(0, 0);
			this.ctrSettings1.Name = "ctrSettings1";
			this.ctrSettings1.Size = new System.Drawing.Size(328, 224);
			this.ctrSettings1.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new System.Drawing.Point(128, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(208, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnTestConnect
			// 
			this.btnTestConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnTestConnect.Location = new System.Drawing.Point(28, 232);
			this.btnTestConnect.Name = "btnTestConnect";
			this.btnTestConnect.Size = new System.Drawing.Size(96, 23);
			this.btnTestConnect.TabIndex = 3;
			this.btnTestConnect.Text = "&Test connection";
			this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
			// 
			// DlgSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(328, 260);
			this.Controls.Add(this.btnTestConnect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.ctrSettings1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.DlgSettings_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgSettings_Load(object sender, System.EventArgs e)
		{
		
		}
		
		private void MyInit()
		{
			Settings setting = null;	
			try
			{
				if(!Directory.Exists(PersonalFolder))
					Directory.CreateDirectory(PersonalFolder);

				fileName = string.Format("{0}//settings.xml",PersonalFolder);
				if (File.Exists(fileName))
					setting = Settings.Deserialize(fileName);
				ctrSettings1.SettingParam = setting;
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e,"Deserialize");
			}			
		}

		private void UpdateNewAutoID(GeneralCmd cmd, int KoiID)
		{
			if (!CheckIsExistsAutoID(cmd))
				cmd.ExecuteNonQuery("Insert into DDA_ApplicationData([Key],[Value]) values ('KOIID',0)");
			else
			{
				cmd.ExecuteNonQuery(string.Format("Update DDA_ApplicationData set [Value] = {0} where [Key] = 'KOIID'",KoiID));					
			}			
		}
		private bool CheckIsExistsAutoID(GeneralCmd cmd)
		{			
			return cmd.CheckExistSQL("select top 1 1 from DDA_ApplicationData where [Key] = 'KOIID'");		
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				if(!Directory.Exists(PersonalFolder))
					Directory.CreateDirectory(PersonalFolder);

				fileName = string.Format("{0}//settings.xml",PersonalFolder);
				setting = ctrSettings1.SettingParam;
				if (setting == null)
					return;
				
				setting.Serialize(fileName);
				MessageBox.Show("The configuration was saved.","SISKOI DTS",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
				//Khong cho chay nua.
//				string _echeckname = "Global\\SiGlaz_KOIDTS_Client";
//				IntPtr _echeck = IntPtr.Zero;
//
//				_echeck = Kernel32.CreateEvent(IntPtr.Zero,true,false,_echeckname);
//				if(_echeck==IntPtr.Zero)
//				{
//					throw new Exception("Cannot create " + _echeckname + " event");
//				}
//
//				Kernel32.SetEvent(_echeck);
				
				this.Close();
				

			}
			catch (System.Exception ex)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(ex,"Serialize");
			}						
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnTestConnect_Click(object sender, System.EventArgs e)
		{	
			setting = ctrSettings1.SettingParam;
			if (setting == null)
				return;

			ConnectionParam connectParam = new ConnectionParam();
			connectParam.Database = setting.Database;
			connectParam.Password = Crypto.Decrypt(setting.Password);
			connectParam.Server = setting.Server;
			connectParam.Username = setting.UserName;
			GeneralCmd cmd = new GeneralCmd(connectParam);	
			if (cmd.TestConnection())				
				MessageBox.Show("Test connect database successfully.","SISKOI DTS",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
			{
				MessageBox.Show("Test connect database fail.","SISKOI DTS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
		}		
	}
}
