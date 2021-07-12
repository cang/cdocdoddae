using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Common.DDA;
using SiGlaz.Utility;
using SSA.SystemFrameworks;
using SiGlaz.SharedMemory;
using SiGlaz.DDA.Business;

namespace DDANavigator.Dialogs
{
	public class DlgSourceOfDiskViewLargeImage : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.TabControl tabSourceOfDisk;
		private System.Windows.Forms.TabPage pageTopMap;
		private System.Windows.Forms.TabPage pageBottomMap;
		private System.Windows.Forms.PictureBox picTopMap;
		private System.ComponentModel.Container components = null;
		private ViewMode _viewMode = ViewMode.Disk;
		private System.Windows.Forms.PictureBox picBottomMap;
		private DDAResultDataCollection _ddaResultDataCollection = null;
		#endregion

		#region Constructor & Destructor
		public DlgSourceOfDiskViewLargeImage(DDAResultDataCollection ddaResultDataCollection, ViewMode viewMode)
		{
			InitializeComponent();

			_ddaResultDataCollection = ddaResultDataCollection;
			_viewMode = viewMode;
			
			DisplayImage();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgSourceOfDiskViewLargeImage));
			this.tabSourceOfDisk = new System.Windows.Forms.TabControl();
			this.pageTopMap = new System.Windows.Forms.TabPage();
			this.pageBottomMap = new System.Windows.Forms.TabPage();
			this.picTopMap = new System.Windows.Forms.PictureBox();
			this.picBottomMap = new System.Windows.Forms.PictureBox();
			this.tabSourceOfDisk.SuspendLayout();
			this.pageTopMap.SuspendLayout();
			this.pageBottomMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabSourceOfDisk
			// 
			this.tabSourceOfDisk.Controls.Add(this.pageTopMap);
			this.tabSourceOfDisk.Controls.Add(this.pageBottomMap);
			this.tabSourceOfDisk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabSourceOfDisk.Location = new System.Drawing.Point(0, 0);
			this.tabSourceOfDisk.Name = "tabSourceOfDisk";
			this.tabSourceOfDisk.SelectedIndex = 0;
			this.tabSourceOfDisk.Size = new System.Drawing.Size(608, 625);
			this.tabSourceOfDisk.TabIndex = 0;
			// 
			// pageTopMap
			// 
			this.pageTopMap.Controls.Add(this.picTopMap);
			this.pageTopMap.Location = new System.Drawing.Point(4, 22);
			this.pageTopMap.Name = "pageTopMap";
			this.pageTopMap.Size = new System.Drawing.Size(600, 599);
			this.pageTopMap.TabIndex = 0;
			this.pageTopMap.Text = "Top Map";
			// 
			// pageBottomMap
			// 
			this.pageBottomMap.Controls.Add(this.picBottomMap);
			this.pageBottomMap.Location = new System.Drawing.Point(4, 22);
			this.pageBottomMap.Name = "pageBottomMap";
			this.pageBottomMap.Size = new System.Drawing.Size(600, 599);
			this.pageBottomMap.TabIndex = 1;
			this.pageBottomMap.Text = "Bottom Map";
			// 
			// picTopMap
			// 
			this.picTopMap.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.picTopMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picTopMap.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picTopMap.Location = new System.Drawing.Point(0, 0);
			this.picTopMap.Name = "picTopMap";
			this.picTopMap.Size = new System.Drawing.Size(600, 600);
			this.picTopMap.TabIndex = 0;
			this.picTopMap.TabStop = false;
			this.picTopMap.DoubleClick += new System.EventHandler(this.picTopMap_DoubleClick);
			// 
			// picBottomMap
			// 
			this.picBottomMap.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.picBottomMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBottomMap.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picBottomMap.Location = new System.Drawing.Point(0, 0);
			this.picBottomMap.Name = "picBottomMap";
			this.picBottomMap.Size = new System.Drawing.Size(600, 600);
			this.picBottomMap.TabIndex = 1;
			this.picBottomMap.TabStop = false;
			this.picBottomMap.DoubleClick += new System.EventHandler(this.picBottomMap_DoubleClick);
			// 
			// DlgSourceOfDiskViewLargeImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 625);
			this.Controls.Add(this.tabSourceOfDisk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgSourceOfDiskViewLargeImage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "View Large Image";
			this.tabSourceOfDisk.ResumeLayout(false);
			this.pageTopMap.ResumeLayout(false);
			this.pageBottomMap.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		private void DisplayImage()
		{
			if (_ddaResultDataCollection.Count > 1)
			{
				picTopMap.Image = (Image)ConvertKlarf2Image( 
                    BDConvert.ConvertFromBinaryToKlarfParserFile( _ddaResultDataCollection[0].DataSourceRaw));

				picBottomMap.Image = (Image)ConvertKlarf2Image(
                    BDConvert.ConvertFromBinaryToKlarfParserFile( _ddaResultDataCollection[1].DataSourceRaw));

				tabSourceOfDisk.SelectedIndex = _ddaResultDataCollection.FocusedIndex;
			}
			else
			{
				if (_ddaResultDataCollection.FocusedIndex == 0)
				{
					tabSourceOfDisk.TabPages.RemoveAt(1);
					picTopMap.Image = (Image)ConvertKlarf2Image(
                        BDConvert.ConvertFromBinaryToKlarfParserFile( _ddaResultDataCollection[0].DataSourceRaw));
				}
				else
				{
					tabSourceOfDisk.TabPages.RemoveAt(0);
					picBottomMap.Image = (Image)ConvertKlarf2Image(
                        BDConvert.ConvertFromBinaryToKlarfParserFile(_ddaResultDataCollection[0].DataSourceRaw));
				}
			}
		}

		private Bitmap ConvertKlarf2Image(SSA.SystemFrameworks.KlarfParserFile klarfFile)
		{
			SSA.SystemFrameworks.KlarfFileView klarfView = new SSA.SystemFrameworks.KlarfFileView(klarfFile);
			klarfView.ShowCoordinate = true;
			klarfView.ShowCoordinateAxis = true;
			klarfView.ShowGird = true;
			klarfView.ShowOrientationMark = true;

			if (_viewMode == ViewMode.Disk)
			{
				klarfFile.TranPolarFromOrigin();
				SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
			}
			else
			{
				klarfFile.TranCartesianFromOrigin(0,1f);
				SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = SSA.SystemFrameworks.MRSProcessingType.FlatMode;
			}
						
			return klarfView.Export2Image(new Size(600, 600));
		}

		private void RunDDA()
		{
			Cursor.Current = Cursors.WaitCursor;
			if (File.Exists(AppData.Data.DDAPath) == false)
			{
				MessageBox.Show(string.Format("File {0} does not exist. Please reset DDA path.", AppData.Data.DDAPath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				Cursor.Current = Cursors.WaitCursor;

				string temppath = AppData.ApplicationDataPath;//Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Templates), "DDANavData");
				if(!Directory.Exists(temppath))
					Directory.CreateDirectory(temppath);
				temppath = Path.Combine(temppath, "memorydata.dat");
				_ddaResultDataCollection.SerializeBinary(temppath);

				if(AppData.Data.DDAProcess==null)
				{
					if (File.Exists(temppath))
					{
						System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo(AppData.Data.DDAPath,string.Format("\"{0}\" Memory", temppath));
						AppData.Data.DDAProcess = System.Diagnostics.Process.Start(proInfo);
					}
				}
				else
				{
					IntPtr pFoundWindow = AppData.Data.DDAProcess.MainWindowHandle; 
					SiGlaz.Utility.Win32.User32.SendMessage(pFoundWindow,(int)SiGlaz.Utility.Win32.Msgs.WM_USER + 1,0,0);
					SiGlaz.Utility.Win32.User32.SetWindowPos(pFoundWindow,IntPtr.Zero,0,0,0,0,
						(uint)(SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_SHOWWINDOW |SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_NOSIZE) );
				}
			}
		}
		#endregion

		#region Windows Events Handles
		private void picTopMap_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				_ddaResultDataCollection.FocusedIndex = 0;
				RunDDA();		
			}
			catch (System.Exception ex)
			{
				
			}
		}

		private void picBottomMap_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				_ddaResultDataCollection.FocusedIndex = 1;
				RunDDA();
			}
			catch (System.Exception ex)
			{
				
			}
		}
		#endregion
	}
}
