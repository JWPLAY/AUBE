using System;

namespace JW.AUBE.Data.Models.Sales
{
	public class SaleTranItemDataModel
	{
		public int SALE_ITEM_ID { get; set; }
		public int SALE_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_NAME { get; set; }
		public decimal SALE_PRICE { get; set; }
		public int SALE_QTY { get; set; }
		public decimal SALE_AMT { get; set; }
		public DateTime INS_TIME { get; set; }
		public int INS_USER { get; set; }
		public string INS_USER_NAME { get; set; }
		public DateTime UPD_TIME { get; set; }
		public int UPD_USER { get; set; }
		public string UPD_USER_NAME { get; set; }
	}
}
