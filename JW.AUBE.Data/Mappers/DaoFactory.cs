
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace JW.AUBE.Data.Mappers
{
	public class DaoFactory
	{
		private static object syncLock = new object();
		private static ISqlMapper mapper = null;

		public static ISqlMapper Instance
		{
			get
			{
				try
				{
					if (mapper == null)
					{
						lock (syncLock)
						{
							if (mapper == null)
							{
								var dom = new DomSqlMapBuilder();
								var sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMap.config, JW.AUBE.Data");
								mapper = dom.Configure(sqlMapConfig);
							}
						}
					}
				}
				catch
				{
					throw;
				}
				return mapper;
			}
		}
	}
}
