using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DDARMWinUI.Controls;
using DDARMWinUI.Dialogs;
using SiGlaz.Utility;
using SiGlaz.Common.DDA;

namespace DDARMWinUI
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Members

        private System.Windows.Forms.MenuStrip _mainMenu;
		private System.Windows.Forms.ImageList _imgListMainMenu;
		private System.Windows.Forms.ToolStripMenuItem mnuItemFile;
		private System.Windows.Forms.ToolStripMenuItem mnuItemExit;
		private System.Windows.Forms.ToolStripMenuItem mnuItemRecipe;
		private System.Windows.Forms.ToolStripMenuItem mnuItemNewRecipe;
		private System.Windows.Forms.ToolStripMenuItem mnuItemEditRecipe;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDeleteRecipe;
		private System.Windows.Forms.ToolStripMenuItem mnuItemTools;
        private System.Windows.Forms.ToolStripMenuItem mnuItemWebServiceConfiguration;
		private System.Windows.Forms.ToolStripMenuItem mnuItemSignatureCategory;
		private System.Windows.Forms.ToolBar _toolBarMain;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.StatusBar _statusBar;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.ToolBarButton btnDeleteAll;
		private System.Windows.Forms.ToolBarButton btnRun;
		private System.Windows.Forms.ToolBarButton btnStop;
		private System.Windows.Forms.ToolBarButton btnRunAll;
		private System.Windows.Forms.ToolBarButton btnStopAll;
		private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
		private System.Windows.Forms.ToolStripMenuItem menuItemDeleteAll;
		private System.Windows.Forms.ToolStripMenuItem menuItemRun;
		private System.Windows.Forms.ToolStripMenuItem menuItemStop;
		private System.Windows.Forms.ToolStripMenuItem menuItemRunAll;
		private System.Windows.Forms.ToolStripMenuItem menuItemStopAll;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton btnNewRecipe;
		private System.Windows.Forms.ToolBarButton btnEditRecipe;
		private System.Windows.Forms.ToolBarButton btnDeleteRecipe;
		private System.Windows.Forms.ToolBarButton btnRefresh;
		private System.Windows.Forms.ToolStripMenuItem mnuItemPatternLibrary;
		private System.Windows.Forms.ToolStripMenuItem menuItem2;
		private System.Windows.Forms.ToolStripMenuItem menuItem4;
		private System.Windows.Forms.ToolStripMenuItem miImportRecipe;
        private System.Windows.Forms.ToolStripMenuItem miExportRecipe;
        public System.Windows.Forms.ToolStripMenuItem miOptions;
		private System.Windows.Forms.ToolStripMenuItem miImportDDAJobStep;
		private System.Windows.Forms.ToolStripMenuItem miVIEW;
		private System.Windows.Forms.ToolStripMenuItem miShowProcessStep;
		public System.Windows.Forms.ToolStripMenuItem miDefineGrade;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem3;
		private System.ComponentModel.IContainer components;
		#endregion
	
		#region Contructor & Destructor
		public MainForm()
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			InitializeComponent();
			InitializeComponentDynamic();

			EnableVisualStyles(this);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mnuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportDDAJobStep = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemNewRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEditRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRunAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemWebServiceConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSignatureCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPatternLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.miDefineGrade = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.miVIEW = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowProcessStep = new System.Windows.Forms.ToolStripMenuItem();
            this._imgListMainMenu = new System.Windows.Forms.ImageList(this.components);
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._toolBarMain = new System.Windows.Forms.ToolBar();
            this.btnNewRecipe = new System.Windows.Forms.ToolBarButton();
            this.btnEditRecipe = new System.Windows.Forms.ToolBarButton();
            this.btnDeleteRecipe = new System.Windows.Forms.ToolBarButton();
            this.btnDeleteAll = new System.Windows.Forms.ToolBarButton();
            this.btnRefresh = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.btnRun = new System.Windows.Forms.ToolBarButton();
            this.btnStop = new System.Windows.Forms.ToolBarButton();
            this.btnRunAll = new System.Windows.Forms.ToolBarButton();
            this.btnStopAll = new System.Windows.Forms.ToolBarButton();
            this._statusBar = new System.Windows.Forms.StatusBar();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this._mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            // 
            // mnuItemFile
            // 
            this.mnuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportRecipe,
            this.miImportDDAJobStep,
            this.miExportRecipe,
            this.toolStripMenuItem1,
            this.mnuItemExit});
            this.mnuItemFile.Name = "mnuItemFile";
            this.mnuItemFile.Size = new System.Drawing.Size(37, 20);
            this.mnuItemFile.Text = "File";
            // 
            // miImportRecipe
            // 
            this.miImportRecipe.Name = "miImportRecipe";
            this.miImportRecipe.Size = new System.Drawing.Size(177, 22);
            this.miImportRecipe.Text = "Import";
            this.miImportRecipe.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // miImportDDAJobStep
            // 
            this.miImportDDAJobStep.Name = "miImportDDAJobStep";
            this.miImportDDAJobStep.Size = new System.Drawing.Size(177, 22);
            this.miImportDDAJobStep.Text = "Import DDA Job file";
            this.miImportDDAJobStep.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // miExportRecipe
            // 
            this.miExportRecipe.Name = "miExportRecipe";
            this.miExportRecipe.Size = new System.Drawing.Size(177, 22);
            this.miExportRecipe.Text = "Export";
            this.miExportRecipe.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemExit
            // 
            this.mnuItemExit.Name = "mnuItemExit";
            this.mnuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuItemExit.Size = new System.Drawing.Size(177, 22);
            this.mnuItemExit.Text = "E&xit";
            this.mnuItemExit.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemRecipe
            // 
            this.mnuItemRecipe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemNewRecipe,
            this.mnuItemEditRecipe,
            this.mnuItemDeleteRecipe,
            this.menuItemDeleteAll,
            this.menuItemRefresh,
            this.toolStripMenuItem2,
            this.menuItemRun,
            this.menuItemStop,
            this.menuItemRunAll,
            this.menuItemStopAll});
            this.mnuItemRecipe.Name = "mnuItemRecipe";
            this.mnuItemRecipe.Size = new System.Drawing.Size(54, 20);
            this.mnuItemRecipe.Text = "Recipe";
            // 
            // mnuItemNewRecipe
            // 
            this.mnuItemNewRecipe.Image = global::DDARMWinUI.Properties.Resources._0;
            this.mnuItemNewRecipe.Name = "mnuItemNewRecipe";
            this.mnuItemNewRecipe.Size = new System.Drawing.Size(152, 22);
            this.mnuItemNewRecipe.Text = "New";
            this.mnuItemNewRecipe.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemEditRecipe
            // 
            this.mnuItemEditRecipe.Image = global::DDARMWinUI.Properties.Resources._1;
            this.mnuItemEditRecipe.Name = "mnuItemEditRecipe";
            this.mnuItemEditRecipe.Size = new System.Drawing.Size(152, 22);
            this.mnuItemEditRecipe.Text = "Edit";
            this.mnuItemEditRecipe.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemDeleteRecipe
            // 
            this.mnuItemDeleteRecipe.Image = global::DDARMWinUI.Properties.Resources._2;
            this.mnuItemDeleteRecipe.Name = "mnuItemDeleteRecipe";
            this.mnuItemDeleteRecipe.Size = new System.Drawing.Size(152, 22);
            this.mnuItemDeleteRecipe.Text = "Delete";
            this.mnuItemDeleteRecipe.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemDeleteAll
            // 
            this.menuItemDeleteAll.Image = global::DDARMWinUI.Properties.Resources._3;
            this.menuItemDeleteAll.Name = "menuItemDeleteAll";
            this.menuItemDeleteAll.Size = new System.Drawing.Size(152, 22);
            this.menuItemDeleteAll.Text = "Delete All";
            this.menuItemDeleteAll.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Image = global::DDARMWinUI.Properties.Resources._5;
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.menuItemRefresh.Text = "Refresh";
            this.menuItemRefresh.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemRun
            // 
            this.menuItemRun.Image = global::DDARMWinUI.Properties.Resources._6;
            this.menuItemRun.Name = "menuItemRun";
            this.menuItemRun.Size = new System.Drawing.Size(152, 22);
            this.menuItemRun.Text = "Run";
            this.menuItemRun.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Image = global::DDARMWinUI.Properties.Resources._7;
            this.menuItemStop.Name = "menuItemStop";
            this.menuItemStop.Size = new System.Drawing.Size(152, 22);
            this.menuItemStop.Text = "Stop";
            this.menuItemStop.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemRunAll
            // 
            this.menuItemRunAll.Image = global::DDARMWinUI.Properties.Resources._8;
            this.menuItemRunAll.Name = "menuItemRunAll";
            this.menuItemRunAll.Size = new System.Drawing.Size(152, 22);
            this.menuItemRunAll.Text = "Run All";
            this.menuItemRunAll.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItemStopAll
            // 
            this.menuItemStopAll.Image = global::DDARMWinUI.Properties.Resources._9;
            this.menuItemStopAll.Name = "menuItemStopAll";
            this.menuItemStopAll.Size = new System.Drawing.Size(152, 22);
            this.menuItemStopAll.Text = "Stop All";
            this.menuItemStopAll.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemTools
            // 
            this.mnuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemWebServiceConfiguration,
            this.toolStripMenuItem4,
            this.mnuItemSignatureCategory,
            this.mnuItemPatternLibrary,
            this.miDefineGrade,
            this.toolStripMenuItem3,
            this.miOptions});
            this.mnuItemTools.Name = "mnuItemTools";
            this.mnuItemTools.Size = new System.Drawing.Size(48, 20);
            this.mnuItemTools.Text = "Tools";
            // 
            // mnuItemWebServiceConfiguration
            // 
            this.mnuItemWebServiceConfiguration.Name = "mnuItemWebServiceConfiguration";
            this.mnuItemWebServiceConfiguration.Size = new System.Drawing.Size(213, 22);
            this.mnuItemWebServiceConfiguration.Text = "Connection Configuration";
            this.mnuItemWebServiceConfiguration.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemSignatureCategory
            // 
            this.mnuItemSignatureCategory.Name = "mnuItemSignatureCategory";
            this.mnuItemSignatureCategory.Size = new System.Drawing.Size(213, 22);
            this.mnuItemSignatureCategory.Text = "Define Signature";
            this.mnuItemSignatureCategory.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuItemPatternLibrary
            // 
            this.mnuItemPatternLibrary.Name = "mnuItemPatternLibrary";
            this.mnuItemPatternLibrary.Size = new System.Drawing.Size(213, 22);
            this.mnuItemPatternLibrary.Text = "Pattern Library";
            this.mnuItemPatternLibrary.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // miDefineGrade
            // 
            this.miDefineGrade.Name = "miDefineGrade";
            this.miDefineGrade.Size = new System.Drawing.Size(213, 22);
            this.miDefineGrade.Text = "Define Grade";
            this.miDefineGrade.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // miOptions
            // 
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(213, 22);
            this.miOptions.Text = "Options";
            this.miOptions.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem4});
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(44, 20);
            this.menuItem2.Text = "&Help";
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(152, 22);
            this.menuItem4.Text = "&About";
            this.menuItem4.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // miVIEW
            // 
            this.miVIEW.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowProcessStep});
            this.miVIEW.Name = "miVIEW";
            this.miVIEW.Size = new System.Drawing.Size(44, 20);
            this.miVIEW.Text = "View";
            // 
            // miShowProcessStep
            // 
            this.miShowProcessStep.Name = "miShowProcessStep";
            this.miShowProcessStep.Size = new System.Drawing.Size(172, 22);
            this.miShowProcessStep.Text = "Show Process Step";
            this.miShowProcessStep.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // _imgListMainMenu
            // 
            this._imgListMainMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgListMainMenu.ImageStream")));
            this._imgListMainMenu.TransparentColor = System.Drawing.Color.Transparent;
            this._imgListMainMenu.Images.SetKeyName(0, "");
            this._imgListMainMenu.Images.SetKeyName(1, "");
            this._imgListMainMenu.Images.SetKeyName(2, "");
            this._imgListMainMenu.Images.SetKeyName(3, "");
            this._imgListMainMenu.Images.SetKeyName(4, "");
            this._imgListMainMenu.Images.SetKeyName(5, "");
            this._imgListMainMenu.Images.SetKeyName(6, "");
            this._imgListMainMenu.Images.SetKeyName(7, "");
            this._imgListMainMenu.Images.SetKeyName(8, "");
            this._imgListMainMenu.Images.SetKeyName(9, "");
            // 
            // _mainMenu
            // 
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemFile,
            this.mnuItemRecipe,
            this.miVIEW,
            this.mnuItemTools,
            this.menuItem2});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(892, 24);
            this._mainMenu.TabIndex = 3;
            // 
            // _toolBarMain
            // 
            this._toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnNewRecipe,
            this.btnEditRecipe,
            this.btnDeleteRecipe,
            this.btnDeleteAll,
            this.btnRefresh,
            this.toolBarButton1,
            this.btnRun,
            this.btnStop,
            this.btnRunAll,
            this.btnStopAll});
            this._toolBarMain.ButtonSize = new System.Drawing.Size(32, 32);
            this._toolBarMain.DropDownArrows = true;
            this._toolBarMain.ImageList = this._imgListMainMenu;
            this._toolBarMain.Location = new System.Drawing.Point(0, 24);
            this._toolBarMain.Name = "_toolBarMain";
            this._toolBarMain.ShowToolTips = true;
            this._toolBarMain.Size = new System.Drawing.Size(892, 44);
            this._toolBarMain.TabIndex = 0;
            this._toolBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._toolBarMain_ButtonClick);
            // 
            // btnNewRecipe
            // 
            this.btnNewRecipe.ImageIndex = 0;
            this.btnNewRecipe.Name = "btnNewRecipe";
            this.btnNewRecipe.ToolTipText = "New Recipe";
            // 
            // btnEditRecipe
            // 
            this.btnEditRecipe.ImageIndex = 1;
            this.btnEditRecipe.Name = "btnEditRecipe";
            this.btnEditRecipe.ToolTipText = "Edit Selected Recipe";
            // 
            // btnDeleteRecipe
            // 
            this.btnDeleteRecipe.ImageIndex = 2;
            this.btnDeleteRecipe.Name = "btnDeleteRecipe";
            this.btnDeleteRecipe.ToolTipText = "Delete Selected Recipe";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.ImageIndex = 3;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.ToolTipText = "Delete all Recipes";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ToolTipText = "Refresh";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnRun
            // 
            this.btnRun.ImageIndex = 6;
            this.btnRun.Name = "btnRun";
            this.btnRun.ToolTipText = "Run Selected Recipe";
            // 
            // btnStop
            // 
            this.btnStop.ImageIndex = 7;
            this.btnStop.Name = "btnStop";
            this.btnStop.ToolTipText = "Stop Selected Recipe";
            // 
            // btnRunAll
            // 
            this.btnRunAll.ImageIndex = 8;
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.ToolTipText = "Run All Recipes";
            // 
            // btnStopAll
            // 
            this.btnStopAll.ImageIndex = 9;
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.ToolTipText = "Stop All Recipes";
            // 
            // _statusBar
            // 
            this._statusBar.Location = new System.Drawing.Point(0, 450);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Size = new System.Drawing.Size(892, 16);
            this._statusBar.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 68);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(892, 382);
            this.panelMain.TabIndex = 2;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(210, 6);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 466);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this._statusBar);
            this.Controls.Add(this._toolBarMain);
            this.Controls.Add(this._mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region dynamic fields
		private DDARMWinUI.Controls.ctrlRecipeList _ctrlRecipeList;
		#endregion dynamic fields

		#region UI Command

		private bool IsEditAndDelete(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(recipe.IsRunning)
					return false;
			}
			return recipes.Count>0;
		}

		private bool IsRun(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(recipe.IsRunning)
					return false;
			}
			return recipes.Count>0;
		}

		private bool IsStop(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(!recipe.IsRunning)
					return false;
			}
			return recipes.Count>0;
		}

		private bool NoAnyRun(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(recipe.IsRunning)
					return false;
			}
			return true;
		}


        public void UpdateCommandGUISafe()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(UpdateCommandGUI));
            else
                UpdateCommandGUI();
        }

		public void  UpdateCommandGUI()
		{
			//Get Recipe List
			ArrayList recipeList = _ctrlRecipeList.RecipeList;
			ArrayList selectedRecipeList = _ctrlRecipeList.SelectedRecipeList;

			btnNewRecipe.Enabled = mnuItemNewRecipe.Enabled = this.NoAnyRun(recipeList);
			btnRefresh.Enabled = menuItemRefresh.Enabled = true;
			//btnSaveRecipe.Enabled = menuItemSave.Enabled = this.NoAnyRun(recipeList);

			btnEditRecipe.Enabled = mnuItemEditRecipe.Enabled = this.IsEditAndDelete(selectedRecipeList);
			btnDeleteRecipe.Enabled = mnuItemDeleteRecipe.Enabled = this.IsEditAndDelete(selectedRecipeList);
			btnDeleteAll.Enabled = menuItemDeleteAll.Enabled = this.IsEditAndDelete(recipeList);

			btnRun.Enabled = menuItemRun.Enabled = this.IsRun(selectedRecipeList);
			btnStop.Enabled = menuItemStop.Enabled = this.IsStop(selectedRecipeList);
			btnRunAll.Enabled = menuItemRunAll.Enabled = true;
			btnStopAll.Enabled = menuItemStopAll.Enabled = true;

			btnRefresh.Enabled= menuItemRefresh.Enabled = this.NoAnyRun(recipeList);
			mnuItemWebServiceConfiguration.Enabled = this.NoAnyRun(recipeList);
			mnuItemSignatureCategory.Enabled = this.NoAnyRun(recipeList);
			miOptions.Enabled = this.NoAnyRun(recipeList);

			//mnuItemChipCategory.Enabled = this.NoAnyRun(recipeList);
			miImportRecipe.Enabled = this.NoAnyRun(recipeList);
			miImportDDAJobStep.Enabled = this.NoAnyRun(recipeList);
			miExportRecipe.Enabled = this.NoAnyRun(recipeList);
		}

		private void InitializeComponentDynamic()
		{
			this.mnuItemPatternLibrary.Visible = false;

			_ctrlRecipeList = new ctrlRecipeList();
			_ctrlRecipeList.Dock = DockStyle.Fill;
			_ctrlRecipeList.OnStateChange+=new EventHandler(_ctrlRecipeList_OnStateChange);
			this.panelMain.Controls.Add(_ctrlRecipeList);
		}

		protected virtual void EnableVisualStyles(Control ctrl)
		{
			if (ctrl == null)
				return;

			Type type = ctrl.GetType();
			if (type.IsSubclassOf(typeof(ButtonBase)))
				((ButtonBase)ctrl).FlatStyle = FlatStyle.System;

			if (ctrl.Controls.Count > 0)
			{
				foreach (Control childControl in ctrl.Controls)
					EnableVisualStyles(childControl);
			}
		}

		private void ExecuteCmd(string cmd)
		{
			Cursor.Current = Cursors.WaitCursor;

			switch (cmd)
			{
				case "E&xit":
					this.Close();
					break;

				case "New":
				case "New Recipe":
					_ctrlRecipeList.NewRecipe();
					break;

				case "Edit":
				case "Edit Recipe":
				case "Edit Selected Recipe":
					_ctrlRecipeList.EditRecipe();
					break;

				case "Delete":
				case "Delete Recipe":
				case "Delete Selected Recipe":
					_ctrlRecipeList.DeleteRecipe();
					break;

					
				case "Delete All":
				case "Delete all Recipes":
					_ctrlRecipeList.DeleteAll();
					break;

				case "Refresh":
				case "Refresh Recipe":
					_ctrlRecipeList.LoadRecipeList();
					break;

				case "Connection Configuration":
					WebServiceConfiguration();
					break;

				case "Define Signature":
					SignatureCategory();
					break;

				case "Run":
				case "Run Selected Recipe":
					_ctrlRecipeList.Run();
					break;

				case "Stop":
				case "Stop Selected Recipe":
					_ctrlRecipeList.Stop();
					break;

				case "Run All":
				case "Run All Recipes":
					_ctrlRecipeList.RunAll();
					break;

				case "Stop All":
				case "Stop All Recipes":
					_ctrlRecipeList.StopAll();
					break;

				case "&About":
				case "About":
					DlgAbout dlg = new DlgAbout();
					dlg.ShowDialog(this);
					break;

				case "Import":
					_ctrlRecipeList.Import();
					break;

				case "Export":
					_ctrlRecipeList.Export();
					break;

				case "Options":
					Options();
					break;
                    
				case "Import DDA Job file":
					_ctrlRecipeList.ImportDDAJobStep();
					break;

				case "Show Process Step":
                    if (miShowProcessStep.Image == null)
                        miShowProcessStep.Image = global::DDARMWinUI.Properties.Resources._10;
                    else
                        miShowProcessStep.Image = null;

                    ShowProcessStep(this.miShowProcessStep.Image != null);

					break;
					      
				case "Define Grade":
					DefineGrade();
					break;
					
			}
			UpdateCommandGUI();
		}

		private void DefineGrade()
		{
			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			DDARecipe.Dialogs.DlgGrade dlg = new DDARecipe.Dialogs.DlgGrade();
			dlg.Icon = this.Icon;
			dlg.ShowDialog(this);
		}

		private void WebServiceConfiguration()
		{
			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			DDARecipe.Dialogs.DlgWebServiceConfiguration dlg = new DDARecipe.Dialogs.DlgWebServiceConfiguration();
			dlg.Icon = this.Icon;
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				this.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				//	.RefreshCategoryTable();
				_ctrlRecipeList.LoadRecipeList();
			}
		}

		private void SignatureCategory()
		{
			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			DlgDefineSignatures dlg = new DlgDefineSignatures();
			dlg.Icon = this.Icon;
			dlg.ShowDialog(this);
		}

//		private void ChipCategory()
//		{
//			this.Refresh();
//			Cursor.Current = Cursors.WaitCursor;
//			DDARecipe.Dialogs.DlgCategoryGroupTable dlg = new DDARecipe.Dialogs.DlgCategoryGroupTable();
//			dlg.Icon = this.Icon;
//			dlg.ShowDialog(this);
//		}

		
//		private void PatternLibrary()
//		{
//			this.Refresh();
//			Cursor.Current = Cursors.WaitCursor;
//			DDARecipe.Dialogs.DlgPatternLibrary dlg = new DDARecipe.Dialogs.DlgPatternLibrary();
//			dlg.ShowDialog(this);
//		}

		#endregion
		
		#region Windows Events Handles

		private void _ctrlRecipeList_OnStateChange(object sender, EventArgs e)
		{
			UpdateCommandGUISafe();
		}

		private void mnuItem_Click(object sender, System.EventArgs e)
		{
			ExecuteCmd(((ToolStripMenuItem)sender).Text);
		}

		private void _toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ExecuteCmd(e.Button.ToolTipText);		
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			this.Text = Application.ProductName;

			this.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			LoadDefaultGUI();

			_ctrlRecipeList.LoadRecipeList();
			this.UpdateCommandGUI();
		}

		private void LoadDefaultGUI()
		{
            if ((bool)SiGlaz.Common.Configuration.GetValues("SHOW_PROCESS_STEP", false))
            {
                this.miShowProcessStep.Image = global::DDARMWinUI.Properties.Resources._10;
            }
            else
            {
                this.miShowProcessStep.Image = null;
            }
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!this.NoAnyRun(this._ctrlRecipeList.RecipeList))
			{
				this._ctrlRecipeList.StopAll();
			}
//
//			if(_ctrlRecipeList.isSave)
//			{
//				if(MessageBox.Show("Do you want to save changes to recipes ?",Application.ProductName ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
//					_ctrlRecipeList.SaveRecipe();
//			}	
		}

		#endregion

		public void Options()
		{
			DDARecipe.Dialogs.DlgOptions dlg = new DDARecipe.Dialogs.DlgOptions(true,false);
			
			Cursor.Current = Cursors.WaitCursor;
			this.Refresh();

			dlg.LoadData();
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				DDARecipe.DDAExternalData.SaveApplicationData();
			}
		}

		public void ShowProcessStep(bool show)
		{
			SiGlaz.Common.Configuration.SetValues("SHOW_PROCESS_STEP",show);
            _ctrlRecipeList.ShowProcessStep(show);
		}
	
	}
}
