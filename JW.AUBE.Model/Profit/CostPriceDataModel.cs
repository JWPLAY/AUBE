using JW.AUBE.Model.Base;

namespace JW.AUBE.Model.Profit
{
	public class CostPriceDataModel : BaseDataModel
	{
		public string CLOSING_YM { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public decimal COST_PRICE { get; set; }
		public string REMARKS { get; set; }
	}
}
