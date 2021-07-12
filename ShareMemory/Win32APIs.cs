using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SiGlaz.IO.FileMap
{

   /// <summary>Win32 APIs used by the library</summary>
   /// <remarks>
   ///   Defines the PInvoke functions we use
   ///   to access the FileMapping Win32 APIs
   /// </remarks>
   internal class Win32MapApis
   {
      [ DllImport("kernel32", SetLastError=true, CharSet=CharSet.Auto) ]
      public static extern IntPtr CreateFile ( 
         String lpFileName, int dwDesiredAccess, int dwShareMode,
         IntPtr lpSecurityAttributes, int dwCreationDisposition,
         int dwFlagsAndAttributes, IntPtr hTemplateFile );

      [ DllImport("kernel32", SetLastError=true, CharSet=CharSet.Auto) ]
      public static extern IntPtr CreateFileMapping ( 
         IntPtr hFile, IntPtr lpAttributes, int flProtect, 
         int dwMaximumSizeLow, int dwMaximumSizeHigh,
         String lpName );

      [ DllImport("kernel32", SetLastError=true) ]
      public static extern bool FlushViewOfFile ( 
         IntPtr lpBaseAddress, int dwNumBytesToFlush );

      [ DllImport("kernel32", SetLastError=true) ]
      public static extern IntPtr MapViewOfFile (
         IntPtr hFileMappingObject, int dwDesiredAccess, int dwFileOffsetHigh,
         int dwFileOffsetLow, int dwNumBytesToMap );

      [ DllImport("kernel32", SetLastError=true, CharSet=CharSet.Auto) ]
      public static extern IntPtr OpenFileMapping (
         int dwDesiredAccess, bool bInheritHandle, String lpName );

      [ DllImport("kernel32", SetLastError=true) ]
      public static extern bool UnmapViewOfFile ( IntPtr lpBaseAddress );

      [ DllImport("kernel32", SetLastError=true) ]
      public static extern bool CloseHandle ( IntPtr handle );

   } // class Win32MapApis

} // namespace SiGlaz.IO.FileMap
