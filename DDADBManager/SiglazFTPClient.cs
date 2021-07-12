using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SiglazFTPClient
{
    public class SiglazFTPClient
    {
        public SiglazFTPClient()
        {
            //throw new Exception("No Support FTP");
        }

        public SiglazFTPClient(string server,int port,string username,string password)
        {
            //throw new Exception("No Support FTP");
        }

        public bool DeleteFile(string path)
        {
            throw new Exception("No Support FTP");
        }

        public void GetLastError(ref object lastErrorObject, ref string lastErrorString)
        {
            throw new Exception("No Support FTP");
        }

        public ArrayList GetListFiles(string remotedir, bool subFolder)
        {
            throw new Exception("No Support FTP");
        }

        public bool DownloadFile(string fileName, string temporaryFilename)
        {
            throw new Exception("No Support FTP");
        }
    }
}
