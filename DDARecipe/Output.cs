using System;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;
using SSA.SystemFrameworks;
using System.Drawing;



namespace DDARecipe
{
	/// <summary>
	/// Summary description for Output.
	/// </summary>
	public class Output: SiGlaz.Recipes.NodeBitmap
	{
		public Output():base()
		{
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			working.EndTime = DateTime.Now;

			if(working.Results==null || working.Results.Count<=0) return;//have no data

			try
			{
				working.SetWaiting();

				foreach(ResultItem item in working.Results)
				{
					if(item.ResultMultilayer==null)
						InsertSingleResult(working,item);
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				//working.ResetWaiting();
			}
			//base.Execute (workingspace);
		}

		private void InsertSingleResult(DDAWorkingSpace working,ResultItem item)
		{
			if(working.NoConnectToDatabase)
			{
				return;
			}

			if(item.ResultMultilayer!=null) return;

			int signaturekey = (this.Parent as DDARecipe).SignatureID;

			if(item.SignatureName!=string.Empty)
			{
				WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
				Signature sig = new Signature(item.SignatureID,item.SignatureCode,item.SignatureName);
				signaturekey = cmd.SignatureInsert(sig,true,true);//Default Signature Code = 0
			}

			SiGlaz.Common.DDA.SurfaceResult result = new SiGlaz.Common.DDA.SurfaceResult();

			//Get Times
			TimeSpan ts = DateTime.Now.Subtract(working.dtBeginProcess);
			result.ProcessingDuration = (int) (working.CheckDuration +  ts.TotalMilliseconds);

			result.AnalyzeTime = working.EndTime;
			result.NumberOfDefect = item.ResultMap.defectcount;
			result.PercentOfDefect = result.NumberOfDefect*100f/working.Header.NumberOfDefect;
			result.RecipeKey = this.Parent.ID;
			result.SignatureKey = signaturekey;
			result.SurfaceKey = working.SurfaceKey;

			//RawData of DefectListID
			SiGlaz.Common.DDA.ResultDefectList defectlist = new SiGlaz.Common.DDA.ResultDefectList();
			defectlist.alDefectListID = item.ResultMap.GetDefectIDList();
			result.RawData = SiGlaz.Utility.Compression.Compressor.Compress(defectlist.Serialize());

			//Get Image Of Data
			item.ResultMap.TranPolarFromOrigin();
			SSA.SystemFrameworks.KlarfFileView view=new SSA.SystemFrameworks.KlarfFileView(item.ResultMap);
			view.ViewMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
			Bitmap bmp=view.Export2Image(new Size(100,100));
			result.SourceThumbnail = SiGlaz.Utility.DBConvert.Bitmap2Byte(bmp);
			bmp.Dispose();

			item.ResultMap.TranCartesianFromOrigin(InMemmoryData.mrsShiftAngle,1f);//now result is scale 1x1
			view=new SSA.SystemFrameworks.KlarfFileView(item.ResultMap);
			view.ViewMode = SSA.SystemFrameworks.MRSProcessingType.FlatMode;
			Bitmap bmpflat=view.Export2Image(new Size(100,100));
			result.SourceThumbnailFlat = SiGlaz.Utility.DBConvert.Bitmap2Byte(bmpflat);
			bmpflat.Dispose();
		
			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.SurfaceProxy.Surface proxy = WebServiceProxy.WebProxyFactory.CreateSurface();
				if(proxy!=null)
				{
					proxy.Results_Insert(WebServiceProxy.ConvertProxy.Convert(result, typeof(WebServiceProxy.SurfaceProxy.SurfaceResult)) as WebServiceProxy.SurfaceProxy.SurfaceResult);
				}
			}
			else
			{
				SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
				proxy.Results_Insert(result);
			}

			working.HasSignature = true;
		}

	}
}
