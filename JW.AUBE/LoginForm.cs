using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Resources;
using JW.AUBE.Core.Utils;
using JW.AUBE.Model.Auth;

namespace JW.AUBE
{
	public partial class LoginForm : BaseForm
	{
		public LoginForm()
		{
			InitializeComponent();
			Initialize();

			btnOk.Click += delegate (object sender, EventArgs e) { doLogin(); };
			btnCancel.Click += delegate (object sender, EventArgs e) { Close(); };

			txtCompanyId.GotFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("인증받은 회사ID를 입력하세요!!!");
			};
			txtCompanyId.LostFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("Ready!!");
			};

			txtLoginId.GotFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("사용자ID를 입력하세요!!!");
			};
			txtLoginId.LostFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("Ready!!");
			};

			txtPassword.GotFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("비밀번호를 입력하세요!!!");
			};
			txtPassword.LostFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("Ready!!");
			};

			txtCompanyId.KeyDown += delegate (object sender, KeyEventArgs e) { doTextKeyDown(sender, e); };
			txtLoginId.KeyDown += delegate (object sender, KeyEventArgs e) { doTextKeyDown(sender, e); };
			txtPassword.KeyDown+= delegate (object sender, KeyEventArgs e) { doTextKeyDown(sender, e); };
		}

		private void doTextKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if ((sender as TextEdit).Name == txtCompanyId.Name)
				{
					txtLoginId.Focus();
				}
				else if ((sender as TextEdit).Name == txtLoginId.Name)
				{
					txtPassword.Focus();
				}
				else if ((sender as TextEdit).Name == txtPassword.Name)
				{
					doLogin();
				}
			}
		}

		private void Initialize()
		{
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			MaximizeBox = false;
			MinimizeBox = false;
			Icon = IconResource.icon;

			lcItemCompanyId.SetFieldName("COMPANY_ID");
			lcItemLoginId.SetFieldName("LOGIN_ID");
			lcItemPassword.SetFieldName("LOGIN_PW");

			lcItemCompanyId.AppearanceItemCaption.TextOptions.HAlignment = 
				lcItemLoginId.AppearanceItemCaption.TextOptions.HAlignment = 
				lcItemPassword.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;

			picImage.Image = ImageResource.Logo;
			//picImage.Properties.SizeMode = PictureSizeMode.Stretch;
			
			txtCompanyId.EditValue = "1000";
			txtLoginId.EditValue = "admin";
			txtPassword.EditValue = "admin";

			lcItemCompanyId.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtLoginId.Focus();
		}

		private void SetStatusMessage(string msg)
		{
			barMessage.Caption = string.Format(" >>> {0}", msg);
		}

		private void doLogin()
		{
			try
			{
				if (txtCompanyId.EditValue.ToStringNullToEmpty() == string.Empty)
				{
					MsgBox.Show("회사코드를 입력해야 합니다.");
					txtCompanyId.Focus();
					return;
				}

				if (txtLoginId.EditValue.ToStringNullToEmpty() == string.Empty)
				{
					MsgBox.Show("접속 아이디를 입력하세요!!!");
					txtLoginId.Focus();
					return;
				}

				if (txtPassword.EditValue.ToStringNullToEmpty() == string.Empty)
				{
					MsgBox.Show("비밀번호를 입력하세요!!!");
					txtPassword.Focus();
					return;
				}

				var data = DBTranHelper.GetData("Auth", "CheckLoginUser", null, new DataMap()
				{
					{ "LOGIN_ID", txtLoginId.EditValue },
					{ "LOGIN_PW", txtPassword.EditValue }
				}).TranList[0].Data;

				if (data == null)
					throw new Exception("로그인 사용자의 정보가 정확하지 않습니다.");

				GlobalVar.Settings.SetValue("USER_ID", (data as LoginUserDataModel).USER_ID);
				GlobalVar.Settings.SetValue("USER_NAME", (data as LoginUserDataModel).USER_NAME);

				SetModifiedCount();
				Close();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
