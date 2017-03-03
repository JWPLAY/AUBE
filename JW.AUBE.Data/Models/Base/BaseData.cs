using System;

namespace JW.AUBE.Data.Models.Base
{
	public class BaseData
	{
		public DateTime? InsertDtime { get; set; }
		public int? INS_USER { get; set; }
		public string InsertUserName { get; set; }
		public DateTime? UpdateDtime { get; set; }
		public int? UPD_USER { get; set; }
		public string UpdateUserName { get; set; }
	}
}
