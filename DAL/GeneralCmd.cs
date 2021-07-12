using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace SiGlaz.DAL
{
	/// <summary>
	/// Summary description for GeneralCmd.
	/// </summary>
	public class GeneralCmd
	{
		public const string SP_INSERT = "_Insert";
		public const string SP_UPDATE = "_Update";
		public const string SP_DELETEALL = "_DeleteAll";
		public const string SP_DELETEBYPRIMARYKEY = "_DeleteByPrimaryKey";
		public const string SP_GETALL = "_GetAll";
		public const string SP_GETBYPRIMARYKEY = "_GetByPrimaryKey";
		#region private members
		/// <summary>
		/// Parameter for database connection
		/// </summary>
		protected ConnectionParam	_param;

		protected SqlConnection		_activecon;
		protected SqlTransaction	_activetran;
		protected bool				_externaltransaction;
		private SqlConnection _currentConnection;
		#endregion

		#region Constructors

		public GeneralCmd():this(SiGlaz.Common.DDA.DDADBType.DDADB)
		{
//			string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");
//			this._param = GetConnectionParam(configFileName);
		}

		public GeneralCmd(SiGlaz.Common.DDA.DDADBType type)
		{
			string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");

			if(type==SiGlaz.Common.DDA.DDADBType.DDAStagingArea)
				configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionDDAStagingArea.cfg");
			else if(type==SiGlaz.Common.DDA.DDADBType.DDAArchives)
				configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionDDAArchive.cfg");
			else if(type==SiGlaz.Common.DDA.DDADBType.DDADataMarts)
				configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionDDADataMarts.cfg");

			this._param = GetConnectionParam(configFileName);
		}

		public GeneralCmd(string configFileName)
		{
			this._param = GetConnectionParam(configFileName);
		}

		public GeneralCmd(ConnectionParam param)
		{
			this._param = param;
		}

		#endregion

		#region Authentication methods
		/// <summary>
		/// check if the service invoke is authorized
		/// </summary>
		/// <param name="privateKey"></param>
		/// <returns></returns>
		public bool IsAuthorized(String privateKey)
		{
			SqlConnection connection = null;
			SqlCommand cmd = null;

			try
			{
				connection = CreateConnection(this._param);
				cmd = connection.CreateCommand();
				cmd.CommandText = "IsAuthorized";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PrivateKey", Utility.MD5Crypto.GetMD5(privateKey));
				return cmd.ExecuteScalar() != null;
			}
			finally
			{
				if ( cmd != null )
				{
					cmd.Dispose();
					cmd = null;
				}
				if ( connection != null )
				{
					connection.Close();
					connection.Dispose();
					connection = null;
				}
			}
		}

		#endregion

		#region Public opreational methods

		public object GetValueSQL(string SQL)
		{
			DataSet ds = this.ExecuteDataset(SQL);
			object returnvalue = null;

			if(ds!=null)
			{
				if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
					returnvalue = ds.Tables[0].Rows[0][0];

				ds.Dispose();
			}

			return returnvalue;
		}

		public bool CheckExistSQL(string spName)
		{
			return ExecuteScalarSQL(spName)>0;
		}

		public long ExecuteScalarSQL(string SQL)
		{
			SqlConnection con = null;
			object objReturn=null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					objReturn = SqlHelper.ExecuteScalar(con,CommandType.Text,SQL);
				}
				else if(ActiveTransaction!=null)
					objReturn = SqlHelper.ExecuteScalar(ActiveTransaction,CommandType.Text,SQL);
				else
					objReturn = SqlHelper.ExecuteScalar(ActiveConnection,CommandType.Text,SQL);

				if(objReturn!=null && objReturn!=DBNull.Value)
					return Convert.ToInt64(objReturn);
				else
					return -1;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public bool CheckExist(string spName,params object[] objs)
		{
			return ExecuteScalarProc(spName,objs)>0;
		}

		public long ExecuteScalarProc(string spName,params object[] objs)
		{
			SqlConnection con = null;
			object objReturn=null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					objReturn = SqlHelper.ExecuteScalar(con,spName,objs);
				}
				else if(ActiveTransaction!=null)
					objReturn = SqlHelper.ExecuteScalar(ActiveTransaction,spName,objs);
				else
					objReturn = SqlHelper.ExecuteScalar(ActiveConnection,spName,objs);

				if(objReturn!=null && objReturn!=DBNull.Value)
					return Convert.ToInt64(objReturn);
				else
					return -1;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public DataSet ExecuteDataset(string spName,params object[] objs)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteDataset(con,spName,objs);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteDataset(ActiveTransaction,spName,objs);
				else
					return SqlHelper.ExecuteDataset(ActiveConnection,spName,objs);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public DataSet ExecuteDatasetEx(string spName,params object[] objs)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteDatasetEx(con,spName,objs);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteDatasetEx(ActiveTransaction,spName,objs);
				else
					return SqlHelper.ExecuteDatasetEx(ActiveConnection,spName,objs);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public DataSet ExecuteDataset(string SQL)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteDataset(con,CommandType.Text,SQL);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteDataset(ActiveTransaction,CommandType.Text,SQL);
				else
					return SqlHelper.ExecuteDataset(ActiveConnection,CommandType.Text,SQL);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public void CloseCurrentConnection()
		{
			try
			{
				if (_currentConnection != null)
				{
					_currentConnection.Close();
					_currentConnection = null;
				}
			}
			catch
			{
				throw;
			}
		}

		public SqlDataReader ExecuteReader(string SQL)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					_currentConnection = con;
					return SqlHelper.ExecuteReader(con,CommandType.Text,SQL);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteReader(ActiveTransaction,CommandType.Text,SQL);
				else
					return SqlHelper.ExecuteReader(ActiveConnection,CommandType.Text,SQL);
			}
			catch
			{
				throw;
			}
		}

		public SqlDataReader ExecuteReaderEx(string spName, params object[] objs)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					_currentConnection = con;
					return SqlHelper.ExecuteReader(con, spName, objs);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteReader(con, spName, objs);
				else
					return SqlHelper.ExecuteReader(con, spName, objs);
			}
			catch
			{
				throw;
			}
		}

		public int ExecuteNonQuery(string spName,params object[] objs)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteNonQuery(con,spName,objs);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteNonQuery(ActiveTransaction,spName,objs);
				else
					return SqlHelper.ExecuteNonQuery(ActiveConnection,spName,objs);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		
		public int ExecuteNonQuery(string SQL)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteNonQuery(con,CommandType.Text,SQL);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteNonQuery(ActiveTransaction,CommandType.Text,SQL);
				else
					return SqlHelper.ExecuteNonQuery(ActiveConnection,CommandType.Text,SQL);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		public int ExecuteNonQueryEx(string spName,params object[] objs)
		{
			SqlConnection con = null;
			try
			{
				if(ActiveConnection==null)
				{
					con = this.CreateConnection();
					return SqlHelper.ExecuteNonQueryEx(con,spName,objs);
				}
				else if(ActiveTransaction!=null)
					return SqlHelper.ExecuteNonQueryEx(ActiveTransaction,spName,objs);
				else
					return SqlHelper.ExecuteNonQueryEx(ActiveConnection,spName,objs);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con!=null)
				{
					con.Close();
					con.Dispose();
					con=null;
				}
			}
		}

		#endregion

        #region Private helper methods

		protected string ConnectionString
		{
			get
			{
				return _param.ConnectionString;
			}
		}

        protected SqlConnection CreateConnection(ConnectionParam param)
		{
			string connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", param.Server, param.Database, param.Username, param.Password);

			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			return connection;
		}

		protected SqlConnection CreateConnection()
		{
			return CreateConnection(this._param);
		}

		private ConnectionParam GetConnectionParam(string configFileName)
		{
			ConnectionParam param = new ConnectionParam();
			param.Load(configFileName);
			return param;
		}

		protected void BeginCommand()
		{
			if(_externaltransaction) return;
			this.ActiveConnection = this.CreateConnection();
			this.ActiveTransaction = this.ActiveConnection.BeginTransaction();
		}
		protected void RollbackCommand()
		{
			if(_externaltransaction) return;
			RollbackTransaction();
		}
		protected void CommitCommand()
		{
			if(_externaltransaction) return;
			CommitTransaction();
		}
		protected void FinallyCommand()
		{
			if(_externaltransaction) return;
			FinallyTransaction();
		}

		protected void BeginTransaction()
		{
			_externaltransaction = true;
			this.ActiveConnection = this.CreateConnection();
			this.ActiveTransaction = this.ActiveConnection.BeginTransaction();
		}
		protected void RollbackTransaction()
		{
			if(this.ActiveTransaction!=null)
				this.ActiveTransaction.Rollback();
		}
		protected void CommitTransaction()
		{
			if(this.ActiveTransaction!=null)
				this.ActiveTransaction.Commit();
		}
		protected void FinallyTransaction()
		{
			if( this.ActiveTransaction!=null)
			{
				this.ActiveTransaction.Dispose();
				this.ActiveTransaction = null;
			}
			if( this.ActiveConnection!=null)
			{
				this.ActiveConnection.Close();
				this.ActiveConnection = null;
			}
			_externaltransaction = false;
		}

		#endregion

		#region Testing methods
		public bool TestConnection()
		{
			if(_param!=null) 
				return _param.TestConnection();
			else
				return false;
		}
		#endregion

		#region Properties


		/// <summary>
		/// When ActiveConnection is not null , Make sure that it is open connection
		/// </summary>
		public SqlConnection ActiveConnection
		{
			get
			{
				return _activecon;
			}
			set
			{
				_activecon = value;
			}
		}

		/// <summary>
		/// When ActiveTransaction is not null, Make sure that is open ActiveTransaction
		/// </summary>
		public SqlTransaction ActiveTransaction
		{
			get
			{
				return _activetran;
			}
			set
			{
				_activetran = value;
			}
		}

		#endregion Properties

		#region internal utils
		protected string AssignToNull(string value)
		{
			if( value==string.Empty)
				return null;
			else
				return value;
		}
		#endregion internal utils

	}
}
