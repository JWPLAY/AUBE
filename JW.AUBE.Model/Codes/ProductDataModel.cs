using JW.AUBE.Model.Base;

namespace JW.AUBE.Model.Codes
{
	public class ProductDataModel : BaseDataModel
	{
		public int PRODUCT_ID { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string PRODUCT_NAME { get; set; }
		public string BARCODE { get; set; }
		public string PRODUCT_TYPE { get; set; }
		public string CATEGORY { get; set; }
		public string UNIT_TYPE { get; set; }
		public string USE_YN { get; set; }
		public string REMARKS { get; set; }
	}
}
