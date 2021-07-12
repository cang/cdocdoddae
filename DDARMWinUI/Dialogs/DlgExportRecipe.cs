using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARMWinUI.Dialogs
{
	public class DlgExportRecipe : System.Windows.Forms.Form
	{
		#region Members
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton raAllRecipes;
		private System.Windows.Forms.RadioButton raSelectedRecipes;
		#endregion
		
		#region Constructor & Destructor
		public DlgExportRecipe()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgExportRecipe));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.raAllRecipes = new System.Windows.Forms.RadioButton();
			this.raSelectedRecipes = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-44, 60);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(508, 8);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(20, 76);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(100, 76);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// raAllRecipes
			// 
			this.raAllRecipes.Checked = true;
			this.raAllRecipes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raAllRecipes.Location = new System.Drawing.Point(16, 8);
			this.raAllRecipes.Name = "raAllRecipes";
			this.raAllRecipes.TabIndex = 3;
			this.raAllRecipes.Text = "All Recipes";
			// 
			// raSelectedRecipes
			// 
			this.raSelectedRecipes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raSelectedRecipes.Location = new System.Drawing.Point(16, 32);
			this.raSelectedRecipes.Name = "raSelectedRecipes";
			this.raSelectedRecipes.Size = new System.Drawing.Size(148, 24);
			this.raSelectedRecipes.TabIndex = 4;
			this.raSelectedRecipes.Text = "Selected Recipe(s)";
			// 
			// DlgExportRecipe
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(194, 107);
			this.Controls.Add(this.raSelectedRecipes);
			this.Controls.Add(this.raAllRecipes);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgExportRecipe";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Export Recipe";
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public bool IsAllRecipes
		{
			get{ return raAllRecipes.Checked; }
		}
		#endregion
	}
}
