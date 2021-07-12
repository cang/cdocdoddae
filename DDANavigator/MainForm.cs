using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DDANavigator.Dialogs;
using DDANavigator.Controls;
using SiGlaz.Common.DDA;

namespace DDANavigator
{
	public class MainForm : Dialogs.FormBase
	{
		#region Members

        private System.Windows.Forms.ToolBar _toolBar;
		private System.Windows.Forms.ToolBarButton tbDataSource;
		private System.Windows.Forms.ToolBarButton tbSingleSignature;
		private System.Windows.Forms.ToolBarButton tbSignatureOfSurface;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbDDANavigatorHelp;
		private System.Windows.Forms.ToolBarButton tbAboutDDANavigator;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.ImageList _imgLists;
		private DDANavigator.Controls.ctrlDataSourceQuery _ctrlDataSourceQuery;
		private DDANavigator.Controls.ctrlSingleLayerQuery _ctrlSingleLayerQuery;
        private DDANavigator.Controls.ctrlSignatureOfSurfaceQuery _ctrlSignatureOfSurfaceQuery;
		private System.Windows.Forms.ToolBarButton tbSourceOfDisk;
        private DDANavigator.Controls.ctrlSourceOfDiskQuery _ctrlSourceOfDiskQuery;
		private System.Windows.Forms.ToolBarButton tbParetoChart;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private DDANavigator.Controls.ctrlParetoChartQuery _ctrlParetoChartQuery;
        private MenuStrip _menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem queryToolStripMenuItem;
        private ToolStripMenuItem sourceOfSurfaceToolStripMenuItem;
        private ToolStripMenuItem sourceOfDiskToolStripMenuItem;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem singleSignatureToolStripMenuItem;
        private ToolStripMenuItem signatureOfSurfaceToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem signatureParetoChartToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem dDANavigatorHelpToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aboutDDANavigatorToolStripMenuItem;
		private System.ComponentModel.IContainer components;
		#endregion
		
		#region Constructor & Destructor
		public MainForm()
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			InitializeComponent();
			InitConfig();
			ViewFlashScreen();

			_ctrlDataSourceQuery.DisplayFabList();
			_ctrlSingleLayerQuery.DisplayFabList();
			_ctrlSignatureOfSurfaceQuery.DisplayFabList();
			_ctrlSourceOfDiskQuery.DisplayFabList();
			_ctrlParetoChartQuery.DisplayFabList();

			_ctrlDataSourceQuery.OnTimeChanged += new DDANavigator.Controls.TestDateChangedHandler(_ctrlDataSourceQuery_OnTimeChanged);
			_ctrlDataSourceQuery.OnFabIDChanged += new DDANavigator.Controls.FabIDChangedHandler(_ctrlDataSourceQuery_OnFabIDChanged);

			_ctrlSingleLayerQuery.OnTimeChanged += new DDANavigator.Controls.TestDateChangedHandler(_ctrlSingleLayerQuery_OnTimeChanged);
			_ctrlSingleLayerQuery.OnFabIDChanged += new DDANavigator.Controls.FabIDChangedHandler(_ctrlSingleLayerQuery_OnFabIDChanged);

			_ctrlSignatureOfSurfaceQuery.OnTimeChanged += new DDANavigator.Controls.TestDateChangedHandler(_ctrlSignatureOfSurfaceQuery_OnTimeChanged);
			_ctrlSignatureOfSurfaceQuery.OnFabIDChanged += new DDANavigator.Controls.FabIDChangedHandler(_ctrlSignatureOfSurfaceQuery_OnFabIDChanged);

			_ctrlSourceOfDiskQuery.OnTimeChanged += new DDANavigator.Controls.TestDateChangedHandler(_ctrlSourceOfDiskQuery_OnTimeChanged);
			_ctrlSourceOfDiskQuery.OnFabIDChanged += new DDANavigator.Controls.FabIDChangedHandler(_ctrlSourceOfDiskQuery_OnFabIDChanged);

			_ctrlParetoChartQuery.OnTimeChanged += new DDANavigator.Controls.TestDateChangedHandler(_ctrlParetoChartQuery_OnTimeChanged);
			_ctrlParetoChartQuery.OnFabIDChanged += new DDANavigator.Controls.FabIDChangedHandler(_ctrlParetoChartQuery_OnFabIDChanged);

			_ctrlDataSourceQuery.LoadConfig();
			_ctrlSourceOfDiskQuery.LoadConfig();
			_ctrlSingleLayerQuery.LoadConfig();
			_ctrlSignatureOfSurfaceQuery.LoadConfig();
			_ctrlParetoChartQuery.LoadConfig();

            LoadImageMenu();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this._imgLists = new System.Windows.Forms.ImageList(this.components);
            this._toolBar = new System.Windows.Forms.ToolBar();
            this.tbDataSource = new System.Windows.Forms.ToolBarButton();
            this.tbSourceOfDisk = new System.Windows.Forms.ToolBarButton();
            this.tbSingleSignature = new System.Windows.Forms.ToolBarButton();
            this.tbSignatureOfSurface = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbParetoChart = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbDDANavigatorHelp = new System.Windows.Forms.ToolBarButton();
            this.tbAboutDDANavigator = new System.Windows.Forms.ToolBarButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this._ctrlParetoChartQuery = new DDANavigator.Controls.ctrlParetoChartQuery();
            this._ctrlSourceOfDiskQuery = new DDANavigator.Controls.ctrlSourceOfDiskQuery();
            this._ctrlSignatureOfSurfaceQuery = new DDANavigator.Controls.ctrlSignatureOfSurfaceQuery();
            this._ctrlSingleLayerQuery = new DDANavigator.Controls.ctrlSingleLayerQuery();
            this._ctrlDataSourceQuery = new DDANavigator.Controls.ctrlDataSourceQuery();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceOfSurfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceOfDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleSignatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatureOfSurfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.signatureParetoChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDANavigatorHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutDDANavigatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _imgLists
            // 
            this._imgLists.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgLists.ImageStream")));
            this._imgLists.TransparentColor = System.Drawing.Color.Transparent;
            this._imgLists.Images.SetKeyName(0, "");
            this._imgLists.Images.SetKeyName(1, "");
            this._imgLists.Images.SetKeyName(2, "");
            this._imgLists.Images.SetKeyName(3, "");
            this._imgLists.Images.SetKeyName(4, "");
            this._imgLists.Images.SetKeyName(5, "");
            this._imgLists.Images.SetKeyName(6, "");
            this._imgLists.Images.SetKeyName(7, "");
            this._imgLists.Images.SetKeyName(8, "");
            this._imgLists.Images.SetKeyName(9, "");
            // 
            // _toolBar
            // 
            this._toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbDataSource,
            this.tbSourceOfDisk,
            this.tbSingleSignature,
            this.tbSignatureOfSurface,
            this.toolBarButton1,
            this.tbParetoChart,
            this.toolBarButton2,
            this.tbDDANavigatorHelp,
            this.tbAboutDDANavigator});
            this._toolBar.ButtonSize = new System.Drawing.Size(24, 24);
            this._toolBar.DropDownArrows = true;
            this._toolBar.ImageList = this._imgLists;
            this._toolBar.Location = new System.Drawing.Point(0, 24);
            this._toolBar.Name = "_toolBar";
            this._toolBar.ShowToolTips = true;
            this._toolBar.Size = new System.Drawing.Size(867, 36);
            this._toolBar.TabIndex = 0;
            this._toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._toolBar_ButtonClick);
            // 
            // tbDataSource
            // 
            this.tbDataSource.ImageIndex = 7;
            this.tbDataSource.Name = "tbDataSource";
            this.tbDataSource.ToolTipText = "Source of Surface";
            // 
            // tbSourceOfDisk
            // 
            this.tbSourceOfDisk.ImageIndex = 8;
            this.tbSourceOfDisk.Name = "tbSourceOfDisk";
            this.tbSourceOfDisk.ToolTipText = "Source of Disk";
            // 
            // tbSingleSignature
            // 
            this.tbSingleSignature.ImageIndex = 2;
            this.tbSingleSignature.Name = "tbSingleSignature";
            this.tbSingleSignature.ToolTipText = "Single Signature";
            // 
            // tbSignatureOfSurface
            // 
            this.tbSignatureOfSurface.ImageIndex = 3;
            this.tbSignatureOfSurface.Name = "tbSignatureOfSurface";
            this.tbSignatureOfSurface.ToolTipText = "Signature of Surface";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbParetoChart
            // 
            this.tbParetoChart.ImageIndex = 9;
            this.tbParetoChart.Name = "tbParetoChart";
            this.tbParetoChart.ToolTipText = "Signature Pareto Chart";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbDDANavigatorHelp
            // 
            this.tbDDANavigatorHelp.ImageIndex = 5;
            this.tbDDANavigatorHelp.Name = "tbDDANavigatorHelp";
            this.tbDDANavigatorHelp.ToolTipText = "DDA Navigator Help";
            // 
            // tbAboutDDANavigator
            // 
            this.tbAboutDDANavigator.ImageIndex = 6;
            this.tbAboutDDANavigator.Name = "tbAboutDDANavigator";
            this.tbAboutDDANavigator.ToolTipText = "About DDA Navigator";
            // 
            // panelMain
            // 
            this.panelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.BackgroundImage")));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this._ctrlParetoChartQuery);
            this.panelMain.Controls.Add(this._ctrlSourceOfDiskQuery);
            this.panelMain.Controls.Add(this._ctrlSignatureOfSurfaceQuery);
            this.panelMain.Controls.Add(this._ctrlSingleLayerQuery);
            this.panelMain.Controls.Add(this._ctrlDataSourceQuery);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(867, 562);
            this.panelMain.TabIndex = 1;
            // 
            // _ctrlParetoChartQuery
            // 
            this._ctrlParetoChartQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlParetoChartQuery.FabID = "";
            this._ctrlParetoChartQuery.Location = new System.Drawing.Point(0, 0);
            this._ctrlParetoChartQuery.Name = "_ctrlParetoChartQuery";
            this._ctrlParetoChartQuery.Size = new System.Drawing.Size(863, 558);
            this._ctrlParetoChartQuery.TabIndex = 4;
            this._ctrlParetoChartQuery.TimeFilter = ((SiGlaz.Common.DDA.Basic.TimeFilter)(resources.GetObject("_ctrlParetoChartQuery.TimeFilter")));
            this._ctrlParetoChartQuery.Visible = false;
            // 
            // _ctrlSourceOfDiskQuery
            // 
            this._ctrlSourceOfDiskQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlSourceOfDiskQuery.FabID = "";
            this._ctrlSourceOfDiskQuery.Location = new System.Drawing.Point(0, 0);
            this._ctrlSourceOfDiskQuery.Name = "_ctrlSourceOfDiskQuery";
            this._ctrlSourceOfDiskQuery.Size = new System.Drawing.Size(863, 558);
            this._ctrlSourceOfDiskQuery.TabIndex = 3;
            this._ctrlSourceOfDiskQuery.TimeFilter = ((SiGlaz.Common.DDA.Basic.TimeFilter)(resources.GetObject("_ctrlSourceOfDiskQuery.TimeFilter")));
            this._ctrlSourceOfDiskQuery.Visible = false;
            // 
            // _ctrlSignatureOfSurfaceQuery
            // 
            this._ctrlSignatureOfSurfaceQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlSignatureOfSurfaceQuery.FabID = "";
            this._ctrlSignatureOfSurfaceQuery.Location = new System.Drawing.Point(0, 0);
            this._ctrlSignatureOfSurfaceQuery.Name = "_ctrlSignatureOfSurfaceQuery";
            this._ctrlSignatureOfSurfaceQuery.Size = new System.Drawing.Size(863, 558);
            this._ctrlSignatureOfSurfaceQuery.TabIndex = 2;
            this._ctrlSignatureOfSurfaceQuery.TimeFilter = ((SiGlaz.Common.DDA.Basic.TimeFilter)(resources.GetObject("_ctrlSignatureOfSurfaceQuery.TimeFilter")));
            this._ctrlSignatureOfSurfaceQuery.Visible = false;
            // 
            // _ctrlSingleLayerQuery
            // 
            this._ctrlSingleLayerQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlSingleLayerQuery.FabID = "";
            this._ctrlSingleLayerQuery.Location = new System.Drawing.Point(0, 0);
            this._ctrlSingleLayerQuery.Name = "_ctrlSingleLayerQuery";
            this._ctrlSingleLayerQuery.Size = new System.Drawing.Size(863, 558);
            this._ctrlSingleLayerQuery.TabIndex = 1;
            this._ctrlSingleLayerQuery.TimeFilter = ((SiGlaz.Common.DDA.Basic.TimeFilter)(resources.GetObject("_ctrlSingleLayerQuery.TimeFilter")));
            this._ctrlSingleLayerQuery.Visible = false;
            // 
            // _ctrlDataSourceQuery
            // 
            this._ctrlDataSourceQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlDataSourceQuery.FabID = "";
            this._ctrlDataSourceQuery.Location = new System.Drawing.Point(0, 0);
            this._ctrlDataSourceQuery.Name = "_ctrlDataSourceQuery";
            this._ctrlDataSourceQuery.Size = new System.Drawing.Size(863, 558);
            this._ctrlDataSourceQuery.TabIndex = 0;
            this._ctrlDataSourceQuery.TimeFilter = ((SiGlaz.Common.DDA.Basic.TimeFilter)(resources.GetObject("_ctrlDataSourceQuery.TimeFilter")));
            this._ctrlDataSourceQuery.Visible = false;
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(867, 24);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Tag = "0";
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceOfSurfaceToolStripMenuItem,
            this.sourceOfDiskToolStripMenuItem,
            this.singleSignatureToolStripMenuItem,
            this.signatureOfSurfaceToolStripMenuItem,
            this.toolStripSeparator1,
            this.signatureParetoChartToolStripMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.queryToolStripMenuItem.Text = "&Query";
            // 
            // sourceOfSurfaceToolStripMenuItem
            // 
            this.sourceOfSurfaceToolStripMenuItem.Name = "sourceOfSurfaceToolStripMenuItem";
            this.sourceOfSurfaceToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sourceOfSurfaceToolStripMenuItem.Tag = "7";
            this.sourceOfSurfaceToolStripMenuItem.Text = "&Source of Surface";
            this.sourceOfSurfaceToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // sourceOfDiskToolStripMenuItem
            // 
            this.sourceOfDiskToolStripMenuItem.Name = "sourceOfDiskToolStripMenuItem";
            this.sourceOfDiskToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sourceOfDiskToolStripMenuItem.Tag = "1";
            this.sourceOfDiskToolStripMenuItem.Text = "Source of &Disk";
            this.sourceOfDiskToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // singleSignatureToolStripMenuItem
            // 
            this.singleSignatureToolStripMenuItem.Name = "singleSignatureToolStripMenuItem";
            this.singleSignatureToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.singleSignatureToolStripMenuItem.Tag = "2";
            this.singleSignatureToolStripMenuItem.Text = "Si&ngle Signature";
            this.singleSignatureToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // signatureOfSurfaceToolStripMenuItem
            // 
            this.signatureOfSurfaceToolStripMenuItem.Name = "signatureOfSurfaceToolStripMenuItem";
            this.signatureOfSurfaceToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.signatureOfSurfaceToolStripMenuItem.Tag = "3";
            this.signatureOfSurfaceToolStripMenuItem.Text = "S&ignature of Surface";
            this.signatureOfSurfaceToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // signatureParetoChartToolStripMenuItem
            // 
            this.signatureParetoChartToolStripMenuItem.Name = "signatureParetoChartToolStripMenuItem";
            this.signatureParetoChartToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.signatureParetoChartToolStripMenuItem.Tag = "9";
            this.signatureParetoChartToolStripMenuItem.Text = "Signature &Pareto Chart";
            this.signatureParetoChartToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Tag = "4";
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDANavigatorHelpToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutDDANavigatorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // dDANavigatorHelpToolStripMenuItem
            // 
            this.dDANavigatorHelpToolStripMenuItem.Name = "dDANavigatorHelpToolStripMenuItem";
            this.dDANavigatorHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.dDANavigatorHelpToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.dDANavigatorHelpToolStripMenuItem.Tag = "5";
            this.dDANavigatorHelpToolStripMenuItem.Text = "DDA Navigator Help";
            this.dDANavigatorHelpToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // aboutDDANavigatorToolStripMenuItem
            // 
            this.aboutDDANavigatorToolStripMenuItem.Name = "aboutDDANavigatorToolStripMenuItem";
            this.aboutDDANavigatorToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutDDANavigatorToolStripMenuItem.Tag = "6";
            this.aboutDDANavigatorToolStripMenuItem.Text = "&About DDA Navigator";
            this.aboutDDANavigatorToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(867, 622);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.Text = "DDA Navigator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.panelMain.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Main
		[STAThread]
		static void Main()
		{
//			if(DDAEnterpriseLook.Begin(1,"DDANAV")==false)
//				return;

			Application.Run(new MainForm());

//			DDAEnterpriseLook.End();
		}
		#endregion

		#region UI Command
		private void ViewFlashScreen()
		{
			DlgFlashScreen dlg = new DlgFlashScreen();
			dlg.ShowDialog(this);
			dlg.TopMost=true;
		}

		private void ExecuteCmd(string cmd)
		{
			Cursor.Current = Cursors.WaitCursor;

			switch (cmd)
			{
				case "&Exit":
					this.Close();
					break;

				case "&Source of Surface":
				case "Source of Surface":
					OnSourceOfSurface();
					break;
					
				case "Si&ngle Signature":
				case "Single Signature":
					OnSingleSignature();
					break;

				case "S&ignature of Surface":
				case "Signature of Surface":
					OnSignatureOfSurface();
					break;

				case "&Options...":
					OnOption();
					break;

				case "DDA Navigator Help":
					OnHelp();
					break;

				case "&About DDA Navigator":
				case "About DDA Navigator":
					OnAbout();
					break;

				case "Source of &Disk":
				case "Source of Disk":
					OnSourceOfDisk();
					break;

				case "Signature &Pareto Chart":
				case "Signature Pareto Chart":
					OnParetoChart();
					break;
			}
		}

		private void InitConfig()
		{
			if (!System.IO.Directory.Exists(AppData.ApplicationDataPath))
				System.IO.Directory.CreateDirectory(AppData.ApplicationDataPath);

			if (!System.IO.Directory.Exists(AppData.CommonApplicationDataPath))
				System.IO.Directory.CreateDirectory(AppData.CommonApplicationDataPath);

			AppData.Data.LoadApplicationData(System.IO.Path.Combine(AppData.ApplicationDataPath, "App.config"));
		}

		private void SetTitle(string functionName)
		{
			this.Text = string.Format("{0} - {1}", Application.ProductName, functionName);
		}

		private void SelectView(Control view)
		{
			view.Visible = true;

			foreach(Control ctrl in this.panelMain.Controls)
			{
				if(ctrl!=view)
				{
					ctrl.Visible = false;
				}
			}
		}

		private void SetTableLayoutConfig()
		{
			Control ctrl = GetActiveControl();
			if (ctrl == null) return;

			if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlDataSourceQuery))
			{
				((DDANavigator.Controls.ctrlDataSourceQuery)ctrl).SetTableLayoutConfig();
				_ctrlSourceOfDiskQuery.GetTableLayoutConfig();
				_ctrlSingleLayerQuery.GetTableLayoutConfig();
				_ctrlSignatureOfSurfaceQuery.GetTableLayoutConfig();
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSourceOfDiskQuery))
			{
				((DDANavigator.Controls.ctrlSourceOfDiskQuery)ctrl).SetTableLayoutConfig();
				_ctrlDataSourceQuery.GetTableLayoutConfig();
				_ctrlSingleLayerQuery.GetTableLayoutConfig();
				_ctrlSignatureOfSurfaceQuery.GetTableLayoutConfig();
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSingleLayerQuery))
			{
				((DDANavigator.Controls.ctrlSingleLayerQuery)ctrl).SetTableLayoutConfig();
				_ctrlDataSourceQuery.GetTableLayoutConfig();
				_ctrlSourceOfDiskQuery.GetTableLayoutConfig();
				_ctrlSignatureOfSurfaceQuery.GetTableLayoutConfig();
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSignatureOfSurfaceQuery))
			{
				((DDANavigator.Controls.ctrlSignatureOfSurfaceQuery)ctrl).SetTableLayoutConfig();
				_ctrlDataSourceQuery.GetTableLayoutConfig();
				_ctrlSourceOfDiskQuery.GetTableLayoutConfig();
				_ctrlSingleLayerQuery.GetTableLayoutConfig();
			}
		}

		public Control GetActiveControl()
		{
			foreach(Control ctrl in this.panelMain.Controls)
			{
				if (ctrl.Visible == true)
					return ctrl;
			}

			return null;
		}

        public void LoadImageMenu()
        {
            foreach (ToolStripMenuItem item in _menuStrip.Items)
            {
                LoadImageMenu(item, _imgLists);
            }
        }

        public void LoadImageMenu(ToolStripMenuItem item, ImageList imgList)
        {
            if (item.Tag != null)
            {
                int index = Convert.ToInt32(item.Tag);
                item.Image = imgList.Images[index];

            }

            if (item.DropDownItems.Count > 0)
            {
                for (int i = 0; i < item.DropDownItems.Count; i++)
                {
                    if (item.DropDownItems[i].GetType() != typeof(ToolStripSeparator))
                        LoadImageMenu((ToolStripMenuItem)item.DropDownItems[i], imgList);
                }
            }
        }
		#endregion

		#region Query
		private void SetDataFilterCondition()
		{
			Control ctrl = GetActiveControl();

			if (ctrl == null) return;

			if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlDataSourceQuery))
			{
				#region Data Source
				ctrlDataSourceQuery ctrlDataSource = (ctrlDataSourceQuery)ctrl;
	
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskID = ctrlDataSource.CtrlDataFilterCondition.DiskID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskTypeID = ctrlDataSource.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotNo = ctrlDataSource.CtrlDataFilterCondition.LotNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotIDCode = ctrlDataSource.CtrlDataFilterCondition.LotIDCode;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.CassetteID = ctrlDataSource.CtrlDataFilterCondition.CassetteID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.Station = ctrlDataSource.CtrlDataFilterCondition.Station;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.WordCellID = ctrlDataSource.CtrlDataFilterCondition.WordCellID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.SlotNoType = ctrlDataSource.CtrlDataFilterCondition.SlotNoType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TestGrade = ctrlDataSource.CtrlDataFilterCondition.TestGrade;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.IRISBinNo = ctrlDataSource.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TesterType = ctrlDataSource.CtrlDataFilterCondition.TesterType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceType = ctrlDataSource.CtrlDataFilterCondition.ResourceType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceID = ctrlDataSource.CtrlDataFilterCondition.ResourceID;


				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskID = ctrlDataSource.CtrlDataFilterCondition.DiskID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskTypeID = ctrlDataSource.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotNo = ctrlDataSource.CtrlDataFilterCondition.LotNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotIDCode = ctrlDataSource.CtrlDataFilterCondition.LotIDCode;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.CassetteID = ctrlDataSource.CtrlDataFilterCondition.CassetteID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.Station = ctrlDataSource.CtrlDataFilterCondition.Station;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.WordCellID = ctrlDataSource.CtrlDataFilterCondition.WordCellID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SlotNoType = ctrlDataSource.CtrlDataFilterCondition.SlotNoType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TestGrade = ctrlDataSource.CtrlDataFilterCondition.TestGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.IRISBinNo = ctrlDataSource.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TesterType = ctrlDataSource.CtrlDataFilterCondition.TesterType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceType = ctrlDataSource.CtrlDataFilterCondition.ResourceType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceID = ctrlDataSource.CtrlDataFilterCondition.ResourceID;

				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskID = ctrlDataSource.CtrlDataFilterCondition.DiskID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlDataSource.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotNo = ctrlDataSource.CtrlDataFilterCondition.LotNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotIDCode = ctrlDataSource.CtrlDataFilterCondition.LotIDCode;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.CassetteID = ctrlDataSource.CtrlDataFilterCondition.CassetteID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.Station = ctrlDataSource.CtrlDataFilterCondition.Station;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.WordCellID = ctrlDataSource.CtrlDataFilterCondition.WordCellID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SlotNoType = ctrlDataSource.CtrlDataFilterCondition.SlotNoType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TestGrade = ctrlDataSource.CtrlDataFilterCondition.TestGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlDataSource.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TesterType = ctrlDataSource.CtrlDataFilterCondition.TesterType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceType = ctrlDataSource.CtrlDataFilterCondition.ResourceType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceID = ctrlDataSource.CtrlDataFilterCondition.ResourceID;

				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskID = ctrlDataSource.CtrlDataFilterCondition.DiskID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskTypeID = ctrlDataSource.CtrlDataFilterCondition.DiskTypeID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotNo = ctrlDataSource.CtrlDataFilterCondition.LotNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotIDCode = ctrlDataSource.CtrlDataFilterCondition.LotIDCode;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.CassetteID = ctrlDataSource.CtrlDataFilterCondition.CassetteID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.Station = ctrlDataSource.CtrlDataFilterCondition.Station;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.WordCellID = ctrlDataSource.CtrlDataFilterCondition.WordCellID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SlotNoType = ctrlDataSource.CtrlDataFilterCondition.SlotNoType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TestGrade = ctrlDataSource.CtrlDataFilterCondition.TestGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.IRISBinNo = ctrlDataSource.CtrlDataFilterCondition.IRISBinNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TesterType = ctrlDataSource.CtrlDataFilterCondition.TesterType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceType = ctrlDataSource.CtrlDataFilterCondition.ResourceType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceID = ctrlDataSource.CtrlDataFilterCondition.ResourceID;
				#endregion
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSourceOfDiskQuery))
			{
				#region Source of Disk
				ctrlSourceOfDiskQuery ctrlSourceOfDisk = (ctrlSourceOfDiskQuery)ctrl;

				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskTypeID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotNo = ctrlSourceOfDisk.CtrlDataFilterCondition.LotNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotIDCode = ctrlSourceOfDisk.CtrlDataFilterCondition.LotIDCode;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.CassetteID = ctrlSourceOfDisk.CtrlDataFilterCondition.CassetteID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.Station = ctrlSourceOfDisk.CtrlDataFilterCondition.Station;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.WordCellID = ctrlSourceOfDisk.CtrlDataFilterCondition.WordCellID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.SlotNoType = ctrlSourceOfDisk.CtrlDataFilterCondition.SlotNoType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TestGrade = ctrlSourceOfDisk.CtrlDataFilterCondition.TestGrade;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSourceOfDisk.CtrlDataFilterCondition.IRISBinNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TesterType = ctrlSourceOfDisk.CtrlDataFilterCondition.TesterType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceType = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceID = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceID;

				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotNo = ctrlSourceOfDisk.CtrlDataFilterCondition.LotNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotIDCode = ctrlSourceOfDisk.CtrlDataFilterCondition.LotIDCode;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.CassetteID = ctrlSourceOfDisk.CtrlDataFilterCondition.CassetteID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.Station = ctrlSourceOfDisk.CtrlDataFilterCondition.Station;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.WordCellID = ctrlSourceOfDisk.CtrlDataFilterCondition.WordCellID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SlotNoType = ctrlSourceOfDisk.CtrlDataFilterCondition.SlotNoType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TestGrade = ctrlSourceOfDisk.CtrlDataFilterCondition.TestGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSourceOfDisk.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TesterType = ctrlSourceOfDisk.CtrlDataFilterCondition.TesterType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceType = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceID = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceID;

				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotNo = ctrlSourceOfDisk.CtrlDataFilterCondition.LotNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotIDCode = ctrlSourceOfDisk.CtrlDataFilterCondition.LotIDCode;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.CassetteID = ctrlSourceOfDisk.CtrlDataFilterCondition.CassetteID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.Station = ctrlSourceOfDisk.CtrlDataFilterCondition.Station;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.WordCellID = ctrlSourceOfDisk.CtrlDataFilterCondition.WordCellID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SlotNoType = ctrlSourceOfDisk.CtrlDataFilterCondition.SlotNoType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TestGrade = ctrlSourceOfDisk.CtrlDataFilterCondition.TestGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSourceOfDisk.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TesterType = ctrlSourceOfDisk.CtrlDataFilterCondition.TesterType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceType = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceID = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceID;

				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSourceOfDisk.CtrlDataFilterCondition.DiskTypeID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotNo = ctrlSourceOfDisk.CtrlDataFilterCondition.LotNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotIDCode = ctrlSourceOfDisk.CtrlDataFilterCondition.LotIDCode;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.CassetteID = ctrlSourceOfDisk.CtrlDataFilterCondition.CassetteID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.Station = ctrlSourceOfDisk.CtrlDataFilterCondition.Station;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.WordCellID = ctrlSourceOfDisk.CtrlDataFilterCondition.WordCellID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SlotNoType = ctrlSourceOfDisk.CtrlDataFilterCondition.SlotNoType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TestGrade = ctrlSourceOfDisk.CtrlDataFilterCondition.TestGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSourceOfDisk.CtrlDataFilterCondition.IRISBinNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TesterType = ctrlSourceOfDisk.CtrlDataFilterCondition.TesterType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceType = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceID = ctrlSourceOfDisk.CtrlDataFilterCondition.ResourceID;
				#endregion
				
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSingleLayerQuery))
			{
				#region Single Layer
				ctrlSingleLayerQuery ctrlSingleLayer = (ctrlSingleLayerQuery)ctrl;

				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskID = ctrlSingleLayer.CtrlDataFilterCondition.DiskID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSingleLayer.CtrlDataFilterCondition.DiskTypeID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotNo = ctrlSingleLayer.CtrlDataFilterCondition.LotNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotIDCode = ctrlSingleLayer.CtrlDataFilterCondition.LotIDCode;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.CassetteID = ctrlSingleLayer.CtrlDataFilterCondition.CassetteID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.Station = ctrlSingleLayer.CtrlDataFilterCondition.Station;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.WordCellID = ctrlSingleLayer.CtrlDataFilterCondition.WordCellID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.SlotNoType = ctrlSingleLayer.CtrlDataFilterCondition.SlotNoType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TestGrade = ctrlSingleLayer.CtrlDataFilterCondition.TestGrade;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSingleLayer.CtrlDataFilterCondition.IRISBinNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TesterType = ctrlSingleLayer.CtrlDataFilterCondition.TesterType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceType = ctrlSingleLayer.CtrlDataFilterCondition.ResourceType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceID = ctrlSingleLayer.CtrlDataFilterCondition.ResourceID;

				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskID = ctrlSingleLayer.CtrlDataFilterCondition.DiskID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSingleLayer.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotNo = ctrlSingleLayer.CtrlDataFilterCondition.LotNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotIDCode = ctrlSingleLayer.CtrlDataFilterCondition.LotIDCode;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.CassetteID = ctrlSingleLayer.CtrlDataFilterCondition.CassetteID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.Station = ctrlSingleLayer.CtrlDataFilterCondition.Station;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.WordCellID = ctrlSingleLayer.CtrlDataFilterCondition.WordCellID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.SlotNoType = ctrlSingleLayer.CtrlDataFilterCondition.SlotNoType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TestGrade = ctrlSingleLayer.CtrlDataFilterCondition.TestGrade;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSingleLayer.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TesterType = ctrlSingleLayer.CtrlDataFilterCondition.TesterType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceType = ctrlSingleLayer.CtrlDataFilterCondition.ResourceType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceID = ctrlSingleLayer.CtrlDataFilterCondition.ResourceID;

				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskID = ctrlSingleLayer.CtrlDataFilterCondition.DiskID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSingleLayer.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotNo = ctrlSingleLayer.CtrlDataFilterCondition.LotNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotIDCode = ctrlSingleLayer.CtrlDataFilterCondition.LotIDCode;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.CassetteID = ctrlSingleLayer.CtrlDataFilterCondition.CassetteID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.Station = ctrlSingleLayer.CtrlDataFilterCondition.Station;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.WordCellID = ctrlSingleLayer.CtrlDataFilterCondition.WordCellID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SlotNoType = ctrlSingleLayer.CtrlDataFilterCondition.SlotNoType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TestGrade = ctrlSingleLayer.CtrlDataFilterCondition.TestGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSingleLayer.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TesterType = ctrlSingleLayer.CtrlDataFilterCondition.TesterType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SignatureName = ctrlSingleLayer.CtrlDataFilterCondition.SignatureName;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DDAGrade = ctrlSingleLayer.CtrlDataFilterCondition.DDAGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceType = ctrlSingleLayer.CtrlDataFilterCondition.ResourceType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceID = ctrlSingleLayer.CtrlDataFilterCondition.ResourceID;

				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskID = ctrlSingleLayer.CtrlDataFilterCondition.DiskID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSingleLayer.CtrlDataFilterCondition.DiskTypeID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotNo = ctrlSingleLayer.CtrlDataFilterCondition.LotNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotIDCode = ctrlSingleLayer.CtrlDataFilterCondition.LotIDCode;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.CassetteID = ctrlSingleLayer.CtrlDataFilterCondition.CassetteID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.Station = ctrlSingleLayer.CtrlDataFilterCondition.Station;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.WordCellID = ctrlSingleLayer.CtrlDataFilterCondition.WordCellID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SlotNoType = ctrlSingleLayer.CtrlDataFilterCondition.SlotNoType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TestGrade = ctrlSingleLayer.CtrlDataFilterCondition.TestGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSingleLayer.CtrlDataFilterCondition.IRISBinNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TesterType = ctrlSingleLayer.CtrlDataFilterCondition.TesterType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SignatureName = ctrlSingleLayer.CtrlDataFilterCondition.SignatureName;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DDAGrade = ctrlSingleLayer.CtrlDataFilterCondition.DDAGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceType = ctrlSingleLayer.CtrlDataFilterCondition.ResourceType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceID = ctrlSingleLayer.CtrlDataFilterCondition.ResourceID;
				#endregion
			}
			else if (ctrl.GetType() == typeof(DDANavigator.Controls.ctrlSignatureOfSurfaceQuery))
			{
				#region Signature of Surface
				ctrlSignatureOfSurfaceQuery ctrlSignatureOfSurface = (ctrlSignatureOfSurfaceQuery)ctrl;

				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskTypeID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotIDCode = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotIDCode;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.CassetteID = ctrlSignatureOfSurface.CtrlDataFilterCondition.CassetteID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.Station = ctrlSignatureOfSurface.CtrlDataFilterCondition.Station;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.WordCellID = ctrlSignatureOfSurface.CtrlDataFilterCondition.WordCellID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.SlotNoType = ctrlSignatureOfSurface.CtrlDataFilterCondition.SlotNoType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TestGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.TestGrade;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.IRISBinNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TesterType = ctrlSignatureOfSurface.CtrlDataFilterCondition.TesterType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceType = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceID = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceID;

				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotIDCode = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotIDCode;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.CassetteID = ctrlSignatureOfSurface.CtrlDataFilterCondition.CassetteID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.Station = ctrlSignatureOfSurface.CtrlDataFilterCondition.Station;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.WordCellID = ctrlSignatureOfSurface.CtrlDataFilterCondition.WordCellID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.SlotNoType = ctrlSignatureOfSurface.CtrlDataFilterCondition.SlotNoType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TestGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.TestGrade;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TesterType = ctrlSignatureOfSurface.CtrlDataFilterCondition.TesterType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceType = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceID = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceID;

				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotIDCode = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotIDCode;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.CassetteID = ctrlSignatureOfSurface.CtrlDataFilterCondition.CassetteID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.Station = ctrlSignatureOfSurface.CtrlDataFilterCondition.Station;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.WordCellID = ctrlSignatureOfSurface.CtrlDataFilterCondition.WordCellID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SlotNoType = ctrlSignatureOfSurface.CtrlDataFilterCondition.SlotNoType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TestGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.TestGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TesterType = ctrlSignatureOfSurface.CtrlDataFilterCondition.TesterType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SignatureName = ctrlSignatureOfSurface.CtrlDataFilterCondition.SignatureName;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DDAGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.DDAGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceType = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceID = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceID;

				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DiskTypeID = ctrlSignatureOfSurface.CtrlDataFilterCondition.DiskTypeID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.LotIDCode = ctrlSignatureOfSurface.CtrlDataFilterCondition.LotIDCode;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.CassetteID = ctrlSignatureOfSurface.CtrlDataFilterCondition.CassetteID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.Station = ctrlSignatureOfSurface.CtrlDataFilterCondition.Station;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.WordCellID = ctrlSignatureOfSurface.CtrlDataFilterCondition.WordCellID;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SlotNoType = ctrlSignatureOfSurface.CtrlDataFilterCondition.SlotNoType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TestGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.TestGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.IRISBinNo = ctrlSignatureOfSurface.CtrlDataFilterCondition.IRISBinNo;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.TesterType = ctrlSignatureOfSurface.CtrlDataFilterCondition.TesterType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.SignatureName = ctrlSignatureOfSurface.CtrlDataFilterCondition.SignatureName;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.DDAGrade = ctrlSignatureOfSurface.CtrlDataFilterCondition.DDAGrade;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceType = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceType;
				_ctrlParetoChartQuery.CtrlDataFilterCondition.ResourceID = ctrlSignatureOfSurface.CtrlDataFilterCondition.ResourceID;
				#endregion
			}
			else
			{
				#region Pareto Chart
				ctrlParetoChartQuery ctrlParetoChart = (ctrlParetoChartQuery)ctrl;

				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskID = ctrlParetoChart.CtrlDataFilterCondition.DiskID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlParetoChart.CtrlDataFilterCondition.DiskTypeID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotNo = ctrlParetoChart.CtrlDataFilterCondition.LotNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.LotIDCode = ctrlParetoChart.CtrlDataFilterCondition.LotIDCode;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.CassetteID = ctrlParetoChart.CtrlDataFilterCondition.CassetteID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.Station = ctrlParetoChart.CtrlDataFilterCondition.Station;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.WordCellID = ctrlParetoChart.CtrlDataFilterCondition.WordCellID;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.SlotNoType = ctrlParetoChart.CtrlDataFilterCondition.SlotNoType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TestGrade = ctrlParetoChart.CtrlDataFilterCondition.TestGrade;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlParetoChart.CtrlDataFilterCondition.IRISBinNo;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.TesterType = ctrlParetoChart.CtrlDataFilterCondition.TesterType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceType = ctrlParetoChart.CtrlDataFilterCondition.ResourceType;
				_ctrlDataSourceQuery.CtrlDataFilterCondition.ResourceID = ctrlParetoChart.CtrlDataFilterCondition.ResourceID;

				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskID = ctrlParetoChart.CtrlDataFilterCondition.DiskID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.DiskTypeID = ctrlParetoChart.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotNo = ctrlParetoChart.CtrlDataFilterCondition.LotNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.LotIDCode = ctrlParetoChart.CtrlDataFilterCondition.LotIDCode;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.CassetteID = ctrlParetoChart.CtrlDataFilterCondition.CassetteID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.Station = ctrlParetoChart.CtrlDataFilterCondition.Station;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.WordCellID = ctrlParetoChart.CtrlDataFilterCondition.WordCellID;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.SlotNoType = ctrlParetoChart.CtrlDataFilterCondition.SlotNoType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TestGrade = ctrlParetoChart.CtrlDataFilterCondition.TestGrade;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.IRISBinNo = ctrlParetoChart.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.TesterType = ctrlParetoChart.CtrlDataFilterCondition.TesterType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceType = ctrlParetoChart.CtrlDataFilterCondition.ResourceType;
				_ctrlSourceOfDiskQuery.CtrlDataFilterCondition.ResourceID = ctrlParetoChart.CtrlDataFilterCondition.ResourceID;

				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskID = ctrlParetoChart.CtrlDataFilterCondition.DiskID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DiskTypeID = ctrlParetoChart.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotNo = ctrlParetoChart.CtrlDataFilterCondition.LotNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.LotIDCode = ctrlParetoChart.CtrlDataFilterCondition.LotIDCode;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.CassetteID = ctrlParetoChart.CtrlDataFilterCondition.CassetteID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.Station = ctrlParetoChart.CtrlDataFilterCondition.Station;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.WordCellID = ctrlParetoChart.CtrlDataFilterCondition.WordCellID;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SlotNoType = ctrlParetoChart.CtrlDataFilterCondition.SlotNoType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TestGrade = ctrlParetoChart.CtrlDataFilterCondition.TestGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.IRISBinNo = ctrlParetoChart.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.TesterType = ctrlParetoChart.CtrlDataFilterCondition.TesterType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.SignatureName = ctrlParetoChart.CtrlDataFilterCondition.SignatureName;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.DDAGrade = ctrlParetoChart.CtrlDataFilterCondition.DDAGrade;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceType = ctrlParetoChart.CtrlDataFilterCondition.ResourceType;
				_ctrlSingleLayerQuery.CtrlDataFilterCondition.ResourceID = ctrlParetoChart.CtrlDataFilterCondition.ResourceID;

				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskID = ctrlParetoChart.CtrlDataFilterCondition.DiskID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DiskTypeID = ctrlParetoChart.CtrlDataFilterCondition.DiskTypeID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotNo = ctrlParetoChart.CtrlDataFilterCondition.LotNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.LotIDCode = ctrlParetoChart.CtrlDataFilterCondition.LotIDCode;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.CassetteID = ctrlParetoChart.CtrlDataFilterCondition.CassetteID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.Station = ctrlParetoChart.CtrlDataFilterCondition.Station;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.WordCellID = ctrlParetoChart.CtrlDataFilterCondition.WordCellID;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SlotNoType = ctrlParetoChart.CtrlDataFilterCondition.SlotNoType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TestGrade = ctrlParetoChart.CtrlDataFilterCondition.TestGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.IRISBinNo = ctrlParetoChart.CtrlDataFilterCondition.IRISBinNo;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.TesterType = ctrlParetoChart.CtrlDataFilterCondition.TesterType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.SignatureName = ctrlParetoChart.CtrlDataFilterCondition.SignatureName;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.DDAGrade = ctrlParetoChart.CtrlDataFilterCondition.DDAGrade;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceType = ctrlParetoChart.CtrlDataFilterCondition.ResourceType;
				_ctrlSignatureOfSurfaceQuery.CtrlDataFilterCondition.ResourceID = ctrlParetoChart.CtrlDataFilterCondition.ResourceID;
				#endregion
			}
		}

		private void OnSourceOfSurface()
		{
			SetTitle("Source of Surface Query");
			_ctrlDataSourceQuery.DisplayFabList();
			SetDataFilterCondition();
			SetTableLayoutConfig();
			SelectView(_ctrlDataSourceQuery);
		}

		private void OnSourceOfDisk()
		{
			SetTitle("Source of Disk Query");
			_ctrlSourceOfDiskQuery.DisplayFabList();
			SetDataFilterCondition();			
			SetTableLayoutConfig();
			SelectView(_ctrlSourceOfDiskQuery);
		}

		private void OnSingleSignature()
		{
			SetTitle("Single Signature Query");
			_ctrlSingleLayerQuery.DisplayFabList();
			SetDataFilterCondition();			
			SetTableLayoutConfig();
			SelectView(_ctrlSingleLayerQuery);
		}

		private void OnSignatureOfSurface()
		{
			SetTitle("Signature of Surface Query");
			_ctrlSignatureOfSurfaceQuery.DisplayFabList();
			SetDataFilterCondition();
			SetTableLayoutConfig();
			SelectView(_ctrlSignatureOfSurfaceQuery);
		}

		private void OnParetoChart()
		{
			SetTitle("Signature Pareto Chart");
			_ctrlParetoChartQuery.DisplayFabList();
			SetDataFilterCondition();
			SelectView(_ctrlParetoChartQuery);
		}
		#endregion

		#region Tools
		private void OnOption()
		{
			DlgOptions dlg = new DlgOptions();
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				_ctrlDataSourceQuery.DisplayFabList();
				_ctrlSingleLayerQuery.DisplayFabList();
				_ctrlSignatureOfSurfaceQuery.DisplayFabList();
			}
		}
		#endregion

		#region Help
		private void OnHelp()
		{

		}

		private void OnAbout()
		{
			DlgAbout dlg = new DlgAbout();
			dlg.ShowDialog(this);
		}
		#endregion

		#region Windows Events Handles
		private void _toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ExecuteCmd(e.Button.ToolTipText);
		}

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCmd(((ToolStripMenuItem)sender).Text);
        }

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (MessageBox.Show("Do you want to quit the program ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				e.Cancel = true;

			if(AppData.Data.DDAProcess != null)
				AppData.Data.DDAProcess.Kill();

			AppData.Data.SaveApplicationData( System.IO.Path.Combine(AppData.ApplicationDataPath, "App.config"));	
			SetDataFilterCondition();
			SetTableLayoutConfig();
			_ctrlDataSourceQuery.SaveConfig();
			_ctrlSourceOfDiskQuery.SaveConfig();
			_ctrlSingleLayerQuery.SaveConfig();
			_ctrlSignatureOfSurfaceQuery.SaveConfig();
			_ctrlParetoChartQuery.SaveConfig();
		}

		private void _ctrlDataSourceQuery_OnTimeChanged(SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			_ctrlSingleLayerQuery.TimeFilter = timeFilter;
			_ctrlSignatureOfSurfaceQuery.TimeFilter = timeFilter;
			_ctrlSourceOfDiskQuery.TimeFilter = timeFilter;
			_ctrlParetoChartQuery.TimeFilter = timeFilter;
		}

		private void _ctrlDataSourceQuery_OnFabIDChanged(string fabID)
		{
			_ctrlSingleLayerQuery.FabID = fabID;
			_ctrlSignatureOfSurfaceQuery.FabID = fabID;
			_ctrlSourceOfDiskQuery.FabID = fabID;
			_ctrlParetoChartQuery.FabID = fabID;
		}

		private void _ctrlSingleLayerQuery_OnTimeChanged(SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			_ctrlDataSourceQuery.TimeFilter = timeFilter;
			_ctrlSignatureOfSurfaceQuery.TimeFilter = timeFilter;
			_ctrlSourceOfDiskQuery.TimeFilter = timeFilter;
			_ctrlParetoChartQuery.TimeFilter = timeFilter;
		}

		private void _ctrlSingleLayerQuery_OnFabIDChanged(string fabID)
		{
			_ctrlDataSourceQuery.FabID = fabID;
			_ctrlSignatureOfSurfaceQuery.FabID = fabID;
			_ctrlSourceOfDiskQuery.FabID = fabID;
			_ctrlParetoChartQuery.FabID = fabID;
		}

		private void _ctrlSignatureOfSurfaceQuery_OnTimeChanged(SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			_ctrlDataSourceQuery.TimeFilter = timeFilter;
			_ctrlSingleLayerQuery.TimeFilter = timeFilter;
			_ctrlSourceOfDiskQuery.TimeFilter = timeFilter;
			_ctrlParetoChartQuery.TimeFilter = timeFilter;
		}

		private void _ctrlSignatureOfSurfaceQuery_OnFabIDChanged(string fabID)
		{
			_ctrlDataSourceQuery.FabID = fabID;
			_ctrlSingleLayerQuery.FabID = fabID;
			_ctrlSourceOfDiskQuery.FabID = fabID;
			_ctrlParetoChartQuery.FabID = fabID;
		}

		private void _ctrlSourceOfDiskQuery_OnTimeChanged(SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			_ctrlDataSourceQuery.TimeFilter = timeFilter;
			_ctrlSingleLayerQuery.TimeFilter = timeFilter;
			_ctrlSignatureOfSurfaceQuery.TimeFilter = timeFilter;
			_ctrlParetoChartQuery.TimeFilter = timeFilter;
		}

		private void _ctrlSourceOfDiskQuery_OnFabIDChanged(string fabID)
		{
			_ctrlDataSourceQuery.FabID = fabID;
			_ctrlSingleLayerQuery.FabID = fabID;
			_ctrlSignatureOfSurfaceQuery.FabID = fabID;
			_ctrlParetoChartQuery.FabID = fabID;
		}

		private void _ctrlParetoChartQuery_OnTimeChanged(SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			_ctrlDataSourceQuery.TimeFilter = timeFilter;
			_ctrlSingleLayerQuery.TimeFilter = timeFilter;
			_ctrlSignatureOfSurfaceQuery.TimeFilter = timeFilter;
			_ctrlSourceOfDiskQuery.TimeFilter = timeFilter;
		}

		private void _ctrlParetoChartQuery_OnFabIDChanged(string fabID)
		{
			_ctrlDataSourceQuery.FabID = fabID;
			_ctrlSingleLayerQuery.FabID = fabID;
			_ctrlSignatureOfSurfaceQuery.FabID = fabID;
			_ctrlSourceOfDiskQuery.FabID = fabID;
		}
		#endregion

        
	}
}
