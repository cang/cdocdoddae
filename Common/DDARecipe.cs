using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for DDARecipe.
	/// </summary>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class DDARecipe
	{
		protected int _RecipeKey;
		protected string _RecipeName= string.Empty;

		protected int		_SCKey;
		protected string	_SignatureName;
		public	  int		SignatureCode;

		protected int _PrevRecipeKey;
		protected string _PrevRecipeName;

		protected string _Description=string.Empty;
		protected byte[] _RawData = null;

		protected eRecipeStatus	_Status;

		public	  string	TesterType = string.Empty;//all 

		public	 bool		BreakWhenFound = false;

		public int		RecipeKey
		{
			get
			{
				return _RecipeKey;
			}
			set
			{
				_RecipeKey = value;
			}
		}


		public string	RecipeName
		{
			get
			{
				return _RecipeName;
			}
			set
			{
				_RecipeName = value;
			}
		}


		public int		SCKey
		{
			get
			{
				return _SCKey;
			}
			set
			{
				_SCKey = value;
			}
		}

		public string		SignatureName
		{
			get
			{
				return _SignatureName;
			}
			set
			{
				_SignatureName = value;
			}
		}

		public int		PrevRecipeKey
		{
			get
			{
				return _PrevRecipeKey;
			}
			set
			{
				_PrevRecipeKey = value;
			}
		}

		public string		PrevRecipeName
		{
			get
			{
				return _PrevRecipeName;
			}
			set
			{
				_PrevRecipeName = value;
			}
		}


		public byte[] RawData
		{
			get
			{
				return _RawData;
			}
			set
			{
				_RawData = value;
			}
		}

		public string	Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		public eRecipeStatus	Status
		{
			get
			{
				return _Status;
			}
			set
			{
				_Status = value;
			}
		}

		public DDARecipe(int recipekey, string recipename, int sckey, int prevrecipekey,byte[] rawdata,string description)
		{
			this.RecipeKey = recipekey;
			this.RecipeName=recipename;
			this.SCKey=sckey;
			this.PrevRecipeKey = prevrecipekey;
			this.RawData = rawdata;
			this.Description = description;
		}

		public DDARecipe(int recipekey, string recipename, int sckey, int prevrecipekey,byte[] rawdata,string description,string testertype,bool breakwhenfound) : this(recipekey, recipename, sckey, prevrecipekey,rawdata,description)
		{
			this.TesterType  = testertype;
			this.BreakWhenFound = breakwhenfound;
		}

		public DDARecipe()
		{
		}
	}


}
