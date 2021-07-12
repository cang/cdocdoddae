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
	public class DlgGradeDetail : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader colSigID;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudGrade;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtGradeDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components;

		ArrayList alGrades;
		private System.Windows.Forms.Button btnToLeftAll;
		private System.Windows.Forms.Button btnToLeft;
		private System.Windows.Forms.Button btnToRight;
		private System.Windows.Forms.Button btnToRightAll;
		private System.Windows.Forms.ListView lvAll;
		private System.Windows.Forms.ListView lvGrade;
		public  SiGlaz.Common.DDA.Grade objGrade;

		private ListViewColumnSorter _lvwColumnSorter = new ListViewColumnSorter();
		private ListViewColumnSorter _lvwColumnSorter1 = new ListViewColumnSorter();


		public DlgGradeDetail(ArrayList gradelist,SiGlaz.Common.DDA.Grade editobj)
		{
			InitializeComponent();

			nudGrade.Maximum = int.MaxValue;

			objGrade = editobj;
			alGrades = gradelist;

			nudGrade.Enabled = objGrade==null;
			if(objGrade==null)
			{
				objGrade = new SiGlaz.Common.DDA.Grade();
				int id = 0;
				foreach(SiGlaz.Common.DDA.Grade obj in alGrades)
				{
					if( id < obj.GradeID )
						id = obj.GradeID;
				}

				objGrade.GradeID = id + 1;
				if(objGrade.GradeID<0)
					objGrade.GradeID = 1;

				Text = "Add New Grade";
				}
			else
			{
				Text = "Modify Grade" ;
			}

			lvAll.ListViewItemSorter = _lvwColumnSorter;
			lvGrade.ListViewItemSorter = _lvwColumnSorter1;
		
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnToLeftAll = new System.Windows.Forms.Button();
			this.btnToLeft = new System.Windows.Forms.Button();
			this.btnToRight = new System.Windows.Forms.Button();
			this.btnToRightAll = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lvAll = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.txtGradeDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nudGrade = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.lvGrade = new System.Windows.Forms.ListView();
			this.colSigID = new System.Windows.Forms.ColumnHeader();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGrade)).BeginInit();
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
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(348, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(268, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 408);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(690, 48);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(690, 408);
			this.panel2.TabIndex = 15;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnToLeftAll);
			this.panel4.Controls.Add(this.btnToLeft);
			this.panel4.Controls.Add(this.btnToRight);
			this.panel4.Controls.Add(this.btnToRightAll);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.lvAll);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.txtGradeDescription);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.nudGrade);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.lvGrade);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(690, 408);
			this.panel4.TabIndex = 0;
			// 
			// btnToLeftAll
			// 
			this.btnToLeftAll.Location = new System.Drawing.Point(328, 280);
			this.btnToLeftAll.Name = "btnToLeftAll";
			this.btnToLeftAll.Size = new System.Drawing.Size(32, 23);
			this.btnToLeftAll.TabIndex = 27;
			this.btnToLeftAll.Text = "<<";
			this.btnToLeftAll.Click += new System.EventHandler(this.btnToLeftAll_Click);
			// 
			// btnToLeft
			// 
			this.btnToLeft.Location = new System.Drawing.Point(328, 248);
			this.btnToLeft.Name = "btnToLeft";
			this.btnToLeft.Size = new System.Drawing.Size(32, 23);
			this.btnToLeft.TabIndex = 26;
			this.btnToLeft.Text = "<";
			this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
			// 
			// btnToRight
			// 
			this.btnToRight.Location = new System.Drawing.Point(328, 216);
			this.btnToRight.Name = "btnToRight";
			this.btnToRight.Size = new System.Drawing.Size(32, 23);
			this.btnToRight.TabIndex = 25;
			this.btnToRight.Text = ">";
			this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
			// 
			// btnToRightAll
			// 
			this.btnToRightAll.Location = new System.Drawing.Point(328, 184);
			this.btnToRightAll.Name = "btnToRightAll";
			this.btnToRightAll.Size = new System.Drawing.Size(32, 23);
			this.btnToRightAll.TabIndex = 24;
			this.btnToRightAll.Text = ">>";
			this.btnToRightAll.Click += new System.EventHandler(this.btnToRightAll_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = "All Signatures";
			// 
			// lvAll
			// 
			this.lvAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader2});
			this.lvAll.FullRowSelect = true;
			this.lvAll.Location = new System.Drawing.Point(8, 112);
			this.lvAll.Name = "lvAll";
			this.lvAll.Size = new System.Drawing.Size(312, 280);
			this.lvAll.TabIndex = 4;
			this.lvAll.View = System.Windows.Forms.View.Details;
			this.lvAll.DoubleClick += new System.EventHandler(this.lvAll_DoubleClick);
			this.lvAll.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAll_ColumnClick);
			this.lvAll.SelectedIndexChanged += new System.EventHandler(this.lvAll_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "SignatureID";
			this.columnHeader1.Width = 72;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Signature Name";
			this.columnHeader2.Width = 231;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(368, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 16);
			this.label3.TabIndex = 21;
			this.label3.Text = "Signatures Of Grade";
			// 
			// txtGradeDescription
			// 
			this.txtGradeDescription.Location = new System.Drawing.Point(96, 38);
			this.txtGradeDescription.Name = "txtGradeDescription";
			this.txtGradeDescription.Size = new System.Drawing.Size(584, 20);
			this.txtGradeDescription.TabIndex = 3;
			this.txtGradeDescription.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description :";
			// 
			// nudGrade
			// 
			this.nudGrade.Location = new System.Drawing.Point(96, 14);
			this.nudGrade.Maximum = new System.Decimal(new int[] {
																	 1316134912,
																	 2328,
																	 0,
																	 0});
			this.nudGrade.Name = "nudGrade";
			this.nudGrade.Size = new System.Drawing.Size(152, 20);
			this.nudGrade.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "DDAGrade : ";
			// 
			// lvGrade
			// 
			this.lvGrade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.colSigID,
																					  this.colName});
			this.lvGrade.FullRowSelect = true;
			this.lvGrade.Location = new System.Drawing.Point(368, 112);
			this.lvGrade.Name = "lvGrade";
			this.lvGrade.Size = new System.Drawing.Size(312, 280);
			this.lvGrade.TabIndex = 5;
			this.lvGrade.View = System.Windows.Forms.View.Details;
			this.lvGrade.DoubleClick += new System.EventHandler(this.lvGrade_DoubleClick);
			this.lvGrade.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGrade_ColumnClick);
			this.lvGrade.SelectedIndexChanged += new System.EventHandler(this.lvGrade_SelectedIndexChanged);
			// 
			// colSigID
			// 
			this.colSigID.Text = "SignatureID";
			this.colSigID.Width = 72;
			// 
			// colName
			// 
			this.colName.Text = "Signature Name";
			this.colName.Width = 231;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DlgGradeDetail
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(690, 456);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "DlgGradeDetail";
			this.Text = "DDAGrade Detail";
			this.Load += new System.EventHandler(this.DlgDiskTypeConfiguration_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudGrade)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgDiskTypeConfiguration_Load(object sender, System.EventArgs e)
		{
			LoadData();
			UpdateGUI();
		}

		ArrayList alAll = null;
		ArrayList alSignatureGrade = new ArrayList();
		private void LoadData()
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				SiGlaz.Common.DDA.Result.SignatureListResult result = cmd.SignatureList();
				//SiGlaz.Common.DDA.Result.SignatureListResult result = cmd.GradeMappingGetUnknownSignature();
				if(result.IsSuccess)
					alAll = result.signature;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				Close();
			}

			nudGrade.Value = objGrade.GradeID;
			txtGradeDescription.Text = objGrade.GradeDescription;

			//Remove others
			if(alAll!=null)
			{
				for(int i=alAll.Count-1;i>=0;i--)
				{
					SiGlaz.Common.DDA.Signature sig = alAll[i] as SiGlaz.Common.DDA.Signature;

					if(sig.SCKey<=1)
					{
						alAll.RemoveAt(i);
						continue;
					}

					if(objGrade.SignatureKeyList!=null)
					{
						if(objGrade.SignatureKeyList.Contains(sig.SCKey))
						{
							alSignatureGrade.Add(sig);
							alAll.RemoveAt(i);
							continue;
						}
					}

					foreach(SiGlaz.Common.DDA.Grade grade in alGrades)
					{
						if(grade.SignatureKeyList!=null)
						{
							
							if(grade.SignatureKeyList.Contains(sig.SCKey))
							{
								alAll.RemoveAt(i);
								break;
							}
						}
					}
				}
			}

			LoadData(alAll,lvAll,false);
			LoadData(alSignatureGrade,lvGrade,false);
	
		}

		private void LoadData(ArrayList alData,ListView lv,bool update)
		{
			if(!update)
				lv.Items.Clear();
			if(alData==null) return;

			foreach(SiGlaz.Common.DDA.Signature obj in alData)
			{
				ListViewItem item = lv.Items.Add(obj.SignatureID.ToString());
				item.Tag = obj;
				item.SubItems.Add(obj.SignatureName);
			}
		}

		private void Remove(ArrayList alData,ListView lv)
		{
			if(alData==null) return;
			for(int i=lv.Items.Count-1;i>=0;i--)
			{
				if(alData.Contains(lv.Items[i].Tag))
					lv.Items.RemoveAt(i);
			}
		}

		private  void Remove(ArrayList alparent,ArrayList alChildren)
		{
			if(alChildren==null) return;
			if(alparent==null) return;

			for(int i=alparent.Count-1;i>=0;i--)
			{
				if(alChildren.Contains(alparent[i]))
					alparent.RemoveAt(i);
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			foreach(SiGlaz.Common.DDA.Grade grade in alGrades)
			{
				if(nudGrade.Value == grade.GradeID)
				{
					MessageBox.Show(string.Format("Grade {0} was existed in Grade List",nudGrade.Value), this.Text);
					return;
				}
			}

			objGrade.GradeID = Convert.ToInt32(nudGrade.Value);
			objGrade.GradeDescription = txtGradeDescription.Text;
			objGrade.SignatureKeyList.Clear();

			foreach(ListViewItem item in lvGrade.Items)
			{
				objGrade.SignatureKeyList.Add( (item.Tag as SiGlaz.Common.DDA.Signature).SCKey );
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnToRightAll_Click(object sender, System.EventArgs e)
		{
			alSignatureGrade.AddRange(alAll);
			LoadData(alAll,lvGrade,true);
			alAll.Clear();
			lvAll.Items.Clear();
			UpdateGUI();
		}

		private void btnToLeftAll_Click(object sender, System.EventArgs e)
		{
			alAll.AddRange(alSignatureGrade);
			LoadData(alSignatureGrade,lvAll,true);
			alSignatureGrade.Clear();
			lvGrade.Items.Clear();
			UpdateGUI();
		}

		private void btnToRight_Click(object sender, System.EventArgs e)
		{
			if(lvAll.SelectedItems==null) return;
			ArrayList alSelects = new ArrayList();
			foreach(ListViewItem item in lvAll.SelectedItems)
			{
				alSelects.Add(item.Tag);
			}

			LoadData(alSelects,lvGrade,true);
			Remove(alSelects,lvAll);
			Remove(alAll,alSelects);
			alSignatureGrade.AddRange(alSelects);
			UpdateGUI();
		}

		private void btnToLeft_Click(object sender, System.EventArgs e)
		{
			if(lvGrade.SelectedItems==null) return;
			ArrayList alSelects = new ArrayList();
			foreach(ListViewItem item in lvGrade.SelectedItems)
			{
				alSelects.Add(item.Tag);
			}

			LoadData(alSelects,lvAll,true);
			Remove(alSelects,lvGrade);
			Remove(alSignatureGrade,alSelects);
			alAll.AddRange(alSelects);
			UpdateGUI();
		}

		private void lvAll_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
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
			lvAll.Sort();

		}

		private void lvGrade_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListView listView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == _lvwColumnSorter1.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (_lvwColumnSorter1.Order == SortOrder.Ascending)
					_lvwColumnSorter1.Order = SortOrder.Descending;
				else
					_lvwColumnSorter1.Order = SortOrder.Ascending;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				_lvwColumnSorter1.SortColumn = e.Column;
				_lvwColumnSorter1.Order = SortOrder.Ascending;
			}
			// Perform the sort with these new sort options.
			lvGrade.Sort();
		}

		private void UpdateGUI()
		{
			btnToRightAll.Enabled = lvAll.Items.Count>0;
			btnToRight.Enabled = lvAll.SelectedItems.Count>0;
			btnToLeftAll.Enabled = lvGrade.Items.Count>0;
			btnToLeft.Enabled = lvGrade.SelectedItems.Count>0;
		}

		private void lvAll_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateGUI();
		}

		private void lvGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateGUI();
		}

		private void lvAll_DoubleClick(object sender, System.EventArgs e)
		{
			btnToRight_Click(null,null);
			UpdateGUI();
		}

		private void lvGrade_DoubleClick(object sender, System.EventArgs e)
		{
			btnToLeft_Click(null,null);
			UpdateGUI();
		}

	}


}
