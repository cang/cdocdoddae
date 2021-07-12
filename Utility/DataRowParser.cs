using System;
using System.Data;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for DataColumnParser.
	/// </summary>
	public class DataRowParser
	{
		public static String ParseToString(DataRow row, String columnName, String defaultValue)
		{
			try
			{
				return Convert.ToString(row[columnName]).Trim();
			}
			catch (System.Exception)
			{
				return  defaultValue;
			}
		}

        public static String ParseToString(DataRow row, int columnIndex, String defaultValue)
        {
            try
            {
                return Convert.ToString(row[columnIndex]).Trim();
            }
            catch (System.Exception)
            {
                return defaultValue;
            }
        }

		public static int ParseToInt32(DataRow row, String columnName, int defaultValue)
		{
			try
			{
				return Convert.ToInt32(row[columnName]);
			}
			catch (System.Exception)
			{
				return  defaultValue;
			}
		}

		public static long ParseToInt64(DataRow row, String columnName, long defaultValue)
		{
			try
			{
				return Convert.ToInt64(row[columnName]);
			}
			catch (System.Exception)
			{
				return  defaultValue;
			}
		}

		public static double ParseToDouble(DataRow row, String columnName, double defaultValue)
		{
			try
			{
				return Convert.ToDouble(row[columnName]);
			}
			catch (System.Exception)
			{
				return  defaultValue;
			}
		}

		public static byte[] ParseToByteArray(DataRow row, String columnName)
		{
			try
			{
				return (byte[])row[columnName];
			}
			catch (System.Exception)
			{
				return  null;
			}
		}

		public static DateTime ParseToDateTime(DataRow row, string columnName, DateTime defaultValue)
		{
			try
			{
				return Convert.ToDateTime(row[columnName]);
			}
			catch (System.Exception)
			{
				return  defaultValue;
			}
		}
	}
}
