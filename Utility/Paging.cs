using System;
using System.Data;
using System.Collections;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for Paging.
	/// </summary>
	public class Paging
	{
		public static ArrayList GetPage(object[] sourceData, int pageNumber, int pageSize, ref int pageCount, ref int rowCount)
		{
			if ( sourceData == null )
				return null;

			// calculate rowCounr/pageCount
			rowCount  = sourceData.Length;
			pageCount = rowCount / pageSize;
			if ( rowCount % pageSize != 0 )
				pageCount++;

			// adjust page size
			if ( pageSize <= 0 )
				pageSize = 10;

			// adjust page number
			if (pageNumber > pageCount )
				pageNumber = pageCount;
			if (pageNumber < 1)
				pageNumber = 1;

			// calculate start/end row
			int startRow = (pageNumber - 1) * pageSize;
			int endRow = startRow + pageSize - 1;
			if ( endRow >= rowCount )
				endRow = rowCount - 1;
			
			ArrayList result = new ArrayList(endRow - startRow + 1);
			
			for (int rowIndex = startRow; rowIndex <= endRow; ++rowIndex)
			{
				result.Add(sourceData[rowIndex]);
			}
			
			return result;
		}

		
		public static DataSet GetPage(DataSet sourceData, int pageNumber, int pageSize, ref int pageCount, ref int rowCount)
		{
			if ( sourceData == null )
				return null;
			DataTable sourceTable = sourceData.Tables[0];

			// calculate rowCounr/pageCount
			rowCount  = sourceTable.Rows.Count;
			pageCount = rowCount / pageSize;
			if ( rowCount % pageSize != 0 )
				pageCount++;

			// adjust page size
			if ( pageSize <= 0 )
				pageSize = 10;

			// adjust page number
			if (pageNumber > pageCount)
				pageNumber = pageCount;
			if ( pageNumber < 1 )
				pageNumber = 1;

			// calculate start/end row
			int startRow = (pageNumber - 1) * pageSize;
			int endRow = startRow + pageSize - 1;
			if ( endRow >= rowCount )
				endRow = rowCount - 1;
			
			DataTable resultTable = sourceTable.Clone();
			for (int rowIndex = startRow; rowIndex <= endRow; ++rowIndex)
			{
				DataRow row = resultTable.NewRow();
				for ( int colIndex = 0; colIndex < sourceTable.Columns.Count; ++colIndex )
				{
					row[colIndex] = sourceTable.Rows[rowIndex][colIndex];
				}
				resultTable.Rows.Add(row);
			}

			DataSet result = new DataSet();
			result.Tables.Add(resultTable);
			return result;
		}
	}
}
