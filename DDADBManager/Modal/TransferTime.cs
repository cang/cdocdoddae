using System;

namespace DDADBManager.Modal
{

	public class TransferTime
	{
		public bool					moveAllDAta=false;
		public bool					transferBeforeTime = false;
		public DateTime				datetime;
		public TransferDelayMode	delaymode;
		public int					delay=1;

		public TransferTime()
		{
		}
	}

	public enum TransferDelayMode
	{
		Minute,
		Hour,
		Day,
		Week,
		Month
	}

}
