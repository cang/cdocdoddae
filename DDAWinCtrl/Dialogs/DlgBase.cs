using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SiGlaz.Utility;

namespace DDAWinCtrl.Dialogs
{
	/// <summary>
	/// Summary description for DlgBase.
	/// </summary>
	public class DlgBase : System.Windows.Forms.Form
	{
		public DlgBase()
		{
			// initialize windows resources
			this.InitializeComponent();

			// initialize basic properties
			this.MaximizeBox = false;
			this.MinimizeBox = false;		
			this.StartPosition = FormStartPosition.CenterParent;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			//this.ShowInTaskbar = false;
		}

		private void InitializeComponent()
		{
			// 
			// DlgBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "DlgBase";

		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			EnableVisualStyles(this);
		}

		protected virtual void EnableVisualStyles(Control ctrl)
		{
			if (ctrl == null)
				return;

			Type type = ctrl.GetType();

			if(type!=typeof(SiGlaz.Recipes.Canvas))
			{
				System.Reflection.PropertyInfo objFlatStyle = type.GetProperty("FlatStyle");
				if(objFlatStyle!=null)
					objFlatStyle.SetValue(ctrl,FlatStyle.System,null);
			}

			if (ctrl.Controls.Count > 0)
			{
				foreach (Control childControl in ctrl.Controls)
					EnableVisualStyles(childControl);
			}
		}


	}

	public class DlgPersistence : DlgBase
	{
		private bool _persist = false;

		public bool Persist
		{
			get {return _persist;}
			set {_persist = value;}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// initialize persistence data
			PersistenceDefaultForm obj = new PersistenceDefaultForm(this);
			obj.Load();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed (e);

			// uninitialized persistence data
			PersistenceDefaultForm obj = new PersistenceDefaultForm(this);
			obj.Save();
		}
	}
}
