using System;
using JW.AUBE.Model.Enums;

namespace JW.AUBE.Model.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class CustomPropertyAttribute : Attribute
	{
		public string Caption { get; set; }
		public ColumnTypeEnum ColumnType { get; set; }
		public HorzAlignmentEnum HorzAlignment { get; set; }
		public int Width { get; set; }
		public FormatTypeEnum FormatType { get; set; }
		public string FormatString { get; set; }
		public bool Visible { get; set; }
		public bool ReadOnly { get; set; }
		public bool IsSummary { get; set; }
		public SummaryItemTypeEnum SummaryItemType { get; set; }
		public bool IsSummaryGroup { get; set; }
	}
}
