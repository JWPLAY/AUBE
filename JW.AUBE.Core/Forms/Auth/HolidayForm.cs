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
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class HolidayForm : EditForm
	{
		public HolidayForm()
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

			lcItemHolidayDate.Tag = true;
			lcItemHolidayName.Tag = true;

			SetFieldNames();

			txtInsTime.SetEnable(false);
			txtInsUser.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUser.SetEnable(false);

			datHolidayDate.Init();

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
					FieldName="HOLIDAY_DATE",
					Caption = "휴일일자",
					HorzAlignment = HorzAlignment.Center,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="HOLIDAY_NAME",
					Caption="휴일명",
					HorzAlignment = HorzAlignment.Near
				}
			});
			gridList.SetWidth("ROW_NO", 40);
			gridList.SetWidth("HOLIDAY_DATE", 100);
			gridList.SetWidth("HOLIDAY_NAME", 200);

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
			txtHolidayName.Clear();
			memDescription.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			datHolidayDate.SetEnable(true);
			this.EditMode = EditModeEnum.New;
			datHolidayDate.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectHoliday", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectHoliday", new DataMap() { { "ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				datHolidayDate.SetDateChar8(row["HOLIDAY_DATE"].ToString());
				txtHolidayName.EditValue = row["HOLIDAY_NAME"];
				memDescription.EditValue = row["DESCRIPTION"];
				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

				datHolidayDate.SetEnable(false);
				this.EditMode = EditModeEnum.Modify;
				txtHolidayName.Focus();

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
					{ "HOLIDAY_DATE", datHolidayDate.GetDateChar8() },
					{ "HOLIDAY_NAME", txtHolidayName.EditValue },
					{ "DESCRIPTION", memDescription.EditValue },
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
							SqlId = "Holiday",
							KeyField = "HOLIDAY_DATE",
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
					{ "HOLIDAY_DATE", datHolidayDate.GetDateChar8() },
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
							SqlId = "Holiday",
							KeyField = "HOLIDAY_DATE",
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