using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Reports;
using JW.AUBE.Core.Utils;
using JW.AUBE.Model.Codes;

namespace JW.AUBE.Core.Forms.Code
{
	public partial class ProductTagForm : EditForm
	{
		public ProductTagForm()
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

			SetFieldNames();

			spnPrintCount.SetFormat("N0", false);

			InitGrid();
			InitDocument();
			
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
				new XGridColumn() { FieldName = "PRODUCT_NAME", Width = 200 },
				new XGridColumn() { FieldName = "SALE_PRICE", HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", Width = 100 },
				new XGridColumn() { FieldName = "COST_PRICE", HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", Width = 100 },
				new XGridColumn() { FieldName = "PRODUCT_TYPE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "CATEGORY", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "USE_YN", HorzAlignment = HorzAlignment.Center, RepositoryItem = gridList.GetRepositoryItemCheckEdit(), Width = 80 }
			});

			gridList.SetColumnBackColor(SkinUtils.ForeColor, "ROW_NO");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "ROW_NO");
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
						DataLoadPrint(view.GetRowCellValue(e.RowHandle, "PRODUCT_ID"), view.GetRowCellValue(e.RowHandle, "PRODUCT_NAME"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion
		}

		void InitDocument()
		{
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				gridList.BindData("Product", "GetList", null, new DataMap()
				{
					{ "FIND_TEXT", txtFindText.EditValue },
					{ "VIEW_TYPE", "1" }
				});
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DataLoadPrint(object id, object name)
		{
			using (RptProductTagDs ds = new RptProductTagDs())
			{
				ds.Tables.Clear();

				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("PRODUCT_ID", typeof(int)),
					new DataColumn("PRODUCT_NAME", typeof(string))
				});
				dt.Rows.Add(id, name);
	
				ds.Tables.Add(dt);
				ds.Tables[0].TableName = "Products";
				ds.Tables[0].PrimaryKey = new DataColumn[] { dt.Columns["PRODUCT_ID"] };

				using(RptProductTag rpt = new RptProductTag())
				{
					rpt.DataSource = ds;
					dvTag.DocumentSource = rpt;
					rpt.CreateDocument();
				}
			}
		}
	}
}