using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class MenusForm : EditForm
	{
		public MenusForm()
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
				New = true,
				Refresh = true,
				Save = true,
				SaveAndNew = true,
				Delete = true
			});
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemMenuName.Tag = true;

			SetFieldNames();

			txtMenuId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);

			numSortSeq.SetFormat("D", false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupFormType.BindData("FORM_TYPE", null, null, true);
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "HIER_ID",
					HorzAlignment = HorzAlignment.Near,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "HIER_NAME",
					CaptionCode = "MENU_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 300
				},
				new XGridColumn()
				{
					FieldName = "MENU_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "SORT_SEQ",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "USE_YN",
					HorzAlignment = HorzAlignment.Near,
					Width = 80,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit()
				}
			);

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "MENU_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			txtMenuId.Clear();
			txtMenuName.Clear();
			txtParentId.Clear();
			numSortSeq.Clear();
			txtAssembly.Clear();
			txtNamespace.Clear();
			txtInstance.Clear();
			chkUseYn.Checked = true;
			memRemarks.Clear();

			txtInsTime.Clear();
			txtInsUserName.Clear();
			txtUpdTime.Clear();
			txtUpdUserName.Clear();

			this.EditMode = EditModeEnum.New;
			txtMenuName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectMenus", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectMenu", new DataMap() { { "MENU_ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtMenuId.EditValue = row["MENU_ID"];
				txtMenuName.EditValue = row["MENU_NAME"];
				txtParentId.EditValue = row["PARENT_ID"];
				numSortSeq.EditValue = row["SORT_SEQ"];
				txtAssembly.EditValue = row["ASSEMBLY"];
				txtNamespace.EditValue = row["NAMESPACE"];
				txtInstance.EditValue = row["INSTANCE"];
				lupFormType.EditValue = row["FORM_TYPE"];
				chkUseYn.EditValue = row["USE_YN"];
				memRemarks.EditValue = row["REMARKS"];

				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUserName.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUserName.EditValue = row["UPD_USER_NAME"];

				this.EditMode = EditModeEnum.Modify;
				txtMenuName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				DataMap map = lc.ItemToDataMap();
				map.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				var res = ServerRequest.SingleRequest("Base", "Save", "Menu", map.ToDataTable(), "MENU_ID");
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				callback(arg, res.DataList[0].ReturnValue);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				DataTable dt = (new DataMap()
				{
					{ "MENU_ID", txtMenuId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Base", "Save", "Menu", dt, "MENU_ID");
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("삭제하였습니다.");
				callback(arg, null);

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}