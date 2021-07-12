using System;
using SiGlaz.Common.DDA;
using System.Windows.Forms;

namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for WebProxyFactory.
	/// </summary>
	public class WebProxyFactory
	{
		public enum		eMessageType : byte
		{
			None,
			WindowMessage,
			SystemEvent,
			Console
		}

		public const	int				TIMEOUT = 15 * 60 * 1000;
		public static	eMessageType		MessageType = eMessageType.WindowMessage;


		public WebProxyFactory()
		{
		}

		private static void LogException(Exception e)
		{
			string msg = "Connect to web service :" + e.Message;

			if(MessageType == eMessageType.WindowMessage)
				MessageBox.Show(msg,"DDA WebService Proxy",MessageBoxButtons.OK, MessageBoxIcon.Error); 			 	
			else if(MessageType == eMessageType.Console)
				Console.WriteLine(msg);
			else if(MessageType == eMessageType.SystemEvent)
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(e);
		}

		public static WebServiceProxy.CategoryProxy.Category CreateCategory()
		{
			try
			{
				WebServiceProxy.CategoryProxy.Category proxy = new WebServiceProxy.CategoryProxy.Category();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root] ,SiGlaz.Common.DDA.Const.WebServiceConst.Category);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}

		public static WebServiceProxy.SourceProxy.Source CreateSource()
		{
			try
			{
				WebServiceProxy.SourceProxy.Source proxy = new WebServiceProxy.SourceProxy.Source();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root] ,SiGlaz.Common.DDA.Const.WebServiceConst.Source);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}


		public static WebServiceProxy.RecipeProxy.Recipe CreateRecipe()
		{
			try
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = new WebServiceProxy.RecipeProxy.Recipe();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root] ,SiGlaz.Common.DDA.Const.WebServiceConst.Recipe);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}


		public static WebServiceProxy.SurfaceProxy.Surface CreateSurface()
		{
			try
			{
				WebServiceProxy.SurfaceProxy.Surface proxy = new WebServiceProxy.SurfaceProxy.Surface();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root] ,SiGlaz.Common.DDA.Const.WebServiceConst.Surface);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}

		public static WebServiceProxy.SingleLayerProxy.SingleLayer CreateSingleLayer()
		{
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = new WebServiceProxy.SingleLayerProxy.SingleLayer();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root] ,SiGlaz.Common.DDA.Const.WebServiceConst.SingleLayer);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}

		public static WebServiceProxy.YieldTrendPlotProxy.YieldTrendPlot CreateYieldTrendPlot()
		{
			try
			{
				WebServiceProxy.YieldTrendPlotProxy.YieldTrendPlot proxy = new WebServiceProxy.YieldTrendPlotProxy.YieldTrendPlot();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root], SiGlaz.Common.DDA.Const.WebServiceConst.YieldTrendPlot);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}

		public static WebServiceProxy.PerformanceIndicatorsProxy.PerformanceIndicators CreatePerformanceIndicators()
		{
			try
			{
				WebServiceProxy.PerformanceIndicatorsProxy.PerformanceIndicators proxy = new WebServiceProxy.PerformanceIndicatorsProxy.PerformanceIndicators();
				proxy.Url = string.Format("{0}/{1}", AppData.Data.WebServiceList[WebServicetypeType.Root], SiGlaz.Common.DDA.Const.WebServiceConst.PerformanceIndicators);
				proxy.Timeout = TIMEOUT;
				proxy.Discover();
				return proxy;
			}
			catch (System.Exception e)
			{
				LogException(e);
				return null;
			}
		}
	}
}
