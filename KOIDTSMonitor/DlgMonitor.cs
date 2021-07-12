using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting;
using System.Threading;

using KOIDTSSimpleMsg;
using SiGlaz.Common.DDA;
using SiGlaz.Utility.Wind32;

namespace KOIDTSMonitor
{	
	public class DlgMonitor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbStart;
		private System.Windows.Forms.ToolBarButton tbStop;
		private System.Windows.Forms.ToolBarButton tbSetting;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnExit;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnStart;
		private System.Windows.Forms.MenuItem mnStop;
		private System.Windows.Forms.MenuItem nmSetting;
		private System.Windows.Forms.RichTextBox rtOutput;
		public DlgMonitor()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgMonitor));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rtOutput = new System.Windows.Forms.RichTextBox();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbStart = new System.Windows.Forms.ToolBarButton();
			this.tbStop = new System.Windows.Forms.ToolBarButton();
			this.tbSetting = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnExit = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnStart = new System.Windows.Forms.MenuItem();
			this.mnStop = new System.Windows.Forms.MenuItem();
			this.nmSetting = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rtOutput);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 44);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(772, 453);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Status Running";
			// 
			// rtOutput
			// 
			this.rtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtOutput.Location = new System.Drawing.Point(3, 16);
			this.rtOutput.Name = "rtOutput";
			this.rtOutput.Size = new System.Drawing.Size(766, 434);
			this.rtOutput.TabIndex = 0;
			this.rtOutput.Text = "";
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbStart,
																						this.tbStop,
																						this.tbSetting});
			this.toolBar1.ButtonSize = new System.Drawing.Size(32, 32);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(772, 44);
			this.toolBar1.TabIndex = 7;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbStart
			// 
			this.tbStart.ImageIndex = 1;
			this.tbStart.ToolTipText = "Start";
			// 
			// tbStop
			// 
			this.tbStop.ImageIndex = 0;
			this.tbStop.ToolTipText = "Stop";
			// 
			// tbSetting
			// 
			this.tbSetting.ImageIndex = 2;
			this.tbSetting.ToolTipText = "Settings";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnExit});
			this.menuItem1.Text = "&File";
			// 
			// mnExit
			// 
			this.mnExit.Index = 0;
			this.mnExit.Text = "&Exit";
			this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnStart,
																					  this.mnStop,
																					  this.nmSetting});
			this.menuItem3.Text = "&Tools";
			// 
			// mnStart
			// 
			this.mnStart.Index = 0;
			this.mnStart.Text = "&Start";
			this.mnStart.Click += new System.EventHandler(this.mnStart_Click);
			// 
			// mnStop
			// 
			this.mnStop.Index = 1;
			this.mnStop.Text = "S&top";
			this.mnStop.Click += new System.EventHandler(this.mnStop_Click);
			// 
			// nmSetting
			// 
			this.nmSetting.Index = 2;
			this.nmSetting.Text = "Settin&g";
			this.nmSetting.Click += new System.EventHandler(this.nmSetting_Click);
			// 
			// DlgMonitor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(772, 497);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "DlgMonitor";
			this.Text = "EISKIO DDA Monitor";
			this.Load += new System.EventHandler(this.DlgMonitor_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		
		public delegate void MessageHandler(string message);

		public void AddNewLine(string message)
		{
			if (rtOutput.InvokeRequired == false)
			{
				crossThreadAddNewLine(message);
			}
			else
			{
				// Show the text asynchronously
				MessageHandler statusDelegate =
					new MessageHandler(crossThreadAddNewLine);

				this.rtOutput.BeginInvoke(statusDelegate,
					new object[] { message });
			}
		}

		private void crossThreadAddNewLine(string message)
		{
			try
			{
				Monitor.Enter(rtOutput);
				if(rtOutput.Lines.Length>= 255)
				{
					int length = rtOutput.Text.IndexOf("\n") + 1;
					rtOutput.Select(0,length);
					rtOutput.SelectedText="";
				}
				rtOutput.AppendText(message + "\n");
				SiGlaz.Utility.ControlWin32.ScrollToBottom(rtOutput);
			}
			catch
			{
			}
			finally
			{
				Monitor.Exit(rtOutput);
			}
		}

		private void SetStatusGui(bool status)
		{
			tbSetting.Enabled = nmSetting.Enabled = mnStart.Enabled = tbStart.Enabled = mnExit.Enabled = !status;
			tbStop.Enabled = mnStop.Enabled = status;
		}

		private void Start()
		{			
			string _echeckname = "Global\\SiGlaz_KOIDTS_Client";
			IntPtr _echeck = IntPtr.Zero;

			_echeck = Kernel32.CreateEvent(IntPtr.Zero,true,false,_echeckname);
			if(_echeck==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echeckname + " event");
			}

			string PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");
			string fileName =string.Format("{0}\\{1}",PersonalFolder,"SiGlaz_KOIDTS_Client");

			SiGlaz.Common.Configuration.SetValues("RUNNING_STATUS",true);
			SiGlaz.Common.Configuration.SaveData(fileName);
			
			Kernel32.SetEvent(_echeck);		
			AddNewLine(Environment.NewLine + "Service is running...");
			SetStatusGui(true);
		}

		private void Stop()
		{
			string _echeckname = "Global\\SiGlaz_KOIDTS_Client";
			IntPtr _echeck = IntPtr.Zero;

			_echeck = Kernel32.CreateEvent(IntPtr.Zero,true,false,_echeckname);
			if(_echeck==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echeckname + " event");
			}

			string PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");
			string fileName =string.Format("{0}\\{1}",PersonalFolder,"SiGlaz_KOIDTS_Client");
			
			SiGlaz.Common.Configuration.SetValues("RUNNING_STATUS",false);
			SiGlaz.Common.Configuration.SaveData(fileName);

			
			Kernel32.SetEvent(_echeck);		
			AddNewLine(Environment.NewLine + "Service is stopped");			
			SetStatusGui(false);
		}

		private void ConfigSettings()
		{
			DlgSettings dlg = new DlgSettings();
			dlg.ShowDialog(this);
		}

		MonitorOutputLine listenLine = new MonitorOutputLine();

		private void DlgMonitor_Load(object sender, System.EventArgs e)
		{
			string PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");
			string fileName =string.Format("{0}\\{1}",PersonalFolder,"SiGlaz_KOIDTS_Client");

			SiGlaz.Common.Configuration.LoadData(fileName);
			bool status = (bool)SiGlaz.Common.Configuration.GetValues("RUNNING_STATUS",false);
			SetStatusGui( status);

			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			InitRemotingObjects();

//			listenLine.OnOutputLine+=new EventHandler(listenLine_OnOutputLine);
//			listenLine.Listen();
//			
		}

		private void listenLine_OnOutputLine(object sender, EventArgs e)
		{
			AddNewLine(sender.ToString());
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
		
		}		
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tbStart)
			{
				Start();
				return;
			}
			if (e.Button == tbStop)
			{
				Stop();
				return;
			}
			if (e.Button == tbSetting)
			{
				ConfigSettings();
				return;
			}				
		}

		private void mnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnStart_Click(object sender, System.EventArgs e)
		{
			Start();
		}

		private void mnStop_Click(object sender, System.EventArgs e)
		{
			Stop();
		}

		private void nmSetting_Click(object sender, System.EventArgs e)
		{
			ConfigSettings();
		}

		#region RemotableEvent
		public static RemotableEventController Controler = new RemotableEventController();

		public RObject	_remoteObj = null;
		public REvent	_remoteEvent = new REvent();

		public void InitRemotingObjects()
		{
			_remoteObj= new RObject();
			_remoteObj.OnMessageSimple+=new MessageHandlerSimple(_remoteEvent.HandlerOnMessageSimple);

			_remoteEvent.OnMessageSimple+=new MessageHandlerSimple(_remoteEvent_OnMessageSimple);
		}

		private void _remoteEvent_OnMessageSimple(object obj, string msg)
		{
			AddNewLine(msg);
		}
		#endregion 
	}
}
