using System;
using System.Data;
using System.Data.OleDb;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for ExcelFile.
	/// </summary>
	public class OleDbUtils
	{
		public OleDbUtils()
		{
		}

		public static string GetDataOfRow(DataRow row,int index)
		{
			if(row.IsNull(index))
				return string.Empty;
			return row[index].ToString();
		}

		public static DataSet LoadSheets(string strFilePath)
		{ 
			OleDbConnection  cnCSV = null;
			OleDbDataAdapter daCSV = null;
			try 
			{  
				string strConnectionString =string.Empty;  
				strConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""" ; 
				cnCSV = new OleDbConnection (strConnectionString);  
				cnCSV.Open(); 
				OleDbCommand cmdSelect = cnCSV.CreateCommand();
				cmdSelect.CommandType = CommandType.Text;
				daCSV = new OleDbDataAdapter();

				//Get List Table Name
				DataTable dtTables = cnCSV.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[] {null, null, null, "TABLE"});
				if(dtTables==null) return null;

				DataSet  dsresult = new DataSet();
				for ( int i = 0; i < dtTables.Rows.Count; ++i )
				{
					string tablename = dtTables.Rows[i]["TABLE_NAME"].ToString();
					cmdSelect.CommandText = string.Format("SELECT * FROM [{0}]",tablename);
					daCSV.SelectCommand  = cmdSelect;
					daCSV.Fill(dsresult,tablename);
				}

				return dsresult;
			}
			catch
			{	  
				return null;
			}
			finally
			{
				if(daCSV!=null)
					daCSV = null;
				if( cnCSV!=null && cnCSV.State == ConnectionState.Open)
					cnCSV.Close();
			}
		}


	}
}
