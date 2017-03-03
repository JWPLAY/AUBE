using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Base.Forms
{
	public partial class CodeHelpForm : BaseForm
	{
		public CodeHelpForm()
		{
			InitializeComponent();
			Initialize();

			txtFindText.KeyDown += delegate (object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (e.KeyCode == System.Windows.Forms.Keys.Enter)
				{
					if (txtFindText.EditValue == null)
					{
						MsgBox.Show("검색어를 입력하세요!!!");
						txtFindText.Focus();
						return;
					}
					BindData();
				}
				else
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Escape)
					{
						ReturnData = null;
						Close();
					}
				}
			};
			xGrid.RowCellClick += delegate (object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
				{
					return;
				}
				if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
				{
					if (e.RowHandle < 0)
					{
						return;
					}
					SetReturnDataAndClose();
				}
			};
			xGrid.MainView.KeyDown += delegate (object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (e.KeyCode == System.Windows.Forms.Keys.Enter)
				{
					if (xGrid.MainView.FocusedRowHandle < 0)
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
			xGrid.Init();
			if (DisplayFields != null)
			{
				var columns = new List<XGridColumn>();
				foreach (string field in DisplayFields)
				{
					columns.Add(new XGridColumn() { FieldName = field });
				}
				xGrid.AddGridColumns(columns.ToArray());
			}
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
				Parameters.SetValue("USE_YN", (chkUseYn.Checked) ? "Y" : "N");

				data = CodeHelpUtils.GetCodeHelpSearch(CodeGroup, Parameters);
				if (data == null)
				{
					MsgBox.Show("검색된 데이터가 없습니다.");
					txtFindText.Focus();
					return;
				}
			}

			if (data != null)
			{
				xGrid.DataSource = data;
				xGrid.BestFitColumns();
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if (xGrid.MainView.RowCount > 0)
			{
				xGrid.MainView.Focus();
			}
			else
			{
				txtFindText.Focus();
			}
		}

		private void SetReturnDataAndClose()
		{
			var rowHandle = xGrid.MainView.FocusedRowHandle;
			ReturnData = new DataMap()
			{
				{ CodeField, xGrid.MainView.GetRowCellValue(rowHandle, CodeField) },
				{ NameField, xGrid.MainView.GetRowCellValue(rowHandle, NameField) }
			};
			SetModifiedCount();
			Close();
		}
	}
}
