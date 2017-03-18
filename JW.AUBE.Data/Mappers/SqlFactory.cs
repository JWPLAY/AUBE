using System.Data.SqlClient;
using JW.AUBE.Service.Config;
using Microsoft.ApplicationBlocks.Data;

namespace JW.AUBE.Service.Mappers
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
