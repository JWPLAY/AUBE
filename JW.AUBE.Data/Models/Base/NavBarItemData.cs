namespace JW.AUBE.Data.Models.Base
{
	public class NavBarItemData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string WebUrl { get; set; }
		public string Group { get; set; }
		public string ImageName { get; set; }

		public NavBarItemData()
		{
		}
		public NavBarItemData(int id, string name, string webUrl, string group, string imageName)
		{
			Id = id;
			Name = name;
			WebUrl = webUrl;
			Group = group;
			ImageName = imageName;
		}
	}
}
