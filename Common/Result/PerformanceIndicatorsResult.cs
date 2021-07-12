using System;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA;

namespace SiGlaz.Common.DDA.Result
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://siglaz.com")]
	public class PerformanceIndicatorsResult : YieldTrendPlotResult
	{
		#region Constructor
		public PerformanceIndicatorsResult() : base()
		{

		}
		#endregion
	}
}
