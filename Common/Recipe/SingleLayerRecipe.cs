using System;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Basic;

namespace SiGlaz.Common.DDA.Recipe
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class SingleLayerRecipe : DataSourceRecipe
	{
		#region Constructor
		public SingleLayerRecipe() : base()
	{
	}
		#endregion
	}
}
