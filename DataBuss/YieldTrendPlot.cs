using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA.Basic;

namespace SiGlaz.DDA.Business
{
	public class YieldTrendPlot : SingleTableCmd
	{
		#region Constructor
		public YieldTrendPlot() : base()
		{

		}

		public YieldTrendPlot(SiGlaz.Common.DDA.DDADBType type) : base(type)
		{

		}
		#endregion

		#region Private Methods
		//private ArrayList GetPeriodList(YieldTrendPlotRecipe recipe)
		//{
		//    ArrayList periods = new ArrayList();
		//    DateTime from = recipe.TimeFilter.From;
		//    DateTime to = recipe.TimeFilter.To;
		//    int days = 0;
		//    DateTime toDate = to;
		//    bool flag = true;

		//    //switch (recipe.CategoryAxis.Unit)
		//    //{
		//    //    case CategoryAxisUnit.Hour:
		//    //        #region Hour
		//    //        while (flag)
		//    //        {
		//    //            if (recipe.CategoryAxis.GroupUnit > 1)
		//    //            {
		//    //                to = from.AddHours(recipe.CategoryAxis.GroupUnit - 1);
		//    //                to = new DateTime(to.Year, to.Month, to.Day, to.Hour, 59, 59);
		//    //            }
		//    //            else
		//    //                to = new DateTime(from.Year, from.Month, from.Day, from.Hour, 59, 59);

		//    //            if (to > toDate)
		//    //            {
		//    //                to = toDate;
		//    //                flag = false;
		//    //            }

		//    //            Period period = new Period(from, to);
		//    //            period.CategoryValue = string.Format("{0}", from.ToString("MMddyy-HH"));
		//    //            period.DiskCount = GetDiskCountByGrade(period.From, period.To, recipe);
		//    //            period.TotalDisk = GetTotalDisk(period.From, period.To, recipe);
		//    //            periods.Add(period);
		//    //            from = to.AddHours(1);
		//    //            from = new DateTime(from.Year, from.Month, from.Day, from.Hour, 0, 0);
		//    //        }
		//    //        break;
		//    //        #endregion 

		//    //    case CategoryAxisUnit.Day:
		//    //        #region Day
		//    //        days = to.Subtract(from).Days;
		//    //        if (recipe.CategoryAxis.GroupUnit > 1)
		//    //            days = days / recipe.CategoryAxis.GroupUnit;

		//    //        for (int i = 1; i <= days + 1; i++)
		//    //        {
		//    //            if (recipe.CategoryAxis.GroupUnit > 1)
		//    //                to = from.AddDays(recipe.CategoryAxis.GroupUnit - 1);
		//    //            else
		//    //                to = new DateTime(from.Year, from.Month, from.Day, 23, 59, 59);

		//    //            if (to > toDate)
		//    //                to = toDate;

		//    //            Period period = new Period(from, to);

		//    //            if (recipe.CategoryAxis.GroupUnit == 1)
		//    //                period.CategoryValue = period.From.ToString("MM/dd/yyyy");
		//    //            else
		//    //                period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));

		//    //            period.DiskCount = GetDiskCountByGrade(period.From, period.To, recipe);
		//    //            period.TotalDisk = GetTotalDisk(period.From, period.To, recipe);

		//    //            periods.Add(period);
		//    //            from = to.AddDays(1);
		//    //            from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
		//    //        }
		//    //        break;
		//    //        #endregion

		//    //    case CategoryAxisUnit.Week:
		//    //        #region Week
		//    //        DayOfWeek dayOfWeek = from.DayOfWeek;

		//    //        if (dayOfWeek != DayOfWeek.Sunday)
		//    //            days = 7 - (int)from.DayOfWeek;

		//    //        if (recipe.CategoryAxis.GroupUnit > 1)
		//    //            days += 7 * (recipe.CategoryAxis.GroupUnit - 1);

		//    //        while (flag)
		//    //        {
		//    //            to = from.AddDays(days);
		//    //            to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

		//    //            if (to >= toDate)
		//    //            {
		//    //                to = toDate;
		//    //                flag = false;
		//    //            }

		//    //            Period period = new Period(from, to);
		//    //            period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));
		//    //            period.DiskCount = GetDiskCountByGrade(period.From, period.To, recipe);
		//    //            period.TotalDisk = GetTotalDisk(period.From, period.To, recipe);
		//    //            periods.Add(period);

		//    //            days = (7 * recipe.CategoryAxis.GroupUnit) - 1;
		//    //            from = to.AddDays(1);
		//    //            from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
		//    //        }
		//    //        break;
		//    //        #endregion

		//    //    case CategoryAxisUnit.Month:
		//    //        #region Month
		//    //        int daysOfMonths = DateTime.DaysInMonth(from.Year, from.Month);
		//    //        days = daysOfMonths - from.Day;
		//    //        days += GetTotalDaysByNMonth(recipe.CategoryAxis.GroupUnit, from);

		//    //        while (flag)
		//    //        {
		//    //            to = from.AddDays(days);
		//    //            to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

		//    //            if (to >= toDate)
		//    //            {
		//    //                to = toDate;
		//    //                flag = false;
		//    //            }

		//    //            Period period = new Period(from, to);
		//    //            period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));
		//    //            period.DiskCount = GetDiskCountByGrade(period.From, period.To, recipe);
		//    //            period.TotalDisk = GetTotalDisk(period.From, period.To, recipe);
		//    //            periods.Add(period);

		//    //            from = to.AddDays(1);
		//    //            from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);

		//    //            if (recipe.CategoryAxis.GroupUnit > 1)
		//    //                days = GetTotalDaysByNMonth(recipe.CategoryAxis.GroupUnit, from) - 1;
		//    //            else
		//    //                days = DateTime.DaysInMonth(from.Year, from.Month) - 1;
		//    //        }
		//    //        break;
		//    //        #endregion
		//    //}

		//    return periods;
		//}

		//private int GetTotalDaysByNMonth(int n, DateTime date)
		//{
		//    int days = 0;
		//    DateTime dt = date;

		//    for (int i = 0; i < n - 1; i++)
		//    {
		//        dt = dt.AddMonths(1);
		//        days += DateTime.DaysInMonth(dt.Year, dt.Month);
		//    }

		//    return days;
		//}

		//private int GetDiskCountByGrade(DateTime from, DateTime to, YieldTrendPlotRecipe recipe)
		//{
		//    string query = string.Format("SELECT Count(DISTINCT DiskKey) FROM DDADM_View WHERE {0}", recipe.GetSqlWhere());
		//    return (int)ExecuteScalarSQL(query);
		//}

		//private int GetTotalDisk(DateTime from, DateTime to, YieldTrendPlotRecipe recipe)
		//{
		//    string query = string.Format("SELECT Count(DISTINCT DiskKey) FROM DDADM_View WHERE {0}", recipe.GetSqlWhere2());
		//    return (int)ExecuteScalarSQL(query);
		//}

		private bool CheckDateTimeExist(DateTime dateTime, DataTable dt)
		{
			foreach (DataRow row in dt.Rows)
			{
				DateTime date = Convert.ToDateTime(row["DataStamp"]);

				if (date.ToString("yyyy/MM/dd HH:mm:ss") == dateTime.ToString("yyyy/MM/dd HH:mm:ss"))
					return true;
			}

			return false;
		}

		private DataSet GetData(YieldTrendPlotRecipe recipe)
		{
			string sqlWhere = recipe.GetSqlWhere();
			string query = string.Empty;
			
			if (recipe.CubeInfo.Type == CubeType.Yield4H)
				query = string.Format("SELECT [DataStamp], [Yields] FROM DM_4H_YIELD_VIEW WHERE {0} ORDER BY [DataStamp]", sqlWhere);
			else if (recipe.CubeInfo.Type == CubeType.Yield2H)
				query = string.Format("SELECT [DataStamp], [Yields] FROM DM_2H_YIELD_VIEW WHERE {0} ORDER BY [DataStamp]", sqlWhere);
			else
				query = string.Format("SELECT [DataStamp], [Yields] FROM DM_2H_YIELD_V2_VIEW WHERE {0} ORDER BY [DataStamp]", sqlWhere);

			if (!recipe.IsShowNullDataPoint)
				return ExecuteDataset(query);
			else
			{
				DataSet ds = ExecuteDataset(query);

				if (ds == null || ds.Tables.Count <= 0)
					return null;
				else
				{
					DateTime fromDate = recipe.TimeFilter.From;
					DateTime toDate = recipe.TimeFilter.To;
					int unit = 4;

					if (recipe.CubeInfo.Type == CubeType.Yield2H || recipe.CubeInfo.Type == CubeType.Yield2H_V2)
						unit = 2;

					int rowIndex = 0;

					while (fromDate <= toDate)
					{
						DataRow[] rows = ds.Tables[0].Select(string.Format("[DataStamp] = '{0}'", fromDate.ToString("yyyy/MM/dd HH:mm:ss")));

						if (rows == null || rows.Length <= 0)
						{
							DataRow newRow = ds.Tables[0].NewRow();
							newRow[0] = fromDate;
							newRow[1] = 0;
							ds.Tables[0].Rows.InsertAt(newRow, rowIndex);
						}

						fromDate = fromDate.AddHours(unit);
						rowIndex++;
					}

					ds.AcceptChanges();
					return ds;
				}
			}
		}
		#endregion

		#region Public Methods
		public YieldTrendPlotResult GetChartData(YieldTrendPlotRecipe recipe)
		{
			YieldTrendPlotResult result = new YieldTrendPlotResult();

			try
			{
				result.ChartTitle = string.Format("From: {0} To: {1}\r\nGrade = {2}\r\n{3}\r\n{4}", recipe.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), recipe.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"), recipe.Grade, recipe.QueryCondition.ConditionList[1].Replace("'", ""), recipe.QueryCondition.ConditionList[2].Replace("'", "")).Replace("ResourceID", "ResourceValue");

				if (recipe.CubeInfo.Type == CubeType.Yield4H)
					result.CategoryLabel = string.Format("Time (4 Hours)", recipe.CategoryAxis.GroupUnit, recipe.CategoryAxis.Unit);
				else
					result.CategoryLabel = string.Format("Time (2 Hours)", recipe.CategoryAxis.GroupUnit, recipe.CategoryAxis.Unit);

				result.DataLabel = "Yield(%)";
				result.ControlLimit = recipe.ControlLimit;

				DataSet ds = GetData(recipe);

				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
					int rowCount = ds.Tables[0].Rows.Count;
					ArrayList categoryValues = new ArrayList();
					ArrayList dataValues = new ArrayList();
					ArrayList dateTimes = new ArrayList();

					foreach (DataRow row in ds.Tables[0].Rows)
					{
						DateTime dateTime = Convert.ToDateTime(row[0]);
						categoryValues.Add(dateTime.ToString("MMddyy-HH"));
						dateTimes.Add(dateTime);
						dataValues.Add(Math.Round(Convert.ToDouble(row[1]), 2));
					}

					result.CategoryValues = (string[])categoryValues.ToArray(typeof(string));
					result.DateTimes = (DateTime[])dateTimes.ToArray(typeof(DateTime));
					result.DataValues = (double[])dataValues.ToArray(typeof(double));
				}
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

		public DataSetResult GetHintData(string fabID, string cubeType, string cubeName, string fieldName, DateTime from, DateTime to, string filter)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				if (cubeType.ToUpper() == CubeType.Yield4H.ToString().ToUpper())
				{
					if (filter == string.Empty)
						query = string.Format("SELECT DISTINCT {0} FROM DM_4H_YIELD_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND CubeType = '{4}' AND CubeName = '{5}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, cubeType, cubeName);
					else
						query = string.Format("SELECT DISTINCT {0} FROM DM_4H_YIELD_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4} AND CubeType = '{5}' AND CubeName = '{6}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter, cubeType, cubeName);
				}
				else if (cubeType.ToUpper() == CubeType.Yield2H.ToString().ToUpper())
				{
					if (filter == string.Empty)
						query = string.Format("SELECT DISTINCT {0} FROM DM_2H_YIELD_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND CubeType = '{4}' AND CubeName = '{5}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, cubeType, cubeName);
					else
						query = string.Format("SELECT DISTINCT {0} FROM DM_2H_YIELD_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4} AND CubeType = '{5}' AND CubeName = '{6}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter, cubeType, cubeName);
				}
				else
				{
					if (filter == string.Empty)
						query = string.Format("SELECT DISTINCT {0} FROM DM_2H_YIELD_V2_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND CubeType = '{4}' AND CubeName = '{5}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, cubeType, cubeName);
					else
						query = string.Format("SELECT DISTINCT {0} FROM DM_2H_YIELD_V2_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4} AND CubeType = '{5}' AND CubeName = '{6}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter, cubeType, cubeName);
				}
				
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

		public DataSetResult GetCubeNames(string cubeType)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT [CubeName] FROM DIM_CUBES WHERE [IsActive] = 'true' AND [CubeType] = '{0}'", cubeType);
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

		public DataSetResult GetFabList()
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT [FabID] FROM DIM_FABS");
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

		public DataSetResult GetTemplateList()
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT CubeTemplateKey, CubeTemplateName FROM PAR_CUBETEMPLATES WHERE Status = 1");
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

		public DataSetResult GetTemplateDetail(int templateKey)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT T.*, C.CubeType, C.CubeName FROM dbo.PAR_CUBETEMPLATES T, dbo.DIM_CUBES C WHERE T.CubeKey = C.CubeKey AND T.Status = 1 AND CubeTemplateKey = {0}", templateKey);
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

		public DataSetResult GetDateList(string cubeName, string cubeType)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				if (cubeType.ToUpper() == CubeType.Yield4H.ToString().ToUpper())
					query = string.Format("SELECT DISTINCT CAST(CAST(DATEPART(year, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(month, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(day, [DataStamp]) AS nvarchar) AS smalldatetime) as DataStamp FROM dbo.DM_4H_YIELD_VIEW WHERE [CubeName] = '{0}'", cubeName);
				else if (cubeType.ToUpper() == CubeType.Yield2H.ToString().ToUpper())
					query = string.Format("SELECT DISTINCT CAST(CAST(DATEPART(year, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(month, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(day, [DataStamp]) AS nvarchar) AS smalldatetime) as DataStamp FROM dbo.DM_2H_YIELD_VIEW WHERE [CubeName] = '{0}'", cubeName);
				else
					query = string.Format("SELECT DISTINCT CAST(CAST(DATEPART(year, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(month, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(day, [DataStamp]) AS nvarchar) AS smalldatetime) as DataStamp FROM dbo.DM_2H_YIELD_V2_VIEW WHERE [CubeName] = '{0}'", cubeName);
				
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

		public bool CheckIsActive(int cubeKey)
		{
			bool result = false;

			try
			{
				string query = string.Format("SELECT IsActive FROM DIM_CUBES WHERE CubeKey = {0}", cubeKey);
				DataSet ds = ExecuteDataset(query);

				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
					result = Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
			}
			catch
			{
				
			}

			return result;
		}
		#endregion
	}
}
