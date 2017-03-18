namespace JW.AUBE.Model.Auth
{
	public class MainMenuDataModel
	{
		public int MENU_ID { get; set; }
		public int PARENT_ID { get; set; }
		public string MENU_NAME { get; set; }
		public int MENU_LEVEL { get; set; }
		public string HIER_ID { get; set; }
		public string ASSEMBLY { get; set; }
		public string NAMESPACE { get; set; }
		public string INSTANCE { get; set; }
		public string FORM_TYPE { get; set; }
		public string BOOKMARK_YN { get; set; }
		public int CHILD_COUNT { get; set; }
		public string VIEW_YN { get; set; }
		public string EDIT_YN { get; set; }
	}
}
