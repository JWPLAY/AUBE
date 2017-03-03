using System.Drawing;
using System.Text.RegularExpressions;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Utils;

namespace JW.AUBE.Core.Utils
{
	public static class SkinUtils
	{
		public static bool IsDarkSkin()
		{
			if (Regex.IsMatch(UserLookAndFeel.Default.SkinName, "DevExpress Dark Style|Visual Studio 2013 Dark|High Contrast|Sharp Plus|Darkroom|Blueprint|Metropolis Dark|Office 2016 Dark|Office 2016 Black"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static Color BackColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.Window);
		}
		public static Color ForeColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.WindowText);
		}
		public static Color Control()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.Control);
		}
		public static Color ControlText()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.ControlText);
		}
		public static Color DisableBackColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			if (IsDarkSkin())
			{
				return currentSkin.Colors.GetColor(CommonColors.DisabledControl);
			}
			else
			{
				return Color.WhiteSmoke;
			}
		}
		public static Color DisableForeColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			if (IsDarkSkin())
			{
				return currentSkin.Colors.GetColor(CommonColors.DisabledText);
			}
			else
			{
				return ControlText();
			}
		}
		public static Color HighlightBackColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.Highlight);
		}
		public static Color HighlightForeColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.HighlightText);
		}
		public static Color Window()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.Window);
		}
		public static Color WindowText()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			return currentSkin.Colors.GetColor(CommonColors.WindowText);
		}
		public static Color GetFocusedRowBackColor(this GridView view)
		{
			return view.Appearance.FocusedRow.BackColor;
		}
		public static Color GetFocusedRowForeColor(this GridView view)
		{
			return view.Appearance.FocusedRow.ForeColor;
		}
		public static Color EditBackColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).TranslateColor(Color.LemonChiffon);
			}
		}
		public static Color EditForeColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).TranslateColor(Color.FromArgb(39, 39, 39));
			}
		}

		public static Color GetGridSubTotalBackColor()
		{
			return Color.FromArgb(253, 233, 217);
		}
		public static Color GetGridSubTotalForeColor()
		{
			var currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
			if (IsDarkSkin())
			{
				return currentSkin.Colors.GetColor(CommonColors.ControlText);
			}
			else
			{
				return ControlText();
			}
		}

		public static Font GetFont(string fontFamilyName, FontStyle fontStyle)
		{
			try
			{
				return new Font(fontFamilyName, 10f, fontStyle);
			}
			catch
			{
				return null;
			}
		}
		public static Font GetFont(string fontFamilyName)
		{
			Font font = GetFont(fontFamilyName, FontStyle.Regular);

			if (font == null)
			{
				font = GetFont(fontFamilyName, FontStyle.Bold);
			}
			if (font == null)
			{
				font = GetFont(fontFamilyName, FontStyle.Italic);
			}
			if (font == null)
			{
				font = GetFont(fontFamilyName, FontStyle.Bold | FontStyle.Italic);
			}
			return font;
		}

		public static Color StringToColor(string rgbValue)
		{
			var color = Color.Transparent;

			if (!rgbValue.IsNullOrEmpty())
			{
				if (rgbValue.Split(',').Length == 3)
				{
					var colors = rgbValue.Split(',');
					return Color.FromArgb(colors[0].ToIntegerNullToZero(), colors[1].ToIntegerNullToZero(), colors[2].ToIntegerNullToZero());
				}
			}
			return color;
		}
		public static string ColorToString(Color color)
		{
			return string.Format("{0},{1},{2}", color.R, color.G, color.B);
		}
	}
}
