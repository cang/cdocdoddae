using System;
using System.Collections;
using System.Data;


using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace SiGlaz.DDA.Business
{
	/// <summary>
	/// Summary description for Surface.
	/// </summary>
	public class Surface: SingleTableCmd
	{
		public Surface() : base()
		{
		}
		public Surface(SiGlaz.Common.DDA.DDADBType type) : base(type)
		{
		}

		#region query new wafer

		public ArrayList GetNewSurfaceKey(int recipeid,int prevrecipid,short fabkey,DateTime fromDate,string TestGradeList,int numbersurfaces)
		{
			ArrayList alResult = new ArrayList();

			try
			{
				object[] objs = new object[6];
				objs[0] = recipeid;
				objs[1] = prevrecipid;
				objs[2] = fabkey;


				if(fromDate == DateTime.MinValue)
					objs[3] = null;
				else if( fromDate == DateTime.MinValue.AddYears(1))
					objs[3] = DateTime.Parse("1900-01-01 00:00:00");
				else 
					objs[3] = fromDate;


				if(TestGradeList!=null && TestGradeList!=string.Empty)
					objs[4] = TestGradeList;
				else
					objs[4] = null;


				objs[5] = numbersurfaces;

				DataSet ds = ExecuteDataset("GET_NPROCESS_SURFACE",objs);
				if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr  in ds.Tables[0].Rows)
					{
						alResult.Add(dr[0]);
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				return null;
			}

			return alResult;
		}

		public ResultBase GetPrevRecipeKey(int recipeid)
		{
			ResultBase result = new ResultBase();
			try
			{
				object[] objs = new object[1];
				objs[0] = recipeid;
				result.id32 = (int)ExecuteScalarProc("GET_PREV_RECIPE",objs);
			}
			catch(Exception ex)
			{
				result.Code = ErrorCode.UNKNOWN_ERROR;
				result.Description = ex.ToString();
			}
			return result;
		}

		public byte[] GetResultDetail(int recipeid,long surfacekey)
		{
			try
			{
				object[] objs = new object[2];
				objs[0] = recipeid;
				objs[1] = surfacekey;

				DataSet ds = ExecuteDataset("GET_RESULT_DETAIL",objs);

				if( ds.Tables.Count > 0  && ds.Tables[0].Rows.Count>0 && !ds.Tables[0].Rows[0].IsNull("RawData") )
					return (byte[])ds.Tables[0].Rows[0]["RawData"];
				else
					return  null;
			}
			catch
			{
				return null;
			}
		}

		public byte[] GetProcessedResultDetail(int recipeid,long surfacekey)
		{
			BinaryResult result = new BinaryResult();

			bool NoCompress = false;

			try
			{
				int recipekey = recipeid;
				SiGlaz.Common.DDA.ResultDefectList processedList = null;
				ArrayList alKeys = new ArrayList();
				alKeys.Add(recipeid);

				while(true)
				{
					//Get Prev Recipe Key
					ResultBase prevresult = GetPrevRecipeKey(recipekey);
					if( prevresult.id32!=-1)
					{
						recipekey = prevresult.id32;
						if( alKeys.Contains(recipekey)) 
							break;//error , circle 
					}
					else
						break;

					//Get Data
					object[] objs = new object[2];
					objs[0] = recipekey;
					objs[1] = surfacekey;

					DataSet ds = ExecuteDataset("GET_RESULT_DETAIL_RAWDATA",objs);//[GET_RESULT_DETAIL] code cu

					//Get all result of this recipe and surface
					if(ds.Tables.Count > 0  && ds.Tables[0].Rows.Count>0)
					{
						foreach(DataRow dr  in ds.Tables[0].Rows)
						{
							if(!dr.IsNull("RawData"))
							{
								byte[] lpbyte = (byte[])dr["RawData"];
								NoCompress = (bool)dr["NoCompress"];
								if(lpbyte!=null)
								{
									if(!NoCompress)
										lpbyte = SiGlaz.Utility.Compression.Compressor.DeCompress(lpbyte);

									SiGlaz.Common.DDA.ResultDefectList defectlist = SiGlaz.Common.DDA.ResultDefectList.Deserialize(lpbyte);

									if(defectlist!=null && defectlist.alDefectListID!=null)
									{
										if(processedList==null)
											processedList = defectlist;
										else
											processedList.alDefectListID.AddRange(defectlist.alDefectListID);
									}
								}
							}
						}
					}//end get all result of recipe and surface
				}//end while

				if(processedList==null || processedList.alDefectListID.Count<=0)
					result.Result = null;
				else
					result.Result = processedList.Serialize();

				if(result.Result!=null)
				{
					if(!NoCompress)
						result.Result = SiGlaz.Utility.Compression.Compressor.Compress(result.Result);
				}

				return result.Result;
			}
			catch//(Exception ex)
			{
				//result.Code = ErrorCode.UNKNOWN_ERROR;
				//result.Description = ex.ToString();
				return null;
			}
		}

		public bool HasSignature(long surfacekey)
		{
			try
			{
				return ExecuteScalarProc("DDA_Surfaces_HasSignature",surfacekey) > 0;
			}
			catch
			{
				return false;
			}
		}

		public void DeleteNoSignature(long surfacekey,int ProcessingDuration)
		{
			try
			{
				ExecuteNonQuery("DDA_Surfaces_DeleteNoSignature",surfacekey,ProcessingDuration);
			}
			catch
			{
			}
		}


		public bool	CheckProcessed(int recipekey,long surfacekey)
		{
			string SQL = string.Format("SELECT TOP 1 1 FROM DDA_Processed WITH(NOLOCK) WHERE SurfaceKey= {0} AND RecipeKey= {1}",surfacekey,recipekey);
			try
			{
				return this.CheckExistSQL(SQL);
			}
			catch
			{
				return true;
			}
		}

		#endregion query new wafer

		#region insert result

		public void SurfaceUpdateProcessingDuration(long surfacekey,int ProcessingDuration)
		{
			try
			{
				this.ExecuteNonQuery("DDA_Surfaces_UpdateProcessingDuration",surfacekey,ProcessingDuration);
			}	
			catch
			{
				throw;
			}
		}

		public ResultBase Processed_Delete(int recipekey,long surfacekey)
		{
			ResultBase result = new ResultBase();
			try
			{
				//this.BeginCommand();

				this.TableName = "DDA_Processed";
				this.DeleteByPrimaryKey(recipekey,surfacekey);

				//this.CommitCommand();
			}
			catch(Exception ex)
			{
				//this.RollbackCommand();

				result.Description = ex.ToString();
				result.Code = ErrorCode.UNKNOWN_ERROR;
			}
			finally
			{
				//this.FinallyCommand();
			}
			return result;
		}
		
		public ResultBase Processed_Insert(int recipekey,long surfacekey,bool BreakWhenFound,bool finish)
		{
			ResultBase result = new ResultBase();
			try
			{
				string SQL = string.Format("SELECT RecipeKey FROM DDA_Processed WHERE RecipeKey={0} AND SurfaceKey={1}",recipekey,surfacekey);
				int testid = (int)this.ExecuteScalarSQL(SQL);

				if(testid>0 && !finish)
				{
					result.Code = ErrorCode.UNKNOWN_ERROR;
					return result;
				}

				//this.BeginCommand();
				object []objs = new object[4];
				objs[0] = recipekey;
				objs[1] = surfacekey;
				objs[2] = BreakWhenFound;
				objs[3] = finish;

				this.TableName = "DDA_Processed";

				if(testid>0)//update
				{
					this.Update(objs);
				}
				else
				{
					this.Insert(objs);
				}

				//this.CommitCommand();
			}
			catch(Exception ex)
			{
				//this.RollbackCommand();

				result.Description = ex.ToString();
				result.Code = ErrorCode.UNKNOWN_ERROR;
			}
			finally
			{
				//this.FinallyCommand();
			}
			return result;
		}

		public ResultBase	Results_Insert(SiGlaz.Common.DDA.SurfaceResult resultobj)
		{
			ResultBase result = new ResultBase(ErrorCode.OK,string.Empty);

			//Check before insert result - Don't allow one surface can has more than one signature 
			//AND (DDA_Results.NumberOfDefect = {3})");//compare number of defects
			string SQL = string.Format("SELECT TOP 1 1 FROM DDA_ResultDetail INNER JOIN DDA_Results ON DDA_ResultDetail.ResultKey = DDA_Results.ResultKey WHERE (DDA_ResultDetail.SurfaceKey = {0}) AND (DDA_Results.SignatureKey = {1})",resultobj.SurfaceKey,resultobj.SignatureKey);
			if( this.CheckExistSQL(SQL) ) return result;//

			try
			{
				this.BeginCommand();

				//Insert DDA_Results
				object []objs = new object[9];
				objs[0] = 0;//return
				objs[1] = resultobj.SignatureKey;
				objs[2] = false;//multi layer
				objs[3] = resultobj.AnalyzeTime;
				objs[4] = resultobj.NumberOfDefect;
				objs[5] = resultobj.PercentOfDefect;

				if (resultobj.RecipeKey == -1)
					objs[6] = DBNull.Value;
				else
					objs[6] = resultobj.RecipeKey;

				objs[7] = resultobj.ProcessingDuration;

				objs[8] = 0;//output

				ExecuteNonQueryEx("DDA_Results_Insert",objs);
				resultobj.ResultKey = (long)objs[8];

				//Insert DDA_ResultDetail
				objs = new object[6];
				objs[0] = 0;
				objs[1] = resultobj.ResultKey;
				objs[2] = resultobj.SurfaceKey;
				objs[3] = resultobj.NumberOfDefect;
				objs[4] = resultobj.PercentOfDefect;
				objs[5] = 0;

				ExecuteNonQueryEx("DDA_ResultDetail_Insert",objs);
				resultobj.ResultDetailKey = (long)objs[5];

				result.id64 = resultobj.ResultDetailKey;

				if (resultobj.SourceThumbnail != null)
				{
					//DDA_ResultDetailData
					objs = new object[5];
					objs[0] = resultobj.ResultDetailKey;
					objs[1] = resultobj.RawData;//compressed
					objs[2] = resultobj.SourceThumbnail;
					objs[3] = resultobj.SourceThumbnailFlat;
					objs[4] = false;

					this.TableName = "DDA_ResultDetailData";
					this.Insert(objs);

					//Update HasSignature status
					objs = new object[2];
					objs[0] = resultobj.SurfaceKey;
					objs[1] = true;
					ExecuteNonQuery("DDA_Surfaces_UpdateHasSignatureStatus",objs);
				}
				
				this.CommitCommand();
			}
			catch(Exception ex)
			{
				this.RollbackCommand();

				result.Description = ex.ToString();
				result.Code = ErrorCode.UNKNOWN_ERROR;
			}
			finally
			{
				this.FinallyCommand();
			}
			return  result;
		}

		#endregion insert result

	}
}
