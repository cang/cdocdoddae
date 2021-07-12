using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.Common;
using SiGlaz.Utility;

namespace DDADBManager
{
	/// <summary>
	/// Summary description for AboutSSA.
	/// </summary>
	public class AboutSSA : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblCompany;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.TextBox labelVersion;
		private System.Windows.Forms.TextBox labelReleaseDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AboutSSA()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutSSA));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelReleaseDate = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblProductID = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(362, 80);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(344, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "This product is licensed to: ";
			// 
			// lblCompany
			// 
			this.lblCompany.Location = new System.Drawing.Point(12, 12);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(124, 16);
			this.lblCompany.TabIndex = 0;
			this.lblCompany.Text = "Demo";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Product Details:";
			// 
			// labelVersion
			// 
			this.labelVersion.BackColor = System.Drawing.SystemColors.Control;
			this.labelVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.labelVersion.Location = new System.Drawing.Point(12, 30);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.ReadOnly = true;
			this.labelVersion.Size = new System.Drawing.Size(320, 13);
			this.labelVersion.TabIndex = 3;
			this.labelVersion.Text = "Demo Version";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(208, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "DDADB Manager";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelReleaseDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.labelVersion);
			this.groupBox1.Location = new System.Drawing.Point(4, 104);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 68);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// labelReleaseDate
			// 
			this.labelReleaseDate.BackColor = System.Drawing.SystemColors.Control;
			this.labelReleaseDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.labelReleaseDate.Location = new System.Drawing.Point(12, 48);
			this.labelReleaseDate.Name = "labelReleaseDate";
			this.labelReleaseDate.ReadOnly = true;
			this.labelReleaseDate.Size = new System.Drawing.Size(320, 13);
			this.labelReleaseDate.TabIndex = 4;
			this.labelReleaseDate.Text = "Release Date";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblCompany);
			this.groupBox2.Controls.Add(this.lblProductID);
			this.groupBox2.Location = new System.Drawing.Point(4, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(355, 52);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			// 
			// lblProductID
			// 
			this.lblProductID.AutoSize = true;
			this.lblProductID.Location = new System.Drawing.Point(12, 32);
			this.lblProductID.Name = "lblProductID";
			this.lblProductID.Size = new System.Drawing.Size(285, 16);
			this.lblProductID.TabIndex = 1;
			this.lblProductID.Text = "ProductID B73AAF30-6605-4f68-AA68-B764F99CA14D";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(284, 348);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label7.Location = new System.Drawing.Point(5, 176);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(343, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "Copyright © 2006 SiGlaz.  All rights reserved.";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Location = new System.Drawing.Point(5, 264);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(355, 80);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(339, 63);
			this.label8.TabIndex = 12;
			this.label8.Text = @"Warning: This computer program is protected by copyright law and international treaties.  Unauthorized reproduction or distribution of this program, or any portion of it,  may  result  in  severe  civil  and criminal penalties, and will be prosecuted to the maximum extent possible under the law.";
			this.label8.Click += new System.EventHandler(this.label8_Click_1);
			// 
			// AboutSSA
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(362, 376);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutSSA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About DDADB Manager";
			this.Load += new System.EventHandler(this.AboutSSA_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void label6_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void label8_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label8_Click_1(object sender, System.EventArgs e)
		{
		
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

		private void AboutSSA_Load(object sender, System.EventArgs e)
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

	}
}
