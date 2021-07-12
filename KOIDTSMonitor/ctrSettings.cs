using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using SiGlaz.Utility;
using SiGlaz.Common.DDA;

namespace KOIDTSMonitor
{	
	public class ctrSettings : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.NumericUpDown nudEvery;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbSchedule;
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown nudNumDays;
		private System.Windows.Forms.Label label8;
		private SiGlaz.Utility.RijndaelCrypto Crypto = new RijndaelCrypto();
		public ctrSettings()
		{
			InitializeComponent();
			MyInit();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lb = new System.Windows.Forms.Label();
			this.nudEvery = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.cbSchedule = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.nudNumDays = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudEvery)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudNumDays)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.txtDatabase);
			this.groupBox1.Controls.Add(this.txtServer);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(4, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 116);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(112, 88);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(196, 20);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Text = "";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(112, 64);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(196, 20);
			this.txtUserName.TabIndex = 6;
			this.txtUserName.Text = "sa";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(112, 40);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(196, 20);
			this.txtDatabase.TabIndex = 5;
			this.txtDatabase.Text = "DDADB";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(112, 16);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(196, 20);
			this.txtServer.TabIndex = 4;
			this.txtServer.Text = "(local)";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Password:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "User name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Database name:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Database server:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lb);
			this.groupBox2.Controls.Add(this.nudEvery);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbSchedule);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(4, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 48);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Schedule";
			// 
			// lb
			// 
			this.lb.Location = new System.Drawing.Point(252, 16);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(60, 23);
			this.lb.TabIndex = 4;
			this.lb.Text = "hour(s)";
			this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudEvery
			// 
			this.nudEvery.Location = new System.Drawing.Point(196, 20);
			this.nudEvery.Name = "nudEvery";
			this.nudEvery.Size = new System.Drawing.Size(52, 20);
			this.nudEvery.TabIndex = 3;
			this.nudEvery.Value = new System.Decimal(new int[] {
																   2,
																   0,
																   0,
																   0});
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(156, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "every";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbSchedule
			// 
			this.cbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSchedule.Location = new System.Drawing.Point(76, 20);
			this.cbSchedule.Name = "cbSchedule";
			this.cbSchedule.Size = new System.Drawing.Size(76, 21);
			this.cbSchedule.TabIndex = 1;
			this.cbSchedule.TextChanged += new System.EventHandler(this.cbSchedule_TextChanged);
			this.cbSchedule.SelectedIndexChanged += new System.EventHandler(this.cbSchedule_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Schedule:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 172);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(300, 24);
			this.label7.TabIndex = 2;
			this.label7.Text = "Define the number of hours to be used to calculate time to get data";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudNumDays
			// 
			this.nudNumDays.Location = new System.Drawing.Point(80, 200);
			this.nudNumDays.Maximum = new System.Decimal(new int[] {
																	   1410065407,
																	   2,
																	   0,
																	   0});
			this.nudNumDays.Minimum = new System.Decimal(new int[] {
																	   1,
																	   0,
																	   0,
																	   0});
			this.nudNumDays.Name = "nudNumDays";
			this.nudNumDays.Size = new System.Drawing.Size(76, 20);
			this.nudNumDays.TabIndex = 3;
			this.nudNumDays.Value = new System.Decimal(new int[] {
																	 72,
																	 0,
																	 0,
																	 0});
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(160, 199);
			this.label8.Name = "label8";
			this.label8.TabIndex = 4;
			this.label8.Text = "hour(s)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ctrSettings
			// 
			this.Controls.Add(this.label8);
			this.Controls.Add(this.nudNumDays);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ctrSettings";
			this.Size = new System.Drawing.Size(324, 228);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudEvery)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudNumDays)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void MyInit()
		{
			string[] scheduleList = Enum.GetNames(typeof(eSchedule));
			cbSchedule.Items.Clear();
			for (int i = 0; i < scheduleList.Length; i++)
				cbSchedule.Items.Add(scheduleList[i]);
			cbSchedule.SelectedIndex = 1;
		}

		private void cbSchedule_TextChanged(object sender, System.EventArgs e)
		{
			if (cbSchedule.Text == "Hourly")
				lb.Text = "hour(s)";
			else
				lb.Text = "minute(s)";
		}		

		private eSchedule GetScheduleType()
		{
			return (eSchedule) cbSchedule.SelectedIndex;
		}

		private void SetScheduleType(eSchedule ScheduleType)
		{
			cbSchedule.SelectedIndex = Convert.ToInt32(ScheduleType);
		}

		Settings settingParam = null;

		private void cbSchedule_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbSchedule.Text == "Hourly")
				lb.Text = "hour(s)";
			else
				lb.Text = "minute(s)";
		}
	
        public Settings SettingParam
		{
			get
			{	
				settingParam.Database = txtDatabase.Text;
				settingParam.Password = Crypto.Encrypt(txtPassword.Text);
				settingParam.Server = txtServer.Text;
				settingParam.UserName = txtUserName.Text;
				settingParam.Schedule = GetScheduleType();
				settingParam.ScheduleNum = Convert.ToInt32(nudEvery.Value);
				settingParam.NumOfHours = Convert.ToInt32(nudNumDays.Value);
				return settingParam;
			}
			set
			{	
				settingParam = value;
				if (settingParam == null)
					settingParam = new Settings();				
				txtPassword.Text =Crypto.Decrypt(settingParam.Password);
				txtServer.Text = settingParam.Server;
				txtUserName.Text = settingParam.UserName;
				txtDatabase.Text = settingParam.Database;
				nudNumDays.Value = Convert.ToDecimal(settingParam.NumOfHours);
				SetScheduleType(settingParam.Schedule);
				nudEvery.Value = settingParam.ScheduleNum;
			}
		}
	}
}
