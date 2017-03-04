using System;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Data.Mappers;

namespace JW.AUBE.Data.Utils
{
	public static class CommonDataUtils
	{
		public static string GetProductCode(string productType)
		{
			try
			{
				string return_code = string.Empty;
				string product_code = productType + GetYearCode() + GetMonthCode();
				var code = DaoFactory.Instance.QueryForObject<string>("GetProductCode", new DataMap() { { "PRODUCT_CODE", product_code } });
				if (!string.IsNullOrEmpty(code))
				{
					return_code = code.Substring(0, 3) + (code.Substring(3, 3).ToIntegerNullToZero() + 1).ToString("000");
				}
				else
				{
					return_code = product_code + "001";
				}
				return return_code;
			}
			catch
			{
				throw;
			}
		}

		public static string GetYearCode()
		{
			string[] yearcode = GetAlphaCode();
			return yearcode[DateTime.Now.Year - 2017];
		}

		public static string GetMonthCode()
		{
			string[] monthcode = GetAlphaCode();
			return monthcode[DateTime.Now.Month - 1];
		}

		public static string[] GetAlphaCode()
		{
			return new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
		}
	}
}
