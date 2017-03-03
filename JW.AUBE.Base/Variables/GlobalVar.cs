using JW.AUBE.Base.Map;

namespace JW.AUBE.Base.Variables
{
	public static class GlobalVar
	{
		static GlobalVar()
		{
			Settings = new DataMap();
		}

		public static string Version { get; set; }

		public static string ServerUrl { get; set; }

		public static string DatabaseId { get; set; }

		public static DataMap Settings { get; set; }
	}
}
