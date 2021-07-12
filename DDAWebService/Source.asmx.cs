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
	/// Summary description for Source.
	/// </summary>
	/// 
	[WebService(Namespace="http://siglaz.com")]
	public class Source : System.Web.Services.WebService
	{
		public Source()
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

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

		[WebMethod()]
		public long DiskInsert(SiGlaz.Common.DDA.Disk disk)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.DiskInsert(disk);
		}

		[WebMethod()]
		public long SurfaceInsert(SiGlaz.Common.DDA.Disk disk,SiGlaz.Common.DDA.Surface surface)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.SurfaceInsert(disk,surface);
		}

		[WebMethod()]
		public long	SurfaceInsertAll(SiGlaz.Common.DDA.Fab fab,SiGlaz.Common.DDA.Disk disk,SiGlaz.Common.DDA.Surface surface)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.SurfaceInsertAll(fab,disk,surface);
		}

		#region DDADB Query Methods
		[WebMethod(MessageName="GetSourceThumbnail_DDADB")]
		public byte[] GetSourceThumbnail(long surfaceKey)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetSourceThumbnail(surfaceKey);
		}
		
		[WebMethod(MessageName="GetSourceThumbnailFlat_DDADB")]
		public byte[] GetSourceThumbnailFlat(long surfaceKey)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetSourceThumbnailFlat(surfaceKey);
		}
		
		[WebMethod(MessageName="GetSourceRawData_DDADB")]
		public DataSet GetSourceRawData(long surfaceKey)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetSourceRawData(surfaceKey);
		}
		
		[WebMethod(MessageName="GetDataSourcePaging_DDADB")]
		public DataSetResult GetDataSourcePaging(DataSourceRecipe recipe)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetDataSourcePaging(recipe);
		}

		[WebMethod(MessageName="GetHintData_DDADB")]
		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetHintData(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetHintDataOfDisk_DDADB")]
		public DataSetResult GetHintDataOfDisk(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetHintDataOfDisk(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetSurfaceByDisk_DDADB")]
		public DataSetResult GetSurfaceByDisk(long diskKey)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetSurfaceByDisk(diskKey);
		}

		[WebMethod(MessageName="GetSourceOfDiskPaging_DDADB")]
		public DataSetResult GetSourceOfDiskPaging(DataSourceRecipe recipe)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetSourceOfDiskPaging(recipe);
		}

		[WebMethod(MessageName="GetTotalRow_SurfaceOfDisk_DDADB")]
		public ResultBase GetTotalRow_SurfaceOfDisk(string sqlWhere)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetTotalRow_SurfaceOfDisk(sqlWhere);
		}

		[WebMethod(MessageName="GetTotalRow_SourceOfDisk_DDADB")]
		public ResultBase GetTotalRow_SourceOfDisk(string sqlWhere)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source();
			return cmd.GetTotalRow_SourceOfDisk(sqlWhere);
		}
		#endregion

		#region DDAStagingArea Query Methods
		[WebMethod(MessageName="GetSourceThumbnail_DDAStagingArea")]
		public byte[] GetSourceThumbnail(long surfaceKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetSourceThumbnail(surfaceKey);
		}

		[WebMethod(MessageName="GetSourceThumbnailFlat_DDAStagingArea")]
		public byte[] GetSourceThumbnailFlat(long surfaceKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetSourceThumbnailFlat(surfaceKey);
		}

		[WebMethod(MessageName="GetSourceRawData_DDAStagingArea")]
		public DataSet GetSourceRawData(long surfaceKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetSourceRawData(surfaceKey);
		}

		[WebMethod(MessageName="GetDataSourcePaging_DDAStagingArea")]
		public DataSetResult GetDataSourcePaging(DataSourceRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetDataSourcePaging(recipe);
		}
		
		[WebMethod(MessageName="GetHintData_DDAStagingArea")]
		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetHintData(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetHintDataOfDisk_DDAStagingArea")]
		public DataSetResult GetHintDataOfDisk(string fabID, string fieldName, DateTime from, DateTime to, string filter, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetHintDataOfDisk(fabID, fieldName, from, to, filter);
		}

		[WebMethod(MessageName="GetSurfaceByDisk_DDAStagingArea")]
		public DataSetResult GetSurfaceByDisk(long diskKey, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetSurfaceByDisk(diskKey);
		}

		[WebMethod(MessageName="GetSourceOfDiskPaging_DDAStagingArea")]
		public DataSetResult GetSourceOfDiskPaging(DataSourceRecipe recipe, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetSourceOfDiskPaging(recipe);
		}

		[WebMethod(MessageName="GetTotalRow_SurfaceOfDisk_DDAStagingArea")]
		public ResultBase GetTotalRow_SurfaceOfDisk(string sqlWhere, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetTotalRow_SurfaceOfDisk(sqlWhere);
		}

		[WebMethod(MessageName="GetTotalRow_SourceOfDisk_DDAStagingArea")]
		public ResultBase GetTotalRow_SourceOfDisk(string sqlWhere, SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Source cmd = new SiGlaz.DDA.Business.Source(type);
			return cmd.GetTotalRow_SourceOfDisk(sqlWhere);
		}
		#endregion
	}
}
