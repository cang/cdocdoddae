using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgDiskTypeConfiguration.
	/// </summary>
	public class DlgDiskTypeConfiguration : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnBackup;
		private System.Windows.Forms.Button btnRestore;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgDiskTypeConfiguration()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgDiskTypeConfiguration));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnBackup = new System.Windows.Forms.Button();
			this.btnRestore = new System.Windows.Forms.Button();
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
			this.btnCancel.Location = new System.Drawing.Point(394, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(314, 376);
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
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Product Class";
			this.dataGridTextBoxColumn1.MappingName = "Prod_Class";
			this.dataGridTextBoxColumn1.Width = 150;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Inner Diameter (mm)";
			this.dataGridTextBoxColumn2.MappingName = "InnerDiameter";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Outer Diameter (mm)";
			this.dataGridTextBoxColumn3.MappingName = "OuterDiameter";
			this.dataGridTextBoxColumn3.Width = 150;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(234, 376);
			this.btnExport.Name = "btnExport";
			this.btnExport.TabIndex = 14;
			this.btnExport.Text = "Export";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnBackup
			// 
			this.btnBackup.Location = new System.Drawing.Point(154, 376);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.TabIndex = 15;
			this.btnBackup.Text = "Backup";
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			// 
			// btnRestore
			// 
			this.btnRestore.Location = new System.Drawing.Point(74, 376);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.TabIndex = 16;
			this.btnRestore.Text = "Restore";
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			// 
			// DlgDiskTypeConfiguration
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(543, 408);
			this.Controls.Add(this.btnRestore);
			this.Controls.Add(this.btnBackup);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgDiskTypeConfiguration";
			this.Text = "Product Class Setting";
			this.Load += new System.EventHandler(this.DlgDiskTypeConfiguration_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgDiskTypeConfiguration_Load(object sender, System.EventArgs e)
		{
			//LoadData();
		}

		DataTable	table = null;
		public void LoadData()
		{
			try
			{
				if( SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
					if(proxy==null) return;
					WebServiceProxy.CategoryProxy.DataSetResult result = proxy.DiskSizesListDataset();
					if(result.Result!=null)
						table = result.Result.Tables[0];
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					SiGlaz.Common.DDA.Result.DataSetResult result = proxy.DiskSizesListDataset();
					if(result.Result!=null)
						table = result.Result.Tables[0];
				}

				if(table!=null)
				{
					table.Columns[0].AllowDBNull = true;

					table.Columns[1].AllowDBNull = false;
					table.Columns[1].Unique = true;
					table.Columns[1].MaxLength = 6;
					
					table.Columns[2].AllowDBNull = false;
					table.Columns[2].DefaultValue = 25;

					table.Columns[3].AllowDBNull = false;
					table.Columns[3].DefaultValue = 95;
				}
				else
					return;

				dataGrid1.DataSource = table;

				table.RowDeleting+=new DataRowChangeEventHandler(table_RowDeleting);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : " + ex.Message,Application.ProductName);
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(table==null) return;

			table.AcceptChanges();
			foreach(DataRow dr in table.Rows )
			{
				if( (double)dr[2] <= 0)
				{
					MessageBox.Show("InnerDiameter is not less than zero.",Application.ProductName);
					return;
				}
				if( (double)dr[3] <= 0)
				{
					MessageBox.Show("OuterDiameter is not less than zero.",Application.ProductName);
					return;
				}
				if( (double)dr[2] >= (double)dr[3] )
				{
					MessageBox.Show("OuterDiameter must be greater than InnerDiameter.",Application.ProductName);
					return;
				}
			}

			try
			{
				if( SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();

					//Removed Row
					foreach(int removedid in alRemovedKey)
					{
						proxy.DiskSizesDelete(removedid);
					}

					//Update Row 
					foreach(DataRow dr in table.Rows)
					{
						WebServiceProxy.CategoryProxy.DiskSize objinsert = new WebServiceProxy.CategoryProxy.DiskSize();

						if(!dr.IsNull("DiskSizeKey"))
							objinsert.DiskSizeKey = (int)dr["DiskSizeKey"];
						else
							objinsert.DiskSizeKey = -1;
						
						if(!dr.IsNull("Prod_Class"))
							objinsert.Prod_Class = dr["Prod_Class"].ToString();

						if(!dr.IsNull("InnerDiameter"))
							objinsert.InnerDiameter = (double)dr["InnerDiameter"];

						if(!dr.IsNull("OuterDiameter"))
							objinsert.OuterDiameter = (double)dr["OuterDiameter"];

						proxy.DiskSizesInsert(objinsert);
					}
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();

					//Removed Row
					foreach(int removedid in alRemovedKey)
					{
						proxy.DiskSizesDelete(removedid);
					}

					//Update Row 
					foreach(DataRow dr in table.Rows)
					{
						SiGlaz.Common.DDA.DiskSize objinsert = new SiGlaz.Common.DDA.DiskSize();

						if(!dr.IsNull("DiskSizeKey"))
							objinsert.DiskSizeKey = (int)dr["DiskSizeKey"];
						else
							objinsert.DiskSizeKey = -1;
						
						if(!dr.IsNull("Prod_Class"))
							objinsert.Prod_Class = dr["Prod_Class"].ToString();

						if(!dr.IsNull("InnerDiameter"))
							objinsert.InnerDiameter = (double)dr["InnerDiameter"];

						if(!dr.IsNull("OuterDiameter"))
							objinsert.OuterDiameter = (double)dr["OuterDiameter"];

						proxy.DiskSizesInsert(objinsert);
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

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Please click OK to save to database before exporting" , Application.ProductName);

			//Get Product from database and export to file
			using(SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.Title = "Export to product configuration file";
				dlg.Filter = "Product configuration document (*.xml)|*.xml|All files (*.*)|*.*";

				dlg.FilterIndex = 0;

				if( dlg.ShowDialog(this) == DialogResult.OK)
				{
					string filename = dlg.FileName;


					if( System.IO.File.Exists(filename))
					{
						System.IO.File.SetAttributes(filename,System.IO.FileAttributes.Normal);
						System.IO.File.Delete(filename);
					}
					try
					{
						DDAExternalData.RefreshDiskType();//reload data from database

						FPPCommon.ProductConfiguration product = DDAExternalData.ProductConfiguration;
						product.Serialize(filename);
					}
					catch
					{
						MessageBox.Show("Cannot export to file",Application.ProductName);
					}
				}
			}
		}

		private void btnBackup_Click(object sender, System.EventArgs e)
		{
			if(table==null) return;

			//MessageBox.Show("Please click OK to save to database before exporting" , Application.ProductName);

			//Get Product from database and export to file
			using(SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.Title = "Backup product class configuration file";
				dlg.Filter = "Product class configuration document (*.xml)|*.xml|All files (*.*)|*.*";

				dlg.FilterIndex = 0;

				if( dlg.ShowDialog(this) == DialogResult.OK)
				{
					string filename = dlg.FileName;


					if( System.IO.File.Exists(filename))
					{
						System.IO.File.SetAttributes(filename,System.IO.FileAttributes.Normal);
						System.IO.File.Delete(filename);
					}
					try
					{
						table.DataSet.WriteXml(filename);
					}
					catch
					{
						MessageBox.Show("Cannot backup to file",Application.ProductName);
					}
				}
			}
		}

		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			if(table==null) return;

			//Get Product from database and export to file
			using(OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Backup product class configuration file";
				dlg.Filter = "Product class configuration document (*.xml)|*.xml|All files (*.*)|*.*";

				dlg.FilterIndex = 0;

				if( dlg.ShowDialog(this) == DialogResult.OK)
				{
					string filename = dlg.FileName;

					if( !System.IO.File.Exists(filename))
						return;
	
					try
					{
						DataSet ds = new DataSet();
						ds.ReadXml(filename);

						if(ds.Tables.Count>0)
						{
							//Clear current data
							table.AcceptChanges();
							foreach(DataRow dr in table.Rows)
							{
								if(!dr.IsNull("DiskSizeKey"))
								{
									int key = (int)dr["DiskSizeKey"];
									if(key>0 && !alRemovedKey.Contains(key))
										alRemovedKey.Add(key);
								}
							}
							table.Clear();

							//Import new data
							foreach(DataRow dr in ds.Tables[0].Rows)
							{
								dr[0] = -1;
								table.ImportRow(dr);
							}
						}
					}
					catch
					{
						MessageBox.Show("Cannot restore from file",Application.ProductName);
					}
				}
			}
		}
	}
}
