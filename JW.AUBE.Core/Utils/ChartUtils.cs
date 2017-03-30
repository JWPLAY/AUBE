using DevExpress.XtraCharts;

namespace JW.AUBE.Core.Utils
{
	public static class ChartUtils
	{
		public static void SetAxisYLabelPercent(this SecondaryAxisY y)
		{
			y.Label.TextPattern = "{V:P0}";
		}
		public static void SetSeriesLabelPointOption(this Series series)
		{
			series.Label.TextPattern = "{V}";
		}
		public static void SetSeriesLabelPointOptionNumeric(this Series series, int precision = 0)
		{
			series.Label.TextPattern = string.Format("{{V:N{0}}}", precision);
		}
		public static void SetSeriesLabelPointOptionPercent(this Series series, int precision = 0)
		{
			series.Label.TextPattern = string.Format("{{V:P{0}}}", precision);
		}
		public static void ShowLegend(this ChartControl chart, bool bShow = true)
		{
			chart.Legend.Visibility = (bShow) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
		}
	}
}
