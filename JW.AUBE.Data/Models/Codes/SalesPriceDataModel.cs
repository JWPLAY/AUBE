using JW.AUBE.Data.Models.Base;

namespace JW.AUBE.Data.Models.Codes
{
	public class SalesPriceDataModel : BaseDataModel
	{
		public int REG_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public string BEG_DATE { get; set; }
		public string END_DATE { get; set; }
		public decimal SALE_PRICE { get; set; }
		public string REMARKS { get; set; }
	}
}
