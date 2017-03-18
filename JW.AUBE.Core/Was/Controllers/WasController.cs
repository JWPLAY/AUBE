using System;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;

namespace JW.AUBE.Core.Was.Controllers
{
	public class WasController
	{
		private const string assemblyName = @"JW.AUBE.Service";

		public WasRequest Execute(WasRequest req)
		{
			var namespaceName = string.Format("JW.AUBE.Service.Services.{0}Service", req.ServiceId);
			var methodName = req.ProcessId;

			try
			{
				Logger.Info(string.Format("WasController=> {0}.{1}", namespaceName, methodName));
				var result = (WasRequest)TypeUtils.InvokeMethodByParam(assemblyName, namespaceName, methodName, req);
				return result;
			}
			catch (Exception ex)
			{
				Logger.Error("WasController=> " + ex.Message);
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}
	}
}
