using System;
using SiGlaz.Common;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;
using System.Collections;

namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for SourceCmd.
	/// </summary>
	public class SourceCmd
	{
		WebServiceProxy.SourceProxy.Source proxy;
		SiGlaz.DDA.Business.Source bussobject;

		public SourceCmd()
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				proxy =new WebServiceProxy.SourceProxy.Source();
			else
				bussobject = new SiGlaz.DDA.Business.Source();
		}

		public DataSetResult GetHintData(string fabID, string fieldName, DateTime from, DateTime to, string filter)
		{
			if(bussobject!=null)
				return bussobject.GetHintData(fabID,fieldName,from,to,filter);

			return ConvertProxy.Convert(proxy.GetHintData(fabID,fieldName,from,to,filter, (SourceProxy.DDADBType)SiGlaz.Common.DDA.AppData.Data.DBType),typeof(DataSetResult)) as DataSetResult;
		}
		
	}
}
