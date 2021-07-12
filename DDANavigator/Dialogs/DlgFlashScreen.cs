using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDANavigator.Dialogs
{
	public class DlgFlashScreen : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		private int	secondwait=0;
		private int	limitwait=0;
		public event EventHandler UserClose;

		#endregion
		
		#region Constructor & Destructor
		public DlgFlashScreen()
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgFlashScreen));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// DlgFlashScreen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(500, 300);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgFlashScreen";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DlgFlashScreen";
			this.TopMost = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DlgFlashScreen_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DlgFlashScreen_MouseDown);
			this.Load += new System.EventHandler(this.DlgFlashScreen_Load);

		}
		#endregion

		#region Windows Events Handles
		private void DlgFlashScreen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(UserClose!=null)
				UserClose(null,EventArgs.Empty);

			this.Close();		
		}

		private void DlgFlashScreen_Load(object sender, System.EventArgs e)
		{
			try
			{
				limitwait=10;
				timer1.Enabled=true;
			}
			catch{}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{	
			if(++secondwait>=limitwait) 
			{
				if(UserClose!=null)
					UserClose(null,EventArgs.Empty);
				Close();
			}
		}

		private void DlgFlashScreen_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(UserClose!=null)
				UserClose(null,EventArgs.Empty);
			Close();

		}
		#endregion
	}
}
