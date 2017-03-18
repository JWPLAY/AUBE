using JW.AUBE.Data.Models.Base;

namespace JW.AUBE.Data.Models.Codes
{
	public class ProductMaterialListModel : BaseDataModel
	{
		public int ROW_NO { get; set; }
		public int REG_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public int MATERIAL_ID { get; set; }
		public string MATERIAL_NAME { get; set; }
		public int INPUT_QTY { get; set; }
	}
}
