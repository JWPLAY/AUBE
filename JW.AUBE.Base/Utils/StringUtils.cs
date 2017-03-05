using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JW.AUBE.Base.Utils
{
	public static class StringUtils
	{
		/// <summary>
		/// 문자열을 좌측으로 부터 특정 길이만큼 자른다.
		/// </summary>
		/// <param name="text">기준 문자열</param>
		/// <param name="textLen">자를 문자열의 길이</param>
		/// <returns>반환 문자열</returns>
		public static string Left(this string text, int textLen)
		{
			string convText;

			if (text.Length < textLen)
			{
				textLen = text.Length;
			}
			convText = text.Substring(0, textLen);
			return convText;
		}

		/// <summary>
		/// 문자열을 우측으로 부터 특정 길이만큼 자른다.
		/// </summary>
		/// <param name="text">기준 문자열</param>
		/// <param name="textLen">자를 문자열의 길이</param>
		/// <returns>반환 문자열</returns>
		public static string Right(this string text, int textLen)
		{
			string convText;
			if (text.Length < textLen)
			{
				textLen = text.Length;
			}
			convText = text.Substring(text.Length - textLen, textLen);
			return convText;
		}

		/// <summary>
		/// 문자열을 지정한 자리만큼 자른다.
		/// </summary>
		/// <param name="text">기준 문자열</param>
		/// <param name="startInt">문자열의 시작자리수</param>
		/// <param name="endInt">문자열의 종료자리수</param>
		/// <returns>반환 문자열</returns>
		public static string Mid(this string text, int startInt, int endInt)
		{
			string convText;
			if (startInt < text.Length || endInt < text.Length)
			{
				convText = text.Substring(startInt, endInt);
				return convText;
			}
			else
			{
				return text;
			}
		}

		/// <summary>
		/// 대소문자로 구성된 문자열에서 (_)를 대문자 앞에 추가하고 대문자로 변환하는 함수
		/// 첫번째 문자열은 제외된다.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToUpperUnderscoreBySb(this string str)
		{
			var i = 0;
			var sb = new StringBuilder();
			foreach (char c in str)
			{
				if (char.IsUpper(c) && i > 0)
				{
					sb.Append("_");
				}
				sb.Append(c);
				i++;
			}
			return sb.ToString().ToUpper();
		}

		public static string ToUpperUnderscoreByLinq(this string str)
		{
			var converted = str.Select(x => char.IsUpper(x) ? string.Concat("_", x) : x.ToString());
			var singleString = converted.Aggregate((a, b) => a + b);
			if (singleString.Left(1).Equals("_"))
			{
				singleString = singleString.Right(singleString.Length - 1);
			}
			return singleString.ToUpper();
		}

		public static string ToUpperUnderscoreByPattern(this string str)
		{
			return Regex.Replace(str, "([a-z])([A-Z])", "$1_$2").ToUpper();
		}

		public static string ToUnderscore(this string str)
		{
			return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString()));
		}

		public static string ToCamelCase(this string str)
		{
			string[] atoms = str.Split('_');
			StringBuilder camel = new StringBuilder();
			TextInfo ti = new CultureInfo("en-US", false).TextInfo;
			foreach (string atom in atoms)
			{
				camel.Append(ti.ToTitleCase(atom.ToLower()));
			}
			return camel.ToString();
		}

		public static string NumberCheck(string num)
		{
			var retValue = string.Empty;

			var regex = new Regex(@"^[0-9]{1,10}$");

			if ((num.Length > 1) && (num.Substring(0, 1) == "-"))
			{
				retValue = "-";
			}
			for (var i = 0; i < num.Length; i++)
			{
				var ismatch = regex.IsMatch(num[i].ToString());
				if (!ismatch)
				{
					continue;
				}
				else
				{
					retValue += num[i];
				}
			}
			return retValue;
		}

		public enum StringAlignType
		{
			TEL
			,
			POST
			,
			BIZ
			,
			PERSON
			,
			DATE
			,
			DATEHAN
		}

		public static string StringAlign(StringAlignType type, string da)
		{
			var data = string.Empty;

			da = NumberCheck(da);
			if (da.Length < 5)
			{
				return da;
			}
			switch (type)
			{
				case StringAlignType.TEL:
					if (da.Length > 8)
					{
						if (da.Substring(0, 2) == "02")
						{
							if (da.Length < 10)
							{
								data = string.Format("{0}-{1}-{2}", da.Substring(0, 2), da.Substring(2, 3), da.Substring(5));
							}
							else
							{
								data = string.Format("{0}-{1}-{2}", da.Substring(0, 2), da.Substring(2, 4), da.Substring(6));
							}
						}
						else
						{
							if (da.Length < 11)
							{
								data = string.Format("{0}-{1}-{2}", da.Substring(0, 3), da.Substring(3, 3), da.Substring(6));
							}
							else
							{
								data = string.Format("{0}-{1}-{2}", da.Substring(0, 3), da.Substring(3, 4), da.Substring(7));
							}
						}
					}
					else
					{
						data = string.Format("{0}-{1}", da.Substring(0, da.Length - 4), da.Substring(da.Length - 4));
					}
					break;


				case StringAlignType.POST:
					if (da.Length.Equals(6))
					{
						data = string.Format("{0}-{1}", da.Substring(0, 3), da.Substring(3));
					}
					else
					{
						data = da;
					}
					break;

				case StringAlignType.BIZ:
					if (da.Length.Equals(10))
					{
						data = string.Format("{0}-{1}-{2}", da.Substring(0, 3), da.Substring(3, 2), da.Substring(5));
					}
					else
					{
						data = da;
					}
					break;
				case StringAlignType.PERSON:
					if (da.Length.Equals(13))
					{
						data = string.Format("{0}-{1}", da.Substring(0, 6), da.Substring(6));
					}
					else
					{
						data = da;
					}
					break;
				case StringAlignType.DATE:
					if (da.Length.Equals(8))
					{
						data = string.Format("{0}-{1}-{2}", da.Substring(0, 4), da.Substring(4, 2), da.Substring(6));
					}
					else
					{
						if (da.Length.Equals(14))
						{
							data = string.Format("{0}-{1}-{2} {3}:{4}:{5}", da.Substring(0, 4), da.Substring(4, 2), da.Substring(6, 2), da.Substring(8, 2), da.Substring(10, 2), da.Substring(12));
						}
						else
						{
							data = da;
						}
					}
					break;

				case StringAlignType.DATEHAN:
					if (da.Length.Equals(8))
					{
						data = string.Format("{0}년{1}월{2}일", da.Substring(0, 4), da.Substring(4, 2), da.Substring(6));
					}
					else
					{
						if (da.Length.Equals(14))
						{
							data = string.Format("{0}년{1}월{2}일  {3}시{4}분{5}초", da.Substring(0, 4), da.Substring(4, 2), da.Substring(6, 2), da.Substring(8, 2), da.Substring(10, 2), da.Substring(12));
						}
						else
						{
							data = da;
						}
					}
					break;

				default:
					break;
			}

			return data;
		}
	}
}
