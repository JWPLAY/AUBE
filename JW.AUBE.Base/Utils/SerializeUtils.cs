using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace JW.AUBE.Base.Utils
{
	public static class SerializeUtils
	{
		/// <summary>
		/// XML 포맷으로 직렬화 합니다.
		/// </summary>
		/// <param name="obj">직렬화할 Object</param>
		/// <returns>직렬화된 XML 문자열</returns>
		public static string Serialize(this object obj)
		{
			var ser = new XmlSerializer(obj.GetType());
			var sb = new System.Text.StringBuilder();
			var writer = new System.IO.StringWriter(sb);

			if (obj.GetType() == typeof(DataTable))
			{
				var dtTemp = (DataTable)obj;
				if (string.IsNullOrEmpty(dtTemp.TableName))
				{
					dtTemp.TableName = "NONAME";
				}
			}

			ser.Serialize(writer, obj);

			var doc = new XmlDocument();
			doc.LoadXml(sb.ToString());
			var xml = doc.InnerXml;
			return xml;
		}

		/// <summary>
		/// 직렬화된 XML 문자열을 Object 역직렬화 합니다.
		/// </summary>
		/// <param name="xml">직렬화된 XML 문자열</param>
		/// <param name="objType">직렬화한 Object 의 타입</param>
		/// <example>DataTable dataTable = (DataTable)stringValue.DeSerialize(typeof(DataTable));</example>
		/// <returns>역직렬화된 Object</returns>
		public static object DeSerialize(this string xml, Type objType)
		{
			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var reader = new XmlNodeReader(doc.DocumentElement);
			var ser = new XmlSerializer(objType);
			var obj = ser.Deserialize(reader);
			return obj;
		}
	}
}
