using System;
using System.Data;
using System.Data.SqlClient;

namespace SiGlaz.DAL
{
	/// <summary>
	/// Summary description for SingleTableCmd.
	/// </summary>
	public class SingleTableCmd : GeneralCmd
	{
		protected	string		_TableName;

		public string	TableName
		{
			get
			{
				return _TableName;
			}
			set
			{
				_TableName = value;
			}
		}

		public SingleTableCmd():base()
		{
		}

		public SingleTableCmd(SiGlaz.Common.DDA.DDADBType type):base(type)
		{
		}

		public SingleTableCmd(string tablename,SiGlaz.Common.DDA.DDADBType type):this(type)
		{
			_TableName = tablename;
		}

		public SingleTableCmd(string tablename,ConnectionParam param):base(param)
		{
			_TableName = tablename;
		}

		public SingleTableCmd(ConnectionParam param):base(param)
		{
		}

		public long Insert(params object[] objs)
		{
			string spName = "_" + _TableName + GeneralCmd.SP_INSERT;
			return this.ExecuteScalarProc(spName,objs);
		}

		public long Insert(DataRow dr)
		{
			object []objs = new object[dr.Table.Columns.Count];
			for(int i=0;i<objs.Length;i++)
			{
				objs[i] = dr[i];
			}
			return Insert(objs);
		}

		public int Update(params object[] objs)
		{
			string spName = "_" + _TableName + GeneralCmd.SP_UPDATE;
			return this.ExecuteNonQuery(spName,objs);
		}
		
		public int DeleteByPrimaryKey(params object[] objs)
		{
			string spName = "_" + _TableName + GeneralCmd.SP_DELETEBYPRIMARYKEY;
			return this.ExecuteNonQuery(spName,objs);
		}

		public int DeleteAll()
		{
			string spName = "_" + _TableName + GeneralCmd.SP_DELETEALL;
			return this.ExecuteNonQuery(spName);
		}

		public DataSet GetTable(string tablename)
		{
			string spName = "_" + tablename + GeneralCmd.SP_GETALL;
			return this.ExecuteDataset(spName);
		}

		public DataSet GetTable()
		{
			string spName = "_" + _TableName + GeneralCmd.SP_GETALL;
			return this.ExecuteDataset(spName);
		}

		public DataSet GetTableByPrimaryKey(string tablename,params object[] objs)
		{
			_TableName = tablename;
			return GetTableByPrimaryKey(objs);
		}

		public DataSet GetTableByPrimaryKey(params object[] objs)
		{
			string spName = "_" + _TableName + GeneralCmd.SP_GETBYPRIMARYKEY;
			return this.ExecuteDataset(spName,objs);
		}

		

	}
}
