using System;
using System.Xml.Serialization;
using SiGlaz.Common.DDA;


namespace SiGlaz.Common.DDA.Basic
{
	[XmlRootAttribute("CategoryUnit")]
	public class CategoryAxis
	{
		#region Members
		private CategoryAxisUnit _unit;
		private int _groupUnit = 1;
		#endregion

		#region Constructor & Destructor 
		public CategoryAxis()
		{
			_unit = CategoryAxisUnit.Hour;
			_groupUnit = 4;
		}
		#endregion
	
		#region Properties

		[XmlElement("Unit", typeof(CategoryAxisUnit))]
		public CategoryAxisUnit Unit
		{
			get { return _unit; }
			set { _unit = value; }
		}

		[XmlElement("GroupUnit", typeof(int))]
		public int GroupUnit
		{
			get { return _groupUnit; }
			set { _groupUnit = value; }
		}

		#endregion
	}
}
