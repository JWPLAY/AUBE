using System;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Grid
{
	partial class XGrid
	{
		private void InitEmptyRepositoryItem(bool visible = false)
		{
			if (MainGrid.RepositoryItems["EmptyRepositoryItem"] == null)
			{
				var item = new RepositoryItemButtonEdit()
				{
					Name = "EmptyRepositoryItem",
					TextEditStyle = (visible) ? TextEditStyles.DisableTextEditor : TextEditStyles.HideTextEditor
				};
				item.Buttons.Clear();
				MainGrid.RepositoryItems.Add(item);
			}
			else
			{
				((RepositoryItemButtonEdit)MainGrid.RepositoryItems["EmptyRepositoryItem"]).TextEditStyle =
					(visible) ? TextEditStyles.DisableTextEditor : TextEditStyles.HideTextEditor;
			}
		}
		public RepositoryItem GetEmptyRepositoryItem(bool visible = false)
		{
			((RepositoryItemButtonEdit)MainGrid.RepositoryItems["EmptyRepositoryItem"]).TextEditStyle =
					(visible) ? TextEditStyles.DisableTextEditor : TextEditStyles.HideTextEditor;
			return MainGrid.RepositoryItems["EmptyRepositoryItem"];
		}
		public RepositoryItemSpinEdit GetEmptyRepositoryItemSpinEdit()
		{
			var formatString = "N0";

			var edit = new RepositoryItemSpinEdit()
			{
				EditMask = formatString,
				AllowFocused = false,
				ReadOnly = true
			};
			edit.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
			edit.DisplayFormat.FormatType = FormatType.Numeric;
			edit.DisplayFormat.FormatString = formatString;
			edit.EditFormat.FormatType = FormatType.Numeric;
			edit.EditFormat.FormatString = formatString;
			edit.Mask.UseMaskAsDisplayFormat = true;
			edit.Buttons.Clear();

			return edit;
		}

		public void SetRepositoryItem(string fieldName, RepositoryItem item)
		{
			if (item.GetType() == typeof(RepositoryItemSpinEdit))
			{
				((RepositoryItemSpinEdit)item).AllowMouseWheel = false;
			}
			((GridView)MainView).Columns.OfType<GridColumn>().Where(x => x.FieldName == fieldName).ToList().ForEach(x =>
			{
				x.ColumnEdit = item;
				x.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
			});

			item.EditValueChanged += delegate (object sender, EventArgs e)
			{
				MainView.PostEditor();
			};
			MainGrid.RepositoryItems.Add(item);
		}

		public RepositoryItemCheckEdit GetRepositoryItemCheckEdit(string nullValue = null)
		{
			return new RepositoryItemCheckEdit()
			{
				ValueChecked = "Y",
				ValueUnchecked = "N",
				NullStyle = StyleIndeterminate.Unchecked,
				NullText = nullValue
			};
		}

		public void SetRepositoryItemCheckEdit(string fieldName, string nullValue = null)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemCheckEdit(nullValue));
		}

		public RepositoryItemTextEdit GetRespositoryItemTextEdit()
		{
			return new RepositoryItemTextEdit();
		}

		public void SetRespositoryItemTextEdit(string fieldName)
		{
			SetRepositoryItem(fieldName, GetRespositoryItemTextEdit());
		}

		public RepositoryItemSpinEdit GetRepositoryItemSpinEdit(int precision, int? bestFitWidth = null)
		{
			var formatString = (precision == 0) ? "D" : string.Format("F{0}", precision);
			var edit = new RepositoryItemSpinEdit()
			{
				EditMask = formatString,
				AllowFocused = true
			};
			edit.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
			edit.DisplayFormat.FormatType = FormatType.Numeric;
			edit.DisplayFormat.FormatString = formatString;
			edit.EditFormat.FormatType = FormatType.Numeric;
			edit.EditFormat.FormatString = formatString;
			edit.Mask.UseMaskAsDisplayFormat = true;
			if (bestFitWidth != null)
			{
				edit.BestFitWidth = (int)bestFitWidth;
			}
			return edit;
		}

		public void SetRepositoryItemSpinEdit(string fieldName, int precision, int? bestFitWidth = null)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemSpinEdit(precision, bestFitWidth));
		}

		public RepositoryItemSpinEdit GetRepositoryItemSpinEdit(string formatString, int? bestFitWidth = null, bool buttonClear = false)
		{
			var edit = new RepositoryItemSpinEdit()
			{
				EditMask = formatString,
				AllowFocused = true
			};
			edit.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
			edit.DisplayFormat.FormatType = FormatType.Numeric;
			edit.DisplayFormat.FormatString = formatString;
			edit.EditFormat.FormatType = FormatType.Numeric;
			edit.EditFormat.FormatString = formatString;
			edit.Mask.UseMaskAsDisplayFormat = true;
			if (bestFitWidth != null)
			{
				edit.BestFitWidth = (int)bestFitWidth;
			}
			if (buttonClear)
			{
				edit.Buttons.Clear();
			}
			return edit;
		}

		public void SetRepositoryItemSpinEdit(string fieldName, string formatString, int? bestFitWidth = null, bool buttonClear = false)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemSpinEdit(formatString, bestFitWidth, buttonClear));
		}

		public RepositoryItemDateEdit GetRepositoryItemDateEdit(string formatString, int? bestFitWidth = 110)
		{
			var edit = new RepositoryItemDateEdit()
			{
				EditMask = formatString
			};
			edit.DisplayFormat.FormatType = FormatType.DateTime;
			edit.DisplayFormat.FormatString = formatString;
			edit.EditFormat.FormatString = formatString;
			edit.EditFormat.FormatType = FormatType.DateTime;
			edit.Mask.UseMaskAsDisplayFormat = true;
			edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			edit.ShowClear = true;
			edit.ShowToday = true;
			edit.AllowMouseWheel = false;
			if (bestFitWidth != null)
			{
				edit.BestFitWidth = (int)bestFitWidth;
			}
			if (formatString.Equals("yyyy.MM") || formatString.Equals("yyyy-MM"))
			{
				edit.VistaCalendarViewStyle = VistaCalendarViewStyle.YearView | VistaCalendarViewStyle.YearsGroupView | VistaCalendarViewStyle.CenturyView;
			}
			else
			{
				if (formatString.Equals("yyyy"))
				{
					edit.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView | VistaCalendarViewStyle.CenturyView;
				}
				else
				{
					edit.CalendarView = CalendarView.Classic;
					edit.Mask.UseMaskAsDisplayFormat = false;
					edit.ShowWeekNumbers = true;
					edit.VistaDisplayMode = DefaultBoolean.False;
				}
			}
			return edit;
		}

		public void SetRepositoryItemDateEdit(string fieldName, string formatString, int? bestFitWidth = 110)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemDateEdit(formatString, bestFitWidth));
		}

		public RepositoryItemLookUpEdit GetRepositoryItemLookUpEdit(string valueMember, string displayMember)
		{
			var edit = new RepositoryItemLookUpEdit()
			{
				ValueMember = valueMember,
				DisplayMember = displayMember,
				ShowHeader = false,
				NullText = ""
			};
			edit.Columns.Add(new LookUpColumnInfo(displayMember));

			return edit;
		}

		public void SetRepositoryItemLookUpEdit(string fieldName, string valueMember, string displayMember)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemLookUpEdit(valueMember, displayMember));
		}

		public RepositoryItemLookUpEdit GetRepositoryItemLookUpEdit(string valueMember, string displayMember, LookUpColumnInfo[] columns)
		{
			var edit = new RepositoryItemLookUpEdit()
			{
				ValueMember = valueMember,
				DisplayMember = displayMember,
				NullText = ""
			};
			edit.Columns.AddRange(columns);

			return edit;
		}

		public void SetRepositoryItemLookUpEdit(string fieldName, string valueMember, string displayMember, LookUpColumnInfo[] columns)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemLookUpEdit(valueMember, displayMember, columns));
		}

		public void SetRepositoryItemLookUpEdit(string fieldName, string valueMember, string displayMember, string serviceId, string processId, string sqlId, DataMap parameters)
		{
			RepositoryItemLookUpEdit edit = GetRepositoryItemLookUpEdit(valueMember, displayMember);
			edit.DataSource = DBTranHelper.GetData(serviceId, processId, sqlId, parameters).TranList[0].Data;
			SetRepositoryItem(fieldName, edit);
		}

		public void SetRepositoryItemButtonEdit(string fieldName)
		{
			SetRepositoryItem(fieldName, new RepositoryItemButtonEdit());
		}

		public RepositoryItemProgressBar GetRepositoryItemProgressBar(int minimum, int maximum, Color start, Color end, FormatType formatType, string formatString)
		{
			var item = new RepositoryItemProgressBar()
			{
				ProgressViewStyle = ProgressViewStyle.Solid,
				ShowTitle = true,
				PercentView = false,
				Minimum = minimum,
				Maximum = maximum,
				StartColor = start,
				EndColor = end
			};
			item.DisplayFormat.FormatType = formatType;
			item.DisplayFormat.FormatString = formatString;
			item.LookAndFeel.UseDefaultLookAndFeel = false;
			item.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			return item;
		}

		public void SetRepositoryItemProgressBar(string fieldName, int minimum, int maximum, Color start, Color end, FormatType formatType, string formatString)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemProgressBar(minimum, maximum, start, end, formatType, formatString));
		}
	}
}
