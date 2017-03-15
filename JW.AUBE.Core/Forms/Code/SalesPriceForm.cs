using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Helper;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Code
{
	public partial class SalesPriceForm : EditForm
	{
		public SalesPriceForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemProductName.Tag = true;

			SetFieldNames();

			txtRegId.SetEnable(false);
			txtProductId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);

			datSaleDate.Init();
			spnSalePrice.SetFormat("N0", false);
			
			InitGrid();

			lcTabGroup.SelectedTabPage = lcTabGroupHistory;
		}

		void InitGrid()
		{
			#region 조회리스트
			gridList.Init();
			gridList.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "PRODUCT_ID", HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName = "PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "PRODUCT_NAME", HorzAlignment = HorzAlignment.Near, Width = 200 },
				new XGridColumn() { FieldName = "PRODUCT_TYPE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "CATEGORY", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "USE_YN", HorzAlignment = HorzAlignment.Center, RepositoryItem = gridList.GetRepositoryItemCheckEdit(), Width = 80 }
			});

			gridList.SetColumnBackColor(Color.Black, "ROW_NO");
			gridList.SetColumnForeColor(Color.White, "ROW_NO");
			gridList.ColumnFix("ROW_NO");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "PRODUCT_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region 변경이력
			gridHistList.Init();

			#region Grid Add Columns
			gridHistList.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "REG_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 40,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName = "PRODUCT_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 50,
					Visible = false					
				},
				new XGridColumn()
				{
					FieldName = "MATERIAL_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName = "MATERIAL_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "INPUT_QTY",
					HorzAlignment = HorzAlignment.Far,
					FormatType = FormatType.Numeric,
					FormatString = "N2",
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "UNIT_TYPE",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "INS_TIME",
					HorzAlignment = HorzAlignment.Center,
					Width = 150
				},
				new XGridColumn()
				{
					FieldName = "INS_USER_NAME",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "UPD_TIME",
					HorzAlignment = HorzAlignment.Center,
					Width = 150
				},
				new XGridColumn()
				{
					FieldName = "UPD_USER_NAME",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				});
			#endregion

			gridHistList.SetRepositoryItemButtonEdit("MATERIAL_NAME");
			gridHistList.SetEditable("MATERIAL_NAME", "INPUT_QTY");

			gridHistList.SetColumnBackColor(Color.Black, "ROW_NO");
			gridHistList.SetColumnForeColor(Color.Yellow, "ROW_NO");
			gridHistList.ColumnFix("ROW_NO");

			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			try
			{
				txtRegId.Clear();
				txtProductId.Clear();
				txtProductName.Clear();
				spnSalePrice.Clear();
				memRemarks.Clear();

				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				gridHistList.DataSource = null;
				gridHistList.EmptyDataTableBinding();

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
				this.EditMode = EditModeEnum.New;
				txtProductName.Focus();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				gridList.BindData("Base", "GetList", "SelectProducts", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

				if (param != null)
					DetailDataLoad(param);
				else
					DataInit();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var res = ServerRequest.GetData("Product", new DataMap() { { "PRODUCT_ID", id } });
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null || (res.DataList[0].Data as DataTable).Rows.Count == 0)
						throw new Exception("조회 데이터가 없습니다.");

					DataRow row = (res.DataList[0].Data as DataTable).Rows[0];

					txtProductId.EditValue = row["PRODUCT_ID"];
					txtProductName.EditValue = row["PRODUCT_NAME"];
					memRemarks.EditValue = row["REMARKS"];

					txtInsTime.EditValue = row["INS_TIME"];
					txtInsUserName.EditValue = row["INS_USER_NAME"];
					txtUpdTime.EditValue = row["UPD_TIME"];
					txtUpdUserName.EditValue = row["UPD_USER_NAME"];					
				}

				if (res.DataList.Count > 1)
				{
					gridHistList.DataSource = res.DataList[1].Data;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtProductName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				DataMap map = lcGroupEdit.ItemToDataMap();
				map.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				var res = ServerRequest.Execute("Product", "Save", new DataTable[] { map.ToDataTable(), GetMaterialData() });
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				callback(arg, res.DataList[0].ReturnValue);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				DataTable dt = (new DataMap()
				{
					{ "PRODUCT_ID", txtProductId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Base", "Save", "Product", dt, "PRODUCT_ID");
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

		void DataLoadMaterials()
		{
			try
			{
				gridHistList.BindData("Base", "GetList", "SelectProductMaterials", new DataMap() { { "PRODUCT_ID", txtProductId.EditValue } });
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DataSaveMaterials()
		{
			try
			{
				DataTable dt = GetMaterialData();

				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("저장할 건이 없습니다.");

				var res = ServerRequest.SingleRequest("Base", "Save", "ProductMaterial", dt);
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("저장하였습니다.");
				DataLoadMaterials();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private DataTable GetMaterialData()
		{
			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("REG_ID", typeof(int)),
					new DataColumn("PRODUCT_ID", typeof(int)),
					new DataColumn("MATERIAL_ID", typeof(int)),
					new DataColumn("INPUT_QTY", typeof(int)),
					new DataColumn("ROWSTATE", typeof(string))
				});

				if (gridHistList.MainView.RowCount > 0)
				{
					gridHistList.PostEditor();
					gridHistList.UpdateCurrentRow();

					foreach (DataRow row in gridHistList.GetDataTable().GetChangedData().Rows)
					{
						string rowstate = row["ROWSTATE"].ToString();

						dt.Rows.Add(
							row["REG_ID"],
							txtProductId.EditValue,
							row["MATERIAL_ID"],
							row["INPUT_QTY"],
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