using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Product
	{
		public		int			ProductKey =-1;
		public		string		ProductCode;
		public		string		Prod_Class;

		public Product()
		{
		
		}

		public Product(string productCode):this()
		{
			this.ProductCode   = productCode;
		}

		public Product(int productKey,string productCode,string Prod_Class):this()
		{
			this.ProductKey = productKey;
			this.ProductCode   = productCode;
			this.Prod_Class = Prod_Class;
		}

	
	}
}
