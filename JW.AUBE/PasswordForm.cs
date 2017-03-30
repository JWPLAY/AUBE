using System;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE
{
	public partial class PasswordForm : BaseForm
	{
		public PasswordForm()
		{
			InitializeComponent();
			Init();

			btnConfirm.Click += delegate (object sender, System.EventArgs e)
			{
				doConfirm();
			};
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

		void doConfirm()
		{
			if (txtCurPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("현재 비밀번호를 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChgPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("변경할 비밀번호를 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChkPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("변경할 비밀번호를 비밀번호 확인란에 한번 더 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChgPwd.EditValue.ToStringNullToEmpty() != txtChkPwd.EditValue.ToStringNullToEmpty())
			{
				MsgBox.Show("변경할 비밀번호와 비밀번호 확인이 일치해야 합니다.");
				txtChgPwd.Focus();
				return;
			}

			if (txtCurPwd.EditValue.ToStringNullToEmpty() == txtChgPwd.EditValue.ToStringNullToEmpty())
			{
				MsgBox.Show("기존 비밀번호와 변경할 비밀번호가 일치합니다. 다시 입력하세요!!!");
				txtChgPwd.Focus();
				return;
			}

			try
			{
				var ret = DBTranHelper.Execute("Auth", "ChangePassword", null, new DataMap()
				{
					{ "LOGIN_ID", GlobalVar.Settings.GetValue("LOGIN_ID") },
					{ "LOGIN_PW", txtCurPwd.EditValue },
					{ "CHG_LOGIN_PW", txtChgPwd.EditValue }
				}, null);

				if (ret.ErrorNumber != 0)
					throw new Exception(ret.ErrorMessage);

				MsgBox.Show("변경하였습니다.");
				Close();
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
