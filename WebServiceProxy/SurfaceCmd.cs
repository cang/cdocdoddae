using System;
using SiGlaz.Common;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for CategoryProxy.
	/// </summary>
	public class SurfaceCmd
	{	
		WebServiceProxy.SurfaceProxy.Surface proxy;
		SiGlaz.DDA.Business.Surface bussobject;

		public SurfaceCmd()
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				proxy = WebProxyFactory.CreateSurface();
			else
				bussobject = new SiGlaz.DDA.Business.Surface();
		}

		public ResultBase Processed_Insert(int recipekey,long surfacekey,bool BreakWhenFound,bool finish)
		{
			if(bussobject!=null)
				return bussobject.Processed_Insert(recipekey,surfacekey,BreakWhenFound,finish);
		
			return ConvertProxy.Convert(proxy.Processed_Insert(recipekey,surfacekey,BreakWhenFound,finish),typeof(ResultBase)) as ResultBase;
		}

		public ResultBase Processed_Delete(int recipekey,long surfacekey)
		{
			if(bussobject!=null)
				return bussobject.Processed_Delete(recipekey,surfacekey);
		
			return ConvertProxy.Convert(proxy.Processed_Delete(recipekey,surfacekey),typeof(ResultBase)) as ResultBase;
		}


		public bool	CheckProcessed(int recipekey,long surfacekey)
		{
			if(bussobject!=null)
				return bussobject.CheckProcessed(recipekey,surfacekey);
		
			return proxy.CheckProcessed(recipekey,surfacekey);
		}

		public void SurfaceUpdateProcessingDuration(long surfacekey,int ProcessingDuration)
		{
			if(bussobject!=null)
				bussobject.SurfaceUpdateProcessingDuration(surfacekey,ProcessingDuration);
			else
				proxy.SurfaceUpdateProcessingDuration(surfacekey,ProcessingDuration);
		}
	}
}
