using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;

namespace JW.AUBE.Base.DBTran.Controller
{
	public static class DBTranHelper
	{
		public static DBTranSet Request(this DBTranSet reqset)
		{
			try
			{
				return (new DBTranController()).Execute(reqset);
			}
			catch
			{
				throw;
			}
		}

		public static DBTranSet GetData(string serviceId, DataMap parameter)
		{
			try
			{
				return GetData(serviceId, "GetData", parameter);
			}
			catch
			{
				throw;
			}
		}
		public static DBTranSet GetData(string serviceId, string processId, DataMap parameter)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					TranList = new DBTranData[]
					{
						new DBTranData() { Parameter = parameter }
					}
				}).Request();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				if (res.TranList == null || res.TranList.Length == 0)
					throw new Exception("요청결과의 데이터가 없습니다.");

				return res;
			}
			catch
			{
				throw;
			}
		}

		public static DBTranSet Execute(string serviceId, string processId, DataTable[] TranList)
		{
			try
			{
				if (TranList == null || TranList.Length == 0)
					throw new Exception("처리할 데이터가 없습니다.");

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				List<DBTranData> reqlist = new List<DBTranData>();
				foreach (DataTable dt in TranList)
				{
					if (dt.Columns.Contains("INS_USER") == false)
						dt.Columns.Add("INS_USER", typeof(int));

					foreach (DataRow dr in dt.Rows)
						dr["INS_USER"] = GlobalVar.Settings.GetValue("USER_ID");

					reqlist.Add(new DBTranData() { Data = dt });
				}

				var res = (new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					TranList = reqlist.ToArray()
				}).Request();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				return res;
			}
			catch
			{
				throw;
			}
		}
		public static DBTranSet Execute(string serviceId, string processId, DataMap parameter)
		{
			try
			{
				if (parameter == null)
					throw new Exception("처리할 데이터가 없습니다.");

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					TranList = new DBTranData[]
					{
						new DBTranData() {Parameter = parameter }
					}
				}).Request();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				return res;
			}
			catch
			{
				throw;
			}
		}

		public static object SingleRequest(this DBTranSet req)
		{
			try
			{
				req = req.Request();

				if (req.ErrorNumber == 0)
				{
					if (req.TranList == null ||
						req.TranList.Length == 0 ||
						req.TranList[0] == null ||
						req.TranList[0].Data == null)
					{
						return null;
					}
					else
					{
						return req.TranList[0].Data;
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
		public static object SingleRequest(string serviceId, string processId, string sqlId, DataMap parameter)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					TranList = new DBTranData[]
					{
						new DBTranData()
						{
							SqlId = sqlId,
							Parameter = parameter,
							Data = parameter.ToDataTable()
						}
					}
				}).Request();

				if (res.ErrorNumber == 0)
				{
					if (res.TranList == null || res.TranList.Length == 0 || res.TranList[0] == null)
					{
						throw new Exception("서버 요청에 대한 응답이 없습니다.\r\n확인 후 다시 시도하세요!!!");
					}
				}
				else
				{
					throw new Exception(res.ErrorMessage);
				}
				return res.TranList[0].Data;
			}
			catch
			{
				throw;
			}
		}

		public static DBTranSet SingleRequest(string serviceId, string processId, string sqlId, DataTable data, string keyField = null)
		{
			try
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

				var res = Request(new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					IsTransaction = true,
					TranList = new DBTranData[]
					{
						new DBTranData()
						{
							SqlId = sqlId,
							KeyField = keyField,
							Data = data
						}
					}
				});

				if (res == null)
					throw new Exception("처리결과를 수신하지 못했습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				return res;
			}
			catch
			{
				throw;
			}
		}

		public static DBTranSet ProcedureCall(string sqlId, DataMap parameter)
		{
			try
			{
				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("INS_USER") == false)
					parameter.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));

				var res = (new DBTranSet()
				{
					ServiceId = "Base",
					ProcessId = "ProcedureCall",
					IsTransaction = true,
					TranList = new DBTranData[]
					{
						new DBTranData()
						{
							SqlId = sqlId,
							Parameter = parameter,

						}
					}
				}).Request();

				if (res == null)
					throw new Exception("처리결과를 수신하지 못했습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				return res;
			}
			catch
			{
				throw;
			}
		}
	}
}
