using System;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for OuputTextCtrl.
	/// </summary>
	public class OuputTextCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.RichTextBox txtText;
        private Modal.TextHistory _DataSource;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mitCopy;
        private ToolStripMenuItem mitClearAll;
		private System.ComponentModel.IContainer components;

		public OuputTextCtrl()
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
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mitClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.ContextMenuStrip = this.contextMenuStrip1;
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(0, 0);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(720, 200);
            this.txtText.TabIndex = 0;
            this.txtText.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitCopy,
            this.mitClearAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // mitCopy
            // 
            this.mitCopy.Name = "mitCopy";
            this.mitCopy.Size = new System.Drawing.Size(118, 22);
            this.mitCopy.Text = "Copy";
            this.mitCopy.Click += new System.EventHandler(this.mitCopy_Click);
            // 
            // mitClearAll
            // 
            this.mitClearAll.Name = "mitClearAll";
            this.mitClearAll.Size = new System.Drawing.Size(118, 22);
            this.mitClearAll.Text = "Clear All";
            this.mitClearAll.Click += new System.EventHandler(this.mitClearAll_Click);
            // 
            // OuputTextCtrl
            // 
            this.Controls.Add(this.txtText);
            this.Name = "OuputTextCtrl";
            this.Size = new System.Drawing.Size(720, 200);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		public Modal.TextHistory DataSource
		{
			get
			{
				return this._DataSource;
			}
			set
			{
				if(this._DataSource!=null)
					this._DataSource.OnAddNewLine-=new DDADBManager.Modal.MessageLine(_DataSource_OnAddNewLine);

				this._DataSource = value;

				if(this._DataSource!=null)
				{
					this._DataSource.OnAddNewLine+=new DDADBManager.Modal.MessageLine(_DataSource_OnAddNewLine);

					if (txtText.InvokeRequired == false)
					{
						crossThreadSetNewContent(this._DataSource.Content);
					}
					else
					{
						// Show the text asynchronously
						MessageHandler statusDelegate =
							new MessageHandler(crossThreadSetNewContent);

						this.txtText.BeginInvoke(statusDelegate,
							new object[] { this._DataSource.Content });
					}
				}
			}
		}

		private delegate void MessageHandler(string message);
		private void _DataSource_OnAddNewLine(int id, string message)
		{
			if (txtText.InvokeRequired == false)
			{
				crossThreadAddNewLine(message);
			}
			else
			{
				// Show the text asynchronously
				MessageHandler statusDelegate =
					new MessageHandler(crossThreadAddNewLine);

				this.txtText.BeginInvoke(statusDelegate,
					new object[] { message });
			}
		}

		private void crossThreadSetNewContent(string message)
		{
			try
			{
				Monitor.Enter(txtText);
				txtText.Text = message;
				txtText.SelectionStart=txtText.MaxLength-1;
			}
			catch
			{
			}
			finally
			{
				Monitor.Exit(txtText);
			}
		}

		private void crossThreadAddNewLine(string message)
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
				txtText.AppendText(message);
				SiGlaz.Utility.ControlWin32.ScrollToBottom(txtText);
//				txtText.SelectionStart=txtText.Text.Length;
//				txtText.SelectionLength=0;
//				txtText.ScrollToCaret();
			}
			catch
			{
			}
			finally
			{
				Monitor.Exit(txtText);
			}
		}

        private void mitCopy_Click(object sender, EventArgs e)
        {
            string txtCopy = txtText.SelectedText;
            if (txtCopy != null && txtCopy != string.Empty)
                System.Windows.Forms.Clipboard.SetDataObject(txtCopy);

        }

        private void mitClearAll_Click(object sender, EventArgs e)
        {
            if (_DataSource != null && _DataSource.NumberLine > 0)
                _DataSource.Clear();

            try
            {
                Monitor.Enter(txtText);
                txtText.Text = string.Empty;
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
