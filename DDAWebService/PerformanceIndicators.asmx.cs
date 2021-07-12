using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;

namespace DDAWebService
{
	[WebService(Namespace = "http://siglaz.com")]
	public class PerformanceIndicators : System.Web.Services.WebService
	{
		public PerformanceIndicators()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod]
		public PerformanceIndicatorsResult GetChartData(PerformanceIndicatorsRecipe recipe)
		{
			SiGlaz.DDA.Business.PerformanceIndicators cmd = new SiGlaz.DDA.Business.PerformanceIndicators(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetChartData(recipe);
		}

		[WebMethod]
		public DataSetResult GetHintData(string fabID, string cubeType, string cubeName, string fieldName, DateTime from, DateTime to, string filter)
		{
			SiGlaz.DDA.Business.PerformanceIndicators cmd = new SiGlaz.DDA.Business.PerformanceIndicators(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetHintData(fabID, cubeType, cubeName, fieldName, from, to, filter);
		}

		[WebMethod]
		public DataSetResult GetCubeNames()
		{
			SiGlaz.DDA.Business.PerformanceIndicators cmd = new SiGlaz.DDA.Business.PerformanceIndicators(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetCubeNames();
		}

		[WebMethod]
		public DataSetResult GetFabList()
		{
			SiGlaz.DDA.Business.PerformanceIndicators cmd = new SiGlaz.DDA.Business.PerformanceIndicators(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetFabList();
		}

		[WebMethod]
		public DataSetResult GetDateList(string cubeName)
		{
			SiGlaz.DDA.Business.PerformanceIndicators cmd = new SiGlaz.DDA.Business.PerformanceIndicators(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetDateList(cubeName);
		}
	}
}
