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
	public class DlgSelectSignature : SiGlaz.Recipes.Dialogs.DlgBase
	{
		#region Members

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		//private System.ComponentModel.IContainer components;
		//private WebServiceProxy.CategoryProxy.Category _SigService = null;
		//private SiGlaz.DDA.Business.Category  _SigService1 = null;
		//private string _title = "DDA Signature Category";
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader colID;
		private System.Windows.Forms.ColumnHeader colName;
		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
		#endregion
		
		#region Constructor & Destructor
		public DlgSelectSignature()
		{
			InitializeComponent();
			
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                //if(components != null)
                //{
                //    components.Dispose();
                //}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgSelectSignature));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.colID = new System.Windows.Forms.ColumnHeader();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(252, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(168, 376);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-28, 360);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 8);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colID,
																						this.colName});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(580, 356);
			this.listView1.TabIndex = 10;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// colID
			// 
			this.colID.Text = "ID";
			this.colID.Width = 148;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 337;
			// 
			// DlgSelectSignature
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(494, 408);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgSelectSignature";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Signature";
			this.Load += new System.EventHandler(this.DlgOutputSignature_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgOutputSignature_Load(object sender, System.EventArgs e)
		{
			DisplaySignatureCategoryList();
		}

		public string SingatureName
		{
			get 
			{ 
				if(listView1.SelectedItems!=null && listView1.SelectedItems.Count>0)
					return listView1.SelectedItems[0].SubItems[1].Text;
				else
					return string.Empty;
			}
			set
			{
				foreach(ListViewItem item in listView1.Items)
				{
					if(item.SubItems[1].Text == value)
					{
						item.Selected = true;
						break;
					}
				}
			}
		}

		public void DisplaySignatureCategoryList()
		{
			listView1.Items.Clear();

			try
			{

				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
	
				SiGlaz.Common.DDA.Result.SignatureListResult dsResult = cmd.SignatureList();
				if(dsResult.Code== ErrorCode.OK && dsResult.signature!=null)
				{
					foreach(SiGlaz.Common.DDA.Signature sig in dsResult.signature)
					{
						if(sig.SCKey<=1) continue;

						ListViewItem item = new ListViewItem(sig.SignatureID.ToString());
						item.Tag = sig.SCKey;
						item.SubItems.Add(sig.SignatureName);
						listView1.Items.Add(item);
					}
				}
			}
			catch
			{
				MessageBox.Show(this,"Cannot connect to database",Application.ProductName);
				Close();
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
		
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
