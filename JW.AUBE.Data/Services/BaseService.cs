using System;
using System.Collections.Generic;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Data.Mappers;

namespace JW.AUBE.Data.Services
{
	public static class BaseService
	{
		/// <summary>
		/// GetList
		/// 데이터 리스트 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetList(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<DataMap>(req.SqlId, req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
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
		/// GetData
		/// 데이터 한건 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetData(WasRequest req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<DataMap>(req.SqlId, req.Parameter);
				List<DataMap> list = new List<DataMap>();
				if (data != null)
					list.Add(data);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
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
					foreach (WasRequestData data in req.DataList)
					{
						if (data.Data == null || data.Data.Rows.Count == 0)
							continue;

						IList<DataMap> list = ConvertUtils.DataTableToDataMapList(data.Data);
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
		public static WasRequest Delete(WasRequest req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<DataMap>(string.Format("Select{0}", req.SqlId), req.Parameter);
				if (map != null)
				{
					DaoFactory.Instance.Insert("Delete{0}", req.Parameter);
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

		public static WasRequest ProcedureCall(WasRequest req)
		{
			try
			{
				DaoFactory.Instance.QueryForObject<int>(req.SqlId, req.Parameter);
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
