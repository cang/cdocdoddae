using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DDADBManager.View
{
	public class LoadETestProcessViewCtrl : DDADBManager.View.ProcessViewCtrl
	{
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components = null;

		public LoadETestProcessViewCtrl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			this.lblProgress.Text = "";
			this.lblTitle.Text = "";
			
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


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblProgress = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblProgress);
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(696, 120);
			this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
			this.panel1.Controls.SetChildIndex(this.lblProgress, 0);
			// 
			// lblProgress
			// 
			this.lblProgress.AutoSize = true;
			this.lblProgress.Location = new System.Drawing.Point(8, 99);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(81, 16);
			this.lblProgress.TabIndex = 4;
			this.lblProgress.Text = "progress status";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(8, 83);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(26, 16);
			this.lblTitle.TabIndex = 5;
			this.lblTitle.Text = "Title";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(144, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(400, 57);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// LoadETestProcessViewCtrl
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Name = "LoadETestProcessViewCtrl";
			this.Size = new System.Drawing.Size(696, 120);
			this.Load += new System.EventHandler(this.LoadETestProcessViewCtrl_Load);
			this.panel1.ResumeLayout(false);

		}
		#endregion


		public Process.ProcessBase		DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				if(_DataSource!=null)
				{
					Process.ProcessBase xx = _DataSource;
					xx.OnBeginProcess-=new EventHandlerProcess(value_OnBeginProcess);
					xx.OnEndProcess-=new EventHandlerProcess(value_OnEndProcess);
					xx.OnProcess-=new EventHandlerProcess(value_OnProcess);
					xx.OnProcessInfo-=new EventHandlerProcessInfor(value_OnProcessInfo);
					xx.OnStateChange-=new EventHandlerProcessInfor(value_OnStateChange);
				}

				if(value==null) return;
				_DataSource = value;

				if(_DataSource!=null)
				{
					this.Caption = this.DataSource.Name;
					value.OnBeginProcess+=new EventHandlerProcess(value_OnBeginProcess);
					value.OnEndProcess+=new EventHandlerProcess(value_OnEndProcess);
					value.OnProcess+=new EventHandlerProcess(value_OnProcess);
					value.OnProcessInfo+=new EventHandlerProcessInfor(value_OnProcessInfo);
					value.OnStateChange+=new EventHandlerProcessInfor(value_OnStateChange);
				}
			}
		}

		private delegate void MessageHandler1(int id,string filepath);

		private void value_OnBeginProcess1(int id,string filepath)
		{
			this.lblTitle.Text = filepath;
			this.lblProgress.Text = "Begin Process";
		}

		private void value_OnBeginProcess(int id,string filepath, ProcessEventArgs e)
		{
			if(!this.InvokeRequired)
				value_OnBeginProcess1(id,filepath);
			else
			{
				this.BeginInvoke(new MessageHandler1(value_OnBeginProcess1),new object[]{id,filepath});
			}
		}



		private void value_OnEndProcess1(int id,string filepath)
		{
			this.lblTitle.Text = filepath;
			this.lblProgress.Text = "End Process";
		}
		private void value_OnEndProcess(int id,string filepath, ProcessEventArgs e)
		{
			if(!this.InvokeRequired)
				value_OnEndProcess1(id,filepath);
			else
			{
				this.BeginInvoke(new MessageHandler1(value_OnEndProcess1),new object[]{id,filepath});
			}
		}

		private void value_OnProcess1(int id,string filepath)
		{
			this.lblTitle.Text = filepath;
			this.lblProgress.Text = "Processing...";
		}
		private void value_OnProcess(int id,string filepath, ProcessEventArgs e)
		{
			if(!this.InvokeRequired)
				value_OnProcess1(id,filepath);
			else
			{
				this.BeginInvoke(new MessageHandler1(value_OnProcess1),new object[]{id,filepath});
			}
		}

		public bool	IsRunning
		{
			get
			{
				return this.DataSource.IsRunning;
			}
		}

		public override void Stop()
		{
			this.DataSource.Stop();
			base.Stop();
		}

		public override void Run()
		{
			this.DataSource.Execute();
			base.Run();
		}

		private delegate void MessageHandler();
		private void value_OnStateChange(int id,string sender, EventArgs e)
		{
			if(!this.InvokeRequired)
				RefreshStatus();
			else
			{
				this.BeginInvoke(new MessageHandler(RefreshStatus),null);
			}
			this.HandlerChangeStatus();
		}

		public void RefreshStatus()
		{
			if(this.pictureBox1.Image!=null)
			{
				Bitmap bmp = this.pictureBox1.Image as Bitmap;
				this.pictureBox1.Image = null;
				bmp.Dispose();
			}
			
			if(this.DataSource.IsRunning)
			{
				if( this.DataSource.IsWaiting)
					this.pictureBox1.Image = new Bitmap(this.GetType(),_DataSource.WaitingImage);
				else
				{
					this.pictureBox1.Image = new Bitmap(this.GetType(),_DataSource.RunningImage);
					this.Caption = this.DataSource.Name + " Running...";
				}
			}
			else
			{
				this.pictureBox1.Image = new Bitmap(this.GetType(),_DataSource.StopImage);
				this.Caption = this.DataSource.Name;
			}
		}

	
		private void value_OnProcessInfo1(int id,string description)
		{
			try
			{
				if( this.DataSource.IsWaiting)
					this.lblTitle.Text = "no file";
				this.lblProgress.Text = description;
			}
			catch
			{
			}
		}
		
		private void value_OnProcessInfo(int id,string description, EventArgs e)
		{
			if(!this.InvokeRequired)
				value_OnProcessInfo1(id,description);
			else
			{
				this.BeginInvoke(new MessageHandler1(value_OnProcessInfo1),new object[]{id,description});
			}
		}

		private void LoadETestProcessViewCtrl_Load(object sender, System.EventArgs e)
		{
			RefreshStatus();
		}


		public override bool CheckInvalidate()
		{
			Process.ProcessBase obj = this.DataSource as Process.ProcessBase;
			if( obj.ValidateString!=string.Empty)
			{
				MessageBox.Show("Invalidate : " + obj.ValidateString,this.ParentForm.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			return true;
		}


	}

}

