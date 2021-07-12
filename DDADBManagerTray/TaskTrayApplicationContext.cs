using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DDADBManagerTray
{
	public class TaskTrayApplicationContext : ApplicationContext
	{
		public NotifyIcon notifyIcon = new NotifyIcon();
		Form1 configWindow = new Form1();

		public MenuItem miStar ;
		public MenuItem miStop ;
		public MenuItem miPause ;
		public MenuItem miReStar ;
		public MenuItem miControoler ;
		public MenuItem miRecipe;
	
		public TaskTrayApplicationContext()
		{
			MenuItem configMenuItem = new MenuItem("DDADB Services Controller", new EventHandler(ShowConfig));
			configMenuItem.DefaultItem = true;
			MenuItem sep1 = new MenuItem("-");

			miStar = new MenuItem("Start",new EventHandler(configWindow.ButtonStart_Click));
			miStop = new MenuItem("Stop",new EventHandler(configWindow.ButtonStop_Click));
			miPause = new MenuItem("Pause",new EventHandler(configWindow.ButtonPause_Click));
			miReStar = new MenuItem("Restart",new EventHandler(configWindow.ButtonReStart_Click));

			miControoler = new MenuItem("DDADB Manager",new EventHandler(configWindow.button2_Click));
			miRecipe = new MenuItem("DDA Recipe Manager",new EventHandler(configWindow.button3_Click));

			MenuItem sep2 = new MenuItem("-");
			MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

			notifyIcon.Icon = new Icon(typeof(Form1),"icon_sevices_stop.ico");

			//notifyIcon.Text = "DDADB Manager Service";//, double click or right click";
		
			notifyIcon.DoubleClick += new EventHandler(ShowMessage);
			notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem,miControoler,miRecipe,sep1,miStar,miStop,miPause,miReStar,sep2,exitMenuItem });

			notifyIcon.ContextMenu.Popup+=new EventHandler(ContextMenu_Popup);

			notifyIcon.Visible = true;
		}

		void ShowMessage(object sender, EventArgs e)
		{
			// Only show the message if the settings say we can.
			//if (TaskTrayApplication.Properties.Settings.Default.ShowMessage)
			//	MessageBox.Show("Hello World");
			ShowConfig(null,null);
		}

		void ShowConfig(object sender, EventArgs e)
		{
			// If we are already showing the window meerly focus it.
			if (configWindow.Visible)
			{
				configWindow.TopMost = true;
				configWindow.TopMost = false;
			}
			else
			{
				configWindow.TopMost = true;
				try
				{
					if (!configWindow.Visible)
						configWindow.ShowDialog();
				}
				catch
				{
				}
			}
		}

		void Exit(object sender, EventArgs e)
		{
			// We must manually tidy up and remove the icon before we exit.
			// Otherwise it will be left behind until the user mouses over.
			notifyIcon.Visible = false;
			notifyIcon.Dispose();

			Application.Exit();
		}

		private void ContextMenu_Popup(object sender, EventArgs e)
		{
			//get the status of the service.
			try
			{
				string strServerStatus = configWindow.ServerStatus;
				bool isdisable = DataInstaller.DDAServiceOptions.IsDisable;
			
				//check the status of the service and enable the 
				//command buttons accordingly.
				if (strServerStatus == "Running" && !isdisable)
				{
					miPause.Enabled=  false;
					miStop.Enabled= true;
					miStar.Enabled= false;
					miReStar.Enabled= false;//true;
				}
				else if(strServerStatus == "Paused" && !isdisable)
				{
					miStar.Enabled= true;
					miPause.Enabled= false;
					miStop.Enabled= true;
					miReStar.Enabled= false;
				}
				else if (strServerStatus == "Stopped" && !isdisable)
				{
					miStar.Enabled= true;
					miPause.Enabled= false;
					miStop.Enabled= false;
					miReStar.Enabled=false;
				}
				else
				{
					miStar.Enabled= false;
					miPause.Enabled= false;
					miStop.Enabled= false;
					miReStar.Enabled=false;
				}
			}
			catch
			{
				miStar.Enabled= false;
				miPause.Enabled= false;
				miStop.Enabled= false;
				miReStar.Enabled=false;
			}
		}
	}
}
