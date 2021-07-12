using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Data;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for RecipeResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class RecipeListResult : Error
	{
		[XmlElement(typeof(DDARecipe))]
		public ArrayList Recipes = new ArrayList();

		public RecipeListResult()
		{
		}
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class SignatureListResult : Error
	{
		[XmlElement(typeof(SiGlaz.Common.DDA.Signature))]
		public ArrayList signature = new ArrayList();

		public SignatureListResult()
		{
		}

	}
}
