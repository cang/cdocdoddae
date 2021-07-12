using System;
using System.Collections;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Grade.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Grade
	{
		public int			Gradekey;
		public int			GradeID;
		public string		GradeDescription = string.Empty;
		public ArrayList	SignatureKeyList = new ArrayList();
		
		public Grade()
		{
		}
	}
}
