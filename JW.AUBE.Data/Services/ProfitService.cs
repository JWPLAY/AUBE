using System;
using System.Collections.Generic;
using  JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Model.Profit;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class ProfitService
	{
		public static DBTranSet GetList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<ProfitListModel>("GetProfitList", req.TranList[0].Parameter);
				req.TranList[0].Data = list;
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
