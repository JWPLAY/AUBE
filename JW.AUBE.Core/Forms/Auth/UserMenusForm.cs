using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class UserMenusForm : EditForm
	{
		public UserMenusForm()
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			InitGrid();
		}

		void InitGrid()
		{
			#region gridUsers
			gridUsers.Init();
			gridUsers.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "USER_ID", HorzAlignment = HorzAlignment.Center, Visible = false },
				new XGridColumn() { FieldName = "USER_NAME", HorzAlignment = HorzAlignment.Center, Width = 150 }
			);
			gridUsers.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridUsers.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
			gridUsers.ColumnFix("ROW_NO");

			gridUsers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailLoad(view.GetRowCellValue(e.RowHandle, "USER_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region gridMenus
			gridMenus.Init();
			gridMenus.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "HIER_ID", Visible = false },
				new XGridColumn() { FieldName = "HIER_NAME", Caption = "메뉴명", Width = 300 },
				new XGridColumn() { FieldName = "MENU_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "VIEW_YN", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridMenus.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "EDIT_YN", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridMenus.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
			);
			gridMenus.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridMenus.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
			gridMenus.ColumnFix("ROW_NO");

			gridMenus.SetEditable("VIEW_YN", "EDIT_YN");
			#endregion
		}
		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			gridUsers.BindData("Base", "GetList", "SelectUsers", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (gridMenus.RowCount > 0)
			{
				gridMenus.PostEditor();
				gridMenus.UpdateCurrentRow();
			}

			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("USER_ID", typeof(int)),
					new DataColumn("MENU_ID", typeof(int)),
					new DataColumn("VIEW_YN", typeof(string)),
					new DataColumn("EDIT_YN", typeof(string)),
					new DataColumn("INS_USER", typeof(int)),
					new DataColumn("ROWSTATE", typeof(string))
				});

				foreach (DataRow row in gridMenus.GetDataTable().Rows)
				{
					if (row.RowState == DataRowState.Modified &&
						(
							row["VIEW_YN"].ToString() != row["VIEW_YN", DataRowVersion.Original].ToString() ||
							row["EDIT_YN"].ToString() != row["EDIT_YN", DataRowVersion.Original].ToString()
						))
					{
						dt.Rows.Add(
							gridUsers.GetValue(gridUsers.MainView.FocusedRowHandle, "USER_ID"),
							row["MENU_ID"],
							row["VIEW_YN"],
							row["EDIT_YN"],
							GlobalVar.Settings.GetValue("USER_ID"),
							"UPSERT");
					}
				}

				if (dt == null || dt.Rows.Count == 0)
				{
					ShowMsgBox("저장할 내역이 없습니다.");
					return;
				}

				var res = DBTranHelper.Execute("Base", "Save", "UserMenus", dt, null);
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				int rowhandle = gridUsers.MainView.FocusedRowHandle;
				object userId = gridUsers.GetValue(rowhandle, "USER_ID");
				DataLoad();
				gridUsers.MainView.FocusedRowHandle = rowhandle;
				DetailLoad(userId);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DetailLoad(object userId)
		{
			gridMenus.BindData("Base", "GetList", "SelectUserMenus", new DataMap() { { "USER_ID", userId } });
		}
	}
}