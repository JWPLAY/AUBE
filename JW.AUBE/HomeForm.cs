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

			btnRefresh.Click += delegate (object sender, System.EventArgs e) { doHomeRefresh(); };
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			doHomeRefresh();
		}

		private void doHomeRefresh()
		{
			string url = @"http://www.naver.com";
			if (GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty().IsNullOrEmpty() == false)
				url = GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty();
			wb.Navigate(new System.Uri(url));
		}
	}
}