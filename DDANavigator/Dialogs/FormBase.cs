using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDANavigator.Dialogs
{
	public class FormBase : System.Windows.Forms.Form
	{
		#region Members
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region Constructor & Destructor 
		public FormBase()
		{
			InitializeComponent();

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
			// 
			// FormBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "FormBase";
			this.Text = "FormBase";

		}
		#endregion

		#region UI Command
		protected virtual void EnableVisualStyles(Control ctrl)
		{
			if (ctrl == null)
				return;

			Type type = ctrl.GetType();

			if (type != typeof(Label) && type != typeof(Panel))
			{
				if (type!=typeof(GroupBox))
				{
					if (type != typeof(Button))
					{
						if (type != typeof(RadioButton))
						{
							System.Reflection.PropertyInfo objFlatStyle = type.GetProperty("FlatStyle");
							if(objFlatStyle!=null)
								objFlatStyle.SetValue(ctrl,FlatStyle.System,null);
						}
						else if (((RadioButton)ctrl).BackgroundImage == null && ((RadioButton)ctrl).Image == null && ((RadioButton)ctrl).ImageIndex < 0)
						{
							System.Reflection.PropertyInfo objFlatStyle = type.GetProperty("FlatStyle");
							if(objFlatStyle!=null)
								objFlatStyle.SetValue(ctrl,FlatStyle.System,null);
						}
					}
					else if (((Button)ctrl).BackgroundImage == null && ((Button)ctrl).Image == null && ((Button)ctrl).ImageIndex < 0)
					{
						System.Reflection.PropertyInfo objFlatStyle = type.GetProperty("FlatStyle");
						if(objFlatStyle!=null)
							objFlatStyle.SetValue(ctrl,FlatStyle.System,null);
					}					
				}
				else if (ctrl.Size.Height > 8)
				{
					System.Reflection.PropertyInfo objFlatStyle = type.GetProperty("FlatStyle");
					if(objFlatStyle!=null)
						objFlatStyle.SetValue(ctrl,FlatStyle.System,null);
				}
			}
			
			if (ctrl.Controls.Count > 0)
			{
				foreach (Control childControl in ctrl.Controls)
					EnableVisualStyles(childControl);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			EnableVisualStyles(this);
		}
		#endregion
	}
}
