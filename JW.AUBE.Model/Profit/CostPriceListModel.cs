using JW.AUBE.Model.Base;

namespace JW.AUBE.Model.Profit
{
	public class CostPriceListModel : BaseDataModel
	{
		public int ROW_NO { get; set; }
		public string CLOSING_YM { get; set; }
		public string PRODUCT_TYPE { get; set; }
		public string CATEGORY { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public int BASE_QTY { get; set; }
		public decimal BASE_AMT { get; set; }
		public int PURC_QTY { get; set; }
		public decimal PURC_AMT { get; set; }
		public int TSUM_QTY { get; set; }
		public decimal TSUM_AMT { get; set; }
		public decimal COST_PRICE { get; set; }
		public string REMARKS { get; set; }
	}
}
