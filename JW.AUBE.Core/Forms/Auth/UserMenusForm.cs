using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Variables;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Base.Forms;
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
			SetToolbarButtons(new ToolbarButtons()
			{
				Refresh = true,
				Save = true,
				SaveAndNew = true
			});
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
			gridUsers.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn()
				{
					FieldName="ROW_NO",
					Caption = "NO",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="ID",
					Caption = "사용자ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="NAME",
					Caption="사용자명",
					HorzAlignment = HorzAlignment.Near
				}
			});
			gridUsers.SetWidth("ROW_NO", 40);
			gridUsers.SetWidth("NAME", 150);

			gridUsers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailLoad(view.GetRowCellValue(e.RowHandle, "ID"));
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
			gridMenus.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn()
				{
					FieldName="ROW_NO",
					Caption = "NO",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="HIER_ID",
					Caption="메뉴계층ID",
					HorzAlignment = HorzAlignment.Near,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="HIER_NAME",
					Caption="메뉴명",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="ID",
					Caption = "메뉴ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="VIEW_YN",
					Caption = "조회권한",
					HorzAlignment = HorzAlignment.Center,
					RepositoryItem = gridMenus.GetRepositoryItemCheckEdit()
				},
				new XGridColumn()
				{
					FieldName="EDIT_YN",
					Caption = "편집권한",
					HorzAlignment = HorzAlignment.Center,
					RepositoryItem = gridMenus.GetRepositoryItemCheckEdit()
				},
				new XGridColumn()
				{
					FieldName="INS_TIME",
					Caption = "최초등록일시",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="INS_USER_NAME",
					Caption = "최초등록자명",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="UPD_TIME",
					Caption = "최종수정일시",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="UPD_USER_NAME",
					Caption = "최종수정자명",
					HorzAlignment = HorzAlignment.Center
				}
			});
			gridMenus.SetWidth("ROW_NO", 40);
			gridMenus.SetWidth("HIER_NAME", 300);
			gridMenus.SetWidth("ID", 80);
			gridMenus.SetWidth("VIEW_YN", 80);
			gridMenus.SetWidth("EDIT_YN", 80);
			gridMenus.SetWidth("INS_TIME", 180);
			gridMenus.SetWidth("INS_USER_NAME", 100);
			gridMenus.SetWidth("UPD_TIME", 180);
			gridMenus.SetWidth("UPD_USER_NAME", 100);

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
							gridUsers.GetValue(gridUsers.MainView.FocusedRowHandle, "ID"),
							row["ID"],
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
				
				var res = ServerRequest.Request(new WasRequest()
				{
					ServiceId = "Base",
					ProcessId = "Save",
					IsTransaction = true,
					DataList = new List<WasRequestData>()
					{
						new WasRequestData()
						{
							SqlId = "UserMenus",
							Data = dt
						}
					}
				});

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				int rowhandle = gridUsers.MainView.FocusedRowHandle;
				object userId = gridUsers.GetValue(rowhandle, "ID");
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