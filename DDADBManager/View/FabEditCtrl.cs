using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


using SiGlaz.Common.DDA;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for FabEditCtrl.
	/// </summary>
	public class FabEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gFab;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.ComboBox cboFab;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FabEditCtrl()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gFab = new System.Windows.Forms.GroupBox();
			this.cboFab = new System.Windows.Forms.ComboBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.gFab.SuspendLayout();
			this.SuspendLayout();
			// 
			// gFab
			// 
			this.gFab.Controls.Add(this.cboFab);
			this.gFab.Controls.Add(this.txtDescription);
			this.gFab.Controls.Add(this.label2);
			this.gFab.Controls.Add(this.label1);
			this.gFab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gFab.Location = new System.Drawing.Point(0, 0);
			this.gFab.Name = "gFab";
			this.gFab.Size = new System.Drawing.Size(552, 72);
			this.gFab.TabIndex = 1;
			this.gFab.TabStop = false;
			this.gFab.Text = "Plant";
			// 
			// cboFab
			// 
			this.cboFab.Location = new System.Drawing.Point(96, 16);
			this.cboFab.Name = "cboFab";
			this.cboFab.Size = new System.Drawing.Size(184, 21);
			this.cboFab.TabIndex = 4;
			this.cboFab.SelectedValueChanged += new System.EventHandler(this.cboFab_SelectedValueChanged);
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(96, 40);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(448, 20);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Text = "";
			this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Plant ID:";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// FabEditCtrl
			// 
			this.Controls.Add(this.gFab);
			this.Name = "FabEditCtrl";
			this.Size = new System.Drawing.Size(552, 72);
			this.gFab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		SiGlaz.Common.DDA.Fab _DataSource;
		public SiGlaz.Common.DDA.Fab DataSource
		{
			get
			{
				UpdateData(true);
				return _DataSource;
			}
			set
			{
				_DataSource = value;
				UpdateData(false);
			}
		}

		public void UpdateData(bool update)
		{
			if(update)
			{
				if(_DataSource==null)
					_DataSource = new SiGlaz.Common.DDA.Fab();
				_DataSource.FabID = cboFab.Text;
				_DataSource.Description = txtDescription.Text;
			}
			else
			{
				if(_DataSource==null)
				{
					cboFab.Text = txtDescription.Text =string.Empty;
					return;
				}
				else
				{
					cboFab.Text = _DataSource.FabID;
					txtDescription.Text = _DataSource.Description;
				}
			}
		}

		private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void txtFabID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(cboFab.Text.Trim() == string.Empty)
			{
				errorProvider1.SetError(sender as Control,"Please type Plant ID");
				e.Cancel = true;
			}
			else
				errorProvider1.SetError(sender as Control,string.Empty);
		}


		public string ValidateString
		{
			get
			{
				if(cboFab.Text.Trim() == string.Empty)
					return "Please type Plant ID";
				return string.Empty;
			}
		}

		public void LoadFabList()
		{
			try
			{
				if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
					if(proxy!=null)
					{
						WebServiceProxy.CategoryProxy.DataSetResult result = proxy.FabList();

						if(result.Code==WebServiceProxy.CategoryProxy.ErrorCode.OK)
							LoadDataIntoCombo(result.Result.Tables[0]);
						else
							MessageBox.Show(result.Description,Application.ProductName);
					}
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					SiGlaz.Common.DDA.Result.DataSetResult result = proxy.FabList();

					if(result.IsSuccess)
						LoadDataIntoCombo(result.Result.Tables[0]);
					else
						MessageBox.Show("Cannot connect to database.",Application.ProductName);
	
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,Application.ProductName);
			}
		}


		private void LoadDataIntoCombo(DataTable table)
		{
			cboFab.Items.Clear();
			if( table==null)
				return;

			foreach(DataRow dr in table.Rows)
			{
				if(dr.IsNull("FabID"))
					continue;

				cboFab.Items.Add(dr["FabID"].ToString());
			}
		}

		private void cboFab_SelectedValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				string fabid = cboFab.Text;

				if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
					WebServiceProxy.CategoryProxy.Fab result = proxy.GetFabByFabID(fabid);
					if(result!=null)
						txtDescription.Text = result.Description;
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					Fab result = proxy.GetFabByFabID(fabid);

					if(result!=null)
						txtDescription.Text = result.Description;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,Application.ProductName);
			}
		}
	}
}
