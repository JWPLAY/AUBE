using System;

namespace JW.AUBE.Core.Models
{
	public class ElapseTime
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public ElapseTime()
		{
			StartTime = DateTime.Now;
			EndTime = DateTime.Now;
		}
		public int ElapseSeconds()
		{
			return Math.Abs(StartTime.Subtract(EndTime).Seconds);
		}
		public int ElapseMinutes()
		{
			return Math.Abs(StartTime.Subtract(EndTime).Minutes);
		}
		public int ElapseHours()
		{
			return Math.Abs(StartTime.Subtract(EndTime).Hours);
		}
	}
}
