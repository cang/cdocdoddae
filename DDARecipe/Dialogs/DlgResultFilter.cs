using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgResultFilter.
	/// </summary>
	public class DlgResultFilter : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radRemove;
		private System.Windows.Forms.RadioButton radKeep;
		public System.Windows.Forms.CheckBox chkClearResult;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgResultFilter()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radRemove = new System.Windows.Forms.RadioButton();
			this.radKeep = new System.Windows.Forms.RadioButton();
			this.chkClearResult = new System.Windows.Forms.CheckBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-256, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(900, 4);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(163, 140);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 23);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(91, 140);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 23);
			this.buttonOK.TabIndex = 11;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radRemove);
			this.groupBox3.Controls.Add(this.radKeep);
			this.groupBox3.Location = new System.Drawing.Point(4, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(472, 72);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Result Filter Options";
			// 
			// radRemove
			// 
			this.radRemove.Location = new System.Drawing.Point(8, 44);
			this.radRemove.Name = "radRemove";
			this.radRemove.Size = new System.Drawing.Size(220, 23);
			this.radRemove.TabIndex = 2;
			this.radRemove.Text = "Remove";
			// 
			// radKeep
			// 
			this.radKeep.Checked = true;
			this.radKeep.Location = new System.Drawing.Point(8, 20);
			this.radKeep.Name = "radKeep";
			this.radKeep.Size = new System.Drawing.Size(220, 23);
			this.radKeep.TabIndex = 1;
			this.radKeep.TabStop = true;
			this.radKeep.Text = "Keep";
			// 
			// chkClearResult
			// 
			this.chkClearResult.Location = new System.Drawing.Point(8, 88);
			this.chkClearResult.Name = "chkClearResult";
			this.chkClearResult.Size = new System.Drawing.Size(236, 24);
			this.chkClearResult.TabIndex = 15;
			this.chkClearResult.Text = "Remove all Results after Filter";
			// 
			// DlgResultFilter
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(318, 172);
			this.Controls.Add(this.chkClearResult);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Name = "DlgResultFilter";
			this.Text = "Result Filter Setting";
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
		
		}

		public SiGlaz.Common.DDA.eOutputType Param
		{
			get
			{
				return radKeep.Checked?SiGlaz.Common.DDA.eOutputType.Keep:SiGlaz.Common.DDA.eOutputType.Remove;
			}
			set
			{
				radKeep.Checked = value == SiGlaz.Common.DDA.eOutputType.Keep;
				radRemove.Checked = value == SiGlaz.Common.DDA.eOutputType.Remove;
			}
		}
	}
}
