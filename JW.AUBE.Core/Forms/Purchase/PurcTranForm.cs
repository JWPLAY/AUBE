using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Helper;
using JW.AUBE.Core.Utils;
using JW.AUBE.Data.Models.Purchase;

namespace JW.AUBE.Core.Forms.Purchase
{
	public partial class PurcTranForm : EditForm
	{
		public PurcTranForm()
		{
			InitializeComponent();

			btnItemAdd.Click += delegate (object sender, EventArgs e)
			{
				int rowIndex = gridList.AddNewRow();
				gridList.SetValue(rowIndex, "PURC_QTY", 0);
				gridList.SetValue(rowIndex, "PURC_PRICE", 0);
				gridList.SetValue(rowIndex, "PURC_AMT", 0);
			};
			btnItemDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridList.MainView.FocusedRowHandle < 0)
					return;

				gridList.MainView.DeleteRow(gridList.MainView.FocusedRowHandle);
			};
		}

		protected override void InitButtons()
		{
			SetToolbarButtons(new Models.ToolbarButtons()
			{
				Refresh = true,
				New = true,
				Export = true
			});

			btnItemAdd.Enabled = btnItemDel.Enabled = this.IsDataEdit;
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtPurcId.SetEnable(false);
			txtPurcNo.SetEnable(false);

			datPurcDate.Init(Enumerations.CalendarViewType.DayView);
			txtCustomer.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);

			InitGrid();
		}
		void InitCombo()
		{
			lupPurcType.BindData("PURC_TYPE", null, null, true);
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO", HorzAlignment = HorzAlignment.Center, Width = 50 },
				new XGridColumn() { FieldName = "PURC_ITEM_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PURC_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_UNIT", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PURC_PRICE", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "PURC_QTY", HorzAlignment = HorzAlignment.Far, Width = 60, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "PURC_AMT", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "INS_TIME", HorzAlignment = HorzAlignment.Center, Width = 120 },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "UPD_TIME", HorzAlignment = HorzAlignment.Center, Width = 120 },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME", HorzAlignment = HorzAlignment.Center, Width = 100 }
				);

			gridList.SetRepositoryItemButtonEdit("PRODUCT_NAME");
			gridList.SetEditable("PRODUCT_NAME", "PURC_PRICE", "PURC_QTY");

			#region Grid Events
			(gridList.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					doSearchProduct();
				}
			};
			(gridList.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (gridList.GetValue(gridList.MainView.FocusedRowHandle, "MATERIAL_NAME").ToStringNullToEmpty() == "")
				{
					gridList.SetValue(gridList.MainView.FocusedRowHandle, "MATERIAL_NAME", null);
					gridList.SetValue(gridList.MainView.FocusedRowHandle, "MATERIAL_ID", null);
				}
			};
			(gridList.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				doSearchProduct();
			};
			#endregion
		}

		void doSearchProduct()
		{
			try
			{
				gridList.PostEditor();
				gridList.UpdateCurrentRow();

				int rowIndex = gridList.MainView.FocusedRowHandle;
				object findtext = gridList.GetValue(rowIndex, "PRODUCT_NAME");
				DataMap map = CodeHelper.ShowForm("PRODUCT", new DataMap() { { "FIND_TEXT", findtext } });
				if (map != null && map.GetType() == typeof(DataMap) && map.GetValue("PRODUCT_ID").ToStringNullToEmpty() != "")
				{
					gridList.SetValue(rowIndex, "PRODUCT_NAME", map.GetValue("PRODUCT_NAME"));
					gridList.SetValue(rowIndex, "PRODUCT_CODE", map.GetValue("PRODUCT_CODE"));
					gridList.SetValue(rowIndex, "PRODUCT_ID", map.GetValue("PRODUCT_ID"));
					gridList.SetValue(rowIndex, "PRODUCT_UNIT", map.GetValue("PRODUCT_UNIT"));
					gridList.SetFocus(rowIndex, "PURC_PRICE");
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var res = ServerRequest.GetData("Purchase", new DataMap() { { "PURC_ID", param } });
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null)
						throw new Exception("조회 데이터가 없습니다.");

					PurcTranDataModel model = res.DataList[0].Data as PurcTranDataModel;

					txtPurcId.EditValue = model.PURC_ID;
					txtPurcNo.EditValue = model.PURC_NO;
					datPurcDate.EditValue = model.PURC_DATE;
					lupPurcType.EditValue = model.PURC_TYPE;
					memRemarks.EditValue = model.REMARKS;

					txtInsTime.EditValue = model.INS_TIME;
					txtInsUserName.EditValue = model.INS_USER_NAME;
					txtUpdTime.EditValue = model.UPD_TIME;
					txtUpdUserName.EditValue = model.UPD_USER_NAME;
				}

				if (res.DataList.Count > 1)
				{
					gridList.DataSource = res.DataList[1].Data;
				}

				//onProductTypeChanged();

				this.EditMode = EditModeEnum.Modify;
				memRemarks.Focus();

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}