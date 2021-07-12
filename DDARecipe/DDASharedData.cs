using System;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for DDASharedData.
	/// </summary>
	public class DDASharedData : SiGlaz.SharedMemory.SharedData
	{
		public DDARecipe						recipe = null;
		public int								idCurrentNode = -1;
		public DDARecipeEventArgs				eventobj = null;

		public DDASharedData() : base()
		{
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			//Recipe
			if(recipe==null)
				stream.Write(false);
			else
			{
				stream.Write(true);
				recipe.Serialize(stream);
			}

			//Node id
			stream.Write(idCurrentNode);

			//RecipeEventArgs
			if(eventobj==null)
				stream.Write(false);
			else
			{
				stream.Write(true);
				eventobj.Serialize(stream);
			}
		}

		public override void Deserialize(System.IO.BinaryReader stream)
		{
			base.Deserialize (stream);

			//Recipe
			if(stream.ReadBoolean())
			{
				if(recipe==null)
					recipe = new DDARecipe();
				recipe.Deserialize(stream);
			}
			else
				recipe = null;

			//Node id
			idCurrentNode = stream.ReadInt32();

			//RecipeEventArgs
			if(stream.ReadBoolean())
			{
				eventobj = new DDARecipeEventArgs();
				eventobj.Deserialize(stream);
			}
			else
				eventobj = null;

		}

	}
}
