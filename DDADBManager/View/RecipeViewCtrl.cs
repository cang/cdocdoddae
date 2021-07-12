using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for ProcessViewCtrl.
	/// </summary>
	public class ProcessViewCtrl : System.Windows.Forms.UserControl
	{
		protected Process.ProcessBase		_DataSource;
		protected bool					_Selected;
		public System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;

		public event EventHandler		OnBeforeSelected;
		public event EventHandler		OnSelectedChanged;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProcessViewCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

	
		public bool					Selected
		{
			get
			{
				return _Selected;
			}
			set
			{
				bool old = _Selected;
				_Selected = value;
				if(_Selected)
				{
					button1.BackColor = SystemColors.Highlight;
					button1.ForeColor = Color.White;
				}
				else
				{
					button1.BackColor  = SystemColors.Control;
					button1.ForeColor = Color.Black;
				}
				if(old!=_Selected && OnSelectedChanged!=null)
					OnSelectedChanged(this,EventArgs.Empty);
			}

		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(688, 104);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Enabled = false;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(690, 17);
			this.button1.TabIndex = 0;
			this.button1.Text = "Load ETest";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProcessViewCtrl
			// 
			this.Controls.Add(this.panel1);
			this.Name = "ProcessViewCtrl";
			this.Size = new System.Drawing.Size(688, 104);
			this.Load += new System.EventHandler(this.ProcessViewCtrl_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProcessViewCtrl_MouseDown);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ProcessViewCtrl_Load(object sender, System.EventArgs e)
		{
			foreach(Control ctrl in panel1.Controls)
			{
				ctrl.MouseDown+=new MouseEventHandler(ctrl_MouseDown);
			}
		}

		private void HandleBeforeSelect()
		{
			if(OnBeforeSelected!=null)
				OnBeforeSelected(this,EventArgs.Empty);
			Selected = true;
		}

		private void ProcessViewCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			HandleBeforeSelect();
		}

		private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			HandleBeforeSelect();
		}

		private void ctrl_MouseDown(object sender, MouseEventArgs e)
		{
			HandleBeforeSelect();
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}

		public string Caption
		{
			get
			{
				return this.button1.Text;
			}
			set
			{
				this.button1.Text = value;
			}
		}

//		public virtual void ForceAbort()
//		{
//			HandlerChangeStatus();
//		}

		public virtual void Stop()
		{
			HandlerChangeStatus();
		}

		public virtual void Run()
		{
			HandlerChangeStatus();
		}

		public virtual bool CheckInvalidate()
		{
			return false;
		}


		public void HandlerChangeStatus()
		{
			if(OnSelectedChanged!=null)
				OnSelectedChanged(this,EventArgs.Empty);
		}
	
		[Browsable(false)]
		public virtual Process.ProcessBase DataSourceBase
		{
			get
			{
				return _DataSource;
			}
		}

	}
}
