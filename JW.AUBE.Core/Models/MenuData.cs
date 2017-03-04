using System.Drawing;

namespace JW.AUBE.Core.Models
{
	public class MenuData : IMenuData
	{
		public int MENU_ID { get; set; }
		public string MENU_NAME { get; set; }
		public string CAPTION { get; set; }
		public Image IMAGE { get; set; }
		public string ASSEMBLY { get; set; }
		public string NAMESPACE { get; set; }
		public string INSTANCE { get; set; }
		public string FORM_TYPE { get; set; }
		public string VIEW_YN { get; set; }
		public string EDIT_YN { get; set; }
	}
}
