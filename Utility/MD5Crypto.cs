using System;
using System.Security.Cryptography;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for MD5Crypto.
	/// </summary>
	public class MD5Crypto
	{
		/// <summary>
		/// Convert byte's array to hex's string
		/// </summary>
		/// <param name="hashValue">Byte's array</param>
		/// <returns>hex's string</returns>
		private static string HashToString(byte[] hashValue)
		{
			string strHex = string.Empty;

			foreach ( byte b in hashValue ) 
			{
				strHex += string.Format("{0:x2}", b);
			}

			return strHex;
		}

		/// <summary>
		/// Encrypt input string with md5 algorithm
		/// </summary>
		/// <param name="inputString">string to be encrypted</param>
		/// <returns>Encrypted string</returns>
		public static string GetMD5(string inputString)
		{
			System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
			
			byte[] data = encoding.GetBytes(inputString);

			MD5 md5 =  new MD5CryptoServiceProvider();
			
			return HashToString(md5.ComputeHash(data));
		}
	}
}
