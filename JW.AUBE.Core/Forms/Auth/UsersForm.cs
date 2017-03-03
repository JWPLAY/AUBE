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

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemId.SetFieldName("USER_ID");
			lcItemName.SetFieldName("USER_NAME");

			txtId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			InitGrid();
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
				},
				new XGridColumn()
				{
					FieldName="LOGIN_ID",
					Caption="로그인ID",
					HorzAlignment = HorzAlignment.Near
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
			gridList.SetWidth("NAME", 100);
			gridList.SetWidth("LOGIN_ID", 100);
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
			txtLoginId.Clear();
			txtLoginPw.Clear();
			chkUseYn.Checked = true;
			memeRemarks.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			this.EditMode = EditModeEnum.New;
			txtName.Focus();
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
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectUsers", new DataMap() { { "ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtId.EditValue = row["ID"];
				txtName.EditValue = row["NAME"];
				txtLoginId.EditValue = row["LOGIN_ID"];
				txtLoginPw.EditValue = row["LOGIN_PW"];
				chkUseYn.EditValue = row["USE_YN"];
				memeRemarks.EditValue = row["REMARKS"];
				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

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
				DataTable dt = (new DataMap()
				{
					{ "ID", txtId.EditValue },
					{ "NAME", txtName.EditValue },
					{ "LOGIN_ID", txtLoginId.EditValue },
					{ "LOGIN_PW", txtLoginPw.EditValue },
					{ "USE_YN", chkUseYn.EditValue },
					{ "REMARKS", memeRemarks.EditValue },
					{ "INS_USER", GlobalVar.Settings.GetValue("USER_ID") },
					{ "ROWSTATE", (this.EditMode== EditModeEnum.New)?"INSERT":"UPDATE" }
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
							SqlId = "Users",
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
							SqlId = "Users",
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