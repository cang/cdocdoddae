using System;
using System.Collections;

namespace DDARecipeRObjects
{
	/// <summary>
	/// Summary description for StructEvent.
	/// </summary>
	/// 
	[Serializable]
	public class RecipeListEvent : EventArgs
	{
		public ArrayList	RecipeRunningStatus = new ArrayList();
		public RecipeListEvent()
		{
		}

		public RecipeListEvent(ArrayList	recipeRunningStatus):base()
		{
			this.RecipeRunningStatus = recipeRunningStatus;
		}
	}

	
}
