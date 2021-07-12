using System;
using System.Collections;
//using SiGlaz.DDA.Engine;

using SSA.SystemFrameworks;


namespace DDARecipe
{
	public class ResultItem
	{
		public ResultType				Type;
		public KlarfParserFile			ResultMap;
		public ArrayList				ResultMultilayer;

		public string					SignatureName = string.Empty;
		public int						SignatureID;
		public int						SignatureCode;

		public ResultItem()
		{
		}

		public ResultItem(KlarfParserFile map)
		{
			this.ResultMap = map;
		}

		public ResultItem(int signaturekey,int signaturecode,string signatureName,KlarfParserFile map) : this(map)
		{
			this.SignatureID = signaturekey;
			this.SignatureCode = signaturecode;
			this.SignatureName = signatureName;
		}

		public ResultItem(int signaturekey,int signaturecode,string signatureName,KlarfParserFile map,ResultType type) : this(signaturekey,signaturecode,signatureName,map)
		{
			this.Type = type;
		}
	}


	public enum	ResultType
	{
		DefectList
		,Zonal
		,Pattern
	}

}
