namespace JW.AUBE.Model.Sales
{
	public class SaleTranItemDataModel
	{
		public int ROW_NO { get; set; }
		public int ITEM_ID { get; set; }
		public int SALE_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public decimal SALE_PRICE { get; set; }
		public decimal DISC_RATE { get; set; }
		public decimal DISC_PRICE { get; set; }
		public int SALE_QTY { get; set; }
		public decimal SALE_AMT { get; set; }
		public decimal DISC_AMT { get; set; }
		public decimal NPAY_AMT { get; set; }
		public string DISC_TYPE { get; set; }
		public string INS_TIME { get; set; }
		public int INS_USER { get; set; }
		public string INS_USER_NAME { get; set; }
		public string UPD_TIME { get; set; }
		public int UPD_USER { get; set; }
		public string UPD_USER_NAME { get; set; }
	}
}
