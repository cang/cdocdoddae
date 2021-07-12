using System;
using System.Collections;

using SiGlaz.Common.DDA.Basic;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for SingleResult.
	/// </summary>
	public class ProcessControlResult
	{
		#region Private members
		private string _chartTitle;
		private string _valueLabel;
		private string _categoryLabel;
		private double[] _valueData;
		private string[] _categoryData;
		private double _mean;
		private double _deviation;
		private ArrayList _wecoRuleResults;
		private bool _isOOC;
		private Error _error;
		#endregion

		#region Properties
		public string ChartTitle
		{
			get { return _chartTitle; }
			set { _chartTitle = value; }
		}
		public string ValueLabel
		{
			get { return _valueLabel; }
			set { _valueLabel = value; }
		}
		public string CategoryLabel
		{
			get { return _categoryLabel; }
			set { _categoryLabel = value; }
		}
		public double[] ValueData
		{
			get { return _valueData; }
			set { _valueData = value; }
		}
		public string[] CategoryData
		{
			get { return _categoryData; }
			set { _categoryData = value; }
		}
		public double Mean
		{
			get { return _mean; }
			set { _mean = value; }
		}
		public double Deviation
		{
			get { return _deviation; }
			set { _deviation = value; }
		}
		public Error Error
		{
			get { return _error; }
			set { _error = value; }
		}
		public WECORuleResult[] WECORuleResults
		{
			get { return (WECORuleResult[])_wecoRuleResults.ToArray(typeof(WECORuleResult)); }
			set
			{
				_wecoRuleResults.Clear();
				if (value != null) _wecoRuleResults.AddRange(value);
			}
		}
		public bool IsOOC
		{
			get { return _isOOC; }
			set { _isOOC = value; }
		}
		#endregion

		#region Constructors
		public ProcessControlResult()
		{
			_error = new Error();
			_wecoRuleResults = new ArrayList();
		}
		#endregion

		public void AddWECORuleResult(WECORuleResult wecoRuleResult)
		{
			_wecoRuleResults.Add(wecoRuleResult);
		}
	}
}
