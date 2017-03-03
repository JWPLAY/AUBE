using System;
using System.ComponentModel;
using System.Linq;

namespace JW.AUBE.Base.Utils
{
	public static class EnumUtils
	{
		/// <summary>
		/// Enum Value로 Description 읽어오기
		/// </summary>
		/// <param name="value">Enum Value</param>
		/// <returns>Description</returns>
		public static string GetDescriptionFromEnumValue(Enum value)
		{
			var attribute = value.GetType()
				.GetField(value.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false)
				.SingleOrDefault() as DescriptionAttribute;
			return attribute == null ? value.ToString() : attribute.Description;
		}

		/// <summary>
		/// Enum Description으로 Value읽어오기
		/// </summary>
		/// <typeparam name="T">Enum 형식</typeparam>
		/// <param name="description">Description</param>
		/// <returns>Enum Value</returns>
		public static T GetEnumValueFromDescription<T>(string description)
		{
			var type = typeof(T);
			if (!type.IsEnum)
			{
				throw new ArgumentException();
			}
			var fields = type.GetFields();
			var field = fields
							.SelectMany(f => f.GetCustomAttributes(
								typeof(DescriptionAttribute), false), (
			f, a) => new
			{ Field = f, Att = a })
							.Where(a => ((DescriptionAttribute)a.Att)
								.Description == description).SingleOrDefault();
			return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
		}
	}
}
