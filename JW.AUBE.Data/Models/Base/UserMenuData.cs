namespace JW.AUBE.Data.Models.Base
{
	public class UserMenuData
	{
		public string HIER_ID { get; set; }
		public int ID { get; set; }
		public string PARENT_ID { get; set; }
		public string NAME { get; set; }
		public int CHILD_COUNT { get; set; }
		public string VIEW_YN { get; set; }
		public string BOOKMARK_YN { get; set; }
	}
}
