using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using DDANavigator.Controls;

namespace DDANavigator.Dialogs
{
	public class DlgTableLayout : FormBase
	{
		#region Members
		private ctrlTableLayout _ctrlTableLayout;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnDefault;
		private TableLayout _tableLayout = null;
		private FunctionType _type = FunctionType.SingleLayer;
		#endregion
			
		#region Constructor & Destructor
		public DlgTableLayout(TableLayout tableLayout, FunctionType type)
		{
			InitializeComponent();

			_type = type;
			_ctrlTableLayout.Type = type;
			_ctrlTableLayout.GetDefault();
			_tableLayout = tableLayout;
			DisplayTableLayout();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgTableLayout));
			this._ctrlTableLayout = new DDANavigator.Controls.ctrlTableLayout();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDefault = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _ctrlTableLayout
			// 
			this._ctrlTableLayout.Location = new System.Drawing.Point(4, 8);
			this._ctrlTableLayout.Name = "_ctrlTableLayout";
			this._ctrlTableLayout.Size = new System.Drawing.Size(483, 304);
			this._ctrlTableLayout.TabIndex = 0;
			this._ctrlTableLayout.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-12, 312);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(512, 8);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(208, 328);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(288, 328);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnDefault
			// 
			this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDefault.Location = new System.Drawing.Point(128, 328);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.TabIndex = 4;
			this.btnDefault.Text = "&Get Default";
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// DlgTableLayout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(490, 360);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._ctrlTableLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgTableLayout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Table Layout";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DlgTableLayout_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public TableLayout TableLayout
		{
			get { return _tableLayout; }
			set { _tableLayout = value; }
		}
		#endregion

		#region UI Command
		private void DisplayTableLayout()
		{
			_ctrlTableLayout.DisplayInfo(_tableLayout);
		}
		#endregion

		#region Windows Events Handles
		private void DlgTableLayout_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (_ctrlTableLayout.CheckInfo())
				{
					_tableLayout = _ctrlTableLayout.GetTableLayout();
					
					e.Cancel = false;
				}
				else
					e.Cancel = true;
			}
					
		}

		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			_ctrlTableLayout.GetDefault();
		}
		#endregion
	}
}
