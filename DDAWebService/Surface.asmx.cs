using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using SiGlaz.DAL;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

namespace DDAWebService
{
	/// <summary>
	/// Summary description for Surface.
	/// </summary>
	/// 
	[WebService(Namespace="http://siglaz.com")]
	public class Surface : System.Web.Services.WebService
	{
		public Surface()
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

		
		#region query new wafer

		[WebMethod()]
		public ArrayList GetNewSurfaceKey(int recipeid,int prevrecipid,short fabkey,DateTime fromDate,string TestGradeList,int numbersurfaces)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.GetNewSurfaceKey(recipeid,prevrecipid,fabkey,fromDate,TestGradeList,numbersurfaces);
		}

		[WebMethod()]
		public ResultBase GetPrevRecipeKey(int recipeid)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.GetPrevRecipeKey(recipeid);
		}

		[WebMethod()]
		public byte[] GetResultDetail(int recipeid,long surfacekey)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.GetResultDetail(recipeid,surfacekey);
		}

		[WebMethod()]
		public byte[] GetProcessedResultDetail(int recipeid,long surfacekey)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.GetProcessedResultDetail(recipeid,surfacekey);
		}

		[WebMethod()]
		public bool HasSignature(long surfacekey)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.HasSignature(surfacekey);
		}

		[WebMethod()]
		public void DeleteNoSignature(long surfacekey,int ProcessingDuration)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			proxy.DeleteNoSignature(surfacekey,ProcessingDuration);
		}

		[WebMethod()]
		public bool	CheckProcessed(int recipekey,long surfacekey)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.CheckProcessed(recipekey,surfacekey);
		}

		#endregion query new wafer


		#region insert result

		[WebMethod()]
		public void SurfaceUpdateProcessingDuration(long surfacekey,int ProcessingDuration)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			proxy.SurfaceUpdateProcessingDuration(surfacekey,ProcessingDuration);
		}

		[WebMethod()]
		public ResultBase Processed_Insert(int recipekey,long surfacekey,bool BreakWhenFound,bool finish)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.Processed_Insert(recipekey,surfacekey,BreakWhenFound,finish);
		}

		[WebMethod()]
		public ResultBase Processed_Delete(int recipekey,long surfacekey)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.Processed_Delete(recipekey,surfacekey);
		}

		[WebMethod()]
		public ResultBase	Results_Insert(SiGlaz.Common.DDA.SurfaceResult resultobj)
		{
			SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
			return proxy.Results_Insert(resultobj);
		}

		#endregion insert result
	}
}
