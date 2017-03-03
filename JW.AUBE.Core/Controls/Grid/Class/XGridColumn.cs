using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace JW.AUBE.Core.Controls.Grid
{
	public class XGridColumn : IDisposable
	{
		public string FieldName { get; set; }
		public string Caption { get; set; }
		public string CaptionCode { get; set; }
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

		public void Dispose()
		{
			if (RepositoryItem != null)
			{
				RepositoryItem.Dispose();
				RepositoryItem = null;
			}
			if (OwnerBand != null)
			{
				OwnerBand.Dispose();
				OwnerBand = null;
			}
		}
		public XGridColumn(
				string fieldName = null,
				string caption = null,
				string captionCode = null,
				bool visible = true,
				HorzAlignment horzAlignment = HorzAlignment.Near,
				UnboundColumnType columnType = UnboundColumnType.String,
				FormatType formatType = FormatType.None,
				string formatString = null,
				bool readOnly = false,
				int width = 0,
				bool isSummary = false,
				SummaryItemType summaryItemType = SummaryItemType.None,
				bool isSummaryGroup = false,
				GridBand ownerBand = null,
				RepositoryItem repositoryItem = null)
		{
			FieldName = fieldName;
			Caption = caption;
			CaptionCode = captionCode;
			ColumnType = columnType;
			HorzAlignment = horzAlignment;
			FormatType = formatType;
			FormatString = formatString;
			Visible = visible;
			ReadOnly = readOnly;
			IsSummary = isSummary;
			SummaryItemType = summaryItemType;
			IsSummaryGroup = isSummaryGroup;
			RepositoryItem = repositoryItem;
			OwnerBand = ownerBand;
			if (width > 0)
				Width = width;
		}
	}
}
