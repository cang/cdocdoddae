using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace DDAWebService
{
	/// <summary>
	/// Summary description for Category.
	/// </summary>
	/// 
	[WebService(Namespace="http://siglaz.com")]
	public class Category : System.Web.Services.WebService
	{
		public Category()
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
		public string HelloWorld()
		{
			return "Hello World";
		}

		[WebMethod(MessageName="TestConnection_DDADB")]
		public bool TestConnection()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.TestConnection();
		}

		[WebMethod(MessageName="TestConnection_DDAStagingArea")]
		public bool TestConnection(SiGlaz.Common.DDA.DDADBType type)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category(type);
			return cmd.TestConnection();
		}


		#region DDA_Fabs

		[WebMethod()]
		public bool FabExist(short fabid)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.FabExist(fabid);
		}

		[WebMethod(MessageName="FabInsertName")]
		public short FabInsert(string fab)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.FabInsert(fab);
		}

		[WebMethod(MessageName="FabInsert")]
		public short FabInsert(Fab objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.FabInsert(objinsert);
		}

		[WebMethod()]
		public DataSetResult	FabList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.FabList();
		}

		[WebMethod()]
		public Fab				GetFabByFabID(string fabid)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GetFabByFabID(fabid);
		}

		#endregion DDA_Fabs

		#region DDA_Stations

		[WebMethod(MessageName="StationInsertName")]
		public int StationInsert(string station)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.StationInsert(station);
		}


		[WebMethod(MessageName="StationInsert")]
		public int StationInsert(Station objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.StationInsert(objinsert);
		}

		[WebMethod(MessageName="StationList")]
		public DataSetResult	StationList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.StationList();
		}

		#endregion DDA_Stations

		#region DDA_Products

		[WebMethod(MessageName="ProductInsertName")]
		public int ProductInsert(string Product)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductInsert(Product);
		}

		[WebMethod(MessageName="ProductInsert")]
		public int ProductInsert(Product objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductInsert(objinsert);
		}

		[WebMethod()]
		public DataSetResult	ProductListDataset()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductListDataset();
		}

		[WebMethod()]
		public ArrayList	ProductList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductList();
		}

		[WebMethod()]
		public ResultBase ProductDelete(int DiskSizeKey)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductDelete(DiskSizeKey);
		}

		[WebMethod()]
		public bool ProductCanDelete(int key)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductCanDelete(key);
		}
		

		#endregion DDA_Products

		#region DDA_WordCells

		[WebMethod(MessageName="WordCellsInsertName")]
		public int WordCellsInsert(string wordCell)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.WordCellsInsert(wordCell);
		}

		[WebMethod(MessageName="WordCellsInsert")]
		public int WordCellsInsert(WordCell objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.WordCellsInsert(objinsert);
		}

		[WebMethod(MessageName="WordCellsList")]
		public DataSetResult	WordCellsList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.WordCellsList();
		}

		#endregion DDA_WordCells

		#region DDA_DiskSizes

	
		[WebMethod()]
		public int DiskSizesInsert(DiskSize objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.DiskSizesInsert(objinsert);
		}

		[WebMethod(MessageName="DiskSizesListDataset")]
		public DataSetResult	DiskSizesListDataset()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.DiskSizesListDataset();
		}

		[WebMethod(MessageName="DiskSizesList")]
		public ArrayList	DiskSizesList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.DiskSizesList();
		}

		[WebMethod(MessageName="ProductDiskSizesListDataset")]
		public DataSetResult	ProductDiskSizesListDataset()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductDiskSizesListDataset();
		}
		
		[WebMethod(MessageName="ProductDiskSizesList")]
		public ArrayList	ProductDiskSizesList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductDiskSizesList();
		}

		[WebMethod()]
		public bool ProductDiskSizeExist(string productcode)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductDiskSizeExist(productcode);
		}

		[WebMethod()]
		public string ProductGetProductClass(string productcode)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ProductGetProductClass(productcode);
		}

		[WebMethod()]
		public ProductDiskSize GetProductDiskSize(string productcode)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GetProductDiskSize(productcode);
		}

		[WebMethod()]
		public ResultBase DiskSizesDelete(int DiskSizeKey)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.DiskSizesDelete(DiskSizeKey);
		}

		#endregion DDA_DiskSizes

		#region DDA_Channels

		[WebMethod(MessageName="ChannelsInsert")]
		public int ChannelsInsert(Channel objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ChannelsInsert(objinsert);
		}

		[WebMethod(MessageName="ChannelsList")]
		public DataSetResult	ChannelsList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ChannelsList();
		}

		#endregion DDA_WordCells
		
		#region DDA_Signatures

		[WebMethod()]
		public DataSetResult SignatureListToDataset()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureListToDataset();
		}

		[WebMethod()]
		public SignatureListResult SignatureList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureList();
		}

		[WebMethod()]
		public int SignatureInsert(SiGlaz.Common.DDA.Signature objinsert,bool updatebyName,bool skipUpdate)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureInsert(objinsert,updatebyName,skipUpdate);
		}
		
		[WebMethod()]
		public ResultBase SignatureDelete(int key)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureDelete(key);
		}

		[WebMethod()]
		public bool SignatureCanDelete(int key)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureCanDelete(key);
		}

		[WebMethod()]
		public Signature SignatureGetByKey(int key)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureGetByKey(key);
		}

		[WebMethod()]
		public Signature SignatureGetByName(string signatureName)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.SignatureGetByName(signatureName);
		}

		#endregion DDA_Signatures

		#region not using now
		
		[WebMethod()]
		public DateTime GetLastUpdateOfTable(string TableName)
		{				
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GetLastUpdateOfTable(TableName);
		}

		[WebMethod()]
		public DateTime			GetLastUpdateOfDiskSize()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GetLastUpdateOfDiskSize();
		}
		
		[WebMethod()]
		void UpdateLastUpdateOfTable(string TableName)
		{				
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			cmd.UpdateLastUpdateOfTable(TableName);
		}

		#endregion not using now

		#region DDA_TesterTypes

		[WebMethod()]
		public bool TesterTypesExist(short testertypeid)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.TesterTypesExist(testertypeid);
		}

		[WebMethod()]
		public short TesterTypesInsert(string testertype)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.TesterTypesInsert(testertype);
		}

		[WebMethod()]
		public DataSetResult TesterTypesList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.TesterTypesList();
		}

		#endregion DDA_TesterTypes
	
		#region DDA_Grades

		[WebMethod()]
		public DataSetResult GradesListToDataset()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradesListToDataset();
		}

		[WebMethod()]
		public ArrayList GradesList()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradesList();
		}

		[WebMethod()]
		public ArrayList GradeMappingGetSignatureKey(int gradekey)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradeMappingGetSignatureKey(gradekey);
		}

		[WebMethod()]
		public SignatureListResult GradeMappingGetSignature(int gradekey)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradeMappingGetSignature(gradekey);
		}

		[WebMethod()]
		public int GradesInsert(SiGlaz.Common.DDA.Grade objinsert)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradesInsert(objinsert);
		}

		[WebMethod()]
		public ResultBase GradesDelete(int key)
		{				
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradesDelete(key);
		}

		[WebMethod()]
		public SignatureListResult GradeMappingGetUnknownSignature()
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.GradeMappingGetUnknownSignature();
		}

		#endregion DDA_Grades

		#region DDA_ApplicationData

		[WebMethod()]
		public void ApplicationDataInsert(string key,string val)
		{
			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			cmd.ApplicationDataInsert(key,val);
		}

		[WebMethod()]
		public object ApplicationDataGetValue(string key)
		{

			SiGlaz.DDA.Business.Category cmd = new SiGlaz.DDA.Business.Category();
			return cmd.ApplicationDataGetValue(key);
		}

		#endregion DDA_ApplicationData
	}
}
