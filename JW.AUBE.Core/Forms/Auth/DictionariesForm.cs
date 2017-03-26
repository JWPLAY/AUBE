using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class DictionariesForm : EditForm
	{
		public DictionariesForm()
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

			lcItemLogicalName.Tag = true;
			lcItemPhysicalName.Tag = true;

			SetFieldNames();

			txtDictionaryId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns
			(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "DICTIONARY_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "LOGICAL_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName = "PHYSICAL_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "DICTIONARY_ID"));
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
			txtDictionaryId.Clear();
			txtLogicalName.Clear();
			txtPhysicalName.Clear();
			memDescription.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			this.EditMode = EditModeEnum.New;
			txtLogicalName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectDictionaries", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = (DataTable)DBTranHelper.SingleRequest("Base", "GetData", "SelectDictionaries", new DataMap() { { "DICTIONARY_ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtDictionaryId.EditValue = row["DICTIONARY_ID"];
				txtLogicalName.EditValue = row["LOGICAL_NAME"];
				txtPhysicalName.EditValue = row["PHYSICAL_NAME"];
				memDescription.EditValue = row["DESCRIPTION"];
				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

				this.EditMode = EditModeEnum.Modify;
				txtLogicalName.Focus();

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
				DataTable dt = (new DataMap()
				{
					{ "DICTIONARY_ID", txtDictionaryId.EditValue },
					{ "LOGICAL_NAME", txtLogicalName.EditValue },
					{ "PHYSICAL_NAME", txtPhysicalName.EditValue },
					{ "DESCRIPTION", memDescription.EditValue },
					{ "ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE" }
				}).ToDataTable();

				var res = DBTranHelper.SingleRequest("Base", "Save", "Dictionary", dt, "DICTIONARY_ID");
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
				DataTable dt = (new DataMap()
				{
					{ "DICTIONARY_ID", txtDictionaryId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = DBTranHelper.SingleRequest("Base", "Save", "Dictionary", dt, "DICTIONARY_ID");
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