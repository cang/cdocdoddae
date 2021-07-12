/*
* Created by : Nguyen Dinh Trong
* Created Date : May, 20th, 2005
* Description : This class used to upload/download files to/from FTP server
* 
* Modified by : Khoa Dang
* Last Modified Date : Jan, 9th, 2007
* Description : Port code from using Asynchronous Callback to Thread architect
*/

#define USE_WAIT_HANDLE		// comment this line for using Ansynchronous callback technique
//#define TRACE_DEBUG		// uncomment this line for tracing debug information

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Xml.Serialization;

namespace DDADBManager
{
	public enum FtpServerType : int
	{
		Unix = 1,
		Windows = 2,
		Unknown = 3
	};

	public enum FtpTransferType : int
	{
		ASCII = 0,
		Binary = 1,
		Uknown = 3
	}

	/// <summary>
	/// Provides client connections for FTP network services
	/// </summary>
	/// <remarks>
	/// The <b>FtpClient</b> class provides simple methods for connecting, downloading, uploading and delete 
	/// data over a network in asynchronous blocking mode.
	/// </remarks>
	public class FtpClient : IDisposable
	{
		#region Private constants

		private const int DefaultAcceptIncommonConnectionTimeOut = 30000; // 30 seconds
		private const int DefaultWaitHandleTimeOut = 60*1000; // 1 minutes // moi sua lai
		
		private const int SOCKET_TIMEOUT = 15000; // 15 seconds

		private const string LOCAL_HOST_IP = "127.0.0.1";
		private const string LOCAL_HOST_NAME = "localhost";

		#region FTP Status Codes

		private const int fscFileStatusOkAboutToOpenDataConnection = 150;
		private const int fscDataConnectionOpenTransferStarting = 125;
		
		private const int fscFileStatusOk = 213;
		private const int fscClosingDataConnection = 226;
		private const int fscTransferComplete = 226;

		private const int fscRequestedActionNotTakenFileUnavailable = 550;
		
		private const int fscCommandOkay = 200;
		private const int fscCommandNotImplemented = 202;

		private const int fscSystemTypeOk = 215;

		private const int fscServiceReadyForNewUser = 220;
		private const int fscUserNameOkayNeedPassword = 331;	
		private const int fscUserLoggedIn = 230;

		private const int fscRequestedFileActionOkay = 250;
		private const int fscPATHNAMECreated = 257;

		#endregion

		#endregion

		#region Private members

		/// <summary>
		/// Server OS
		/// </summary>
		private int _serverOS; // 1 - Unix, 2 - Windows

		/// <summary>
		/// Remote name or IP address
		/// </summary>
		private string _remoteHost;

		/// <summary>
		/// Remote port
		/// </summary>
		private int _remotePort;

		/// <summary>
		/// 		/// Remote path
		/// </summary>
		private string _remotePath;

		/// <summary>
		/// User name who has permission to access remote host
		/// </summary>
		private string _username;

		/// <summary>
		/// Password to access remote host
		/// </summary>
		private string _password;

		/// <summary>
		/// Final local path
		/// </summary>
		private string _localPath;

		/// <summary>
		/// This member stores the status of the connection to FTP server is opened or nto
		/// </summary>
		private bool _isOpen;

		/// <summary>
		/// Last occurred error
		/// </summary>
		private string _lastError;

		/// <summary>
		/// Local IP address
		/// </summary>
		private IPAddress _localIP;

		/// <summary>
		/// Socket to send command to remote host
		/// </summary>
		private Socket _clientSocket;

		/// <summary>
		/// Listener for server socket
		/// </summary>
		private Socket _acceptListener;

		/// <summary>
		/// Data socket
		/// </summary>
		private Socket _dataSocket;

		/// <summary>
		/// File stream for writing data to file
		/// </summary>
		private FileStream _stream;

		/// <summary>
		/// Reply code from server
		/// </summary>
		private int _resultCode;

		/// <summary>
		/// Reply message from server
		/// </summary>
		private string _resultMessage;

		/// <summary>
		/// Buffer for transfer
		/// </summary>
		private byte[] _buffer = new byte[10240];

		/// <summary>
		/// Temporary buffer for receiving message from FTP server
		/// </summary>
		private string _message;

		/// <summary>
		/// First time write to file
		/// </summary>
		//		private bool _isFirstWrite;

		/// <summary>
		/// Is readLineCallback done ?
		/// </summary>
		private bool _readLineCallbackDone;

		/// <summary>
		/// Is Accept done ?
		/// </summary>
		private bool _acceptIncomingConnectionDone;

		/// <summary>
		/// Is download done ?
		/// </summary>
		private bool _downloadDone;

		private bool _isDownloading;

		/// <summary>
		/// Is upload done ?
		/// </summary>
		private bool _uploadDone;

		/// <summary>
		/// Is getting file list done ?
		/// </summary>
		private bool _getFileListDone;

		/// <summary>
		/// Time-out
		/// </summary>
		private DateTime _timeout;

		private MemoryStream _memory;

		/// <summary>
		/// Port range
		/// </summary>
		private static int DATA_PORT_RANGE_FROM = 35272;

		private static int DATA_PORT_RANGE_TO   = 65000;

		//private Regex _unixListLineExpression  = new Regex(@"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)");
		private Regex _unixListLineExpression  = new Regex(@"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+[^\s]+)\s+(?<name>.+)");
		private Regex _unixListLineExpression1 = new Regex(@"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)");
		private Regex _unixListLineExpression2 = new Regex(@"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)");
		private Regex _dosListLineExpression   = new Regex(@"(?<timestamp>\d{2}\-\d{2}\-\d{2}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)");

		private AutoResetEvent _acceptWaitHandle = new AutoResetEvent(false);
		private AutoResetEvent _getFileListWaitHandle = new AutoResetEvent(false);
		private AutoResetEvent _downloadFileWaitHandle = new AutoResetEvent(false);
		private AutoResetEvent _uploadFileWaitHandle = new AutoResetEvent(false);
		private AutoResetEvent _readLineWaitHandle = new AutoResetEvent(false);
		

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the name of remote host.
		/// </summary>
		/// <value>The name of the remote host</value>
		public string Server
		{
			get { return _remoteHost; }
			set { _remoteHost = value; }
		}

		/// <summary>
		/// Gets or sets the port number of remote host.
		/// </summary>
		/// <value>The port number of the remote host.</value>
		public int Port
		{
			get { return _remotePort; }
			set { _remotePort = value; }
		}

		/// <summary>
		/// Gets or sets the username for remote host authentication
		/// </summary>
		/// <value>The username for remote host authentication</value>
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		/// <summary>
		/// Gets or sets the password for remote host authentication
		/// </summary>
		/// <value>The password for remote host authentication</value>
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		/// <summary>
		/// Gets or sets the initial directory of the remote host when making a connection.
		/// </summary>
		/// <value>The initial directory of the remote host</value>
		public string RemoteDir
		{
			get { return _remotePath; }
			set { _remotePath = value; }
		}

		/// <summary>
		/// Gets or sets the local directory using for downloading data from remote host.
		/// </summary>
		/// <value>The local directory using for downloading data from remote host.</value>
		public string LocalDir
		{
			get { return _localPath; }
			set { _localPath = value; }
		}

		/// <summary>
		/// Gets the description of the last error.
		/// </summary>
		/// <value>The description of the last error</value>
		[XmlIgnore()]
		public string LastError
		{
			get { return _lastError; }
		}

		/// <summary>
		/// Gets the description of the last error code.
		/// </summary>
		/// <value>The description of the last error code</value>
		[XmlIgnore()]
		public int LastCode
		{
			get { return _resultCode; }
		}

		#endregion

		#region constructors and destructors

		public FtpClient(string remoteHost, int remotePort, string username, string password, string remotePath, string localPath)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.FtpClient");

				this._remoteHost = remoteHost;
				this._remotePort = remotePort;
				this._username   = username;
				this._password   = password;
				this._remotePath = remotePath;
				this._localPath  = localPath;
				this._isOpen     = false;

				if (remoteHost == LOCAL_HOST_IP || remoteHost.ToLower() == LOCAL_HOST_NAME)
				{
					// convert local host IP address to an IPAddress instance
					this._localIP = IPAddress.Parse(LOCAL_HOST_IP);
				}
				else
				{
					try
					{
						// retrieve host name of the local computer
						string hostName = Dns.GetHostName();
					
						// resolves a DNS host name to an IPHostEntry instance
						IPHostEntry hostEntry = Dns.Resolve(hostName);
					
						// ensures hostEntry is valid
						if (hostEntry == null || hostEntry.AddressList.Length == 0)
							throw new System.Exception("Result of resolving local host IP Address is empty.");
					
						// local host IP Address retrieved successfully.
						this._localIP = hostEntry.AddressList[0];
					}
					catch (System.Exception exp)
					{
						OutputTraceLog(exp, "Failed to initialize local IP Address");

						throw;
					}				
				}
			}
			finally
			{
				OutputDebugLog("End FtpClient.FtpClient");
			}
		}

		~FtpClient()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			// force close
			this.CleanUp();

			// clean up accept wait handle
			if (_acceptWaitHandle != null)
			{
				_acceptWaitHandle.Close();
				_acceptWaitHandle = null;
			}

			if (_getFileListWaitHandle != null)
			{
				_getFileListWaitHandle.Close();
				_getFileListWaitHandle = null;
			}
			if (_downloadFileWaitHandle != null)
			{
				_downloadFileWaitHandle.Close();
				_downloadFileWaitHandle = null;
			}

			if (_uploadFileWaitHandle != null)
			{
				_uploadFileWaitHandle.Close();
				_uploadFileWaitHandle = null;
			}

			if (_readLineWaitHandle != null)
			{
				_readLineWaitHandle.Close();
				_readLineWaitHandle = null;
			}

			if (disposing)
				GC.SuppressFinalize(this);
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Connects the client to a remote FTP server using the specified host name, port number, username and password.
		/// </summary>
		/// <exception cref=""
		public bool Open()
		{
			try
			{
				OutputDebugLog("Begin FtpClient.Open");

				#region check if the connection has been opened
			
				if (this._isOpen) 
				{
					// then close the old connection
					Close();
				}

				#endregion

				#region establishs a new connection to remote FTP server
			
				IPAddress address = null;
				IPEndPoint remoteEndPoint = null;
				Socket socket = null;

				try
				{
					// create new instance of socket class using Tcp protocol
					socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				
					// retrieve IP address of remote FTP server
					address = GetIPAddress(this._remoteHost);
				
					// try to connect to remote FTP server
					remoteEndPoint = new IPEndPoint(address, this._remotePort);
					socket.Connect(remoteEndPoint);

					// set socket timeout option
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, DefaultWaitHandleTimeOut);
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, DefaultWaitHandleTimeOut);

					// socket has been opened successfully
					this._clientSocket = socket;
				}
				catch (Exception exp)
				{
					// release temporary created socket
					if (socket != null && socket.Connected) 
						socket.Close();
					socket = null;
				
					// output error to trace log
					OutputTraceLog(exp, "FtpClient.Open");
                
					// save last error
					_lastError = "FtpClient.Open : Couldn't connect to remote server.\r\n" + exp.Message;

					return false;
				}

				#endregion

				#region wait for welcome message
			
				// retrieves message and status code from server
				this.ReadResponse();

				// check result code
				if (this._resultCode != fscServiceReadyForNewUser)
				{
					// close client socket connection
					Close();

					// save last error code and message
					_lastError = GetErrorMessage();
				
					// output to trace log
					OutputTraceLog("FtpClient.Open : " + _resultMessage);
                				
					return false;
				}

				#endregion

				#region authenticates with username and password

				// send user command to remote FTP server
				SendCommand("USER " + _username);

				// check result code
				if (this._resultCode != fscUserNameOkayNeedPassword && this._resultCode == fscUserLoggedIn)
				{
					// close client socket connection
					CleanUp();

					// save last error code and message
					_lastError = GetErrorMessage();
				
					// output to trace log
					OutputTraceLog("FtpClient.Open : " + _resultMessage);

					return false;
				}

				// only sends password command when user did not logged in.
				if (this._resultCode != fscUserLoggedIn)
				{
					// send password command to FTP server
					SendCommand("PASS " + _password);

					// check result code
					if (this._resultCode != fscUserLoggedIn && this._resultCode != fscCommandNotImplemented)
					{
						// close client socket connection
						CleanUp();
					
						// save last error code and message
						_lastError = GetErrorMessage();
					
						// output to trace log
						OutputTraceLog("FtpClient.Open : " + _resultMessage);

						return false;
					}
				}

				#endregion

				#region check the system type of remote FTP server
			
				// send command SYST to retrieve type of remote host
				SendCommand("SYST");

				if ( _resultCode != fscSystemTypeOk )
				{
					// close client socket connection
					CleanUp();
				
					// save last error code and message
					_lastError = GetErrorMessage();
				
					// output to trace log
					OutputTraceLog("FtpClient.Open : SYST" + _resultMessage);

					return false;
				}

				// retrieve system type of remote host from received message
				string serverType = _resultMessage.Substring(4, 4);
				serverType = serverType.ToUpper();

				if (serverType == "UNIX") 
				{
					// UNIX FTP server
					_serverOS = 1;
				}
				else if ( serverType == "WIND" ) 
				{
					// Windows FTP Server
					_serverOS = 2;
				}
				else 
				{
					// unknown system type of remote host
					_serverOS = 3;
				
					// close client socket connection
					CleanUp();
					
					// save last error code & message
					_lastError = "Not supported this server OS.";
				
					// output to trace log
					OutputTraceLog("FtpClient.Open : SYST" + _resultMessage);

					return false;
				}

				#endregion

				#region change current dir of remote host

				// validate argument
				if ( _remotePath != null && _remotePath.Equals(".") == false && _remotePath.Length > 0 )
				{
					// change working directory by sending command CWD (Change working directory) to remote server
					SendCommand("CWD " + _remotePath);

					// check result code
					if (this._resultCode != fscRequestedFileActionOkay) 
					{
						// save last error code and message
						_lastError = GetErrorMessage();

						// output to trace log
						OutputTraceLog("FtpClient.SetCurrentDir : " + _resultMessage);

						return false;
					}

					// retrieve the name of the current directory on the remote host
					// by sending command PWD (Print working directory)
					SendCommand("PWD");

					// check result code
					if (this._resultCode != 257) 
					{
						// save last error code and message
						_lastError = GetErrorMessage();
				
						// output to trace log
						OutputTraceLog("FtpClient.SetCurrentDir : " + _resultMessage);

						return false;
					}

					// gonna have to do better than this....
					string[] str = this._resultMessage.Split('"');
					this._remotePath = str[1];
				}

				// everything is okay, signal opened state
				_isOpen = true;

				#endregion

				return _isOpen; 
			}
			finally
			{
				OutputDebugLog("End FtpClient.Open");
			}
		}

		/// <summary>
		/// Close the FTP connection and releases all resources associated with the <see cref="FtpClient">FtpClient</see>.
		/// </summary>
		/// The <b>Close</b> method closes the FTP Connection by sending QUIT command to remote server. 
		/// It then calls the <b>CleanUp</b> method to close the underlying TCP client connection and releases 
		/// all resources associated with the <see cref="FtpClient">FtpClient</see>
		public void Close()
		{
			try
			{
				OutputDebugLog("Begin FtpClient.Close");
				
				// send QUIT command to FTP server
				if (this._clientSocket != null )
				{
					try
					{
						// say goodbye to remote FTP server
						SendCommand("QUIT");
					}
					catch // do not handle anything here
					{					
					}
				}

				// call CleanUp function to close the TCP client connection and release resources
				CleanUp();
			}
			finally
			{
				OutputDebugLog("End FtpClient.Close");
			}
		}

		/// <summary>
		/// sets the current directory on the remote FTP server
		/// </summary>
		/// The <b>SetCurrentDir</b> methods changes the current directory on the remote FTP server.
		/// It first check if the connection has been opened or not. If not, the method calls <b>Open</b> method
		/// to create a connection to FTP server. 
		/// The <b>SetCurrentDir</b> method use CWD command to change to current directory on the remote host.
		/// <returns><b>True</b> if succeeded otherwise <b>False</b></returns>
		public bool SetCurrentDir(string remoteDir)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.SetCurrentDir(\"{0}\")", remoteDir);

				// validate argument
				if ( remoteDir == null || remoteDir.Equals(".") || remoteDir.Length == 0 )
					return true;

				// check if the connection has been establish
				if (this._isOpen == false && this.Open()==false) 
					return false;

				// change working directory by sending command CWD (Change working directory) to remote server
				SendCommand("CWD " + remoteDir);

				// check result code
				if (this._resultCode != fscRequestedFileActionOkay) 
				{
					// save last error code and message
					_lastError = GetErrorMessage();

					//string s="No such file or directory.";					
					// output to trace log
					OutputTraceLog("FtpClient.SetCurrentDir : " + _resultMessage);

					return false;
				}

				// retrieve the name of the current directory on the remote host
				// by sending command PWD (Print working directory)
				SendCommand("PWD");

				// check result code
				if (this._resultCode != 257) 
				{
					// save last error code and message
					_lastError = GetErrorMessage();
				
					// output to trace log
					OutputTraceLog("FtpClient.SetCurrentDir : " + _resultMessage);

					return false;
				}

				// gonna have to do better than this....
				this._remotePath = this._resultMessage.Split('"')[1];

				return true;
			}
			finally
			{
				OutputDebugLog("End FtpClient.SetCurrentDir");
			}
		}

		/// <summary>
		/// Get the last modified time of the file on the remote server
		/// </summary>
		/// <param name="remoteFile">The location of the file on the remote server</param>
		/// <returns>The last modified time of the file otherwise <see cref="DateTime.MinValue"/>DateTime.MinValue</see></returns>
		public DateTime GetFileTime(string remoteFile)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.GetFileTime(\"{0}\")", remoteFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false)
					return DateTime.MinValue;

				// set the remote host to ASCII transfer mode
				if (SetTransferType(FtpTransferType.ASCII) == false)
					return DateTime.MinValue;

				// send command MDTM to remote FTP server 
				// to receive the last-modified time of the given file.
				SendCommand("MDTM " + Path.GetFileName(remoteFile));

				// check result code
				if ( this._resultCode != fscFileStatusOk)
					return DateTime.MinValue;

				// the return value from FTP server is in the format "YYYYMMDDhhmmss"
				int year   = Convert.ToInt32(_resultMessage.Substring(4, 4));
				int month  = Convert.ToInt32(_resultMessage.Substring(8, 2));
				int day    = Convert.ToInt32(_resultMessage.Substring(10, 2));
				int hour   = Convert.ToInt32(_resultMessage.Substring(12, 2));
				int minute = Convert.ToInt32(_resultMessage.Substring(14, 2));
				int second = Convert.ToInt32(_resultMessage.Substring(16, 2));

				// convert received time to local time
				DateTime filetime = new DateTime(year, month, day, hour, minute, second);			
				return filetime.ToLocalTime();
			}
			catch
			{
				return DateTime.MinValue;
			}
			finally
			{
				OutputDebugLog("End FtpClient.GetFileTime");
			}
		}

		/// <summary>
		/// Gets the size of the file on the remote server.
		/// </summary>
		/// <param name="remoteFile">The location of the file on the remote server</param>
		/// <returns>The size of the file otherwise -1.</returns>
		public long GetFileSize(string remoteFile)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.GetFileSize(\"{0}\")", remoteFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false)
					return -1;

				// set the remote host to ASCII transfer mode
				if (SetTransferType(FtpTransferType.ASCII) == false)
					return -1;

				// send command SIZE to remote FTP server 
				// to receive the size of the given file.
				SendCommand("SIZE " + remoteFile);
			
				long size = -1;
			
				// check result code
				if (this._resultCode == fscFileStatusOk)
					size = long.Parse(this.GetErrorMessage());
			
				return size;
			}
			finally
			{
				OutputDebugLog("End FtpClient.GetFileSize");
			}
		}

		public ArrayList GetSubFolders(ArrayList parentFolders)
		{
			ArrayList resultDirs = new ArrayList();
			for(int i=0; i<parentFolders.Count; i++)
			{
				string dir = (string)parentFolders[i];

				SetCurrentDir(dir);

				ArrayList subDirs = GetFolderList();

				if(subDirs != null && subDirs.Count > 0) 
				{
					for(int j =0;j<subDirs.Count;j++)
					{
						string subDir = (string)subDirs[j];
 
						if(!dir.EndsWith("/")) dir = dir + "/";
						if(!subDir.EndsWith("/")) subDir = subDir + "/";

						string dirName = string.Format("{0}{1}", dir, subDir);

						subDirs[j] = dirName;
						resultDirs.Add(dirName);						
					}

					ArrayList tmpResultDirs = GetSubFolders(subDirs);

					if(tmpResultDirs != null)
						resultDirs.AddRange(tmpResultDirs);
				}
			}

			return resultDirs;
		}
		/// <summary>
		/// Gets the list of file in the current directory on the remote FTP server
		/// </summary>
		/// <returns>The <see cref="ArrayList">ArrayList</see> object contains the filename 
		/// in the current directory on the remote FTP server.</returns>		
		/// <remarks></remarks>
		public ArrayList GetFileList()
		{
			return List(1);
		}

		public ArrayList GetFolderList()
		{
			return List(0);
		}
		
		private ArrayList List(int type)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.GetFileList");
				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false) 
					return null;

				// set the remote host to ASCII transfer mode
				if (SetTransferType(FtpTransferType.ASCII) == false)
					return null;

				// create a accept listener to issue accept incoming request from server
				if (CreateDataSocket() == false) 
					return null;

				// retrieve the information about each file in the current directory on the remote host
				// by sending LIST command
				SendCommand("LIST");

				// check result code
				if (this._resultCode != fscFileStatusOkAboutToOpenDataConnection && 
					this._resultCode != fscDataConnectionOpenTransferStarting && 
					this._resultCode != fscClosingDataConnection || 
					this._resultCode == fscRequestedActionNotTakenFileUnavailable) 
				{
					// save last error and message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog("FtpClient.GetFileList : SendCommand LIST : " + _resultMessage);

					// close data socket
					CloseDataSocket();

					return null;
				}

				#region wait for issuing accept incoming requests from remote server

#if USE_WAIT_HANDLE				
				
				if (this.DoAcceptIncommingRequest() == false)
				{
					// clean up the data listener and data socket objects
					CloseDataSocket();

					// save last error and message
					_lastError = "Time-out.";
					
					// output to trace log
					OutputTraceLog("FtpClient.GetFileList : Cannot accept incomming connection attempt : Time-out.");

					return null;
				}			
				
#else
				_timeout = DateTime.Now.AddSeconds(30);
				_acceptIncomingConnectionDone = false;
				_acceptListener.BeginAccept(new AsyncCallback(AcceptCallback), null);

				// check time-out
				while ( !_acceptIncomingConnectionDone && _timeout > DateTime.Now )
				{
					System.Threading.Thread.Sleep(10);
				}

				if ( !_acceptIncomingConnectionDone )
				{
					// clean up the data listener and data socket objects
					CloseDataSocket();

					// save last error and message
					_lastError = "Time-out.";
					
					// output to trace log
					OutputTraceLog("FtpClient.GetFileList : Cannot create data socket : Time-out.");

					return null;
				}
#endif
				#endregion

				#region download file list from the remote host
				
#if USE_WAIT_HANDLE				

				if (this.DoGetFileList() == false)
					return null;

				// close all connections
				this.CloseDataSocket();
#else
				_timeout = DateTime.Now.AddSeconds(60);
				_getFileListDone = false;
				_message = String.Empty;
				_dataSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(GetFileListCallback), null);

				// check time-out
				while ( !_getFileListDone && _timeout > DateTime.Now )
				{
					System.Threading.Thread.Sleep(10);
				}

				CloseDataSocket();

				if ( !_getFileListDone )
				{
					_lastError = "Time-out.";
					
					OutputTraceLog("FtpClient.GetFileList : Cannot get the file list. Time-out.");
					return null;
				}
#endif			

				#endregion

				#region parse results returned by remote server

				// save the response message
				String[] listLines = _message.Split("\r\n".ToCharArray());

				// check if transfer complete code has been reached
				if (this._resultCode != fscTransferComplete)
				{
					// try to read it again
					ReadResponse();
				}

				// check result code
				if (this._resultCode != fscTransferComplete)
				{
					// save error message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog("FtpClient.GetFileList : " + _resultMessage);
					
					return null;
				}
			
				// parse file name from raw data
				ArrayList list = new ArrayList();

				foreach (String line in listLines)
				{
					if (line != null && line != "")
					{
						String name = (type == 1) ? GetFileName(line) : GetFolderName(line);
						if (name != null && name != "")
							list.Add(name);
					}
				}

				#endregion

				return list;//sua lai neu exception thi return null, nguoc lai return array ngay ca khi array.count =0 //Code cu~: return ( list.Count > 0 ) ? list : null;
			}
			catch (Exception exp) // unhanded exception
			{
				// output to trace log
				OutputTraceLog(exp, "FtpClient.GetFileList - Unhanded Exception");

				return null;
			}
			finally
			{
				OutputDebugLog("End FtpClient.GetFileList");
			}
		}
/*
		public bool Download(string remoteFile)
		{
			object interProcessResourceAccessObject = null;
		
			string FileName=Path.Combine(_localPath, Path.GetFileName(remoteFile));
			try
			{
				bool hasSignal = false;
				
				hasSignal = Utility.BeginSynchResource(FileName, ref interProcessResourceAccessObject);
				if (hasSignal)
					return DownloadAsync(remoteFile);
				else return false;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
			finally 
			{
				Utility.EndSynchResource(FileName, ref interProcessResourceAccessObject);
			}			
			
		}*/
		/// <summary>
		/// The <b>Download</b> method download a file from remote server to local machine at location specified by <b>LocalPath</b>.
		/// </summary>
		/// <param name="remoteFile"></param>
		/// <returns></returns>		
		public bool Download(string remoteFile)
		{
			string remoteFileName = string.Empty;

			try
			{
				OutputDebugLog("Begin FtpClient.Download(\"{0}\")", remoteFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false)
					return false;

				// set the remote host to Binary transfer mode
				if (SetTransferType(FtpTransferType.Binary) == false)
					return false;

				// create a accept listener to issue accept incoming request from server
				if (CreateDataSocket() == false)
					return false;

				// send command "RETR" to retrieve given file from the remote server
				SendCommand("RETR " + remoteFile);
				
				// check result code
				if (_resultCode != fscFileStatusOkAboutToOpenDataConnection && 
					_resultCode != fscDataConnectionOpenTransferStarting && 
					_resultCode != fscClosingDataConnection)
				{
					// save last error and message
					_lastError = GetErrorMessage();

					// close listener socket
					CloseDataSocket();
					
					// output to trace log
					OutputTraceLog(String.Format("FtpClient.Download : SendCommand RETR : Cannot download the file {0} from FTP server. Reason : {1}", remoteFile, _resultMessage));

					return false;
				}

				#region wait for issuing accept incoming requests from remote server

#if USE_WAIT_HANDLE			
				
				if (this.DoAcceptIncommingRequest() == false)
				{
					// clean up the data listener and data socket objects
					CloseDataSocket();

					// save last error and message
					_lastError = "Time-out.";
					
					// output to trace log
					OutputTraceLog("FtpClient.Download : Cannot accept incomming connection attempt : Time-out.");

					return false;
				}
#else
				// get data socket
				_timeout = DateTime.Now.AddSeconds(30);
				_acceptIncomingConnectionDone  = false;
				_acceptListener.BeginAccept(new AsyncCallback(AcceptCallback), null);

				// check time-out
				while ( !_acceptIncomingConnectionDone && _timeout > DateTime.Now )
				{
					System.Threading.Thread.Sleep(10);
				}

				if ( !_acceptIncomingConnectionDone ) // failed
				{
					CloseDataSocket();

					_lastError = "Failed to create data socket. Time-out.";
					
					OutputTraceLog("FtpClient.Download : Failed to create data socket.");
					return false;
				}
				
#endif
				#endregion

				#region download file from the remote host
#if USE_WAIT_HANDLE

				// download file from the remote server
				if (this.DoDownloadFile(remoteFile) == false)
				{
					// only need to close data socket
					// error has been handled in DoDownloadFile
					this.CloseDataSocket();

					return false;
				}
				
				// close all connections
				this.CloseDataSocket();
#else
				// receiving data
				_timeout = DateTime.Now.AddMinutes(2);
				_downloadDone = false;
				_isDownloading = true;
				_memory = new MemoryStream();
				_dataSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(DownloadCallback), remoteFile);

				// check time-out
				while ( !_downloadDone && _timeout > DateTime.Now )
				{
					System.Threading.Thread.Sleep(10);
				}

				_isDownloading = false;

				CloseDataSocket();
				
				if ( !_downloadDone ) // failed
				{
					CleanUp();
					_lastError = "FtpClient.Download : Time-out.";
					
					OutputTraceLog(String.Format("FtpClient.Download : Cannot download the file {0} from FTP server. Reason : Time-out", remoteFile));
					return false;
				}
#endif
				#endregion

				#region parse results returned by remote server

				// check if transfer complete code has been reached
				if (this._resultCode != fscClosingDataConnection && this._resultCode != fscRequestedFileActionOkay)
				{
					// try to read it again
					ReadResponse();
				}

				// check result code
				if ( this._resultCode != fscClosingDataConnection && this._resultCode != fscRequestedFileActionOkay)
				{
					// save error message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog(String.Format("FtpClient.Download : After transferring : Cannot download the file {0} from FTP server. Reason : {1}", remoteFile, _resultMessage));
					
					return false;
				}

				// check if local directory is existed
				if (Directory.Exists(_localPath) == false) 
				{
					// create the new one
					Directory.CreateDirectory(_localPath);
				}

				// inits a file stream to flush data from memory stream

				//remove char of filename in Path.InvalidPathChars
				//remoteFileName = Utility.CorrectInvalidPathChars(remoteFile);				

				remoteFileName = Path.GetFileName(remoteFileName);	
			
				//correct file name
				//remoteFileName = Utility.CorrectFileName(remoteFileName);	

				_stream = File.Create(Path.Combine(_localPath, remoteFileName));
				
				// flush memory stream to file stream
				_memory.WriteTo(_stream);

				// force stream to flush data from memory to file
				_stream.Flush();

				#endregion

				return true;
			}
			catch (Exception exp ) // unhanded exception
			{
				// save last error and message
				_lastError = "FtpClient.Download : " + exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.Download : Local Path : " + remoteFileName + " Remote File : " + remoteFile);

				return false;
			}
			finally
			{
				// clean up temporary helpers
				if (_memory != null)
				{
					_memory.Close();
					_memory = null;
				}

				if (_stream != null)
				{
					_stream.Close();
					_stream = null;
				}

				#region GC full collect
				GC.WaitForPendingFinalizers();
				GC.Collect();
				GC.Collect();
				#endregion

				OutputDebugLog("End FtpClient.Download");
			}
		}


		public bool Upload(string localFile)
		{
			// parse remote file name from local file path
			string remoteFile = Path.GetFileName(localFile);

			return Upload(localFile, remoteFile);
		}

		/// <summary>
		/// The <b>Upload</b> method upload the file from local disk to remote server
		/// </summary>
		/// <param name="localFile"></param>
		/// <returns></returns>
		public bool Upload(string localFile, string remoteFile)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.Upload(\"{0}\")", localFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false)
					return false;

				// set the remote host to Binary transfer mode
				if (SetTransferType(FtpTransferType.Binary) == false)
					return false;

				// create a accept listener to issue accept incoming request from server
				if (CreateDataSocket() == false)
					return false;

				// send command "STOR" in order to request server to store the remote file name
				SendCommand("STOR " + remoteFile);
				
				// check result code
				if (this._resultCode != fscFileStatusOkAboutToOpenDataConnection && 
					this._resultCode != fscDataConnectionOpenTransferStarting)
				{
					// save last error and message
					_lastError = GetErrorMessage();
					
					// close listener socket
					OutputTraceLog("FtpClient.Upload : SendCommand STOR : " + _resultMessage);

					return false;
				}

				#region wait for issuing accept incoming requests from remote server

#if USE_WAIT_HANDLE		

				if (this.DoAcceptIncommingRequest() == false)
				{
					// clean up the data listener and data socket objects
					CloseDataSocket();

					// save last error and message
					_lastError = "Time-out.";
					
					// output to trace log
					OutputTraceLog("FtpClient.Upload : Cannot accept incomming connection attempt : Time-out.");

					return false;
				}
#else
				// get data socket
				_timeout = DateTime.Now.AddSeconds(30);
				_acceptIncomingConnectionDone = false;
				_acceptListener.BeginAccept(new AsyncCallback(AcceptCallback), null);

				// check time-out
				while ( !_acceptIncomingConnectionDone && _timeout > DateTime.Now )
				{
					System.Threading.Thread.Sleep(10);
				}
				
				//
				if ( !_acceptIncomingConnectionDone )
				{
					CloseDataSocket();
					CleanUp();
					
					OutputTraceLog(String.Format("FtpClient.Upload : Cannot upload the file {0} to FTP server. Reason : time-out to create data socket.", localFile));
					return false;
				}

#endif
				#endregion

				#region update file to the remote host
#if USE_WAIT_HANDLE

				// upload file to the remote server
				if (this.DoUploadFile(localFile) == false)
				{
					// only need to close data socket
					// error has been handled in DoDownloadFile
					this.CloseDataSocket();

					return false;
				}
				
				// close all connections
				this.CloseDataSocket();
#else
				int bytes = 0;
				byte[] buffer = new byte[1024];

				try
				{
					if ( _stream != null )
					{
						_stream.Close();
						_stream = null;
					}

					_stream = File.Open(localFile, FileMode.Open, FileAccess.Read, FileShare.Read);

					while ( ( bytes = _stream.Read(buffer, 0, buffer.Length) ) > 0 )
					{
						_timeout = DateTime.Now.AddSeconds(30);
						_uploadDone = false;
						_dataSocket.BeginSend(buffer, 0, bytes, 0, new AsyncCallback(UploadCallback), null);

						while ( !_uploadDone && _timeout > DateTime.Now )
						{
							System.Threading.Thread.Sleep(10);
						}

						if ( !_uploadDone )
						{
							CleanUp();
							
							OutputTraceLog(String.Format("FtpClient.Upload : Failed to upload the file {0} to FTP server. Reason : time-out.", localFile));
							return false;
						}
					}
				}
				catch ( Exception exp )
				{
					CleanUp();
					
					OutputTraceLog(exp, "FtpClient.Upload");
					return false;
				}
				finally
				{
					CloseDataSocket();
					if ( _stream != null ) 
					{
						_stream.Close();
						_stream = null;
					}
				}

#endif
				#endregion

				// check if transfer complete code has been reached
				if (this._resultCode != fscClosingDataConnection && this._resultCode != fscRequestedFileActionOkay)
				{
					// try to read it again
					ReadResponse();
				}

				// check result code
				if (this._resultCode != fscTransferComplete)
				{
					// save error message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog("FtpClient.Upload : After transfering file : " + _resultMessage);

					return false;
				}

				return true;
			}
			catch ( Exception exp )
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.Upload");
				return false;
			}
			finally
			{
				OutputDebugLog("End FtpClient.Upload");
			}
		}
		
		/// <summary>
		/// The <b>Delete</b> method remove the file on the remote server
		/// </summary>
		/// <param name="remoteFile"></param>
		/// <returns></returns>
		public bool DeleteFile(string remoteFile)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.DeleteFile(\"{0}\")", remoteFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false) 
					return false;

				// set the remote host to ASCII transfer mode
				if (SetTransferType(FtpTransferType.ASCII) == false)
					return false;

				// send command "DELE" to remote server in order to delete the given file
				//SendCommand("DELE " + Path.GetFileName(remoteFile));
				SendCommand("DELE " + Path.GetFileName(remoteFile));

				if (this._resultCode != fscRequestedFileActionOkay) 
				{
					// save last error and message
					_lastError = this._resultMessage;
					
					// output to trace log
					OutputTraceLog("FtpClient.DeleteFile : " + _resultMessage);

					return false;
				}

				return true;
			}
			catch (Exception exp) // unhanded exception
			{
				// save last error and message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.DeleteFile");

				// clean up data and force the connection to close (I don't know why)
				CleanUp();

				return false;
			}
			finally
			{
				OutputDebugLog("End FtpClient.DeleteFile");
			}
		}

		public bool DeleteFileWithFullName(string remoteFile)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.DeleteFile(\"{0}\")", remoteFile);

				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false) 
					return false;

				// set the remote host to ASCII transfer mode
				if (SetTransferType(FtpTransferType.ASCII) == false)
					return false;

				// send command "DELE" to remote server in order to delete the given file
				//SendCommand("DELE " + Path.GetFileName(remoteFile));
				SendCommand("DELE " + remoteFile);

				if (this._resultCode != fscRequestedFileActionOkay) 
				{
					// save last error and message
					_lastError = this._resultMessage;
					
					// output to trace log
					OutputTraceLog("FtpClient.DeleteFile : " + _resultMessage);

					return false;
				}

				return true;
			}
			catch (Exception exp) // unhanded exception
			{
				// save last error and message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.DeleteFile");

				// clean up data and force the connection to close (I don't know why)
				CleanUp();

				return false;
			}
			finally
			{
				OutputDebugLog("End FtpClient.DeleteFile");
			}
		}


		public bool Rename(string oldFileName, string newFileName)
		{
			try
			{
				OutputDebugLog("Begin FtpClient.GetFileList");
				// check if the connection is opened or not
				// if not, then open the connection to remote FTP server
				if (this._isOpen == false && this.Open() == false) 
					return false;

				// try to rename remote file
				SendCommand("RNFR " + oldFileName);

				// check result code
				if (this._resultCode != 350)
				{
					// save last error and message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog("FtpClient.Rename : SendCommand RNFR : " + _resultMessage);

					return false;
				}

				// send command RNTO
				SendCommand("RNTO " + newFileName);
				if (this._resultCode != 250)
				{
					// save last error and message
					_lastError = GetErrorMessage();
					
					// output to trace log
					OutputTraceLog("FtpClient.Rename : SendCommand RNTO : " + _resultMessage);

					return false;
				}
				return true;
			}
			catch (Exception exp) // unhanded exception
			{
				// output to trace log
				OutputTraceLog(exp, "FtpClient.GetFileList - Unhanded Exception");

				return false;
			}
			finally
			{
				OutputDebugLog("End FtpClient.GetFileList");
			}
		}
		#endregion

		#region Private methods

		#region Asynchronous callback helpers

		private void ReadLineCallback(IAsyncResult ar)
		{
			try
			{
				int bytesRead = this._clientSocket.EndReceive(ar);

				string tmp = Encoding.ASCII.GetString(_buffer, 0, bytesRead);

				String[] recvLines = tmp.Split('\n');

				// get the last string of return message
				if ( recvLines.Length > 2 )
					_message = recvLines[recvLines.Length - 2];
				else
					_message = recvLines[0];

				// check if all return message has come
				if ( _message.Length > 4 && !_message.Substring(3, 1).Equals(" ") ) 
					this._clientSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(ReadLineCallback), null);
				else
					_readLineCallbackDone = true;

				tmp = null;
				for ( int i = 0; i < recvLines.Length; ++i )
				{
					recvLines[i] = null;
				}
				recvLines = null;
			}
			catch ( Exception exp )
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.ReadLineCallback");
			}
		}
		
		private void GetFileListCallback(IAsyncResult ar)
		{
			try
			{
				int bytes = _dataSocket.EndReceive(ar);
				_message  += Encoding.ASCII.GetString(_buffer, 0, bytes);

				if ( bytes > 0 )
				{
					// set time-out for next try
					_timeout = DateTime.Now.AddSeconds(60);

					_dataSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(GetFileListCallback), null);
				}
				else
				{
					_getFileListDone = true;
				}
			}
			catch ( Exception exp )
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.GetFileListCallback");
			}
			finally
			{
			}
		}
		
		private void UploadCallback(IAsyncResult ar)
		{
			try
			{
				_dataSocket.EndSend(ar);
				_uploadDone = true;
			}
			catch ( Exception exp )
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.Upload");
			}
		}
		
		private void DownloadCallback(IAsyncResult ar)
		{
			lock ( this )
			{
				if ( !_isDownloading )
					return;

				try
				{
					string remoteFile = (string)ar.AsyncState;

					// Read data from the remote device.
					int bytesRead = _dataSocket.EndReceive(ar);

					if ( bytesRead > 0 ) 
					{
						// write to memory
						_memory.Write(_buffer, 0, bytesRead);

						// set time-out for next try
						_timeout = DateTime.Now.AddSeconds(60);

						//  Get the rest of the data.
						_dataSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(DownloadCallback), remoteFile);
					} 
					else 
					{
						_downloadDone = true;
					}
				} 
				catch ( Exception e ) 
				{
					_downloadDone = false;
					_lastError = e.Message;
					
					OutputTraceLog(e, "FtpClient.Download");
				}
			}
		}

		private void AcceptCallback(IAsyncResult ar)
		{
			try
			{
				_dataSocket = this._acceptListener.EndAccept(ar);
				_acceptIncomingConnectionDone = true;
			}
			catch (Exception exp)
			{
				_dataSocket = null;
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.AcceptCallback");               
			}
		}


		#endregion

		/// <summary>
		/// The <b>ReadLine</b> method reads a message sent from remote host line by line
		/// </summary>
		/// <returns>The message sent from the remote host.</returns>
		private string ReadLine()
		{
			if (this._clientSocket == null)
				throw new System.ArgumentNullException("_clientSocket");

			_timeout = DateTime.Now.AddSeconds(60);
			_message = string.Empty;
			_readLineCallbackDone = false;

			this._clientSocket.BeginReceive(_buffer, 0, _buffer.Length, 0, new AsyncCallback(ReadLineCallback), null);

			while ( !_readLineCallbackDone && _timeout > DateTime.Now )
			{
				System.Threading.Thread.Sleep(10);
			}

			if ( !_readLineCallbackDone )
			{	
				// output to trace log
				OutputTraceLog("FtpClient.ReadLine : Time-out.");

				return string.Empty;
			}

			return _message;
		}

		/// <summary>
		/// The <b>ReadResponse</b> method reads a result message sent from remote host.
		/// </summary>
		private void ReadResponse()
		{
			try
			{
				this._message = string.Empty;
#if USE_WAIT_HANDLE
				this._resultMessage = this.DoReadLine();
#else
				this._resultMessage = ReadLine();
#endif

				if ( this._resultMessage.Length > 3 )
					this._resultCode = int.Parse(this._resultMessage.Substring(0, 3));
				else
					this._resultCode = 0;
			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog("FtpClient.ReadResponse: {0}", exp.Message);

				// signal connection is closed
				this._isOpen = false;
			}
		}

		/// <summary>
		/// Send a command to remote host and receive return message from it
		/// </summary>
		/// <param name="command">a string object contains the command to be sent</param>
		private void SendCommand(string command)
		{
			try
			{
				Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
				this._clientSocket.Send( cmdBytes, cmdBytes.Length, 0);

				if (command.StartsWith("USER") || command.StartsWith("PASS"))
					System.Threading.Thread.Sleep(1000);
			
				if (command != "QUIT")
					ReadResponse();
			}
			catch(System.Exception exp)
			{
				// output to trace log
				OutputTraceLog("FtpClient.ReadResponse: {0}", exp.Message);

				// signal connection is closed
				this._isOpen = false;
			}
		}

		/// <summary>
		/// Sets the type of file to be transfered
		/// </summary>
		/// <param name="transferType">The type of file to be transfered.</param>
		/// <returns>True if succeed, otherwise False</returns>
		private bool SetTransferType(FtpTransferType transferType)
		{
			try
			{
				switch (transferType)
				{
					case FtpTransferType.ASCII:
						SendCommand("TYPE A");
						break;
					case FtpTransferType.Binary:
						SendCommand("TYPE I");
						break;
					default:
						throw new System.Exception("Unknown transfer type " + transferType.ToString());
				}

				return _resultCode == fscCommandOkay;
			}
			catch (Exception exp)
			{
				// closes the connection and releases resources
				CleanUp();

				// saves last error code and message
				_lastError = exp.Message;
				
				// outputs to trace log
				OutputTraceLog(exp, "FtpClient.SetTrasferType");

				return false;
			}
		}

		
		#region Utilities helpers

		private void CleanUp()
		{
			try
			{
				if (_memory != null)
					_memory.Close();
				_memory = null;

				if (_stream != null)
					_stream.Close();
				_stream = null;

				if (this._dataSocket != null && this._dataSocket.Connected)
					this._dataSocket.Close();
				this._dataSocket = null;

				if (this._acceptListener != null && this._acceptListener.Connected)
					this._acceptListener.Close();
				this._acceptListener = null;

				if (this._clientSocket != null)
					this._clientSocket.Close();
				this._clientSocket = null;
			}
			catch (Exception exp)
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.CleanUp");
			}

			this._isOpen = false;
		}

		
		private String GetErrorMessage()
		{
			if ( this._resultMessage != null && this._resultMessage.Length > 4 )
			{
				return this._resultMessage.Substring(4);
			}
			else
			{
				return "Connection lost !";
			}
		}

		private IPAddress GetIPAddress(string remoteHost)
		{
			try
			{
				return IPAddress.Parse(remoteHost);
			}
			catch
			{
				return Dns.Resolve(remoteHost).AddressList[0];
			}
		}

		
		private String GetFileName(String line)
		{
			Match m;
			
			if ( ( m = MatchingListLine(line)) == null )
				return null;
			if ( m.Groups["dir"].Value != "" && m.Groups["dir"].Value != "-")  
				return null;
			else 
				return m.Groups["name"].Value;
		}
		
		private String GetFolderName(String line)
		{
			Match m;
			if ( ( m = MatchingListLine(line)) == null )
				return null;
			if ( m.Groups["dir"].Value != "" && m.Groups["dir"].Value != "-")  
				return m.Groups["name"].Value;
			return null;
		}

		
		private Match MatchingListLine(string line)
		{
			Match m;

			switch ( _serverOS )
			{
				case 1: // Unix
					m = _unixListLineExpression.Match(line);
					if ( m.Success )
						return m;
					m = _unixListLineExpression2.Match(line);
					if ( m.Success )
						return m;
					m = _unixListLineExpression1.Match(line);
					if ( m.Success )
						return m;
					return null;
				case 2: // windows
					m = _dosListLineExpression.Match(line);	
					if ( m.Success )
						return m;
					return null;
			}

			return null;			
		}

		#endregion

		#region TraceLog helpers

		private void OutputTraceLog(string message)
		{
			//Utility.WriteToTraceLog(message);
		}

		private void OutputTraceLog(string format, object arg0)
		{
			this.OutputTraceLog(format, arg0, null, null, null);
		}

		private void OutputTraceLog(string format, object arg0, object arg1)
		{
			this.OutputTraceLog(format, arg0, arg1, null, null);
		}

		private void OutputTraceLog(string format, object arg0, object arg1, object arg2)
		{
			this.OutputTraceLog(format, arg0, arg1, arg2, null);
		}

		private void OutputTraceLog(string format, object arg0, object arg1, object arg2, object arg3)
		{
			string message = string.Format(format, arg0, arg1, arg2, arg3);
			//Utility.WriteToTraceLog(message);
		}

		private void OutputTraceLog(Exception obj, string message)
		{
			//Utility.WriteToTraceLog(obj, message);
		}

		private void OutputDebugLog(string message)
		{
#if TRACE_DEBUG
			Utility.WriteToTraceLog(message);
#endif
		}

		private void OutputDebugLog(string format, object arg0)
		{
#if TRACE_DEBUG
			this.OutputDebugLog(format, arg0, null, null, null);
#endif
		}

		private void OutputDebugLog(string format, object arg0, object arg1)
		{
#if TRACE_DEBUG
			this.OutputDebugLog(format, arg0, arg1, null, null);
#endif
		}

		private void OutputDebugLog(string format, object arg0, object arg1, object arg2)
		{
#if TRACE_DEBUG
			this.OutputDebugLog(format, arg0, arg1, arg2, null);
#endif
		}

		private void OutputDebugLog(string format, object arg0, object arg1, object arg2, object arg3)
		{
#if TRACE_DEBUG
			string message = string.Format(format, arg0, arg1, arg2, arg3);
			Utility.WriteToTraceLog(message);
#endif
		}

		#endregion 

		#region Data Socket helpers

		/// <summary>
		/// The <b>CreateDataSocket</b> method open an existing port range from 1204 to 5000 on local machine.
		/// This method also call <b>SetDataPort</b> in order to request the remote host using the created port
		/// for transferring data. This type of connection is called Active Mode in FTP networking.
		/// </summary>
		/// <returns>True if succeeded, otherwise False</returns>
		private bool CreateDataSocket()
		{
			Socket socket = null; // data socket
			int port = GetPortNumber(); // number of port used for transferring data from server to local machine			
			int tryCount = 0; // number of times trying to open port specified by port number.
			int waitBetweenTry = 1000; // number of milliseconds wait between doing connection.
			IPEndPoint localEP = null; // local end point
			DateTime timeout = DateTime.Now.AddMinutes(5); // default time out is 15 second
			
			while (timeout > DateTime.Now)
			{
				try
				{
					// generates port number randomly
					//port = GetPortNumber();
					
					// create a local End Point
					localEP = new IPEndPoint(_localIP, port);
					
					// create a data socket and bind it to local End Point
					socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

					// set socket option to avoid exception Address in use. 
					// This exception occurs when we try to bind to port with state TIME_WAIT.
					//socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, 0);
					//socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, new LingerOption(true, 10));

					// set socket wait time out
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, DefaultWaitHandleTimeOut);
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, DefaultWaitHandleTimeOut);

					// bind end point
					socket.Bind(localEP);
					
					// place created socket in a listening state with maximum length of the pending connections queue.
					socket.Listen(100);

					// save created socket
					_acceptListener = socket;

					// do not need to try again
					break;
				}
				catch(SocketException se)
				{
					// save last error and message
					_lastError = string.Format("Cannot open port {0}. Reason : {1}. Error Code : {2}. Try count : {3}", port, se.Message, se.ErrorCode, ++tryCount);
					
					// release created socket
					if (socket != null)
						socket.Close();
					socket = null;

					// wait for 1 second before continuing because 
					// sometimes the remote server is disconnect or busy.
					System.Threading.Thread.Sleep(waitBetweenTry);

					// try the other port
					if ( port < DATA_PORT_RANGE_TO )
					{
						port++;
					}
					else
					{
						port = DATA_PORT_RANGE_FROM;
					}
				}
				catch (Exception exp)
				{
					// save last error and message
					_lastError = string.Format("Cannot open port {0}. Reason : {1}. Try count : {2}", port, exp.Message, ++tryCount);
					
					// release created socket
					if (socket != null)
						socket.Close();
					socket = null;

					// wait for 1 second before continuing because 
					// sometimes the remote server is disconnect or busy.
					System.Threading.Thread.Sleep(waitBetweenTry);

					// try the other port
					if ( port < DATA_PORT_RANGE_TO )
					{
						port++;
					}
					else
					{
						port = DATA_PORT_RANGE_FROM;
					}
				}
			}

			// check if data socket is created
			if (_acceptListener == null )
			{
				// output to trace log
				OutputTraceLog("FtpClient.CreateDataSocket : " + _lastError);

				return false;
			}

			// specifies the host and port to which the server should connect for the next file transfer
			if (SetDataPort(port) == false)
			{
				// close created data socket
				this.CloseDataSocket();

				return false;
			}

			return true;
		}

		private void CloseDataSocket()
		{
			if (_dataSocket != null )
			{
				_dataSocket.Close();
				_dataSocket = null;
			}

			if ( _acceptListener != null )
			{
				_acceptListener.Close();
				_acceptListener = null;
			}
		}

		private int GetPortNumber()
		{
			Random rnd = new Random((int)DateTime.Now.Ticks);
			return DATA_PORT_RANGE_FROM + rnd.Next(DATA_PORT_RANGE_TO - DATA_PORT_RANGE_FROM);
		}

		private bool SetDataPort(int port)
		{
			int portHigh = port >> 8;
			int portLow  = port & 255;

			try
			{
				if ( _remoteHost == "127.0.0.1" || _remoteHost.ToLower() == "localhost" )
					SendCommand("PORT 127,0,0,1," + portHigh.ToString() + "," + portLow);
				else
					SendCommand("PORT " + _localIP.ToString().Replace(".", ",") + "," + portHigh.ToString() + "," + portLow);
				
				if ( _resultCode != 200 )
				{
					_lastError = GetErrorMessage();
					
					OutputTraceLog("FtpClient.SetDataPort : " + _resultMessage);
					return false;
				}
				return true;
			}
			catch ( Exception exp )
			{
				_lastError = exp.Message;
				
				OutputTraceLog(exp, "FtpClient.SetDataPort");
				return false;
			}
		}

		#endregion

		#region Asysnchronous helpers

		private bool DoAcceptIncommingRequest()
		{
			if (_clientSocket == null)
				throw new System.ArgumentNullException("_clientSocket");

			Thread workerThread = null;

			try
			{
				// reset wait handle
				_acceptWaitHandle.Reset();

				// reset flags
				_acceptIncomingConnectionDone = false;

				// prepare buffer for receiving data
				this._message = "";
						
				// start workerThread to retrieve file list from server
				workerThread = new Thread(new ThreadStart(ThreadAcceptIncominRequest));
				workerThread.Name = "ThreadAcceptIncominRequest";
				workerThread.Start();

				// wait for incoming connection is accepted or time out
				bool isTimeOut = _acceptWaitHandle.WaitOne(DefaultAcceptIncommonConnectionTimeOut, false) == false;
				
				if (isTimeOut)
				{
					// save error message
					_lastError = "ThreadAcceptIncominRequest was time out.";

					// output to trace log
					OutputTraceLog("FtpClient.DoAcceptIncommingRequest : Cannot accept incomming request: Time-out.");
				}
			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog(exp.Message, "FtpClient.DoAcceptIncommingRequest : Unhanded exception.");
			}
			finally
			{
				if (workerThread != null)
				{
					if (workerThread.IsAlive)
					{
						// raise a ThreadAbortException in the workerThread which is invoked, 
						// to begin the process of terminating workerThread.
						workerThread.Abort();

						// wait for workerThread to shutdown
						if (!workerThread.Join(DefaultWaitHandleTimeOut))
							workerThread.Interrupt(); // force workerThread to shutdown
					}

					// release workerThread reference
					workerThread = null;
				}
			}

			return _acceptIncomingConnectionDone;
		}

		private bool DoGetFileList()
		{
			if (_acceptListener	== null)
				throw new System.ArgumentNullException("_acceptListner");
			if (_dataSocket	== null)
				throw new System.ArgumentNullException("_dataSocket");

			Thread workerThread = null;

			try
			{
				// reset wait handle
				_getFileListWaitHandle.Reset();

				// reset flags
				_getFileListDone = false;

				// prepare buffer for receiving data
				this._message = "";
					
			
				// start workerThread to retrieve file list from server
				workerThread = new Thread(new ThreadStart(ThreadGetFileList));
				workerThread.Name = "ThreadGetFileList";
				workerThread.Start();

				// wait for data downloaded or time out
				bool isTimeOut = _getFileListWaitHandle.WaitOne(DefaultWaitHandleTimeOut, false) == false;

				if (isTimeOut)
				{
					// save error message
					_lastError = "ThreadGetFileList was time out.";

					// output to trace log
					OutputTraceLog("FtpClient.DoGetFileList : Cannot get the file list: Time-out.");
				}
			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog(exp.Message, "FtpClient.DoGetFileList : Unhanded exception.");
			}
			finally
			{
				if (workerThread != null)
				{
					if (workerThread.IsAlive)
					{
						// raise a ThreadAbortException in the workerThread which is invoked, 
						// to begin the process of terminating workerThread.
						workerThread.Abort();

						// wait for workerThread to shutdown
						if (!workerThread.Join(DefaultWaitHandleTimeOut))
							workerThread.Interrupt(); // force workerThread to shutdown
					}

					// release workerThread reference
					workerThread = null;
				}
			}

			return _getFileListDone;
		}

		private bool DoDownloadFile(string remoteFile)
		{
			if (_acceptListener	== null)
				throw new System.ArgumentNullException("_acceptListner");
			if (_dataSocket	== null)
				throw new System.ArgumentNullException("_dataSocket");

			Thread workerThread = null;

			try
			{
				// reset wait handle
				_downloadFileWaitHandle.Reset();

				// reset flags
				_downloadDone = false;

				// prepare arguments for downloading data
				this._message = "";
				this._isDownloading = true;
				this._memory = new MemoryStream();
									
				// start workerThread to download file from server
				workerThread = new Thread(new ThreadStart(ThreadDownloadFile));
				workerThread.Name = "ThreadDownloadFile";			
				workerThread.Start();

				// wait for data is downloaded or time out
				bool isTimeOut = _downloadFileWaitHandle.WaitOne(DefaultWaitHandleTimeOut, false) == false;

				if (isTimeOut)
				{
					// save error message
					_lastError = "ThreadDownloadFile was time out.";

					// output to trace log
					OutputTraceLog("FtpClient.DoDownloadFile : Cannot download file. Time-out.");
				}
			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog(exp.Message, "FtpClient.DoDownloadFile : Unhanded exception.");
			}
			finally
			{
				if (workerThread != null)
				{
					if (workerThread.IsAlive)
					{
						// raise a ThreadAbortException in the workerThread which is invoked, 
						// to begin the process of terminating workerThread.
						workerThread.Abort();

						// wait for workerThread to shutdown
						if (!workerThread.Join(DefaultWaitHandleTimeOut))
							workerThread.Interrupt(); // force workerThread to shutdown
					}

					// release workerThread reference
					workerThread = null;
				}
			}

			return _downloadDone;
		}

		private bool DoUploadFile(string localFile)
		{
			if (_acceptListener	== null)
				throw new System.ArgumentNullException("_acceptListner");
			if (_dataSocket	== null)
				throw new System.ArgumentNullException("_dataSocket");

			Thread workerThread = null;

			try
			{
				// prepare arguments for downloading data
				if (_stream != null)
					_stream.Close();
				_stream = File.Open(localFile, FileMode.Open, FileAccess.Read, FileShare.Read);
									
				// reset wait handle
				_uploadFileWaitHandle.Reset();

				// reset flags
				_uploadDone = false;

				// start workerThread to upload data to server
				workerThread = new Thread(new ThreadStart(ThreadUploadFile));
				workerThread.Name = "ThreadUploadFile";			
				workerThread.Start();

				// wait for data is uploaded to remote server or timeout
				bool isTimeOut = _uploadFileWaitHandle.WaitOne(DefaultWaitHandleTimeOut, false) == false;

				if (isTimeOut && workerThread.IsAlive)
				{
					// raise a ThreadAbortException in the workerThread which is invoked, 
					// to begin the process of terminating workerThread.
					workerThread.Abort();

					// wait for workerThread to shutdown
					if (!workerThread.Join(DefaultWaitHandleTimeOut))
						workerThread.Interrupt(); // force workerThread to shutdown
				
					// save error message
					_lastError = "ThreadUploadFile was time out.";

					// output to trace log
					OutputTraceLog("FtpClient.DoUploadFile : Cannot upload file. Time-out.");
				}

				// release workerThread reference
				workerThread = null;

			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog(exp.Message, "FtpClient.DoUploadFile : Unhanded exception.");
			}
			finally
			{
				if (workerThread != null)
				{
					if (workerThread.IsAlive)
					{
						// raise a ThreadAbortException in the workerThread which is invoked, 
						// to begin the process of terminating workerThread.
						workerThread.Abort();

						// wait for workerThread to shutdown
						if (!workerThread.Join(DefaultWaitHandleTimeOut))
							workerThread.Interrupt(); // force workerThread to shutdown
					}

					// release workerThread reference
					workerThread = null;
				}

				if (_stream != null)
					_stream.Close();
				_stream = null;
			}

			return _uploadDone;
		}

		/// <summary>
		/// The <b>DoReadLine</b> method reads a message sent from remote host line by line
		/// </summary>
		/// <returns>The message sent from the remote host.</returns>
		private string DoReadLine()
		{
			if (_clientSocket == null)
				throw new System.ArgumentNullException("_clientSocket");

			Thread workerThread = null;
			
			try
			{
				// reset wait handle
				_readLineWaitHandle.Reset();

				// reset flags
				_readLineCallbackDone = false;

				// prepare buffer for receiving data
				this._message = "";
						
				// start workerThread to read data from server
				workerThread = new Thread(new ThreadStart(ThreadReadLine));
				workerThread.Name = "ThreadReadLine";
				workerThread.Start();

				// wait for the data is read or time out
				bool isTimeOut = _readLineWaitHandle.WaitOne(DefaultWaitHandleTimeOut, false) == false;

				// check whether the operation is time-out
				if (isTimeOut)
				{
					// save error message
					_lastError = "ThreadReadLine was time out.";

					// output to trace log
					OutputTraceLog("FtpClient.DoReadLine : Cannot wait until receive responses from server. Time-out.");
				}
			}
			catch (System.Exception exp)
			{
				// output to trace log
				OutputTraceLog(exp.Message, "FtpClient.DoReadLine : Unhanded exception.");
			}
			finally
			{
				if (workerThread != null)
				{
					if (workerThread.IsAlive)
					{
						// raise a ThreadAbortException in the workerThread which is invoked, 
						// to begin the process of terminating workerThread.
						workerThread.Abort();

						// wait for workerThread to shutdown
						if (!workerThread.Join(DefaultWaitHandleTimeOut))
							workerThread.Interrupt(); // force workerThread to shutdown
					}

					// release workerThread reference
					workerThread = null;
				}
			}

			if (_readLineCallbackDone)
				return _message;
			return "";
		}


		#region Thread helpers
		
		/// <summary>
		/// The method <b>ThreadAcceptIncominRequest</b> calls method Accept of an existed socket object 
		/// to accept incoming connection attempt.
		/// </summary>
		private void ThreadAcceptIncominRequest()
		{
			if (_acceptListener == null)
				throw new ArgumentNullException("_clientSocket");
			
			try
			{		
				// accept incoming connection attempt
				_dataSocket = this._acceptListener.Accept();

				// signal finished flag
				_acceptIncomingConnectionDone = true;
			}
			catch (System.Threading.ThreadAbortException exp) // thread was aborted
			{
				// save last error message
				_lastError = exp.Message;

				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadAcceptIncominRequest: Thread was aborted.");
			}
			catch (System.Exception exp) // an generic exception occurred
			{
				// save last error message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadAcceptIncominRequest");
			}
			finally
			{
				// signal wait handle
				_acceptWaitHandle.Set();
			}
		}
		
		/// <summary>
		/// The method <b>ThreadGetFileList</b> calls method Received of an existed socket object 
		/// to receive data transfered from remote server.
		/// </summary>
		private void ThreadGetFileList()
		{
			if (_dataSocket == null)
				throw new ArgumentNullException("_dataSocket");
			
			long totalBytes = 0; // number of bytes downloaded
			
			try
			{				
				int bytes = 0; // number of byte received every call to Socket.Receive
				_message = "";

				do
				{
					bytes = _dataSocket.Receive(_buffer);
					if (bytes > 0)
						_message += Encoding.ASCII.GetString(_buffer, 0, bytes);
					totalBytes += bytes;
				} 
				while (bytes > 0);

				// signal finished flag
				_getFileListDone = true;
			}
			catch (System.Threading.ThreadAbortException exp) // thread was aborted
			{
				// save last error message
				_lastError = exp.Message;

				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadGetFileList: Thread was aborted at " + totalBytes + " bytes downloaded.");
			}
			catch (System.Exception exp) // an generic exception occurred
			{
				// save last error message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadGetFileList:");
			}
			finally
			{
				// signal wait handle
				_getFileListWaitHandle.Set();
			}
		}

		/// <summary>
		/// The method <b>ThreadDownloadFile</b> calls method Received of an existed socket object 
		/// to receive data transfered from remote server.
		/// </summary>
		private void ThreadDownloadFile()
		{
			if (_dataSocket == null)
				throw new ArgumentNullException("_dataSocket");
			if (_memory == null)
				throw new ArgumentException("Memory stream was not created", "_memory");

			long totalBytes = 0; // number of bytes downloaded
			
			try
			{				
				int bytes = 0; // number of byte received every call to Socket.Receive
				
				do
				{
					bytes = _dataSocket.Receive(_buffer);
					if (bytes > 0)
						_memory.Write(_buffer, 0, bytes);						
					totalBytes += bytes;
				} 
				while (bytes > 0);

				// signal finished flag
				_downloadDone = true;
			}
			catch (System.Threading.ThreadAbortException exp) // thread was aborted
			{
				// save last error message
				_lastError = exp.Message;

				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadDownloadFile: Thread was aborted at " + totalBytes + " bytes downloaded.");
			}
			catch (System.Exception exp) // an generic exception occurred
			{
				// save last error message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadGetFileList:");
			}
			finally
			{
				// signal wait handle
				_downloadFileWaitHandle.Set();
			}
		}

		/// <summary>
		/// The method <b>ThreadUploadFile</b> calls method Received of an existed socket object 
		/// to receive data transfered from remote server.
		/// </summary>
		private void ThreadUploadFile()
		{
			if (_dataSocket == null)
				throw new ArgumentNullException("_dataSocket");
			if (_stream == null)
				throw new ArgumentNullException("Local file was not specified", "_stream");
			if (_stream.CanRead == false)
				throw new ArgumentException("Local file cannot be read", "_stream");

			long totalBytes = 0; // number of bytes uploaded
			
			try
			{				
				int bytes = 0; // number of byte received every call to Socket.Receive
				int sentBytes = 0;
				
				do
				{
					bytes = _stream.Read(_buffer, 0, _buffer.Length);
					if (bytes > 0)
						sentBytes = _dataSocket.Send(_buffer, 0, bytes, SocketFlags.None);
					totalBytes += sentBytes;
				} 
				while (bytes > 0);

				// signal finished flag
				_uploadDone = true;
			}
			catch (System.Threading.ThreadAbortException exp) // thread was aborted
			{
				// save last error message
				_lastError = exp.Message;

				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadDownloadFile: Thread was aborted at " + totalBytes + " bytes downloaded.");
			}
			catch (System.Exception exp) // an generic exception occurred
			{
				// save last error message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadGetFileList:");
			}
			finally
			{
				// signal wait handle
				_uploadFileWaitHandle.Set();
			}
		}

		/// <summary>
		/// The method <b>ThreadReadLine</b> calls method Receive of _clientSocket instance
		/// to receive data sent from the remote server
		/// </summary>
		private void ThreadReadLine()
		{
			if (_clientSocket == null)
				throw new ArgumentNullException("_clientSocket");
			
			int bufSize = 128;
			byte[] localBuffer = new byte[bufSize];
			string strBuffer = "";
			string totalMessages = "";

			try
			{		
				bool isDone = false;

				while (!isDone)
				{
					// retrieve data from remote server
					int bytesRead = this._clientSocket.Receive(localBuffer);
					// parse raw data
					string str = Encoding.ASCII.GetString(localBuffer, 0, bytesRead);
					// append to string buffer
					strBuffer += str;
					totalMessages += str;
					
					// if received message is contain line separator
					if (strBuffer.IndexOf("\r\n") > 0)
					{
						try
						{
							// split into lines
							String[] lines = strBuffer.Split('\n');

							// remove first string
							int index = strBuffer.IndexOf("\r\n");
							strBuffer = strBuffer.Remove(0, index+"\r\n".Length);
						
							// get the last string of return message
							if (lines.Length > 2)
							{
								_message = lines[lines.Length - 2];
							}
							else
							{
								_message = lines[0];							
							}

							// check if all return message has come
							string code = _message.Substring(3, 1);
							if (_message.Length <= 4 || code.Equals(" "))
								isDone = true;

							// clean up data, this is so strict !!!!
							str = null;
							for (int i = 0; i < lines.Length; i++)
								lines[i] = null;
							lines = null;
						}
						catch
						{
							// output temporary data into TraceLog
							OutputTraceLog("TotalMessages:\"" + totalMessages + "\"", "FtpClient.ThreadReadLine: Generic Exception occurred.");

							throw;
						}
						finally
						{
						}
					}
				}

				// signal finished flag
				_readLineCallbackDone = true;
			}
			catch (System.Threading.ThreadAbortException exp) // thread was aborted
			{
				// save last error message
				_lastError = exp.Message;

				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadReadLine: Thread was aborted.");
			}
			catch (System.Exception exp) // an generic exception occurred
			{
				// save last error message
				_lastError = exp.Message;
				
				// output to trace log
				OutputTraceLog(exp, "FtpClient.ThreadReadLine");
			}
			finally
			{
				// signal wait handle
				_readLineWaitHandle.Set();
			}
		}
		#endregion

		#endregion

		#endregion
	}
}
