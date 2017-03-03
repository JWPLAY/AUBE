using System.Configuration;

namespace JW.AUBE.Base.Utils
{
	public class AppConfigUtils
	{
		/// <summary>
		/// App.Config의 값을 읽어온다.
		/// </summary>
		/// <param name="key">키값</param>
		/// <returns></returns>
		public static string GetValue(string key)
		{
			try
			{
				string result;
				var config = new AppSettingsReader();
				result = ((string)(config.GetValue(key, typeof(string))));

				return result;
			}
			catch
			{
				return null;
			}
		}
	}
}
