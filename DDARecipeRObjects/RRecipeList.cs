using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

using System.Collections;
using System.Collections.Specialized;


using SiGlaz.Recipes;
using DDARecipe;

using SiGlaz.Common.DDA;


namespace DDARecipeRObjects
{
	/// <summary>
	/// Summary description for RRecipeList.
	/// </summary>
	public class RRecipeList : RRecipeListEvent, IRRecipeListMethod
	{
		public RRecipeList()
		{
		}
		
		#region IRRecipeListMethod Members

		public RecipeListEvent RequireRecipeList()
		{
			ArrayList alRunningRecipe = new ArrayList();
			for(int i=0;i<Cache.GetInstance().RecipeList.Count;i++)
			{
				if(Cache.GetInstance().RecipeListStatus[i])
					alRunningRecipe.Add(Cache.GetInstance().RecipeList[i]);
			}
			RecipeListEvent e = new RecipeListEvent(alRunningRecipe);
			return e;
		}

		public void RunRecipe(int index)
		{
			if(Cache.GetInstance().WasRunning && Cache.GetInstance().RecipeListStatus[index])
				return;

            string cmdpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DDARMProcess.exe");
            if (!System.IO.File.Exists(cmdpath))
                return;

            System.Diagnostics.ProcessStartInfo proInfo =
                new System.Diagnostics.ProcessStartInfo(cmdpath, @"/Controler " + Cache.GetInstance().RecipeList[index] + " " + index);//+ SiGlaz.Common.DDA.AppData.Data.NumberOfProcessToReStart);

            proInfo.UseShellExecute = false;
            proInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(proInfo);

		}

		public void StopRecipe(int index)
		{
			if(!Cache.GetInstance().RecipeListStatus[index])
				return;

			HandlerOnStopCmd(index,null);
		}

		public void StopAllRecipes()
		{
			if(Cache.GetInstance().RecipeList==null
				|| Cache.GetInstance().RecipeListStatus==null
				) return;

			for(int i=0;i<Cache.GetInstance().RecipeList.Count;i++)
			{
				if(Cache.GetInstance().RecipeListStatus[i] )
				{
					this.StopRecipe(i);
				}
			}
		}

		public byte[] RequireApplicationConfig()
		{
			return SiGlaz.Common.DDA.AppData.Data.SaveApplicationData();
		}

		public bool SaveApplicationConfig(byte[] lpbyte)
		{
			SiGlaz.Common.DDA.AppData.Data.LoadApplicationData(lpbyte);

			//Save to disk
			DDARecipe.DDAExternalData.SaveApplicationData();

			//Reload recipelist
			if( !Cache.GetInstance().LoadDefaultRecipeList() )
				return false;

			Cache.GetInstance().RunDefaultRecipeList();

			return true;
		}

		public  bool RefreshRecipeList()
		{
			//Reload recipelist
			return Cache.GetInstance().LoadDefaultRecipeList();
		}

		public SiGlaz.DAL.ConnectionParam GetConnectionParam()
		{
			return Cache.GetInstance().ConnectionParam;
		}

		public void SetConnectionParam(SiGlaz.DAL.ConnectionParam param)
		{
			Cache.GetInstance().ConnectionParam = param;
			Cache.GetInstance().ConnectionParam.Save(Cache.GetInstance().ConnectionFilePath);
		}

		public override void HandlerOnStart(int RecipeIndex, RecipeEventArgs e)
		{
			SetStartStatus(RecipeIndex);
			base.HandlerOnStart (RecipeIndex, e);
		}

		public override void HandlerOnStop(int RecipeIndex, RecipeEventArgs e)
		{
			SetStopStatus(RecipeIndex);
			base.HandlerOnStop (RecipeIndex, e);
		}

		#endregion

		#region IRRecipeListMethod Members

		public void SetStartStatus(int RecipeIndex)
		{
			if(Cache.GetInstance().RecipeListStatus.Length>RecipeIndex && !Cache.GetInstance().RecipeListStatus[RecipeIndex])
			{
				Cache.GetInstance().RecipeListStatus[RecipeIndex]=true;
				
				lock(AppData.Data.RunningRecipeIDList)
				{
					if(!AppData.Data.RunningRecipeIDList.Contains(Cache.GetInstance().RecipeList[RecipeIndex]))
						AppData.Data.RunningRecipeIDList.Add(Cache.GetInstance().RecipeList[RecipeIndex]);
				}

				//Save to disk
				DDARecipe.DDAExternalData.SaveApplicationData();
			}
		}

		public void SetStopStatus(int RecipeIndex)
		{
			if(!Cache.GetInstance().WhenStopService)
			{
				if(Cache.GetInstance().RecipeListStatus.Length>RecipeIndex && Cache.GetInstance().RecipeListStatus[RecipeIndex])
				{
					Cache.GetInstance().RecipeListStatus[RecipeIndex]=false;

					lock(AppData.Data.RunningRecipeIDList)
					{
						if(AppData.Data.RunningRecipeIDList.Contains(Cache.GetInstance().RecipeList[RecipeIndex]))
							AppData.Data.RunningRecipeIDList.Remove(Cache.GetInstance().RecipeList[RecipeIndex]);
					}

					//Save to disk
					DDARecipe.DDAExternalData.SaveApplicationData();
				}
			}
		}

		#endregion

		#region IRRecipeListMethod Members

		public bool AnyRun()
		{
			if(AppData.Data.RunningRecipeIDList!=null && AppData.Data.RunningRecipeIDList.Count>0)
				return true;
			else
				return false;
		}

		#endregion

		#region IRRecipeListMethod Members

		public bool RefreshExternalData()
		{
			//DDARecipe.DDAExternalData.DiskTypeTableLastDate = DateTime.MinValue;
			//DDARecipe.DDAExternalData.RefreshDiskType();
			return DDARecipe.DDAExternalData.CheckFab();
		}

		#endregion

		#region IRRecipeListMethod Members

		public void PrepareShutdown()
		{
			Cache.GetInstance().WhenStopService = true;
		}

		#endregion
	}
}
