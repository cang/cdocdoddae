using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDADBManager.View
{
	/// <summary>
	/// Summary description for SchemaViewCrl.
	/// </summary>
	public class SchemaViewCrl : System.Windows.Forms.UserControl
	{
		//private DDADBManager.Process.Schema _DataSource = null;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pContainer;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event EventHandler		OnSelectedChanged;

		public SchemaViewCrl()
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

		public void Add(ProcessViewCtrl ctrl)
		{
			int top = 0;
			if(pContainer.Controls.Count>0) 
			{
				ProcessViewCtrl ctrlprev = pContainer.Controls[pContainer.Controls.Count-1] as ProcessViewCtrl;
				top = ctrlprev.Top + ctrlprev.Height;
			}
			ctrl.Top = top;
			ctrl.Left = 0;
			ctrl.Width = pContainer.Width;
			ctrl.Anchor =AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ctrl.OnBeforeSelected+=new EventHandler(ctrl_OnBeforeSelected);
			ctrl.OnSelectedChanged+=new EventHandler(ctrl_OnSelectedChanged);
			pContainer.Controls.Add(ctrl);

			if(pContainer.Controls.Count==1)
			{
				this.ResetSelect();
				ctrl.Selected = true;
			}
			pContainer.Height =  top + ctrl.Height + 10;
		}
	

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.pContainer = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.pContainer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(608, 272);
			this.panel1.TabIndex = 0;
			// 
			// pContainer
			// 
			this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pContainer.Location = new System.Drawing.Point(0, 0);
			this.pContainer.Name = "pContainer";
			this.pContainer.Size = new System.Drawing.Size(604, 224);
			this.pContainer.TabIndex = 0;
			// 
			// SchemaViewCrl
			// 
			this.Controls.Add(this.panel1);
			this.Name = "SchemaViewCrl";
			this.Size = new System.Drawing.Size(608, 272);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ResetSelect()
		{
			foreach(View.ProcessViewCtrl ctrl in this.pContainer.Controls)
			{
				if(ctrl.Selected)
					ctrl.Selected = false;
			}
		}


		private void ctrl_OnBeforeSelected(object sender, EventArgs e)
		{
			this.ResetSelect();
		}

		public View.ProcessViewCtrl[] AllProcessCtrl
		{
			get
			{
				View.ProcessViewCtrl[] result = new ProcessViewCtrl[this.pContainer.Controls.Count];
				this.pContainer.Controls.CopyTo(result,0);
				return result;
			}
		}

		/// <summary>
		/// ArrayList of DataSourceBase
		/// </summary>
		public ArrayList AllProcessSource
		{
			get
			{
				ArrayList alResult = new ArrayList();
				foreach(View.ProcessViewCtrl ctrl in AllProcessCtrl)
				{
					alResult.Add(ctrl.DataSourceBase);
				}
				return alResult;
			}
		}

		public void DeleteAll()
		{
			this.pContainer.Controls.Clear();
			this.pContainer.Height = 10;
			ctrl_OnSelectedChanged(null,null);
		}

		public View.ProcessViewCtrl SelectedControl
		{
			get
			{
				foreach(View.ProcessViewCtrl ctrl in this.pContainer.Controls)
				{
					if( ctrl.Selected)
						return ctrl;
				}
				return null;
			}
			set
			{
				this.ResetSelect();
				foreach(View.ProcessViewCtrl ctrl in this.pContainer.Controls)
				{
					if(ctrl==value)
					{
						ctrl.Selected = true;
						return;
					}
				}
			}
		}

//		[Browsable(false)]
//		public DDADBManager.Process.Schema DataSource
//		{
//			get
//			{
//				return _DataSource;
//			}
//			set
//			{
//				_DataSource = value;
//			}
		//		}

		private void ctrl_OnSelectedChanged(object sender, EventArgs e)
		{
			if(OnSelectedChanged!=null)
				OnSelectedChanged(sender,e);
		}

		private int IndexOfCtrl(View.ProcessViewCtrl ctrl)
		{
			for(int i=0;i<this.pContainer.Controls.Count;i++)
			{
				if(ctrl == this.pContainer.Controls[i])
					return i;
			}
			return -1;
		}

		public void Delete(View.ProcessViewCtrl ctrl)
		{
			//Search ctrl
			int index = this.IndexOfCtrl(ctrl);
			if( index==-1) return;
			//Move Up
			for(int i=index+1;i< this.pContainer.Controls.Count;i++)
			{
				this.pContainer.Controls[i].Top-=this.pContainer.Controls[i].Height;
			}
			this.pContainer.Controls.RemoveAt(index);

			if(this.pContainer.Controls.Count>0)
			{
				if(index>0)
					index--;
				(this.pContainer.Controls[index] as View.ProcessViewCtrl).Selected = true;
			}
			else
				ctrl_OnSelectedChanged(null,null);

			this.pContainer.Height = this.pContainer.Controls.Count*ctrl.Height + 10;
		}


	}
}
