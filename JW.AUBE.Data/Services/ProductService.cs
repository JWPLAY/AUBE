using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Model.Codes;
using JW.AUBE.Service.Mappers;
using JW.AUBE.Service.Utils;

namespace JW.AUBE.Service.Services
{
	public static class ProductService
	{
		public static DBTranSet GetList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<ProductListModel>("SelectProducts", req.TranList[0].Parameter);
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
				var product = DaoFactory.Instance.QueryForObject<ProductDataModel>("SelectProduct", req.TranList[0].Parameter);
				var materials = DaoFactory.Instance.QueryForList<ProductMaterialListModel>("SelectProductMaterials", req.TranList[0].Parameter);

				req.TranList = new DBTranData[]
				{
					new DBTranData() {Data = product },
					new DBTranData() {Data = materials }
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
					object product_id = null;
					object reg_id = null;
					string product_code = string.Empty;

					//상품정보 저장
					if (req.TranList.Length > 0)
					{
						if (req.TranList[0].Data == null)
							throw new Exception("상품정보를 저장할 데이터가 존재하지 않습니다.");

						DataMap data = req.TranList[0].Data as DataMap;
						data.SetValue("INS_USER", req.UserId);

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
						req.TranList[0].ErrorNumber = 0;
						req.TranList[0].ErrorMessage = "SUCCESS";
						req.TranList[0].ReturnValue = product_id;
					}

					//원부자재정보 저장
					if (req.TranList.Length > 1)
					{
						if (req.TranList[1].Data != null && (req.TranList[1].Data as DataTable).Rows.Count > 0)
						{
							IList<DataMap> list = (req.TranList[1].Data as DataTable).ToDataMapList();
							foreach (DataMap map in list)
							{
								map.SetValue("PRODUCT_ID", product_id);
								map.SetValue("INS_USER", req.UserId);

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
							req.TranList[1].ErrorNumber = 0;
							req.TranList[1].ErrorMessage = "SUCCESS";
							req.TranList[1].ReturnValue = product_id;
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

		public static DBTranSet Delete(DBTranSet req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<DataMap>("SelectProduct", req.TranList[0].Parameter);
				if (map != null)
				{
					DaoFactory.Instance.Insert("DeleteProduct", req.TranList[0].Parameter);
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

		public static DBTranSet GetSalesPriceList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<SalesPriceListModel>("GetSalesPriceList", req.TranList[0].Parameter);
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

		public static DBTranSet GetSalesPriceData(DBTranSet req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<SalesPriceDataModel>("GetSalesPriceData", req.TranList[0].Parameter);
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

		public static DBTranSet SaveSalesPrice(DBTranSet req)
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
					object product_id = null;
					object reg_id = null;
					
					if (req.TranList.Length > 0)
					{
						if (req.TranList[0].Data == null)
							throw new Exception("상품정보를 저장할 데이터가 존재하지 않습니다.");

						DataMap data = req.TranList[0].Data as DataMap;
						data.SetValue("INS_USER", req.UserId);

						product_id = data.GetValue("PRODUCT_ID");

						if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
						{
							reg_id = DaoFactory.Instance.Insert("InsertSalesPrice", data);
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
						{
							reg_id = data.GetValue("REG_ID");
							DaoFactory.Instance.Update("UpdateSalesPrice", data);
							
						}
						else if (data.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
						{
							reg_id = data.GetValue("REG_ID");
							DaoFactory.Instance.Update("DeleteSalesPrice", data);
							
						}
						req.TranList[0].ErrorNumber = 0;
						req.TranList[0].ErrorMessage = "SUCCESS";
						req.TranList[0].ReturnValue = reg_id;
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

		public static DBTranSet GetDataByBarcode(DBTranSet req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<DataMap>("GetProductId", req.TranList[0].Parameter);
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
	}
}
