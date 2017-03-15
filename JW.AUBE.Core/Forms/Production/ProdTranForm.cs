﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;
using JW.AUBE.Data.Models.Production;

namespace JW.AUBE.Core.Forms.Production
{
	public partial class ProdTranForm : EditForm
	{
		public ProdTranForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datSchProdDate.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemProdDate.Tag = true;
			lcItemProduct.Tag = true;

			SetFieldNames();

			lcItemSchProdDate.SetFieldCaption("조회기간");
			lcItemSchProduct.SetFieldCaption("검색제품명");
			
			txtProdId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);
						
			datSchProdDate.Init();
			datProdDate.Init();
			spnProdQty.SetFormat("N0", false);
			txtProductId.Init("PROD_PRODUCT", "PRODUCT_ID", "PRODUCT_NAME", null, null);
			txtSchProduct.Init("PROD_PRODUCT", "PRODUCT_ID", "PRODUCT_NAME", null, null);

			InitGrid();
		}

		void InitGrid()
		{
			#region 조회리스트
			gridList.Init();
			gridList.AddGridColumns(new XGridColumn[]
			{
				new XGridColumn() { FieldName="ROW_NO" },
				new XGridColumn() { FieldName="PROD_ID", Visible = false },
				new XGridColumn() { FieldName="PROD_DATE", HorzAlignment = HorzAlignment.Center, Width=100 },
				new XGridColumn() { FieldName="PRODUCT_ID",   HorzAlignment = HorzAlignment.Center, Width = 60, Visible = false },
				new XGridColumn() { FieldName="PRODUCT_CODE", HorzAlignment = HorzAlignment.Center, Width = 80  },
				new XGridColumn() { FieldName="PRODUCT_NAME", HorzAlignment = HorzAlignment.Near,   Width = 200 },
				new XGridColumn() { FieldName="PROD_QTY", HorzAlignment = HorzAlignment.Far, Width = 80, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName="REMARKS", Width = 200 },
				new XGridColumn() { FieldName="INS_TIME" },
				new XGridColumn() { FieldName="INS_USER", Visible = false },
				new XGridColumn() { FieldName="INS_USER_NAME" },
				new XGridColumn() { FieldName="UPD_TIME" },
				new XGridColumn() { FieldName="UPD_USER", Visible = false },
				new XGridColumn() { FieldName="UPD_USER_NAME" }
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "PROD_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
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
				txtProdId.Clear();
				txtProductId.Clear();
				spnProdQty.Clear();
				memRemarks.Clear();
				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
				this.EditMode = EditModeEnum.New;
				datProdDate.Focus();
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
				gridList.BindData("Production", "GetList", null, new DataMap()
				{
					{ "ST_PROD_DATE", datSchProdDate.DateFrEdit.GetDateChar8() },
					{ "ED_PROD_DATE", datSchProdDate.DateToEdit.GetDateChar8() },
					{ "PRODUCT_ID", txtProductId.EditValue }					
				});

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
				var res = ServerRequest.GetData("Production", new DataMap() { { "PROD_ID", id } });
				if (res.DataList.Count > 0)
				{
					if (res.DataList[0].Data == null)
						throw new Exception("조회 데이터가 없습니다.");

					ProdTranDataModel model = (ProdTranDataModel)res.DataList[0].Data;

					txtProdId.EditValue = model.PROD_ID;
					datProdDate.SetDateChar8(model.PROD_DATE);
					txtProductId.EditValue = model.PRODUCT_ID;
					txtProductId.EditText = model.PRODUCT_NAME;
					spnProdQty.EditValue = model.PROD_QTY;
					memRemarks.EditValue = model.REMARKS;

					txtInsTime.EditValue = model.INS_TIME;
					txtInsUserName.EditValue = model.INS_USER_NAME;
					txtUpdTime.EditValue = model.UPD_TIME;
					txtUpdUserName.EditValue = model.UPD_USER_NAME;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtProductId.Focus();

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

				var res = ServerRequest.Execute("Production", "Save", new DataTable[] { map.ToDataTable() });
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
					{ "PROD_ID", txtProdId.EditValue },
					{ "ROWSTATE", "DELETE" }
				}).ToDataTable();

				var res = ServerRequest.SingleRequest("Production", "Save", null, dt);
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
	}
}