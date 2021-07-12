using System;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for SchedularItem.
	/// </summary>
	public class SchedularItem
	{
		public bool					RunByDay = false;//true = RunningModeByDay,false = RunningModeByDelay
		public RunningModeByDelay	delayMode;
		public int					delay = 1;

		public RunningModeByDay		dayMode;
		public DateTime				atTime = DateTime.Now;

		public SchedularItem()
		{
		}
	}

	public enum RunningModeByDelay
	{
		Minute,
		Hour
	}

	public enum RunningModeByDay
	{
		EveryDay,
		EveryMonday,
		EveryTuesday,
		EveryWednesday,
		EveryThursday,
		EveryFriday,
		EverySatuday,
		EverySunday
	}
}
