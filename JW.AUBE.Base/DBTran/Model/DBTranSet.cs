using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JW.AUBE.Base.DBTran.Model
{
	[DataContract]
	public class DBTranSet : IDisposable
	{
		[DataMember]
		public string ServiceId { get; set; }

		[DataMember]
		public string ProcessId { get; set; }

		[DataMember]
		public string DatabaseId { get; set; }

		[DataMember]
		public bool IsTransaction { get; set; }

		[DataMember]
		public DBTranData[] TranList { get; set; }

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

		public DBTranSet()
		{
			IsTransaction = true;
			TranList = null;
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
				if (TranList != null && TranList.Length > 0)
				{
					foreach (DBTranData data in TranList)
					{
						if (data != null)
						{
							data.Dispose();
						}
					}
					TranList = null;
				}
			}
		}
	}
}
