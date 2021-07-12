using System;
using System.Collections;
using System.Text;

namespace SiGlaz.Common.DDA
{
	public enum DDADBType
	{
		DDADB,
		DDAStagingArea,
		DDAArchives,
		DDADataMarts,
	}

	public enum FunctionType
	{
		DataSource,
		SingleLayer,
		SignatureOfSurface,
		SourceOfDisk,
		YieldTrendPlot,
		PerformanceIndicators,
	}

	public enum TimeRangeType 
	{
		LastOneHour,
		Last6Hours,
		Last12Hours,
		LastOneDay,
		LastOneWeek,
		Last2Weeks,
		Last3Weeks,
		LastOneMonth,
		FromDateToDate,
		LastNHours,
		LastNDays,
		LastNWeeks,
	}

	public enum ConditionFieldType 
	{
		String = 1,
		Number,
		Date,
		Time,
		Boolean,
	} 

	public enum ViewMode
	{
		Disk,
		Flat
	}

	public enum ViewSurface : int
	{
		All = 0,
		Top,
		Bottom,
	}

	
	public enum eOutputType
	{
		Keep,
		Remove
	}

	public enum eMarkLocation
	{
		Top,
		Up,
		Left,
		Bottom,
		Down,
		Right
	}

	
	public enum WebServicetypeType
	{
		None,
		Root,
		DataSource,
		IDAPortalWebService,
	}

    public enum RuleType : int 
	{
        IDAAlarmControlRule = 0,
		ControlRule = 0, 
        SurfScanRule,
        HoldRateRule,
        AutoLearnRule,
        LayerRepeaterRule,
        SignatureRule,
        ExcursionRule,
	};

    public enum WECORuleType : int 
	{ 
        None = 0,
		AnyPointAbove3Sigma, 
		TwoOutOfThreeConsecutivePointsAbove2Sigma, 
		FourOutOfFiveConsecutivePointsAboveSigma, 
		EightConsecutivePointsAboveMean, 
	};

    public enum WECORuleThresholdType : int
    {
        Auto = 0,
        Custom,
        LookupTable,
    };

    public enum ConditionType : int
    {
        Basic = 0,
        Advanced,
    }

    public enum AnalyzingRuleType : int 
	{ 
        None = 0,
		LinearRule, 
		TrendUpRule,
        WECORule, 
	};

	public enum Severity : int
	{
        None = 0,
		VeryLow,
		Low,
		Medium,
		High,
		VeryHigh,
	};

    public enum ErrorCode : int
    {
        OK = 0,
		UNKNOWN_ERROR,
        NO_DATA,
        INVALID_SQL_STATEMENT,
        NO_AUTHORIZED,
        NO_DATA_TO_ANALYZE
    };

    public enum ValueAxisUnit : int
    {
		WaferChipCount = 0,
		SignatureChipCount,
		Yield,
		AverageProcessingTime,
    };

	public enum CategoryAxisUnit : int
	{
		Wafer = 0,
		Lot,
		Hour,
		Day,
		Week,
		Month,
	};

	public enum ChartMatrix : int
	{
		// Ox = Wafer
		Wafer_WaferChipCount = 0,
		Wafer_SignatureChipCount,

		// Ox = Lot
		Lot_WaferChipCount = 2,
		Lot_SignatureChipCount,
	};

    public enum SortType : int
    {
        None,
        Ascending,
        Descending,
    };

    public enum ChartType : int
    {
        Line = 0,
        Column,
    }   

	public enum eTrendLineBy : byte
	{
		Slot,
		Day,
		Month,
		Year
	}

	public enum TableStatus : int
	{
		All = 0,
		OnlyOOC,
	}

	public enum eSurface : byte
	{
		Top,
		Bottom
	}

	public enum ViewType : int
	{
		All = 0,
		SourceWithSignature,
		SourceWithoutSignature,
	}


	public enum eRecipeStatus : byte
	{
		Normal,
		Running,
		Edited
	}

	public enum CubeType : int
	{
		Yield2H,
		Yield4H,
		Performance,
		Yield2H_V2,
	}

	public enum ExportType : int
	{
		DataAndImage = 0,
		OnlyData,
	}

	public enum AxisType : int 
	{
		DiscCount = 0,
		Yield
	}
}
