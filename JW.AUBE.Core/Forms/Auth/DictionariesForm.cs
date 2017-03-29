using System;
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
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
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "DICTIONARY_ID", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "LOGICAL_NAME", Width = 200 },
				new XGridColumn() { FieldName = "PHYSICAL_NAME", Width = 200 }
			);
			gridList.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
			gridList.ColumnFix("ROW_NO");

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

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
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
				DataMap data = (DataMap)DBTranHelper.GetData("Base", "GetData", "SelectDictionaries", new DataMap() { { "DICTIONARY_ID", id } }).TranList[0].Data;
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				txtDictionaryId.EditValue = data.GetValue("DICTIONARY_ID");
				txtLogicalName.EditValue = data.GetValue("LOGICAL_NAME");
				txtPhysicalName.EditValue = data.GetValue("PHYSICAL_NAME");
				memDescription.EditValue = data.GetValue("DESCRIPTION");
				txtInsTime.EditValue = data.GetValue("INS_TIME");
				txtInsUser.EditValue = data.GetValue("INS_USER_NAME");
				txtUpdTime.EditValue = data.GetValue("UPD_TIME");
				txtUpdUser.EditValue = data.GetValue("UPD_USER_NAME");

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
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
				DataMap data = new DataMap()
				{
					{ "DICTIONARY_ID", txtDictionaryId.EditValue },
					{ "LOGICAL_NAME", txtLogicalName.EditValue },
					{ "PHYSICAL_NAME", txtPhysicalName.EditValue },
					{ "DESCRIPTION", memDescription.EditValue },
					{ "ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Dictionary", data, "DICTIONARY_ID");
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
					{ "DICTIONARY_ID", txtDictionaryId.EditValue },
					{ "ROWSTATE", "DELETE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Dictionary", data, null);
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