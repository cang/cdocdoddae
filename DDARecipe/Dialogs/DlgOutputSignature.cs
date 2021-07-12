using System.IO;
using System.Globalization;
using System.Data.OleDb;
using System.Data;

using SiGlaz.Common.DDA;

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARecipe.Dialogs
{
	public class DlgOutputSignature : SiGlaz.Recipes.Dialogs.DlgBase
	{
		#region Members

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		//private string _title = "DDAA Signature Category";
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtSig;
		public System.Windows.Forms.CheckBox chkClearResult;
		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
		#endregion
		
		#region Constructor & Destructor
		public DlgOutputSignature()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgOutputSignature));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtSig = new System.Windows.Forms.TextBox();
			this.chkClearResult = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(164, 148);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(84, 148);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-28, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 8);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Output with Signature Name ";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(290, 31);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtSig
			// 
			this.txtSig.Location = new System.Drawing.Point(12, 32);
			this.txtSig.Name = "txtSig";
			this.txtSig.Size = new System.Drawing.Size(276, 20);
			this.txtSig.TabIndex = 13;
			this.txtSig.Text = "";
			// 
			// chkClearResult
			// 
			this.chkClearResult.Location = new System.Drawing.Point(12, 80);
			this.chkClearResult.Name = "chkClearResult";
			this.chkClearResult.Size = new System.Drawing.Size(236, 24);
			this.chkClearResult.TabIndex = 14;
			this.chkClearResult.Text = "Remove all Results after Output";
			// 
			// DlgOutputSignature
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 184);
			this.Controls.Add(this.chkClearResult);
			this.Controls.Add(this.txtSig);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgOutputSignature";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Custimoze Signature Output";
			this.Load += new System.EventHandler(this.DlgOutputSignature_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgOutputSignature_Load(object sender, System.EventArgs e)
		{
			
		}

		public Signature Signature
		{
			get 
			{ 
				try
				{
					WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
					Signature result= cmd.SignatureGetByName(txtSig.Text.Trim());
					if(result==null)
						result = new Signature(-1,0,txtSig.Text.Trim());
					return result;
				}
				catch
				{
					return null;
				}
			}
			set
			{
				if(value!=null)
				{
					txtSig.Text = value.SignatureName;
				}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DlgSelectSignature dlg = new DlgSelectSignature();
			dlg.SingatureName = txtSig.Text;
			if( dlg.ShowDialog(this)==DialogResult.OK)
			{
				txtSig.Text = dlg.SingatureName;
			}
		}

	}
}
