using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

using DDARecipe;
using SiGlaz.Recipes;

namespace DDARecipeRObjects
{
	[Serializable]
	[ComVisible(true)]
	public delegate			void				NodeEventHandler(int RecipeIndex,int nodeIndex,RecipeEventArgs e);

	[Serializable]
	[ComVisible(true)]
	public delegate			void				RecipeEventHandler(int RecipeIndex,RecipeEventArgs e);

	[Serializable]
	[ComVisible(true)]
	public delegate			void				MessageEventHandler(RecipeEventArgs e);

}
