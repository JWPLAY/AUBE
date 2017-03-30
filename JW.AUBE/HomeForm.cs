using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Utils;

namespace JW.AUBE
{
	public partial class HomeForm : BaseForm
	{
		public HomeForm()
		{
			InitializeComponent();
			Init();

			btnRefresh.Click += delegate (object sender, System.EventArgs e) { doHomeRefresh(); };
		}

		private void Init()
		{
			this.BackColor = SkinUtils.FormBackColor;
			chart1.BackColor = chart2.BackColor = SkinUtils.FormBackColor;
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