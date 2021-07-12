using System;
using System.Collections;
using System.IO;
using SiGlaz.Common.DDA;
using DDARecipe;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for RecipeData.
	/// </summary>
	public class RecipeData
	{
		public ArrayList				alSignature = new ArrayList();
		public ArrayList				alRecipe = new ArrayList();

		public RecipeData()
		{
		}


		public virtual void Serialize(BinaryWriter stream)
		{
			//alSignature
			stream.Write(alSignature.Count);
			foreach(Signature obj in alSignature)
			{
				obj.Serialize(stream);
			}

			//alRecipe
			stream.Write(alRecipe.Count);
			foreach(DDARecipe obj in alRecipe)
			{
				obj.Serialize(stream);
			}
		}

		public virtual void SerializeBinary(string filepath)
		{
			SiGlaz.Utility.FileUtils.DeleteFile(filepath);
			FileStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = File.Create(filepath);
				bw = new BinaryWriter(stream);
				this.Serialize(bw);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual byte[] SerializeBinary()
		{
			MemoryStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = new MemoryStream();
				bw = new BinaryWriter(stream);
				this.Serialize(bw);
				bw.Flush();
				return stream.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}


		public virtual void Deserialize(BinaryReader stream)
		{
			try
			{
				//alSignature
				alSignature.Clear();
				int SignatureCount = stream.ReadInt32();
				for(int i=0;i<SignatureCount;i++)
				{
					Signature obj = new Signature();
					obj.Deserialize(stream);
					alSignature.Add(obj);
				}

				//alRecipe
				alRecipe.Clear();
				int RecipeCount = stream.ReadInt32();
				for(int i=0;i<RecipeCount;i++)
				{
					DDARecipe obj = new DDARecipe();
					obj.Deserialize(stream);
					alRecipe.Add(obj);
				}
			}
			catch
			{
				throw;
			}
		}
	
		public virtual void DeserializeBinary(string filepath)
		{
			if( !SiGlaz.Utility.FileUtils.ExistsFile(filepath) ) return;
			FileStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = File.Open(filepath,FileMode.Open);
				br = new BinaryReader(stream);
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual void DeserializeBinary(byte []lpbyte)
		{
			if( lpbyte==null || lpbyte.Length<=0 ) return;

			MemoryStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = new MemoryStream(lpbyte);
				br = new BinaryReader(stream);
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		private bool CheckSignatureNameExist(string signatureName)
		{
			foreach (SiGlaz.Common.DDA.Signature sig in alSignature)
			{
				if (sig.SignatureName.ToLower() == signatureName.ToLower())
					return true;
			}

			return false;
		}

		public virtual void ImportDDAJobStep(string fileName,string testertype )
		{
			try
			{
				SiGlaz.DDA.Framework.Automation.Schema schema = SiGlaz.DDA.Framework.Automation.Schema.Deserialize(fileName);

				int signatureID = 4;//skip system signature 1-3

				int prevRecipeID = -1;
				string prevRecipeName = "None";

				foreach (SiGlaz.DDA.Framework.Automation.SignatureRecipe recipe in schema.SignatureRecipeCollection)
				{
					//Import Signature - Auto generate recipe id , because DDA Pro no contain recipe id, only signature id code
					int SignatureCode = recipe.ID;
					recipe.ID = signatureID++;

					if (!CheckSignatureNameExist(recipe.Name))//search by name // will be change to SignatureCode later, because now user don't understand about Signature Code
					{
						SiGlaz.Common.DDA.Signature sig = new Signature(recipe.ID,SignatureCode,recipe.Name);
						alSignature.Add(sig);
					}

					//Import Recipe
					DDARecipe ddaRecipe = new DDARecipe();

					ddaRecipe.PrevRecipeID = prevRecipeID;
					ddaRecipe.PrevRecipeName = prevRecipeName;

					//recipe.Break;
					if (recipe.ExcludeResult || recipe.Break)
					{
						prevRecipeID = recipe.ID;
						prevRecipeName = recipe.Name;
					}
					//else //prevRecipeID nochange
	
					ddaRecipe.Import(recipe);

					ddaRecipe.SignatureCode = SignatureCode;
					ddaRecipe.TesterType = testertype;

					alRecipe.Add(ddaRecipe);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
