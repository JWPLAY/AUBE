﻿using JW.AUBE.Data.Models.Base;

namespace JW.AUBE.Data.Models.Codes
{
	public class ProductMaterialDataModel : BaseDataModel
	{
		public int REG_ID { get; set; }
		public int PRODUCT_ID { get; set; }
		public int MATERIAL_ID { get; set; }
		public string MATERIAL_NAME { get; set; }
		public int INPUT_QTY { get; set; }
		public string UNIT_TYPE { get; set; }
	}
}
