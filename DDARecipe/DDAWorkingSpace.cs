using System;
using System.Collections;
using SiGlaz.Common.DDA;

using SSA.SystemFrameworks;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for DDAWorkingSpace.
	/// </summary>
	public class DDAWorkingSpace : SiGlaz.Recipes.WorkingSpace
	{
		public		DDADataFlowHeader	Header = null;
		public		KlarfParserFile		SourceMap = null;
		public		KlarfParserFile		ProcessMap = null;
		public		long				SurfaceKey  =  0;

		public DateTime				BeginTime = DateTime.Now;
		public DateTime				EndTime = DateTime.Now;

		public bool					IsMulti = false;//multi map

		public Hashtable			htPatternLibrary = new Hashtable();
		public Hashtable			htFuncLibrary = new Hashtable();

		/// <summary>
		/// Array of ResultItem
		/// </summary>
		public ArrayList			Results = null;//Multi result

		public bool					HasSignature= false;

		public SSA.Business.Facade.BFacadeTC.TCService OldEngine = new SSA.Business.Facade.BFacadeTC.TCService();
		public SSA.Business.Facade.BFacadeTC.TCService4FlatViewObject OldEngineFlat = new SSA.Business.Facade.BFacadeTC.TCService4FlatViewObject();

		//runtime 
		//public DateTime				dtProcessedSurfaces = DateTime.MinValue;
		public DateTime				dtProcessedSurfacesMore = DateTime.MinValue;
		//public bool					UseMoreProcess = false;
		public int					processedTickCount = 0;

		public Queue				quereSurfaceKey = new Queue(DDAConst.MAX_SURFACE_QUEUE);
		public Queue				quereSurfaceMoreKey = new Queue(DDAConst.MAX_SURFACE_QUEUE);

		public double				LoadDuration = 0;
		public double				CheckDuration = 0;
		public DateTime				dtBeginProcess;
		//public DateTime				dtEndProcess;

		public DDAWorkingSpace() : base()
		{
		}

		public override SiGlaz.Recipes.RecipeEventArgs CreateEventArgs(string msg)
		{
			DDARecipeEventArgs e = new DDARecipeEventArgs(msg);
			e.Header = this.Header;
			return e;
		}

		public override SiGlaz.Recipes.RecipeEventArgs CreateEventArgs(string msg, SiGlaz.Recipes.Recipe recipe)
		{
			DDARecipeEventArgs e = new DDARecipeEventArgs(msg);
			e.Header = this.Header;
			e.RecipeID = recipe.ID;
			return e;
		}

		public void FreeMemory()
		{
			if(SourceMap!=null)
			{
				if(!NoConnectToDatabase)
				{
					SourceMap.Dispose();
					SourceMap = null;
				}
			}
			if(ProcessMap!=null)
			{
				ProcessMap.Dispose();
				ProcessMap = null;
			}

			if(Results!=null)
			{
				Results.Clear();
				Results = null;
			}

			HasSignature = false;
			SurfaceKey = 0;
			HaveResult = false;
			Selection = false;
		}

		private void AddOnlyOneResult(ResultItem item)
		{
			if(Results==null)
			{
				Results = new ArrayList(1);
				Results.Add(item);
			}
		}

		public void UpdateDefectList(ArrayList defectList)
		{
			if(Results==null)
				AddOnlyOneResult(new ResultItem());

			ResultItem result = Results[0] as ResultItem;
			if(result.ResultMap==null)
				result.ResultMap = this.SourceMap.CopyHeader();

			result.ResultMap.AddDefectsList(defectList);
		}

		public void UpdateDefectList(string SigName,ArrayList defectList)
		{
			if(Results==null)
				Results = new ArrayList();

			//Seach
			ResultItem resultitem = null;
			foreach(ResultItem item in this.Results)
			{
				if(item.SignatureName==SigName)
				{
					resultitem = item;
					break;
				}
			}

			if(resultitem==null)
			{
				resultitem =new ResultItem();
				resultitem.ResultMap = this.SourceMap.CopyHeader();
				resultitem.SignatureName = SigName;
				Results.Add(resultitem);
			}

			resultitem.ResultMap.AddDefectsList(defectList);
		}

		public DateTime dtProcessedSurfaces
		{
			get
			{
				DateTime result = DateTime.MinValue;

				if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate!=null)
				{
					if( SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.Type == TimeRangeType.LastNHours 
						&& SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.N == -1 )
						result = result.AddYears(1);
					else
						result = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate.From;
				}

				return result;
			}

		}

	}
}
