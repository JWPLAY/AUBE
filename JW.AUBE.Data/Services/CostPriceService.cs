using System;
using System.Data;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Model.Profit;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class CostPriceService
	{
		public static DBTranSet GetList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<CostPriceListModel>("GetCostPriceList", req.TranList[0].Parameter);
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

		public static DBTranSet Save(DBTranSet req)
		{
			bool isTran = false;

			try
			{
				if (req == null)
					throw new Exception("처리할 요청이 정확하지 않습니다.");

				if (req.TranList == null || req.TranList.Length == 0)
					throw new Exception("처리할 데이터가 없습니다.");

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					if (req.TranList.Length > 0)
					{
						if (req.TranList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.TranList[0].Data as DataTable).ToDataMapList()[0];

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							DaoFactory.Instance.Insert("InsertCostPrice", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							DaoFactory.Instance.Update("UpdateCostPrice", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						{
							DaoFactory.Instance.Update("DeleteCostPrice", data);
						}
						req.TranList[0].ErrorNumber = 0;
						req.TranList[0].ErrorMessage = "SUCCESS";
						req.TranList[0].ReturnValue = null;
					}
					
					if (isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch(Exception ex)
				{
					if (isTran)
						DaoFactory.Instance.RollBackTransaction();

					throw new Exception(ex.Message);
				}
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
