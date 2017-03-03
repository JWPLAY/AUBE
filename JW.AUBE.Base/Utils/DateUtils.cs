using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace JW.AUBE.Base.Utils
{
	public class DateUtils
	{
		/// <summary>
		/// 문자열 8자리 Date를 문자열 10자리로 변경하여 반환한다.
		/// </summary>
		/// <param name="str">날짜문자열(yyyyMMdd)</param>
		/// <param name="separator">null, (.), (/)</param>
		/// <returns></returns>
		public static string String8To10(string str, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return string.Format("{0}{3}{1}{3}{2}", str.Substring(0, 4), str.Substring(4, 2), str.Substring(6, 2), separator);
		}

		/// <summary>
		/// 문자열 10자리 Date를 문자열 10자리로 변경하여 반환한다.
		/// 형식이 일치하지 않는 경우 맞추기 위한 것임(/ -> .)
		/// separator로 등록된 구분자로 변경한다.
		/// </summary>
		/// <param name="str">날짜문자열(yyyy/MM/dd)</param>
		/// <param name="separator">(.)</param>
		/// <returns></returns>
		public static string String10To10(string str, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return string.Format("{0}{3}{1}{3}{2}", str.Substring(0, 4), str.Substring(5, 2), str.Substring(8, 2), separator);
		}

		public static string DateTimeToString8(DateTime dt)
		{
			return string.Format("{0:yyyyMMdd}", dt);
		}

		/// <summary>
		/// DateTime형식을 문자열 10자리 값으로 변경하여 반환한다.
		/// </summary>
		/// <param name="dt">DateTime</param>
		/// <param name="separator">날짜구분문자</param>
		/// <returns></returns>
		public static string DateTimeToString10(DateTime dt, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return dt.ToString(string.Format("yyyy{0}MM{0}dd", separator));
		}

		/// <summary>
		/// DateTime형식을 문자열 19자리로 변경하여 반환한다.
		/// (yyyy.MM.dd HH:mm:ss)
		/// </summary>
		/// <param name="dt">DateTime</param>
		/// <param name="separator">날짜구분문자</param>
		/// <returns></returns>
		public static string DateTimeToString19(DateTime dt, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return dt.ToString(string.Format("yyyy{0}MM{0}dd HH:mm:ss", separator));
		}

		/// <summary>
		/// 10자리 문자열을 DateTime형식으로 변환하여 반환한다.
		/// </summary>
		/// <param name="str">날짜문자값(yyyy.MM.dd)</param>
		/// <param name="separator">날짜구분문자</param>
		/// <returns></returns>
		public static DateTime String10ToDateTime(string str, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return Convert.ToDateTime(str.Replace(".", "/"));
		}

		/// <summary>
		/// 8자리 문자열을 DateTime형식으로 변환하여 반환한다.
		/// </summary>
		/// <param name="str">날짜문자값</param>
		/// <returns></returns>
		public static DateTime String8ToDateTime(string str)
		{
			str = string.Format("{0}/{1}/{2}", str.Substring(0, 4), str.Substring(4, 2), str.Substring(6, 2));
			return Convert.ToDateTime(str);
		}

		/// <summary>
		/// 19자리 문자열을 DateTime형식으로 변환하여 반환한다.
		/// </summary>
		/// <param name="str">날짜문자값(yyyy.MM.dd HH:mm:ss)</param>
		/// <param name="separator">날짜구분문자</param>
		/// <returns></returns>
		public static DateTime String19ToDateTime(string str, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return DateTime.ParseExact(str, string.Format("yyyy{0}MM{0}dd HH:mm:ss", separator), null);
		}

		/// <summary>
		/// 16자리 문자열을 DateTime형식으로 변환하여 반환한다.
		/// </summary>
		/// <param name="str">날짜문자값(yyyy.MM.dd HH:mm)</param>
		/// <param name="separator">날짜구분문자</param>
		/// <returns></returns>
		public static DateTime String16ToDateTime(string str, string separator)
		{
			if (string.IsNullOrEmpty(separator))
			{
				separator = ".";
			}
			return DateTime.ParseExact(str, string.Format("yyyy{0}MM{0}dd HH:mm", separator), null);
		}

		/// <summary>
		/// 지정된 월과 연도의 날짜수를 구한다.
		/// </summary>
		/// <param name="dateStr">문자열로 표현된 일자(년월, 년월일)</param>
		/// <returns>일수</returns>
		public static int DaysInMonth(string dateStr)
		{
			int intYear;
			int intMonth;

			if (dateStr.Length == 6)
			{
				intYear = Convert.ToInt32(StringUtils.Left(dateStr, 4));
				intMonth = Convert.ToInt32(StringUtils.Right(dateStr, 2));
			}
			else
			{
				if (dateStr.Length == 8)
				{
					intYear = Convert.ToInt32(StringUtils.Left(dateStr, 4));
					intMonth = Convert.ToInt32(StringUtils.Right(StringUtils.Left(dateStr, 6), 2));
				}
				else
				{
					return 0;
				}
			}
			return DateTime.DaysInMonth(intYear, intMonth);
		}

		public static int WeeksInYear(DateTime date)
		{
			var cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
			return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
		}

		public static double NetworkDays(DateTime start, DateTime end,
											IEnumerable<DateTime> holidays = null,
											ITimePeriodCollection holidayPeriods = null)
		{
			var startDay = new Day(start < end ? start : end);
			var endDay = new Day(end > start ? end : start);
			if (startDay.Equals(endDay))
			{
				return 0;
			}

			var filter = new CalendarPeriodCollectorFilter();
			filter.AddWorkingWeekDays();
			if (holidays != null)
			{
				foreach (DateTime holiday in holidays)
				{
					filter.ExcludePeriods.Add(new Day(holiday));
				}
			}
			if (holidayPeriods != null)
			{
				filter.ExcludePeriods.AddAll(holidayPeriods);
			}

			var testPeriod = new CalendarTimeRange(start, end);
			var collector = new CalendarPeriodCollector(filter, testPeriod);
			collector.CollectDays();

			var networkDays = 0.0d;
			foreach (ICalendarTimeRange period in collector.Periods)
			{
				networkDays += Math.Round(period.Duration.TotalDays, 2);
			}
			return networkDays;
		}

		/// <summary>
		/// 지정한 문자열을 지정한 수만큼 반복한다.
		/// </summary>
		/// <param name="str">반복한 문자 혹은 문자열</param>
		/// <param name="len">반복할 횟수</param>
		/// <returns>반복한 후 반환하는 문자열</returns>
		public static string StrReplace(string str, int len)
		{
			var ret = string.Empty;
			for (var i = 0; i < len; i++)
			{
				ret += str;
			}
			return ret;
		}
	}
}
