namespace JW.AUBE.Data.Models.Base
{
	public class MenuData : BaseData
	{
		public int MenuId { get; set; }
		public string MenuName { get; set; }
		public int ParentMenuId { get; set; }
		public int SortSeq { get; set; }
		public int ChildCount { get; set; }
	}
}
