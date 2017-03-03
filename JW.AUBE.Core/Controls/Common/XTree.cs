using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JW.AUBE.Core.Utils;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace JW.AUBE.Core.Controls.Common
{
	[ToolboxItem(true)]
	public partial class XTree : TreeList
	{
		public XTree()
		{
			InitializeComponent();
			Initialize();
		}


		public void Initialize()
		{
			try
			{
				BeforeCheckNode += delegate (object sender, CheckNodeEventArgs e)
				{
					BeginUpdate();
					ToggleChildren(e.Node, e.State);
					EndUpdate();
				};

				OptionsView.EnableAppearanceEvenRow = true;
				OptionsView.EnableAppearanceOddRow = true;
				OptionsView.AutoWidth = false;
				OptionsBehavior.AllowExpandOnDblClick = false;
				OptionsBehavior.PopulateServiceColumns = true;
				OptionsSelection.EnableAppearanceFocusedRow = true;
			}
			catch
			{
				throw;
			}
		}

		public void SetColumnBackColor(string fieldName, Color color)
		{
			Columns[fieldName].AppearanceCell.Options.UseBackColor = true;
			Columns[fieldName].AppearanceCell.BackColor = color;
		}

		public void SetColumnForeColor(string fieldName, Color color)
		{
			Columns[fieldName].AppearanceCell.Options.UseForeColor = true;
			Columns[fieldName].AppearanceCell.ForeColor = color;
		}

		public void SetFocusedRowBackColor(Color color)
		{
			Appearance.FocusedRow.Options.UseBackColor = true;
			Appearance.FocusedRow.BackColor = color;
		}

		private void ToggleChildren(TreeListNode parent, CheckState check)
		{
			parent.Nodes.Cast<TreeListNode>().ToList().ForEach(x =>
				{
					SetNodeCheckState(x, check);
					if (x.HasChildren)
					{
						ToggleChildren(x, check);
					}
				});
		}

		public TreeListColumn AddColumn()
		{
			return Columns.Add();
		}
		public TreeListColumn AddColumn(string fieldName, string caption, HorzAlignment align, FormatType formatType, string formatString, bool visible, bool readOnly, int width)
		{
			try
			{
				if (string.IsNullOrEmpty(caption))
				{
					caption = DomainUtils.GetFieldName(fieldName.ToUpper()).Trim().Replace(" ", string.Empty);
				}
				var col = AddColumn();

				col.Name = "COL_" + fieldName.ToUpper();
				col.AppearanceCell.Options.UseTextOptions = true;
				col.AppearanceCell.TextOptions.HAlignment = align;
				col.Caption = caption;
				col.CustomizationCaption = caption;
				col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
				col.FieldName = fieldName;

				col.Format.FormatType = formatType;
				if (!string.IsNullOrEmpty(formatString))
				{
					col.Format.FormatString = formatString;
				}

				if (Editable == false || readOnly)
				{
					col.OptionsColumn.ReadOnly = true;
					col.OptionsColumn.AllowEdit = false;
					col.OptionsColumn.AllowFocus = false;
				}
				else
				{
					col.OptionsColumn.ReadOnly = false;
					col.OptionsColumn.AllowEdit = true;
					col.OptionsColumn.AllowFocus = true;
				}

				if (width > 0)
				{
					col.OptionsColumn.AllowSize = false;
					col.Width = width;
				}
				col.Visible = visible;
				if (visible)
				{
					col.VisibleIndex = Columns.Count;
				}
				return col;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
		public TreeListColumn AddColumn(string fieldName)
		{
			return AddColumn(fieldName, null, HorzAlignment.Near, FormatType.None, null, true, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, bool visible)
		{
			return AddColumn(fieldName, null, HorzAlignment.Near, FormatType.None, null, visible, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, string caption)
		{
			return AddColumn(fieldName, caption, HorzAlignment.Near, FormatType.None, null, true, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, HorzAlignment align)
		{
			return AddColumn(fieldName, null, align, FormatType.None, null, true, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, HorzAlignment align, bool readOnly)
		{
			return AddColumn(fieldName, null, align, FormatType.None, null, true, readOnly, 0);
		}
		public TreeListColumn AddColumn(string fieldName, HorzAlignment align, FormatType formatType, string formatString)
		{
			return AddColumn(fieldName, null, align, formatType, formatString, true, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, string caption, bool visible)
		{
			return AddColumn(fieldName, caption, HorzAlignment.Near, FormatType.None, null, visible, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, string caption, HorzAlignment align)
		{
			return AddColumn(fieldName, caption, align, FormatType.None, null, true, true, 0);
		}
		public TreeListColumn AddColumn(string fieldName, string caption, HorzAlignment align, FormatType formatType, string formatString)
		{
			return AddColumn(fieldName, caption, align, formatType, formatString, true, true, 0);
		}

		public void SetFormat(int colIndex, FormatType formatType, string formatString)
		{
			Columns[colIndex].Format.FormatType = formatType;
			Columns[colIndex].Format.FormatString = formatString;
		}
		public void SetFormat(string fieldName, FormatType formatType, string formatString)
		{
			Columns[fieldName].Format.FormatType = formatType;
			Columns[fieldName].Format.FormatString = formatString;
		}

		/// <summary>
		/// 컬럼의 Width를 조정합니다.
		/// </summary>
		/// <param name="colIndex">컬럼ID</param>
		/// <param name="width">Width</param>
		public void SetWidth(int colIndex, int width)
		{
			Columns[colIndex].Width = width;
			Columns[colIndex].OptionsColumn.FixedWidth = true;
		}
		/// <summary>
		/// 컬럼의 Width를 조정합니다.
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="width">Width</param>
		public void SetWidth(string fieldName, int width)
		{
			Columns[fieldName].Width = width;
			Columns[fieldName].OptionsColumn.FixedWidth = true;
		}

		public void SetHorzAlign(int colIndex, HorzAlignment hAlign)
		{
			Columns[colIndex].AppearanceCell.Options.UseTextOptions = true;
			Columns[colIndex].AppearanceCell.TextOptions.HAlignment = hAlign;
		}
		public void SetHorzAlign(string fieldName, HorzAlignment hAlign)
		{
			Columns[fieldName].AppearanceCell.Options.UseTextOptions = true;
			Columns[fieldName].AppearanceCell.TextOptions.HAlignment = hAlign;
		}

		public void Sort(string[] columns, SortOrder[] sortOrder)
		{
			if (columns == null)
			{
				return;
			}
			BeginSort();

			for (var i = 0; i < columns.Length; i++)
			{
				if (sortOrder == null || sortOrder.Length < (i + 1))
				{
					Columns[columns[i]].SortOrder = SortOrder.Ascending;
				}
				else
				{
					Columns[columns[i]].SortOrder = sortOrder[i];
				}
			}
			EndSort();
		}

		public void ExpandLevel(int level, TreeListNodes nodes = null)
		{
			if (nodes == null)
			{
				nodes = Nodes;
			}
			nodes.Where(x => x.Level > level).ToList().ForEach(x => x.Expanded = false);

			nodes.Where(x => x.Level <= level).ToList().ForEach(x =>
				{
					x.Expanded = true;
					if (x.HasChildren)
					{
						ExpandLevel(level, x.Nodes);
					}
				});
		}

		public void SetRepositoryItem(string fieldName, RepositoryItem item)
		{
			RepositoryItems.Add(item);
			Columns.Where(x => x.FieldName == fieldName).ToList().ForEach(x =>
				{
					x.ColumnEdit = item;
					x.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
				});
			item.EditValueChanged += delegate (object sender, EventArgs e)
			{
				PostEditor();
			};
		}

		public RepositoryItemTextEdit GetRespositoryItemTextEdit()
		{
			return new RepositoryItemTextEdit();
		}

		public void SetRespositoryItemTextEdit(string fieldName)
		{
			SetRepositoryItem(fieldName, GetRespositoryItemTextEdit());
		}

		public RepositoryItemSpinEdit GetRepositoryItemSpinEdit(int precision)
		{
			var item = new RepositoryItemSpinEdit()
			{ EditMask = (precision == 0) ? "D" : string.Format("F{0}", precision),
				AllowFocused = true
			};
			item.DisplayFormat.FormatType = FormatType.Numeric;
			item.DisplayFormat.FormatString = (precision == 0) ? "D" : string.Format("F{0}", precision);
			item.AllowFocused = true;
			return item;
		}

		public void SetRepositoryItemSpinEdit(string fieldName, int precision)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemSpinEdit(precision));
		}

		public RepositoryItemLookUpEdit GetRepositoryItemLookUpEdit(string valueMember, string displayMember, LookUpColumnInfo[] columns)
		{
			var item = new RepositoryItemLookUpEdit()
			{ ValueMember = valueMember,
				DisplayMember = displayMember
			};
			item.Columns.AddRange(columns);
			return item;
		}

		public void SetRepositoryItemLookUpEdit(string fieldName, string valueMember, string displayMember, LookUpColumnInfo[] columns)
		{
			SetRepositoryItem(fieldName, GetRepositoryItemLookUpEdit(valueMember, displayMember, columns));
		}

		public void Export()
		{
			Export(null);
		}
		public void Export(string fileName)
		{
		}

		public void ToExcel(string fileName = null)
		{
		}
		public void ToExcelByDataSource(string fileName = null)
		{
		}
		public void ToClipboard()
		{
			CopyToClipboard();
		}
	}
}
