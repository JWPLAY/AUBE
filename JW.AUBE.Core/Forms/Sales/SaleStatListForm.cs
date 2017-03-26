using System;
using System.Collections.Generic;
using DevExpress.Data;
using DevExpress.Utils;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Sales
{
	public partial class SaleStatListForm : EditForm
	{
		public SaleStatListForm()
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

			datSaleDate.Init();
			InitGrid();
		}
		void InitGrid()
		{
			gridSaleProduct.Init();
			gridSaleProduct.ShowFooter = true;
			gridSaleProduct.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "SALE_QTY", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "SALE_AMT", Width = 120, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			});

			gridSaleCustomer.Init();
			gridSaleCustomer.ShowFooter = true;
			gridSaleCustomer.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() {FieldName="CUSTOMER_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() {FieldName="CUSTOMER_NAME", Width=200 },
				new XGridColumn() {FieldName="SALE_QTY", Width=100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() {FieldName="SALE_AMT", Width=120, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			});

			gridSaleCategory.Init();
			gridSaleCategory.ShowFooter = true;
			gridSaleCategory.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() {FieldName="CATEGORY", Width=200 },
				new XGridColumn() {FieldName="SALE_QTY", Width=100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() {FieldName="SALE_AMT", Width=120, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			});

			gridSalePayType.Init();
			gridSalePayType.ShowFooter = true;
			gridSalePayType.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() {FieldName="PAY_TYPE", Width=100 },
				new XGridColumn() {FieldName="SALE_QTY", Width=100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() {FieldName="SALE_AMT", Width=120, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString="N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			});
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				DataMap p = new DataMap();
				p.SetValue("ST_SALE_DATE", datSaleDate.DateFrEdit.GetDateChar8());
				p.SetValue("ED_SALE_DATE", datSaleDate.DateToEdit.GetDateChar8());

				var res = DBTranHelper.Execute("Sales", "GetSaleStat", p);

				if (res.TranList.Length == 0)
					throw new Exception("조회 데이터가 없습니다.");

				if (res.TranList.Length > 0)
					gridSaleProduct.DataSource = (res.TranList[0].Data as List<DataMap>).DataMapListToDataTable("Data1");

				if (res.TranList.Length > 1)
					gridSaleCustomer.DataSource = (res.TranList[1].Data as List<DataMap>).DataMapListToDataTable("Data2");

				if (res.TranList.Length > 2)
					gridSaleCategory.DataSource = (res.TranList[2].Data as List<DataMap>).DataMapListToDataTable("Data3");

				if (res.TranList.Length > 3)
					gridSalePayType.DataSource = (res.TranList[3].Data as List<DataMap>).DataMapListToDataTable("Data4");

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}