using System;
using SiGlaz.Common;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;
using System.Collections;

namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for CategoryProxy.
	/// </summary>
	public class CategoryCmd
	{	
		WebServiceProxy.CategoryProxy.Category proxy;
		SiGlaz.DDA.Business.Category bussobject;

		public CategoryCmd()
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				proxy = WebProxyFactory.CreateCategory();
			else
				bussobject = new SiGlaz.DDA.Business.Category();
		}

		public bool TestConnection()
		{
			if(bussobject!=null)
				return bussobject.TestConnection();

			return proxy.TestConnection();
		}


		#region DDA_Signatures

		public DataSetResult SignatureListToDataset()
		{
			if(bussobject!=null)
				return bussobject.SignatureListToDataset();
		
			return ConvertProxy.Convert(proxy.SignatureListToDataset(),typeof(DataSetResult)) as DataSetResult;
		}

		public SignatureListResult SignatureList()
		{
			if(bussobject!=null)
				return bussobject.SignatureList();

			return ConvertProxy.Convert(proxy.SignatureList(),typeof(SignatureListResult)) as SignatureListResult;
		}
			
		public int SignatureInsert(SiGlaz.Common.DDA.Signature objinsert,bool updateByName,bool skipUpdate)
		{
			if(bussobject!=null)
				return bussobject.SignatureInsert(objinsert,updateByName,skipUpdate);
			
			WebServiceProxy.CategoryProxy.Signature obj = ConvertProxy.Convert(objinsert,typeof(WebServiceProxy.CategoryProxy.Signature)) as WebServiceProxy.CategoryProxy.Signature;
			return proxy.SignatureInsert(obj,updateByName,skipUpdate);
		}

		public ResultBase SignatureDelete(int key)
		{				
			if(bussobject!=null)
				return bussobject.SignatureDelete(key);
		
			return ConvertProxy.Convert(proxy.SignatureDelete(key),typeof(ResultBase)) as ResultBase;
		}


		public bool SignatureCanDelete(int key)
		{
			if(bussobject!=null)
				return bussobject.SignatureCanDelete(key);
		
			return proxy.SignatureCanDelete(key);
		}

		public Signature SignatureGetByKey(int key)
		{
			if(bussobject!=null)
				return bussobject.SignatureGetByKey(key);
		
			return ConvertProxy.Convert(proxy.SignatureGetByKey(key),typeof(Signature)) as Signature;
		}

		public Signature SignatureGetByName(string signatureName)
		{
			if(bussobject!=null)
				return bussobject.SignatureGetByName(signatureName);
		
			return ConvertProxy.Convert(proxy.SignatureGetByName(signatureName),typeof(Signature)) as Signature;
		}

		#endregion DDA_Signatures

		#region DDA_TesterTypes

		public bool TesterTypesExist(short testertypeid)
		{
			if(bussobject!=null)
				return bussobject.TesterTypesExist(testertypeid);
		
			return proxy.TesterTypesExist(testertypeid);
		}
	
		public short TesterTypesInsert(string testertype)
		{
			if(bussobject!=null)
				return bussobject.TesterTypesInsert(testertype);
		
			return proxy.TesterTypesInsert(testertype);	
		}
		
		public DataSetResult TesterTypesList()
		{
			if(bussobject!=null)
				return bussobject.TesterTypesList();
		
			return ConvertProxy.Convert(proxy.TesterTypesList(),typeof(DataSetResult)) as DataSetResult;
		}

		#endregion DDA_TesterTypes
		
		#region DDA_Products

		public int ProductInsert(string productName)
		{
			if(bussobject!=null)
				return bussobject.ProductInsert(productName);
		
			return proxy.ProductInsert(productName);
		}

		public int ProductInsert(Product objinsert)
		{
			if(bussobject!=null)
				return bussobject.ProductInsert(objinsert);
		
			WebServiceProxy.CategoryProxy.Product obj = ConvertProxy.Convert(objinsert,typeof(WebServiceProxy.CategoryProxy.Product)) as WebServiceProxy.CategoryProxy.Product;
			return proxy.ProductInsert(obj);
		}

		public ResultBase ProductDelete(int DiskSizeKey)
		{
			if(bussobject!=null)
				return bussobject.ProductDelete(DiskSizeKey);

			return ConvertProxy.Convert(proxy.ProductDelete(DiskSizeKey),typeof(ResultBase)) as ResultBase;
		}

		public DataSetResult	ProductListDataset()
		{
			if(bussobject!=null)
				return bussobject.ProductListDataset();

			return ConvertProxy.Convert(proxy.ProductListDataset(),typeof(DataSetResult)) as DataSetResult;
		}

		public ArrayList	ProductList()
		{
			if(bussobject!=null)
				return bussobject.ProductList();

			ArrayList alResult = new ArrayList();
			object[] objs = proxy.ProductList();
			if(objs!=null)
			{
				foreach(object obj in objs)
				{
					alResult.Add(ConvertProxy.Convert(obj,typeof(SiGlaz.Common.DDA.Product)));
				}
			}

			return alResult;
		}

		public bool ProductCanDelete(int key)
		{
			if(bussobject!=null)
				return bussobject.ProductCanDelete(key);
		
			return proxy.ProductCanDelete(key);
		}

		public string ProductGetProductClass(string productcode)
		{
			if(bussobject!=null)
				return bussobject.ProductGetProductClass(productcode);
		
			return proxy.ProductGetProductClass(productcode);
		}

		#endregion DDA_Products

		#region DDA_Grades

		public DataSetResult GradesListToDataset()
		{
			if(bussobject!=null)
				return bussobject.GradesListToDataset();
		
			return ConvertProxy.Convert(proxy.GradesListToDataset(),typeof(DataSetResult)) as DataSetResult;
		}


		public ArrayList GradesList()
		{
			if(bussobject!=null)
				return bussobject.GradesList();

			ArrayList alResult = new ArrayList();
			object[] objs = proxy.GradesList();
			if(objs!=null)
			{
				foreach(object obj in objs)
				{
					alResult.Add(ConvertProxy.Convert(obj,typeof(SiGlaz.Common.DDA.Grade)));
				}
			}

			return alResult;
		}

		public ArrayList GradeMappingGetSignatureKey(int gradekey)
		{
			if(bussobject!=null)
				return bussobject.GradeMappingGetSignatureKey(gradekey);

			ArrayList alResult = new ArrayList();
			object[] objs = proxy.GradesList();
			if(objs!=null)
				alResult.AddRange(objs);

			return alResult;
		}

		public SignatureListResult GradeMappingGetSignature(int gradekey)
		{
			if(bussobject!=null)
				return bussobject.GradeMappingGetSignature(gradekey);

			return ConvertProxy.Convert(proxy.GradeMappingGetSignature(gradekey),typeof(SignatureListResult)) as SignatureListResult;
		}

		public int GradesInsert(SiGlaz.Common.DDA.Grade objinsert)
		{
			if(bussobject!=null)
				return bussobject.GradesInsert(objinsert);
			
			WebServiceProxy.CategoryProxy.Grade obj = ConvertProxy.Convert(objinsert,typeof(WebServiceProxy.CategoryProxy.Grade)) as WebServiceProxy.CategoryProxy.Grade;
			objinsert.Gradekey = proxy.GradesInsert(obj);
			return objinsert.Gradekey;
		}

		public ResultBase GradesDelete(int key)
		{				
			if(bussobject!=null)
				return bussobject.GradesDelete(key);
		
			return ConvertProxy.Convert(proxy.GradesDelete(key),typeof(ResultBase)) as ResultBase;
		}

		public SignatureListResult GradeMappingGetUnknownSignature()
		{
			if(bussobject!=null)
				return bussobject.GradeMappingGetUnknownSignature();

			return ConvertProxy.Convert(proxy.GradeMappingGetUnknownSignature(),typeof(SignatureListResult)) as SignatureListResult;
		}

		#endregion DDA_Grades

		public DataSetResult	DiskSizesListDataset()
		{
			if(bussobject!=null)
				return bussobject.DiskSizesListDataset();

			return ConvertProxy.Convert(proxy.DiskSizesListDataset(),typeof(DataSetResult)) as DataSetResult;
		}



		#region DDA_ApplicationData

		public void ApplicationDataInsert(string key,string val)
		{
			if(bussobject!=null)
				bussobject.ApplicationDataInsert(key,val);
			else
				proxy.ApplicationDataInsert(key,val);
		}

		public object ApplicationDataGetValue(string key)
		{
			if(bussobject!=null)
				return bussobject.ApplicationDataGetValue(key);

			return proxy.ApplicationDataGetValue(key);
		}


		#endregion DDA_ApplicationData

	}
}
