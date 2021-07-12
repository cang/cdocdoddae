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
	public class PerformanceIndicators : SingleTableCmd
	{
		#region Constructor
		public PerformanceIndicators()
			: base()
		{

		}

		public PerformanceIndicators(SiGlaz.Common.DDA.DDADBType type)
			: base(type)
		{

		}
		#endregion

		#region Private Methods
		//private ArrayList GetPeriodList(PerformanceIndicatorsRecipe recipe)
		//{
		//    ArrayList periods = new ArrayList();
		//    DateTime from = recipe.TimeFilter.From;
		//    DateTime to = recipe.TimeFilter.To;
		//    int days = 0;
		//    DateTime toDate = to;
		//    bool flag = true;

		//    switch (recipe.CategoryAxis.Unit)
		//    {
		//        case CategoryAxisUnit.Hour:
		//            #region Hour
		//            while (flag)
		//            {
		//                if (recipe.CategoryAxis.GroupUnit > 1)
		//                {
		//                    to = from.AddHours(recipe.CategoryAxis.GroupUnit - 1);
		//                    to = new DateTime(to.Year, to.Month, to.Day, to.Hour, 59, 59);
		//                }
		//                else
		//                    to = new DateTime(from.Year, from.Month, from.Day, from.Hour, 59, 59);

		//                if (to > toDate)
		//                {
		//                    to = toDate;
		//                    flag = false;
		//                }

		//                Period period = new Period(from, to);
		//                period.CategoryValue = string.Format("{0}", from.ToString("MMddyy-HH"));
		//                period.AverageProcessingTime = GetAverageProcessingTime(period.From, period.To, recipe);
		//                periods.Add(period);
		//                from = to.AddHours(1);
		//                from = new DateTime(from.Year, from.Month, from.Day, from.Hour, 0, 0);
		//            }
		//            break;
		//            #endregion

		//        case CategoryAxisUnit.Day:
		//            #region Day
		//            days = to.Subtract(from).Days;
		//            if (recipe.CategoryAxis.GroupUnit > 1)
		//                days = days / recipe.CategoryAxis.GroupUnit;

		//            for (int i = 1; i <= days + 1; i++)
		//            {
		//                if (recipe.CategoryAxis.GroupUnit > 1)
		//                    to = from.AddDays(recipe.CategoryAxis.GroupUnit - 1);
		//                else
		//                    to = new DateTime(from.Year, from.Month, from.Day, 23, 59, 59);

		//                if (to > toDate)
		//                    to = toDate;

		//                Period period = new Period(from, to);

		//                if (recipe.CategoryAxis.GroupUnit == 1)
		//                    period.CategoryValue = period.From.ToString("MM/dd/yyyy");
		//                else
		//                    period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));

		//                period.AverageProcessingTime = GetAverageProcessingTime(period.From, period.To, recipe);
		//                periods.Add(period);
		//                from = to.AddDays(1);
		//                from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
		//            }
		//            break;
		//            #endregion

		//        case CategoryAxisUnit.Week:
		//            #region Week
		//            DayOfWeek dayOfWeek = from.DayOfWeek;

		//            if (dayOfWeek != DayOfWeek.Sunday)
		//                days = 7 - (int)from.DayOfWeek;

		//            if (recipe.CategoryAxis.GroupUnit > 1)
		//                days += 7 * (recipe.CategoryAxis.GroupUnit - 1);

		//            while (flag)
		//            {
		//                to = from.AddDays(days);
		//                to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

		//                if (to >= toDate)
		//                {
		//                    to = toDate;
		//                    flag = false;
		//                }

		//                Period period = new Period(from, to);
		//                period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));
		//                period.AverageProcessingTime = GetAverageProcessingTime(period.From, period.To, recipe);
		//                periods.Add(period);

		//                days = (7 * recipe.CategoryAxis.GroupUnit) - 1;
		//                from = to.AddDays(1);
		//                from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
		//            }
		//            break;
		//            #endregion

		//        case CategoryAxisUnit.Month:
		//            #region Month
		//            int daysOfMonths = DateTime.DaysInMonth(from.Year, from.Month);
		//            days = daysOfMonths - from.Day;
		//            days += GetTotalDaysByNMonth(recipe.CategoryAxis.GroupUnit, from);

		//            while (flag)
		//            {
		//                to = from.AddDays(days);
		//                to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

		//                if (to >= toDate)
		//                {
		//                    to = toDate;
		//                    flag = false;
		//                }

		//                Period period = new Period(from, to);
		//                period.CategoryValue = string.Format("{0}-{1}", period.From.ToString("MM/dd/yy"), period.To.ToString("MM/dd/yy"));
		//                period.AverageProcessingTime = GetAverageProcessingTime(period.From, period.To, recipe);
		//                periods.Add(period);

		//                from = to.AddDays(1);
		//                from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);

		//                if (recipe.CategoryAxis.GroupUnit > 1)
		//                    days = GetTotalDaysByNMonth(recipe.CategoryAxis.GroupUnit, from) - 1;
		//                else
		//                    days = DateTime.DaysInMonth(from.Year, from.Month) - 1;
		//            }
		//            break;
		//            #endregion
		//    }

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

		//private int GetAverageProcessingTime(DateTime from, DateTime to, PerformanceIndicatorsRecipe recipe)
		//{
		//    string query = string.Format("SELECT AVG(ProcessingDuration) FROM DDADM_View WHERE {0} GROUP BY [DiskKey]", recipe.GetSqlWhere());
		//    return (int)ExecuteScalarSQL(query);
		//}

		private DataSet GetData(PerformanceIndicatorsRecipe recipe)
		{
			 string sqlWhere = recipe.GetSqlWhere();
			string query = string.Format("SELECT [DataStamp], [AverageProcessingDuration] FROM DM_4H_PERPORMANCE_VIEW WHERE {0} ORDER BY [DataStamp]", sqlWhere);

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
		public PerformanceIndicatorsResult GetChartData(PerformanceIndicatorsRecipe recipe)
		{
			PerformanceIndicatorsResult result = new PerformanceIndicatorsResult();

			try
			{
				result.ChartTitle = string.Format("From: {0} To: {1}\r\nGrade = {2}\r\n{3}\r\n{4}", recipe.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), recipe.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"), recipe.Grade, recipe.QueryCondition.ConditionList[1].Replace("'", ""), recipe.QueryCondition.ConditionList[2].Replace("'", "").Replace("ResourceType", "ResourceValue"));
				result.CategoryLabel = string.Format("Time: {0} {1}", recipe.CategoryAxis.GroupUnit, recipe.CategoryAxis.Unit);
				result.DataLabel = "Average Processing Time(ms)";
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
				if (filter == string.Empty)
					query = string.Format("SELECT DISTINCT {0} FROM DM_4H_PERPORMANCE_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND CubeType = '{4}' AND CubeName = '{5}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, cubeType, cubeName);
				else
					query = string.Format("SELECT DISTINCT {0} FROM DM_4H_PERPORMANCE_VIEW WHERE [DataStamp] BETWEEN '{1}' AND '{2}' AND FabID = '{3}' AND {4} AND CubeType = '{5}' AND CubeName = '{6}'", fieldName, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), fabID, filter, cubeType, cubeName);

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

		public DataSetResult GetCubeNames()
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT [CubeName] FROM DIM_CUBES WHERE [IsActive] = 'true' AND [CubeType] = 'Performance'");
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

		public DataSetResult GetDateList(string cubeName)
		{
			DataSetResult result = new DataSetResult();
			string query = string.Empty;

			try
			{
				query = string.Format("SELECT DISTINCT CAST(CAST(DATEPART(year, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(month, [DataStamp]) AS nvarchar) + '/' + CAST(DATEPART(day, [DataStamp]) AS nvarchar) AS smalldatetime) as DataStamp FROM dbo.DM_4H_PERPORMANCE_VIEW WHERE [CubeName] = '{0}'", cubeName);
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
		#endregion
	}
}
