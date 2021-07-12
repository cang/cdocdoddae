using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;
using DDANavigator.Dialogs;

namespace DDANavigator.Controls
{
	#region Delegate Events
	public delegate void TestDateChangedHandler(TimeFilter timeFilter);
	public delegate void FabIDChangedHandler(string fabID);
	public delegate void ViewChartHandler(WebServiceProxy.SingleLayerProxy.ChartResult result);
	public delegate void ClearChartHandler();
	public delegate void ResourceTypeChangedHandler(string resourceType);
	public delegate void InitGroupByHandler(WebServiceProxy.SingleLayerProxy.ChartResult result);
	#endregion

	public class ctrlBase : System.Windows.Forms.UserControl
	{
		#region Members
		private System.ComponentModel.Container components = null;
        protected DlgStatus _dlgStatus = null;
		#endregion

		#region Events	
		public event TestDateChangedHandler OnTimeChanged = null;
		public event FabIDChangedHandler OnFabIDChanged = null;
		public event ResourceTypeChangedHandler OnResourceTypeChanged = null;
		#endregion
		
		#region Constructor & Destructor
		public ctrlBase()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ctrlBase
			// 
			this.Name = "ctrlBase";
			this.Size = new System.Drawing.Size(380, 212);

		}
		#endregion

        #region UI Command
        protected void CloseDialogWaiting()
        {
            MethodInvoker invoke = delegate
            {
                if (_dlgStatus != null)
                {
                    _dlgStatus.Close();
                    _dlgStatus = null;
                }
            };

            BeginInvoke(invoke);
        }
        #endregion

		#region Raise Events
		public void RaiseTimeChanged(TimeFilter time)
		{
			if (OnTimeChanged != null)
				OnTimeChanged(time);
		}

		public void RaiseFabChanged(string fabID)
		{
			if (OnFabIDChanged != null)
				OnFabIDChanged(fabID);
		}

		public void RaiseResourceTypeChanged(string resourceType)
		{
			if (OnResourceTypeChanged != null)
				OnResourceTypeChanged(resourceType);
		}
		#endregion
	}
}
