using JW.AUBE.Base.Variables;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Core.Was.Controllers;

namespace JW.AUBE.Core.Was.Helper
{
	public static class WasHelper
	{
		#region WasRequest

		public static WasRequest Request(WasRequest reqset)
		{
			try
			{
				reqset.DatabaseId = GlobalVar.DatabaseId;
				return (new WasController()).Execute(reqset);
			}
			catch
			{
				throw;
			}
		}

		//public static WasRequest Request(string serviceId, string processId, string sqlId, DataMap param)
		//{
		//	try
		//	{
		//		using (WasRequest reqset = new WasRequest()
		//		{
		//			ServiceId = serviceId,
		//			ProcessId = processId,
		//			DatabaseId = GlobalVar.DatabaseId,
		//			RequestList = new List<WasRequest>()
		//			{
		//				new WasRequest()
		//				{
		//					SqlId = sqlId,
		//					DataParams = param
		//				}
		//			}
		//		})
		//		{
		//			return Request(reqset);
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}

		//public static WasRequest Request(string serviceId, string processId, string sqlId, DataMap param, int pageNo, int pageSize)
		//{
		//	try
		//	{
		//		using(WasRequest reqset = new WasRequest()
		//		{
		//			ServiceId = serviceId,
		//			ProcessId = processId,
		//			DatabaseId = GlobalVar.DatabaseId,
		//			RequestList = new List<WasRequest>()
		//			{
		//				new WasRequest()
		//				{
		//					SqlId = sqlId,
		//					DataParams = param,
		//					Paging = new WasRequestDataPaging()
		//					{
		//						PageNo = pageNo,
		//						PageSize = pageSize
		//					}
		//				}
		//			}
		//		})
		//		{
		//			if (reqset.RequestList[0].DataParams == null)
		//				reqset.RequestList[0].DataParams = new DataMap();
		//			reqset.RequestList[0].DataParams.SetValue("PAGE_NO", pageNo);
		//			reqset.RequestList[0].DataParams.SetValue("PAGE_SIZE", pageSize);

		//			return Request(reqset);
		//			//return (new MisClient()).Execute(requests);
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}
		#endregion
	}
}
