using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace DDANavigator.Dialogs
{
	public class DlgMessageBox : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.Label lbMsg;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnOpenFolder;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.Container components = null;
		private string _filename;
		#endregion
		
		#region Constructor & Destructor
		public DlgMessageBox(string filename)
		{
			InitializeComponent();

			_filename = filename;
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
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgMessageBox));
			this.lbMsg = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnOpenFolder = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// lbMsg
			// 
			this.lbMsg.AutoSize = true;
			this.lbMsg.Location = new System.Drawing.Point(68, 16);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(180, 16);
			this.lbMsg.TabIndex = 0;
			this.lbMsg.Text = "Export report to Excel successfully.";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-36, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(356, 4);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnOpen
			// 
			this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOpen.Location = new System.Drawing.Point(18, 64);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(76, 23);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "&Open File";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnOpenFolder
			// 
			this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOpenFolder.Location = new System.Drawing.Point(98, 64);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size(80, 23);
			this.btnOpenFolder.TabIndex = 3;
			this.btnOpenFolder.Text = "Op&en Folder";
			this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(182, 64);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(67, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(20, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 36);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// DlgMessageBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(266, 96);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnOpenFolder);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lbMsg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDA Navigator";
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		private void RefreshGUI()
		{

		}

		private void OpenExcel(string filename)
		{
			Cursor.Current=Cursors.WaitCursor;
			try
			{
				System.Diagnostics.Process.Start(filename);
			}
			catch(Exception)
			{
				MessageBox.Show(string.Format("Cannot open Excel file"),this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}				
			Cursor.Current=Cursors.Default;	
		}

		private void OpenFolder(string path)
		{
			Cursor.Current=Cursors.WaitCursor;
			try
			{
				System.Diagnostics.Process.Start(path);
			}
			catch(Exception)
			{
				MessageBox.Show("Cannot open folder", this.Text,MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			Cursor.Current=Cursors.Default;						
		}

		#endregion

		#region Windows Event Handle
		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			OpenExcel(_filename);
			this.Close();
		}

		private void btnOpenFolder_Click(object sender, System.EventArgs e)
		{
			OpenFolder(Path.GetDirectoryName(_filename));
			this.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion	
	}
}
