using System;
using System.Data;
using System.Runtime.Serialization;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Base.DBTran.Model
{
	[DataContract]
	public class DBTranData : IDisposable
	{
		[DataMember]
		public string SqlId { get; set; }

		[DataMember]
		public DataMap Parameter { get; set; }

		[DataMember]
		public bool IsMaster { get; set; }

		[DataMember]
		public string KeyField { get; set; }

		[DataMember]
		public string DataModelName { get; set; }

		[DataMember]
		public object Data { get; set; }

		[DataMember]
		public int PageNo { get; set; }

		[DataMember]
		public int PageSize { get; set; }

		[DataMember]
		public int TotalPages { get; set; }

		[DataMember]
		public int TotalRecords { get; set; }

		[DataMember]
		public object ReturnValue { get; set; }

		[DataMember]
		public string ReturnMessage { get; set; }

		[DataMember]
		public int ErrorNumber { get; set; }

		[DataMember]
		public string ErrorMessage { get; set; }

		public DBTranData()
		{
			IsMaster = false;
			PageNo = 0;
			PageSize = 0;
			TotalPages = 0;
			TotalRecords = 0;
			ErrorNumber = 0;
			ErrorMessage = "SUCCESS";
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Data != null)
				{
					if (Data.GetType() == typeof(DataTable))
					{
						(Data as DataTable).Dispose();
					}
					Data = null;
				}
				if (Parameter != null)
					Parameter = null;
			}
		}
	}
}
