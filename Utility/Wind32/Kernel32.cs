using System;
using System.Text;
using System.Runtime.InteropServices;

namespace SiGlaz.Utility.Wind32
{
	/// <summary>
	/// Summary description for Kernel32.
	/// </summary>
	public class Kernel32
	{
		public Kernel32()
		{
		}

		public static string GetLastErrorString()
		{
			// from header files
			const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
			const uint FORMAT_MESSAGE_IGNORE_INSERTS  = 0x00000200;
			const uint FORMAT_MESSAGE_FROM_SYSTEM    = 0x00001000;

			int nLastError= GetLastError();

			IntPtr lpMsgBuf= IntPtr.Zero;

			uint dwChars= FormatMessage(
				FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
				IntPtr.Zero,
				(uint)nLastError,
				0, // Default language
				ref lpMsgBuf,
				0,
				IntPtr.Zero);
			if (dwChars==0)
			{
				// Handle the error.
				int le= Marshal.GetLastWin32Error();
				return null;
			}

			string sRet= Marshal.PtrToStringAnsi(lpMsgBuf);

			// Free the buffer.
			lpMsgBuf= LocalFree( lpMsgBuf );

			return sRet;
		}
									   
		[DllImport("kernel32.dll")]
		static extern IntPtr LocalFree(IntPtr lpMsgBuf);

		[DllImport("kernel32.dll")]
		static extern uint FormatMessage(uint dwFlags, IntPtr lpSource,
			uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer,
			uint nSize, IntPtr Arguments);

		// the version, the sample is built upon:
		[DllImport("Kernel32.dll", SetLastError=true)]
		static extern uint FormatMessage( uint dwFlags, IntPtr lpSource,
			uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
			uint nSize, IntPtr pArguments);

		// the parameters can also be passed as a string array:
		[DllImport("Kernel32.dll", SetLastError=true)]
		static extern uint FormatMessage( uint dwFlags, IntPtr lpSource,
			uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
			uint nSize, string[] Arguments);


		[DllImport("kernel32")]
		public static extern  int GetLastError();


		[DllImport("kernel32")]
		public static extern  IntPtr CreateEvent(
			IntPtr lpEventAttributes,
			bool bManualReset,
			bool bInitialState,
			String lpName
			);

		[DllImport("kernel32")]
		public static extern  IntPtr OpenEvent(
			int dwDesiredAccess,
			bool bInheritHandle,
			String lpName
			);

		[DllImport("kernel32")]
		public static extern  		bool ResetEvent(
			IntPtr hEvent
			);

		[DllImport("kernel32")]
		public static extern  		bool SetEvent(
			IntPtr hEvent
			);

		[DllImport("kernel32")]
		public static extern  		int WaitForSingleObject(
			IntPtr hHandle,
			int dwMilliseconds
			);

		[DllImport("Kernel32.dll", SetLastError=true)]
		public static extern bool CloseHandle(IntPtr handle);


		[DllImport("advapi32.dll", SetLastError=true)]
		public static extern bool SetSecurityDescriptorDacl(ref SECURITY_DESCRIPTOR securityDescriptor, bool daclPresent, IntPtr dacl, bool daclDefaulted);

		[DllImport("advapi32.dll", SetLastError=true)]
		public static extern bool InitializeSecurityDescriptor(out SECURITY_DESCRIPTOR securityDescriptor, uint dwRevision);


		[StructLayoutAttribute(LayoutKind.Sequential)]
			public struct SECURITY_DESCRIPTOR 
		{
			public byte revision;
			public byte size;
			public short control;
			public IntPtr owner;
			public IntPtr group;
			public IntPtr sacl;
			public IntPtr dacl;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct SECURITY_ATTRIBUTES
		{
			public int nLength;
			public IntPtr lpSecurityDescriptor;
			public int bInheritHandle;
		}

		

	}
}
