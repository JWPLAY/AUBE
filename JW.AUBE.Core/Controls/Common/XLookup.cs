using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Helper;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Common
{
	[ToolboxItem(true)]
	public partial class XLookup : LookUpEdit, IControlExtension
	{
		public bool mIsEnable = true;
		private int _recordCount = 0;
		private string _nullText = string.Empty;
		private bool _mNullable = false;
		private string _listMember = "LIST_NAME";
		private bool _IsSetInit = false;

		public XLookup()
		{
			InitializeComponent();

			if (!DesignMode)
			{
				Paint += delegate (object sender, System.Windows.Forms.PaintEventArgs e)
				{
					if (Properties.ReadOnly == false && Enabled)
					{
						if (!Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Combo).Any())
						{
							Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
						}

						if (_mNullable && !Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).Any())
						{
							Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
						}
						else
						{
							if (_mNullable == false && Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).Any())
							{
								ClearDeleteButton();
							}
						}
					}
					else
					{
						Properties.Buttons.Clear();
					}
				};
			}
			ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == ButtonPredefines.Delete)
				{
					EditValue = null;
				}
			};
		}

		[Browsable(false)]
		public object DataSource
		{
			get
			{
				return Properties.DataSource;
			}
			set
			{
				BeginUpdate();
				Properties.DataSource = value;

				if (value != null)
				{
					if (value.GetType() == typeof(DataTable))
					{
						var dt = (DataTable)value;

						if (dt.Rows.Count > 0 && dt.Columns.Contains(ValueMember) && dt.Columns.Contains(DisplayMember) && !string.IsNullOrEmpty(_nullText))
						{
							var firstRow = dt.NewRow();
							firstRow[DisplayMember] = _nullText;
							firstRow[ListMember] = _nullText;
							dt.Rows.InsertAt(firstRow, 0);
						}

						if (Properties.ReadOnly && dt.Rows.Count > 0 && dt.Columns.Contains(ValueMember))
						{
							EditValue = dt.Rows[0][ValueMember];
						}
						_recordCount = dt.Rows.Count;
					}
					else
					{
						if (value.GetType() == typeof(IList))
						{
							_recordCount = ((IList)value).Count;
						}
					}
				}
				else
				{
					_recordCount = 0;
				}

				EndUpdate();
			}
		}

		[Browsable(true)]
		public string GroupCode { get; set; }

		[Browsable(true)]
		public string ValueMember
		{
			get
			{
				return Properties.ValueMember;
			}
			set
			{
				Properties.ValueMember = value;
			}
		}

		[Browsable(true)]
		public string DisplayMember
		{
			get
			{
				return Properties.DisplayMember;
			}
			set
			{
				Properties.DisplayMember = value;
			}
		}

		[Browsable(true)]
		public string ListMember
		{
			get
			{
				return _listMember;
			}
			set
			{
				_listMember = value;
			}
		}

		[Browsable(false)]
		public LookUpColumnInfoCollection Columns
		{
			get
			{
				return Properties.Columns;
			}
		}

		[Browsable(true)]
		public string NullText
		{
			get
			{
				return Properties.NullText;
			}
			set
			{
				Properties.NullText = value;
			}
		}

		[Browsable(false)]
		public int RowCount
		{
			get
			{
				return _recordCount;
			}
		}

		[Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				return ItemIndex;
			}
			set
			{
				var dt = (DataTable)DataSource;
				if (dt != null)
				{
					ItemIndex = value;
					EditValue = dt.Rows[value][ValueMember];
				}
			}
		}

		public void Init()
		{
			Properties.BestFitMode = BestFitMode.BestFit;
			Properties.SearchMode = SearchMode.AutoComplete;
			Properties.AutoSearchColumnIndex = 1;
			Properties.AllowNullInput = DefaultBoolean.False;
			Properties.ShowHeader = false;
			Properties.ShowFooter = false;
			NullText = string.Empty;
		}

		public void Clear()
		{
			EditValue = null;
		}

		public void ShowDeleteButton()
		{
			Properties.Buttons.OfType<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).ToList().ForEach(x =>
				x.Visible = true
			);
		}
		public void HideDeleteButton()
		{
			Properties.Buttons.OfType<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).ToList().ForEach(x =>
				x.Visible = false
			);
		}
		public void ClearDeleteButton()
		{
			foreach (var item in Properties.Buttons.OfType<EditorButton>().ToList().Where(button => button.Kind == ButtonPredefines.Delete))
			{
				Properties.Buttons.RemoveAt(item.Index);
			}
		}

		private void AddDeleteButton()
		{
			foreach (var item in Properties.Buttons.OfType<EditorButton>().ToList().Where(button => button.Kind == ButtonPredefines.Delete))
			{
				Properties.Buttons.RemoveAt(item.Index);
			}
			Properties.Buttons.Add(new EditorButton() { Kind = ButtonPredefines.Delete });
		}

		public void AddColumn(string fieldName)
		{
			AddColumn(fieldName, ResourceUtils.GetColumnCaption(fieldName));
		}
		public void AddColumn(string fieldName, string caption)
		{
			Properties.Columns.Add(new LookUpColumnInfo()
			{
				FieldName = fieldName,
				Caption = caption
			});
		}

		public void AddColumns(string[] columns)
		{
			if (columns != null)
			{
				foreach (string col in columns)
				{
					AddColumn(col);
				}
			}
		}

		public void SetValueAndDisplayMember(string valueMember, string displayMember)
		{
			if (!string.IsNullOrEmpty(valueMember))
			{
				ValueMember = valueMember;
			}
			if (!string.IsNullOrEmpty(displayMember))
			{
				DisplayMember = displayMember;
			}
		}

		public void SetDefault(bool bDeleteButtonVisible = true)
		{
			Init();
			Columns.Clear();
			SetValueAndDisplayMember("CODE", "NAME");
			AddColumns(new string[] { "CODE", "NAME", "LIST_NAME" });

			for (var i = 1; i < 6; i++)
			{
				AddColumn(string.Format("OPTION_VALUE{0}", i.ToString()));
				Columns[string.Format("OPTION_VALUE{0}", i.ToString())].Visible = false;
			}

			Columns["CODE"].Visible = false;
			Columns["NAME"].Visible = false;

			_mNullable = false;
			ClearDeleteButton();
			if (bDeleteButtonVisible)
			{
				AddDeleteButton();
			}
			_IsSetInit = true;
		}

		public void SetNullText(string text)
		{
			SetDefault();
			Properties.AllowNullInput = DefaultBoolean.True;
			Properties.NullText = text;
			_nullText = text;
			_mNullable = true;
		}
		public void SetNullText()
		{
			SetNullText("None");
		}

		public void BindData(string groupCode, DataMap parameters = null, string nullText = null, bool init = false)
		{
			if (init == true || _IsSetInit == false)
			{
				if (nullText.IsNullOrEmpty())
				{
					SetDefault();
				}
				else
				{
					SetNullText(nullText);
				}
			}

			if (groupCode.IsNullOrEmpty() == false)
			{
				GroupCode = groupCode;
			}
			object value = null;
			if (DataSource != null && EditValue != null)
			{
				value = EditValue;
			}
			DataSource = CodeHelper.Lookup(GroupCode, parameters);
			if (RowCount > 0)
			{
				if (value != null)
				{
					EditValue = value;
				}
				else
				{
					if (Properties.AllowNullInput == DefaultBoolean.False)
					{
						SelectedIndex = 0;
					}
					else
					{
						EditValue = null;
					}
				}

				if (RowCount <= 20)
				{
					Properties.DropDownRows = RowCount;
				}
				else
				{
					Properties.DropDownRows = 20;
				}
			}
		}

		public int GetRowCount()
		{
			return Properties.DropDownRows;
		}

		public int GetSelectedIndex()
		{
			return ItemIndex;
		}

		public void SetSelectedIndex(int index)
		{
			ItemIndex = index;
		}

		public object GetCodeValue(int index)
		{
			try
			{
				var columnName = string.Format("OPTION_VALUE{0}", index);
				var data = GetSelectedDataRow();

				if (data == null)
				{
					return null;
				}
				if ((data as DataRowView).DataView.Table.Columns.Contains(columnName))
				{
					return (data as DataRowView).Row[columnName];
				}
				else
				{
					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		public void SetForeColor(Color color)
		{
			Properties.Appearance.Options.UseForeColor = true;
			Properties.Appearance.ForeColor = color;
		}

		public void SetEnable(bool bEnable = false, Color? backColor = null)
		{
			mIsEnable = bEnable;
			Properties.AllowFocused = bEnable;
			Properties.ReadOnly = !bEnable;

			if (bEnable == false)
			{
				Properties.Appearance.BackColor = SkinUtils.DisableBackColor;
				Properties.Appearance.ForeColor = SkinUtils.DisableForeColor;
			}
			else
			{
				Properties.Appearance.Options.UseBackColor = false;
				Properties.Appearance.Options.UseForeColor = false;
			}

			if (backColor != null)
			{
				Properties.Appearance.Options.UseBackColor = true;
				Properties.Appearance.BackColor = (Color)backColor;
			}

			if (Properties.Buttons.Count > 0)
			{
				foreach (EditorButton btn in Properties.Buttons)
				{
					btn.Visible = bEnable;
				}
			}
		}

		protected override void OnEnter(EventArgs e)
		{
			//if (!Properties.ReadOnly && Enabled)
			//{
			//	BackColor = SkinUtils.EditBackColor;
			//	ForeColor = SkinUtils.EditForeColor;
			//}
			base.OnEnter(e);
		}
		protected override void OnLeave(EventArgs e)
		{
			//if (!Properties.ReadOnly && Enabled)
			//{
			//	BackColor = SkinUtils.BackColor();
			//	ForeColor = SkinUtils.ForeColor();
			//}
			base.OnLeave(e);
		}
	}
}
