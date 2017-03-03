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
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
			this.lc = new DevExpress.XtraLayout.LayoutControl();
			this.chartMonthly = new DevExpress.XtraCharts.ChartControl();
			this.lcGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcChartMonthly = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartMonthly)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcChartMonthly)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.chartMonthly);
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 0);
			this.lc.Name = "lc";
			this.lc.Root = this.lcGroupBase;
			this.lc.Size = new System.Drawing.Size(998, 568);
			this.lc.TabIndex = 0;
			this.lc.Text = "layoutControl1";
			// 
			// chartMonthly
			// 
			this.chartMonthly.DataBindings = null;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.chartMonthly.Diagram = xyDiagram1;
			this.chartMonthly.Legend.Name = "Default Legend";
			this.chartMonthly.Location = new System.Drawing.Point(24, 43);
			this.chartMonthly.Name = "chartMonthly";
			series1.Name = "Series 1";
			series1.View = lineSeriesView1;
			this.chartMonthly.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.chartMonthly.Size = new System.Drawing.Size(950, 127);
			this.chartMonthly.TabIndex = 4;
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.lcGroupBase.GroupBordersVisible = false;
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlGroup1});
			this.lcGroupBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupBase.Name = "lcGroupBase";
			this.lcGroupBase.Size = new System.Drawing.Size(998, 568);
			this.lcGroupBase.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 174);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(978, 374);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.Color.WhiteSmoke;
			this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
			this.layoutControlGroup1.AppearanceItemCaption.BackColor = System.Drawing.Color.WhiteSmoke;
			this.layoutControlGroup1.AppearanceItemCaption.Options.UseBackColor = true;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcChartMonthly});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(978, 174);
			// 
			// lcChartMonthly
			// 
			this.lcChartMonthly.Control = this.chartMonthly;
			this.lcChartMonthly.Location = new System.Drawing.Point(0, 0);
			this.lcChartMonthly.Name = "lcChartMonthly";
			this.lcChartMonthly.Size = new System.Drawing.Size(954, 131);
			this.lcChartMonthly.TextSize = new System.Drawing.Size(0, 0);
			this.lcChartMonthly.TextVisible = false;
			// 
			// HomeForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.Controls.Add(this.lc);
			this.Name = "HomeForm";
			this.Text = "HomeForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartMonthly)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcChartMonthly)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl lc;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupBase;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraCharts.ChartControl chartMonthly;
		private DevExpress.XtraLayout.LayoutControlItem lcChartMonthly;
	}
}