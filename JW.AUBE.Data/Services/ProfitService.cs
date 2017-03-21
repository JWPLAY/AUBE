using System;
using System.Collections.Generic;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Model.Profit;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class ProfitService
	{
		public static WasRequest GetList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<ProfitListModel>("GetProfitList", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData() { Data = list }
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}
	}
}
