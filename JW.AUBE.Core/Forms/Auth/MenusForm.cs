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

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemId.SetFieldName("MENU_ID");
			lcItemName.SetFieldName("MENU_NAME");

			txtId.SetEnable(false);
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
			gridList.AddGridColumns(new XGridColumn[]
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
					Caption="메뉴계층명",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="ID",
					Caption = "메뉴ID",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="NAME",
					Caption="메뉴명",
					HorzAlignment = HorzAlignment.Near,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="SORT_SEQ",
					Caption="정렬순서",
					HorzAlignment = HorzAlignment.Center
				},
				new XGridColumn()
				{
					FieldName="USE_YN",
					Caption="사용여부",
					HorzAlignment = HorzAlignment.Near,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit()
				}
			});
			gridList.SetWidth("ROW_NO", 40);
			gridList.SetWidth("HIER_NAME", 300);
			gridList.SetWidth("ID", 80);
			gridList.SetWidth("USE_YN", 80);

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
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
			txtId.Clear();
			txtName.Clear();
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
			txtName.Focus();
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
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectMenus", new DataMap() { { "ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtId.EditValue = row["ID"];
				txtName.EditValue = row["NAME"];
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
				txtName.Focus();

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
				map.SetValue("INS_USER", GlobalVar.Settings.GetValue("USER_ID"));
				map.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");
				
				var res = ServerRequest.Request(new WasRequest()
				{
					ServiceId = "Base",
					ProcessId = "Save",
					IsTransaction = true,
					DataList = new List<WasRequestData>()
					{
						new WasRequestData()
						{
							SqlId = "Menus",
							KeyField = "ID",
							Data = map.ToDataTable()
						}
					}
				});

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
					{ "ID", txtId.EditValue },
					{ "INS_USER", GlobalVar.Settings.GetValue("USER_ID") },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.Request(new WasRequest()
				{
					ServiceId = "Base",
					ProcessId = "Save",
					IsTransaction = true,
					DataList = new List<WasRequestData>()
					{
						new WasRequestData()
						{
							SqlId = "Menus",
							KeyField = "ID",
							Data = dt
						}
					}
				});

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