using System;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using DDARecipe;

namespace DDARMWinUI.Controls
{
	/// <summary>
	/// Summary description for ctrlDebugResult.
	/// </summary>
	public class ctrlDebugResult : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabPage tabOutput;
		private System.Windows.Forms.TabPage tabTrace;
		private System.Windows.Forms.RichTextBox txtOutput;
		private System.Windows.Forms.RichTextBox txtTrace;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem miClearAll;
		private DDARecipe.DDARecipe		_Recipe;


		public ctrlDebugResult()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctrlDebugResult));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabOutput = new System.Windows.Forms.TabPage();
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.miClearAll = new System.Windows.Forms.MenuItem();
			this.tabTrace = new System.Windows.Forms.TabPage();
			this.txtTrace = new System.Windows.Forms.RichTextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1.SuspendLayout();
			this.tabOutput.SuspendLayout();
			this.tabTrace.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl1.Controls.Add(this.tabOutput);
			this.tabControl1.Controls.Add(this.tabTrace);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(760, 360);
			this.tabControl1.TabIndex = 0;
			// 
			// tabOutput
			// 
			this.tabOutput.Controls.Add(this.txtOutput);
			this.tabOutput.ImageIndex = 0;
			this.tabOutput.Location = new System.Drawing.Point(4, 4);
			this.tabOutput.Name = "tabOutput";
			this.tabOutput.Size = new System.Drawing.Size(752, 333);
			this.tabOutput.TabIndex = 0;
			this.tabOutput.Text = "Output";
			// 
			// txtOutput
			// 
			this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutput.ContextMenu = this.contextMenu1;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtOutput.Location = new System.Drawing.Point(0, 0);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(752, 333);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.Text = "";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.miClearAll});
			// 
			// miClearAll
			// 
			this.miClearAll.Index = 0;
			this.miClearAll.OwnerDraw = true;
			this.miClearAll.Text = "Clear All";
			this.miClearAll.Click += new System.EventHandler(this.miClearAll_Click);
			// 
			// tabTrace
			// 
			this.tabTrace.Controls.Add(this.txtTrace);
			this.tabTrace.ImageIndex = 1;
			this.tabTrace.Location = new System.Drawing.Point(4, 4);
			this.tabTrace.Name = "tabTrace";
			this.tabTrace.Size = new System.Drawing.Size(752, 333);
			this.tabTrace.TabIndex = 1;
			this.tabTrace.Text = "Trace Log";
			// 
			// txtTrace
			// 
			this.txtTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTrace.ContextMenu = this.contextMenu1;
			this.txtTrace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTrace.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTrace.ForeColor = System.Drawing.Color.DarkRed;
			this.txtTrace.Location = new System.Drawing.Point(0, 0);
			this.txtTrace.Name = "txtTrace";
			this.txtTrace.Size = new System.Drawing.Size(752, 333);
			this.txtTrace.TabIndex = 0;
			this.txtTrace.Text = "";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// 
			// ctrlDebugResult
			// 
			this.Controls.Add(this.tabControl1);
			this.Name = "ctrlDebugResult";
			this.Size = new System.Drawing.Size(760, 360);
			this.tabControl1.ResumeLayout(false);
			this.tabOutput.ResumeLayout(false);
			this.tabTrace.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private delegate void MessageHandler(string message);

		public DDARecipe.DDARecipe		Recipe
		{
			get
			{
				return _Recipe;
			}
			set
			{
				if(_Recipe!=null)
				{
					if(_Recipe.TextHistory!=null)
						_Recipe.TextHistory.OnAddNewLine-=new EventHandler(TextHistory_OnAddNewLine);
					if(_Recipe.TraceHistory!=null)
						_Recipe.TraceHistory.OnAddNewLine-=new EventHandler(TraceHistory_OnAddNewLine);
				}
				_Recipe = value;

				//Reset
//				try
//				{
//					Monitor.Enter(txtOutput);
//					txtOutput.Text = string.Empty;
//					txtTrace.Text = string.Empty;
//				}
//				finally
//				{
//					Monitor.Exit(txtOutput);
//				}

				if(_Recipe!=null)
				{
					//Restore TextHistory
					if(_Recipe.TextHistory!=null)
					{
						_Recipe.TextHistory.OnAddNewLine+=new EventHandler(TextHistory_OnAddNewLine);
						if(!this.txtOutput.InvokeRequired)
							SetTextContent(_Recipe.TextHistory.Content);
						else
						{
							MessageHandler dele = new MessageHandler(SetTextContent);
							this.txtOutput.BeginInvoke(dele,new object[]{_Recipe.TextHistory.Content});
						}
					}

					//Restore TraceHistory
					if(_Recipe.TraceHistory!=null)
					{
						_Recipe.TraceHistory.OnAddNewLine+=new EventHandler(TraceHistory_OnAddNewLine);
						if(!this.txtTrace.InvokeRequired)
							SetTraceContent(_Recipe.TraceHistory.Content);
						else
						{
							MessageHandler dele = new MessageHandler(SetTraceContent);
							this.txtTrace.BeginInvoke(dele,new object[]{_Recipe.TraceHistory.Content});
						}
					}
				}
			}
		}

		private void SetTextContent(string msg)
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtOutput");
			try
			{
				//Monitor.Enter(txtOutput);
				lck.WaitOne();
				txtOutput.Text = msg;
			}
			finally
			{
				//Monitor.Exit(txtOutput);
				lck.Release();
				lck.Dispose();
			}
		}

		private void SetTraceContent(string msg)
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtTrace");
			try
			{
				//Monitor.Enter(txtTrace);
				lck.WaitOne();
				txtTrace.Text = msg;
			}
			finally
			{
				//Monitor.Exit(txtTrace);
				lck.Release();
				lck.Dispose();
			}
		}

		private void TextHistory_OnAddNewLine(object sender, EventArgs e)
		{
			if(!this.txtOutput.InvokeRequired)
				TextHistory_OnAddNewLineSafe(sender.ToString());
			else
			{
				MessageHandler dele = new MessageHandler(TextHistory_OnAddNewLineSafe);
				this.txtOutput.BeginInvoke(dele,new object[]{sender.ToString()});
			}
		}

		private void TextHistory_OnAddNewLineSafe(string msg)
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtOutput");
			try
			{
				//Monitor.Enter(txtOutput);
				lck.WaitOne();

				if(this.Recipe!=null && this.Recipe.TextHistory!=null && txtOutput.Lines.Length>= this.Recipe.TextHistory.MaxLine)
				{
					int length = txtOutput.Text.IndexOf("\n") + 1;
					txtOutput.Select(0,length);
					txtOutput.SelectedText="";
				}

				txtOutput.AppendText(msg);

				SiGlaz.Utility.ControlWin32.ScrollToBottom(txtOutput);
			}
			finally
			{
				lck.Release();
				lck.Dispose();
				//Monitor.Exit(txtOutput);
			}
		}

		private void TraceHistory_OnAddNewLine(object sender, EventArgs e)
		{
			if(!this.txtTrace.InvokeRequired)
				TraceHistory_OnAddNewLineSafe(sender.ToString());
			else
			{
				MessageHandler dele = new MessageHandler(TraceHistory_OnAddNewLineSafe);
				this.txtTrace.BeginInvoke(dele,new object[]{sender.ToString()});
			}
		}

		private void TraceHistory_OnAddNewLineSafe(string msg)
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtTrace");
			try
			{
				//Monitor.Enter(txtTrace);
				lck.WaitOne();

				if(this.Recipe!=null && this.Recipe.TraceHistory!=null && txtTrace.Lines.Length>= this.Recipe.TraceHistory.MaxLine)
				{
					int length = txtTrace.Text.IndexOf("\n") + 1;
					txtTrace.Select(0,length);
					txtTrace.SelectedText="";
				}

				txtTrace.AppendText(msg);

				SiGlaz.Utility.ControlWin32.ScrollToBottom(txtTrace);
			}
			finally
			{
				lck.Release();
				lck.Dispose();
				//Monitor.Exit(txtTrace);
			}
		}

		public void ScrollToBottom()
		{
			SiGlaz.Utility.ControlWin32.ScrollToBottom(txtOutput);
			SiGlaz.Utility.ControlWin32.ScrollToBottom(txtTrace);
		}


		private void miClearAll_Click(object sender, System.EventArgs e)
		{
			if(tabControl1.SelectedTab == tabOutput)
			{
				if(this.Recipe!=null && this.Recipe.TextHistory!=null && this.Recipe.TextHistory.NumberLine>0)
				{
					this.Recipe.TextHistory.Clear();

					SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtOutput");
					try
					{
						lck.WaitOne();
						txtOutput.Text = string.Empty;
					}
					finally
					{
						lck.Release();
						lck.Dispose();
					}
				}
			}
			else
			{
				if(this.Recipe!=null && this.Recipe.TraceHistory!=null && this.Recipe.TraceHistory.NumberLine>0)
				{
					this.Recipe.TextHistory.Clear();

					SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDARMController.txtTrace");
					try
					{
						lck.WaitOne();
						txtTrace.Text = string.Empty;
					}
					finally
					{
						lck.Release();
						lck.Dispose();
					}
				}
			}
		}
		


	}
}
