using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using  JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Service.Mappers;
using JW.AUBE.Model.Sales;
using JW.AUBE.Service.Utils;

namespace JW.AUBE.Service.Services
{
	public static class SalesService
	{
		public static DBTranSet GetList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleTranListModel>("GetSaleTranList", req.TranList[0].Parameter);
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

		public static DBTranSet GetData(DBTranSet req)
		{
			try
			{
				var saletran = DaoFactory.Instance.QueryForObject<SaleTranDataModel>("GetSaleTran", req.TranList[0].Parameter);
				var saleitem = DaoFactory.Instance.QueryForList<SaleTranItemDataModel>("GetSaleTranItem", req.TranList[0].Parameter);

				req.TranList = new DBTranData[]
				{
					new DBTranData() { Data = saletran },
					new DBTranData() { Data = saleitem }
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
					object sale_id = null;
					object sale_no = null;
					object item_id = null;

					//마스터저장
					if (req.TranList.Length > 0)
					{
						if (req.TranList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.TranList[0].Data as DataTable).ToDataMapList()[0];

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
						req.TranList[0].ErrorNumber = 0;
						req.TranList[0].ErrorMessage = "SUCCESS";
						req.TranList[0].ReturnValue = sale_id;
					}

					//품목 저장
					if (req.TranList.Length > 1)
					{
						if (req.TranList[1].Data != null && (req.TranList[1].Data as DataTable).Rows.Count > 0)
						{
							IList<DataMap> list = (req.TranList[1].Data as DataTable).ToDataMapList();
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
							req.TranList[1].ErrorNumber = 0;
							req.TranList[1].ErrorMessage = "SUCCESS";
							req.TranList[1].ReturnValue = item_id;
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
		public static DBTranSet Delete(DBTranSet req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<SaleTranDataModel>("GetSaleTran", req.TranList[0].Parameter);
				if (map != null)
				{
					//삭제 전에 재고 반영한다.
					DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
					{
						{ "TRAN_ID", req.TranList[0].Parameter.GetValue("SALE_ID") },
						{ "TRAN_TP", "SL" },
						{ "REG_TP", "DD" },
						{ "ITEM_ID", 0 },
						{ "INS_USER", req.TranList[0].Parameter.GetValue("INS_USER") }
					});
					
					DaoFactory.Instance.Delete("DeleteSaleTran", req.TranList[0].Parameter);
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

		public static DBTranSet GetCategory(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleCategoryListModel>("GetSaleCategory", req.TranList[0].Parameter);
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
		public static DBTranSet GetProducts(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SaleProductsListModel>("GetSaleProducts", req.TranList[0].Parameter);
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

		public static DBTranSet GetSaleSumData(DBTranSet req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<SaleSumDataModel>("GetSaleSumData", req.TranList[0].Parameter);
				req.TranList[0].Data = data;
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		public static DBTranSet GetSaleStat(DBTranSet req)
		{
			try
			{
				var data1 = DaoFactory.Instance.QueryForList<DataMap>("GetSaleProductList", req.TranList[0].Parameter);
				var data2 = DaoFactory.Instance.QueryForList<DataMap>("GetSaleCustomerList", req.TranList[0].Parameter);
				var data3 = DaoFactory.Instance.QueryForList<DataMap>("GetSaleCategoryList", req.TranList[0].Parameter);
				var data4 = DaoFactory.Instance.QueryForList<DataMap>("GetSalePayTypeList", req.TranList[0].Parameter);

				req.TranList = new DBTranData[]
				{
					new DBTranData() { Data = data1 },
					new DBTranData() { Data = data2 },
					new DBTranData() { Data = data3 },
					new DBTranData() { Data = data4 }
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
