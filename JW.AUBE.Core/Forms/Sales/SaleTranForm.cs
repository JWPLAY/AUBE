using System;
using DevExpress.Utils;
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
			lcItemCustomer.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue;

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
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				}
				);
		}
		void InitGridCategory()
		{
			gridCategories.Init();
			gridCategories.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "CATEGORY_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "CATEGORY_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				});
		}
		void InitGridProducts()
		{
			gridFindItems.Init();
			gridFindItems.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "PRODUCT_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "PRODUCT_CODE",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "PRODUCT_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				});
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


	}
}