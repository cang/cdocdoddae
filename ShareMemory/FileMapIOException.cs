using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SiGlaz.IO.FileMap
{

   /// <summary>Exception class thrown by the library</summary>
   /// <remarks>
   ///   Represents an exception occured as a result of an
   ///   invalid IO operation on any of the File mapping classes
   ///   It wraps the error message and the underlying Win32 error
   ///   code that caused the error.
   /// </remarks>
   // TODO: Make Serializable!
   public class FileMapIOException : IOException
   {
      //
      // properties
      //
      private int m_win32Error = 0;
      public int Win32ErrorCode
      {
         get { return m_win32Error; }
      }
      public override string Message
      {
         get 
         {
            if ( Win32ErrorCode != 0 )
               return base.Message + " (" + Win32ErrorCode + ")";
            else
               return base.Message;
         }
      }

      // construction
      public FileMapIOException ( int error ) : base()
      {
         m_win32Error = error;
      }
      public FileMapIOException ( string message ) : base(message)
      {
      }
      public FileMapIOException ( string message, Exception innerException ) 
               : base(message, innerException)
      {
      }

   } // class FileMapIOException


} // namespace SiGlaz.IO.FileMap
