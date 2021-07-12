using System;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for DDARecipeEventArgs.
	/// </summary>
	/// 
	[Serializable]
	public class DDARecipeEventArgs : SiGlaz.Recipes.RecipeEventArgs
	{
		public DDADataFlowHeader	Header = null;

		public DDARecipeEventArgs() : base()
		{
		}
		public DDARecipeEventArgs(string msg) : base(msg)
		{
		}

		public void Serialize(System.IO.BinaryWriter stream)
		{
			stream.Write(this.Message);
			stream.Write(this.RecipeID);
			if(Header==null)
				stream.Write(false);
			else
			{
				stream.Write(true);
				Header.Serialize(stream);
			}
		}

		public void Deserialize(System.IO.BinaryReader stream)
		{
			this.Message = stream.ReadString();
			this.RecipeID = stream.ReadInt32();
			if(stream.ReadBoolean())
			{
				Header = new DDADataFlowHeader();
				Header.Deserialize(stream);
			}
			else
				Header = null;
		}


	}
}
