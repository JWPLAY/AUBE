namespace JW.AUBE.Model.System
{
	public class TableListModel
	{
		public int ROW_NO { get; set; }
		public string TABLE_ID { get; set; }
		public string SCHEMA_NAME { get; set; }
		public string TABLE_NAME { get; set; }
		public int ID { get; set; }
		public string DESCRIPTION { get; set; }
		public string REMARKS { get; set; }
		public int ROW_COUNT { get; set; }
		public decimal TABLE_SIZE { get; set; }
		public decimal DATA_SIZE { get; set; }
		public decimal INDEX_SIZE { get; set; }
		public string LAST_USER_SEEK { get; set; }
		public string LAST_USER_SCAN { get; set; }
		public string LAST_USER_LOOKUP { get; set; }
		public string LAST_USER_UPDATE { get; set; }
		public string LAST_SYSTEM_UPDATE { get; set; }
	}
}
