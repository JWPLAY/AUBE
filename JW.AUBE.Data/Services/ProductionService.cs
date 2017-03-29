using System;
using System.Data;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Model.Production;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class ProductionService
	{
		public static DBTranSet GetList(DBTranSet req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<ProdTranListModel>("GetProdTranList", req.TranList[0].Parameter);
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
				var data = DaoFactory.Instance.QueryForObject<ProdTranDataModel>("GetProdTranData", req.TranList[0].Parameter);
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
					object prod_id = null;
					
					if (req.TranList.Length > 0)
					{
						if (req.TranList[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						DataMap data = req.TranList[0].Data as DataMap;
						data.SetValue("INS_USER", req.UserId);

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
						req.TranList[0].ErrorNumber = 0;
						req.TranList[0].ErrorMessage = "SUCCESS";
						req.TranList[0].ReturnValue = prod_id;
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
