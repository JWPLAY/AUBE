﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Helper;
using JW.AUBE.Core.Utils;
using JW.AUBE.Model.Sales;

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
				if (e.KeyCode == Keys.Enter)
				{
					InputEnter();
				}
				else if(e.KeyCode== Keys.Escape)
				{
					txtInput.Clear();
					txtInput.Focus();
				}
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
			gridProducts.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						SetSaleItem(new SaleTranItemDataModel()
						{
							PRODUCT_ID = view.GetRowCellValue(e.RowHandle, "PRODUCT_ID").ToIntegerNullToZero(),
							PRODUCT_CODE = view.GetRowCellValue(e.RowHandle, "PRODUCT_CODE").ToStringNullToEmpty(),
							PRODUCT_NAME = view.GetRowCellValue(e.RowHandle, "PRODUCT_NAME").ToStringNullToEmpty(),
							SALE_PRICE = view.GetRowCellValue(e.RowHandle, "SALE_PRICE").ToIntegerNullToZero(),
							DISC_RATE = 0,
							DISC_PRICE = view.GetRowCellValue(e.RowHandle, "SALE_PRICE").ToIntegerNullToZero(),
							SALE_QTY = 1,
							SALE_AMT = view.GetRowCellValue(e.RowHandle, "SALE_PRICE").ToIntegerNullToZero(),
							DISC_AMT = 0,
							NPAY_AMT = view.GetRowCellValue(e.RowHandle, "SALE_PRICE").ToIntegerNullToZero(),
							DISC_TYPE = "00"
						});
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			Resize += delegate (object sender, EventArgs e)
			{
				if (this.WindowState == FormWindowState.Maximized)
				{
					btnItemPlus.ImageLocation =
						btnItemMinus.ImageLocation =
						btnItemDelete.ImageLocation =
						btnSearchCustomer.ImageLocation =
						btnDiscountRat.ImageLocation =
						btnDiscountAmt.ImageLocation =
						btnCancel.ImageLocation =
						btnConfirm.ImageLocation = ImageLocation.MiddleLeft;
				}
				else
				{
					btnItemPlus.ImageLocation =
						btnItemMinus.ImageLocation =
						btnItemDelete.ImageLocation =
						btnSearchCustomer.ImageLocation =
						btnDiscountRat.ImageLocation =
						btnDiscountAmt.ImageLocation =
						btnCancel.ImageLocation =
						btnConfirm.ImageLocation = ImageLocation.MiddleCenter;
				}
			};

			btnItemPlus.Click += delegate (object sender, EventArgs e)
			{
				if (gridItems.FocusedRowHandle < 0)
					return;

				int saleQty = gridItems.GetValue(gridItems.FocusedRowHandle, "SALE_QTY").ToIntegerNullToZero() + 1;
				gridItems.SetValue(gridItems.FocusedRowHandle, "SALE_QTY", saleQty);
				gridItems.UpdateCurrentRow();
				CalcSaleItem();
			};
			btnItemMinus.Click += delegate (object sender, EventArgs e)
			{
				if (gridItems.FocusedRowHandle < 0)
					return;

				int saleQty = gridItems.GetValue(gridItems.FocusedRowHandle, "SALE_QTY").ToIntegerNullToZero() - 1;
				if (saleQty >= 0)
					gridItems.SetValue(gridItems.FocusedRowHandle, "SALE_QTY", saleQty);
				gridItems.UpdateCurrentRow();
				CalcSaleItem();
			};
			btnItemDelete.Click += delegate (object sender, EventArgs e)
			{
				gridItems.DeleteRow(gridItems.FocusedRowHandle);
				gridItems.UpdateCurrentRow();
				CalcSaleItem();
			};
		}

		[Browsable(false)]
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
			SetButtons();
			ShowDateTime();
			DataInit();
		}

		protected override void InitButtons()
		{
			VisibleToolbar = false;
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();
			lcItemInput.Text = "상품등록";
			lcItemCustomer.Text = "거래처";

			lcItemInput.AppearanceItemCaption.BackColor = Color.DarkBlue;

			txtCustomer.SetEnable(false);

			InitCombo();
			InitGridItems();
			InitGridCategory();
			InitGridProducts();
		}

		void InitCombo()
		{
			lupPayType.BindData("PAY_TYPE", null, null, true);
			lupPayType.Properties.AppearanceDropDown.Font = lupPayType.Font;
		}
		void InitGridItems()
		{
			gridItems.Init();
			gridItems.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "PRODUCT_ID", Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 190 },
				new XGridColumn() { FieldName = "SALE_PRICE", Caption = "판매가", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_RATE", Caption = "할인율", Width = 60, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "DISC_PRICE", Caption = "할인가", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SALE_QTY", Caption = "수량", Width = 60, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "NPAY_AMT", Caption = "판매액", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "DISC_AMT", Caption = "할인액", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = DevExpress.Data.SummaryItemType.Sum },
				new XGridColumn() { FieldName = "SALE_AMT", Caption = "판매가계", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", Visible = false },
				new XGridColumn() { FieldName = "DISC_TYPE", HorzAlignment = HorzAlignment.Center, Width = 80 }
				);
			(gridItems.MainView as GridView).RowHeight = 24;

			gridItems.SetRepositoryItemLookUpEdit("DISC_TYPE", "CODE", "NAME");
			(gridItems.MainView.Columns["DISC_TYPE"].ColumnEdit as RepositoryItemLookUpEdit).DataSource = CodeHelper.Lookup("DISC_TYPE");
		}
		void InitGridCategory()
		{
			gridCategory.Init();
			gridCategory.AddGridColumns(
				new XGridColumn() { FieldName = "CATEGORY_CODE", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "CATEGORY_NAME", HorzAlignment = HorzAlignment.Near, Width = 160 }
				);
			(gridCategory.MainView as GridView).RowHeight = 30;

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
			(gridProducts.MainView as GridView).RowHeight = 30;
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
		protected override void DataInit()
		{

			gridItems.Clear();
			gridItems.DataSource = GetSaleItemData();

			txtInput.Clear();
			txtCustomer.Clear();
			SetSaleInputMode(SaleInputMode.Item);
			esTotSaleAmount.Text = "0";
			esTotDiscAmount.Text = "0";
			esTotNpayAmount.Text = "0";

			GetSaleAmount();

			EditMode = Enumerations.EditModeEnum.New;
			txtInput.Focus();
		}

		private void SetSaleInputMode(SaleInputMode saleInputMode)
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

		private void GetSaleCategory()
		{
			gridCategory.BindData("Sales", "GetCategory", null, null);
			GetSaleProduct();
		}
		private void GetSaleProduct()
		{
			gridProducts.BindData("Sales", "GetProducts", null, new DataMap() { { "CATEGORY", gridCategory.GetValue(gridCategory.MainView.FocusedRowHandle, "CATEGORY_CODE") } });
		}

		private void ShowDateTime()
		{
			Timer timer = new Timer() { Interval = 1000, Enabled = true };
			timer.Tick += delegate (object sender, EventArgs e)
			{
				esSaleDate.Text = string.Format("{0:yyyy.MM.dd} ({1})", DateTime.Now, DateTime.Now.DayOfWeekName());
				esSaleTime.Text = DateTime.Now.ToString("HH:mm");
			};
		}
		private void SetButtons()
		{
			btnItemPlus.Text = btnItemPlus.ToolTip = "수량증가";
			btnItemMinus.Text = btnItemMinus.ToolTip = "수량감소";
			btnItemDelete.Text = btnItemDelete.ToolTip = "품목삭제";
			btnSearchCustomer.Text = btnSearchCustomer.ToolTip = "거래처검색";
			btnDiscountRat.Text = btnDiscountRat.ToolTip = "할인율(%)";
			btnDiscountAmt.Text = btnDiscountAmt.ToolTip = "할인액";
			btnCancel.Text = btnCancel.ToolTip = "판매취소";
			btnConfirm.Text = btnConfirm.ToolTip = "판매완료";

			btnItemPlus.Font = 
				btnItemMinus.Font = 
				btnItemDelete.Font = 
				btnSearchCustomer.Font = 
				btnDiscountRat.Font = 
				btnDiscountAmt.Font =
				btnCancel.Font = 
				btnConfirm.Font = new Font(AppearanceObject.DefaultFont.FontFamily, 10f);
		}

		private void GetSaleAmount()
		{
			try
			{
				var res = ServerRequest.GetData("Sales", "GetSaleSumData", null);
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null)
						throw new Exception("조회 데이터가 없습니다.");

					SaleSumDataModel model = res.DataList[0].Data as SaleSumDataModel;
					esDaySaleCount.Text = string.Format("{0:N0}", model.SALE_DAY_COUNT);
					esDaySaleAmount.Text = string.Format("{0:N0}", model.SALE_DAY_AMOUNT);
					esMonSaleAmount.Text = string.Format("{0:N0}", model.SALE_MON_AMOUNT);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void SetSaleItem(SaleTranItemDataModel model)
		{
			if (gridItems.DataSource == null)
				gridItems.DataSource = GetSaleItemData();

			int rowIndex = gridItems.AddNewRow();
			gridItems.SetValue(rowIndex, "PRODUCT_ID", model.PRODUCT_ID);
			gridItems.SetValue(rowIndex, "PRODUCT_CODE", model.PRODUCT_CODE);
			gridItems.SetValue(rowIndex, "PRODUCT_NAME", model.PRODUCT_NAME);
			gridItems.SetValue(rowIndex, "SALE_PRICE", model.SALE_PRICE);
			gridItems.SetValue(rowIndex, "DISC_RATE", model.DISC_RATE);
			gridItems.SetValue(rowIndex, "DISC_PRICE", model.DISC_PRICE);
			gridItems.SetValue(rowIndex, "SALE_QTY", model.SALE_QTY);
			gridItems.SetValue(rowIndex, "SALE_AMT", model.SALE_AMT);
			gridItems.SetValue(rowIndex, "DISC_AMT", model.DISC_AMT);
			gridItems.SetValue(rowIndex, "NPAY_AMT", model.NPAY_AMT);
			gridItems.SetValue(rowIndex, "DISC_TYPE", "00");
			gridItems.UpdateCurrentRow();

			gridItems.SelectRow(rowIndex);

			SetSaleAmount();
			txtInput.Focus();
		}
		
		private DataTable GetSaleItemData()
		{
			DataTable dt = new DataTable();
			dt.Columns.AddRange(new DataColumn[] {
				new DataColumn("ITEM_ID", typeof(int)),
				new DataColumn("SALE_ID", typeof(int)),
				new DataColumn("PRODUCT_ID", typeof(int)),
				new DataColumn("PRODUCT_CODE", typeof(string)),
				new DataColumn("PRODUCT_NAME", typeof(string)),
				new DataColumn("SALE_PRICE", typeof(int)),
				new DataColumn("DISC_RATE", typeof(int)),
				new DataColumn("DISC_PRICE", typeof(int)),
				new DataColumn("SALE_QTY", typeof(int)),
				new DataColumn("SALE_AMT", typeof(decimal)),
				new DataColumn("DISC_AMT", typeof(decimal)),
				new DataColumn("NPAY_AMT", typeof(decimal)),
				new DataColumn("DISC_TYPE", typeof(string))
			});

			return dt;
		}

		private void SetSaleAmount()
		{
			decimal d_tot_sale_amount = 0;
			decimal d_tot_disc_amount = 0;
			decimal d_tot_npay_amount = 0;

			if (gridItems.MainView.RowCount > 0)
			{
				for (int i = 0; i < gridItems.MainView.RowCount; i++)
				{
					d_tot_sale_amount += gridItems.GetValue(i, "SALE_AMT").ToDecimalNullToZero();
					d_tot_disc_amount += gridItems.GetValue(i, "DISC_AMT").ToDecimalNullToZero();
					d_tot_npay_amount += gridItems.GetValue(i, "NPAY_AMT").ToDecimalNullToZero();
				}
			}

			esTotSaleAmount.Text = string.Format("{0:N0}", d_tot_sale_amount);
			esTotDiscAmount.Text = string.Format("{0:N0}", d_tot_disc_amount);
			esTotNpayAmount.Text = string.Format("{0:N0}", d_tot_npay_amount);
		}

		private void CalcSaleItem()
		{
			if (gridItems.RowCount > 0)
			{
				int rowIndex = gridItems.MainView.FocusedRowHandle;
				int salePrice = gridItems.GetValue(rowIndex, "SALE_PRICE").ToIntegerNullToZero();
				int dcRate = gridItems.GetValue(rowIndex, "DISC_RATE").ToIntegerNullToZero();
				int dcPrice = salePrice - salePrice * dcRate / 100;
				int saleQty = gridItems.GetValue(rowIndex, "SALE_QTY").ToIntegerNullToZero();
				int discAmt = gridItems.GetValue(rowIndex, "DISC_AMT").ToIntegerNullToZero();
				if (dcPrice > 0)
					discAmt = (salePrice - dcPrice) * saleQty;
				int saleAmt = saleQty * salePrice;
				int npayAmt = saleAmt - discAmt;

				gridItems.SetValue(rowIndex, "SALE_PRICE", salePrice);
				gridItems.SetValue(rowIndex, "DISC_RATE", dcRate);
				gridItems.SetValue(rowIndex, "DISC_PRICE", dcPrice);
				gridItems.SetValue(rowIndex, "SALE_QTY", saleQty);
				gridItems.SetValue(rowIndex, "SALE_AMT", saleAmt);
				gridItems.SetValue(rowIndex, "DISC_AMT", discAmt);
				gridItems.SetValue(rowIndex, "NPAY_AMT", npayAmt);
				gridItems.SetValue(rowIndex, "DISC_TYPE", "10");
				gridItems.UpdateCurrentRow();
			}
			SetSaleAmount();
		}

		private void InputEnter()
		{
			if (SaleInputMode == SaleInputMode.Item)
			{

			}
			else if (SaleInputMode == SaleInputMode.DiscountRate)
			{
				if (txtInput.EditValue.ToStringNullToEmpty().IsNumeric() == false)
				{
					ShowMsgBox("할인율은 숫자로 입력해야 합니다.");
					txtInput.Clear();
					txtInput.Focus();
				}
				else
				{
					if (gridItems.MainView.FocusedRowHandle < 0)
						return;

					int rowIndex = gridItems.MainView.FocusedRowHandle;
					int dcRate = txtInput.EditValue.ToIntegerNullToZero();

					gridItems.SetValue(rowIndex, "DISC_RATE", dcRate);
					gridItems.SetValue(rowIndex, "DISC_TYPE", "10");
					gridItems.UpdateCurrentRow();

					CalcSaleItem();

					SetSaleInputMode(SaleInputMode.Item);
					txtInput.Clear();
					txtInput.Focus();
				}
			}
			else if (SaleInputMode == SaleInputMode.DiscountAmount)
			{
				if (txtInput.EditValue.ToStringNullToEmpty().IsNumeric() == false)
				{
					ShowMsgBox("할인액은 숫자로 입력해야 합니다.");
					txtInput.Clear();
					txtInput.Focus();
				}
				else
				{
					if (gridItems.MainView.FocusedRowHandle < 0)
						return;

					int rowIndex = gridItems.MainView.FocusedRowHandle;
					int discAmt = txtInput.EditValue.ToIntegerNullToZero();

					gridItems.SetValue(rowIndex, "DISC_RATE", 0);
					gridItems.SetValue(rowIndex, "DISC_AMT", discAmt);
					gridItems.SetValue(rowIndex, "DISC_TYPE", "20");
					gridItems.UpdateCurrentRow();

					CalcSaleItem();

					SetSaleInputMode(SaleInputMode.Item);
					txtInput.Clear();
					txtInput.Focus();
				}
			}
		}
	}
}