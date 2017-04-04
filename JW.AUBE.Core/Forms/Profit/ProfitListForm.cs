using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Profit
{
	public partial class ProfitListForm : EditForm
	{
		public ProfitListForm()
		{
			InitializeComponent();
		}

		protected override void InitButtons()
		{
			SetToolbarButtons(new Models.ToolbarButtons() { Refresh = true, Export = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			datClosingYm.Init(Enumerations.CalendarViewType.MonthView);
			txtProduct.Init("ALL_PRODUCT", "PRODUCT_ID", "PRODUCT_NAME", null, null);

			InitCombo();
			InitGrid();
		}
		void InitCombo()
		{
			lupProductType.BindData("PRODUCT_TYPE", null, "ALL", true);
			lupCategory.BindData("CATEGORY", null, "ALL", true);
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.ShowFooter = true;
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "PRODUCT_TYPE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "CATEGORY", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "SALE_AMT", Caption = "당월매출", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "BASE_AMT", Caption = "기초재고", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "PURC_AMT", Caption = "당월매입", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "PROD_AMT", Caption = "당월생산", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ADJS_AMT", Caption = "당월조정", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "BLNC_AMT", Caption = "기말재고", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "COST_AMT", Caption = "매출원가", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "PRFT_AMT", Caption = "매출이익", HorzAlignment = HorzAlignment.Far, Width = 110, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "PRFT_RAT", Caption = "이익율(%)", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "P2", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Custom },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
				);

			gridList.SetMerge("PRODUCT_TYPE", "CATEGORY");
			
			gridList.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");

			gridList.RowCellStyle += delegate (object sender, RowCellStyleEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Column.FieldName.EndsWith("_QTY") || 
						e.Column.FieldName.EndsWith("_AMT"))
					{
						if (e.CellValue.ToDecimalNullToZero() < 0)
							e.Appearance.ForeColor = Color.Red;
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			(gridList.MainView as GridView).CustomSummaryCalculate += delegate (object sender, DevExpress.Data.CustomSummaryEventArgs e)
			{
				try
				{
					GridView view = sender as GridView;
					GridSummaryItem col = e.Item as GridSummaryItem;
					if (col == null)
						return;

					if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
					{
						if (col.FieldName.Equals("PRFT_RAT"))
						{
							decimal den = view.Columns["SALE_AMT"].SummaryItem.SummaryValue.ToDecimalNullToZero();
							decimal num = view.Columns["PRFT_AMT"].SummaryItem.SummaryValue.ToDecimalNullToZero();
							e.TotalValue = (den > 0 && num > 0) ? num / den : 0;
						}
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Profit", "GetList", null, new DataMap() {
				{ "CLOSING_YM", datClosingYm.GetDateChar6() },
				{ "PRODUCT_ID", txtProduct.EditValue },
				{ "PRODUCT_TYPE", lupProductType.EditValue },
				{ "CATEGORY", lupCategory.EditValue }
			});
		}
	}
}