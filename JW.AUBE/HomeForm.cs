using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE
{
	public partial class HomeForm : BaseForm
	{
		public HomeForm()
		{
			InitializeComponent();
			Init();

			btnRefresh.Click += delegate (object sender, EventArgs e) { doHomeRefresh(); };
		}

		private void Init()
		{
			chart1.BackColor = chart2.BackColor = SkinUtils.FormBackColor;
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			this.Padding = new Padding(4);

			doHomeRefresh();

			InitChart1();
			InitChart2();
			DataLoad();
		}

		private void doHomeRefresh()
		{
			string url = @"http://www.naver.com";
			if (GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty().IsNullOrEmpty() == false)
				url = GlobalVar.Settings.GetValue("HOMEPAGE").ToStringNullToEmpty();
			wb.Navigate(new Uri(url));
		}

		private void InitChart1()
		{
			try
			{
				chart1.Series.Clear();

				Series series = new Series("매출액", ViewType.Bar);

				chart1.Series.AddRange(new Series[] { series });

				series.CrosshairLabelPattern = "{S} : {V:N0}";
				series.SetSeriesLabelPointOptionNumeric();

				chart1.CrosshairOptions.GroupHeaderPattern = "{A:M월 d일}";
				chart1.Titles[0].Visibility = DefaultBoolean.True;

			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void InitChart2()
		{
			try
			{
				chart2.Series.Clear();

				Series series = new Series("매출액", ViewType.Area);

				chart2.Series.AddRange(new Series[] { series });
				
				series.CrosshairLabelPattern = "{S} : {V:N0}";
				series.SetSeriesLabelPointOptionNumeric();

				chart2.CrosshairOptions.GroupHeaderPattern = "{A:yy년 M월}";
				chart2.Titles[0].Visibility = DefaultBoolean.True;

			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void DataLoad()
		{
			try
			{
				var res = DBTranHelper.GetData("Sales", "GetSaleDashboard", new DataMap() { { "SALE_DATE", DateTime.Now.ToString("yyyyMMdd") } });

				if (res.TranList.Length > 0)
				{
					for (int i = 0; i < chart1.Series.Count; i++)
						chart1.Series[i].Points.Clear();

					var data1 = res.TranList[0].Data as List<DataMap>;
					foreach (DataMap data in data1)
					{
						chart1.Series[0].Points.Add(new SeriesPoint(data.GetValue("SALE_DATE").ToString().ToDateTime(), data.GetValue("SALE_AMT").ToDecimalNullToZero()));
					}
				}

				if (res.TranList.Length > 1)
				{
					for (int i = 0; i < chart2.Series.Count; i++)
						chart2.Series[i].Points.Clear();

					var data2 = res.TranList[1].Data as List<DataMap>;
					foreach (DataMap data in data2)
					{
						chart2.Series[0].Points.Add(new SeriesPoint((data.GetValue("SALE_YM").ToString() + "01").ToDateTime(), data.GetValue("SALE_AMT").ToDecimalNullToZero()));
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}