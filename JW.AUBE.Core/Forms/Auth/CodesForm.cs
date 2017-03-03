using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class CodesForm : EditForm
	{
		public CodesForm()
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
			lcItemCode.Tag = true;

			SetFieldNames();

			lcItemId.SetFieldName("CODE_ID");
			lcItemName.SetFieldName("CODE_NAME");
			lcItemValue.SetFieldName("CODE_VALUE");
		
			txtId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			spnSortSeq.SetFormat("D", false, HorzAlignment.Near);
			chkUseYn.Init();

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupParentCode.BindData("CodeGroup", null, "ROOT", true);
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
					Caption="계층ID",
					HorzAlignment = HorzAlignment.Near,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="HIER_NAME",
					Caption="코드계층명",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="ID",
					Caption = "ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="CODE",
					Caption="코드",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="NAME",
					Caption="코드명",
					HorzAlignment = HorzAlignment.Near,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="VALUE",
					Caption="값",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="USE_YN",
					Caption="사용여부",
					HorzAlignment = HorzAlignment.Center,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit()
				},
				new XGridColumn()
				{
					FieldName="OPTION_VALUE1",
					Caption="옵션값1",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="OPTION_VALUE2",
					Caption="옵션값2",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="OPTION_VALUE3",
					Caption="옵션값3",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="OPTION_VALUE4",
					Caption="옵션값4",
					HorzAlignment = HorzAlignment.Near
				},
				new XGridColumn()
				{
					FieldName="OPTION_VALUE5",
					Caption="옵션값5",
					HorzAlignment = HorzAlignment.Near
				}
			});
			gridList.SetWidth("ROW_NO", 40);
			gridList.SetWidth("HIER_NAME", 250);
			gridList.SetWidth("ID", 80);
			gridList.SetWidth("CODE", 120);
			gridList.SetWidth("NAME", 200);
			gridList.SetWidth("VALUE", 120);
			gridList.SetWidth("USE_YN", 80);
			gridList.SetWidth("OPTION_VALUE1", 100);
			gridList.SetWidth("OPTION_VALUE2", 100);
			gridList.SetWidth("OPTION_VALUE3", 100);
			gridList.SetWidth("OPTION_VALUE4", 100);
			gridList.SetWidth("OPTION_VALUE5", 100);

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

			object group_code = lupParentCode.EditValue;
			lupParentCode.BindData("CodeGroup", null, "ROOT", true);
			lupParentCode.EditValue = group_code;

			txtName.Clear();
			txtCode.Clear();
			txtValue.Clear();
			spnSortSeq.Clear();
			memDescription.Clear();

			txtOptionValue1.Clear();
			txtOptionValue2.Clear();
			txtOptionValue3.Clear();
			txtOptionValue4.Clear();
			txtOptionValue5.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			this.EditMode = EditModeEnum.New;
			txtCode.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectCodes", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });
			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectCode", new DataMap() { { "ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtId.EditValue = row["ID"];
				lupParentCode.BindData("CodeGroup", null, "ROOT", true);
				lupParentCode.EditValue = row["PARENT_CODE"];
				txtCode.EditValue = row["CODE"];
				txtName.EditValue = row["NAME"];
				txtValue.EditValue = row["VALUE"];
				spnSortSeq.EditValue = row["SORT_SEQ"];
				chkUseYn.EditValue = row["USE_YN"];
				memDescription.EditValue = row["DESCRIPTION"];
				txtOptionValue1.EditValue = row["OPTION_VALUE1"];
				txtOptionValue2.EditValue = row["OPTION_VALUE2"];
				txtOptionValue3.EditValue = row["OPTION_VALUE3"];
				txtOptionValue4.EditValue = row["OPTION_VALUE4"];
				txtOptionValue5.EditValue = row["OPTION_VALUE5"];
				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

				this.EditMode = EditModeEnum.Modify;
				txtCode.Focus();
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
				if (DataValidate() == false) return;

				DataTable dt = (new DataMap()
				{
					{ "ID", txtId.EditValue },
					{ "PARENT_CODE", lupParentCode.EditValue },
					{ "CODE", txtCode.EditValue },
					{ "NAME", txtName.EditValue },
					{ "VALUE", txtValue.EditValue },
					{ "SORT_SEQ", spnSortSeq.EditValue },
					{ "USE_YN", chkUseYn.EditValue },
					{ "DESCRIPTION", memDescription.EditValue },
					{ "OPTION_VALUE1", txtOptionValue1.EditValue },
					{ "OPTION_VALUE2", txtOptionValue2.EditValue },
					{ "OPTION_VALUE3", txtOptionValue3.EditValue },
					{ "OPTION_VALUE4", txtOptionValue4.EditValue },
					{ "OPTION_VALUE5", txtOptionValue5.EditValue },
					{ "INS_USER", GlobalVar.Settings.GetValue("USER_ID") },
					{ "ROWSTATE", ( this.EditMode == EditModeEnum.New ) ? "INSERT" : "UPDATE" }
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
							SqlId = "Codes",
							KeyField = "ID",
							Data = dt
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
							SqlId = "Codes",
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