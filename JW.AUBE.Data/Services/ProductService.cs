using System;
using System.Collections.Generic;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Data.Mappers;
using JW.AUBE.Data.Utils;

namespace JW.AUBE.Data.Services
{
	public static class ProductService
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
				var product = DaoFactory.Instance.QueryForList<DataMap>("SelectProduct", req.Parameter);
				var materials = DaoFactory.Instance.QueryForList<DataMap>("SelectProductMaterials", req.Parameter);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(product, "Product")
					}
					,
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(materials, "Materials")
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
					object product_id = null;
					object reg_id = null;
					string product_code = string.Empty;

					//상품정보 저장
					if (req.DataList.Count > 0)
					{
						if (req.DataList[0].Data == null || req.DataList[0].Data.Rows.Count == 0)
							throw new Exception("상품정보를 저장할 데이터가 존재하지 않습니다.");

						DataMap data = ConvertUtils.DataTableToDataMapList(req.DataList[0].Data)[0];

						if (string.IsNullOrEmpty(data.GetValue("PRODUCT_CODE").ToStringNullToEmpty()))
						{
							product_code = CommonDataUtils.GetProductCode(data.GetValue("PRODUCT_TYPE").ToString());
							data.SetValue("PRODUCT_CODE", product_code);
						}

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							product_id = DaoFactory.Instance.Insert("InsertProduct", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							DaoFactory.Instance.Update("UpdateProduct", data);
							product_id = data.GetValue("PRODUCT_ID");
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						{
							DaoFactory.Instance.Update("DeleteProduct", data);
							product_id = data.GetValue("PRODUCT_ID");
						}
						req.DataList[0].ErrorNumber = 0;
						req.DataList[0].ErrorMessage = "SUCCESS";
						req.DataList[0].ReturnValue = product_id;
					}

					//원부자재정보 저장
					if (req.DataList.Count > 1)
					{
						if (req.DataList[1].Data != null && req.DataList[1].Data.Rows.Count > 0)
						{
							IList<DataMap> list = ConvertUtils.DataTableToDataMapList(req.DataList[1].Data);
							foreach (DataMap map in list)
							{
								map.SetValue("PRODUCT_ID", product_id);

								if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
								{
									reg_id = DaoFactory.Instance.Insert("InsertProductMaterial", map);
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
								{
									DaoFactory.Instance.Update("UpdateProductMaterial", map);
									reg_id = map.GetValue("REG_ID");
								}
								else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
								{
									DaoFactory.Instance.Update("DeleteProductMaterial", map);
									reg_id = map.GetValue("REG_ID");
								}
							}
							req.DataList[1].ErrorNumber = 0;
							req.DataList[1].ErrorMessage = "SUCCESS";
							req.DataList[1].ReturnValue = product_id;
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
				var map = DaoFactory.Instance.QueryForObject<DataMap>("SelectProduct", req.Parameter);
				if (map != null)
				{
					DaoFactory.Instance.Insert("DeleteProduct", req.Parameter);
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
