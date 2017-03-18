namespace JW.AUBE.Base.Utils
{
	public static class InvokeMethods
	{
		public static string GetQuery(string sqlId)
		{
			try
			{
				const string assemblyName = "JW.AUBE.Service.Service";
				var query = string.Empty;

				var className = (sqlId.IndexOf('.') > 0) ? sqlId.Split('.')[0] : "CommonSQL";

				var namespaceAndTypeName = string.Format("{0}.{1}.{2}", assemblyName, "SqlQueries", className);

				var methodName = (sqlId.IndexOf('.') > 0) ? sqlId.Split('.')[1] : sqlId;

				query = (string)TypeUtils.InvokeMethodByParam(assemblyName, namespaceAndTypeName, methodName, null);

				return query;
			}
			catch
			{
				throw;
			}
		}
	}
}
