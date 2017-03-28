using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;

namespace JW.AUBE
{
	public partial class HomeForm : BaseForm
	{
		public HomeForm()
		{
			InitializeComponent();
		}

		protected override void LoadForm()
		{
			base.LoadForm();

			string url = @"http://www.naver.com";
			if (GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty().IsNullOrEmpty() == false)
				url = GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty();
			wb.Navigate(new System.Uri(url));
		}
	}
}