using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Service.Mappers;
using JW.AUBE.Model.Sales;
using JW.AUBE.Service.Utils;

namespace JW.AUBE.Service.Services
{
	public static class SalesService
	{
		public static WasRequest GetList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleTranListModel>("GetSaleTranList", req.Parameter);
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
				var saletran = DaoFactory.Instance.QueryForObject<SaleTranDataModel>("GetSaleTran", req.Parameter);
				var saleitem = DaoFactory.Instance.QueryForList<SaleTranItemDataModel>("GetSaleTranItem", req.Parameter);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData() { Data = saletran },
					new WasRequestData() { Data = saleitem }
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
					object sale_id = null;
					object sale_no = null;
					object item_id = null;

					//마스터저장
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.DataList[0].Data as DataTable).ToDataMapList()[0];

						if (string.IsNullOrEmpty(data.GetValue("SALE_NO").ToStringNullToEmpty()))
						{
							sale_no = CommonDataUtils.GetSaleNo();
							data.SetValue("SALE_NO", sale_no);
						}

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							sale_id = DaoFactory.Instance.Insert("InsertSaleTran", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							DaoFactory.Instance.Update("UpdateSaleTran", data);
							sale_id = data.GetValue("SALE_ID");
						}
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = sale_id;
					}

					//품목 저장
					if (req.DataList.Count > 1)
					{
						if (req.DataList[1].Data != null && (req.DataList[1].Data as DataTable).Rows.Count > 0)
						{
							IList<DataMap> list = (req.DataList[1].Data as DataTable).ToDataMapList();
							foreach (DataMap map in list)
							{
								map.SetValue("SALE_ID", sale_id);

								if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
								{
									item_id = DaoFactory.Instance.Insert("InsertSaleTranItem", map);
									DaoFactory.Instance.Update("UpdateSaleTranSum", map);

									//재고반영
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", sale_id },
										{ "TRAN_TP", "SL" },
										{ "REG_TP", "II" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
								{
									item_id = map.GetValue("ITEM_ID");

									//재고반영(-)
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", sale_id },
										{ "TRAN_TP", "SL" },
										{ "REG_TP", "UD" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});

									//구매내역 수정
									DaoFactory.Instance.Update("UpdateSaleTranItem", map);
									DaoFactory.Instance.Update("UpdateSaleTranSum", map);

									//재고반영(+)
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", sale_id },
										{ "TRAN_TP", "SL" },
										{ "REG_TP", "UI" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
								{
									item_id = map.GetValue("ITEM_ID");

									//재고반영
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", sale_id },
										{ "TRAN_TP", "SL" },
										{ "REG_TP", "DD" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});

									DaoFactory.Instance.Update("DeleteSaleTranItem", map);
									DaoFactory.Instance.Update("UpdateSaleTranSum", map);
								}
							}
							req.DataList[1].ErrorNumber = 0;
							req.DataList[1].ErrorMessage = "SUCCESS";
							req.DataList[1].ReturnValue = item_id;
						}
					}

					if (isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch (Exception ex)
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
		public static WasRequest Delete(WasRequest req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<SaleTranDataModel>("GetSaleTran", req.Parameter);
				if (map != null)
				{
					//삭제 전에 재고 반영한다.
					DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
					{
						{ "TRAN_ID", req.Parameter.GetValue("SALE_ID") },
						{ "TRAN_TP", "SL" },
						{ "REG_TP", "DD" },
						{ "ITEM_ID", 0 },
						{ "INS_USER", req.Parameter.GetValue("INS_USER") }
					});
					
					DaoFactory.Instance.Delete("DeleteSaleTran", req.Parameter);
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

		public static WasRequest GetCategory(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleCategoryListModel>("GetSaleCategory", req.Parameter);
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
		public static WasRequest GetProducts(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleProductsListModel>("GetSaleProducts", req.Parameter);
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

		public static WasRequest GetSaleSumData(WasRequest req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<SaleSumDataModel>("GetSaleSumData", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData() { Data = data }
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
