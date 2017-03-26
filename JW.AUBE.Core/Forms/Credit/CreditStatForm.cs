using DevExpress.Data;
using DevExpress.Utils;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Credit
{
	public partial class CreditStatForm : EditForm
	{
		public CreditStatForm()
		{
			InitializeComponent();
		}

		protected override void InitButtons()

		{
			SetToolbarButtons(new Models.ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

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
				new XGridColumn() { FieldName = "CUSTOMER_ID", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "CUSTOMER_NAME", Width = 200 },
				new XGridColumn() { FieldName = "BASE_AMT", Caption = "기초잔액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "SALE_AMT", Caption = "매출액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "DPST_AMT", Caption = "입금액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "BLNC_AMT", Caption = "기말잔액", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			);
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "GetCreditList", new DataMap() {
				{ "ST_SALE_DATE", datSaleDate.DateFrEdit.GetDateChar8() },
				{ "ED_SALE_DATE", datSaleDate.DateToEdit.GetDateChar8() },
				{ "CUSTOMER_ID", txtCustomer.EditValue }
			});
		}
	}
}