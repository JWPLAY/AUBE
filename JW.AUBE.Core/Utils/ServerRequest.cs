using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Core.Was.Controllers;

namespace JW.AUBE.Core.Utils
{
	public static class ServerRequest
	{
		public static WasRequest Request(this WasRequest reqset)
		{
			try
			{
				return (new WasController()).Execute(reqset);
			}
			catch
			{
				throw;
			}
		}
		public static WasRequest GetData(string serviceId, DataMap parameter)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new WasRequest()
							{
								ServiceId = serviceId,
								ProcessId = "GetData",
								Parameter = parameter
							}).Request();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.DataList == null || res.DataList.Count == 0)
					throw new Exception("요청결과의 데이터가 없습니다.");

				return res;
			}
			catch
			{
				throw;
			}
		}
		public static WasRequest Execute(string serviceId, string processId, DataTable[] datalist)
		{
			try
			{
				if (datalist == null || datalist.Length == 0)
					throw new Exception("처리할 데이터가 없습니다.");

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				List<WasRequestData> reqdatalist = new List<WasRequestData>();
				foreach(DataTable dt in datalist)
				{
					if (dt.Columns.Contains("INS_USER") == false)
						dt.Columns.Add("INS_USER", typeof(int));

					foreach (DataRow dr in dt.Rows)
						dr["INS_USER"] = GlobalVar.Settings.GetValue("USER_ID");

					reqdatalist.Add(new WasRequestData() { Data = dt });
				}

				var res = (new WasRequest()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					DataList = reqdatalist
				}).Request();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.DataList == null || res.DataList.Count == 0)
					throw new Exception("요청결과의 데이터가 없습니다.");

				return res;
			}
			catch
			{
				throw;
			}
		}

		public static DataTable SingleRequest(this WasRequest req)
		{
			try
			{
				req = req.Request();

				if (req.ErrorNumber == 0)
				{
					if (req.DataList == null ||
						req.DataList.Count == 0 ||
						req.DataList[0] == null ||
						req.DataList[0].Data == null)
					{
						return null;
					}
					else
					{
						return req.DataList[0].Data;
					}
				}
				else
				{
					throw new Exception(req.ErrorMessage);
				}
			}
			catch
			{
				throw;
			}
		}
		public static DataTable SingleRequest(string serviceId, string processId, string sqlId, DataMap parameter)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new WasRequest()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					SqlId = sqlId,
					Parameter = parameter,
					DataList = new List<WasRequestData>()
					{
						new WasRequestData()
						{
							SqlId = sqlId,
							Data = parameter.ToDataTable()
						}
					}
				}).Request();

				if (res.ErrorNumber == 0)
				{
					if (res.DataList == null || res.DataList.Count == 0 || res.DataList[0] == null)
					{
						throw new Exception("서버 요청에 대한 응답이 없습니다.\r\n확인 후 다시 시도하세요!!!");
					}
				}
				else
				{
					throw new Exception(res.ErrorMessage);
				}
				return res.DataList[0].Data;
			}
			catch
			{
				throw;
			}
		}

		public static WasRequest SingleRequest(string serviceId, string processId, string sqlId, DataTable data, string keyField = null)
		{
			if (data != null && data.Rows.Count > 0)
			{
				if (data.Columns.Contains("INS_USER") == false)
				{
					data.Columns.Add("INS_USER", typeof(int));
					foreach (DataRow row in data.Rows)
						row["INS_USER"] = GlobalVar.Settings.GetValue("USER_ID");
				}
			}

			return Request(new WasRequest()
			{
				ServiceId = serviceId,
				ProcessId = processId,
				IsTransaction = true,
				DataList = new List<WasRequestData>()
					{
						new WasRequestData()
						{
							SqlId = sqlId,
							KeyField = keyField,
							Data = data
						}
					}
			});
		}
		public static WasRequest ProcedureCall(string sqlId, DataMap parameter)
		{
			try
			{
				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				return (new WasRequest()
							{
								ServiceId = "Base",
								ProcessId = "ProcedureCall",
								SqlId = sqlId,
								Parameter = parameter,
								IsTransaction = true
							}).Request();
			}
			catch
			{
				throw;
			}
		}
	}
}