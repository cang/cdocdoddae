using System;
using System.Xml.Serialization;
using SiGlaz.Common.DDA;

namespace SiGlaz.Common.DDA.Basic
{
	[XmlRootAttribute("ValueAxis")]
	public class ValueAxis
	{
		#region Members
		private ValueAxisUnit _unit;
		#endregion

		#region Constructor & Destructor 
		public ValueAxis()
		{
			_unit = ValueAxisUnit.Yield;
		}
		#endregion
	
		#region Properties

		[XmlElement("Unit", typeof(ValueAxisUnit))]
		public ValueAxisUnit Unit
		{
			get { return _unit; }
			set { _unit = value; }
		}
		#endregion
	}
}
