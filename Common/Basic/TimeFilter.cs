using System;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	[Serializable]
    public class TimeFilter
    {
		#region Private members
		private TimeRangeType _type;
		private DateTime _from;
		private DateTime _to;
        private int _N;
		#endregion

        #region Properties
        public TimeRangeType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public DateTime From
        {
			get 
			{
				switch (_type)
				{
					case TimeRangeType.FromDateToDate:
						return _from;
					case TimeRangeType.Last12Hours:
						return DateTime.Now.AddHours(-12);
					case TimeRangeType.Last2Weeks:
						return DateTime.Now.AddDays(-14);
					case TimeRangeType.Last3Weeks:
						return DateTime.Now.AddDays(-21);
					case TimeRangeType.Last6Hours:
						return DateTime.Now.AddHours(-6);
					case TimeRangeType.LastOneDay:
						return DateTime.Now.AddDays(-1);
					case TimeRangeType.LastOneHour:
						return DateTime.Now.AddHours(-1);
					case TimeRangeType.LastOneMonth:
						return DateTime.Now.AddMonths(-1);
					case TimeRangeType.LastOneWeek:
						return DateTime.Now.AddDays(-7);
                    case TimeRangeType.LastNHours:
                        return DateTime.Now.AddHours(-_N);
                    case TimeRangeType.LastNDays:
                        return DateTime.Now.AddDays(-_N);
                    case TimeRangeType.LastNWeeks:
                        return DateTime.Now.AddDays(-_N * 7);
					default:
						return DateTime.Now;
				}
			}
			set 
			{ 
				_from = value;
			}
        }
        public DateTime To
        {
			get
			{
                switch (_type)
                {
                    case TimeRangeType.FromDateToDate:
                        return _to;
                    default:
                        return DateTime.Now;
                }
			}
			set 
			{
				_to = value;
			}
        }
        public int N
        {
            get { return _N; }
            set { _N = value; }
        }
        #endregion

		#region Public Methods
		public string GetSqlWhere()
		{
			return string.Format("[TestDate] BETWEEN '{0}' AND '{1}'", this.From.ToString("yyyy-MM-dd HH:mm:ss"), this.To.ToString("yyyy-MM-dd HH:mm:ss"));
		}

		public override string ToString()
		{
			return string.Format("From: {0} To: {1}", this.From.ToString("MMM dd yyyy HH:mm:ss"), this.To.ToString("MMM dd yyyy HH:mm:ss"));
		}

		public string GetSqlWhere_DataMart()
		{
			return string.Format("[DataStamp] BETWEEN '{0}' AND '{1}'", this.From.ToString("yyyy-MM-dd HH:mm:ss"), this.To.ToString("yyyy-MM-dd HH:mm:ss"));
		}
		#endregion
    }
}