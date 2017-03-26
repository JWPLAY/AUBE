using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;
using JW.AUBE.Base.DBTran.Controller;

namespace JW.AUBE.Core.Forms.Auth
{
	public partial class CalendarForm : EditForm
	{
		public CalendarForm()
		{
			InitializeComponent();

			datCalYear.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
					DataLoad(null);
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datCalYear.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons()
			{
				Refresh = true,
				Save = true
			});

			//btnCreate.Enabled = this.IsDataEdit;
			btnCreate.Click += delegate (object sender, EventArgs e)
			{
				doCreate();
			};
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemCalDate.Tag = true;

			SetFieldNames();

			datCalYear.Init(CalendarViewType.YearView);
			datCalDate.Init(CalendarViewType.DayView);
			chkHolidayYn.Init();

			datCalDate.SetEnable(false);
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
					FieldName = "DAY_OF_YEAR",
					Caption = "NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "CAL_DATE",
					Caption = "일자",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "WEEK_NAME",
					Caption = "요일",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "CAL_YEAR",
					Caption = "년",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "CAL_MONTH",
					Caption = "월",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "CAL_DAY",
					Caption = "일",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "QUARTER",
					Caption = "분기",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "DAY_OF_WEEK",
					Caption = "주일수",
					HorzAlignment = HorzAlignment.Center,
					Width = 60
				},
				new XGridColumn()
				{
					FieldName = "WEEK_OF_MONTH",
					Caption = "월주차",
					HorzAlignment = HorzAlignment.Center,
					Width = 60
				},
				new XGridColumn()
				{
					FieldName = "WEEK_OF_YEAR",
					Caption = "연주차",
					HorzAlignment = HorzAlignment.Center,
					Width = 60
				},
				new XGridColumn()
				{
					FieldName = "HOLIDAY_YN",
					Caption = "휴일여부",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "HOLIDAY_NAME",
					Caption = "휴일명",
					HorzAlignment = HorzAlignment.Near,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "REMARKS",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				}
			);

			gridList.SetRepositoryItemCheckEdit("HOLIDAY_YN");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "CAL_DATE"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridList.RowCellStyle += delegate (object sender, RowCellStyleEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					GridView view = sender as GridView;
					if (e.RowHandle != view.FocusedRowHandle)
					{
						if (view.GetRowCellValue(e.RowHandle, "HOLIDAY_YN").ToString() == "Y")
							e.Appearance.BackColor = System.Drawing.Color.LightPink;
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
			datCalDate.Clear();
			txtHolidayName.Clear();
			memRemarks.Clear();

			txtInsTime.Clear();
			txtInsUser.Clear();
			txtUpdTime.Clear();
			txtUpdUser.Clear();

			this.EditMode = EditModeEnum.New;
			txtHolidayName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "SelectCalendar", new DataMap() { { "CAL_YEAR", datCalYear.GetDateChar4() } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataTable dt = (DataTable)DBTranHelper.SingleRequest("Base", "GetData", "SelectCalendar", new DataMap() { { "CAL_DATE", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				datCalDate.EditValue = row["CAL_DATE"].ToDateTime();
				chkHolidayYn.EditValue = row["HOLIDAY_YN"];
				txtHolidayName.EditValue = row["HOLIDAY_NAME"];
				memRemarks.EditValue = row["REMARKS"];
				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUser.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUser.EditValue = row["UPD_USER_NAME"];

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
					{ "CAL_DATE", datCalDate.GetDateChar8() },
					{ "HOLIDAY_YN", chkHolidayYn.EditValue },
					{ "HOLIDAY_NAME", txtHolidayName.EditValue },
					{ "REMARKS", memRemarks.EditValue },
					{ "ROWSTATE", "UPDATE" }
				}).ToDataTable();
				
				var res = DBTranHelper.Request(new DBTranSet()
				{
					ServiceId = "Base",
					ProcessId = "Save",
					IsTransaction = true,
					TranList = new DBTranData[]
					{
						new DBTranData()
						{
							SqlId = "Calendar",
							KeyField = "CAL_DATE",
							Data = dt
						}
					}
				});

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

		void doCreate()
		{
			if (MsgBox.Show("선택한 연도의 캘린더를 생성하겠습니까?", "확인!!", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			try
			{
				var res = DBTranHelper.ProcedureCall("CreateCalendar", new DataMap() { { "CAL_YEAR", datCalYear.GetDateChar4().ToIntegerNullToZero() } });
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("생성하였습니다.");
				DataLoad(null);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}