using System;
using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Credit
{
	public partial class SalesLedgerForm : EditForm
	{
		public SalesLedgerForm()
		{
			InitializeComponent();

			gridList.RowCellStyle += delegate (object sender, RowCellStyleEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Column.FieldName.EndsWith("_AMT"))
					{
						if (e.CellValue.ToDecimalNullToZero() < 0)
							e.Appearance.ForeColor = Color.Red;
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void InitButtons()

		{
			SetToolbarButtons(new Models.ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemCustomer.Tag = true;
			lcItemSaleDate.Tag = true;

			SetFieldNames();

			txtCustomer.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);
			datSaleDate.Init();

			InitGrid();
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.ShowFooter = true;
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "TRAN_ID", Caption = "거래ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "TRAN_DATE", Caption = "거래일", HorzAlignment = HorzAlignment.Center, Width = 90 },
				new XGridColumn() { FieldName = "ITEM_NAME", Caption = "품명", Width = 300 },
				new XGridColumn() { FieldName = "BASE_AMT", Caption = "전일잔액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "SALE_AMT", Caption = "당일매출", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "DPST_AMT", Caption = "당일입금", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "BLNC_AMT", Caption = "당일잔액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Custom }
			);
		}

		protected override void DataLoad(object param = null)
		{
			if (DataValidate() == false) return;
			gridList.BindData("Base", "GetList", "GetSalesLedgerList", new DataMap() {
				{ "ST_SALE_DATE", datSaleDate.DateFrEdit.GetDateChar8() },
				{ "ED_SALE_DATE", datSaleDate.DateToEdit.GetDateChar8() },
				{ "CUSTOMER_ID", txtCustomer.EditValue }
			});
		}
	}
}