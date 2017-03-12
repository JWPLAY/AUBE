using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace JW.AUBE.Core.Controls.Grid
{
	public class XGridColumn : IDisposable
	{
		/// <summary>
		/// 컬럼의 필드명
		/// </summary>
		public string FieldName { get; set; }

		/// <summary>
		/// 컬럼의 표시 문자열
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// 캡션을 생성하는 기준 코드값
		/// </summary>
		public string CaptionCode { get; set; }

		/// <summary>
		/// 컬럼 유형
		/// </summary>
		public UnboundColumnType ColumnType { get; set; }

		/// <summary>
		/// 셀 정렬방법
		/// </summary>
		public HorzAlignment HorzAlignment { get; set; }

		/// <summary>
		/// 컬럼 사이즈
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// 포맷유형
		/// </summary>
		public FormatType FormatType { get; set; }

		/// <summary>
		/// 포맷 문자열
		/// </summary>
		public string FormatString { get; set; }

		/// <summary>
		/// 컬럼 표시 여부
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// 컬럼의 읽기전용 여부
		/// </summary>
		public bool ReadOnly { get; set; }

		/// <summary>
		/// 부분합 표시 여부
		/// </summary>
		public bool IsSummary { get; set; }

		/// <summary>
		/// 부분합의 유형
		/// </summary>
		public SummaryItemType SummaryItemType { get; set; }

		/// <summary>
		/// 부분합 그룹
		/// </summary>
		public bool IsSummaryGroup { get; set; }

		/// <summary>
		/// 컬럼 에디터 유형
		/// </summary>
		public RepositoryItem RepositoryItem { get; set; }

		/// <summary>
		/// 부모 밴드
		/// </summary>
		public GridBand OwnerBand { get; set; }

		/// <summary>
		/// 필수값 여부
		/// </summary>
		public bool IsMandatory { get; set; }

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
				RepositoryItem repositoryItem = null,
				bool isMandatory = false)
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
			IsMandatory = isMandatory;
			if (width > 0)
				Width = width;
		}
	}
}
