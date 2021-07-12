using System;
using System.Data;
using SiGlaz.DAL;
using System.Collections;

using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA;

namespace SiGlaz.DDA.Business
{
	/// <summary>
	/// Summary description for Recipe.
	/// </summary>
	public class Recipe : SingleTableCmd
	{
		public Recipe():base()
		{			
		}

		public Recipe(SiGlaz.Common.DDA.DDADBType type):base(type)
		{			
		}

		public DataSetResult RecipeListToDataset()
		{
			DataSetResult result = new DataSetResult();
			try
			{
				result.Result = ExecuteDataset("GetRecipeList");
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}


		public string RecipeNameByKey(int key)
		{			
			DataSetResult result = new DataSetResult();
			try
			{
				result.Result = this.GetTableByPrimaryKey("DDA_Recipes",key);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			if(result.Result.Tables[0].Rows.Count>0)
				return result.Result.Tables[0].Rows[0].ItemArray[1].ToString();

			return string.Empty;
		}

		private DDARecipe GetRecipeOfRow(DataRow dr)
		{
			if(dr==null)
				return null;

			bool hasraw = dr.Table.Columns.Contains("RawData");

			DDARecipe item = new DDARecipe();

			if(!dr.IsNull("RecipeKey"))
				item.RecipeKey = (int)dr["RecipeKey"] ;

			if(!dr.IsNull("RecipeName"))
				item.RecipeName = (string)dr["RecipeName"] ;

			if(!dr.IsNull("SignatureKey"))
				item.SCKey = (int)dr["SignatureKey"] ;

			if(!dr.IsNull("PrevRecipeKey"))
				item.PrevRecipeKey = (int)dr["PrevRecipeKey"] ;

			if(!dr.IsNull("PrevRecipeKey"))
				item.PrevRecipeName =RecipeNameByKey((int)dr["PrevRecipeKey"]) ;

			if(!dr.IsNull("Description"))
				item.Description = (string)dr["Description"] ;

			if(!dr.IsNull("SignatureName"))
				item.SignatureName = (string)dr["SignatureName"] ;

			if(!dr.IsNull("SignatureID"))
				item.SignatureCode = (int)dr["SignatureID"];

			if(!dr.IsNull("Status"))
				item.Status = (eRecipeStatus)(byte)dr["Status"] ;

			if(!dr.IsNull("TesterType"))
				item.TesterType = (string)dr["TesterType"];

			if(!dr.IsNull("BreakWhenFound"))
				item.BreakWhenFound = (bool)dr["BreakWhenFound"];

			if(hasraw && !dr.IsNull("RawData"))
				item.RawData = dr["RawData"] as byte[];

			return item;
		}


		public DDARecipe GetRecipeByKey(int key)
		{			
			try
			{
				DataSet ds = this.ExecuteDataset("GetRecipeByKey",key);
				if( ds!=null && ds.Tables[0]!=null && ds.Tables[0].Rows.Count >=1)
				{
					DataRow dr = ds.Tables[0].Rows[0];
					DDARecipe item = this.GetRecipeOfRow(dr);
					ds.Dispose();
					return item;
				}
				return null;
			}
			catch//(Exception ex)
			{
				return null;
			}
		}

		public RecipeListResult RecipeList()
		{
			DataSetResult resultprocess = this.RecipeListToDataset();
			RecipeListResult result = new RecipeListResult();
			result.Code = resultprocess.Code;
			result.Description = resultprocess.Description;		
			if(result.IsSuccess)
			{
				foreach (DataRow dr in resultprocess.Result.Tables[0].Rows)
				{
					DDARecipe item = this.GetRecipeOfRow(dr);
					if(item==null) continue;
					result.Recipes.Add(item);
				}
			}
			return result;
		}

		public BinaryResult GetRawData(long key)
		{
			BinaryResult result = new BinaryResult();
			try
			{
				byte []lpbyte = null;
				DataSet  ds  = ExecuteDataset("DDA_Recipes_GetRawData",key);
				if( ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0 && !ds.Tables[0].Rows[0].IsNull("RawData"))
				{
					lpbyte = ds.Tables[0].Rows[0]["RawData"] as byte[];
				}
				result.Result = lpbyte;
				ds.Dispose();
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}


		public ResultBase DeleteRecipe(long key)
		{	
			ResultBase result = new ResultBase();
			try
			{				
				this.TableName = "DDA_Recipes";
				result.id32 = this.DeleteByPrimaryKey(key);
			}
			catch(Exception ex)
			{
				result.Code =ErrorCode.UNKNOWN_ERROR;
				result.Description=ex.Message;
			}		
			return result;
		}

		public ResultBase InsertRecipe(SiGlaz.Common.DDA.DDARecipe _recipe)
		{
			ResultBase result = new ResultBase();
			if(_recipe!=null)
			{				
				long isexists = this.ExecuteScalarProc("RecipeGetByID",
					_recipe.RecipeKey);

				if(isexists>0) 			
					// exists key, Update
					result = UpdateRecipe(_recipe);			
				else
					result = InsertRecipeForce(_recipe);
			}		

			return result;
		}


		public ResultBase InsertRecipeForce(SiGlaz.Common.DDA.DDARecipe _recipe)
		{
			ResultBase result = new ResultBase();
			if(_recipe!=null)
			{				
				try
				{
					this.BeginCommand();

					object []objs = new object[7];
					objs[0] = _recipe.RecipeName;
					objs[1] = _recipe.SCKey;
					objs[2] =_recipe.PrevRecipeKey;		
					objs[3] =_recipe.Description;		
					objs[4] = (byte)_recipe.Status;	
					objs[5] = _recipe.TesterType;
					objs[6] = _recipe.BreakWhenFound;


					this.TableName = "DDA_Recipes";

					_recipe.RecipeKey = (int)this.Insert(objs);
					result.id32 = _recipe.RecipeKey;

					objs = null;

					#region Insert Recipe Detail
					objs = new object[2];
					objs[0] =  _recipe.RecipeKey;
					objs[1] =  _recipe.RawData;				
					this.TableName = "DDA_RecipeData";
					this.Insert(objs);
					#endregion Insert Recipe Detail

					this.CommitCommand();					
				}
				catch(Exception ex)
				{
					this.RollbackCommand();

					result.Code= ErrorCode.UNKNOWN_ERROR;
					result.Description =ex.Message;
				}
				finally
				{
					this.FinallyCommand();
				}
			}		
				
			return result;
		}


		public ResultBase UpdateRecipe(SiGlaz.Common.DDA.DDARecipe _recipe)
		{			
			ResultBase result = new ResultBase();
			try
			{
				this.BeginCommand();

				object []objs = new object[8];
				objs[0] = _recipe.RecipeName;
				objs[1] = _recipe.SCKey;
				objs[2] =_recipe.PrevRecipeKey;		
				objs[3] =_recipe.Description;						
				objs[4] =(byte)_recipe.Status;	
				objs[5] =_recipe.TesterType;
				objs[6] = _recipe.BreakWhenFound;
				objs[7] = _recipe.RecipeKey;

				this.TableName = "DDA_Recipes";
				this.Update(objs);

				result.id32 = _recipe.RecipeKey;
				objs = null;

				#region Update Recipe Detail
				objs = new object[2];
				objs[0] =  _recipe.RecipeKey;
				objs[1] =  _recipe.RawData;				
				this.TableName = "DDA_RecipeData";
				this.Update(objs);
				#endregion Insert Recipe Detail

				this.CommitCommand();
			
			}
			catch(Exception ex)
			{
				this.RollbackCommand();

				result.Code =ErrorCode.UNKNOWN_ERROR;
				result.Description=ex.Message;
			}
			finally
			{
				this.FinallyCommand();
			}
			return result;
		}

		public eRecipeStatus GetStatus(int recipeKey)
		{
			try
			{				
				string SQL = string.Format("SELECT Status FROM DDA_Recipes WHERE RecipeKey = {0}",recipeKey);
				byte status = (byte)this.ExecuteScalarSQL(SQL);

				if(status==(byte)eRecipeStatus.Normal)
				{
					SQL = string.Format("SELECT COUNT(FabKey) FROM DDA_RecipeStatus WHERE RecipeKey = {0} AND  Status = 1",recipeKey);
					if( this.ExecuteScalarSQL(SQL) > 0)
						status=(byte)eRecipeStatus.Running;
				}

				return (eRecipeStatus)status;
			}
			catch
			{
				return eRecipeStatus.Normal;
			}		
		}

	
		public void UpdateStatus(int recipeKey,eRecipeStatus status)
		{
			try
			{				
				string SQL = string.Format("UPDATE DDA_Recipes SET Status = {0} WHERE RecipeKey = {1}",(byte)status,recipeKey);
				this.ExecuteNonQuery(SQL);
			}
			catch
			{
			}		
		}


		public bool	CanDelete()
		{
			try
			{				
				string SQL = "SELECT COUNT(RecipeKey) FROM DDA_Recipes WHERE (Status <> 0)";
				return this.ExecuteScalarSQL(SQL) <=0;
			}
			catch
			{
				return false;
			}
		}

		public bool RecipeIsEdited(int recipeKey)
		{
			try
			{				
				string SQL = string.Format("SELECT Status FROM DDA_Recipes WHERE RecipeKey = {0}",recipeKey);
				byte status = (byte)this.ExecuteScalarSQL(SQL);
				return	(status==(byte)eRecipeStatus.Edited);
			}
			catch
			{
				return false;
			}		
		}

		public void ResetRecipeStatus()
		{
			try
			{				
				this.ExecuteNonQuery("UPDATE DDA_Recipes SET Status = 0");
			}
			catch
			{
			}		
		}


		public ArrayList GetNextRecipeKey(int recipeid,bool onelevel)
		{
			ResultBase result = new ResultBase();

			string SQL = string.Format("SELECT RecipeKey FROM DDA_Recipes WHERE PrevRecipeKey = {0}",recipeid);

			try
			{
				ArrayList alResult = new ArrayList();

				DataSet ds = this.ExecuteDataset(SQL);
				if(ds!=null && ds.Tables.Count>0)
				{
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						if( !dr.IsNull(0))
							alResult.Add((int)dr[0]);
					}
				}

				if(alResult.Count>0 && !onelevel)
				{
					ArrayList alNewResult = new ArrayList();

					foreach(int recipe in alResult)
					{
						ArrayList alSubResult = GetNextRecipeKey(recipe,onelevel);

						if(alSubResult.Count>0)
							alNewResult.AddRange(alSubResult);
					}

					if(alNewResult.Count>0)
						alResult.AddRange(alNewResult);
				}

				return alResult;
				
			}
			catch
			{
				throw;
			}
		}


	}
}
