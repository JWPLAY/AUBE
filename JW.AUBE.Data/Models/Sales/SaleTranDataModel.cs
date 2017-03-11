﻿using System;

namespace JW.AUBE.Data.Models.Sales
{
	public class SaleTranDataModel
	{
		public int SALE_ID { get; set; }
		public string SALE_NO { get; set; }
		public string SALE_DATE { get; set; }
		public string SALE_TYPE { get; set; }
		public int CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
		public string REMARKS { get; set; }
		public DateTime INS_TIME { get; set; }
		public int INS_USER { get; set; }
		public string INS_USER_NAME { get; set; }
		public DateTime UPD_TIME { get; set; }
		public int UPD_USER { get; set; }
		public string UPD_USER_NAME { get; set; }
	}
}