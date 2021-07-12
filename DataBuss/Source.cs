using System;
using System.Data;
using System.Data.SqlClient;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;

namespace SiGlaz.DDA.Business
{
	public class Source : Category
	{
		static object synDiskInsertObject = new object();

		#region Constructor
		public Source() : base()
		{
		}
		public Source(SiGlaz.Common.DDA.DDADBType type) : base(type)
		{
		}

		public Source(ConnectionParam param) : base(param)
		{

		}
		#endregion
		
		#region Insert

		public long DiskInsert(SiGlaz.Common.DDA.Disk disk)
		{
			object[] objs = new object[4];

			objs[0] = 0;//return value
			objs[1] = disk.FabKey;
			objs[2] = disk.DiskID;
			objs[3] = 0;//output

			this.ExecuteNonQueryEx("DDA_Disk_GetKey",objs);

			disk.DiskKey = (long)objs[3];

			objs = null;

			if(disk.DiskKey>0) 
				return -1;
			try
			{
				//this.BeginCommand();
				objs = new object[21];

				objs[0] = 0;
				objs[1] = disk.DiskID;
				objs[2] = disk.TestGrade;
				objs[3] = disk.SlotNum;
				objs[4] = disk.LotID;
				objs[5] = disk.CassetteID;
				objs[6] = disk.StationKey;
				objs[7] = disk.WordCellKey;
				objs[8] = disk.FabKey;
				objs[9] = disk.InnerDiameter;
				objs[10] = disk.OuterDiameter;
				objs[11] = disk.L2_Top_Corr_cts;
				objs[12] = disk.L2_Bot_Corr_cts;
				objs[13] = disk.L2_Top_NCorr_cts;
				objs[14] = disk.L2_Bot_NCorr_cts;
				objs[15] = disk.ProductKey;
				objs[16] = disk.TestDiskDate;

				objs[17] = disk.TesterTypeId;

				objs[18] = disk.LotIDCode;
				objs[19] = disk.BinNum;

				objs[20] = 0;

				this.ExecuteNonQueryEx("DDA_Disks_Insert",objs);

				disk.DiskKey = (long)objs[20];
				objs = null;

				return disk.DiskKey ;
				//this.CommitCommand();
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

		public long SurfaceInsert(SiGlaz.Common.DDA.Disk disk,SiGlaz.Common.DDA.Surface surface)
		{
			object[] objs = new object[4];

			objs[0] = 0;//return value
			objs[1] = disk.DiskKey;
			objs[2] = (byte)surface.TopBottom;
			objs[3] = 0;//output

			this.ExecuteNonQueryEx("DDA_Surfaces_GetKey",objs);

			surface.SurfaceKey = (long)objs[3];

			objs = null;

			if(surface.SurfaceKey>0) 
				return -1;
			try
			{
				this.BeginCommand();

				//Insert Surface
				objs = new object[11];
				objs[0] = 0;
				objs[1] = disk.DiskKey;
				objs[2] = surface.TestDate;
				objs[3] = (byte)surface.TopBottom;
				objs[4] = surface.NumberOfDefect;
				objs[5] = surface.Loaded;
				objs[6] = false;
				objs[7] = surface.IsDefectList;
				objs[8] = DateTime.Now;//InsertedDate
				objs[9] = disk.FileName;
				objs[10] = 0;
				this.ExecuteNonQueryEx("DDA_Surfaces_Insert",objs);
				surface.SurfaceKey = (long)objs[10];
				objs = null;

				//Insert DDA_SurfaceData
				objs = new object[5];
				objs[0] = surface.SurfaceKey;
				objs[1] = surface.RawData;
				objs[2] = surface.SourceThumbnail;
				objs[3] = surface.SourceThumbnailFlat;
				objs[4] = surface.NoCompress;
				this.TableName = "DDA_SurfaceData";
				this.Insert(objs);
				objs = null;

				this.CommitCommand();

				return surface.SurfaceKey;
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

		public long SurfaceInsertAll(SiGlaz.Common.DDA.Fab fab,SiGlaz.Common.DDA.Disk disk,SiGlaz.Common.DDA.Surface surface)
		{
			//When many process on other computer insert the same the value the same times, the first one will successful
			//and the other will throw exception and rollback process
			//Please note that there fields must unique in database : FabID,Tester,TestCell,ProductCode
			//lock(synDiskInsertObject)
			{
				try
				{
					//this.BeginTransaction();

					//DDA_Fabs
					disk.FabKey  = this.FabInsert(fab);//FabID

					disk.TesterTypeId = this.TesterTypesInsert(disk.TesterType);

					//DDA_Stations
					disk.StationKey = this.StationInsert(disk.Station);//Tester

					//DDA_WordCells
					disk.WordCellKey = this.WordCellsInsert(disk.WordCell);//TestCell

					//DDA_Cassettes
					disk.ProductKey = this.ProductInsert(disk.ProductCode);//ProductCode

					//If exception happed before this line, transaction was rollback and assign to null 
					//so that safe code to call multi times Commit,RollBack or Finally.

					this.BeginTransaction();

					this.DiskInsert(disk);

					long surfacekey = this.SurfaceInsert(disk,surface);
					if(surfacekey<=0)
					{
						this.RollbackTransaction();
						return -1;
					}

					this.CommitTransaction();

					return surfacekey;
				}
				catch
				{
					this.RollbackTransaction();

					throw;
				}
				finally
				{
					this.FinallyTransaction();
				}
			}
		}

		#endregion

		#region Query

		public byte[] GetSourceThumbnail(long surfaceKey)
		{
			SqlDataReader reader =  null;
			try
			{
				object[] paramList = new object[1];
				paramList[0] = surfaceKey;
				reader = SqlHelper.ExecuteReader(this.ConnectionString, "_GetSourceThumbnail", paramList);
				if (reader.Read()) return (byte[])reader[0];
				else return null;
			}
			catch
			{
				return null;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
			}
		}

		public byte[] GetSourceThumbnailFlat(long surfaceKey)
		{
			SqlDataReader reader =  null;
			try
			{
				object[] paramList = new object[1];
				paramList[0] = surfaceKey;
				reader = SqlHelper.ExecuteReader(this.ConnectionString, "_GetSourceThumbnailFlat", paramList);
				if (reader.Read()) return (byte[])reader[0];
				else return null;
			}
			catch
			{
				return null;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
			}
		}

		/// <summary>
		/// GetSourceRawData
		/// </summary>
		/// <param name="surfaceKey"></param>
		/// <returns><this result using in BDConvert class/returns>
		public DataSet GetSourceRawData(long surfaceKey)
		{
			try
			{
				DataSet ds = this.ExecuteDataset("DDA_GET_SURFACE_DATA", surfaceKey);
				if( ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0 )
					return ds;
				return null;
			}
			catch
			{
				return null;
			}
		}

		public DataSetResult GetDataSourcePaging(DataSourceRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				object[] objs = new object[5];

				objs[0] = 0;//return value
				objs[1] = recipe.GetSqlWhere(); //Where Sql

				//Page Position
				if(recipe.TableLayout.PagePosition < 0)
					objs[2] = (int)0;
				else
					objs[2] =  recipe.TableLayout.PagePosition;

				//Page Size
				if(recipe.TableLayout.PageSize < 1)
					objs[3]  = 10;
				else
					objs[3] = recipe.TableLayout.PageSize;

				objs[4] = 0;//output

				result.Result = ExecuteDatasetEx("_GetDataSource", objs);
				result.TotalRow = (int)objs[4];
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetDataSourceDetail(long surfaceKey, bool hasImage)
		{
			DataSetResult result = new DataSetResult();
			string sql = string.Empty;

			try
			{
				if (hasImage)
					sql = string.Format("SELECT V.*, D.SourceThumbnail, D.SourceThumbnailFlat FROM SourceView V WITH(NOLOCK), DDA_SurfaceData D WITH(NOLOCK) WHERE V.SurfaceKey = D.SurfaceKey AND V.SurfaceKey = {0}", surfaceKey);
				else
					sql = string.Format("SELECT * FROM SourceView WITH(NOLOCK) WHERE SurfaceKey = {0}", surfaceKey);

				result.Result = ExecuteDataset(sql);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetDiskDetail(long diskKey, bool hasImage)
		{
			DataSetResult result = new DataSetResult();
			string sql = string.Empty;

			try
			{
				if (hasImage)
					sql = string.Format("SELECT S.*, SD.SourceThumbnail, SD.SourceThumbnailFlat FROM SourceView S WITH(NOLOCK), DDA_SurfaceData SD WITH(NOLOCK) WHERE S.SurfaceKey = SD.SurfaceKey AND S.DiskKey = {0} ORDER BY S.Surface", diskKey);
				else
					sql = string.Format("SELECT * FROM SourceView WITH(NOLOCK) WHERE DiskKey = {0} ORDER BY Surface", diskKey);

				result.Result = ExecuteDataset(sql);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetDataSourceAll(DataSourceRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
//				string sql = string.Format("SELECT SurfaceKey FROM SourceView WHERE {0}", recipe.GetSqlWhere());
//				result.Result = ExecuteDataset(sql);

				object[] objs = new object[5];
				objs[0] = 0;//return value
				objs[1] = "SourceViewQuery";
				objs[2] = "SurfaceKey";
				objs[3]  = recipe.GetSqlWhere();
				objs[4] = false;

				result.Result = ExecuteDatasetEx("ExportView", objs);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetDataSourceAll2(DataSourceRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				string sql = string.Format("SELECT * FROM SourceView WHERE {0}", recipe.GetSqlWhere());
				result.Result = ExecuteDataset(sql);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public SqlDataReader GetDataSourceAllWithReader(DataSourceRecipe recipe)
		{
			try
			{
//				string sql = string.Format("SELECT {0} FROM SourceView WITH(NOLOCK) WHERE {1}", recipe.GetFieldSelected(),recipe.GetSqlWhere());
//				return ExecuteReader(sql);

				object[] objs = new object[4];
				objs[0] = "SourceViewQuery";
				objs[1] = recipe.GetFieldSelected();
				objs[2]  = recipe.GetSqlWhere();
				objs[3] = false;

				return ExecuteReaderEx("ExportView", objs);
			}
			catch 
			{
				throw;
			}
		}

		public SqlDataReader GetSourceOfDiskAllWithReader(DataSourceRecipe recipe)
		{
			try
			{
//				string sql = string.Format("SELECT {0} FROM DiskView WITH(NOLOCK) WHERE {1}", recipe.GetFieldSelected(),recipe.GetSqlWhere());
//				return ExecuteReader(sql);

				object[] objs = new object[4];
				objs[0] = "DiskViewQuery";
				objs[1] = recipe.GetFieldSelected();
				objs[2]  = recipe.GetSqlWhere();
				objs[3] = false;
				
				return ExecuteReaderEx("ExportView", objs);
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				//Cang sua lai - chua test hehe
				string sConnect = "WHERE";
				query = string.Format("SELECT DISTINCT {0} FROM SourceViewQuery WITH(NOLOCK)",fieldName);

				if(fabID!=null && fabID!=string.Empty)
				{
					query += string.Format(" {0} FabID = '{1}'",sConnect,fabID);
					sConnect = "AND";
				}

				if(from>DateTime.MinValue && to<DateTime.MaxValue)
				{
					query += string.Format(" {0} [TestDate] BETWEEN '{1}' AND '{2}'",sConnect,from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
					sConnect = "AND";
				}

				if(filter !=null && filter !=string.Empty)
				{
					query += string.Format(" {0} {1}",sConnect,filter);
				}

//				if (filter ==null)
//					query = string.Format("SELECT DISTINCT {0} FROM SourceView WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID);
//				else
//					query = string.Format("SELECT DISTINCT {0} FROM SourceView WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4}", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter);

				result.Result = ExecuteDataset(query);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetHintDataOfDisk(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				if (filter == string.Empty)
					query = string.Format("SELECT DISTINCT {0} FROM DiskViewQuery WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID);
				else
					query = string.Format("SELECT DISTINCT {0} FROM DiskViewQuery WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4}", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter);

				result.Result = ExecuteDataset(query);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetSurfaceByDisk(long diskKey)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				object[] paramList = new object[1];
				paramList[0] = diskKey;

				result.Result = ExecuteDataset("_GetSurfaceByDisk", paramList);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetSourceOfDiskPaging(DataSourceRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				object[] objs = new object[5];

				objs[0] = 0;//return value
				objs[1] = recipe.GetSqlWhere(); //Where Sql

				//Page Position
				if(recipe.TableLayout.PagePosition < 0)
					objs[2] = (int)0;
				else
					objs[2] =  recipe.TableLayout.PagePosition;

				//Page Size
				if(recipe.TableLayout.PageSize < 1)
					objs[3]  = 10;
				else
					objs[3] = recipe.TableLayout.PageSize;

				objs[4] = 0;//output

				result.Result = ExecuteDatasetEx("_GetSourceOfDisk", objs);
				result.TotalRow = (int)objs[4];
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public DataSetResult GetSourceOfDiskAll(DataSourceRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
//				string sql = string.Format("SELECT DiskKey FROM DiskView WITH(NOLOCK) WHERE {0}", recipe.GetSqlWhere());
//				result.Result = ExecuteDataset(sql);

				object[] objs = new object[5];
				objs[0] = 0;//return value
				objs[1] = "DiskViewQuery";
				objs[2] = "DiskKey";
				objs[3]  = recipe.GetSqlWhere();
				objs[4] = false;

				result.Result = ExecuteDatasetEx("ExportView", objs);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public ResultBase GetTotalRow_SurfaceOfDisk(string sqlWhere)
		{
			ResultBase result = new ResultBase();

			try
			{
				object[] objs = new object[4];

				objs[0] = "SourceView";
				objs[1] = "SurfaceKey";
				objs[2] = "SurfaceKey";
				objs[3] = sqlWhere;
				
				result.id64 = base.ExecuteScalarProc("_GetTotalRow", objs);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}

		public ResultBase GetTotalRow_SourceOfDisk(string sqlWhere)
		{
			ResultBase result = new ResultBase();

			try
			{
				object[] objs = new object[4];

				objs[0] = "DiskView";
				objs[1] = "DiskKey";
				objs[2] = "DiskKey";
				objs[3] = sqlWhere;
				
				result.id64 = base.ExecuteScalarProc("_GetTotalRow", objs);
			}
			catch (System.Data.SqlClient.SqlException se)
			{
				result.Code = ErrorCode.INVALID_SQL_STATEMENT;
				result.Description = se.ToString();
			}
			catch (System.Exception e)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = e.ToString();
			}

			return result;
		}
		#endregion
	}
}
