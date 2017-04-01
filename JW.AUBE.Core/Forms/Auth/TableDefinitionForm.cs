using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;
using JW.AUBE.Model.System;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class TableDefinitionForm : EditForm
	{
		public TableDefinitionForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Save = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtTableId.SetEnable(false);
			txtSchemaName.SetEnable(false);
			txtTableName.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupDbName.BindData("DATABASE", null, null, true);
		}

		void InitGrid()
		{
			#region 그리드정의 - 테이블
			gridTables.Init();
			gridTables.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "TABLE_ID", HorzAlignment = HorzAlignment.Center, Visible = false },
				new XGridColumn() { FieldName = "SCHEMA_NAME", Width = 80 },
				new XGridColumn() { FieldName = "TABLE_NAME", Width = 150 },
				new XGridColumn() { FieldName = "ID", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "DESCRIPTION", Width = 200 },
				new XGridColumn() { FieldName = "REMARKS", Width = 200, Visible = false },
				new XGridColumn() { FieldName = "ROW_COUNT", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TABLE_SIZE", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N3" },
				new XGridColumn() { FieldName = "DATA_SIZE", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N3" },
				new XGridColumn() { FieldName = "INDEX_SIZE", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N3" },
				new XGridColumn() { FieldName = "LAST_USER_SEEK", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LAST_USER_SCAN", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LAST_USER_LOOKUP", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LAST_USER_UPDATE", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LAST_SYSTEM_UPDATE", Width = 150, HorzAlignment = HorzAlignment.Center }
			);
			gridTables.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridTables.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
			gridTables.ColumnFix("ROW_NO");

			gridTables.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						txtTableId.EditValue = view.GetRowCellValue(e.RowHandle, "ID");
						txtSchemaName.EditValue = view.GetRowCellValue(e.RowHandle, "SCHEMA_NAME");
						txtTableName.EditValue = view.GetRowCellValue(e.RowHandle, "TABLE_NAME");
						txtDescription.EditValue = view.GetRowCellValue(e.RowHandle, "DESCRIPTION");
						memRemarks.EditValue = view.GetRowCellValue(e.RowHandle, "REMARKS");

						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "TABLE_NAME"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region 그리드정의 - 컬럼
			gridColumns.Init();
			gridColumns.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "TABLE_ID", HorzAlignment = HorzAlignment.Center, Visible = false },
				new XGridColumn() { FieldName = "TABLE_NAME", HorzAlignment = HorzAlignment.Center, Visible = false },
				new XGridColumn() { FieldName = "COLUMN_ID", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "COLUMN_NAME", Width = 150 },
				new XGridColumn() { FieldName = "DESCRIPTION", Width = 200 },
				new XGridColumn() { FieldName = "COLUMN_TYPE_LEN", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "COLUMN_TYPE", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "DATA_LEN", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "PKEY", Caption = "KEY", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "NULLALBE", Caption = "Nullable", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "COLUMN_IDENTITY", Caption = "Identity", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "COLUMN_DEFAULT", Caption = "Default", Width = 150 },
				new XGridColumn() { FieldName = "REMARKS", Width = 200 },
				new XGridColumn() { FieldName = "ID", Visible = false }
			);
			gridColumns.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridColumns.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
			gridColumns.ColumnFix("ROW_NO");

			gridColumns.SetEditable("DESCRIPTION", "REMARKS");
			#endregion
		}
		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		protected override void DataInit()
		{
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
		}

		protected override void DataLoad(object param = null)
		{
			gridTables.BindData("Database", "GetTableList", "GetTables", new DataMap() { { "DB_NAME", lupDbName.EditValue }, { "FIND_TEXT", txtFindText.EditValue } });
		}

		void DetailDataLoad(object id)
		{
			gridColumns.BindData("Database", "GetColumnList", "GetColumns", new DataMap() { { "DB_NAME", lupDbName.EditValue }, { "TABLE_NAME", id } });
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				DataMap data = new DataMap()
				{
					{ "ID", txtTableId.EditValue },
					{ "DB_NAME", lupDbName.EditValue },
					{ "SCHEMA_NAME", txtSchemaName.EditValue },
					{ "TABLE_NAME", txtTableName.EditValue },
					{ "DESCRIPTION", txtDescription.EditValue },
					{ "REMARKS", memRemarks.EditValue },
					{ "ROWSTATE", (txtTableId.EditValue.IsNullOrEmpty()) ? "INSERT" : "UPDATE" }
				};

				DataTable dtColumns = GetColumnData();

				var res = DBTranHelper.Execute(new DBTranSet()
				{
					ServiceId = "Database",
					ProcessId = "Save",
					IsTransaction = true,
					TranList = new DBTranData[]
					{
						new DBTranData() { SqlId = "Tables", Data = data, IsMaster = true, KeyField = "ID" },
						new DBTranData() { SqlId = "Columns", Data = dtColumns }
					}
				});
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				DataLoad();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		public DataTable GetColumnData()
		{
			DataTable dt = new DataTable();
			dt.Columns.AddRange(new DataColumn[]
			{
				new DataColumn("ID", typeof(int)),
				new DataColumn("DB_NAME", typeof(string)),
				new DataColumn("TABLE_NAME", typeof(string)),
				new DataColumn("COLUMN_NAME", typeof(string)),
				new DataColumn("DESCRIPTION", typeof(string)),
				new DataColumn("REMARKS", typeof(string)),
				new DataColumn("ROWSTATE", typeof(string))
			});

			if (gridColumns.RowCount > 0)
			{
				gridColumns.PostEditor();
				gridColumns.UpdateCurrentRow();

				List<ColumnListModel> list = gridColumns.DataSource as List<ColumnListModel>;
				foreach (ColumnListModel model in list)
				{
					dt.Rows.Add(
						model.ID,
						lupDbName.EditValue,
						model.TABLE_NAME,
						model.COLUMN_NAME,
						model.DESCRIPTION,
						model.REMARKS,
						(model.ID.ToStringNullToEmpty() == "" || model.ID.ToStringNullToEmpty() == "0") ? "INSERT" : "UPDATE");
				}
			}

			return dt;
		}
	}
}