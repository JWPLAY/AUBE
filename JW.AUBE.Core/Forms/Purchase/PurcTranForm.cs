using System;
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
				if(e.KeyCode== Keys.Enter)
				{
					if (txtPurcNo.EditValue.ToStringNullToEmpty().IsNullOrEmpty() == false)
						DataLoad(txtPurcNo.EditValue);
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
				new XGridColumn() { FieldName = "ROW_NO", HorzAlignment = HorzAlignment.Center, Width = 50 },
				new XGridColumn() { FieldName = "ITEM_ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "PURC_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 100, Visible = false, IsMandatory = true },
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200, IsMandatory = true },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_UNIT", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PURC_PRICE", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "PURC_QTY", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N2", IsMandatory = true },
				new XGridColumn() { FieldName = "PURC_AMT", HorzAlignment = HorzAlignment.Far, Width = 100, FormatType = FormatType.Numeric, FormatString = "N2", SummaryItemType = SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "INS_TIME", HorzAlignment = HorzAlignment.Center, Width = 120 },
				new XGridColumn() { FieldName = "INS_USER", Visible = false },
				new XGridColumn() { FieldName = "INS_USER_NAME", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "UPD_TIME", HorzAlignment = HorzAlignment.Center, Width = 120 },
				new XGridColumn() { FieldName = "UPD_USER", Visible = false },
				new XGridColumn() { FieldName = "UPD_USER_NAME", HorzAlignment = HorzAlignment.Center, Width = 100 }
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
			try
			{
				var res = ServerRequest.GetData("Purchase", new DataMap() { { "PURC_ID", param }, { "PURC_NO", param } });
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null || (res.DataList[0].Data as List<DataMap>).Count == 0)
						throw new Exception("조회 데이터가 없습니다.");

					DataMap model = (res.DataList[0].Data as List<DataMap>)[0];

					txtPurcId.EditValue = model.GetValue("PURC_ID");
					txtPurcNo.EditValue = model.GetValue("PURC_NO");
					datPurcDate.EditValue = model.GetValue("PURC_DATE");
					lupPurcType.EditValue = model.GetValue("PURC_TYPE");
					memRemarks.EditValue = model.GetValue("REMARKS");

					txtInsTime.EditValue = model.GetValue("INS_TIME");
					txtInsUserName.EditValue = model.GetValue("INS_USER_NAME");
					txtUpdTime.EditValue = model.GetValue("UPD_TIME");
					txtUpdUserName.EditValue = model.GetValue("UPD_USER_NAME");

					this.ParamsData = txtPurcId.EditValue;
				}

				if (res.DataList.Count > 1)
				{
					gridItem.DataSource = res.DataList[1].Data;
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