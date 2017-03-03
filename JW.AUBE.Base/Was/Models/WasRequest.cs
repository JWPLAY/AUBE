using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Base.Was.Models
{
	[DataContract]
	public class WasRequest : IDisposable
	{
		[DataMember]
		public string ServiceId { get; set; }

		[DataMember]
		public string ProcessId { get; set; }

		[DataMember]
		public string DatabaseId { get; set; }

		[DataMember]
		public string SqlId { get; set; }

		[DataMember]
		public bool IsTransaction { get; set; }

		[DataMember]
		public DataMap Parameter { get; set; }

		[DataMember]
		public List<WasRequestData> DataList { get; set; }

		[DataMember]
		public int UserId { get; set; }

		[DataMember]
		public DateTime? StartTime { get; set; }

		[DataMember]
		public DateTime? EndTime { get; set; }

		[DataMember]
		public int ErrorNumber { get; set; }

		[DataMember]
		public string ErrorMessage { get; set; }

		public WasRequest()
		{
			IsTransaction = true;
			Parameter = new DataMap();
			DataList = new List<WasRequestData>();
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
				if (DataList != null && DataList.Count > 0)
				{
					foreach (WasRequestData data in DataList)
					{
						if (data != null)
						{
							data.Dispose();
						}
					}
					DataList = null;
				}
				if (Parameter != null) Parameter = null;
			}
		}

		public List<DataTable> GetData()
		{
			List<DataTable> list = new List<DataTable>();
			foreach (WasRequestData data in DataList)
				list.Add(data.Data);
			return list;
		}
	}
}
