namespace JW.AUBE.Core.Reports
{
	partial class RptProductTag
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

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.lblProuctName = new DevExpress.XtraReports.UI.XRLabel();
			this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
			this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.rptProductTagDs1 = new JW.AUBE.Core.Reports.RptProductTagDs();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this.rptProductTagDs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.lblProuctName});
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 500F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// lblProuctName
			// 
			this.lblProuctName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Products.PRODUCT_NAME")});
			this.lblProuctName.Dpi = 254F;
			this.lblProuctName.LocationFloat = new DevExpress.Utils.PointFloat(58.20833F, 25.00001F);
			this.lblProuctName.Name = "lblProuctName";
			this.lblProuctName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.lblProuctName.SizeF = new System.Drawing.SizeF(428.625F, 58.42001F);
			this.lblProuctName.StylePriority.UseTextAlignment = false;
			this.lblProuctName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// topMarginBand1
			// 
			this.topMarginBand1.Dpi = 254F;
			this.topMarginBand1.HeightF = 0F;
			this.topMarginBand1.Name = "topMarginBand1";
			// 
			// bottomMarginBand1
			// 
			this.bottomMarginBand1.Dpi = 254F;
			this.bottomMarginBand1.HeightF = 0F;
			this.bottomMarginBand1.Name = "bottomMarginBand1";
			// 
			// rptProductTagDs1
			// 
			this.rptProductTagDs1.DataSetName = "RptProductTagDs";
			this.rptProductTagDs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Dpi = 254F;
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(58.20833F, 83.42001F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(428.625F, 416.58F);
			// 
			// RptProductTag
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
			this.DataMember = "Products";
			this.DataSource = this.rptProductTagDs1;
			this.Dpi = 254F;
			this.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
			this.PageHeight = 2794;
			this.PageWidth = 500;
			this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
			this.RollPaper = true;
			this.SnapGridSize = 25F;
			this.Version = "16.2";
			((System.ComponentModel.ISupportInitialize)(this.rptProductTagDs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
		private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
		private RptProductTagDs rptProductTagDs1;
		private DevExpress.XtraReports.UI.XRLabel lblProuctName;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
	}
}
