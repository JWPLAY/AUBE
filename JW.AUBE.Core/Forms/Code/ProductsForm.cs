using System;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Code
{
	public partial class ProductsForm : EditForm
	{
		public ProductsForm()
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
				gridMaterials.SetValue(rowindex, "ADDRESS_TYPE", "20");
				gridMaterials.SetFocus(rowindex, "ADDRESS_TYPE");
			};
			btnLineDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridMaterials.MainView.FocusedRowHandle < 0)
					return;
				gridMaterials.MainView.DeleteRow(gridMaterials.MainView.FocusedRowHandle);
			};
			btnSave.Click += delegate (object sender, EventArgs e)
			{
				DataSaveMaterials(true);
			};
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemId.SetFieldName("PRODUCT_ID");
			lcItemName.SetFieldName("PRODUCT_NAME");
			lcItemCode.SetFieldName("PRODUCT_CODE");
			
			txtId.SetEnable(false);
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
					Caption = "NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName="ID",
					Caption = "제품ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 60,
					Visible = false
				},
				new XGridColumn()
				{
					FieldName="CODE",
					Caption = "제품코드",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName="NAME",
					Caption="제품명",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName="PRODUCT_TYPE",
					Caption="제품유형",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName="USE_YN",
					Caption="사용여부",
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
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
			gridMaterials.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "ID",
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
					Width = 100,
					Visible = false
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

			gridMaterials.SetRepositoryItemButtonEdit("MATERIAL_NAME");
			gridMaterials.SetEditable("MATERIAL_NAME", "INPUT_QTY");

			gridMaterials.SetColumnBackColor(Color.Black, "ROW_NO");
			gridMaterials.SetColumnForeColor(Color.Yellow, "ROW_NO");
			gridMaterials.ColumnFix("ROW_NO");
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
				txtId.Clear();
				txtCode.Clear();
				txtName.Clear();
				txtBarcode.Clear();
				chkUseYn.Checked = true;
				memRemarks.Clear();

				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				gridMaterials.DataSource = null;
				gridMaterials.EmptyDataTableBinding();

				this.EditMode = EditModeEnum.New;
				txtName.Focus();
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
				DataTable dt = ServerRequest.SingleRequest("Base", "GetData", "SelectProduct", new DataMap() { { "ID", id } });
				if (dt == null || dt.Rows.Count == 0)
					throw new Exception("조회할 데이터가 없습니다.");

				DataRow row = dt.Rows[0];

				txtId.EditValue = row["ID"];
				txtCode.EditValue = row["CODE"];
				txtName.EditValue = row["NAME"];
				txtBarcode.EditValue = row["BARCODE"];
				lupProductType.EditValue = row["PRODUCT_TYPE"];
				txtBarcode.EditValue = row["BARCODE"];
				chkUseYn.EditValue = row["USE_YN"];
				memRemarks.EditValue = row["REMARKS"];

				txtInsTime.EditValue = row["INS_TIME"];
				txtInsUserName.EditValue = row["INS_USER_NAME"];
				txtUpdTime.EditValue = row["UPD_TIME"];
				txtUpdUserName.EditValue = row["UPD_USER_NAME"];

				DataLoadMaterials();

				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();

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
				DataMap map = lc.ItemToDataMap();
				map.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				var res = ServerRequest.SingleRequest("Base", "Save", "Product", map.ToDataTable(), "ID");
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				DataLoadMaterials();

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
					{ "ID", txtId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Base", "Save", "Product", dt, "ID");
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
				gridMaterials.BindData("Base", "GetList", "SelectProductMaterialInput", new DataMap() { { "PRODUCT_ID", txtId.EditValue } });
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DataSaveMaterials(bool reload = false)
		{
			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("ID", typeof(int)),
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
							row["ID"],
							txtId.EditValue,
							row["MATERIAL_ID"],
							row["INPUT_QTY"],
							rowstate
							);
					}
				}

				if (dt == null || dt.Rows.Count == 0)
				{
					if (reload)
						throw new Exception("저장할 건이 없습니다.");
				}
				else
				{
					var res = ServerRequest.SingleRequest("Base", "Save", "ProductMaterialInput", dt);
					if (res.ErrorNumber != 0)
						throw new Exception(res.ErrorMessage);

					if (reload)
					{
						ShowMsgBox("저장하였습니다.");
						DataLoadMaterials();
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}