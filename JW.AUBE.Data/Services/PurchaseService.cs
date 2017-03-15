using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Data.Mappers;
using JW.AUBE.Data.Models.Purchase;
using JW.AUBE.Data.Utils;

namespace JW.AUBE.Data.Services
{
	public static class PurchaseService
	{
		/// <summary>
		/// GetData
		/// 제품 데이터와 해당 제품의 원부자재 목록 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetData(WasRequest req)
		{
			try
			{
				var purctran = DaoFactory.Instance.QueryForObject<PurcTranDataModel>("GetPurcTran", req.Parameter);
				var purcitem = DaoFactory.Instance.QueryForList<PurcTranItemDataModel>("GetPurcTranItem", req.Parameter);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData(){ Data = purctran },
					new WasRequestData(){ Data = purcitem }
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

		/// <summary>
		/// Save
		/// 데이터 저장(Insert, Update)
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
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
					object purc_id = null;
					object purc_no = null;
					object item_id = null;

					//마스터저장
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = (req.DataList[0].Data as DataTable).ToDataMapList()[0];

						if (string.IsNullOrEmpty(data.GetValue("PURC_NO").ToStringNullToEmpty()))
						{
							purc_no = CommonDataUtils.GetPurcNo();
							data.SetValue("PURC_NO", purc_no);
						}

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							purc_id = DaoFactory.Instance.Insert("InsertPurcTran", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							DaoFactory.Instance.Update("UpdatePurcTran", data);
							purc_id = data.GetValue("PURC_ID");
						}
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = purc_id;
					}

					//구매상품내역 저장
					if (req.DataList.Count > 1)
					{
						if (req.DataList[1].Data != null && (req.DataList[1].Data as DataTable).Rows.Count > 0)
						{
							IList<DataMap> list = (req.DataList[1].Data as DataTable).ToDataMapList();
							foreach (DataMap map in list)
							{
								map.SetValue("PURC_ID", purc_id);

								if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
								{
									item_id = DaoFactory.Instance.Insert("InsertPurcTranItem", map);

									//재고반영
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", purc_id },
										{ "TRAN_TP", "PC" },
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
										{ "TRAN_ID", purc_id },
										{ "TRAN_TP", "PC" },
										{ "REG_TP", "UD" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});

									//구매내역 수정
									DaoFactory.Instance.Update("UpdatePurcTranItem", map);

									//재고반영(+)
									DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
									{
										{ "TRAN_ID", purc_id },
										{ "TRAN_TP", "PC" },
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
										{ "TRAN_ID", purc_id },
										{ "TRAN_TP", "PC" },
										{ "REG_TP", "DD" },
										{ "ITEM_ID", item_id },
										{ "INS_USER", map.GetValue("INS_USER") }
									});

									DaoFactory.Instance.Update("DeletePurcTranItem", map);
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

		/// <summary>
		/// Delete
		/// 데이터 삭제(Delete)
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest Delete(WasRequest req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<PurcTranDataModel>("GetPurcTran", req.Parameter);
				if (map != null)
				{
					//삭제 전에 재고 반영한다.
					DaoFactory.Instance.QueryForObject<int>("BatchInventory", new DataMap()
					{
						{ "TRAN_ID", req.Parameter.GetValue("PURC_ID") },
						{ "TRAN_TP", "PC" },
						{ "REG_TP", "DD" },
						{ "ITEM_ID", 0 },
						{ "INS_USER", req.Parameter.GetValue("INS_USER") }
					});

					//구매내역을 삭제한다.
					DaoFactory.Instance.Delete("DeletePurcTran", req.Parameter);
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

		public static WasRequest GetPurcTranList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<PurcTranListDataModel>("GetPurcTranList", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = list	//ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
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
