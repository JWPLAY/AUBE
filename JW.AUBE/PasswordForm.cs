using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Utils;

namespace JW.AUBE
{
	public partial class PasswordForm : BaseForm
	{
		public PasswordForm()
		{
			InitializeComponent();
			Init();
		}

		void Init()
		{
			this.BackColor = SkinUtils.FormBackColor;

			lcItemPwd1.Text = "현재비밀번호:";
			lcItemPwd2.Text = "변경비밀번호:";
			lcItemPwd3.Text = "비밀번호확인:";

			lcItemPwd1.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemPwd2.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemPwd3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		}
	}
}
