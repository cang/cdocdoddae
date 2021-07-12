using System;
using System.IO;

using DDARecipe;
using System.Collections;
using SiGlaz.Common.DDA;

using System.Runtime.Remoting;


namespace DDARecipeRObjects
{

	public class Cache
	{
		private static Cache myInstance;
 
		private Cache()
		{
		}

		public static Cache GetInstance()
		{
			if(myInstance==null)
				myInstance = new Cache();
			return myInstance;
		}

		public bool	WasRunning = false;
		public bool WhenStopService = false;

		public bool LoadApplicationData()
		{
			DDARecipe.DDAExternalData.LoadApplicationDataFromFile();
			LoadConnectionParam();

			#region Retry - TestConnection
			int retrytime = 0;
			int limittime = AppData.Data.WaitingToStartupSecond;
			bool testok = false;
			while(retrytime<=limittime)
			{
				try
				{
					WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
					testok = cmd.TestConnection();
					if(testok)
						break;
				}
				catch
				{
				}
				System.Threading.Thread.Sleep(1000);
				retrytime++;
			}

			if(!testok)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError("DDAServices cannot connect to database");
				return false;
			}
			#endregion Retry - TestConnection
			
			DDARecipe.DDAExternalData.LoadApplicationDataFromDatabase();

			if(!LoadDefaultRecipeList() )
				return false;

			RunDefaultRecipeList();

			return true;
		}

		private Hashtable _objects = new Hashtable();
		public void InitRemoting()
		{
			foreach (WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
			{
				MarshalByRefObject pxy = (MarshalByRefObject) Activator.GetObject(entry.ObjectType, "tcp://localhost:10001/" + entry.ObjectUri);
				pxy.CreateObjRef(entry.ObjectType);
				_objects[pxy.GetType()] = pxy;
			}
		}
	
		public object GetRemoteSingletonObject(Type type)
		{
			return _objects[type];
		}

		public ArrayList	RecipeList = new ArrayList();//int
		public bool[]		RecipeListStatus = null;

		public void RunDefaultRecipeList()
		{
			RRecipeList proxy = GetRemoteSingletonObject(typeof(RRecipeList)) as RRecipeList; 

			bool isrun = false;
			for(int i=0;i<RecipeList.Count;i++)
			{
				if( this.RecipeListStatus[i] )
				{
					proxy.RunRecipe(i);
					if(!isrun) isrun = true;
				}
			}

			if(AppData.Data.RunningRecipeIDList.Count>0)
				WasRunning = isrun;
			else 
				WasRunning = true;
		}

		public bool LoadDefaultRecipeList()
		{
			try
			{
				//load recipe list from database
				RecipeList.Clear();

				if(AppData.Data.UseWebService)
				{
					try
					{
						WebServiceProxy.RecipeProxy.Recipe proxy  = WebServiceProxy.WebProxyFactory.CreateRecipe();
						if(proxy==null)
							return false;

						WebServiceProxy.RecipeProxy.RecipeListResult _recipeCollection = proxy.RecipeList();
						if (_recipeCollection != null && _recipeCollection.Recipes != null && _recipeCollection.Recipes.Length > 0)
						{
							foreach (WebServiceProxy.RecipeProxy.DDARecipe recipe in _recipeCollection.Recipes)
							{
								this.RecipeList.Add(recipe.RecipeKey);
							}
						}

						proxy.Dispose();
						proxy = null;
					}
					catch// (System.Exception e)
					{
						throw;
						//MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					try
					{
						SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();

						SiGlaz.Common.DDA.Result.RecipeListResult _recipeCollection = proxy.RecipeList();
						if (_recipeCollection != null && _recipeCollection.Recipes != null && _recipeCollection.Recipes.Count > 0)
						{
							foreach (SiGlaz.Common.DDA.DDARecipe recipe in _recipeCollection.Recipes)
							{
								this.RecipeList.Add(recipe.RecipeKey);
							}
						}
						proxy = null;
					}
					catch// (System.Exception e)
					{
						throw;
						//MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				//isSave=false;
				//HandleStateChange();
				this.RecipeListStatus = new bool[this.RecipeList.Count];
				for(int i=0;i<this.RecipeList.Count;i++)
				{
					if(AppData.Data.RunningRecipeIDList.Contains(this.RecipeList[i]))
						this.RecipeListStatus[i] = true;
				}

				return true;
			}
			catch(Exception ex)
			{
//				Console.WriteLine(ex.Message);
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
				return false;
			}
			finally
			{
			}
		}

		public SiGlaz.DAL.ConnectionParam ConnectionParam = new SiGlaz.DAL.ConnectionParam();
		public string ConnectionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Connection.cfg");

		public void LoadConnectionParam()
		{
			ConnectionParam.Load(ConnectionFilePath);
		}

	}
}
