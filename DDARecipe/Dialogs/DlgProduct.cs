using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Windows.Forms;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgDiskTypeConfiguration.
	/// </summary>
	public class DlgProduct : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private SiGlaz.Windows.Forms.SDataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgProduct()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgProduct));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
            this.dataGrid1 = new SiGlaz.Windows.Forms.SDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
				((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-80, 360);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(816, 8);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(274, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(194, 376);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(544, 352);
			this.dataGrid1.TabIndex = 13;
			this.dataGrid1.OnDeleteingRow+=new SiGlaz.Windows.Forms.ChangeRowEventHandle(dataGrid1_OnDeleteingRow);
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table";
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Product Code";
			this.dataGridTextBoxColumn2.MappingName = "ProductCode";
			this.dataGridTextBoxColumn2.Width = 200;
			// 
			// DlgProduct
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(543, 408);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgProduct";
			this.Text = "Product Code";
			this.Load += new System.EventHandler(this.DlgDiskTypeConfiguration_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgDiskTypeConfiguration_Load(object sender, System.EventArgs e)
		{
			LoadData();
		}

		private void InitComboBox()
		{
			DataGriComboColumn colTemplate=new DataGriComboColumn();
			colTemplate.myCombo.DropDownStyle = ComboBoxStyle.DropDown;
			
			colTemplate.Setdata(dtProClass,"Prod_Class");
			colTemplate.Width=200;
			colTemplate.MappingName="Prod_Class";
			colTemplate.HeaderText="Product Class";
			dataGridTableStyle1.GridColumnStyles.Add(colTemplate);
		}

		DataTable	table = null;
		DataTable   dtProClass = null;
		private void LoadData()
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();

				SiGlaz.Common.DDA.Result.DataSetResult result = cmd.DiskSizesListDataset();
				if(result.Result!=null)
					dtProClass = result.Result.Tables[0];

				result = cmd.ProductListDataset();
				if(result.Result!=null)
					table = result.Result.Tables[0];

				if(table!=null)
				{
					table.Columns[0].AllowDBNull = true;

					table.Columns[2].AllowDBNull = false;
					table.Columns[2].MaxLength = 6;
					
					table.Columns[1].AllowDBNull = false;
					table.Columns[1].Unique = true;
				}
				else
					return;

				InitComboBox();
				dataGrid1.DataSource = table;

				table.RowDeleting+=new DataRowChangeEventHandler(table_RowDeleting);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				Close();
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(table==null) return;

			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();

				//Removed Row
				foreach(int removedid in alRemovedKey)
				{
					cmd.ProductDelete(removedid);
				}

				//Update Row 
				DataTable dtUpdate = table.GetChanges(DataRowState.Added | DataRowState.Modified);
				if(dtUpdate!=null)
				{
					foreach(DataRow dr in dtUpdate.Rows)
					{
						SiGlaz.Common.DDA.Product objinsert = new SiGlaz.Common.DDA.Product();

						if(!dr.IsNull("ProductKey"))
							objinsert.ProductKey = (int)dr["ProductKey"];
						else
							objinsert.ProductKey = -1;
					
						if(!dr.IsNull("Prod_Class"))
							objinsert.Prod_Class = dr["Prod_Class"].ToString();

						if(!dr.IsNull("ProductCode"))
							objinsert.ProductCode = dr["ProductCode"].ToString();

						cmd.ProductInsert(objinsert);
					}
				}

				Close();
				DialogResult = DialogResult.OK;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
				return;
			}
		}


		ArrayList alRemovedKey = new ArrayList();
		private void table_RowDeleting(object sender, DataRowChangeEventArgs e)
		{
			if(!e.Row.IsNull(0))
				alRemovedKey.Add((int)e.Row[0]);
		}

		private void dataGrid1_OnDeleteingRow(DataRow selectedrow, ref bool cancel)
		{
			if(selectedrow==null)
				return;
			if(selectedrow.IsNull(0))
				return;

			int key = (int)selectedrow[0];

			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();

				if( !cmd.ProductCanDelete(key) )
				{
					if( MessageBox.Show(this,"This product contains all the related disks . If deleted, the information of those disks will be deleted accordingly.\nAre you sure to delete it?",Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
					{
						cancel= true;
					}
				}
				else
				{
					//alRemovedKey.Add(key);
				}
			}
			catch
			{
				cancel= true;
			}
		}
	}


}
