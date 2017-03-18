using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Service.Mappers;
using JW.AUBE.Model.Inventory;
using JW.AUBE.Model.Production;

namespace JW.AUBE.Service.Services
{
	public static class InventoryService
	{
		public static WasRequest GetInventoryList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<InventoryListModel>("GetInventoryList", req.Parameter);
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

		public static WasRequest GetData(WasRequest req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<ProdTranDataModel>("GetProdTranData", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData(){ Data = data }
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
					object prod_id = null;
					
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.DataList[0].Data as DataTable).ToDataMapList()[0];

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							//생산트랜 저장
							prod_id = DaoFactory.Instance.Insert("InsertProdTran", data);

							//재고반영
							DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
							{
								{ "TRAN_ID", prod_id },
								{ "TRAN_TP", "PR" },
								{ "REG_TP", "II" },
								{ "INS_USER", data.GetValue("INS_USER") }
							});
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							prod_id = data.GetValue("PROD_ID");

							//수정 전 재고반영(-)
							DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
							{
								{ "TRAN_ID", prod_id },
								{ "TRAN_TP", "PR" },
								{ "REG_TP", "UD" },
								{ "INS_USER", data.GetValue("INS_USER") }
							});

							//생산수정
							DaoFactory.Instance.Update("UpdateProdTran", data);

							//수정 후 재고반영(+)
							DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
							{
								{ "TRAN_ID", prod_id },
								{ "TRAN_TP", "PR" },
								{ "REG_TP", "UI" },
								{ "INS_USER", data.GetValue("INS_USER") }
							});
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						{
							prod_id = data.GetValue("PROD_ID");

							//재고반영
							DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
							{
								{ "TRAN_ID", prod_id },
								{ "TRAN_TP", "PR" },
								{ "REG_TP", "DD" },
								{ "INS_USER", data.GetValue("INS_USER") }
							});

							//생산트랜삭제
							DaoFactory.Instance.Update("DeleteProdTran", data);
							
						}
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = prod_id;
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
