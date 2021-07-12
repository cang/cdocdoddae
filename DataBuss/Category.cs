using System;
using System.Collections;
using System.Data;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace SiGlaz.DDA.Business
{


	/// <summary>
	/// Summary description for Category.
	/// </summary>
	public class Category : SingleTableCmd 
	{
		public Category() : base()
		{
		}

		public Category(SiGlaz.Common.DDA.DDADBType type) : base(type)
		{
		}

		public Category(ConnectionParam param) : base(param)
		{

		}

		#region common
		public DataSetResult	TableList(string tableName)
		{
			DataSetResult result = new DataSetResult();
			try
			{
				result.Result =  this.GetTable(tableName);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}

		public DataSetResult	GetTableOfSQL(string SQL)
		{
			DataSetResult result = new DataSetResult();
			try
			{
				result.Result =  this.ExecuteDataset(SQL);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}
		#endregion common

		#region DDA_Fabs

		public bool FabExist(short fabid)
		{
			try
			{
				string SQL = string.Format("SELECT TOP 1 FabKey FROM DDA_Fabs Where FabKey = {0}",fabid);
				return this.CheckExistSQL(SQL);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

		public short FabInsert(string fab)
		{
			return FabInsert(new Fab(fab,string.Empty));
		}

		public short FabInsert(Fab objinsert)
		{
			if(objinsert==null) return -1;

			short resultid = (short)this.ExecuteScalarProc("DDA_FabKey_GetByID", objinsert.FabID.Trim() );
			if(resultid>0) 
				return resultid;

			try
			{
				//this.BeginCommand();

				object []objs = new object[3];
				objs[0] = objinsert.FabID.Trim();
				objs[1] = null;
				objs[2] = objinsert.Description;

				this.TableName = "DDA_Fabs";
				resultid = (short)this.Insert(objs);
				objs = null;
				//this.CommitCommand();

				return resultid;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public DataSetResult	FabList()
		{
			return TableList("DDA_Fabs");
		}

		public Fab				GetFabByFabID(string fabid)
		{
			try
			{
				DataSet ds =  this.ExecuteDataset("DDA_Fab_GetByID", fabid);
				if( ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					Fab fab = new Fab();
					fab.FabID = fabid;
					if(!ds.Tables[0].Rows[0].IsNull("Description"))
						fab.Description = ds.Tables[0].Rows[0]["Description"].ToString();
					else
						fab.Description = string.Empty;
					return fab;
				}
				else
					return null;
			}
			catch//(Exception ex)
			{
				return null;
			}
		}

		#endregion DDA_Fabs

		#region DDA_TesterTypes

		public bool TesterTypesExist(short testertypeid)
		{
			try
			{
				string SQL = string.Format("SELECT TOP 1 TesterTypeID FROM DDA_TesterTypes WHERE TesterTypeID = {0}",testertypeid);
				return this.CheckExistSQL(SQL);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

	
		public short TesterTypesInsert(string testertype)
		{
			if(testertype==null) return -1;

			short resultid = (short)this.ExecuteScalarProc("DDA_TesterType_GetByID", testertype.Trim() );
			if(resultid>0) 
				return resultid;

			try
			{
				//this.BeginCommand();

				object []objs = new object[1];
				objs[0] = testertype.Trim();

				this.TableName = "DDA_TesterTypes";
				resultid = (short)this.Insert(objs);
				objs = null;
				//this.CommitCommand();

				return resultid;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}


		public DataSetResult	TesterTypesList()
		{
			return TableList("DDA_TesterTypes");
		}

		#endregion DDA_TesterTypes

		#region DDA_Stations

		public int StationInsert(string station)
		{
			return StationInsert(new Station(station));
		}

		public int StationInsert(Station objinsert)
		{
			if(objinsert==null) return -1;

			int resultid = (int)this.ExecuteScalarProc("DDA_Station_GetByName", objinsert.StationName);
			if(resultid>0) 
				return resultid;

			try
			{
				//this.BeginCommand();

				object []objs = new object[1];
				objs[0] = objinsert.StationName;

				this.TableName = "DDA_Stations";
				resultid = (int)this.Insert(objs);
				objs = null;
				//this.CommitCommand();

				return resultid;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public DataSetResult	StationList()
		{
			return TableList("DDA_Stations");
		}

		#endregion DDA_Stations

		#region DDA_WordCells

		public int WordCellsInsert(string wordCell)
		{
			return WordCellsInsert(new WordCell(wordCell));
		}

		public int WordCellsInsert(WordCell objinsert)
		{
			if(objinsert==null) return -1;

			int resultid = (int)this.ExecuteScalarProc("DDA_WordCells_GetByName", objinsert.WordCellID);
			if(resultid>0) 
				return resultid;

			try
			{
				//this.BeginCommand();

				object []objs = new object[1];
				objs[0] = objinsert.WordCellID;

				this.TableName = "DDA_WordCells";
				resultid = (int)this.Insert(objs);
				objs = null;
				//this.CommitCommand();

				return resultid;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public DataSetResult	WordCellsList()
		{
			return TableList("DDA_WordCells");
		}

		#endregion DDA_WordCells

		#region DDA_DiskSize
	
		public int DiskSizesInsert(DiskSize objinsert)
		{
			if(objinsert==null) return -1;

			string SQL = string.Format("SELECT TOP 1 DiskSizeKey FROM DDA_DiskSizes WHERE DiskSizeKey={0} AND Prod_Class='{1}' AND InnerDiameter={2} AND OuterDiameter={3}",objinsert.DiskSizeKey,objinsert.Prod_Class,objinsert.InnerDiameter,objinsert.OuterDiameter);
			if(this.CheckExistSQL(SQL))
				return objinsert.DiskSizeKey;

			try
			{
//				if(objinsert.DiskSizeKey>=0)
//				{
//					SQL = string.Format("SELECT TOP 1 DiskSizeKey FROM DDA_DiskSizes WHERE DiskSizeKey={0}",objinsert.DiskSizeKey);
//					objinsert.DiskSizeKey = this.ExecuteScalarSQL(SQL);
//				}

				//this.BeginCommand();

				if(objinsert.DiskSizeKey>0)//update
				{
					object []objs = new object[4];
					objs[0] = objinsert.Prod_Class;
					objs[1] = objinsert.InnerDiameter;
					objs[3] = objinsert.DiskSizeKey;
					objs[2] = objinsert.OuterDiameter;

					this.TableName = "DDA_DiskSizes";
					this.Update(objs);

					objs = null;
				}
				else
				{
					object []objs = new object[3];
					objs[0] = objinsert.Prod_Class;
					objs[1] = objinsert.InnerDiameter;
					objs[2] = objinsert.OuterDiameter;

					this.TableName = "DDA_DiskSizes";
					objinsert.DiskSizeKey = (int)this.Insert(objs);

					objs = null;
				}

				//this.CommitCommand();

				return objinsert.DiskSizeKey;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public ResultBase DiskSizesDelete(int DiskSizeKey)
		{
			ResultBase result = new ResultBase();
			try
			{
				this.TableName = "DDA_DiskSizes";
				this.DeleteByPrimaryKey(DiskSizeKey);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}

		public DataSetResult	DiskSizesListDataset()
		{
			return TableList("DDA_DiskSizes");
		}

		public ArrayList	DiskSizesList()
		{
			DataSetResult result = DiskSizesListDataset();
			ArrayList alResult = new ArrayList();
			if(result.Code == ErrorCode.OK)
			{
				foreach(DataRow dr in result.Result.Tables[0].Rows)
				{
					DiskSize obj = new DiskSize();

					if( !dr.IsNull("DiskSizeKey") )
						obj.DiskSizeKey= (int)dr["DiskSizeKey"];

					if( !dr.IsNull("Prod_Class") )
						obj.Prod_Class = (string)dr["Prod_Class"];

					if( !dr.IsNull("InnerDiameter") )
						obj.InnerDiameter = (double)dr["InnerDiameter"];

					if( !dr.IsNull("OuterDiameter") )
						obj.OuterDiameter = (double)dr["OuterDiameter"];

					alResult.Add(obj);
				}
			}
			return alResult;
		}

		public DataSetResult	ProductDiskSizesListDataset()
		{
			return GetTableOfSQL("SELECT * FROM DDA_PRODUCT_DISKSIZE");
		}

		public ArrayList	ProductDiskSizesList()
		{
			DataSetResult result = ProductDiskSizesListDataset();
			ArrayList alResult = new ArrayList();

			if(result.Code == ErrorCode.OK)
			{
				foreach(DataRow dr in result.Result.Tables[0].Rows)
				{
					ProductDiskSize obj = new ProductDiskSize();

					if( !dr.IsNull("DiskSizeKey") )
						obj.DiskSizeKey= (int)dr["DiskSizeKey"];

					if( !dr.IsNull("Prod_Class") )
						obj.Prod_Class = (string)dr["Prod_Class"];

					if( !dr.IsNull("ProductCode") )
						obj.ProductCode = (string)dr["ProductCode"];

					if( !dr.IsNull("InnerDiameter") )
						obj.InnerDiameter = (double)dr["InnerDiameter"];

					if( !dr.IsNull("OuterDiameter") )
						obj.OuterDiameter = (double)dr["OuterDiameter"];

					alResult.Add(obj);
				}
			}

			return alResult;
		}


		public bool ProductDiskSizeExist(string productcode)
		{
			int resultid = (int)this.ExecuteScalarProc("DDA_Products_GetByName", productcode);
			return resultid>0;
		}

		public string ProductGetProductClass(string productcode)
		{
			string SQL = string.Format("SELECT TOP 1 Prod_Class FROM DDA_Products WHERE ProductCode='{0}'", productcode);

			try
			{
				DataSet ds = this.ExecuteDataset(SQL);
				if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					return ds.Tables[0].Rows[0][0].ToString();
				}
				else
					return string.Empty;
			}
			catch
			{
				return string.Empty;
			}
		}

		public ProductDiskSize GetProductDiskSize(string productcode)
		{
			try
			{
				string SQL = string.Format( "SELECT * FROM DDA_PRODUCT_DISKSIZE WHERE ProductCode = '{0}'",productcode );
				DataSet ds = this.ExecuteDataset(SQL);
				if( ds==null || ds.Tables.Count<1 || ds.Tables[0].Rows.Count<1)
					return null;

				DataRow dr = ds.Tables[0].Rows[0];

				ProductDiskSize obj = new ProductDiskSize();

				if( !dr.IsNull("DiskSizeKey") )
					obj.DiskSizeKey= (int)dr["DiskSizeKey"];

				if( !dr.IsNull("Prod_Class") )
					obj.Prod_Class = (string)dr["Prod_Class"];

				if( !dr.IsNull("ProductCode") )
					obj.ProductCode = (string)dr["ProductCode"];

				if( !dr.IsNull("InnerDiameter") )
					obj.InnerDiameter = (double)dr["InnerDiameter"];

				if( !dr.IsNull("OuterDiameter") )
					obj.OuterDiameter = (double)dr["OuterDiameter"];
				
				return obj;
			}
			catch
			{
				return null;
			}
		}

		#endregion DDA_DiskSize

		#region DDA_Products

		public int ProductInsert(string productName)
		{
			string SQL = string.Format("SELECT TOP 1 ProductKey FROM DDA_Products WITH(NOLOCK) WHERE ProductCode='{0}'",productName);
			int result = (int)this.ExecuteScalarSQL(SQL);

			if(result>0)
				return result;

			Product item = new Product(-1,productName,string.Empty);

			return ProductInsert(item);
		}

		public int ProductInsert(Product objinsert)
		{
			if(objinsert==null) return -1;

			if(objinsert.ProductKey>0)
			{
				string SQL = string.Format("SELECT TOP 1 ProductKey FROM DDA_Products WHERE ProductKey={0} AND ProductCode='{1}' AND Prod_Class='{2}'",objinsert.ProductKey,objinsert.ProductCode,objinsert.Prod_Class);
				if(this.CheckExistSQL(SQL))
					return objinsert.ProductKey;
			}

			try
			{
				if(objinsert.ProductKey>0)//update
				{
					object []objs = new object[3];
					objs[0] = objinsert.ProductCode;
					objs[1] = objinsert.Prod_Class;
					objs[2] = objinsert.ProductKey;

					this.TableName = "DDA_Products";
					this.Update(objs);

					objs = null;
				}
				else
				{
					object []objs = new object[2];
					objs[0] = objinsert.ProductCode;
					objs[1] = objinsert.Prod_Class;

					this.TableName = "DDA_Products";
					objinsert.ProductKey = (int)this.Insert(objs);

					objs = null;
				}

				//this.CommitCommand();

				return objinsert.ProductKey;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public ResultBase ProductDelete(int DiskSizeKey)
		{
			ResultBase result = new ResultBase();
			try
			{
				this.TableName = "DDA_Products";
				this.DeleteByPrimaryKey(DiskSizeKey);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}

		public DataSetResult	ProductListDataset()
		{
			return TableList("DDA_Products");
		}

		public ArrayList	ProductList()
		{
			DataSetResult result = ProductListDataset();
			ArrayList alResult = new ArrayList();
			if(result.Code == ErrorCode.OK)
			{
				foreach(DataRow dr in result.Result.Tables[0].Rows)
				{
					Product obj = new Product();

					if( !dr.IsNull("ProductKey") )
						obj.ProductKey= (int)dr["ProductKey"];

					if( !dr.IsNull("ProductCode") )
						obj.ProductCode = (string)dr["ProductCode"];

					if( !dr.IsNull("Prod_Class") )
						obj.Prod_Class = (string)dr["Prod_Class"];

					alResult.Add(obj);
				}
			}
			return alResult;
		}

		public bool ProductCanDelete(int key)
		{
			string SQL = string.Format("SELECT TOP 1 ProductKey FROM DDA_Disks WHERE ProductKey = {0}",key);
			try
			{
				return !this.CheckExistSQL(SQL);
			}
			catch
			{
				return false;
			}
		}
	
		#endregion DDA_DiskSize

		#region DDA_Channels

		public int ChannelsInsert(Channel objinsert)
		{
			if(objinsert==null) return -1;

			int resultid = (int)this.ExecuteScalarProc("DDA_Channels_GetByName", objinsert.ChannelID);
			if(resultid>0) 
				return resultid;

			try
			{
				//this.BeginCommand();

				object []objs = new object[1];
				objs[0] = objinsert.ChannelName;

				this.TableName = "DDA_Channels";
				resultid = (short)this.Insert(objs);
				objs = null;
				//this.CommitCommand();

				return resultid;
			}
			catch
			{
				//this.RollbackCommand();
				throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}

		public DataSetResult	ChannelsList()
		{
			return TableList("DDA_Channels");
		}

		#endregion DDA_WordCells
		
		#region DDA_Signatures

		public DataSetResult SignatureListToDataset()
		{
			return TableList("DDA_Signatures");
		}

		
		public SignatureListResult SignatureList()
		{
			DataSetResult resultprocess = this.SignatureListToDataset();

			SignatureListResult result = new SignatureListResult();

			result.Code = resultprocess.Code;
			result.Description = resultprocess.Description;		

			if(resultprocess.IsSuccess)
			{
				foreach (DataRow dr in resultprocess.Result.Tables[0].Rows)
				{
					SiGlaz.Common.DDA.Signature item = new SiGlaz.Common.DDA.Signature();

					if(!dr.IsNull("SignatureKey"))
						item.SCKey = (int)dr["SignatureKey"] ;

					if(!dr.IsNull("SignatureName"))
						item.SignatureName = (string)dr["SignatureName"] ;

					if(!dr.IsNull("SignatureID"))
						item.SignatureID = (int)dr["SignatureID"] ;					
					
					result.signature.Add(item);
				}
			}

			return result;
		}

		public int SignatureInsert(SiGlaz.Common.DDA.Signature objinsert,bool updatebyName,bool skipUpdate)
		{
			if(objinsert==null) return -1;

			string SQL = string.Format("SELECT TOP 1 SignatureKey FROM DDA_Signatures WITH(NOLOCK) WHERE SignatureKey={0} AND SignatureID={1} AND SignatureName='{2}'",objinsert.SCKey,objinsert.SignatureID,objinsert.SignatureName);
			if(this.CheckExistSQL(SQL))
				return objinsert.SCKey;

			try
			{
				if(updatebyName)// && objinsert.SCKey>=0)
				{
					SQL = string.Format("SELECT TOP 1 SignatureKey FROM DDA_Signatures WITH(NOLOCK) WHERE SignatureName='{0}'",objinsert.SignatureName);
					objinsert.SCKey = (int)this.ExecuteScalarSQL(SQL);
				}

				if(objinsert.SCKey > 0 && skipUpdate)
					return objinsert.SCKey;

				this.TableName = "DDA_Signatures";

				if( objinsert.SCKey > 0 )
					this.Update(objinsert.SignatureID,objinsert.SignatureName,objinsert.SCKey);
				else
					objinsert.SCKey = (int)this.Insert(objinsert.SignatureID,objinsert.SignatureName);

				return  objinsert.SCKey;
			}
			catch
			{
				throw;
			}
			finally
			{
			}
		}

		public ResultBase SignatureDelete(int key)
		{				
			ResultBase result = new ResultBase();
			try
			{			
				//this.BeginCommand();

				this.TableName = "DDA_Signatures";
				
				this.DeleteByPrimaryKey(key);

				//this.CommitCommand();			
			}
			catch(Exception ex)
			{
				//this.RollbackCommand();

				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description= ex.Message;
			}	
			finally
			{
				//this.FinallyCommand();
			}

			return result;
		}


		public bool SignatureCanDelete(int key)
		{
			string SQL = string.Format("SELECT TOP 1 SignatureKey FROM DDA_Results WHERE SignatureKey = {0}",key);
			try
			{
				bool result  = !this.CheckExistSQL(SQL);

				if(result)
				{
					SQL = string.Format("SELECT TOP 1 RecipeKey FROM DDA_Recipes WHERE SignatureKey = {0}",key);
					result  = !this.CheckExistSQL(SQL);
				}

				return result;
			}
			catch
			{
				return false;
			}
		}

		private Signature GetFromDataSet(DataSet ds)
		{
			try
			{
				if( ds==null || ds.Tables.Count<1 || ds.Tables[0].Rows.Count<1)
					return null;

				DataRow dr = ds.Tables[0].Rows[0];

				Signature obj = new Signature();

				if( !dr.IsNull("SignatureKey") )
					obj.SCKey= (int)dr["SignatureKey"];

				if( !dr.IsNull("SignatureID") )
					obj.SignatureID = (int)dr["SignatureID"];

				if( !dr.IsNull("SignatureName") )
					obj.SignatureName = (string)dr["SignatureName"];

				return obj;
			}
			catch
			{
				return null;
			}
		}


		public Signature SignatureGetByKey(int key)
		{
			string SQL = string.Format("SELECT TOP 1 * FROM DDA_Signatures WHERE SignatureKey = {0}",key);

			try
			{
				return GetFromDataSet(this.ExecuteDataset(SQL));
			}
			catch
			{
				return null;
			}
		}

		public Signature SignatureGetByName(string signatureName)
		{
			string SQL = string.Format("SELECT TOP 1 * FROM DDA_Signatures WHERE SignatureName = '{0}'",signatureName);

			try
			{
				return GetFromDataSet(this.ExecuteDataset(SQL));
			}
			catch
			{
				return null;
			}
		}

		#endregion DDA_Signatures

		#region DDA_Grades

		public DataSetResult GradesListToDataset()
		{
			return this.GetTableOfSQL("SELECT * FROM DDA_Grades");
		}

		public ArrayList GradesList()
		{
			DataSetResult resultprocess = this.GradesListToDataset();

			ArrayList result = new ArrayList();

			if(resultprocess.IsSuccess)
			{
				foreach (DataRow dr in resultprocess.Result.Tables[0].Rows)
				{
					SiGlaz.Common.DDA.Grade item = new SiGlaz.Common.DDA.Grade();

					if(!dr.IsNull("GradeKey"))
						item.Gradekey = (int)dr["GradeKey"] ;

					if(!dr.IsNull("Grade"))
						item.GradeID = (int)dr["Grade"] ;
					
					if(!dr.IsNull("GradeDescription"))
						item.GradeDescription = dr["GradeDescription"].ToString();

					item.SignatureKeyList = this.GradeMappingGetSignatureKey(item.Gradekey);
					
					result.Add(item);
				}
			}

			return result;
		}

		public ArrayList GradeMappingGetSignatureKey(int gradekey)
		{
			string SQL = string.Format("SELECT SignatureKey FROM DDA_GradeMapping WHERE GradeKey={0}",gradekey);

			ArrayList result = new ArrayList();

			try
			{
				DataSet ds = this.ExecuteDataset(SQL);
				if(ds!=null && ds.Tables!=null && ds.Tables.Count>0)
				{
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						if(!dr.IsNull(0))
							result.Add((int)dr[0]);
					}
				}
				return result;
			}
			catch
			{
				return result;
			}
			finally
			{
			}
		}

		public SignatureListResult GradeMappingGetSignature(int gradekey)
		{
			string SQL = string.Format("SELECT DDA_Signatures.* FROM DDA_Signatures INNER JOIN DDA_GradeMapping ON DDA_Signatures.SignatureKey = DDA_GradeMapping.SignatureKey WHERE DDA_GradeMapping.GradeKey ={0}",gradekey);

			SignatureListResult result = new SignatureListResult();
			try
			{
				DataSet  ds = this.ExecuteDataset(SQL);

				if(ds!=null && ds.Tables!=null && ds.Tables.Count>0)
				{
					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						SiGlaz.Common.DDA.Signature item = new SiGlaz.Common.DDA.Signature();

						if(!dr.IsNull("SignatureKey"))
							item.SCKey = (int)dr["SignatureKey"] ;

						if(!dr.IsNull("SignatureName"))
							item.SignatureName = (string)dr["SignatureName"] ;

						if(!dr.IsNull("SignatureID"))
							item.SignatureID = (int)dr["SignatureID"] ;					
					
						result.signature.Add(item);
					}
				}
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}

			return result;
		}

		public int GradesInsert(SiGlaz.Common.DDA.Grade objinsert)
		{
			if(objinsert==null) return -1;

			try
			{
				this.BeginCommand();

				//Insert Parent
				this.TableName = "DDA_Grades";
				if( objinsert.Gradekey > 0 )
				{
					this.Update(objinsert.GradeID,objinsert.GradeDescription,objinsert.Gradekey);
				}
				else
				{
					objinsert.Gradekey = (int)this.Insert(objinsert.GradeID,objinsert.GradeDescription);
				}

				//Insert children
				if(objinsert.SignatureKeyList!=null && objinsert.SignatureKeyList.Count>0)
				{
					string SQL= string.Empty;
					this.TableName = "DDA_GradeMapping";
					foreach(int sigkey in objinsert.SignatureKeyList)
					{
						this.Insert(objinsert.Gradekey,sigkey);
						SQL+= "," + sigkey;
					}

					SQL = SQL.Substring(1);
					SQL = string.Format("DELETE FROM DDA_GradeMapping WHERE GradeKey={0} AND SignatureKey NOT IN ({1})",objinsert.Gradekey,SQL);
					this.ExecuteNonQuery(SQL);
				}

				this.CommitCommand();

				return  objinsert.Gradekey;
			}
			catch
			{
				this.RollbackCommand();
				throw;
			}
			finally
			{
				this.FinallyCommand();
			}
		}

		public ResultBase GradesDelete(int key)
		{				
			ResultBase result = new ResultBase();
			try
			{			
				//this.BeginCommand();

				this.TableName = "DDA_Grades";
				this.DeleteByPrimaryKey(key);

				//this.CommitCommand();			
			}
			catch(Exception ex)
			{
				//this.RollbackCommand();

				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description= ex.Message;
			}	
			finally
			{
				//this.FinallyCommand();
			}

			return result;
		}


		public SignatureListResult GradeMappingGetUnknownSignature()
		{
			string SQL = string.Format("SELECT DDA_Signatures.* FROM  DDA_Signatures WHERE NOT EXISTS (SELECT DDA_GradeMapping.SignatureKey FROM DDA_GradeMapping WHERE DDA_Signatures.SignatureKey = DDA_GradeMapping.SignatureKey");

			SignatureListResult result = new SignatureListResult();
			try
			{
				DataSet  ds = this.ExecuteDataset(SQL);

				if(ds!=null && ds.Tables!=null && ds.Tables.Count>0)
				{
					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						SiGlaz.Common.DDA.Signature item = new SiGlaz.Common.DDA.Signature();

						if(!dr.IsNull("SignatureKey"))
							item.SCKey = (int)dr["SignatureKey"] ;

						if(!dr.IsNull("SignatureName"))
							item.SignatureName = (string)dr["SignatureName"] ;

						if(!dr.IsNull("SignatureID"))
							item.SignatureID = (int)dr["SignatureID"] ;					
					
						result.signature.Add(item);
					}
				}
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}

			return result;
		}


		#endregion DDA_Grades


		#region DDA_ApplicationData

		public void ApplicationDataInsert(string key,string val)
		{
			int resultid = (int)this.ExecuteScalarProc("SELECT COUNT(*) FROM DDA_ApplicationData WHERE [Key]='{0}'", key);
			try
			{
				string SQL;
				if ( resultid > 0)
					SQL = string.Format("UPDATE DDA_ApplicationData SET [Value] = '{0}' WHERE [Key] = '{1}'",
						val,key);
				else
					SQL = string.Format("INSERT INTO DDA_ApplicationData([Key],[Value]) VALUES('{1}','{0}')",
						val,key);

				this.ExecuteNonQuery(SQL);
			}
			catch
			{
				throw;
			}
			finally
			{
			}
		}

		public object ApplicationDataGetValue(string key)
		{

			try
			{
				return this.GetValueSQL( string.Format("SELECT [Value] FROM DDA_ApplicationData WHERE [Key]='{0}'",key));
			}
			catch
			{
				return null;
			}
			finally
			{
			}
		}


		#endregion DDA_ApplicationData


		#region not using now
		public DateTime			GetLastUpdateOfTable(string TableName)
		{
			try
			{
				object[] objs = new object[3];
				objs[0] = 0;
				objs[1] = TableName;
				objs[2] = DateTime.MinValue.AddYears(1800);

				ExecuteDatasetEx("LastUpdateTable_GetLastDateTime",objs);

				if(objs[2]==null)
					return DateTime.MinValue.AddYears(1);
				else
					return (DateTime)objs[2];
			}
			catch
			{
				return DateTime.MinValue.AddYears(1800);
			}
		}

		public DateTime			GetLastUpdateOfDiskSize()
		{
			return GetLastUpdateOfTable("DDA_DiskSizes");
		}

		
		//No using now
		public void UpdateLastUpdateOfTable(string TableName)
		{
			try
			{
				//this.BeginCommand();

				object []objs = new object[1];
				objs[0] = TableName;
				this.ExecuteNonQuery("LastUpdateTable_Insert",objs);

				//this.CommitCommand();
			}
			catch
			{
				//this.RollbackCommand();
				//throw;
			}
			finally
			{
				//this.FinallyCommand();
			}
		}


		#endregion not using now

	}


}
