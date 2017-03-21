using JW.AUBE.Model.Base;

namespace JW.AUBE.Model.Profit
{
	public class ProfitListModel : BaseDataModel
	{
		public int ROW_NO { get; set; }
		public string CLOSING_YM { get; set; }
		public string PRODUCT_TYPE { get; set; }
		public string CATEGORY { get; set; }
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public decimal BASE_AMT { get; set; }
		public decimal PURC_AMT { get; set; }
		public decimal PROD_AMT { get; set; }
		public decimal ADJS_AMT { get; set; }
		public decimal BLNC_AMT { get; set; }
		public decimal COST_AMT { get; set; }
		public decimal PRFT_AMT { get; set; }
		public decimal PRFT_RAT { get; set; }
	}
}
