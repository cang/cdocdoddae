using System;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for InterProcessRecipeEvent.
	/// </summary>
	public class InterProcessRecipeEvent : SiGlaz.Utility.InterProcessEvent
	{
		public InterProcessRecipeEvent(int recipekey) : base("RE" + recipekey)//RE = Recipe Event 
		{
		}
		public InterProcessRecipeEvent(int recipekey,bool open) : base("RE" + recipekey,open)//RE = Recipe Event 
		{
		}
	}
}
