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
	public class YieldTrendPlot : System.Web.Services.WebService
	{
		public YieldTrendPlot()
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

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod]
		public YieldTrendPlotResult GetChartData(YieldTrendPlotRecipe recipe)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetChartData(recipe);
		}

		[WebMethod]
		public DataSetResult GetHintData(string fabID, string cubeType, string cubeName, string fieldName, DateTime from, DateTime to, string filter)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetHintData(fabID, cubeType, cubeName, fieldName, from, to, filter);
		}

		[WebMethod]
		public DataSetResult GetCubeNames(string cubeType)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetCubeNames(cubeType);
		}

		[WebMethod]
		public DataSetResult GetFabList()
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetFabList();
		}

		[WebMethod]
		public DataSetResult GetDateList(string cubeName, string cubeType)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetDateList(cubeName, cubeType);
		}

		[WebMethod]
		public DataSetResult GetTemplateList()
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetTemplateList();
		}

		[WebMethod]
		public DataSetResult GetTemplateDetail(int templateKey)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.GetTemplateDetail(templateKey);
		}

		[WebMethod]
		public bool CheckIsActive(int cubeKey)
		{
			SiGlaz.DDA.Business.YieldTrendPlot cmd = new SiGlaz.DDA.Business.YieldTrendPlot(SiGlaz.Common.DDA.DDADBType.DDADataMarts);
			return cmd.CheckIsActive(cubeKey);
		}
	}
}
