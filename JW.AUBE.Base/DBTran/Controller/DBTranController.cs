using System;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.DBTran.Model;

namespace JW.AUBE.Base.DBTran.Controller
{
	public class DBTranController
	{
		private const string assemblyName = @"JW.AUBE.Service";

		public DBTranSet Execute(DBTranSet req)
		{
			var namespaceName = string.Format("JW.AUBE.Service.Services.{0}Service", req.ServiceId);
			var methodName = req.ProcessId;

			try
			{
				Logger.Info(string.Format("DBTranController=> {0}.{1}", namespaceName, methodName));
				var result = (DBTranSet)TypeUtils.InvokeMethodByParam(assemblyName, namespaceName, methodName, req);
				return result;
			}
			catch (Exception ex)
			{
				Logger.Error("DBTranController=> " + ex.Message);
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}
	}
}
