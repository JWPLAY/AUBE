using System;
using System.Collections.Generic;
using System.Data;

namespace JW.AUBE.Base.Utils
{
	public static class ExtensionUtils
	{
		public static bool YnToBool(this object obj)
		{
			if (obj == null || !(obj is string))
			{
				return false;
			}
			return obj.ToString() == "Y" ? true : false;
		}

		public static bool YnToBool(this string str)
		{
			return str == "Y" ? true : false;
		}

		public static string ToDateTime(this string str, string format = "yyyyMMdd")
		{
			return str.Length == 8 ? DateTime.ParseExact(str, "yyyyMMdd", null).ToString(format) : DateTime.Parse(str).ToString(format);
		}

		public static string ToDateTime(this object obj, string format = "yyyyMMdd")
		{
			if (obj == null || !(obj is string))
			{
				return string.Empty;
			}
			return obj.ToString().ToDateTime(format);
		}

		public static string ToLowerUpper(this string str, bool? isUpper)
		{
			if (isUpper != null)
			{
				if ((bool)isUpper)
				{
					str = str.ToUpper();
				}
				else
				{
					str = str.ToLower();
				}
			}

			return str;
		}

		public static decimal ToDecimalNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}

		public static int ToIntegerNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		public static int ToInteger(this decimal d)
		{
			return Convert.ToInt32(d);
		}

		public static int ToInteger(this double d)
		{
			return Convert.ToInt32(d);
		}

		public static double ToDoubleNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToDouble(obj);
			}
		}

		public static bool ToBooleanNullToFalse(this object obj)
		{
			if (obj is bool)
			{
				if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
				{
					return false;
				}
				else
				{
					return (bool)obj;
				}
			}
			else
			{
				if (obj is string)
				{
					if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
					{
						return false;
					}
					else
					{
						return obj.ToString() == "Y" ? true : false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		public static string ToStringNullToEmpty(this object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return string.Empty;
			}
			else
			{
				return obj.ToString();
			}
		}

		public static bool IsNullOrEmpty(this object obj)
		{
			return string.IsNullOrEmpty(obj.ToStringNullToEmpty());
		}

		public static DataTable ToEmptyDataTable(Dictionary<string, Type> columns)
		{
			var dt = new DataTable();
			foreach (KeyValuePair<string, Type> columnName in columns)
			{
				dt.Columns.Add(columnName.Key, columnName.Value);
			}

			return dt;
		}
	}
}
