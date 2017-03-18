using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;

namespace JW.AUBE.Service.Config
{
	public static class DatabaseConfig
	{
		public static string Id { get; set; }
		public static DataMap Connections { get; internal set; }
		public static string ConnectionString
		{
			get
			{
				return Connections.GetValue(Id).ToStringNullToEmpty();
			}
		}

		static DatabaseConfig()
		{
			Connections = new DataMap();
			Connections.SetValue("REAL", @"Data Source=JW-PLAY\SQLEXPRESS;Initial Catalog=AUBE;Integrated Security=True");
			Connections.SetValue("TEST", @"Data Source=JW-PLAY\SQLEXPRESS;Initial Catalog=AUBE;Integrated Security=True");
		}

		public static string GetConnectionString(string id = null)
		{
			if (string.IsNullOrEmpty(id))
			{
				id = Id;
			}
			return Connections.GetValue(id).ToStringNullToEmpty();
		}
	}
}
