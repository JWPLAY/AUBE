using System.Drawing;

namespace JW.AUBE.Core.Models
{
	public class FormData : IFormData
	{
		public int ID { get; set; }
		public string NAME { get; set; }
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
