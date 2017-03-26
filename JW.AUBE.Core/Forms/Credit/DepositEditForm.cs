using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Credit
{
	public partial class DepositEditForm : EditForm
	{
		public DepositEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datSchDepositDate.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemDepositDate.Tag = true;
			lcItemCustomer.Tag = true;

			SetFieldNames();

			lcItemSchDepositDate.SetFieldCaption("조회기간");
			lcItemSchCustomer.SetFieldCaption("검색거래처");
			
			txtDepositId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);
						
			datSchDepositDate.Init();
			datDepositDate.Init();
			spnDepositAmt.SetFormat("N0", false);
			txtCustomerId.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);
			txtSchCustomerId.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);

			InitGrid();
		}

		void InitGrid()
		{
			#region 조회리스트
			gridList.Init();
			gridList.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() { FieldName="ROW_NO" },
				new XGridColumn() { FieldName="DEPOSIT_ID", Visible = false },
				new XGridColumn() { FieldName="DEPOSIT_DATE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName="CUSTOMER_ID",   HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName="CUSTOMER_NAME", HorzAlignment = HorzAlignment.Near,   Width = 180 },
				new XGridColumn() { FieldName="DEPOSIT_AMT", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName="REMARKS", Width = 200 },
				new XGridColumn() { FieldName="INS_TIME" },
				new XGridColumn() { FieldName="INS_USER", Visible = false },
				new XGridColumn() { FieldName="INS_USER_NAME" },
				new XGridColumn() { FieldName="UPD_TIME" },
				new XGridColumn() { FieldName="UPD_USER", Visible = false },
				new XGridColumn() { FieldName="UPD_USER_NAME" }
			});
			gridList.SetColumnBackColor(Color.Black, "ROW_NO");
			gridList.SetColumnForeColor(Color.White, "ROW_NO");
			gridList.ColumnFix("ROW_NO");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "DEPOSIT_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion
		}
		
		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			try
			{
				txtDepositId.Clear();
				txtCustomerId.Clear();
				spnDepositAmt.Clear();
				memRemarks.Clear();
				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
				this.EditMode = EditModeEnum.New;
				datDepositDate.Focus();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				gridList.BindData("Base", "GetList", "GetDepositList", new DataMap()
				{
					{ "ST_DEPOSIT_DATE", datSchDepositDate.DateFrEdit.GetDateChar8() },
					{ "ED_DEPOSIT_DATE", datSchDepositDate.DateToEdit.GetDateChar8() },
					{ "CUSTOMER_ID", txtCustomerId.EditValue }					
				});

				if (param != null)
					DetailDataLoad(param);
				else
					DataInit();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = DBTranHelper.GetData<DataMap>("Base", "GetData", "GetDepositData", new DataMap() { { "DEPOSIT_ID", id } });

				txtDepositId.EditValue = data.GetValue("DEPOSIT_ID");
				datDepositDate.SetDateChar8(data.GetValue("DEPOSIT_DATE"));
				txtCustomerId.EditValue = data.GetValue("CUSTOMER_ID");
				txtCustomerId.EditText = data.GetValue("CUSTOMER_NAME");
				spnDepositAmt.EditValue = data.GetValue("DEPOSIT_AMT");
				memRemarks.EditValue = data.GetValue("REMARKS");

				txtInsTime.EditValue = data.GetValue("INS_TIME");
				txtInsUserName.EditValue = data.GetValue("INS_USER_NAME");
				txtUpdTime.EditValue = data.GetValue("UPD_TIME");
				txtUpdUserName.EditValue = data.GetValue("UPD_USER_NAME");

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCustomerId.Focus();

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
				DataMap map = lcGroupEdit.ItemToDataMap();
				map.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				var res = DBTranHelper.Execute("Base", "Save", "Deposit", map, "DEPOSIT_ID");
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
				DataMap map = new DataMap()
				{
					{ "DEPOSIT_ID", txtDepositId.EditValue },
					{ "ROWSTATE", "DELETE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Deposit", map, null);
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