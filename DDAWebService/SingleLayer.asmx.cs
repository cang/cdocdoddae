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
	/// <summary>
	/// Summary description for SingleLayer.
	/// </summary>
	/// 
	[WebService(Namespace="http://siglaz.com")]
	public class SingleLayer : System.Web.Services.WebService
	{
		public SingleLayer()
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

		#region DDADB Query Methods
		[WebMethod(MessageName="GetResultThumbnail_DDADB")]
		public byte[] GetResultThumbnail(long resultDetailKey)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultThumbnail(resultDetailKey);
		}

		[WebMethod(MessageName="GetResultThumbnailFlat_DDADB")]
		public byte[] GetResultThumbnailFlat(long resultDetailKey)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultThumbnailFlat(resultDetailKey);
		}

		[WebMethod(MessageName="GetResultRawData_DDADB")]
		public byte[] GetResultRawData(long resultDetailKey)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultRawData(resultDetailKey);
		}

		[WebMethod(MessageName="GetSingleLayerPaging_DDADB")]
		public DataSetResult GetSingleLayerPaging(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetSingleLayerPaging(recipe);
		}

		[WebMethod(MessageName="GetHintData_DDADB")]
		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetHintData(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetSurfaceHasSignature_DDADB")]
		public DataSetResult GetSurfaceHasSignature(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetSurfaceHasSignature(recipe);
		}

		[WebMethod(MessageName="GetResultBySurfaceKey_DDADB")]
		public DataSetResult GetResultBySurfaceKey(long surfaceKey, SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultBySurfaceKey(surfaceKey, recipe);
		}

		[WebMethod(MessageName="GetResultBySurfaceKey2_DDADB")]
		public DataSetResult GetResultBySurfaceKey(long surfaceKey, string sqlWhere)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultBySurfaceKey(surfaceKey, sqlWhere);
		}

		[WebMethod(MessageName="GetResultByResultDetailKey_DDADB")]
		public DataSetResult GetResultByResultDetailKey(long resultDetailKey)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetResultByResultDetailKey(resultDetailKey);
		}

		[WebMethod(MessageName="GetTotalRow_SingleLayer_DDADB")]
		public ResultBase GetTotalRow_SingleLayer(string sqlWhere)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetTotalRow_SingleLayer(sqlWhere);
		}

		[WebMethod(MessageName="GetTotalRow_SurfaceHasSignature_DDADB")]
		public ResultBase GetTotalRow_SurfaceHasSignature(string sqlWhere)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetTotalRow_SurfaceHasSignature(sqlWhere);
		}

		[WebMethod(MessageName="GetSignatureParetoChart_DDADB")]
		public ChartResult GetSignatureParetoChart(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetSignatureParetoChart(recipe);
		}

		[WebMethod(MessageName="GetSignatureParetoChartIndividualResource_TestCell_DDADB")]
		public ChartResult GetSignatureParetoChartIndividualResource_TestCell(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer();
			return cmd.GetSignatureParetoChartIndividualResource_TestCell(recipe);
		}
		#endregion

		#region DDAStagingArea Query Methods
		[WebMethod(MessageName="GetResultThumbnail_DDAStagingArea")]
		public byte[] GetResultThumbnail(long resultDetailKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultThumbnail(resultDetailKey);
		}

		[WebMethod(MessageName="GetResultThumbnailFlat_DDAStagingArea")]
		public byte[] GetResultThumbnailFlat(long resultDetailKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultThumbnailFlat(resultDetailKey);
		}

		[WebMethod(MessageName="GetResultRawData_DDAStagingArea")]
		public byte[] GetResultRawData(long resultDetailKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultRawData(resultDetailKey);
		}

		[WebMethod(MessageName="GetSingleLayerPaging_DDAStagingArea")]
		public DataSetResult GetSingleLayerPaging(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetSingleLayerPaging(recipe);
		}

		[WebMethod(MessageName="GetHintData_DDAStagingArea")]
		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetHintData(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetSurfaceHasSignature_DDAStagingArea")]
		public DataSetResult GetSurfaceHasSignature(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetSurfaceHasSignature(recipe);
		}

		[WebMethod(MessageName="GetResultBySurfaceKey_DDAStagingArea")]
		public DataSetResult GetResultBySurfaceKey(long surfaceKey, SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultBySurfaceKey(surfaceKey, recipe);
		}

		[WebMethod(MessageName="GetResultBySurfaceKey2_DDAStagingArea")]
		public DataSetResult GetResultBySurfaceKey(long surfaceKey, string sqlWhere, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultBySurfaceKey(surfaceKey, sqlWhere);
		}

		[WebMethod(MessageName="GetResultByResultDetailKey_DDAStagingArea")]
		public DataSetResult GetResultByResultDetailKey(long resultDetailKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetResultByResultDetailKey(resultDetailKey);
		}

		[WebMethod(MessageName="GetTotalRow_SingleLayer_DDAStagingArea")]
		public ResultBase GetTotalRow_SingleLayer(string sqlWhere, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetTotalRow_SingleLayer(sqlWhere);
		}

		[WebMethod(MessageName="GetTotalRow_SurfaceHasSignature_DDAStagingArea")]
		public ResultBase GetTotalRow_SurfaceHasSignature(string sqlWhere, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetTotalRow_SurfaceHasSignature(sqlWhere);
		}

		[WebMethod(MessageName="GetSignatureParetoChart_DDAStagingArea")]
		public ChartResult GetSignatureParetoChart(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetSignatureParetoChart(recipe);
		}

		[WebMethod(MessageName="GetSignatureParetoChartIndividualResource_TestCell_DDAStagingArea")]
		public ChartResult GetSignatureParetoChartIndividualResource_TestCell(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.SingleLayer cmd = new SiGlaz.DDA.Business.SingleLayer(type);
			return cmd.GetSignatureParetoChartIndividualResource_TestCell(recipe);
		}
		#endregion
	}
}
