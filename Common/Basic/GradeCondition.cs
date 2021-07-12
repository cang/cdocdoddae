using System;

namespace SiGlaz.Common.DDA.Basic
{
	/// <summary>
	/// Summary description for GradeCondtion.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	[Serializable]
	public class GradeCondition
	{
		public TimeFilter	fromDateTime = null;
		public int			ProcessPercent =0;
		public string		ListGradeString = string.Empty;

		public GradeCondition()
		{
		}

	}
}
