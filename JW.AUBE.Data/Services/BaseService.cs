using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Service.Mappers;

namespace JW.AUBE.Service.Services
{
	public static class BaseService
	{
		/// <summary>
		/// GetList
		/// 데이터 리스트 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static DBTranSet GetList(DBTranSet reqset)
		{
			try
			{
				if (reqset.TranList == null || reqset.TranList.Length == 0)
					throw new Exception("처리요청이 없습니다.");

				foreach (DBTranData req in reqset.TranList)
				{
					var list = DaoFactory.Instance.QueryForList<DataMap>(req.SqlId, req.Parameter);
					req.Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId);
				}
				return reqset;
			}
			catch (Exception ex)
			{
				reqset.ErrorNumber = ex.HResult;
				reqset.ErrorMessage = ex.Message;
				return reqset;
			}
		}

		/// <summary>
		/// GetData
		/// 데이터 한건 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static DBTranSet GetData(DBTranSet reqset)
		{
			try
			{
				if (reqset.TranList == null || reqset.TranList.Length == 0)
					throw new Exception("처리요청이 없습니다.");

				foreach (DBTranData req in reqset.TranList)
				{
					req.Data = DaoFactory.Instance.QueryForObject<DataMap>(req.SqlId, req.Parameter);
				}
				return reqset;
			}
			catch (Exception ex)
			{
				reqset.ErrorNumber = ex.HResult;
				reqset.ErrorMessage = ex.Message;
				return reqset;
			}
		}

		/// <summary>
		/// Save
		/// 데이터 저장(Insert, Update)
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static DBTranSet Save(DBTranSet req)
		{
			bool isTran = false;
			string keyField = string.Empty;
			object keyValue = null;
			bool isKey = false;

			try
			{
				if (req.IsTransaction)
				{
					DaoFactory.Instance.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (DBTranData data in req.TranList)
					{
						if (data.Data == null || (data.Data as DataTable).Rows.Count == 0)
							continue;

						IList<DataMap> list = (data.Data as DataTable).ToDataMapList();
						foreach (DataMap map in list)
						{
							if (isKey && data.IsMaster == false && keyField.ToStringNullToEmpty() != "" && keyValue.ToStringNullToEmpty() != "")
							{
								map.SetValue(keyField, keyValue);
							}

							if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "INSERT")
							{
								keyValue = DaoFactory.Instance.Insert(string.Format("Insert{0}", data.SqlId), map);
							}
							else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPDATE")
							{
								DaoFactory.Instance.Update(string.Format("Update{0}", data.SqlId), map);
								if (data.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.KeyField);
							}
							else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "DELETE")
							{
								DaoFactory.Instance.Update(string.Format("Delete{0}", data.SqlId), map);
								if (data.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.KeyField);
							}
							else if (map.GetValue("ROWSTATE").ToStringNullToEmpty() == "UPSERT")
							{
								DaoFactory.Instance.Insert(string.Format("Upsert{0}", data.SqlId), map);
								if (data.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.KeyField);
							}

							if (data.IsMaster && data.KeyField.ToStringNullToEmpty() != "")
							{
								isKey = true;
								keyField = data.KeyField;
							}
						}
						data.ReturnValue = keyValue;
						data.ReturnMessage = "SUCCESS";
					}

					if (req.IsTransaction && isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch(Exception ex)
				{
					if (req.IsTransaction && isTran)
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
		public static DBTranSet Delete(DBTranSet reqset)
		{
			try
			{
				if (reqset.TranList == null || reqset.TranList.Length == 0)
					throw new Exception("처리요청이 없습니다.");

				foreach (DBTranData req in reqset.TranList)
				{
					var map = DaoFactory.Instance.QueryForObject<DataMap>(string.Format("Select{0}", req.SqlId), req.Parameter);
					if (map != null)
					{
						DaoFactory.Instance.Insert("Delete{0}", req.Parameter);
					}
				}
				return reqset;
			}
			catch (Exception ex)
			{
				reqset.ErrorNumber = ex.HResult;
				reqset.ErrorMessage = ex.Message;
				return reqset;
			}
		}

		public static DBTranSet ProcedureCall(DBTranSet reqset)
		{
			try
			{
				if (reqset.TranList == null || reqset.TranList.Length == 0)
					throw new Exception("처리요청이 없습니다.");

				foreach (DBTranData req in reqset.TranList)
				{
					DaoFactory.Instance.QueryForObject<int>(req.SqlId, req.Parameter);
				}
				return reqset;
			}
			catch (Exception ex)
			{
				reqset.ErrorNumber = ex.HResult;
				reqset.ErrorMessage = ex.Message;
				return reqset;
			}
		}
	}
}
