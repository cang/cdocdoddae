using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.Common;
using SiGlaz.Utility;

namespace DDARMWinUI
{
	public class DlgAbout : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label lblCompany;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelReleaseDate;
		private System.Windows.Forms.GroupBox groupBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region Constructor & Destructor
		public DlgAbout()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgAbout));
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelReleaseDate = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblCompany = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblProductID = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox4.Location = new System.Drawing.Point(7, 268);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(349, 96);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(328, 72);
			this.label8.TabIndex = 12;
			this.label8.Text = @"Warning: This computer program is protected by copyright law and international treaties.  Unauthorized reproduction or distribution of this program, or any portion of it,  may  result  in  severe  civil  and criminal penalties, and will be prosecuted to the maximum extent possible under the law.";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(280, 380);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(76, 23);
			this.buttonOK.TabIndex = 17;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 180);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(232, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "Copyright © 2007 SiGlaz.  All rights reserved.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 17);
			this.label4.TabIndex = 14;
			this.label4.Text = "Product Details:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 204);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 17);
			this.label1.TabIndex = 13;
			this.label1.Text = "This product is licensed to:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelReleaseDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.labelVersion);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(7, 100);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(349, 76);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// labelReleaseDate
			// 
			this.labelReleaseDate.AutoSize = true;
			this.labelReleaseDate.Location = new System.Drawing.Point(12, 52);
			this.labelReleaseDate.Name = "labelReleaseDate";
			this.labelReleaseDate.Size = new System.Drawing.Size(74, 17);
			this.labelReleaseDate.TabIndex = 4;
			this.labelReleaseDate.Text = "Release Date:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 17);
			this.label6.TabIndex = 2;
			this.label6.Text = "DDA Recipe Manager";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(12, 32);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(70, 17);
			this.labelVersion.TabIndex = 3;
			this.labelVersion.Text = "Version 1.3.1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblCompany);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lblProductID);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(7, 216);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(349, 52);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			// 
			// lblCompany
			// 
			this.lblCompany.Location = new System.Drawing.Point(12, 12);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(124, 16);
			this.lblCompany.TabIndex = 2;
			this.lblCompany.Text = "Micron Technology, Inc";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 17);
			this.label2.TabIndex = 0;
			// 
			// lblProductID
			// 
			this.lblProductID.Location = new System.Drawing.Point(12, 32);
			this.lblProductID.Name = "lblProductID";
			this.lblProductID.Size = new System.Drawing.Size(312, 12);
			this.lblProductID.TabIndex = 1;
			this.lblProductID.Text = "ProductID 95223462-5FEF-476f-A274-F84D606BD7A9";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(362, 80);
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(-4, 364);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(384, 8);
			this.groupBox3.TabIndex = 21;
			this.groupBox3.TabStop = false;
			// 
			// DlgAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(362, 408);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDA Recipe Manager";
			this.Load += new System.EventHandler(this.About_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region Windows Events Handles

		private void About_Load(object sender, System.EventArgs e)
		{
			Configuration.LoadData( System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"App.cfig"));

			System.Reflection.Assembly asm=System.Reflection.Assembly.GetExecutingAssembly();
			labelVersion.Text="Version: " + asm.GetName().Version.ToString();
			labelReleaseDate.Text="Release Date: "+System.IO.File.GetLastWriteTime(Application.ExecutablePath).ToShortDateString();

			RijndaelCrypto crypto = new RijndaelCrypto();
			string txtCom=Configuration.GetValues("LICENSETO","").ToString();
			string txtDSA=Configuration.GetValues("SIGLAZPRODUCTID","").ToString();

			if( txtCom=="" )
				txtCom="Evaluation";
			else
				txtCom=crypto.Decrypt(txtCom);

			if(txtDSA=="")
				txtDSA=GenProductID();
			else
				txtDSA=crypto.Decrypt(txtDSA);

			lblCompany.Text=txtCom;
			lblProductID.Text="ProductID " + txtDSA;
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		public static string GenProductID()
		{
			string sbase="0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ";//abcdefghijklmnopqrstuvxyz";
			//8-4-4-4-12
			Random rnd=new Random();

			string sgen="";
			for(int i=0;i<8;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<12;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];

			return sgen;
		}


		#endregion		
	}
}
