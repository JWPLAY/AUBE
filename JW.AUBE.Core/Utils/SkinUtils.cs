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
		public static bool IsDarkSkin
		{
			get
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
		}
		public static Color FormBackColor { get { return Color.FromArgb(74, 74, 74); } }
		public static Color BackColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.Window);
			}
		}
		public static Color ForeColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.WindowText);
			}
		}
		public static Color ControlColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.Control);
			}
		}
		public static Color ControlTextColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.ControlText);
			}
		}
		public static Color EditSkinBackColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default)[CommonSkins.SkinTextControl].Color.BackColor;
			}
		}
		public static Color EditSkinForeColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default)[CommonSkins.SkinTextControl].Color.ForeColor;
			}
		}
		public static Color DisableBackColor
		{
			get
			{
				if (IsDarkSkin)
				{
					return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.DisabledControl);
				}
				else
				{
					return Color.WhiteSmoke;
				}
			}
		}
		public static Color DisableForeColor
		{
			get
			{
				if (IsDarkSkin)
				{
					return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.DisabledText);
				}
				else
				{
					return ControlTextColor;
				}
			}
		}
		public static Color HighlightBackColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.Highlight);
			}
		}
		public static Color HighlightForeColor
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.HighlightText);
			}
		}
		public static Color Window
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.Window);
			}
		}
		public static Color WindowText
		{
			get
			{
				return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.WindowText);
			}
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
		public static Color GridSubTotalBackColor
		{
			get
			{
				return Color.FromArgb(253, 233, 217);
			}
		}
		public static Color GridSubTotalForeColor
		{
			get
			{
				if (IsDarkSkin)
				{
					return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.ControlText);
				}
				else
				{
					return ControlTextColor;
				}
			}
		}

		public static Color FocusedRowBackColor(this GridView view)
		{
			return view.Appearance.FocusedRow.BackColor;
		}
		public static Color FocusedRowForeColor(this GridView view)
		{
			return view.Appearance.FocusedRow.ForeColor;
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
