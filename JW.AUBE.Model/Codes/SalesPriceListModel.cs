﻿using JW.AUBE.Model.Base;

namespace JW.AUBE.Model.Codes
{
	public class SalesPriceListModel : BaseDataModel
	{
		public int ROW_NO { get; set; }
		public int REG_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public string BEG_DATE { get; set; }
		public string END_DATE { get; set; }
		public decimal SALE_PRICE { get; set; }
		public string REMARKS { get; set; }
	}
}
