using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class UsersForm : EditForm
	{
		public UsersForm()
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
			SetToolbarButtons(new Core.Models.ToolbarButtons()
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

			lcItemUserName.Tag = true;

			SetFieldNames();

			txtUserId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupUserType.BindData("USER_TYPE", null, null, true);
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
					FieldName = "USER_ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "USER_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "LOGIN_ID",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "USER_ID"));
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
			txtUserId.Clear();
			txtUserName.Clear();
			txtLoginId.Clear();
			txtLoginPw.Clear();
			chkUseYn.Checked = true;
			memeRemarks.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			this.EditMode = EditModeEnum.New;
			txtUserName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectUsers", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = (DataTable)ServerRequest.SingleRequest("Base", "GetData", "SelectUsers", new DataMap() { { "USER_ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtUserId.EditValue = row["USER_ID"];
				txtUserName.EditValue = row["USER_NAME"];
				lupUserType.EditValue = row["USER_TYPE"];
				txtLoginId.EditValue = row["LOGIN_ID"];
				txtLoginPw.EditValue = row["LOGIN_PW"];
				chkUseYn.EditValue = row["USE_YN"];
				memeRemarks.EditValue = row["REMARKS"];

				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

				this.EditMode = EditModeEnum.Modify;
				txtUserName.Focus();

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
					{ "USER_ID", txtUserId.EditValue },
					{ "USER_NAME", txtUserName.EditValue },
					{ "USER_TYPE", lupUserType.EditValue },
					{ "LOGIN_ID", txtLoginId.EditValue },
					{ "LOGIN_PW", txtLoginPw.EditValue },
					{ "USE_YN", chkUseYn.EditValue },
					{ "REMARKS", memeRemarks.EditValue },
					{ "ROWSTATE", (this.EditMode== EditModeEnum.New)?"INSERT":"UPDATE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Base", "Save", "User", dt, "USER_ID");
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
					{ "USER_ID", txtUserId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Base", "Save", "User", dt, "USER_ID");
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