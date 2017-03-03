using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace JW.AUBE.Core.Controls.Grid
{
	public class XGridMenuItem : IDisposable
	{
		public string Name { get; set; }
		public GridColumn Column { get; set; }
		public GridBand Band { get; set; }
		public GridHitInfo GridHitInfo { get; set; }

		public void Dispose()
		{
			if (Column != null)
			{
				Column.Dispose();
				Column = null;
			}
			if (Band != null)
			{
				Band.Dispose();
				Band = null;
			}
		}
		public XGridMenuItem()
		{
			Name = string.Empty;
			Column = null;
			Band = null;
			GridHitInfo = null;
		}

		public XGridMenuItem(string name, GridColumn column, GridBand band, GridHitInfo hitInfo)
		{
			Name = name;
			Column = column;
			Band = band;
			GridHitInfo = hitInfo;
		}
	}
}
