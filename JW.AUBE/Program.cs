using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using JW.AUBE.Base.Constants;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;
using JW.AUBE.Core.Variables;

namespace JW.AUBE
{
	internal static class Program
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			BonusSkins.Register();
			SkinManager.EnableFormSkins();
			UserLookAndFeel.Default.SetSkinStyle(SkinConsts.MAIN_SKIN);
			UserLookAndFeel.Default.UseDefaultLookAndFeel = true;
			UserLookAndFeel.Default.UseWindowsXPTheme = false;
			AppearanceObject.DefaultFont = SystemFonts.DefaultFont;

			Logger.Debug("IIS Start!!");
			SplashUtils.ShowWait("IIS를 구동하는 중입니다... 잠시만...");
			//IISExpress.Start("AubeWeb");
			WebSiteContoller.SiteInvoke(JW.AUBE.Core.Utils.WebSiteContoller.SiteAction.Start);

			Logger.Debug("Application Start!!");

			try
			{
				Setting.Init();

				if (GlobalVar.Settings.GetValue("IS_USESKIN").ToBooleanNullToFalse())
				{
					if (GlobalVar.Settings.GetValue("MAIN_SKIN").ToStringNullToEmpty() != SkinConsts.MAIN_SKIN)
					{
						UserLookAndFeel.Default.SetSkinStyle(GlobalVar.Settings.GetValue("MAIN_SKIN").ToStringNullToEmpty());
					}
				}
				else
				{
					UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
					UserLookAndFeel.Default.UseWindowsXPTheme = true;
				}

				if (GlobalVar.Settings.GetValue("FONT_NAME").ToStringNullToEmpty() != SkinConsts.FONT_NAME ||
					Convert.ToSingle(GlobalVar.Settings.GetValue("FONT_SIZE")) != SkinConsts.FONT_SIZE)
				{
					AppearanceObject.DefaultFont = new Font(GlobalVar.Settings.GetValue("FONT_NAME").ToStringNullToEmpty(), Convert.ToSingle(GlobalVar.Settings.GetValue("FONT_SIZE")));
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}

			try
			{
				using (var f = new LoginForm()
				{
					Name = "LoginForm",
					Text = "로그인"
				})
				{
					if (f.ShowDialog() != DialogResult.OK)
					{
						Logger.Debug("Application Exit!!");
						Application.ExitThread();
						Environment.Exit(0);
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}

			try
			{
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}
			Logger.Debug("Application Close!!");
		}
	}
}
