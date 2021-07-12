using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using SiGlaz.Common.DDA.Result;


namespace DDARMWinUI.Dialogs
{
	/// <summary>
	/// Summary description for DlgDefineSignatures.
	/// </summary>
	public class DlgDefineSignatures : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private SiGlaz.Windows.Forms.SDataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnClear;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgDefineSignatures()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dataGrid1.OnDeleteingRow+=new SiGlaz.Windows.Forms.ChangeRowEventHandle(dataGrid1_OnDeleteingRow);
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new SiGlaz.Windows.Forms.SDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnExport);
			this.panel1.Controls.Add(this.btnImport);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 466);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 40);
			this.panel1.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(19, 8);
			this.btnClear.Name = "btnClear";
			this.btnClear.TabIndex = 14;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.Location = new System.Drawing.Point(177, 8);
			this.btnExport.Name = "btnExport";
			this.btnExport.TabIndex = 13;
			this.btnExport.Text = "Export";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(97, 8);
			this.btnImport.Name = "btnImport";
			this.btnImport.TabIndex = 12;
			this.btnImport.Text = "Import";
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(337, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(76, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(257, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(76, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(432, 466);
			this.panel2.TabIndex = 1;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(432, 466);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table";
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Signature ID";
			this.dataGridTextBoxColumn2.MappingName = "SignatureID";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Signature Name";
			this.dataGridTextBoxColumn3.MappingName = "SignatureName";
			this.dataGridTextBoxColumn3.Width = 300;
			// 
			// DlgDefineSignatures
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(432, 506);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "DlgDefineSignatures";
			this.Text = "Define Signatures";
			this.Load += new System.EventHandler(this.DlgDefineSignatures_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		WebServiceProxy.CategoryCmd  cmd = null;
		private void DlgDefineSignatures_Load(object sender, System.EventArgs e)
		{
			LoadData();
		}

		
		DataTable dt = new  DataTable();
		DataSet dsview = null;

		private void LoadData()
		{
			try
			{
				cmd = new WebServiceProxy.CategoryCmd();
				DataSetResult ds = cmd.SignatureListToDataset();

				dsview = ds.Result;
				dt = ds.Result.Tables[0];

				if(dt.Rows.Count >= 3)
				{
//					dt.Rows.RemoveAt(2);
//					dt.Rows.RemoveAt(1);
					dt.Rows.RemoveAt(0);
				}

				int maxid = 0;
				foreach(DataRow dr in dt.Rows)
				{
					if( !dr.IsNull(1) )
					{
						if( maxid < (int)dr[1] )
							maxid = (int)dr[1];
					}
				}

				dt.Columns[1].AutoIncrement = true;
				dt.Columns[1].AutoIncrementSeed = maxid + 1;
				dt.Columns[1].AutoIncrementStep = 1;
				dt.Columns[1].AllowDBNull = false;
				//dt.Columns[1].Unique = true;

				dt.Columns[2].AllowDBNull = false;
				dt.Columns[2].Unique = true;

				dataGrid1.DataSource = dt;
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message + "\r\n" + ex.StackTrace,Application.ProductName);
				Close();
			}
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
				if(key<=3)
				{
					MessageBox.Show(this,"System Signature cannot be deleted",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Stop);
					cancel= true;
				}
				else if( !cmd.SignatureCanDelete(key) )
				{
					MessageBox.Show(this,"This Signature cannot be deleted because it contains all the related results.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Stop);
					cancel= true;
				}
				else
				{
					alDeletedKey.Add(key);
				}
			}
			catch
			{
				cancel= true;
			}
		}

		ArrayList alDeletedKey = new ArrayList();
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				//Delete data
				//DataTable dtDelete = dt.GetChanges(DataRowState.Deleted);
				//foreach(DataRow dr in dtDelete.Rows)
				foreach(int key in alDeletedKey)
				{
					cmd.SignatureDelete(key);//(int)dr[0]);
				}

				//Add/Modified data
				DataTable dtAddModify = dt.GetChanges(DataRowState.Modified | DataRowState.Added);
				if(dtAddModify!=null)
				{
					foreach(DataRow dr in dtAddModify.Rows)
					{
						SiGlaz.Common.DDA.Signature item = new SiGlaz.Common.DDA.Signature();

						if(!dr.IsNull(0))
							item.SCKey = (int)dr[0];

						if(!dr.IsNull(1))
							item.SignatureID = (int)dr[1];

						item.SignatureName = dr[2].ToString();

						cmd.SignatureInsert(item,false,false);
					}
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch//(Exception ex)
			{
				MessageBox.Show(this, "Cannot update into database",Application.ProductName);
			}
		}

		private void btnImport_Click(object sender, System.EventArgs e)
		{
			//Skip Delete and Import
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Import Signature file";
				dlg.Filter = "Signature document (*.xml)|*.xml|All files (*.*)|*.*";
				dlg.FilterIndex = 0;

				if( dlg.ShowDialog(this) == DialogResult.OK)
				{
					this.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					string filename = dlg.FileName;
					if( System.IO.File.Exists(filename))
					{
						try
						{
							DataSet dsimport = new DataSet();
							dsimport.ReadXml(filename);

							DataRow drImport = null;
							foreach(DataRow dr in dsimport.Tables[0].Rows)
							{
								try
								{
									drImport = dt.NewRow();

									drImport[1] = dr[0];
									drImport[2] = dr[1];

									dt.Rows.Add(drImport);
								}
								catch
								{
								}
							}
						}
						catch
						{
							MessageBox.Show("Invalid signature document",Application.ProductName);
						}
					}
				}
			}

		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			using(SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.Title = "Export Signature file";
				dlg.Filter = "Signature document (*.xml)|*.xml|All files (*.*)|*.*";

				dlg.FilterIndex = 0;

				if( dlg.ShowDialog(this) == DialogResult.OK)
				{
					string filename = dlg.FileName;

					this.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					if( System.IO.File.Exists(filename))
					{
						System.IO.File.SetAttributes(filename,System.IO.FileAttributes.Normal);
						System.IO.File.Delete(filename);
					}
					try
					{
						DataSet  ds = dsview.Copy();
						ds.Tables[0].Columns.RemoveAt(0);

						ds.Namespace = "";
						ds.DataSetName = "DSSignature";
						ds.Tables[0].TableName ="Signature";
						ds.Namespace = "http://tempuri.org/DSSignature.xsd"; 

						ds.WriteXml(filename);
					}
					catch
					{
						MessageBox.Show("Cannot export to file",Application.ProductName);
					}
				}
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				foreach(DataRow dr in dt.Rows)
				{
					if( !dr.IsNull(0) )
					{
						int key = (int)dr[0];
						if( key <= 3 ) continue;

						if(cmd.SignatureCanDelete(key))
							alDeletedKey.Add(key);
					}
				}
			}
			catch
			{
			}

			for(int i= dt.Rows.Count-1;i>=0;i--)
			{
				if( dt.Rows[i].IsNull(0) || (int)dt.Rows[i][0] > 3 )
					dt.Rows.RemoveAt(i);
			}

			dt.Columns[1].AutoIncrementSeed = 1;
		}

	
	}

	
}
