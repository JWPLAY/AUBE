using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JW.AUBE.Base.Utils;

namespace JW.AUBE.Base.Map
{
	[Serializable]
	public class DataMap : Dictionary<string, object>
	{
		public object GetValue(string key)
		{
			object val;
			if (base.TryGetValue(key, out val))
			{
				return val;
			}
			else
			{
				return null;
			}
		}

		public string GetText(string key)
		{
			object val;
			if (base.TryGetValue(key, out val))
			{
				return val.ToStringNullToEmpty();
			}
			else
			{
				return null;
			}
		}

		public void SetValue(string key, object value)
		{
			if (value == DBNull.Value)
			{
				value = null;
			}
			if (ContainsKey(key))
			{
				this[key] = value;
			}
			else
			{
				Add(key, value);
			}
		}

		public DataMap()
			: base(StringComparer.InvariantCultureIgnoreCase)
		{
		}
		protected DataMap(SerializationInfo info, StreamingContext context)
		{
			var data = (List<Tuple<string, object>>)
			info.GetValue("data", typeof(List<Tuple<string, object>>));
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
