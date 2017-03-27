using System.Drawing;
using DevExpress.Utils;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Production
{
	public partial class ProdStatForm : EditForm
	{
		public ProdStatForm()
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
			
			txtProductId.Init("PRODUCT", "PRODUCT_ID", "PRODUCT_NAME", null, null);
			txtMaterialId.Init("MATERIAL", "MATERIAL_ID", "MATERIAL_NAME", null, null);
			datProdDate.Init();

			InitGrid();
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.ShowFooter = true;
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },				
				new XGridColumn() { FieldName = "PROD_DATE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PROD_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "REMARKS", Width = 200 },
				new XGridColumn() { FieldName = "PROD_QTY", Caption = "생산량", HorzAlignment = HorzAlignment.Far, Width = 60, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "ITEM_NO", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "MATERIAL_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "MATERIAL_NAME", Width = 200 },
				new XGridColumn() { FieldName = "INPUT_QTY", Caption="투입량", HorzAlignment = HorzAlignment.Far, Width = 60, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
				);

			gridList.SetMerge("PROD_DATE", "PROD_ID", "PRODUCT_ID", "PRODUCT_CODE", "PRODUCT_NAME", "REMARKS", "PROD_QTY");

			gridList.SetColumnBackColor(Color.FromArgb(50, 50, 50), "ROW_NO");
			gridList.SetColumnForeColor(Color.White, "ROW_NO");
			gridList.ColumnFix("ROW_NO");
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindData("Base", "GetList", "GetProductionList", new DataMap() {
				{ "ST_PROD_DATE", datProdDate.DateFrEdit.GetDateChar8() },
				{ "ED_PROD_DATE", datProdDate.DateToEdit.GetDateChar8() },
				{ "MATERIAL_ID", txtMaterialId.EditValue },
				{ "PRODUCT_ID", txtProductId.EditValue }
			});
		}
	}
}