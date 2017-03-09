using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using JW.AUBE.Base.Constants;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Variables
{
	public static class Setting
	{
		public static void Init()
		{
			try
			{
				Logger.Debug("Setting Start!!");

				GlobalVar.DatabaseId = "REAL";
				GlobalVar.ServerUrl = ServerConsts.REAL;

				GlobalVar.Settings.SetValue("IS_USESKIN", SkinConsts.IS_USESKIN);
				GlobalVar.Settings.SetValue("MAIN_SKIN", SkinConsts.MAIN_SKIN);
				GlobalVar.Settings.SetValue("FORM_SKIN", SkinConsts.FORM_SKIN);
				GlobalVar.Settings.SetValue("GRID_SKIN", SkinConsts.GRID_SKIN); 
				GlobalVar.Settings.SetValue("GRID_EVEN_AND_ODD", SkinConsts.GRID_EVEN_AND_ODD);

				if (FontFamily.Families.Where(x => x.Name == SkinConsts.FONT_NAME).Any())
				{
					GlobalVar.Settings.SetValue("FONT_NAME", SkinConsts.FONT_NAME);
				}
				else
				{
					GlobalVar.Settings.SetValue("FONT_NAME", SystemFonts.DefaultFont.Name);
				}
				GlobalVar.Settings.SetValue("FONT_SIZE", SkinConsts.FONT_SIZE);
				AppearanceObject.DefaultFont = new Font(GlobalVar.Settings.GetValue("FONT_NAME").ToStringNullToEmpty(), (float)GlobalVar.Settings.GetValue("FONT_SIZE"));

				GlobalVar.Settings.SetValue("VISIBLE_TOOLBAR_NAME", "YES");
				GlobalVar.Settings.SetValue("COMPANY_NAME", "JW.Play");
				GlobalVar.Settings.SetValue("DEPARTMENT_NAME", "Development Division");
				GlobalVar.Settings.SetValue("USER_NAME", "Manager");
				GlobalVar.Settings.SetValue("MAINFORM_WINDOW_STATE", FormWindowState.Maximized);

				SplashUtils.ShowWait("리소스 데이터를 생성하는 중입니다... 잠시만...");

				DomainUtils.Init();

				try
				{
					DataTable data = ServerRequest.SingleRequest("Auth", "GetSettings", "Setting", new DataMap());
					if (data != null && data.Rows.Count > 0)
					{
						foreach (DataRow row in data.Rows)
						{
							GlobalVar.Settings.SetValue(row["CODE"].ToString(), row["VALUE"]);
						}
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}

				try
				{
					DomainUtils.SetData();
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
				SplashUtils.CloseWait();
				Logger.Debug("Setting End!!");
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
