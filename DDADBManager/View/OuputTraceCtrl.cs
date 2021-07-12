using System;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using DDADBManager.Modal;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for OuputTextCtrl.
	/// </summary>
	public class OuputTraceCtrl : System.Windows.Forms.UserControl
	{
		private SiGlaz.Windows.Forms.RichTextBoxEx txtText;
		private Modal.TraceHistory _DataSource;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OuputTraceCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			//txtText.DetectUrls = false;

			
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
            this.txtText = new SiGlaz.Windows.Forms.RichTextBoxEx();
			this.SuspendLayout();
			// 
			// txtText
			// 
			this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtText.Location = new System.Drawing.Point(0, 0);
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(720, 200);
			this.txtText.TabIndex = 0;
			this.txtText.Text = "";
			this.txtText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtText_LinkClicked);
			// 
			// OuputTextCtrl
			// 
			this.Controls.Add(this.txtText);
			this.Name = "OuputTextCtrl";
			this.Size = new System.Drawing.Size(720, 200);
			this.ResumeLayout(false);

		}
		#endregion

		public Modal.TraceHistory DataSource
		{
			get
			{
				return this._DataSource;
			}
			set
			{
				if(this._DataSource!=null)
					this._DataSource.OnNewLine-=new DDADBManager.Modal.TraceHistory.TraceNewLinEventHandler(_DataSource_OnNewLine);

				this._DataSource = value;

				if(this._DataSource!=null)
				{
					this._DataSource.OnNewLine+=new DDADBManager.Modal.TraceHistory.TraceNewLinEventHandler(_DataSource_OnNewLine);
				
					try
					{
						Monitor.Enter(txtText);

						txtText.Text = string.Empty;

//
//						foreach(TraceHistory.LineItem line in _DataSource.Contents)
//						{
//							foreach(TraceHistory.ControlItem  item in line.LineItems)
//							{
//								if(item is TraceHistory.HyperLinkItem)
//									txtText.InsertLink( (item as TraceHistory.HyperLinkItem).hyperlink );
//								else
//									txtText.SelectedText += item.text;
//							}
//							txtText.SelectedText += Environment.NewLine;
//						}

						//txtText.Text = this._DataSource.Content;
						//txtText.SelectionStart=txtText.MaxLength-1;
					}
					catch
					{
					}
					finally
					{
						Monitor.Exit(txtText);
					}
				}
			}
		}

	
		private void _DataSource_OnNewLine(DDADBManager.Modal.TraceHistory.LineItem lineitem)
		{
			try
			{
				Monitor.Enter(txtText);

				if(txtText.Lines.Length>= Modal.TextHistory.MaxLine)
				{
					int length = txtText.Text.IndexOf("\n") + 1;
					txtText.Select(0,length);
					txtText.SelectedText="";
				}

				foreach(TraceHistory.ControlItem  item in lineitem.LineItems)
				{
					if(item is TraceHistory.HyperLinkItem)
						txtText.InsertLink(  (item as TraceHistory.HyperLinkItem).hyperlink );
					else
						txtText.SelectedText +=item.text;
				}

				txtText.SelectedText += Environment.NewLine;
			
				SiGlaz.Utility.ControlWin32.ScrollToBottom(txtText);


			}
			catch
			{
			}
			finally
			{
				Monitor.Exit(txtText);
			}
		}

		private void txtText_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}
	}
}
