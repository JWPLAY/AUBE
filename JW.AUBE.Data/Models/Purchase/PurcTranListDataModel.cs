using System;

namespace JW.AUBE.Data.Models.Purchase
{
	public class PurcTranListDataModel
	{
		public int PURC_ID { get; set; }
		public string PURC_DATE { get; set; }
		public string PURC_TYPE { get; set; }
		public int CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
		public string REMARKS { get; set; }
		public int PURC_ITEM_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_NAME { get; set; }
		public decimal PURC_PRICE { get; set; }
		public int PURC_QTY { get; set; }
		public decimal PURC_AMT { get; set; }
		public string PRODUCT_TYPE { get; set; }
		public string CATEGORY { get; set; }
		public DateTime INS_TIME { get; set; }
		public int INS_USER { get; set; }
		public string INS_USER_NAME { get; set; }
		public DateTime UPD_TIME { get; set; }
		public int UPD_USER { get; set; }
		public string UPD_USER_NAME { get; set; }
	}
}
