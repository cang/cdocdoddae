using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using SiGlaz.Utility;

namespace SiGlaz.DAL
{
	/// <summary>
	/// Summary description for ConnectionParam.
	/// </summary>
	/// 
	[Serializable]
	public class ConnectionParam
	{
		private String _server;
		public String Server
		{
			get { return _server; }
			set { _server = value; 
				this.GetConnectionString();
			}
		}

		private String _database;
		public String Database
		{
			get { return _database; }
			set { _database = value; 
				this.GetConnectionString();
			}
		}

		private String _username;
		public String Username
		{
			get { return _username; }
			set { _username = value; 
				this.GetConnectionString();
			}
		}

		private String _password;

		[XmlIgnore()]
		public String Password
		{
			get { return _password; }
			set { _password = value;
				this.GetConnectionString();
			}
		}

		[XmlElement("Password")]
		public String PasswordEncript
		{
			get 
			{ 
				RijndaelCrypto crypto = new RijndaelCrypto();
				return crypto.Encrypt(this.Password);
			}
			set 
			{
				RijndaelCrypto crypto = new RijndaelCrypto();
				this.Password = crypto.Decrypt(value);
			}
		}

		private string _connectionString;
		public	string ConnectionString
		{
			get
			{
				return _connectionString;
			}
		}

		public ConnectionParam()
		{
			this.Server   = "(local)";
			this.Database = "DDADB";
			this.Username = "DDADBUser";
			this.Password = "DDADBPassword";
		}

		public bool Save(String fileName)
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock(fileName);

			bool result = false;
			FileStream stream = null;
			XmlSerializer serializer = null;
			//RijndaelCrypto crypto = null;
			try
			{
				lck.WaitOne();

				stream = File.Create(fileName);
				serializer = new XmlSerializer(typeof(ConnectionParam));
				//crypto = new RijndaelCrypto();
				//String plainPassword = this._password;
				//this._password = crypto.Encrypt(this._password);
				serializer.Serialize(stream, this);
				//this._password = plainPassword;
				result = true;
			}
			catch (System.Exception e)
			{
				throw new Exception("ConnectionParam.Save", e);
			}
			finally
			{
				if ( stream != null )
				{
					stream.Close();
					stream = null;
				}
//				if ( crypto != null )
//				{
//					crypto.Dispose();
//					crypto = null;
//				}

				lck.Release();
				lck.Dispose();
			}

			return result;
		}

		public bool Load(String fileName)
		{
			if(!File.Exists(fileName))
				return false;

			bool result = false;
			FileStream stream = null;
			XmlSerializer serializer = null;
			//RijndaelCrypto crypto = null;

			try
			{
				stream = File.OpenRead(fileName);
				serializer = new XmlSerializer(typeof(ConnectionParam));
				//crypto = new RijndaelCrypto();
				ConnectionParam param = (ConnectionParam)serializer.Deserialize(stream);
				//param._password = crypto.Decrypt(param._password);
				param.CopyTo(this);
				this.GetConnectionString();
				result = true;
			}
			catch (System.Exception e)
			{
				throw new Exception("ConnectionParam.Load", e);
			}
			finally
			{
				if ( stream != null )
				{
					stream.Close();
					stream = null;
				}
//				if ( crypto != null )
//				{
//					crypto.Dispose();
//					crypto = null;
//				}
			}

			return result;
		}

		private void CopyTo(ConnectionParam param)
		{
			param.Server  = this._server;
			param.Database = this._database;
			param.Username = this._username;
			param.Password = this._password;
		}
		private void GetConnectionString()
		{
			_connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", this.Server, this.Database, this.Username, this.Password);
		}

		public bool TestConnection()
		{
			SqlConnection con = null;
			try
			{
				con=new SqlConnection(this.ConnectionString);				
				con.Open();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if(con!=null)
				{
					if(con.State == ConnectionState.Open)
						con.Close();
					con.Dispose();
					con=null;
				}
			}
		}
	}
}
