using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDANavigator.Dialogs
{
	public class DlgStatus : FormBase
	{
		#region Members
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox picWait;
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor & Destructor
		public DlgStatus()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgStatus));
			this.label1 = new System.Windows.Forms.Label();
			this.picWait = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(56, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please Wait...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picWait
			// 
			this.picWait.Image = ((System.Drawing.Image)(resources.GetObject("picWait.Image")));
			this.picWait.Location = new System.Drawing.Point(4, 4);
			this.picWait.Name = "picWait";
			this.picWait.Size = new System.Drawing.Size(48, 48);
			this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picWait.TabIndex = 1;
			this.picWait.TabStop = false;
			// 
			// DlgStatus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(220, 56);
			this.Controls.Add(this.picWait);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgStatus";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Status";
			this.ResumeLayout(false);

		}
		#endregion

		#region Windows Events Handles
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);			
		}
		#endregion
	}
}
