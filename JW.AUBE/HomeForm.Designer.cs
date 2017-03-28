namespace JW.AUBE
{
	partial class HomeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.pnlStatistic = new System.Windows.Forms.Panel();
			this.chart = new DevExpress.XtraCharts.ChartControl();
			this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
			this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
			this.pnlStatistic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
			this.SuspendLayout();
			// 
			// wb
			// 
			this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wb.Location = new System.Drawing.Point(4, 104);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(990, 460);
			this.wb.TabIndex = 0;
			// 
			// pnlStatistic
			// 
			this.pnlStatistic.BackColor = System.Drawing.Color.White;
			this.pnlStatistic.Controls.Add(this.chartControl1);
			this.pnlStatistic.Controls.Add(this.chart);
			this.pnlStatistic.Controls.Add(this.btnRefresh);
			this.pnlStatistic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlStatistic.Location = new System.Drawing.Point(4, 4);
			this.pnlStatistic.Name = "pnlStatistic";
			this.pnlStatistic.Padding = new System.Windows.Forms.Padding(2, 2, 2, 4);
			this.pnlStatistic.Size = new System.Drawing.Size(990, 100);
			this.pnlStatistic.TabIndex = 1;
			// 
			// chart
			// 
			this.chart.AppearanceNameSerializable = "Dark";
			this.chart.DataBindings = null;
			xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram2.AxisY.Interlaced = true;
			xyDiagram2.AxisY.MinorCount = 4;
			xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
			this.chart.Diagram = xyDiagram2;
			this.chart.Dock = System.Windows.Forms.DockStyle.Left;
			this.chart.Legend.Name = "Default Legend";
			this.chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.chart.Location = new System.Drawing.Point(98, 2);
			this.chart.Name = "chart";
			this.chart.PaletteName = "Northern Lights";
			series2.Name = "Series 1";
			this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
			this.chart.Size = new System.Drawing.Size(500, 94);
			this.chart.TabIndex = 0;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.btnRefresh.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
			this.btnRefresh.Location = new System.Drawing.Point(2, 2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(96, 94);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Cafe AUBE";
			// 
			// chartControl1
			// 
			this.chartControl1.AppearanceNameSerializable = "Dark";
			this.chartControl1.DataBindings = null;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
			xyDiagram1.AxisX.WholeRange.SideMarginsValue = 0D;
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.chartControl1.Diagram = xyDiagram1;
			this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartControl1.Legend.Name = "Default Legend";
			this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.chartControl1.Location = new System.Drawing.Point(598, 2);
			this.chartControl1.Name = "chartControl1";
			this.chartControl1.PaletteName = "Northern Lights";
			series1.Name = "Series 1";
			series1.View = areaSeriesView1;
			this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.chartControl1.Size = new System.Drawing.Size(390, 94);
			this.chartControl1.TabIndex = 2;
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.Controls.Add(this.wb);
			this.Controls.Add(this.pnlStatistic);
			this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Name = "HomeForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "HomeForm";
			this.pnlStatistic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wb;
		private System.Windows.Forms.Panel pnlStatistic;
		private DevExpress.XtraCharts.ChartControl chart;
		private DevExpress.XtraEditors.SimpleButton btnRefresh;
		private DevExpress.XtraCharts.ChartControl chartControl1;
	}
}