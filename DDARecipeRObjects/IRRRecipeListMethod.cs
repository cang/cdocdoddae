using System;
using System.Collections;
using System.Collections.Specialized;
namespace DDARecipeRObjects
{
	/// <summary>
	/// Summary description for IRRecipeListMethod.
	/// </summary>
	public interface IRRecipeListMethod
	{
		//Method for GUI
		RecipeListEvent RequireRecipeList();
		
		void RunRecipe(int index);
		void StopRecipe(int index);
//		void RunAllRecipes();
		void StopAllRecipes();

		byte[]	RequireApplicationConfig();
		bool	SaveApplicationConfig(byte[] lpbyte);

		SiGlaz.DAL.ConnectionParam GetConnectionParam();
		void SetConnectionParam(SiGlaz.DAL.ConnectionParam param);

//		void RegisterEvent();
//		void UnRegisterEvent();

//		StringCollection RequireOutput(int processid);
//		StringCollection RequireTrace(int processid);

//		bool RequireWaiting(int processid);
//		bool RequireRunning(int processid);

//		void RegisterEventCmd;
//		void UnregisterEventCmd;

		bool RefreshRecipeList();

		void SetStartStatus(int RecipeIndex);
		void SetStopStatus(int RecipeIndex);

		bool AnyRun();

		bool RefreshExternalData();

		void PrepareShutdown();

	}
}
