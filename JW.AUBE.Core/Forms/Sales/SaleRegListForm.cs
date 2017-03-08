using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;

namespace JW.AUBE.Core.Forms.Sales
{
	public partial class SaleRegListForm : EditForm
	{
		public SaleRegListForm()
		{
			InitializeComponent();
		}

		protected override void InitButtons()

		{
			SetToolbarButtons(new Models.ToolbarButtons()
			{
				Refresh = true,
				New = true,
				Export = true
			});
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			InitGrid();
		}
		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO", HorzAlignment = HorzAlignment.Center, Width = 50 }
				);

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{

					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void DataLoad(object param = null)
		{
			base.DataLoad(param);
		}
	}
}