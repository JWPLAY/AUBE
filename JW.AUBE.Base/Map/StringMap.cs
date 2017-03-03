using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace JW.AUBE.Base.Map
{
	[Serializable]
	public class StringMap : Dictionary<string, string>
	{
		public string GetValue(string key)
		{
			string val;
			if (base.TryGetValue(key, out val))
			{
				return val;
			}
			else
			{
				return null;
			}
		}

		public void SetValue(string key, string value)
		{
			if (ContainsKey(key))
			{
				this[key] = value;
			}
			else
			{
				Add(key, value);
			}
		}

		public StringMap()
			: base(StringComparer.InvariantCultureIgnoreCase)
		{
		}
		protected StringMap(SerializationInfo info, StreamingContext context)
		{
			var data = (List<Tuple<string, string>>)
			info.GetValue("data", typeof(List<Tuple<string, string>>));
			foreach (var item in data)
			{
				Add(item.Item1, item.Item2);
			}
		}
		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}
