using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DDARecipe.Controls;
using DDARMWinUI.Controls;

namespace DDARMWinUI.Dialogs
{
	public class DlgRecipeProperties : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabControl tabRecipe;
		private System.Windows.Forms.TabPage pageRecipeSchema;
		private System.Windows.Forms.TabPage pageRecipeInfo;
		private System.ComponentModel.Container components = null;
		private DDARMWinUI.Controls.ctrlRecipeInfomation _ctrlRecipeInfomation;
		private DDARecipe.Controls.ctrlRecipe _ctrlRecipe;
		private DDARecipe.DDARecipe _recipe = null;
		private ArrayList _Recipes = null;
		#endregion
	
		#region Constructor & Destructor

		public DlgRecipeProperties()
		{
			InitializeComponent();
			InitializeComponentDynamic();

			//this.Icon = new Icon(this.GetType(),"App.ico");
			//this.Text = Application.ProductName;
		}

		public DlgRecipeProperties(DDARecipe.DDARecipe recipe,ArrayList recipes) : this()
		{
			this._Recipes = recipes;
			this.Recipe = recipe;
		}

		public void InitializeComponentDynamic()
		{
			_ctrlRecipe = new ctrlRecipe();
			_ctrlRecipe.Dock = DockStyle.Fill;
			pageRecipeSchema.Controls.Add(_ctrlRecipe);
		}

		public DDARecipe.DDARecipe Recipe
		{
			get
			{
				return _recipe;
			}
			set
			{
				_recipe = value;
				if(_recipe!=null)
					UpdateData(false);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgRecipeProperties));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabRecipe = new System.Windows.Forms.TabControl();
			this.pageRecipeSchema = new System.Windows.Forms.TabPage();
			this.pageRecipeInfo = new System.Windows.Forms.TabPage();
			this._ctrlRecipeInfomation = new DDARMWinUI.Controls.ctrlRecipeInfomation();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabRecipe.SuspendLayout();
			this.pageRecipeInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 526);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 40);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnCancel);
			this.panel3.Controls.Add(this.btnOK);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(592, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 40);
			this.panel3.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(116, 9);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(36, 9);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabRecipe);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 526);
			this.panel2.TabIndex = 1;
			// 
			// tabRecipe
			// 
			this.tabRecipe.Controls.Add(this.pageRecipeSchema);
			this.tabRecipe.Controls.Add(this.pageRecipeInfo);
			this.tabRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabRecipe.Location = new System.Drawing.Point(0, 0);
			this.tabRecipe.Name = "tabRecipe";
			this.tabRecipe.SelectedIndex = 0;
			this.tabRecipe.Size = new System.Drawing.Size(792, 526);
			this.tabRecipe.TabIndex = 0;
			this.tabRecipe.SelectedIndexChanged += new System.EventHandler(this.tabRecipe_SelectedIndexChanged);
			// 
			// pageRecipeSchema
			// 
			this.pageRecipeSchema.Location = new System.Drawing.Point(4, 22);
			this.pageRecipeSchema.Name = "pageRecipeSchema";
			this.pageRecipeSchema.Size = new System.Drawing.Size(784, 500);
			this.pageRecipeSchema.TabIndex = 0;
			this.pageRecipeSchema.Text = "Recipe Schema";
			// 
			// pageRecipeInfo
			// 
			this.pageRecipeInfo.Controls.Add(this._ctrlRecipeInfomation);
			this.pageRecipeInfo.Location = new System.Drawing.Point(4, 22);
			this.pageRecipeInfo.Name = "pageRecipeInfo";
			this.pageRecipeInfo.Size = new System.Drawing.Size(784, 500);
			this.pageRecipeInfo.TabIndex = 1;
			this.pageRecipeInfo.Text = "Recipe Information";
			// 
			// _ctrlRecipeInfomation
			// 
			this._ctrlRecipeInfomation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._ctrlRecipeInfomation.Description = "";
			this._ctrlRecipeInfomation.Location = new System.Drawing.Point(4, 4);
			this._ctrlRecipeInfomation.Name = "_ctrlRecipeInfomation";
			this._ctrlRecipeInfomation.PreviousRecipeKey = -1;
			this._ctrlRecipeInfomation.RecipeList = null;
			this._ctrlRecipeInfomation.RecipeName = "";
			this._ctrlRecipeInfomation.SingatureKey = 0;
			this._ctrlRecipeInfomation.Size = new System.Drawing.Size(780, 252);
			this._ctrlRecipeInfomation.TabIndex = 0;
			// 
			// DlgRecipeProperties
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "DlgRecipeProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recipe Properties";
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabRecipe.ResumeLayout(false);
			this.pageRecipeInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		
		#endregion

		#region UI Command

		private void UpdateData(bool update)
		{
			if(update)
			{
				if(this.Recipe.ReadOnly) return;

				_ctrlRecipe.Recipe.CopyTo(this.Recipe);

				this.Recipe.Name= _ctrlRecipeInfomation.RecipeName;
				this.Recipe.Description=_ctrlRecipeInfomation.Description;
				this.Recipe.SignatureID= _ctrlRecipeInfomation.SingatureKey;
				this.Recipe.SignatureName= _ctrlRecipeInfomation.SingatureName;
				this.Recipe.SignatureCode = _ctrlRecipeInfomation.SignatureCode;
				this.Recipe.PrevRecipeID= _ctrlRecipeInfomation.PreviousRecipeKey;
				this.Recipe.PrevRecipeName= _ctrlRecipeInfomation.PreviousRecipeName;
				this.Recipe.TesterType = _ctrlRecipeInfomation.TesterType;
				this.Recipe.BreakWhenFound = _ctrlRecipeInfomation.Break;
			}
			else
			{
				_ctrlRecipeInfomation.Enabled = !this.Recipe.ReadOnly;

				if(this.Recipe.ReadOnly)
					this.Text += " - ReadOnly";

				_ctrlRecipe.Recipe = this.Recipe.Copy() as DDARecipe.DDARecipe;

				_ctrlRecipeInfomation.RecipeID = this.Recipe.ID;
				_ctrlRecipeInfomation.DisplaySignatureCategoryList();
				_ctrlRecipeInfomation.DisplayTesterTypeList();

				_ctrlRecipeInfomation.TesterType = this.Recipe.TesterType;
				_ctrlRecipeInfomation.RecipeList = this._Recipes;

				_ctrlRecipeInfomation.RecipeName = this.Recipe.Name;
				_ctrlRecipeInfomation.Description = this.Recipe.Description;
				_ctrlRecipeInfomation.SingatureKey = this.Recipe.SignatureID;
				_ctrlRecipeInfomation.PreviousRecipeKey = this.Recipe.PrevRecipeID;

				_ctrlRecipeInfomation.Break = this.Recipe.BreakWhenFound;
			}
		}

		public bool ValidateSyntax()
		{
			string msg = string.Empty;
			if( !_ctrlRecipe.Recipe.ValidateSyntax(ref msg ) )
			{
				MessageBox.Show("Invalidate syntax : " + msg,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
            return true;
		}

		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if( this.ValidateSyntax() )
			{
				this.UpdateData(true);

				Save(this.Recipe);

				DialogResult = DialogResult.OK;
				Close();
			}
		}

		public void Save(DDARecipe.DDARecipe recipe)
		{
			if(recipe==null) return;
			if(recipe.ReadOnly) return;

			try
			{
				if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
					WebServiceProxy.RecipeProxy.DDARecipe xx = WebServiceProxy.ConvertProxy.Convert( obj,  typeof( WebServiceProxy.RecipeProxy.DDARecipe ) ) as WebServiceProxy.RecipeProxy.DDARecipe;
					WebServiceProxy.RecipeProxy.ResultBase result = proxy.InsertRecipe(xx);
					recipe.ID = result.id32;
				}
				else
				{
					SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
					SiGlaz.Common.DDA.Result.ResultBase result = proxy.InsertRecipe(obj);
					recipe.ID = result.id32;
				}
			}
			catch
			{
				MessageBox.Show("Cannot save this recipe.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void tabRecipe_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabRecipe.SelectedTab== pageRecipeInfo)
			{
				_ctrlRecipeInfomation.cboSignature.Enabled = !_ctrlRecipe.Recipe.IsAutoSignatureName();
			}
		}


		#region Windows Events Handles
		
		#endregion
	}
}
