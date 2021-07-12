using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.Utility;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgDiskTypeConfiguration.
	/// </summary>
	public class DlgGrade : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader colGrade;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colSignatureList;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbAdd;
		private System.Windows.Forms.ToolBarButton tbbModify;
		private System.Windows.Forms.ToolBarButton tbbDelete;
		private System.Windows.Forms.ToolBarButton tbbDeleteAll;
		private System.ComponentModel.IContainer components;
		private ListViewColumnSorter _lvwColumnSorter = new ListViewColumnSorter();

		public DlgGrade()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			listView1.ListViewItemSorter = _lvwColumnSorter;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgGrade));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.colGrade = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.colSignatureList = new System.Windows.Forms.ColumnHeader();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbAdd = new System.Windows.Forms.ToolBarButton();
			this.tbbModify = new System.Windows.Forms.ToolBarButton();
			this.tbbDelete = new System.Windows.Forms.ToolBarButton();
			this.tbbDeleteAll = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-160, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1160, 8);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 464);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(754, 8);
			this.panel1.TabIndex = 14;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(754, 464);
			this.panel2.TabIndex = 15;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.listView1);
			this.panel4.Controls.Add(this.toolBar1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(754, 464);
			this.panel4.TabIndex = 1;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colGrade,
																						this.colDescription,
																						this.colSignatureList});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 28);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(754, 436);
			this.listView1.TabIndex = 16;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.ContextMenuChanged += new System.EventHandler(this.listView1_ContextMenuChanged);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// colGrade
			// 
			this.colGrade.Text = "DDAGrade";
			this.colGrade.Width = 75;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 171;
			// 
			// colSignatureList
			// 
			this.colSignatureList.Text = "Signature List";
			this.colSignatureList.Width = 500;
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbAdd,
																						this.tbbModify,
																						this.tbbDelete,
																						this.tbbDeleteAll});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(754, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAdd
			// 
			this.tbbAdd.ImageIndex = 0;
			this.tbbAdd.ToolTipText = "Add";
			// 
			// tbbModify
			// 
			this.tbbModify.ImageIndex = 1;
			this.tbbModify.ToolTipText = "Modify";
			// 
			// tbbDelete
			// 
			this.tbbDelete.ImageIndex = 2;
			this.tbbDelete.ToolTipText = "Delete";
			// 
			// tbbDeleteAll
			// 
			this.tbbDeleteAll.ImageIndex = 3;
			this.tbbDeleteAll.ToolTipText = "Delete All";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DlgGrade
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(754, 472);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "DlgGrade";
			this.Text = "Define DDAGrade";
			this.Load += new System.EventHandler(this.DlgDiskTypeConfiguration_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgDiskTypeConfiguration_Load(object sender, System.EventArgs e)
		{
			LoadData();
			UpdateGUI();
		}

		private void LoadData()
		{
			listView1.Items.Clear();
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				ArrayList alGradeList = cmd.GradesList();

				if(alGradeList!=null)
				{
					foreach(SiGlaz.Common.DDA.Grade obj in alGradeList)
					{
						this.AddToListView(obj);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				Close();
			}
		}

		private void AddToListView(SiGlaz.Common.DDA.Grade obj)
		{
			if(obj==null) return;
			Cursor.Current = Cursors.WaitCursor;

			ListViewItem item = listView1.Items.Add(obj.GradeID.ToString());
			item.Tag = obj;
			item.SubItems.Add(obj.GradeDescription);

			string signatures = string.Empty;

			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				SiGlaz.Common.DDA.Result.SignatureListResult result = cmd.GradeMappingGetSignature(obj.Gradekey);
				if(result.IsSuccess && result.signature!=null)
				{
					foreach(SiGlaz.Common.DDA.Signature sig in result.signature)
					{
						signatures+= "," + sig.SignatureName;
					}
					signatures = signatures.Substring(1);
				}
			}
			catch//(Exception ex)
			{
				//				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				//				Close();
			}
			item.SubItems.Add(signatures);
		}

		private void UpdateToListView(ListViewItem item,SiGlaz.Common.DDA.Grade obj)
		{
			if(obj==null) return;
			Cursor.Current = Cursors.WaitCursor;

			item.Tag = obj;
			item.SubItems[0].Text = obj.GradeID.ToString();
			item.SubItems[1].Text = obj.GradeDescription;

			string signatures = string.Empty;
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				SiGlaz.Common.DDA.Result.SignatureListResult result = cmd.GradeMappingGetSignature(obj.Gradekey);
				if(result.IsSuccess && result.signature!=null)
				{
					foreach(SiGlaz.Common.DDA.Signature sig in result.signature)
					{
						signatures+= "," + sig.SignatureName;
					}
					signatures = signatures.Substring(1);
				}
			}
			catch//(Exception ex)
			{
				//				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				//				Close();
			}
			item.SubItems[2].Text = signatures;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void UpdateGUI()
		{
			tbbDelete.Enabled = tbbModify.Enabled = listView1.SelectedItems.Count>0;
			tbbDeleteAll.Enabled = listView1.Items.Count>0;
		}

		private void Delete(SiGlaz.Common.DDA.Grade obj)
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				cmd.GradesDelete(obj.Gradekey);
			}
			catch//(Exception ex)
			{
				//				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				//				Close();
			}
		}

		private void Delete()
		{
			if(MessageBox.Show(this,"Are you sure to delete it?",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			if(listView1.SelectedItems.Count<=0) return;
			for(int i= listView1.SelectedItems.Count-1;i>=0;i--)
			{
				SiGlaz.Common.DDA.Grade obj = listView1.SelectedItems[i].Tag as SiGlaz.Common.DDA.Grade;
				listView1.SelectedItems[i].Remove();
				Delete(obj);
			}
		}

		private bool InsertUpdate(SiGlaz.Common.DDA.Grade obj)
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				cmd.GradesInsert(obj);
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				return false;
			}
		}

		private void DeleteAll()
		{
			if(MessageBox.Show(this,"Are you sure to delete all grades?",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			if(listView1.Items.Count<=0) return;
			for(int i= listView1.Items.Count-1;i>=0;i--)
			{
				SiGlaz.Common.DDA.Grade obj = listView1.Items[i].Tag as SiGlaz.Common.DDA.Grade;
				Delete(obj);
			}
			listView1.Items.Clear();
		}

		private ArrayList SignatureListOfGrade(SiGlaz.Common.DDA.Grade obj)
		{
			ArrayList alResult = new ArrayList();
			foreach(ListViewItem item in listView1.Items)
			{
				if(item.Tag!=obj)
					alResult.Add(item.Tag);
			}
			return alResult;
		}

		private void Add()
		{
			DlgGradeDetail dlg = new DlgGradeDetail( SignatureListOfGrade(null), null);
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				this.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				if(!InsertUpdate(dlg.objGrade))
					return;
				AddToListView(dlg.objGrade);
			}
		}

		private void Modify()
		{
			if( listView1.SelectedItems.Count<=0) return;
			ListViewItem item = listView1.SelectedItems[0];
			DlgGradeDetail dlg = new DlgGradeDetail( SignatureListOfGrade(item.Tag as SiGlaz.Common.DDA.Grade), item.Tag as SiGlaz.Common.DDA.Grade);
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				this.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				if(!InsertUpdate(dlg.objGrade))
					return;
				UpdateToListView(item,dlg.objGrade);
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == tbbAdd)
			{
				Add();
			}
			else if(e.Button  == tbbModify)
			{
				Modify();
			}
			else if(e.Button == tbbDelete)
			{
				Delete();
			}
			else
			{
				DeleteAll();
			}
			UpdateGUI();
		}

		private void listView1_ContextMenuChanged(object sender, System.EventArgs e)
		{
		
		}

		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListView listView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == _lvwColumnSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (_lvwColumnSorter.Order == SortOrder.Ascending)
					_lvwColumnSorter.Order = SortOrder.Descending;
				else
					_lvwColumnSorter.Order = SortOrder.Ascending;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				_lvwColumnSorter.SortColumn = e.Column;
				_lvwColumnSorter.Order = SortOrder.Ascending;
			}
			// Perform the sort with these new sort options.
			listView1.Sort();
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateGUI();
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			Modify();
			UpdateGUI();
		}

	}


}
