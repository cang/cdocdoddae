using System;
using SiGlaz.Common.DDA;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for End.
	/// </summary>
	public class End : SiGlaz.Recipes.NodeEnd
	{
		public End() : base()
		{
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			base.Execute (workingspace);
			
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.NoConnectToDatabase)
			{
				return;
			}

			if(working.IsMulti) return;
			DDARecipe recipe = this.Parent as DDARecipe;

			try
			{
				working.SetWaiting();

				WebServiceProxy.SurfaceCmd  cmd = new WebServiceProxy.SurfaceCmd();

//				#region check Empty and NoSignature
//
//				int signatureKey = 3;//No-Signature
//				if(working.SourceMap.defectcount<=0)
//					signatureKey = 2;//Empty
//
//				//Get times
//				TimeSpan ts = DateTime.Now.Subtract(working.dtBeginProcess);
//				int checkduration = (int) (working.CheckDuration +  ts.TotalMilliseconds);
//
//				if(AppData.Data.UseWebService)
//				{
//					WebServiceProxy.SurfaceProxy.Surface proxy = WebServiceProxy.WebProxyFactory.CreateSurface();
//
//					#region Update No-Signature
//
//					if(!proxy.HasSignature(working.SurfaceKey) )
//					{
//						#region Insert No-Signaturet Result
//						SiGlaz.Common.DDA.SurfaceResult result = new SiGlaz.Common.DDA.SurfaceResult();
//						result.AnalyzeTime = DateTime.Now;
//						result.NumberOfDefect = 0;//working.Header.NumberOfDefect;
//						result.PercentOfDefect = 0;
//						result.RecipeKey = -1;
//						result.SignatureKey = signatureKey;
//						result.SurfaceKey = working.SurfaceKey;
//						result.ProcessingDuration = checkduration;
//
//						WebServiceProxy.SurfaceProxy.SurfaceResult result1 = (WebServiceProxy.SurfaceProxy.SurfaceResult)WebServiceProxy.ConvertProxy.Convert(result, typeof(WebServiceProxy.SurfaceProxy.SurfaceResult));
//						WebServiceProxy.SurfaceProxy.Surface surfaceProxy = WebServiceProxy.WebProxyFactory.CreateSurface();
//						surfaceProxy.Results_Insert(result1);
//						#endregion
//					}
//					else
//						proxy.DeleteNoSignature(working.SurfaceKey,checkduration);//Remove No-Signature
//
//					#endregion Update No-Signature
//				}
//				else
//				{
//					SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
//
//					#region Update No-Signature
//
//					if(!proxy.HasSignature(working.SurfaceKey) )
//					{
//						#region Insert No-Signature Result
//						SiGlaz.Common.DDA.SurfaceResult result = new SiGlaz.Common.DDA.SurfaceResult();
//						result.AnalyzeTime = DateTime.Now;
//						result.NumberOfDefect = 0;//working.Header.NumberOfDefect;
//						result.PercentOfDefect = 0;
//						result.RecipeKey = -1;
//						result.SignatureKey = signatureKey;
//						result.SurfaceKey = working.SurfaceKey;
//						result.ProcessingDuration = checkduration;
//
//						SiGlaz.DDA.Business.Surface surfaceProxy = new SiGlaz.DDA.Business.Surface();
//						surfaceProxy.Results_Insert(result);
//						#endregion
//					}
//					else
//						proxy.DeleteNoSignature(working.SurfaceKey,checkduration);//Remove No-Signature
//
//					#endregion Update No-Signature
//				}
//
//				#endregion check Empty and NoSignature

				bool breakAllNextRecipe = working.HasSignature && (this.Parent as DDARecipe).BreakWhenFound;
				cmd.Processed_Insert(this.Parent.ID,working.SurfaceKey,breakAllNextRecipe,true);
				
				//DDA_Surfaces_UpdateProcessingDuration
				if( AppData.Data.AllowTrackProcessingTime)
				{
					TimeSpan ts = DateTime.Now.Subtract(working.dtBeginProcess);
					cmd.SurfaceUpdateProcessingDuration(working.SurfaceKey,(int) (working.CheckDuration +  ts.TotalMilliseconds)) ;
				}

				#region multi process event 
				if(recipe.ChildrenIDList!=null && recipe.ChildrenIDList.Count>0)
				{
					//SiGlaz.Utility.DebugLog.LogFolderPath = "D:\\log";
					foreach(int id in recipe.ChildrenIDList)
					{
						try
						{
							InterProcessRecipeEvent pe = new InterProcessRecipeEvent(id,true);
							//SiGlaz.Utility.DebugLog.Write(DateTime.Now.ToString("HH:mm:ss.ffffff")  +":Before Set " + id);
							pe.SetEvent();
							//SiGlaz.Utility.DebugLog.Write(DateTime.Now.ToString("HH:mm:ss.ffffff")  +":After Set " + id);
						}
						catch
						{
						}
					}
				}

				//raise event to global after process finished
				try
				{
					SiGlaz.Utility.InterProcessEvent eglobal = new SiGlaz.Utility.InterProcessEvent("DDAE_PROCESSED",true);
					eglobal.SetEvent();
				}
				catch
				{
				}
				#endregion multi process event 
			}
			catch
			{
				throw;
			}
			finally
			{
				working.FreeMemory();
				working.ResetWaiting();
			}
		}

	}
}
