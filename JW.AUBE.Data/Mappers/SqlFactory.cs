using System.Data.SqlClient;
using JW.AUBE.Data.Config;
using Microsoft.ApplicationBlocks.Data;

namespace JW.AUBE.Data.Mappers
{
	public class SqlFactory
	{
		public static SqlHelper Instance;
		public static SqlConnection Connection
		{
			get
			{
				return new SqlConnection(DatabaseConfig.ConnectionString);
			}
		}
	}
}
