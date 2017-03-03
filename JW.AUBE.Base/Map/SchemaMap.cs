using System;
using System.Collections.Generic;

namespace JW.AUBE.Base.Map
{
	[Serializable]
    public class SchemaMap : Dictionary<string, Type>
    {
        public Type GetValue(string key)
        {
            Type val;
            if (TryGetValue(key, out val))
                return val;
            else
                return null;
        }

		public void SetValue(string key, Type value)
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
    }
}
