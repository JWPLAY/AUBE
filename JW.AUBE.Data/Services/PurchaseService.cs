﻿using System;
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
				var purctran = DaoFactory.Instance.QueryForList<PurcTranDataModel>("GetPurcTran", req.Parameter);
				var purcitem = DaoFactory.Instance.QueryForList<PurcTranItemDataModel>("GetPurcTranItem", req.Parameter);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.ListToDataTable(purctran)
					}
					,
					new WasRequestData()
					{
						Data = ConvertUtils.ListToDataTable(purcitem)
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
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						{
							DaoFactory.Instance.Update("DeletePurcTran", data);
							purc_id = data.GetValue("PURC_ID");
						}
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = purc_id;
					}

					//원부자재정보 저장
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
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
								{
									DaoFactory.Instance.Update("UpdatePurcTranItem", map);
									item_id = map.GetValue("PURC_ITEM_ID");
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
								{
									DaoFactory.Instance.Update("DeletePurcTranItem", map);
									item_id = map.GetValue("PURC_ITEM_ID");
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
				var map = DaoFactory.Instance.QueryForObject<DataMap>("GetPurcTran", req.Parameter);
				if (map != null)
				{
					DaoFactory.Instance.Insert("DeletePurcTran", req.Parameter);
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