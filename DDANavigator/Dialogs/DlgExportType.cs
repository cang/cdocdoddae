using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Common.DDA;

namespace DDANavigator.Dialogs
{
	public class DlgExportType : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton raDataAndImage;
		private System.Windows.Forms.RadioButton raOnlyData;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region Constructor
		public DlgExportType()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgExportType));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.raOnlyData = new System.Windows.Forms.RadioButton();
			this.raDataAndImage = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raOnlyData);
			this.groupBox1.Controls.Add(this.raDataAndImage);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(4, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// raOnlyData
			// 
			this.raOnlyData.Checked = true;
			this.raOnlyData.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raOnlyData.Location = new System.Drawing.Point(20, 20);
			this.raOnlyData.Name = "raOnlyData";
			this.raOnlyData.TabIndex = 1;
			this.raOnlyData.TabStop = true;
			this.raOnlyData.Text = "Only Data";
			// 
			// raDataAndImage
			// 
			this.raDataAndImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDataAndImage.Location = new System.Drawing.Point(20, 48);
			this.raDataAndImage.Name = "raDataAndImage";
			this.raDataAndImage.TabIndex = 0;
			this.raDataAndImage.Text = "Data and Image";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(27, 84);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(60, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(91, 84);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// DlgExportType
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(178, 113);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgExportType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Export Type";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public ExportType ExportType
		{
			get
			{
				if (raDataAndImage.Checked)
					return ExportType.DataAndImage;

				return ExportType.OnlyData;
			}
		}
		#endregion
	}
}
