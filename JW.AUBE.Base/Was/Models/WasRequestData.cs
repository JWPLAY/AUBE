using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Base.Was.Models
{
	[DataContract]
	public class WasRequestData : IDisposable
	{
		[DataMember]
		public string SqlId { get; set; }

		[DataMember]
		public bool IsMaster { get; set; }

		[DataMember]
		public string KeyField { get; set; }

		[DataMember]
		public DataTable Data { get; set; }

		[DataMember]
		public SchemaMap Schema { get; set; }

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

		public WasRequestData()
		{
			IsMaster = false;
			Schema = new SchemaMap();
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
				// Free other state (managed objects).
				if (Data != null)
				{
					Data.Dispose();
					Data = null;
				}
				if (Schema != null) Schema = null;
			}
			// Free your own state (unmanaged objects).
			// Set large fields to null.
		}
	}
}
