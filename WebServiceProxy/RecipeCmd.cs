using System;
using System.Collections;


namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for RecipeCmd.
	/// </summary>
	public class RecipeCmd
	{
		WebServiceProxy.RecipeProxy.Recipe proxy;
		SiGlaz.DDA.Business.Recipe bussobject;

		public RecipeCmd()
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				proxy = WebProxyFactory.CreateRecipe();
			else
				bussobject = new SiGlaz.DDA.Business.Recipe();
		}

		public ArrayList GetNextRecipeKey(int recipeid,bool onelevel)
		{
			if(bussobject!=null)
				return bussobject.GetNextRecipeKey(recipeid,onelevel);
		
			object[] result = proxy.GetNextRecipeKey(recipeid,onelevel);

			ArrayList alResult = new ArrayList();

			if(result!=null)
				alResult.AddRange(result);
	
			return alResult;
		}


		public SiGlaz.Common.DDA.eRecipeStatus GetStatus(int recipeKey)
		{
			if(bussobject!=null)
				return bussobject.GetStatus(recipeKey);

			return (SiGlaz.Common.DDA.eRecipeStatus)((byte)(proxy.GetStatus(recipeKey)));
		}

	
		public void UpdateStatus(int recipeKey,SiGlaz.Common.DDA.eRecipeStatus status)
		{
			if(bussobject!=null)
				bussobject.UpdateStatus(recipeKey,status);
			else
				proxy.UpdateStatus(recipeKey,(WebServiceProxy.RecipeProxy.eRecipeStatus)((byte)status));
		}

	}
}
