using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

using Microsoft.Win32;


using System.ServiceProcess;

namespace DDADBManagerTray
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ServiceProcess.ServiceController WSController;
		private System.Windows.Forms.Button ButtonStart;
		private System.Windows.Forms.Button ButtonStop;
		private System.Windows.Forms.Button ButtonPause;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblStop;
		private System.Windows.Forms.Label lblPause;
		private System.Windows.Forms.Label lblRetart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox picStart;
		private System.Windows.Forms.PictureBox picStop;
		private System.Windows.Forms.Button button3;
		private System.Timers.Timer timer1;
		private System.Windows.Forms.Button btnOption;
		private System.ComponentModel.IContainer components;

		public Form1()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.WSController = new System.ServiceProcess.ServiceController();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonStop = new System.Windows.Forms.Button();
			this.ButtonPause = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.picStart = new System.Windows.Forms.PictureBox();
			this.lblStart = new System.Windows.Forms.Label();
			this.lblStop = new System.Windows.Forms.Label();
			this.lblPause = new System.Windows.Forms.Label();
			this.lblRetart = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.picStop = new System.Windows.Forms.PictureBox();
			this.button3 = new System.Windows.Forms.Button();
			this.timer1 = new System.Timers.Timer();
			this.btnOption = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			this.SuspendLayout();
			// 
			// WSController
			// 
			this.WSController.ServiceName = "DDAServices";
			// 
			// ButtonStart
			// 
			this.ButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStart.Image")));
			this.ButtonStart.Location = new System.Drawing.Point(132, 16);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(24, 24);
			this.ButtonStart.TabIndex = 0;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// ButtonStop
			// 
			this.ButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStop.Image")));
			this.ButtonStop.Location = new System.Drawing.Point(132, 48);
			this.ButtonStop.Name = "ButtonStop";
			this.ButtonStop.Size = new System.Drawing.Size(24, 24);
			this.ButtonStop.TabIndex = 1;
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// ButtonPause
			// 
			this.ButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPause.Image")));
			this.ButtonPause.Location = new System.Drawing.Point(132, 80);
			this.ButtonPause.Name = "ButtonPause";
			this.ButtonPause.Size = new System.Drawing.Size(24, 24);
			this.ButtonPause.TabIndex = 2;
			this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox1.Location = new System.Drawing.Point(8, 236);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(288, 24);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "&Auto-start DDA Services Controller when OS starts";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(132, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 24);
			this.button1.TabIndex = 4;
			this.button1.Click += new System.EventHandler(this.ButtonReStart_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(8, 168);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(148, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "&Run DDADB Manager";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 262);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(314, 22);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 7;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 1000;
			// 
			// picStart
			// 
			this.picStart.BackColor = System.Drawing.SystemColors.Control;
			this.picStart.Image = ((System.Drawing.Image)(resources.GetObject("picStart.Image")));
			this.picStart.Location = new System.Drawing.Point(24, 16);
			this.picStart.Name = "picStart";
			this.picStart.Size = new System.Drawing.Size(80, 100);
			this.picStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picStart.TabIndex = 8;
			this.picStart.TabStop = false;
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new System.Drawing.Point(168, 24);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(28, 16);
			this.lblStart.TabIndex = 9;
			this.lblStart.Text = "Start";
			// 
			// lblStop
			// 
			this.lblStop.AutoSize = true;
			this.lblStop.Location = new System.Drawing.Point(168, 56);
			this.lblStop.Name = "lblStop";
			this.lblStop.Size = new System.Drawing.Size(27, 16);
			this.lblStop.TabIndex = 10;
			this.lblStop.Text = "Stop";
			// 
			// lblPause
			// 
			this.lblPause.AutoSize = true;
			this.lblPause.Location = new System.Drawing.Point(168, 88);
			this.lblPause.Name = "lblPause";
			this.lblPause.Size = new System.Drawing.Size(36, 16);
			this.lblPause.TabIndex = 11;
			this.lblPause.Text = "Pause";
			// 
			// lblRetart
			// 
			this.lblRetart.AutoSize = true;
			this.lblRetart.Location = new System.Drawing.Point(168, 120);
			this.lblRetart.Name = "lblRetart";
			this.lblRetart.Size = new System.Drawing.Size(41, 16);
			this.lblRetart.TabIndex = 12;
			this.lblRetart.Text = "Restart";
			// 
			// groupBox1
			// 
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(-24, 152);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(536, 8);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			// 
			// picStop
			// 
			this.picStop.Image = ((System.Drawing.Image)(resources.GetObject("picStop.Image")));
			this.picStop.Location = new System.Drawing.Point(24, 16);
			this.picStop.Name = "picStop";
			this.picStop.Size = new System.Drawing.Size(80, 100);
			this.picStop.TabIndex = 14;
			this.picStop.TabStop = false;
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(8, 200);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(148, 23);
			this.button3.TabIndex = 15;
			this.button3.Text = "&Run DDA Recipe Manager";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.SynchronizingObject = this;
			this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// btnOption
			// 
			this.btnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOption.Location = new System.Drawing.Point(228, 17);
			this.btnOption.Name = "btnOption";
			this.btnOption.TabIndex = 16;
			this.btnOption.Text = "Options...";
			this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 284);
			this.Controls.Add(this.btnOption);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.lblRetart);
			this.Controls.Add(this.lblPause);
			this.Controls.Add(this.lblStop);
			this.Controls.Add(this.lblStart);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.ButtonPause);
			this.Controls.Add(this.ButtonStop);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.picStart);
			this.Controls.Add(this.picStop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDADB Manager Service";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public static TaskTrayApplicationContext ac = null;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			ac = new TaskTrayApplicationContext();
			Application.Run(ac);
			//Application.Run( new DataInstaller.DDAServiceOptions());
		}

		public string ServerStatus
		{
			get
			{
				WSController.Refresh();
				return WSController.Status.ToString();
			}
		}
			
		private string prevStatus = string.Empty;
		private void SetButtonStatus()
		{
			//get the status of the service.
			try
			{
				string strServerStatus = this.ServerStatus;

				if( strServerStatus==prevStatus)
					return;
			
				//check the status of the service and enable the 
				//command buttons accordingly.

				bool isdisable = DataInstaller.DDAServiceOptions.IsDisable;

				if (strServerStatus == "Running" && !isdisable)
				{
					//check to see if the service can be paused
					if (WSController.CanPauseAndContinue == true)
					{
						lblPause.Enabled = ButtonPause.Enabled = true;
					}
					else
					{
						lblPause.Enabled = ButtonPause.Enabled = false;
					}

					lblStop.Enabled = ButtonStop.Enabled = true;
					lblStart.Enabled =  ButtonStart.Enabled = false;
					lblRetart.Enabled = button1.Enabled = false;//true;

					picStart.BringToFront();
					ac.notifyIcon.Icon = new Icon(this.GetType(),"icon_sevices_play.ico");

				}
				else if(strServerStatus == "Paused" && !isdisable)
				{
					lblStart.Enabled= ButtonStart.Enabled = true;
					lblPause.Enabled = ButtonPause.Enabled = false;
					lblStop.Enabled = ButtonStop.Enabled = true;
					lblRetart.Enabled = button1.Enabled = false;
				}
				else if (strServerStatus == "Stopped" && !isdisable)
				{
					lblStart.Enabled= ButtonStart.Enabled = true;
					lblPause.Enabled = ButtonPause.Enabled = false;
					lblStop.Enabled = ButtonStop.Enabled = false;
					lblRetart.Enabled = button1.Enabled = false;

					picStop.BringToFront();
					ac.notifyIcon.Icon = new Icon(this.GetType(),"icon_sevices_stop.ico");

				}
				else
				{
					lblStart.Enabled= ButtonStart.Enabled = false;
					lblPause.Enabled = ButtonPause.Enabled = false;
					lblStop.Enabled = ButtonStop.Enabled = false;
					lblRetart.Enabled = button1.Enabled = false;
				}

				statusBarPanel1.Text = strServerStatus;
			}
			catch
			{
				lblStart.Enabled= ButtonStart.Enabled = false;
				lblPause.Enabled = ButtonPause.Enabled = false;
				lblStop.Enabled = ButtonStop.Enabled = false;
				lblRetart.Enabled = button1.Enabled = false;
				btnOption.Enabled = false;
			}
		}


		public void ButtonStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				//check the status of the service
				if(WSController.Status.ToString() == "Paused")
				{
					WSController.Continue();
				}
				else if(WSController.Status.ToString() == "Stopped")
				{

					//get an array of services this service depends upon, loop through 
					//the array and prompt the user to start all required services.
					ServiceController[] ParentServices = WSController.ServicesDependedOn;
			
					//if the length of the array is greater than or equal to 1.
					if (ParentServices.Length >= 1)
					{
						foreach(ServiceController ParentService in ParentServices)
						{	
							//make sure the parent service is running or at least paused.
							if(ParentService.Status.ToString() != "Running" || ParentService.Status.ToString() != "Paused")
							{

								if (MessageBox.Show("This service is required. Would you like to also start this service?\n"+ParentService.DisplayName, "Required Service", MessageBoxButtons.YesNo).ToString() == "Yes")
								{
									//if the user chooses to start the service

									ParentService.Start();
									ParentService.WaitForStatus(ServiceControllerStatus.Running);
								}
								else
								{
									//otherwise just return.
									return;
								}
							}
						}
					}
			
					WSController.Start();
				}

				WSController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
				SetButtonStatus();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Could not start the " + WSController.DisplayName + " service on Local Computer.\nError: " + ex.Message, "Services",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}


		public void ButtonStop_Click(object sender, System.EventArgs e)
		{
			try
			{
				//check to see if the service can be stopped.
				if (WSController.CanStop == true)
				{
			
					//get an array of dependent services, loop through the array and 
					//prompt the user to stop all dependent services.
					ServiceController[] DependentServices = WSController.DependentServices;
			
					//if the length of the array is greater than or equal to 1.
					if (DependentServices.Length >= 1)
					{
						foreach(ServiceController DependentService in DependentServices)
						{
							//make sure the dependent service is not already stopped.
							if(DependentService.Status.ToString() != "Stopped")
							{
								if (MessageBox.Show("Would you like to also stop this dependent service?\n"+DependentService.DisplayName, "Dependent Service", MessageBoxButtons.YesNo).ToString() == "Yes")
								{
									// not checking at this point whether the dependent service can be stopped.
									// developer may want to include this check to avoid exception.
									DependentService.Stop();
									DependentService.WaitForStatus(ServiceControllerStatus.Stopped);
								}
								else
								{
									return;
								}
							}
						}
					}
			
					//check the status of the service
					if(WSController.Status.ToString() == "Running" || WSController.Status.ToString() == "Paused")
					{
						WSController.Stop();
					}
					WSController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
					SetButtonStatus();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Could not stop the " + WSController.DisplayName + " service on Local Computer.\nError: " + ex.Message, "Services",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}


		public void ButtonPause_Click(object sender, System.EventArgs e)
		{
			//check to see if the service can be paused and continue
			if (WSController.CanPauseAndContinue == true)
			{
				//check the status of the service
				if(WSController.Status.ToString() == "Running")
				{
					WSController.Pause();
				}

				WSController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Paused);
				SetButtonStatus();
			}
		}


		public void ButtonReStart_Click(object sender, System.EventArgs e)
		{
			if(WSController.Status.ToString() == "Running")
			{
				//get an array of services this service depends upon, loop through 
				//the array and prompt the user to start all required services.
				ServiceController[] ParentServices = WSController.ServicesDependedOn;
			
				//if the length of the array is greater than or equal to 1.
				if (ParentServices.Length >= 1)
				{
					foreach(ServiceController ParentService in ParentServices)
					{	
						//make sure the parent service is running or at least paused.
						if(ParentService.Status.ToString() == "Running")
						{
							if (MessageBox.Show("This service is required. Would you like to also re-start this service?\n"+ParentService.DisplayName, "Required Service", MessageBoxButtons.YesNo).ToString() == "Yes")
							{
								//if the user chooses to start the service
								ParentService.Stop();
								ParentService.WaitForStatus(ServiceControllerStatus.Stopped);

								ParentService.Start();
								ParentService.WaitForStatus(ServiceControllerStatus.Running);
							}
							else
							{
								//otherwise just return.
								return;
							}
						}
					}
				}

				WSController.Stop();
				WSController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
			
				WSController.Start();
				WSController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
			}
				
			SetButtonStatus();
		}




		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if (FormWindowState.Minimized == WindowState)
				Hide();
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{	
			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);

			if (checkBox1.Checked)
				key.SetValue("DDADBManagerTray", "\"" + Application.ExecutablePath + "\"");
			else
				key.DeleteValue("DDADBManagerTray");

			key.Close();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Text = Application.ProductName;

			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);
			object x = key.GetValue("DDADBManagerTray");
			checkBox1.Checked = x!=null;

			SetButtonStatus();
		}

		public void button2_Click(object sender, System.EventArgs e)
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DDADBManagerController.exe");
			if( System.IO.File.Exists(path))
				System.Diagnostics.Process.Start(path);
		}

		public void button3_Click(object sender, System.EventArgs e)
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DDARMController.exe");
			if( System.IO.File.Exists(path))
				System.Diagnostics.Process.Start(path);
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			SetButtonStatus();
		}

		private void btnOption_Click(object sender, System.EventArgs e)
		{
			DataInstaller.DDAServiceOptions dlg = new DataInstaller.DDAServiceOptions();
			if(dlg.ShowDialog(this) == DialogResult.OK)
			{
				SetButtonStatus();
			}
		}
		

	}
}
