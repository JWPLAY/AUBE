using System.Drawing;

namespace JW.AUBE.Core.Models
{
	public interface IMenuData
	{
		int MENU_ID { get; set; }
		string MENU_NAME { get; set; }
		string CAPTION { get; set; }
		Image IMAGE { get; set; }
		string ASSEMBLY { get; set; }
		string NAMESPACE { get; set; }
		string INSTANCE { get; set; }
		string FORM_TYPE { get; set; }
		string VIEW_YN { get; set; }
		string EDIT_YN { get; set; }
	}
}
