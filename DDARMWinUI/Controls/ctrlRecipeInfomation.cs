using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace DDARMWinUI.Controls
{
	public class ctrlRecipeInfomation : System.Windows.Forms.UserControl
	{
		#region Members
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox txtDescription;
		private System.Windows.Forms.TextBox txtName;
		public  System.Windows.Forms.ComboBox cboSignature;
		public System.Windows.Forms.ComboBox cboFab;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.ComboBox cboTesterType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkBreak;
		private System.Windows.Forms.ComboBox cboPreviousRecipe;
		#endregion
		
		#region Constructor & Destructor
		public ctrlRecipeInfomation()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboTesterType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cboFab = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cboPreviousRecipe = new System.Windows.Forms.ComboBox();
			this.cboSignature = new System.Windows.Forms.ComboBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkBreak = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkBreak);
			this.groupBox1.Controls.Add(this.cboTesterType);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.cboFab);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cboPreviousRecipe);
			this.groupBox1.Controls.Add(this.cboSignature);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.txtDescription);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(572, 300);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "````";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// cboTesterType
			// 
			this.cboTesterType.Location = new System.Drawing.Point(112, 44);
			this.cboTesterType.Name = "cboTesterType";
			this.cboTesterType.Size = new System.Drawing.Size(252, 21);
			this.cboTesterType.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Tester Type :";
			// 
			// cboFab
			// 
			this.cboFab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFab.Location = new System.Drawing.Point(128, 284);
			this.cboFab.Name = "cboFab";
			this.cboFab.Size = new System.Drawing.Size(256, 21);
			this.cboFab.TabIndex = 11;
			this.cboFab.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(32, 288);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Run on Fab";
			this.label6.Visible = false;
			// 
			// cboPreviousRecipe
			// 
			this.cboPreviousRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPreviousRecipe.Location = new System.Drawing.Point(112, 92);
			this.cboPreviousRecipe.Name = "cboPreviousRecipe";
			this.cboPreviousRecipe.Size = new System.Drawing.Size(252, 21);
			this.cboPreviousRecipe.TabIndex = 9;
			this.cboPreviousRecipe.SelectedIndexChanged += new System.EventHandler(this.cboPreviousRecipe_SelectedIndexChanged);
			// 
			// cboSignature
			// 
			this.cboSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSignature.Location = new System.Drawing.Point(112, 68);
			this.cboSignature.Name = "cboSignature";
			this.cboSignature.Size = new System.Drawing.Size(252, 21);
			this.cboSignature.TabIndex = 8;
			this.cboSignature.SelectedIndexChanged += new System.EventHandler(this.cboSignature_SelectedIndexChanged);
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(112, 20);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(424, 20);
			this.txtName.TabIndex = 7;
			this.txtName.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(112, 164);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(424, 80);
			this.txtDescription.TabIndex = 6;
			this.txtDescription.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 164);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Description:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Previous Recipe:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Signature";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name:";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(128, 324);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.TabIndex = 1;
			this.txtID.Text = "";
			this.txtID.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ID:";
			this.label1.Visible = false;
			// 
			// chkBreak
			// 
			this.chkBreak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBreak.Location = new System.Drawing.Point(100, 120);
			this.chkBreak.Name = "chkBreak";
			this.chkBreak.Size = new System.Drawing.Size(456, 24);
			this.chkBreak.TabIndex = 14;
			this.chkBreak.Text = "If the signature is found after running this recipe, the next recipes will stop p" +
				"rocessing";
			this.chkBreak.CheckedChanged += new System.EventHandler(this.chkContinue_CheckedChanged);
			// 
			// ctrlRecipeInfomation
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ctrlRecipeInfomation";
			this.Size = new System.Drawing.Size(572, 300);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public int RecipeID
		{
			get { return Convert.ToInt32(txtID.Text); }
			set { txtID.Text = value.ToString(); }
		}

		public string RecipeName
		{
			get { return txtName.Text; }
			set { txtName.Text = value; }
		}

		public string Description
		{
			get { return txtDescription.Text; }
			set { txtDescription.Text = value; }
		}

		public int SingatureKey
		{
			get 
			{ 
				return Convert.ToInt32(cboSignature.SelectedValue); 
			}
			set 
			{
				if(value!=-1)
					cboSignature.SelectedValue = value;
			}
		}

		public string SingatureName
		{
			get 
			{ 
				return cboSignature.Text;
			}
		}

//		public string FabID
//		{
//			get 
//			{ 
//				return cboFab.Text;
//			}
//		}
//
//		public short FabKey
//		{
//			get 
//			{ 
//				if(cboFab.SelectedItem!=null)
//					return (short)cboFab.SelectedValue;
//				else
//					return 0;
//			}
//			set
//			{
//				//if(value!=-1)
//				for(int i=0;i<cboFab.Items.Count;i++)
//				{
//					DataRowView drv = cboFab.Items[i] as DataRowView;
//					if( (short)drv[0] == value)
//					{
//						cboFab.SelectedIndex = i;
//						break;
//					}
//				}
//			}
//		}

		public int PreviousRecipeKey
		{
			get 
			{ 
				return Convert.ToInt32(cboPreviousRecipe.SelectedValue); 
			}
			set
			{
				if(value!=-1)
					cboPreviousRecipe.SelectedValue = value;
			}
		}

		public string PreviousRecipeName
		{
			get 
			{ 
				return cboPreviousRecipe.Text; 
			}
		}

		ArrayList	_RecipeList;
		public ArrayList	RecipeList
		{
			get
			{
				return _RecipeList;
			}
			set
			{
				_RecipeList = value;
				DisplayPreviousRecipe();
			}
		}

		#endregion

		#region UI Command

		public void DisplaySignatureCategoryList()
		{
			DataTable dt = null;

			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.CategoryProxy.Category service = WebServiceProxy.WebProxyFactory.CreateCategory();
				if (service != null)
				{
					WebServiceProxy.CategoryProxy.DataSetResult dsResult = service.SignatureListToDataset();
					if (dsResult != null)
						dt = dsResult.Result.Tables[0];
				}
			}
			else
			{
				SiGlaz.DDA.Business.Category service = new SiGlaz.DDA.Business.Category();
				if (service != null)
				{
					SiGlaz.Common.DDA.Result.DataSetResult dsResult = service.SignatureListToDataset();
					if (dsResult != null)
						dt = dsResult.Result.Tables[0];
				}
			}

			cboSignature.DataSource = dt;
			cboSignature.DisplayMember = "SignatureName";
			cboSignature.ValueMember = "SignatureKey";
		}


		public void DisplayTesterTypeList()
		{
			try
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				DataSetResult result = cmd.TesterTypesList();

				if(result.IsSuccess)
				{
					cboTesterType.Items.Clear();
					foreach(DataRow dr in result.Result.Tables[0].Rows)
					{
						if( !dr.IsNull(1))
							cboTesterType.Items.Add(dr[1].ToString());
					}
				}

			}
			catch
			{
			}
		}

		public string TesterType
		{
			get
			{
				return cboTesterType.Text.Trim();
			}
			set
			{
				cboTesterType.Text = value;
			}
		}

		public bool Break
		{
			get
			{
				return chkBreak.Checked;
			}
			set
			{
				chkBreak.Checked = value;
			}
		}

		public int SignatureCode
		{
			get
			{
				try
				{
					WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
					Signature result = cmd.SignatureGetByKey(this.SingatureKey);
					return result.SignatureID;
				}
				catch
				{
					return 0;
				}
			}
		}

		public void DisplayPreviousRecipe()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add ( new DataColumn ("RecipeKey",typeof(int)));
			dt.Columns.Add ( new DataColumn ("RecipeName",typeof(string)));

			DataRow newRow = dt.NewRow();
			newRow["RecipeKey"] = -1;
			newRow["RecipeName"] = "None";
			dt.Rows.Add(newRow);

			if(_RecipeList!=null)
			{
				foreach(DDARecipe.DDARecipe recipe in _RecipeList)
				{
					if( recipe.ID == this.RecipeID ) continue;
					if( cboTesterType.Text.Trim() != recipe.TesterType) continue;

					newRow = dt.NewRow();
					newRow["RecipeKey"] = recipe.ID;
					newRow["RecipeName"] = recipe.Name;
					dt.Rows.Add(newRow);
				}
			}

			cboPreviousRecipe.DataSource = dt;
			cboPreviousRecipe.DisplayMember = "RecipeName";
			cboPreviousRecipe.ValueMember = "RecipeKey";
		}

		public bool CheckInfo()
		{
			bool result = true;

			if (txtName.Text == string.Empty)
			{
				result = false;
				MessageBox.Show("Please enter recipe name.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtName.Focus();
			}
			else if (cboSignature.Text == string.Empty)
			{

			}

			return result;
		}
		#endregion

		private void cboSignature_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void cboPreviousRecipe_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkContinue_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		#region Windows Events Handles

		#endregion

		
	}
}
