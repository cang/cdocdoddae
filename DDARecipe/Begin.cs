using System;

using SiGlaz.Recipes;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for Begin.
	/// </summary>
	/// 
	[NodeNextRule(true,typeof(Surface))]
	public class Begin : SiGlaz.Recipes.NodeBegin
	{
		public Begin() : base()
		{
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;

			working.BeginTime = DateTime.Now;
			working.FreeMemory();

			//Reset Mode to Disk Mode
			SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
		}

	}
}
