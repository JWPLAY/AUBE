using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Interfaces;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Sales
{
	public partial class SaleTranListForm : EditForm
	{
		public SaleTranListForm()
		{
			InitializeComponent();
		}

		protected override void InitButtons()

		{
			SetToolbarButtons(new Models.ToolbarButtons()
			{
				Refresh = true,
				New = true,
				Export = true
			});
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtCustomer.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);
			txtProduct.Init("PRODUCT", "PRODUCT_ID", "PRODUCT_NAME", null, null);

			InitGrid();
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.ShowFooter = true;
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "SALE_NO", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "SALE_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "SALE_DATE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "SALE_TYPE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PAY_TYPE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "CUSTOMER_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "CUSTOMER_NAME", Width = 200 },
				new XGridColumn() { FieldName = "REMARKS", Width = 200 },
				new XGridColumn() { FieldName = "ITEM_NO", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "ITEM_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "SALE_PRICE", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SALE_QTY", HorzAlignment = HorzAlignment.Far, Width = 60, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SALE_AMT", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "PRODUCT_TYPE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "CATEGORY", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
				);

			gridList.SetColumnBackColor(Color.FromArgb(50, 50, 50), "ROW_NO");
			gridList.SetColumnForeColor(Color.White, "ROW_NO");
			gridList.ColumnFix("ROW_NO");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						OpenSaleTran(view.GetRowCellValue(e.RowHandle, "SALE_ID"));
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
			gridList.BindData("Sales", "GetList", null, new DataMap() {
				{ "ST_SALE_DATE", datSaleDate.DateFrEdit.GetDateChar8() },
				{ "ED_SALE_DATE", datSaleDate.DateToEdit.GetDateChar8() },
				{ "CUSTOMER_ID", txtCustomer.EditValue },
				{ "PRODUCT_ID", txtProduct.EditValue }
			});
		}

		protected override void ActNew()
		{
			OpenSaleTran(null);
		}

		private void OpenSaleTran(object param)
		{
			((IMainForm)this.MdiParent).OpenSaleTran(param);
		}
	}
}