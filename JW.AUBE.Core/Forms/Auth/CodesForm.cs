using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
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
			
			lcItemName.SetFieldName("CODE_NAME");
			lcItemValue.SetFieldName("CODE_VALUE");
		
			txtCodeId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			spnSortSeq.SetFormat("D", false, HorzAlignment.Near);
			spnMaxLength.SetFormat("D", false, HorzAlignment.Near);
			chkUseYn.Init();

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupParentCode.BindData("CODE_GROUP", null, "ROOT", true);
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
					CaptionCode = "CODE_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 250
				},
				new XGridColumn()
				{
					FieldName = "CODE_ID",
					Caption = "ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "CODE",
					HorzAlignment = HorzAlignment.Near,
					Width = 120
				},
				new XGridColumn()
				{
					FieldName = "VALUE",
					CaptionCode = "CODE_VALUE",
					HorzAlignment = HorzAlignment.Near,
					Width = 120
				},
				new XGridColumn()
				{
					FieldName = "USE_YN",
					HorzAlignment = HorzAlignment.Center,
					Width = 80,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit()
				},
				new XGridColumn()
				{
					FieldName = "OPTION_VALUE1",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "OPTION_VALUE2",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "OPTION_VALUE3",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "OPTION_VALUE4",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "OPTION_VALUE5",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "CODE_ID"));
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
			txtCodeId.Clear();

			object group_code = lupParentCode.EditValue;
			lupParentCode.BindData("CODE_GROUP", null, "ROOT", true);
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
				DataTable dt = (DataTable)DBTranHelper.GetData("Base", "GetData", "SelectCode", new DataMap() { { "CODE_ID", id } }).TranList[0].Data;
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtCodeId.EditValue = row["CODE_ID"];
				lupParentCode.BindData("CODE_GROUP", null, "ROOT", true);
				lupParentCode.EditValue = row["PARENT_CODE"];
				txtCode.EditValue = row["CODE"];
				txtName.EditValue = row["NAME"];
				txtValue.EditValue = row["VALUE"];
				spnSortSeq.EditValue = row["SORT_SEQ"];
				spnMaxLength.EditValue = row["MAX_LENGTH"];
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

				DataMap data = new DataMap()
				{
					{ "CODE_ID", txtCodeId.EditValue },
					{ "PARENT_CODE", lupParentCode.EditValue },
					{ "CODE", txtCode.EditValue },
					{ "NAME", txtName.EditValue },
					{ "VALUE", txtValue.EditValue },
					{ "SORT_SEQ", spnSortSeq.EditValue },
					{ "MAX_LENGTH", spnMaxLength.EditValue },
					{ "USE_YN", chkUseYn.EditValue },
					{ "DESCRIPTION", memDescription.EditValue },
					{ "OPTION_VALUE1", txtOptionValue1.EditValue },
					{ "OPTION_VALUE2", txtOptionValue2.EditValue },
					{ "OPTION_VALUE3", txtOptionValue3.EditValue },
					{ "OPTION_VALUE4", txtOptionValue4.EditValue },
					{ "OPTION_VALUE5", txtOptionValue5.EditValue },
					{ "ROWSTATE", ( this.EditMode == EditModeEnum.New ) ? "INSERT" : "UPDATE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Code", data, "CODE_ID");
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				callback(arg, res.TranList[0].ReturnValue);
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
				DataMap data = new DataMap()
				{
					{ "CODE_ID", txtCodeId.EditValue },
					{ "ROWSTATE", "DELETE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Code", data, null);
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