using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Model.Profit;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class CostPriceService
	{
		public static WasRequest GetList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<CostPriceListModel>("GetCostPriceList", req.Parameter);
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

		public static WasRequest Save(WasRequest req)
		{
			bool isTran = false;

			try
			{
				if (req == null)
					throw new Exception("처리할 요청이 정확하지 않습니다.");

				if (req.DataList == null || req.DataList.Count == 0)
					throw new Exception("처리할 데이터가 없습니다.");

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.DataList[0].Data as DataTable).ToDataMapList()[0];

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
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = null;
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
