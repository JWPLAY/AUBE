using System;
using System.Collections.Generic;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Data.Mappers;
using JW.AUBE.Data.Utils;

namespace JW.AUBE.Data.Services
{
	public static class CustomerService
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
				var customerData = DaoFactory.Instance.QueryForList<DataMap>("SelectCustomer", req.Parameter);
				var phonesData = DaoFactory.Instance.QueryForList<DataMap>("SelectCustomerPhones", req.Parameter);
				var addressData = DaoFactory.Instance.QueryForList<DataMap>("SelectCustomerAddress", req.Parameter);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(customerData, "Customer")
					}
					,
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(phonesData, "CustomerPhones")
					}
					,
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(addressData, "CustomerAddress")
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
					object customer_id = null;
					object phone_reg_id = null;
					object address_reg_id = null;
					object biz_reg_id = null;
					object biz_address_id = null;

					//거래처정보 저장
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null || req.DataList[0].Data.Rows.Count == 0)
							throw new Exception("거래처정보를 저장할 데이터가 존재하지 않습니다.");

						DataMap data = ConvertUtils.DataTableToDataMapList(req.DataList[0].Data)[0];




						//if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						//{
						//	product_id = DaoFactory.Instance.Insert("InsertProduct", data);
						//}
						//else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						//{
						//	DaoFactory.Instance.Update("UpdateProduct", data);
						//	product_id = data.GetValue("PRODUCT_ID");
						//}
						//else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						//{
						//	DaoFactory.Instance.Update("DeleteProduct", data);
						//	product_id = data.GetValue("PRODUCT_ID");
						//}
						//req.DataList[0].ErrorNumber = 0;
						//req.DataList[0].ErrorMessage = "SUCCESS";
						//req.DataList[0].ReturnValue = product_id;
					}

					//원부자재정보 저장
					//if (req.DataList.Count > 1)
					//{
					//	if (req.DataList[1].Data != null && req.DataList[1].Data.Rows.Count > 0)
					//	{
					//		IList<DataMap> list = ConvertUtils.DataTableToDataMapList(req.DataList[1].Data);
					//		foreach (DataMap map in list)
					//		{
					//			map.SetValue("PRODUCT_ID", product_id);

					//			if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
					//			{
					//				reg_id = DaoFactory.Instance.Insert("InsertProductMaterial", map);
					//			}
					//			else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
					//			{
					//				DaoFactory.Instance.Update("UpdateProductMaterial", map);
					//				reg_id = map.GetValue("REG_ID");
					//			}
					//			else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
					//			{
					//				DaoFactory.Instance.Update("DeleteProductMaterial", map);
					//				reg_id = map.GetValue("REG_ID");
					//			}
					//		}
					//		req.DataList[1].ErrorNumber = 0;
					//		req.DataList[1].ErrorMessage = "SUCCESS";
					//		req.DataList[1].ReturnValue = product_id;
					//	}
					//}
					
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
				var map = DaoFactory.Instance.QueryForObject<DataMap>("SelectCustomer", req.Parameter);
				if (map != null)
				{
					DaoFactory.Instance.Insert("DeleteCustomer", req.Parameter);
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
