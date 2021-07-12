using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA;


namespace DDAWebService
{
	/// <summary>
	/// Summary description for Recipe.
	/// </summary>
	/// 
	[WebService(Namespace="http://siglaz.com")]
	public class Recipe : System.Web.Services.WebService
	{
		public Recipe()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

		[WebMethod()]
		public DataSetResult RecipeListToDataset()
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.RecipeListToDataset();
		}

		[WebMethod()]
		public string RecipeNameByKey(int key)
		{			
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.RecipeNameByKey(key);
		}

		[WebMethod()]
		public DDARecipe GetRecipeByKey(int key)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.GetRecipeByKey(key);
		}


		[WebMethod()]
		public RecipeListResult RecipeList()
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.RecipeList();
		}

		[WebMethod()]
		public BinaryResult GetRawData(long key)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.GetRawData(key);
		}

		[WebMethod()]
		public ResultBase DeleteRecipe(long key)
		{	
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.DeleteRecipe(key);
		}

		[WebMethod()]
		public ResultBase InsertRecipe(SiGlaz.Common.DDA.DDARecipe _recipe)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.InsertRecipe(_recipe);
		}

		[WebMethod()]
		public ResultBase InsertRecipeForce(SiGlaz.Common.DDA.DDARecipe _recipe)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.InsertRecipeForce(_recipe);
		}


		[WebMethod()]
		public ResultBase UpdateRecipe(SiGlaz.Common.DDA.DDARecipe _recipe)
		{			
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.UpdateRecipe(_recipe);
		}

		[WebMethod()]
		public eRecipeStatus GetStatus(int recipeKey)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.GetStatus(recipeKey);	
		}

		[WebMethod(MessageName="UpdateStatus")]
		public void UpdateStatus(int recipeKey,eRecipeStatus status)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			proxy.UpdateStatus(recipeKey,status);
		}

		[WebMethod()]
		public bool	CanDelete()
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.CanDelete();
		}

		[WebMethod()]
		public bool RecipeIsEdited(int recipeKey)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.RecipeIsEdited(recipeKey);
		}

		[WebMethod()]
		public void ResetRecipeStatus()
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			proxy.ResetRecipeStatus();
		}

		[WebMethod()]
		public ArrayList GetNextRecipeKey(int recipeid,bool onelevel)
		{
			SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
			return proxy.GetNextRecipeKey(recipeid,onelevel);
		}


	}
}
