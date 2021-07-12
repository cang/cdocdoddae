using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class DiskSize
	{
		public		int			DiskSizeKey =-1;
		public		string		Prod_Class = string.Empty;
		public		double		InnerDiameter;
		public		double		OuterDiameter;

		public DiskSize()
		{
		
		}

		public DiskSize(string prod_class,double id,double od):this()
		{
			this.Prod_Class  = prod_class;
			this.InnerDiameter = id;
			this.OuterDiameter = od;
		}

		public DiskSize(int key,string prod_class,double id,double od):this()
		{
			this.DiskSizeKey = key;
			this.Prod_Class  = prod_class;
			this.InnerDiameter = id;
			this.OuterDiameter = od;
		}
	}



	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class ProductDiskSize
	{
		public		int			DiskSizeKey = -1;
		public		string		Prod_Class = string.Empty;
		public		string		ProductCode = string.Empty;
		public		double		InnerDiameter;
		public		double		OuterDiameter;

		public ProductDiskSize()
		{
		
		}

		public ProductDiskSize(int key,string prod_class,string productcode,double id,double od):this()
		{
			this.DiskSizeKey = key;
			this.Prod_Class  = prod_class;
			this.ProductCode  = productcode;
			this.InnerDiameter = id;
			this.OuterDiameter = od;
		}
	}
}
