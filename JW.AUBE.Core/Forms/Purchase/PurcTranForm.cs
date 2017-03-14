using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
				int rowIndex = gridItem.AddNewRow();
				gridItem.SetValue(rowIndex, "PURC_QTY", 0);
				gridItem.SetValue(rowIndex, "PURC_PRICE", 0);
				gridItem.SetValue(rowIndex, "PURC_AMT", 0);
			};
			btnItemDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridItem.MainView.FocusedRowHandle < 0)
					return;

				gridItem.MainView.DeleteRow(gridItem.MainView.FocusedRowHandle);
			};

			txtPurcNo.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					if (txtPurcNo.EditValue.ToStringNullToEmpty().IsNullOrEmpty() == false)
						DataLoad(new DataMap() { { "PURC_NO", txtPurcNo.EditValue } });
				}
			};

			gridItem.MainView.CellValueChanged += delegate (object sender, CellValueChangedEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (Regex.IsMatch(e.Column.FieldName, "PURC_PRICE|PURC_QTY"))
					{
						GridView view = sender as GridView;
						decimal price = view.GetRowCellValue(e.RowHandle, "PURC_PRICE").ToDecimalNullToZero();
						decimal qty = view.GetRowCellValue(e.RowHandle, "PURC_QTY").ToDecimalNullToZero();
						decimal amount = price * qty;
						view.SetRowCellValue(e.RowHandle, "PURC_AMT", amount);
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtPurcNo.Focus();
		}

		protected override void InitButtons()
		{
			SetToolbarButtons(new Models.ToolbarButtons()
			{
				Refresh = true,
				New = true,
				Save = true,
				SaveAndNew = true
			});

			btnItemAdd.Enabled = btnItemDel.Enabled = this.IsDataEdit;
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemCustomer.Tag = true;
			lcItemPurcDate.Tag = true;

			SetFieldNames();

			txtPurcId.SetEnable(false);

			datPurcDate.Init(CalendarViewType.DayView);
			txtCustomerId.Init("CUSTOMER", "CUSTOMER_ID", "CUSTOMER_NAME", null, null);

			InitCombo();
			InitGrid();
		}
		void InitCombo()
		{
			lupPurcType.BindData("PURC_TYPE", null, null, true);
		}
		void InitGrid()
		{
			gridItem.Init();
			gridItem.ShowFooter = true;
			gridItem.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "ITEM_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PURC_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false, IsMandatory = true },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200, IsMandatory = true },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_UNIT", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PURC_PRICE", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "PURC_QTY", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0", IsMandatory = true },
				new XGridColumn() { FieldName = "PURC_AMT", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
				);

			gridItem.SetRepositoryItemButtonEdit("PRODUCT_NAME");
			gridItem.SetEditable("PRODUCT_NAME", "PURC_PRICE", "PURC_QTY");

			#region Grid Events
			(gridItem.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					doSearchProduct();
				}
			};
			(gridItem.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (gridItem.GetValue(gridItem.MainView.FocusedRowHandle, "MATERIAL_NAME").ToStringNullToEmpty() == "")
				{
					gridItem.SetValue(gridItem.MainView.FocusedRowHandle, "MATERIAL_NAME", null);
					gridItem.SetValue(gridItem.MainView.FocusedRowHandle, "MATERIAL_ID", null);
				}
			};
			(gridItem.MainView.Columns["PRODUCT_NAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				doSearchProduct();
			};
			#endregion
		}

		void doSearchProduct()
		{
			try
			{
				gridItem.PostEditor();
				gridItem.UpdateCurrentRow();

				int rowIndex = gridItem.MainView.FocusedRowHandle;
				object findtext = gridItem.GetValue(rowIndex, "PRODUCT_NAME");
				DataMap map = CodeHelper.ShowForm("PURCITEM", new DataMap() { { "FIND_TEXT", findtext } });
				if (map != null && map.GetType() == typeof(DataMap) && map.GetValue("PRODUCT_ID").ToStringNullToEmpty() != "")
				{
					gridItem.SetValue(rowIndex, "PRODUCT_NAME", map.GetValue("PRODUCT_NAME"));
					gridItem.SetValue(rowIndex, "PRODUCT_CODE", map.GetValue("PRODUCT_CODE"));
					gridItem.SetValue(rowIndex, "PRODUCT_ID", map.GetValue("PRODUCT_ID"));
					gridItem.SetValue(rowIndex, "PRODUCT_UNIT", map.GetValue("PRODUCT_UNIT"));
					gridItem.SetFocus(rowIndex, "PURC_PRICE");
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			DataLoad(new DataMap() { { "PURC_ID", param } });
		}

		void DataLoad(DataMap parameters)
		{
			try
			{
				var res = ServerRequest.GetData("Purchase", parameters);
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null)
						throw new Exception("조회 데이터가 없습니다.");

					PurcTranDataModel model = (PurcTranDataModel)res.DataList[0].Data;

					txtPurcId.EditValue = model.PURC_ID;
					txtPurcNo.EditValue = model.PURC_NO;
					datPurcDate.SetDateChar8(model.PURC_DATE);
					lupPurcType.EditValue = model.PURC_TYPE;
					txtCustomerId.EditValue = model.CUSTOMER_ID;
					txtCustomerId.EditText = model.CUSTOMER_NAME;
					memRemarks.EditValue = model.REMARKS;

					txtInsTime.EditValue = model.INS_TIME;
					txtInsUserName.EditValue = model.INS_USER_NAME;
					txtUpdTime.EditValue = model.UPD_TIME;
					txtUpdUserName.EditValue = model.UPD_USER_NAME;

					this.ParamsData = model.PURC_ID;
				}

				if (res.DataList.Count > 1)
				{
					gridItem.DataSource = (res.DataList[1].Data as IList<PurcTranItemDataModel>).ListToDataTable();
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

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (DataValidate() == false) return;
			if (DataValidate(gridItem) == false) return;

			try
			{
				DataTable mst = lc.GroupToDataTable(lcGroupEdit1, lcGroupEdit2);
				mst.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				DataTable item = GetPurcItemData();
				if (item == null || item.Rows.Count == 0)
					throw new Exception("구매품목을 입력해야 합니다.");

				var res = ServerRequest.Execute("Purchase", "Save", new DataTable[] { mst, item });
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				callback(arg, res.DataList[0].ReturnValue);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				DataMap map = new DataMap()
				{
					{ "PURC_ID", txtPurcId.EditValue },
					{ "ROWSTATE", "DELETE" }
				};

				var res = ServerRequest.Execute("Purchase", "Delete", map);
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("삭제하였습니다.");
				callback(arg, null);

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private DataTable GetPurcItemData()
		{
			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("ITEM_ID", typeof(int)),
					new DataColumn("PURC_ID", typeof(int)),
					new DataColumn("PRODUCT_ID", typeof(int)),
					new DataColumn("PURC_PRICE", typeof(decimal)),
					new DataColumn("PURC_QTY", typeof(int)),
					new DataColumn("PURC_AMT", typeof(decimal)),
					new DataColumn("ROWSTATE", typeof(string))
				});

				if (gridItem.MainView.RowCount > 0)
				{
					gridItem.PostEditor();
					gridItem.UpdateCurrentRow();

					foreach (DataRow row in gridItem.GetDataTable().GetChangedData().Rows)
					{
						string rowstate = row["ROWSTATE"].ToString();

						dt.Rows.Add(
							row["ITEM_ID"],
							txtPurcId.EditValue,
							row["PRODUCT_ID"],
							row["PURC_PRICE"],
							row["PURC_QTY"],
							row["PURC_AMT"],
							rowstate
							);
					}
				}

				return dt;
			}
			catch
			{
				throw;
			}
		}
	}
}