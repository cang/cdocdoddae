using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;

namespace SiGlaz.DDA.Business
{
	public class SingleLayer : SingleTableCmd
	{
		#region Constructor
		public SingleLayer() : base()
		{
		}
		public SingleLayer(SiGlaz.Common.DDA.DDADBType type) : base(type)
		{
		}

		public SingleLayer(ConnectionParam param) : base(param)
		{

		}
		#endregion

		#region SingleLayer Query
		public byte[] GetResultThumbnail(long resultDetailKey)
		{
			SqlDataReader reader =  null;
			try
			{
				object[] paramList = new object[1];
				paramList[0] = resultDetailKey;
				reader = SqlHelper.ExecuteReader(this.ConnectionString, "_GetResultThumbnail", paramList);
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

		public byte[] GetResultThumbnailFlat(long resultDetailKey)
		{
			SqlDataReader reader =  null;
			try
			{
				object[] paramList = new object[1];
				paramList[0] = resultDetailKey;
				reader = SqlHelper.ExecuteReader(this.ConnectionString, "_GetResultThumbnailFlat", paramList);
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

		public byte[] GetResultRawData(long resultDetailKey)
		{
			SqlDataReader reader =  null;
			try
			{
				object[] paramList = new object[1];
				paramList[0] = resultDetailKey;
				reader = SqlHelper.ExecuteReader(this.ConnectionString, "_GetResultRawData", paramList);
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
		public DataSetResult GetSingleLayerPaging(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
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

				result.Result = ExecuteDatasetEx("_GetSingleLayer", objs);
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

		public DataSetResult GetSingleLayerAll(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
//				string sql = string.Format("SELECT ResultKey FROM SingleLayerView WHERE {0}", recipe.GetSqlWhere());
//				result.Result = ExecuteDataset(sql);

				object[] objs = new object[5];
				objs[0] = 0;//return value
				objs[1] = "SingleLayerViewQuery";
				objs[2] = "ResultKey";
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

		public SqlDataReader GetSingleLayerAllWithReader(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			try
			{
//				string sql = string.Format("SELECT {0} FROM SingleLayerView WITH(NOLOCK) WHERE {1}", recipe.GetFieldSelected(),recipe.GetSqlWhere());
//				return ExecuteReader(sql);

				object[] objs = new object[4];
				objs[0] = "SingleLayerViewQuery";
				objs[1] = recipe.GetFieldSelected();
				objs[2]  = recipe.GetSqlWhere();
				objs[3] = false;

				return ExecuteReaderEx("ExportView", objs);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public DataSetResult GetSingleLayerDetail(long resultKey, bool hasImage)
		{
			DataSetResult result = new DataSetResult();
			string sql = string.Empty;

			try
			{
				if (hasImage)
					sql = string.Format("SELECT V.*, SD.SourceThumbnail, SD.SourceThumbnailFlat, RD.SourceThumbnail AS ResultThumbnail, SD.SourceThumbnailFlat AS ResultThumbnailFlat FROM  dbo.SingleLayerView V INNER JOIN dbo.DDA_SurfaceData SD ON V.SurfaceKey = SD.SurfaceKey LEFT OUTER JOIN dbo.DDA_ResultDetailData RD ON V.ResultDetailKey = RD.ResultDetailKey WHERE V.ResultKey = {0}", resultKey);
				else
					sql = string.Format("SELECT * FROM  dbo.SingleLayerView WITH(NOLOCK) WHERE ResultKey = {0}", resultKey);

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

		public DataSetResult GetSurfaceHasSignature(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
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

				result.Result = ExecuteDatasetEx("_GetSurfaceHasSignature", objs);
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

		public SqlDataReader GetSurfaceHasSignatureAllWithReader(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			try
			{
//				string sql = string.Format("SELECT DISTINCT SurfaceKey, {0} FROM SingleLayerView WITH(NOLOCK) WHERE {1}", recipe.GetFieldSelected(),recipe.GetSqlWhere());
//				return ExecuteReader(sql);

				object[] objs = new object[4];
				objs[0] = "SingleLayerViewQuery";
				objs[1] = string.Format("SurfaceKey, SignatureName, Grade, {0}", recipe.GetFieldSelected());
				objs[2]  = recipe.GetSqlWhere();
				objs[3] = true;

				return ExecuteReaderEx("ExportView_SurfaceOfSignature", objs);
			}
			catch 
			{
				throw;
			}
		}

		public DataSetResult GetSurfaceHasSignatureAll(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
//				string sql = string.Format("SELECT DISTINCT SurfaceKey, {0} FROM SingleLayerView WITH(NOLOCK) WHERE {1}", recipe.GetFieldSelected(), recipe.GetSqlWhere());
//				result.Result = ExecuteDataset(sql);

				object[] objs = new object[5];
				objs[0] = 0;//return value
				objs[1] = "SingleLayerViewQuery";
				objs[2] = string.Format("SurfaceKey, {0}", recipe.GetFieldSelected());
				objs[3]  = recipe.GetSqlWhere();
				objs[4] = true;

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

		public DataSetResult GetSurfaceHasSignatureDetail(long surfaceKey, bool hasImage)
		{
			DataSetResult result = new DataSetResult();
			string sql = string.Empty;

			try
			{
				if (hasImage)
					sql = string.Format("SELECT V.*, SD.SourceThumbnail, SD.SourceThumbnailFlat, RD.SourceThumbnail AS ResultThumbnail, SD.SourceThumbnailFlat AS ResultThumbnailFlat FROM  dbo.SingleLayerView V INNER JOIN dbo.DDA_SurfaceData SD ON V.SurfaceKey = SD.SurfaceKey LEFT OUTER JOIN dbo.DDA_ResultDetailData RD ON V.ResultDetailKey = RD.ResultDetailKey WHERE V.SurfaceKey = {0}", surfaceKey);
				else
					sql = string.Format("SELECT * FROM dbo.SingleLayerView WHERE SurfaceKey = {0}", surfaceKey);

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

		public SqlDataReader GetResultBySurfaceKeyWithReader(long surfaceKey)
		{
			try
			{
				string sql = string.Format("SELECT R.ResultKey, RD.ResultDetailKey, Si.SignatureKey, Si.SignatureName, RD.NumberOfDefect AS NumberOfSignatureDefect, RD.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_Grades.Grade FROM dbo.DDA_Grades INNER JOIN DDA_GradeMapping ON DDA_Grades.GradeKey = DDA_GradeMapping.GradeKey RIGHT OUTER JOIN DDA_Surfaces S INNER JOIN DDA_ResultDetail RD ON S.SurfaceKey = RD.SurfaceKey INNER JOIN DDA_Results R ON RD.ResultKey = R.ResultKey INNER JOIN DDA_Signatures Si ON R.SignatureKey = Si.SignatureKey ON DDA_GradeMapping.SignatureKey = R.SignatureKey WHERE  (R.IsMultiLayer = 0) AND S.SurfaceKey = {0}", surfaceKey);
				return ExecuteReader(sql);
			}
			catch 
			{
				throw;
			}
		}

		public DataSetResult GetResultBySurfaceKey(long surfaceKey, SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				string sql = string.Format("SELECT R.ResultKey, RD.ResultDetailKey, Si.SignatureKey, Si.SignatureName, RD.NumberOfDefect AS NumberOfSignatureDefect, RD.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_Grades.Grade FROM dbo.DDA_Grades INNER JOIN DDA_GradeMapping ON DDA_Grades.GradeKey = DDA_GradeMapping.GradeKey RIGHT OUTER JOIN DDA_Surfaces S INNER JOIN DDA_ResultDetail RD ON S.SurfaceKey = RD.SurfaceKey INNER JOIN DDA_Results R ON RD.ResultKey = R.ResultKey INNER JOIN DDA_Signatures Si ON R.SignatureKey = Si.SignatureKey ON DDA_GradeMapping.SignatureKey = R.SignatureKey WHERE  (R.IsMultiLayer = 0) AND S.SurfaceKey = {0} ORDER BY dbo.DDA_Grades.Grade, Si.SignatureName", surfaceKey);
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

		public DataSetResult GetResultBySurfaceKey(long surfaceKey, string sqlWhere)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				string sql = string.Format("SELECT R.ResultKey, RD.ResultDetailKey, Si.SignatureKey, Si.SignatureName, RD.NumberOfDefect AS NumberOfSignatureDefect, RD.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_Grades.Grade FROM dbo.DDA_Grades INNER JOIN DDA_GradeMapping ON DDA_Grades.GradeKey = DDA_GradeMapping.GradeKey RIGHT OUTER JOIN DDA_Surfaces S INNER JOIN DDA_ResultDetail RD ON S.SurfaceKey = RD.SurfaceKey INNER JOIN DDA_Results R ON RD.ResultKey = R.ResultKey INNER JOIN DDA_Signatures Si ON R.SignatureKey = Si.SignatureKey ON DDA_GradeMapping.SignatureKey = R.SignatureKey WHERE  (R.IsMultiLayer = 0) AND S.SurfaceKey = {0} AND {1} ORDER BY dbo.DDA_Grades.Grade, Si.SignatureName", surfaceKey, sqlWhere);
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

		public DataSetResult GetResultByResultDetailKey(long resultDetailKey)
		{
			DataSetResult result = new DataSetResult();

			try
			{
				object[] objs = new object[2];
				objs[0] = 0;//return value
				objs[1] = resultDetailKey;

				result.Result = ExecuteDatasetEx("_GetResultByResultDetailKey", objs);
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

		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				if (filter == string.Empty)
					query = string.Format("SELECT DISTINCT {0} FROM SingleLayerView WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID);
				else
					query = string.Format("SELECT DISTINCT {0} FROM SingleLayerView WITH(NOLOCK) WHERE [TestDate] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4}", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter);

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

		public int GetMaxSignatureCount(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			int maxSignatureCount = 0;
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT MAX(SignatureCount) FROM (SELECT COUNT(SignatureKey) AS SignatureCount FROM SingleLayerViewQuery WITH(NOLOCK) WHERE ({0}) GROUP BY SurfaceKey) AS T", recipe.GetSqlWhere());
				result.Result =  ExecuteDataset(query);

				if (result.Result != null && result.Result.Tables.Count > 0 && result.Result.Tables[0].Rows.Count > 0)
					maxSignatureCount = Convert.ToInt32(result.Result.Tables[0].Rows[0][0]);
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

			return maxSignatureCount;
		}

		public ResultBase GetTotalRow_SingleLayer(string sqlWhere)
		{
			ResultBase result = new ResultBase();

			try
			{
				object[] objs = new object[4];

				objs[0] = "SingleLayerView";
				objs[1] = "ResultKey";
				objs[2] = "ResultKey";
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

		public ResultBase GetTotalRow_SurfaceHasSignature(string sqlWhere)
		{
			ResultBase result = new ResultBase();

			try
			{
				object[] objs = new object[4];

				objs[0] = "SingleLayerView";
				objs[1] = "SurfaceKey";
				objs[2] = "DISTINCT DiskKey, DiskID, TestGrade, SlotNum, LotNo, StationKey, InnerDiameter, OuterDiameter, TestCell, CassetteID, Tester, TestDate, Surface, Product, FabID, SurfaceKey, NumberOfDefect, Loaded, L2_Top_Corr_cts, L2_Bot_Corr_cts, L2_Top_NCorr_cts, L2_Bot_NCorr_cts";
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

		public ChartResult GetSignatureParetoChart(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			ChartResult result = new ChartResult();
			DataSet ds = new DataSet();

			try
			{
				object[] objs = new object[1];
				objs[0] = recipe.GetSqlWhere(); //Where Sql

				ds = ExecuteDataset("_GetParetoChartData", objs);

				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
//					result.ChartTitle = "Signature % Pareto Chart";
//					result.CategoryTitle = "Grade-Signature";
//					result.DataTitle = "Disc Count";
//					result.DataTitle2 = "Yield (%)";
//					result.TotalDisk = Convert.ToInt32(objs[2]);
					
					foreach (DataRow row in ds.Tables[0].Rows)
					{
						string grade = row["Grade"].ToString();
						int diskCount = Convert.ToInt32(row["DiskCount"]);
						double yield = Convert.ToDouble(row["Yield"]);
						result.AddCategoryValue(grade);
						result.AddDataValue(Convert.ToDouble(diskCount));
						result.AddDataValue2(yield);
						result.MaxDisk += diskCount;
						result.MaxYield += yield;

						string query = string.Format("SELECT SignatureName FROM DDA_GradeMapping INNER JOIN DDA_Grades ON DDA_GradeMapping.GradeKey = DDA_Grades.GradeKey INNER JOIN DDA_Signatures ON DDA_GradeMapping.SignatureKey = DDA_Signatures.SignatureKey WHERE DDA_Grades.Grade = {0}", grade);
						DataSet dsSignature = ExecuteDataset(query);
						if (dsSignature != null && dsSignature.Tables.Count > 0 && dsSignature.Tables[0].Rows.Count > 0)
						{
							string signatureName = string.Empty;
							foreach (DataRow rowSig in dsSignature.Tables[0].Rows)
								signatureName += rowSig["SignatureName"].ToString() + "/";

							signatureName = signatureName.Substring(0, signatureName.Length - 1);

							result.AddLabelValue(string.Format("{0}-{1}", grade, signatureName));
						}
						else
							result.AddLabelValue(grade);
					}

					if (result.DataValues != null && result.DataValues.Length > 0)
					{
						double total = 0;
						double percentage = 0;
						foreach (double value in result.DataValues)
						{
							total += value;
							percentage = Math.Round(total / result.MaxDisk, 4);
							result.AddParetoValues(percentage);
						}
					}
				}
			}
			catch
			{
				throw;
			}

			return result;
		}

		public ChartResult GetSignatureParetoChartIndividualResource_TestCell(SiGlaz.Common.DDA.Recipe.SingleLayerRecipe recipe)
		{
			ChartResult result = new ChartResult();
			DataSet ds = new DataSet();

			try
			{
				object[] objs = new object[2];
				objs[0] = recipe.GetSqlWhere();
				objs[1] = recipe.GroupBy;

				ds = ExecuteDataset("_GetParetoChartDataIndividualResource_TestCell", objs);
				if (ds == null || ds.Tables.Count <= 1) return result;
				if (ds.Tables[0].Rows.Count <= 0) return result;
				DataTable dtAll = ds.Tables[0];
				DataTable dtGroupBy = ds.Tables[1];

				Hashtable htGrade = new Hashtable();
				
				#region	All
				foreach (DataRow row in dtAll.Rows)
				{
					string grade = row["Grade"].ToString();
					int diskCount = Convert.ToInt32(row["DiskCount"]);
					double yield = Convert.ToDouble(row["Yield"]);

					string query = string.Format("SELECT SignatureName FROM DDA_GradeMapping INNER JOIN DDA_Grades ON DDA_GradeMapping.GradeKey = DDA_Grades.GradeKey INNER JOIN DDA_Signatures ON DDA_GradeMapping.SignatureKey = DDA_Signatures.SignatureKey WHERE DDA_Grades.Grade = {0}", grade);
					DataSet dsSignature = ExecuteDataset(query);
					if (dsSignature != null && dsSignature.Tables.Count > 0 && dsSignature.Tables[0].Rows.Count > 0)
					{
						string signatureName = string.Empty;
						foreach (DataRow rowSig in dsSignature.Tables[0].Rows)
							signatureName += rowSig["SignatureName"].ToString() + "/";

						signatureName = signatureName.Substring(0, signatureName.Length - 1);
						htGrade.Add(grade, string.Format("{0}-{1}", grade, signatureName));
					}
					else
						htGrade.Add(grade, grade);

					result.AddCategoryValue(grade);
					result.AddDataValue(Convert.ToDouble(diskCount));
					result.AddDataValue2(yield);
					result.MaxDisk += diskCount;
					result.MaxYield += yield;
					result.AddLabelValue(htGrade[grade].ToString());
				}
				#endregion

				#region	Individual
				foreach (DataRow row in dtGroupBy.Rows)			
				{
					string groupByName = row["GroupBy"].ToString();
					if (result.GroupByNameContains(groupByName)) continue;

					DataRow[] rows = dtGroupBy.Select(string.Format("GroupBy = '{0}'", groupByName), "DiskCount DESC");
					if (rows == null || rows.Length <= 0) continue;

					IndividualChartResult chartResult = new IndividualChartResult();
					chartResult.GroupByName = groupByName;

					foreach (DataRow subRow in rows)
					{
						string grade = subRow["Grade"].ToString();
						int diskCount = Convert.ToInt32(subRow["DiskCount"]);
						double yield = Convert.ToDouble(subRow["Yield"]);
						
						chartResult.Result.AddCategoryValue(grade);
						chartResult.Result.AddLabelValue(htGrade[grade]);
						chartResult.Result.AddDataValue(Convert.ToDouble(diskCount));
						chartResult.Result.AddDataValue2(yield);
						chartResult.Result.MaxDisk += diskCount;
						chartResult.Result.MaxYield += yield;
					}

					result.AddIndividualChartResult(chartResult);
				}
				#endregion
			}
			catch
			{
				throw;
			}

			return result;
		}
		#endregion
	}
}
