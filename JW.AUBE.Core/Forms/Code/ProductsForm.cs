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
	public partial class ProductsForm : EditForm
	{
		public ProductsForm()
		{
			InitializeComponent();

			lupProductType.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
					onProductTypeChanged();
			};
		}

		void onProductTypeChanged()
		{
			if (lupProductType.EditValue.ToStringNullToEmpty() == "M")
			{
				btnLineAdd.Enabled =
					btnLineDel.Enabled =
					btnSave.Enabled = false;
			}
			else
			{
				if (this.EditMode == EditModeEnum.New)
				{
					btnLineAdd.Enabled =
						btnLineDel.Enabled = true;
					btnSave.Enabled = false;
				}
				else
				{
					btnLineAdd.Enabled =
						btnLineDel.Enabled =
						btnSave.Enabled = true;
				}
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons()
			{
				New = true,
				Refresh = true,
				Save = true,
				SaveAndNew = true,
				Delete = true
			});

			btnLineAdd.Click += delegate (object sender, EventArgs e)
			{
				int rowindex = gridMaterials.AddNewRow();
				gridMaterials.SetFocus(rowindex, "MATERIAL_NAME");
			};
			btnLineDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridMaterials.MainView.FocusedRowHandle < 0)
					return;
				gridMaterials.MainView.DeleteRow(gridMaterials.MainView.FocusedRowHandle);
			};
			btnSave.Click += delegate (object sender, EventArgs e)
			{
				DataSaveMaterials();
			};
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemProductName.Tag = true;

			SetFieldNames();
			
			txtProductId.SetEnable(false);
			txtProductCode.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);

			InitCombo();
			InitGrid();

			lcTabGroup.SelectedTabPage = lcTabGroupMaterials;
		}

		void InitCombo()
		{
			lupProductType.BindData("PRODUCT_TYPE", null, null, true);
			lupCategory.BindData("CATEGORY", null, null, true);
			lupUnitType.BindData("UNIT_TYPE", null, null, true);
		}

		void InitGrid()
		{
			#region 조회리스트
			gridList.Init();
			gridList.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn()
				{
					FieldName="ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName="PRODUCT_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 60,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="PRODUCT_CODE",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName="PRODUCT_NAME",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName="PRODUCT_TYPE",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName="CATEGORY",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName="USE_YN",
					HorzAlignment = HorzAlignment.Center,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit(),
					Width = 80
				}
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
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
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

			#region 원부자재목록
			gridMaterials.Init();

			#region Grid Add Columns
			gridMaterials.AddGridColumns(
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

			gridMaterials.SetRepositoryItemButtonEdit("MATERIAL_NAME");
			gridMaterials.SetEditable("MATERIAL_NAME", "INPUT_QTY");

			gridMaterials.SetColumnBackColor(Color.Black, "ROW_NO");
			gridMaterials.SetColumnForeColor(Color.Yellow, "ROW_NO");
			gridMaterials.ColumnFix("ROW_NO");

			#region Grid Events
			(gridMaterials.MainView.Columns["MATERIAL_NAME"].ColumnEdit as RepositoryItemButtonEdit).KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					doSearchMaterial();
				}
			};
			(gridMaterials.MainView.Columns["MATERIAL_NAME"].ColumnEdit as RepositoryItemButtonEdit).EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (gridMaterials.GetValue(gridMaterials.MainView.FocusedRowHandle, "MATERIAL_NAME").ToStringNullToEmpty() == "")
				{
					gridMaterials.SetValue(gridMaterials.MainView.FocusedRowHandle, "MATERIAL_NAME", null);
					gridMaterials.SetValue(gridMaterials.MainView.FocusedRowHandle, "MATERIAL_ID", null);
				}
			};
			(gridMaterials.MainView.Columns["MATERIAL_NAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				doSearchMaterial();
			};
			#endregion

			#endregion
		}

		void doSearchMaterial()
		{
			try
			{
				gridMaterials.PostEditor();
				gridMaterials.UpdateCurrentRow();

				int rowIndex = gridMaterials.MainView.FocusedRowHandle;
				object findtext = gridMaterials.GetValue(rowIndex, "MATERIAL_NAME");
				DataMap map = CodeHelper.ShowForm("MATERIAL", new DataMap() { { "FIND_TEXT", findtext } });
				if (map != null && map.GetType() == typeof(DataMap) && map.GetValue("MATERIAL_ID").ToStringNullToEmpty() != "")
				{
					gridMaterials.SetValue(rowIndex, "MATERIAL_NAME", map.GetValue("MATERIAL_NAME"));
					gridMaterials.SetValue(rowIndex, "MATERIAL_ID", map.GetValue("MATERIAL_ID"));
					gridMaterials.SetValue(rowIndex, "UNIT_TYPE", map.GetValue("UNIT_TYPE"));
					gridMaterials.SetFocus(rowIndex, "INPUT_QTY");
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
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
				txtProductId.Clear();
				txtProductCode.Clear();
				txtProductName.Clear();
				txtBarcode.Clear();
				chkUseYn.Checked = true;
				memRemarks.Clear();

				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				gridMaterials.DataSource = null;
				gridMaterials.EmptyDataTableBinding();

				onProductTypeChanged();

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
					if (res.DataList[0].Data == null || res.DataList[0].Data.Rows.Count == 0)
						throw new Exception("조회 데이터가 없습니다.");

					DataRow row = res.DataList[0].Data.Rows[0];

					txtProductId.EditValue = row["PRODUCT_ID"];
					txtProductCode.EditValue = row["PRODUCT_CODE"];
					txtProductName.EditValue = row["PRODUCT_NAME"];
					txtBarcode.EditValue = row["BARCODE"];
					lupProductType.EditValue = row["PRODUCT_TYPE"];
					lupCategory.EditValue = row["CATEGORY"];
					lupUnitType.EditValue = row["UNIT_TYPE"];
					txtBarcode.EditValue = row["BARCODE"];
					chkUseYn.EditValue = row["USE_YN"];
					memRemarks.EditValue = row["REMARKS"];

					txtInsTime.EditValue = row["INS_TIME"];
					txtInsUserName.EditValue = row["INS_USER_NAME"];
					txtUpdTime.EditValue = row["UPD_TIME"];
					txtUpdUserName.EditValue = row["UPD_USER_NAME"];					
				}

				if (res.DataList.Count > 1)
				{
					gridMaterials.DataSource = res.DataList[1].Data;
				}

				onProductTypeChanged();

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
				gridMaterials.BindData("Base", "GetList", "SelectProductMaterials", new DataMap() { { "PRODUCT_ID", txtProductId.EditValue } });
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

				if (gridMaterials.MainView.RowCount > 0)
				{
					gridMaterials.PostEditor();
					gridMaterials.UpdateCurrentRow();

					foreach (DataRow row in gridMaterials.GetDataTable().GetChangedData().Rows)
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