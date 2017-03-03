using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace JW.AUBE.Core.Attributes
{
	public class CustomGridDataAttribute : Attribute
	{
		public string FieldName { get; set; }
		public string Caption { get; set; }
		public UnboundColumnType ColumnType { get; set; }
		public HorzAlignment HorzAlignment { get; set; }
		public int Width { get; set; }
		public FormatType FormatType { get; set; }
		public string FormatString { get; set; }
		public bool Visible { get; set; }
		public bool ReadOnly { get; set; }
		public bool IsSummary { get; set; }
		public SummaryItemType SummaryItemType { get; set; }
		public bool IsSummaryGroup { get; set; }
		public RepositoryItem RepositoryItem { get; set; }
		public GridBand OwnerBand { get; set; }
	}
}
