using System;
using System.IO;

namespace DataInstaller
{
	public class ProductSecurity
	{
		public ProductSecurity()
		{
		}

		public static void	 DeployProduct(string sourcefile,string desfile)
		{
			if( !File.Exists(sourcefile) ) return;
			if( !SiGlaz.Common.Configuration.LoadData(sourcefile) )  return;

			string lisenceto=SiGlaz.Common.Configuration.GetValues("LICENSETO","").ToString();
			string siglazProcudtID=SiGlaz.Common.Configuration.GetValues("SIGLAZPRODUCTID","").ToString();

			if( File.Exists(desfile) )
			{
				try
				{
					SiGlaz.Common.Configuration.LoadData(desfile);
				}
				catch{}
			}
			else
				SiGlaz.Common.Configuration._data.Clear();

			SiGlaz.Common.Configuration.SetValues("LICENSETO",lisenceto);
			SiGlaz.Common.Configuration.SetValues("SIGLAZPRODUCTID",siglazProcudtID);
			try
			{
				SiGlaz.Common.Configuration.SaveData(desfile);
				//SiGlaz.Common.Configuration.CreateIDAHierachiverFolder();
			}
			catch{}
		}

		public static string GenProductID()
		{
			string sbase="0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ";//abcdefghijklmnopqrstuvxyz";
			//8-4-4-4-12
			Random rnd=new Random();

			string sgen="";
			for(int i=0;i<8;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<12;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];

			return sgen;
		}

		public static string GetProductID(string filename)
		{
			if( !SiGlaz.Common.Configuration.LoadData(filename) )  return "";
			string siglazProcudtID=SiGlaz.Common.Configuration.GetValues("SIGLAZPRODUCTID","").ToString();

			RijndaelCrypto crypto = new RijndaelCrypto();
			if(siglazProcudtID=="")
				siglazProcudtID=GenProductID();
			else
				siglazProcudtID=crypto.Decrypt(siglazProcudtID);

			return siglazProcudtID;
		}

		public static string GetLicenseTo(string filename)
		{
			if( !SiGlaz.Common.Configuration.LoadData(filename) )  return "";
			string lisenceto=SiGlaz.Common.Configuration.GetValues("LICENSETO","").ToString();

			RijndaelCrypto crypto = new RijndaelCrypto();
			if(lisenceto=="")
				lisenceto="Evaluation";
			else
				lisenceto=crypto.Decrypt(lisenceto);

			return lisenceto;
		}
		public static void	 DeployProduct(string desfile,string productid,string licenseto)
		{
			if( File.Exists(desfile) )
			{
				try
				{
					SiGlaz.Common.Configuration.LoadData(desfile);
				}
				catch{}
			}

			RijndaelCrypto crypto = new RijndaelCrypto();
			licenseto=crypto.Encrypt(licenseto);
			SiGlaz.Common.Configuration.SetValues("LICENSETO",licenseto);

			productid=crypto.Encrypt(productid);
			SiGlaz.Common.Configuration.SetValues("SIGLAZPRODUCTID",productid);

			try
			{
				SiGlaz.Common.Configuration.SaveData(desfile);
				//SiGlaz.Common.Configuration.CreateIDAHierachiverFolder();
			}
			catch{}

		}
	}
}
