using System;
using System.IO;
using System.Data.SqlClient;
using SiGlaz.Common.DDA;

namespace SiGlaz.Export.Excel
{
	public class ExportDataReaderToCSV
	{
		#region Constructor
		public ExportDataReaderToCSV()
		{
		}
		#endregion

		#region Static Methods
		public static void Export(SqlDataReader reader, string[] columns, string fileName)
		{
			StreamWriter sw = null;

			try
			{
				// Create the CSV file to which data will be exported.
				sw = new StreamWriter(fileName ,false);

				//Add Headers
				int colCount = columns.Length;
				for(int i = 0; i < colCount; i++)
				{
					sw.Write(columns[i]);
					if (i < colCount - 1) sw.Write(",");
				}

				sw.Write(sw.NewLine);

				//Add All Rows
				while (reader.Read())
				{
					for (int i = 0; i < colCount; i++)        
					{
						if (!reader.IsDBNull(i))
							sw.Write(reader.GetValue(i).ToString());            

						if ( i < colCount - 1) sw.Write(",");
					}

					sw.Write(sw.NewLine);
				}
			}
			catch 
			{
				throw;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
					reader = null;
				}

				if (sw != null)
				{
					sw.Close();
					sw = null;
				}
			}
		}
		#endregion
	}
}
