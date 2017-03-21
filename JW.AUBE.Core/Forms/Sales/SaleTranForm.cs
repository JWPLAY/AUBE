using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Sales
{
	public partial class SaleTranForm : EditForm
	{
		public SaleTranForm()
		{
			InitializeComponent();

			btnDiscountRat.Click += delegate (object sender, EventArgs e) { SetSaleInputMode(SaleInputMode.DiscountRate); };
			btnDiscountAmt.Click += delegate (object sender, EventArgs e) { SetSaleInputMode(SaleInputMode.DiscountAmount); };

			btnCancel.Click += delegate (object sender, EventArgs e) { DataInit(); };
			btnConfirm.Click += delegate (object sender, EventArgs e) { ActSaveAndNew(); };

			txtInput.Enter += delegate (object sender, EventArgs e)
			{
				switch (SaleInputMode)
				{
					case SaleInputMode.Item:
						SetMessage("상품 바코드를 입력하거나 상품코드를 입력합니다.");
						break;
					case SaleInputMode.DiscountRate:
						SetMessage("할인율(%)을 입력합니다.");
						break;
					case SaleInputMode.DiscountAmount:
						SetMessage("할인금액을 입력합니다.");
						break;
				}
			};
			txtInput.KeyDown += delegate (object sender, KeyEventArgs e)
			{
			};

			gridCategory.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 1)
				{
					GetSaleProduct();
				}
			};
		}

		[DXBrowsable(false)]
		public SaleInputMode SaleInputMode { get; set; }

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtInput.Focus();
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			this.StartPosition = FormStartPosition.CenterScreen;
			SaleInputMode = SaleInputMode.Item;
		}

		protected override void InitButtons()
		{
			VisibleToolbar = false;
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();
			lcItemInput.Text = "상품등록 ";
			lcItemCustomer.Text = "거래처 ";

			lcItemInput.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue;

			txtCustomer.SetEnable(false);
			spnTotSupAmt.SetEnable(false);
			spnTotTaxAmt.SetEnable(false);
			spnTotSumAmt.SetEnable(false);

			spnTotSupAmt.SetFormat("N0", false, HorzAlignment.Far);
			spnTotTaxAmt.SetFormat("N0", false, HorzAlignment.Far);
			spnTotSumAmt.SetFormat("N0", false, HorzAlignment.Far);

			InitCombo();
			InitGridItems();
			InitGridCategory();
			InitGridProducts();
		}
		void InitCombo()
		{
			lupPayType.BindData("PAY_TYPE", null, null, true);
		}
		void InitGridItems()
		{
			gridItems.Init();
			gridItems.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "PRODUCT_ID", Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "SALE_PRICE", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_RATE", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_PRICE", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SALE_AMT", Width = 110, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_AMT", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "NPAY_AMT", Width = 110, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_TYPE", HorzAlignment = HorzAlignment.Center, Width = 100 }
				);
		}
		void InitGridCategory()
		{
			gridCategory.Init();
			gridCategory.AddGridColumns(
				new XGridColumn() { FieldName = "CATEGORY_CODE", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "CATEGORY_NAME", HorzAlignment = HorzAlignment.Near, Width = 160 }
				);

			GetSaleCategory();
		}
		void InitGridProducts()
		{
			gridProducts.Init();
			gridProducts.AddGridColumns(
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_NAME", HorzAlignment = HorzAlignment.Near, Width = 200 },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "SALE_PRICE", HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", Width = 80 }
				);
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				//var res = ServerRequest.GetData("Sales",  new DataMap() { { "PRODUCT_ID", id } });
				//if (res.DataList.Count > 0)
				//{
				//	if (res.DataList[0].Data == null || res.DataList[0].Data.Rows.Count == 0)
				//		throw new Exception("조회 데이터가 없습니다.");

				//	DataRow row = res.DataList[0].Data.Rows[0];

				//	txtProductId.EditValue = row["PRODUCT_ID"];
				//	txtProductCode.EditValue = row["PRODUCT_CODE"];
				//	txtProductName.EditValue = row["PRODUCT_NAME"];
				//	txtBarcode.EditValue = row["BARCODE"];
				//	lupProductType.EditValue = row["PRODUCT_TYPE"];
				//	lupCategory.EditValue = row["CATEGORY"];
				//	lupUnitType.EditValue = row["UNIT_TYPE"];
				//	txtBarcode.EditValue = row["BARCODE"];
				//	chkUseYn.EditValue = row["USE_YN"];
				//	memRemarks.EditValue = row["REMARKS"];

				//	txtInsTime.EditValue = row["INS_TIME"];
				//	txtInsUserName.EditValue = row["INS_USER_NAME"];
				//	txtUpdTime.EditValue = row["UPD_TIME"];
				//	txtUpdUserName.EditValue = row["UPD_USER_NAME"];
				//}

				//if (res.DataList.Count > 1)
				//{
				//	gridMaterials.DataSource = res.DataList[1].Data;
				//}

				//onProductTypeChanged();

				//this.EditMode = EditModeEnum.Modify;
				//txtProductName.Focus();

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			base.DataSave(arg, callback);
		}

		void SetSaleInputMode(SaleInputMode saleInputMode)
		{
			if (saleInputMode == SaleInputMode.Item)
			{
				lcItemInput.Text = "상품등록 ";
			}
			else if (saleInputMode == SaleInputMode.DiscountRate)
			{
				if (SaleInputMode == saleInputMode)
				{
					SetSaleInputMode(SaleInputMode.Item);
					return;
				}
				else
					lcItemInput.Text = "할인율(%) ";
			}
			else if (saleInputMode == SaleInputMode.DiscountAmount)
			{
				if (SaleInputMode == saleInputMode)
				{
					SetSaleInputMode(SaleInputMode.Item);
					return;
				}
				else
					lcItemInput.Text = "할인금액 ";
			}
			SaleInputMode = saleInputMode;
			txtInput.Clear();
			txtInput.Focus();
		}

		void GetSaleCategory()
		{
			gridCategory.BindData("Sales", "GetCategory", null, null);
			GetSaleProduct();
		}
		void GetSaleProduct()
		{
			gridProducts.BindData("Sales", "GetProducts", null, new DataMap() { { "CATEGORY", gridCategory.GetValue(gridCategory.MainView.FocusedRowHandle, "CATEGORY_CODE") } });
		}
	}
}