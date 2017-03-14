using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Enumerations;

namespace JW.AUBE.Core.Utils
{
	public static class ControlUtils
	{
		/* **************************************************************************
		 * CheckEdit
		** *************************************************************************/
		public static void Init(this CheckEdit edit)
		{
			edit.Properties.AutoWidth = true;
			edit.Properties.ValueChecked = "Y";
			edit.Properties.ValueUnchecked = "N";
			edit.EditValue = "N";
			edit.Checked = false;
		}
		public static void Clear(this CheckEdit edit)
		{
			edit.CheckState = CheckState.Indeterminate;
		}
		public static void SetEnable(this CheckEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;
		}

		/* **************************************************************************
		 * LayoutControl
		** *************************************************************************/
		public static void Init(this LayoutControl control)
		{
			control.AllowCustomization = false;
		}

		/* **************************************************************************
		 * MemoEdit
		** *************************************************************************/
		public static void Init(this MemoEdit edit)
		{
			edit.EditValue = null;
		}
		public static void Clear(this MemoEdit edit)
		{
			edit.EditValue = null;
		}
		public static void SetEnable(this MemoEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;
		}

		/* **************************************************************************
		 * SpinEdit
		** *************************************************************************/
		public static void Init(this SpinEdit edit)
		{
			edit.Properties.AllowMouseWheel = false;
		}
		public static void Clear(this SpinEdit edit)
		{
			edit.EditValue = 0;
		}
		public static void SetFormat(this SpinEdit edit, string formatString, bool visibleButtons = true, HorzAlignment hAlign = HorzAlignment.Far)
		{
			edit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
			edit.Properties.DisplayFormat.FormatString = formatString;
			edit.Properties.Mask.UseMaskAsDisplayFormat = true;
			edit.Properties.EditFormat.FormatType = FormatType.Numeric;
			edit.Properties.EditFormat.FormatString = formatString;
			edit.Properties.EditMask = formatString;
			edit.Properties.Appearance.TextOptions.HAlignment = hAlign;

			if (visibleButtons == false)
				edit.ButtonClear();
		}
		public static void SetEnable(this SpinEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;

			if (edit.Properties.Buttons.Count > 0)
			{
				foreach (EditorButton btn in edit.Properties.Buttons)
				{
					btn.Visible = enable;
				}
			}
		}
		public static void ButtonClear(this SpinEdit edit)
		{
			edit.Properties.Buttons.Clear();
		}
		public static void ButtonHide(this SpinEdit edit)
		{
			foreach (EditorButton btn in edit.Properties.Buttons)
			{
				btn.Visible = false;
			}
		}

		/* **************************************************************************
		 * DateEdit
		** *************************************************************************/
		public static void Init(this DateEdit edit)
		{
			edit.Init(CalendarViewType.DayView);
		}
		public static void Clear(this DateEdit edit)
		{
			edit.EditValue = null;
		}
		public static void SetEnable(this DateEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;

			if (edit.Properties.Buttons.Count > 0)
			{
				foreach (EditorButton btn in edit.Properties.Buttons)
				{
					btn.Visible = enable;
				}
			}
		}
		public static void Init(this DateEdit edit, CalendarViewType viewType = CalendarViewType.DayView)
		{
			edit.Properties.AllowMouseWheel = false;
			edit.Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
			edit.Properties.ShowClear = true;
			edit.Properties.ShowToday = true;

			if (viewType == CalendarViewType.DayView)
			{
				edit.Properties.CalendarView = CalendarView.Classic;
				edit.Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
				edit.Properties.VistaDisplayMode = DefaultBoolean.False;
				edit.Properties.Mask.EditMask = "d";
				edit.Properties.Mask.UseMaskAsDisplayFormat = false;
				edit.Properties.ShowWeekNumbers = true;
			}
			else
			{
				if (viewType == CalendarViewType.MonthView)
				{
					edit.Properties.CalendarView = CalendarView.Vista;
					edit.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearView | VistaCalendarViewStyle.YearsGroupView | VistaCalendarViewStyle.CenturyView;

					edit.Properties.Mask.EditMask = "y";
					edit.Properties.Mask.UseMaskAsDisplayFormat = true;
					edit.Properties.VistaDisplayMode = DefaultBoolean.True;
				}
				else
				{
					if (viewType == CalendarViewType.YearView)
					{
						edit.Properties.CalendarView = CalendarView.Vista;
						edit.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView | VistaCalendarViewStyle.CenturyView;

						edit.Properties.Mask.EditMask = "yyyy";
						edit.Properties.Mask.UseMaskAsDisplayFormat = true;
						edit.Properties.VistaDisplayMode = DefaultBoolean.True;
					}
				}
			}
			edit.EditValue = DateTime.Now;
		}

		public static string GetDateChar8(this DateEdit edit)
		{
			return (edit.EditValue == null) ? null : string.Format("{0:yyyyMMdd}", Convert.ToDateTime(edit.EditValue));
		}
		public static void SetDateChar8(this DateEdit edit, object value)
		{
			if (value != null && !string.IsNullOrEmpty(value.ToStringNullToEmpty()))
			{
				edit.EditValue = Convert.ToDateTime(value.ToDateTime("yyyy-MM-dd")).ToShortDateString();
			}
		}
		public static string GetDateChar10(this DateEdit edit)
		{
			return (edit.EditValue == null) ? null : string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(edit.EditValue));
		}
		public static string GetDateChar6(this DateEdit edit)
		{
			return (edit.EditValue == null) ? null : string.Format("{0:yyyyMM}", Convert.ToDateTime(edit.EditValue));
		}
		public static void SetDateChar6(this DateEdit edit, object value)
		{
			if (value != null && !string.IsNullOrEmpty(value.ToStringNullToEmpty()))
			{
				edit.EditValue = Convert.ToDateTime((value + "01").ToDateTime("yyyy-MM-dd")).ToShortDateString();
			}
		}
		public static string GetDateChar4(this DateEdit edit)
		{
			return (edit.EditValue == null) ? null : string.Format("{0:yyyy}", Convert.ToDateTime(edit.EditValue));
		}
		public static void SetFormat(this DateEdit edit, string formatString = "yyyy-MM-dd")
		{
			edit.Properties.EditFormat.FormatType = FormatType.DateTime;
			edit.Properties.EditFormat.FormatString = formatString;
			edit.Properties.DisplayFormat.FormatType = FormatType.DateTime;
			edit.Properties.DisplayFormat.FormatString = formatString;
			edit.Properties.Mask.MaskType = MaskType.DateTime;
			edit.Properties.Mask.EditMask = formatString;
		}
		public static void SetFormatDate(this DateEdit edit)
		{
			edit.SetFormat("yyyy-MM-dd");
		}

		public static void SetFormatDateTime(this DateEdit edit)
		{
			edit.SetFormat("yyyy-MM-dd HH:mm:ss");
		}

		public static void SetFormatDateTimeMin(this DateEdit edit)
		{
			edit.SetFormat("yyyy-MM-dd HH:mm");
		}

		/* **************************************************************************
		 * ButtonEdit
		** *************************************************************************/
		public static void Init(this ButtonEdit edit)
		{
			return;
		}
		public static void Clear(this ButtonEdit edit)
		{
			edit.EditValue = null;
		}
		public static void SetEnable(this ButtonEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;
		}

		/* **************************************************************************
		 * TextEdit
		** *************************************************************************/
		public static void Init(this TextEdit edit)
		{
			edit.Clear();
		}
		public static void Clear(this TextEdit edit)
		{
			edit.EditValue = null;
		}
		public static void SetEnable(this TextEdit edit, bool enable = false)
		{
			edit.Properties.AllowFocused = enable;
			edit.Properties.ReadOnly = !enable;
		}

		/* **************************************************************************
		 * WebBrowser
		** *************************************************************************/
		public static void Init(this WebBrowser web)
		{
			web.ScriptErrorsSuppressed = true;
			web.IsWebBrowserContextMenuEnabled = false;
		}
	}
}
