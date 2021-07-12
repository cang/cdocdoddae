using System;
using System.Data;
using System.Collections;
using System.IO;
using SiGlaz.Common.DDA;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for StaticFunction.
	/// </summary>
	public class DDAExternalData
	{
		public static string AppDataPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"App.config");

		public static FPPCommon.ProductConfiguration	ProductConfiguration
		{
			get
			{
				//RefreshDiskType();
				return FPPCommon.Configuration.Products;
			}
			set
			{
				FPPCommon.Configuration.Products = value;
			}
		}

		public static bool LoadApplicationDataFromFile()
		{
			if (File.Exists(AppDataPath))
			{
				SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDAExternalData");

				try
				{
					lck.WaitOne();
					AppData.Data.LoadApplicationData(AppDataPath);
				}
				catch
				{
					return false;
				}
				finally
				{
					lck.Release();
					lck.Dispose();
				}
			}
			return true;
		}

		public static bool LoadApplicationDataFromDatabase()
		{
			if( !RefreshDiskType() )
				return false;

			if( !CheckFab())
				return false;

			WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
			object rv = cmd.ApplicationDataGetValue(DDAConst.AllowMultiApplicationServer);
			if( rv == null ) 
			{
				AppData.Data.AllowMultiApplicationServer = false;
			}
			else
			{
				AppData.Data.AllowMultiApplicationServer = rv.ToString().ToLower() == "true";
			}

			return true;
		}

		public static bool LoadApplicationData()
		{
			if(!LoadApplicationDataFromFile()) return false;
			return LoadApplicationDataFromDatabase();
		}

		public static void SaveApplicationData()
		{
			SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock("DDAExternalData");

			try
			{
				lck.WaitOne();
				AppData.Data.SaveApplicationData(AppDataPath);
			}
			catch
			{
			}
			finally
			{
				lck.Release();
				lck.Dispose();
			}
		}

		public static bool CheckFab()
		{
			try
			{
				if( SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.WebProxyFactory.eMessageType oldstate = WebServiceProxy.WebProxyFactory.MessageType;
					WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.None;

					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();

					if(proxy!=null)
					{
						if( !proxy.FabExist(AppData.Data.FabKey) )
							AppData.Data.FabKey = 0;
					}

					WebServiceProxy.WebProxyFactory.MessageType = oldstate;
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					if( !proxy.FabExist(AppData.Data.FabKey) )
						AppData.Data.FabKey = 0;
				}

				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}
		
		private static bool LoadDiskType()
		{
			//if(!DiskTypeUpdate) return;

			//Load from web service or database
			try
			{
				if( SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.WebProxyFactory.eMessageType oldstate = WebServiceProxy.WebProxyFactory.MessageType;
					WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.None;
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();

					if(proxy!=null)
					{
						object[] resultlist = proxy.ProductDiskSizesList();
						if(resultlist!=null && resultlist.Length>0)
						{
							FPPCommon.ProductConfiguration products = new FPPCommon.ProductConfiguration(false);
							foreach(WebServiceProxy.CategoryProxy.ProductDiskSize obj in resultlist)
							{
								products.Data.Add(new FPPCommon.ProductItem(obj.ProductCode,(float)obj.InnerDiameter,(float)obj.OuterDiameter));
							}
							ProductConfiguration = products;
						}
					}

					WebServiceProxy.WebProxyFactory.MessageType = oldstate;
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					ArrayList resultlist = proxy.ProductDiskSizesList();
					if(resultlist!=null && resultlist.Count>0)
					{
						FPPCommon.ProductConfiguration products = new FPPCommon.ProductConfiguration(false);
						foreach(SiGlaz.Common.DDA.ProductDiskSize obj in resultlist)
						{
							products.Data.Add(new FPPCommon.ProductItem(obj.ProductCode,(float)obj.InnerDiameter,(float)obj.OuterDiameter));
						}
						ProductConfiguration = products;
					}
				}

				ProductConfiguration.Data.UseWildcard  = false;
				
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}


		public static DateTime	DiskTypeTableLastDate = DateTime.MinValue;
		public static bool		DiskTypeUpdate = false;

		public static bool RefreshDiskType()
		{
			return LoadDiskType();
//			try
//			{
//				if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
//				{
//					WebServiceProxy.WebProxyFactory.eMessageType oldstate = WebServiceProxy.WebProxyFactory.MessageType;
//					WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.None;
//					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
//					if(proxy!=null)
//					{
//						DateTime dtLast = proxy.GetLastUpdateOfDiskSize();
//						DiskTypeUpdate = dtLast > DiskTypeTableLastDate;
//						if(DiskTypeUpdate)
//							DiskTypeTableLastDate = dtLast;
//					}
//					WebServiceProxy.WebProxyFactory.MessageType = oldstate;
//				}
//				else
//				{
//					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
//					
//					DateTime dtLast = proxy.GetLastUpdateOfDiskSize();
//					DiskTypeUpdate = dtLast > DiskTypeTableLastDate;
//					if(DiskTypeUpdate)
//						DiskTypeTableLastDate = dtLast;
//				}
//
//				//Load 
//				if(DiskTypeUpdate)
//				{
//					LoadDiskType();
//				}
//			}
//			catch
//			{
//			}
//			finally
//			{
//				DiskTypeUpdate = false;
//			}
		}


	}
}
