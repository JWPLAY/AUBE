using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Helper
{
	public partial class CodeHelperForm : BaseForm
	{
		public CodeHelperForm()
		{
			InitializeComponent();
			Initialize();

			txtFindText.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					BindData();
				}
				else
				{
					if (e.KeyCode == Keys.Escape)
					{
						ReturnData = null;
						Close();
					}
				}
			};
			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
				{
					return;
				}
				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					if (e.RowHandle < 0)
					{
						return;
					}
					SetReturnDataAndClose();
				}
			};
			gridList.MainView.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					if (gridList.MainView.FocusedRowHandle < 0)
					{
						return;
					}
					SetReturnDataAndClose();
				}
			};
		}

		private void Initialize()
		{
			Parameters = new DataMap();
		}

		public string[] DisplayFields { get; set; }
		public DataMap Parameters { get; set; }
		public string CodeField { get; set; }
		public string NameField { get; set; }
		public string CodeGroup { get; set; }

		public void Init()
		{
			lcItemFindText.SetFieldName("FIND_TEXT");
			lcItemUseYn.SetFieldName("USE_YN");

			lupUseYn.BindData("YESNO_YN", null, "ALL", true);
			if (Parameters != null)
			{
				lupUseYn.EditValue = Parameters.GetValue("USE_YN");
			}

			gridList.Init();
			if (DisplayFields != null)
			{
				var columns = new List<XGridColumn>();
				foreach (string field in DisplayFields)
				{
					columns.Add(new XGridColumn() { FieldName = field });
				}
				gridList.AddGridColumns(columns.ToArray());
				
			}
			SetColumnWidth();
		}
		public void Init(string codeField, string nameField, DataMap parameters, params string[] displayFields)
		{
			CodeField = codeField;
			NameField = nameField;
			Parameters = parameters;
			DisplayFields = displayFields;
			Init();
		}

		public void BindData(DataTable data = null)
		{
			if (data == null)
			{
				if (txtFindText.EditValue != null)
				{
					Parameters.SetValue("FIND_TEXT", txtFindText.EditValue);
				}
				if (Parameters == null)
					Parameters = new DataMap();

				Parameters.SetValue("USE_YN", lupUseYn.EditValue);

				data = CodeHelper.Search(CodeGroup, Parameters);
				if (data == null)
				{
					MsgBox.Show("검색된 데이터가 없습니다.");
					txtFindText.Focus();
					return;
				}
			}

			if (data != null)
			{
				gridList.DataSource = data;
				SetGridColumnName(data);
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if (gridList.MainView.RowCount > 0)
			{
				gridList.MainView.Focus();
			}
			else
			{
				txtFindText.Focus();
			}
		}

		private void SetReturnDataAndClose()
		{
			var rowHandle = gridList.MainView.FocusedRowHandle;
			DataMap returnMap = new DataMap();
			gridList.MainView.Columns.ToList().ForEach(x =>
			{
				returnMap.SetValue(x.FieldName, gridList.MainView.GetRowCellValue(rowHandle, x.FieldName));
			});
			ReturnData = returnMap;
			SetModifiedCount();
			Close();
		}

		private void SetColumnWidth()
		{
			try
			{
				int colWidth = 0;
				List<string> list = new List<string>();
				if (this.DisplayFields != null)
				{
					list = this.DisplayFields.ToList();
				}
				else
				{
					foreach (GridColumn col in gridList.MainView.Columns)
					{
						list.Add(col.FieldName);
					}
				}

				int column_count = 0;
				foreach (string colName in list)
				{
					if (gridList.MainView.Columns.Where(x => x.FieldName == colName).Any() && gridList.MainView.Columns[colName].Visible)
					{
						if (column_count < (list.Count - 1))
							gridList.MainView.Columns[colName].BestFit();
						colWidth += gridList.MainView.Columns[colName].Width;
					}
					column_count++;
				}

				if (colWidth < gridList.Width && gridList.MainView.Columns.Count > 0)
				{
					string colName = gridList.MainView.Columns.Where(x => x.FieldName.EndsWith("NAME")).LastOrDefault().FieldName;
					if (colName.IsNullOrEmpty() == false && list.Contains(colName))
					{
						gridList.MainView.Columns[colName].Width =
							gridList.MainView.Columns[colName].Width + (gridList.Width - colWidth - 40);
					}
					else
					{
						gridList.MainView.Columns[list[list.Count - 1]].Width =
							gridList.MainView.Columns[list[list.Count - 1]].Width + (gridList.Width - colWidth - 40);
					}
				}
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void SetGridColumnName(DataTable dt)
		{
			try
			{
				if (dt != null)
				{
					List<string> mergeFields = new List<string>();

					foreach (DataColumn col in dt.Columns)
					{
						if (gridList.MainView.Columns.Where(x => x.FieldName == col.ColumnName).Any())
						{
							if (col.ColumnName.EndsWith("_ID") ||
								col.ColumnName.EndsWith("_CODE") ||
								col.ColumnName.EndsWith("_TYPE") ||
								col.ColumnName.EndsWith("_NO") ||
								col.ColumnName.EndsWith("_YN"))
							{
								gridList.SetHorzAlign(col.ColumnName, DevExpress.Utils.HorzAlignment.Center);
							}
							else if (col.ColumnName.EndsWith("_QTY") ||
								col.ColumnName.EndsWith("_AMT") ||
								col.ColumnName.EndsWith("_PRICE"))
							{
								gridList.SetFormat(col.ColumnName, DevExpress.Utils.FormatType.Numeric, "N0");
								gridList.SetHorzAlign(col.ColumnName, DevExpress.Utils.HorzAlignment.Far);
							}

							if (col.ColumnName.EndsWith("_YN"))
							{
								gridList.SetRepositoryItemCheckEdit(col.ColumnName);
							}

							if (col.ColumnName.EndsWith("_YN") == false)
							{
								mergeFields.Add(col.ColumnName);
							}
						}
						else
						{
							gridList.AddGridColumn(new XGridColumn() { FieldName = col.ColumnName, Visible = false });
						}
					}

					if (mergeFields.Count > 0)
					{
						gridList.SetMerge(mergeFields.ToArray());
					}

					gridList.SetColumnBackColor(SkinUtils.ForeColor, this.CodeField);
					gridList.SetColumnForeColor(SkinUtils.BackColor, this.CodeField);
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
