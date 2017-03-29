using System;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;

namespace JW.AUBE.Base.DBTran.Controller
{
	public static class DBTranHelper
	{
		public static DBTranSet Execute(this DBTranSet reqset)
		{
			try
			{
				reqset.UserId = GlobalVar.Settings.GetValue("USER_ID").ToIntegerNullToZero();
				return (new DBTranController()).Execute(reqset);
			}
			catch
			{
				throw;
			}
		}
		public static DBTranSet Execute(string serviceId, string processId, object data, string keyField)
		{
			return Execute(serviceId, processId, null, data, keyField);
		}
		public static DBTranSet Execute(string serviceId, string processId, string sqlId, object data, string keyField)
		{
			try
			{
				if (data == null)
					throw new Exception("처리할 데이터가 없습니다.");

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				var res = (new DBTranSet()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					TranList = new DBTranData[]
					{
						new DBTranData()
						{
							IsMaster = true,
							KeyField = keyField,
							SqlId = sqlId,
							Data = data
						}
					}
				}).Execute();

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

		public static DBTranSet GetData(string serviceId, DataMap parameter)
		{
			return GetData(serviceId, null, null, parameter);
		}
		public static DBTranSet GetData(string serviceId, string processId, DataMap parameter)
		{
			return GetData(serviceId, processId, null, parameter);
		}
		public static DBTranSet GetData(string serviceId, string processId, string sqlId, DataMap parameter)
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
							Parameter = parameter
						}
					}
				}).Execute();

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

		public static T GetData<T>(string serviceId, DataMap parameter)
		{
			try
			{
				return GetData<T>(serviceId, null, null, parameter);
			}
			catch
			{
				throw;
			}
		}
		public static T GetData<T>(string serviceId, string processId, DataMap parameter)
		{
			if (string.IsNullOrEmpty(processId))
				processId = "GetData";
			return GetData<T>(serviceId, processId, null, parameter);
		}
		public static T GetData<T>(string serviceId, string processId, string sqlId, DataMap parameter)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (string.IsNullOrEmpty(processId))
					processId = "GetData";

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
							Parameter = parameter
						}
					}
				}).Execute();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				if (res.TranList == null || res.TranList.Length == 0)
					throw new Exception("요청결과의 데이터가 없습니다.");

				return (T)res.TranList[0].Data;
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
				}).Execute();

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
