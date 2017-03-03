using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Resources;

namespace JW.AUBE
{
	public partial class HomeForm : BaseForm
	{
		public HomeForm()
		{
			InitializeComponent();
		}

		private void Init()
		{
			lcGroupBase.BackgroundImage = ImageResource.back_gray;
		}
	}
}