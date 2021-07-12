using System;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Common.DDA;
using DDARecipe;
using DDARecipe.Dialogs;

using SSA.SystemFrameworks;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for CategoryFilter.
	/// </summary>
	public class ClearResult: SiGlaz.Recipes.NodeBitmap
	{
		public ClearResult(): base()
		{
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;

			//Clear result
			if(working.Results!=null)
			{
				working.Results.Clear();
				working.Results = null;
			}

		}

	}
}
