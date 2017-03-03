using JW.AUBE.Base.Constants;
using Microsoft.Win32;

namespace JW.AUBE.Base.Utils
{
	public class RegistryUtils
	{
		public static string GetValue(string path, string key)
		{
			try
			{
				var keyPath = string.Format(@"{0}\{1}", RegiPathConsts.ROOT, path);
				var reg = Registry.CurrentUser.OpenSubKey(keyPath, true);
				if (reg == null)
				{
					reg = Registry.CurrentUser.CreateSubKey(keyPath);
				}
				return reg.GetValue(key).ToString();
			}
			catch
			{
				return null;
			}
		}

		public static void SetValue(string path, string key, string value)
		{
			var keyPath = string.Format(@"{0}\{1}", RegiPathConsts.ROOT, path);
			var reg = Registry.CurrentUser.OpenSubKey(keyPath, true);
			if (reg == null)
			{
				reg = Registry.CurrentUser.CreateSubKey(keyPath);
			}
			reg.SetValue(key, value);
		}
	}
}
