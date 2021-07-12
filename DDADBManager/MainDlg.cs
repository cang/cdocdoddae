using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using TSIControlLib.Docking;
//using TSIControlLib.Common;

namespace DDADBManager
{
	/// <summary>
	/// Summary description for MainDlg.
	/// </summary>
	public class MainDlg : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		public MainDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Text = Application.ProductName;
			InitOutputWindow();
			handler.Form = this;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.btnNewProcess = new System.Windows.Forms.ToolBarButton();
            this.btnModifyProcess = new System.Windows.Forms.ToolBarButton();
            this.btnDeleteProcess = new System.Windows.Forms.ToolBarButton();
            this.btnDeleteAll = new System.Windows.Forms.ToolBarButton();
            this.btnSep1 = new System.Windows.Forms.ToolBarButton();
            this.btnRunProcess = new System.Windows.Forms.ToolBarButton();
            this.btnStopProcess = new System.Windows.Forms.ToolBarButton();
            this.btnRunAll = new System.Windows.Forms.ToolBarButton();
            this.btnStopAll = new System.Windows.Forms.ToolBarButton();
            this.btnSep2 = new System.Windows.Forms.ToolBarButton();
            this.btnHelp = new System.Windows.Forms.ToolBarButton();
            this.btnAbout = new System.Windows.Forms.ToolBarButton();
            this.mainMenu1 = new System.Windows.Forms.MenuStrip();
            this.miFILE = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miRECIPES = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddTransferTask = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddDeleteTask = new System.Windows.Forms.ToolStripMenuItem();
            this.miModifyProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miRun = new System.Windows.Forms.ToolStripMenuItem();
            this.miStop = new System.Windows.Forms.ToolStripMenuItem();
            this.miRunAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTOOLS = new System.Windows.Forms.ToolStripMenuItem();
            this.miWebServiceConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.miDiskTypeConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.miProductCode = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pMain = new System.Windows.Forms.Panel();
            this.schemaViewCrl1 = new DDADBManager.View.SchemaViewCrl();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu1.SuspendLayout();
            this.pMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnNewProcess,
            this.btnModifyProcess,
            this.btnDeleteProcess,
            this.btnDeleteAll,
            this.btnSep1,
            this.btnRunProcess,
            this.btnStopProcess,
            this.btnRunAll,
            this.btnStopAll,
            this.btnSep2,
            this.btnHelp,
            this.btnAbout});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 24);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(792, 36);
            this.toolBar1.TabIndex = 3;
            // 
            // btnNewProcess
            // 
            this.btnNewProcess.ImageIndex = 0;
            this.btnNewProcess.Name = "btnNewProcess";
            this.btnNewProcess.ToolTipText = "Add Task";
            // 
            // btnModifyProcess
            // 
            this.btnModifyProcess.ImageIndex = 1;
            this.btnModifyProcess.Name = "btnModifyProcess";
            this.btnModifyProcess.ToolTipText = "Modify Select Task";
            // 
            // btnDeleteProcess
            // 
            this.btnDeleteProcess.ImageIndex = 2;
            this.btnDeleteProcess.Name = "btnDeleteProcess";
            this.btnDeleteProcess.ToolTipText = "Delete Select Task";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.ImageIndex = 3;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.ToolTipText = "Delete All Tasks";
            // 
            // btnSep1
            // 
            this.btnSep1.Name = "btnSep1";
            this.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnRunProcess
            // 
            this.btnRunProcess.ImageIndex = 4;
            this.btnRunProcess.Name = "btnRunProcess";
            this.btnRunProcess.ToolTipText = "Run Selected Task";
            // 
            // btnStopProcess
            // 
            this.btnStopProcess.ImageIndex = 5;
            this.btnStopProcess.Name = "btnStopProcess";
            this.btnStopProcess.ToolTipText = "Stop Selected Task";
            // 
            // btnRunAll
            // 
            this.btnRunAll.ImageIndex = 6;
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.ToolTipText = "Run All";
            // 
            // btnStopAll
            // 
            this.btnStopAll.ImageIndex = 7;
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.ToolTipText = "Stop All";
            // 
            // btnSep2
            // 
            this.btnSep2.Name = "btnSep2";
            this.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnHelp
            // 
            this.btnHelp.Enabled = false;
            this.btnHelp.ImageIndex = 8;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ToolTipText = "Help";
            // 
            // btnAbout
            // 
            this.btnAbout.ImageIndex = 9;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ToolTipText = "About";
            // 
            // mainMenu1
            // 
            this.mainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFILE,
            this.miRECIPES,
            this.mnuTOOLS,
            this.menuItem6});
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(792, 24);
            this.mainMenu1.TabIndex = 0;
            // 
            // miFILE
            // 
            this.miFILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenFile,
            this.miSaveFile,
            this.toolStripMenuItem1,
            this.miExit});
            this.miFILE.Name = "miFILE";
            this.miFILE.Size = new System.Drawing.Size(37, 20);
            this.miFILE.Text = "&File";
            this.miFILE.Click += new System.EventHandler(this.miFILE_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(160, 30);
            this.miExit.Text = "Exit";
            // 
            // miRECIPES
            // 
            this.miRECIPES.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateProcess,
            this.miAddTransferTask,
            this.miAddDeleteTask,
            this.toolStripMenuItem2,
            this.miModifyProcess,
            this.miDeleteProcess,
            this.miDeleteAll,
            this.toolStripMenuItem3,
            this.miRun,
            this.miStop,
            this.miRunAll,
            this.miStopAll});
            this.miRECIPES.Name = "miRECIPES";
            this.miRECIPES.Size = new System.Drawing.Size(43, 20);
            this.miRECIPES.Text = "&Task";
            // 
            // miCreateProcess
            // 
            this.miCreateProcess.Image = global::DDADBManager.Properties.Resources._0;
            this.miCreateProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miCreateProcess.Name = "miCreateProcess";
            this.miCreateProcess.Size = new System.Drawing.Size(189, 30);
            this.miCreateProcess.Text = "Add Task";
            // 
            // miAddTransferTask
            // 
            this.miAddTransferTask.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAddTransferTask.Name = "miAddTransferTask";
            this.miAddTransferTask.Size = new System.Drawing.Size(189, 30);
            this.miAddTransferTask.Text = "Add Transfer Task";
            // 
            // miAddDeleteTask
            // 
            this.miAddDeleteTask.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAddDeleteTask.Name = "miAddDeleteTask";
            this.miAddDeleteTask.Size = new System.Drawing.Size(189, 30);
            this.miAddDeleteTask.Text = "Add Delete Task";
            this.miAddDeleteTask.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // miModifyProcess
            // 
            this.miModifyProcess.Image = global::DDADBManager.Properties.Resources._1;
            this.miModifyProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miModifyProcess.Name = "miModifyProcess";
            this.miModifyProcess.Size = new System.Drawing.Size(189, 30);
            this.miModifyProcess.Text = "Modify Task";
            // 
            // miDeleteProcess
            // 
            this.miDeleteProcess.Image = global::DDADBManager.Properties.Resources._2;
            this.miDeleteProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miDeleteProcess.Name = "miDeleteProcess";
            this.miDeleteProcess.Size = new System.Drawing.Size(189, 30);
            this.miDeleteProcess.Text = "Delete Selected Task";
            // 
            // miDeleteAll
            // 
            this.miDeleteAll.Image = global::DDADBManager.Properties.Resources._3;
            this.miDeleteAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miDeleteAll.Name = "miDeleteAll";
            this.miDeleteAll.Size = new System.Drawing.Size(189, 30);
            this.miDeleteAll.Text = "Delete All";
            // 
            // miRun
            // 
            this.miRun.Image = global::DDADBManager.Properties.Resources._4;
            this.miRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRun.Name = "miRun";
            this.miRun.Size = new System.Drawing.Size(189, 30);
            this.miRun.Text = "Run Selected Task";
            // 
            // miStop
            // 
            this.miStop.Image = global::DDADBManager.Properties.Resources._5;
            this.miStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miStop.Name = "miStop";
            this.miStop.Size = new System.Drawing.Size(189, 30);
            this.miStop.Text = "Stop Selected Task";
            // 
            // miRunAll
            // 
            this.miRunAll.Image = global::DDADBManager.Properties.Resources._6;
            this.miRunAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRunAll.Name = "miRunAll";
            this.miRunAll.Size = new System.Drawing.Size(189, 30);
            this.miRunAll.Text = "Run All";
            // 
            // miStopAll
            // 
            this.miStopAll.Image = global::DDADBManager.Properties.Resources._7;
            this.miStopAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miStopAll.Name = "miStopAll";
            this.miStopAll.Size = new System.Drawing.Size(189, 30);
            this.miStopAll.Text = "Stop All";
            // 
            // mnuTOOLS
            // 
            this.mnuTOOLS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miWebServiceConfig,
            this.miDiskTypeConfiguration,
            this.miProductCode,
            this.toolStripMenuItem4,
            this.miOptions});
            this.mnuTOOLS.Name = "mnuTOOLS";
            this.mnuTOOLS.Size = new System.Drawing.Size(48, 20);
            this.mnuTOOLS.Text = "&Tools";
            // 
            // miWebServiceConfig
            // 
            this.miWebServiceConfig.Image = global::DDADBManager.Properties.Resources._10;
            this.miWebServiceConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miWebServiceConfig.Name = "miWebServiceConfig";
            this.miWebServiceConfig.Size = new System.Drawing.Size(221, 30);
            this.miWebServiceConfig.Text = "Connection Configuration";
            // 
            // miDiskTypeConfiguration
            // 
            this.miDiskTypeConfiguration.Name = "miDiskTypeConfiguration";
            this.miDiskTypeConfiguration.Size = new System.Drawing.Size(221, 30);
            this.miDiskTypeConfiguration.Text = "Product Class";
            // 
            // miProductCode
            // 
            this.miProductCode.Name = "miProductCode";
            this.miProductCode.Size = new System.Drawing.Size(221, 30);
            this.miProductCode.Text = "Product Code";
            // 
            // miOptions
            // 
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(221, 30);
            this.miOptions.Text = "Options";
            // 
            // menuItem6
            // 
            this.menuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelp,
            this.miAbout});
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(44, 20);
            this.menuItem6.Text = "&Help";
            // 
            // miHelp
            // 
            this.miHelp.Enabled = false;
            this.miHelp.Image = global::DDADBManager.Properties.Resources._8;
            this.miHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(160, 30);
            this.miHelp.Text = "Help";
            // 
            // miAbout
            // 
            this.miAbout.Image = global::DDADBManager.Properties.Resources._9;
            this.miAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(160, 30);
            this.miAbout.Text = "About";
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.SystemColors.Control;
            this.pMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMain.Controls.Add(this.schemaViewCrl1);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 60);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(792, 293);
            this.pMain.TabIndex = 4;
            // 
            // schemaViewCrl1
            // 
            this.schemaViewCrl1.BackColor = System.Drawing.Color.White;
            this.schemaViewCrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schemaViewCrl1.Location = new System.Drawing.Point(0, 0);
            this.schemaViewCrl1.Name = "schemaViewCrl1";
            this.schemaViewCrl1.SelectedControl = null;
            this.schemaViewCrl1.Size = new System.Drawing.Size(788, 289);
            this.schemaViewCrl1.TabIndex = 0;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.ImageList = this.imageList2;
            this.tabControl1.Location = new System.Drawing.Point(0, 353);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 192);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(784, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Output";
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(784, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trace";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 350);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(792, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 6);
            // 
            // miOpenFile
            // 
            this.miOpenFile.Image = global::DDADBManager.Properties.Resources._11;
            this.miOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpenFile.Size = new System.Drawing.Size(160, 30);
            this.miOpenFile.Text = "Open";
            // 
            // miSaveFile
            // 
            this.miSaveFile.Image = global::DDADBManager.Properties.Resources._12;
            this.miSaveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miSaveFile.Name = "miSaveFile";
            this.miSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSaveFile.Size = new System.Drawing.Size(160, 30);
            this.miSaveFile.Text = "Save";
            // 
            // MainDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 545);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.mainMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu1;
            this.Name = "MainDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDlg";
            this.Load += new System.EventHandler(this.MainDlg_Load);
            this.mainMenu1.ResumeLayout(false);
            this.mainMenu1.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.MenuStrip mainMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuItem6;
		private System.Windows.Forms.Panel pMain;
		public	DDADBManager.View.SchemaViewCrl schemaViewCrl1;
		private System.Windows.Forms.ImageList imageList2;
		public System.Windows.Forms.ToolBarButton btnNewProcess;
		public System.Windows.Forms.ToolBarButton btnModifyProcess;
		public System.Windows.Forms.ToolBarButton btnDeleteProcess;
		private System.Windows.Forms.ToolBarButton btnSep1;
		public System.Windows.Forms.ToolBarButton btnDeleteAll;
		public System.Windows.Forms.ToolBarButton btnRunProcess;
		public System.Windows.Forms.ToolBarButton btnStopProcess;
		private System.Windows.Forms.ToolStripMenuItem miFILE;
		public System.Windows.Forms.ToolStripMenuItem miSaveFile;
		public System.Windows.Forms.ToolStripMenuItem miOpenFile;
		public System.Windows.Forms.ToolStripMenuItem miExit;
		private System.Windows.Forms.ToolStripMenuItem miRECIPES;
		public System.Windows.Forms.ToolStripMenuItem miCreateProcess;
		public System.Windows.Forms.ToolStripMenuItem miDeleteProcess;
		public System.Windows.Forms.ToolStripMenuItem miRun;
        public System.Windows.Forms.ToolStripMenuItem miStop;
		public System.Windows.Forms.ToolStripMenuItem miModifyProcess;
		public System.Windows.Forms.ToolBarButton btnRunAll;
		public System.Windows.Forms.ToolBarButton btnStopAll;
		public System.Windows.Forms.ToolStripMenuItem miRunAll;
		public System.Windows.Forms.ToolStripMenuItem miStopAll;
		public System.Windows.Forms.ToolStripMenuItem miWebServiceConfig;
		public System.Windows.Forms.ToolStripMenuItem miHelp;
		public System.Windows.Forms.ToolStripMenuItem miAbout;
		public System.Windows.Forms.ToolStripMenuItem miDeleteAll;
		private System.Windows.Forms.ToolBarButton btnSep2;
		public System.Windows.Forms.ToolBarButton btnHelp;
		public System.Windows.Forms.ToolBarButton btnAbout;
		public System.Windows.Forms.ToolStripMenuItem mnuTOOLS;
		public System.Windows.Forms.ToolStripMenuItem miDiskTypeConfiguration;
		private System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.ToolStripMenuItem miProductCode;
        public System.Windows.Forms.ToolStripMenuItem miOptions;
		public System.Windows.Forms.ToolStripMenuItem miAddTransferTask;
        public System.Windows.Forms.ToolStripMenuItem miAddDeleteTask;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem4;


		MainDlgHandler handler = new MainDlgHandler();
		private void MainDlg_Load(object sender, System.EventArgs e)
		{
			//InitOutputWindow();
			this.Icon = new Icon(this.GetType(),"App.ico");
			this.Text = Application.ProductName;
		}

		//public tsiDockingManager dm;
		public View.OuputTextCtrl OuputCtrl = new DDADBManager.View.OuputTextCtrl();
		public View.OuputTextCtrl TraceCtrl = new DDADBManager.View.OuputTextCtrl();

		public System.Windows.Forms.StatusBar statusBar1;
		public void InitOutputWindow()
		{
			OuputCtrl.Dock = DockStyle.Fill;
			tabControl1.TabPages[0].Controls.Add(OuputCtrl);

			TraceCtrl.Dock = DockStyle.Fill;
			tabControl1.TabPages[1].Controls.Add(TraceCtrl);


//			dm = new tsiDockingManager(this,VisualStyle.IDE);
//			tsiContent ct1 = dm.Contents.Add(this.OuputCtrl,"Output",this.imageList2,0);
//			ct1.DisplaySize=new Size(ct1.DisplaySize.Width,250);
////			ct1.CloseButton = false;
////			ct1.HideButton = false;
//
//			tsiContent ct2 = dm.Contents.Add(this.TraceCtrl,"Trace",this.imageList2,1);
//			tsiWindowContent wc = dm.AddContentWithState(ct1,State.DockBottom) as tsiWindowContent;
//			dm.AddContentToWindowContent(ct2,wc);
//
////			ct2.CloseButton = false;
////			ct2.HideButton = false;
//
//			dm.ContentShown+=new TSIControlLib.Docking.tsiDockingManager.ContentHandler(dm_ContentShown);
//
////			dm.AddContentToZone( ct2,wc.ParentZone,1);
//			dm.HideAllContents();
//			dm.ShowAllContents();

//			this.statusBar1 = new System.Windows.Forms.StatusBar();
//			this.statusBar1.Location = new System.Drawing.Point(0, 523);
//			this.statusBar1.Name = "statusBar1";
//			this.statusBar1.Size = new System.Drawing.Size(792, 22);
//			this.statusBar1.TabIndex = 0;
//
//			this.Controls.Add(this.statusBar1);
		}


		private void miFILE_Click(object sender, System.EventArgs e)
		{
		
		}

		public void ReLoadStatusBar()
		{
//			this.Controls.Remove(this.statusBar1);
//			this.Controls.Add(this.statusBar1);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		
		}

//		private void dm_ContentShown(tsiContent c, EventArgs cea)
//		{
//			ReLoadStatusBar();
//		}

	}
}
