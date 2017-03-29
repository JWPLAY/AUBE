namespace JW.AUBE.Core.Forms.Sales
{
	partial class SaleStatListForm
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
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemSaleDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datSaleDate = new JW.AUBE.Core.Controls.Common.XPeriod();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupStat = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSaleProduct = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridSaleProduct = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSaleProduct = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupSaleCustomer = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridSaleCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSaleCustomer = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupSaleCategory = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridSaleCategory = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSaleCategory = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupSalePayType = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridSalePayType = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSalePayType = new JW.AUBE.Core.Controls.Grid.XGrid();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSaleDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupStat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSalePayType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSalePayType)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridSalePayType);
			this.lc.Controls.Add(this.gridSaleCategory);
			this.lc.Controls.Add(this.gridSaleCustomer);
			this.lc.Controls.Add(this.gridSaleProduct);
			this.lc.Controls.Add(this.datSaleDate);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1115, 213, 450, 400);
			this.lc.Size = new System.Drawing.Size(1012, 418);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGroupStat});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1012, 418);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemSaleDate,
            this.emptySpaceItem1});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(1008, 57);
			// 
			// lcItemSaleDate
			// 
			this.lcItemSaleDate.Control = this.datSaleDate;
			this.lcItemSaleDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemSaleDate.Name = "lcItemSaleDate";
			this.lcItemSaleDate.Size = new System.Drawing.Size(497, 24);
			this.lcItemSaleDate.TextSize = new System.Drawing.Size(82, 14);
			// 
			// datSaleDate
			// 
			this.datSaleDate.FromEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			this.datSaleDate.Location = new System.Drawing.Point(97, 30);
			this.datSaleDate.MaximumSize = new System.Drawing.Size(0, 20);
			this.datSaleDate.MinimumSize = new System.Drawing.Size(215, 20);
			this.datSaleDate.Name = "datSaleDate";
			this.datSaleDate.Size = new System.Drawing.Size(407, 20);
			this.datSaleDate.TabIndex = 5;
			this.datSaleDate.ToEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(497, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcGroupStat
			// 
			this.lcGroupStat.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSaleProduct,
            this.lcGroupSaleCustomer,
            this.lcGroupSaleCategory,
            this.lcGroupSalePayType});
			this.lcGroupStat.Location = new System.Drawing.Point(0, 57);
			this.lcGroupStat.Name = "lcGroupStat";
			this.lcGroupStat.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupStat.Size = new System.Drawing.Size(1008, 357);
			this.lcGroupStat.TextVisible = false;
			// 
			// lcGroupSaleProduct
			// 
			this.lcGroupSaleProduct.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridSaleProduct});
			this.lcGroupSaleProduct.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSaleProduct.Name = "lcGroupSaleProduct";
			this.lcGroupSaleProduct.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSaleProduct.Size = new System.Drawing.Size(499, 173);
			this.lcGroupSaleProduct.Text = "상품별 매출현황";
			// 
			// lcGridSaleProduct
			// 
			this.lcGridSaleProduct.Control = this.gridSaleProduct;
			this.lcGridSaleProduct.Location = new System.Drawing.Point(0, 0);
			this.lcGridSaleProduct.Name = "lcGridSaleProduct";
			this.lcGridSaleProduct.Size = new System.Drawing.Size(489, 144);
			this.lcGridSaleProduct.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridSaleProduct.TextVisible = false;
			// 
			// gridSaleProduct
			// 
			this.gridSaleProduct.Compress = false;
			this.gridSaleProduct.DataSource = null;
			this.gridSaleProduct.Editable = true;
			this.gridSaleProduct.FocusedRowHandle = -2147483648;
			this.gridSaleProduct.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridSaleProduct.Location = new System.Drawing.Point(14, 90);
			this.gridSaleProduct.Name = "gridSaleProduct";
			this.gridSaleProduct.PageFooterCenter = null;
			this.gridSaleProduct.PageFooterLeft = null;
			this.gridSaleProduct.PageFooterRight = null;
			this.gridSaleProduct.PageHeaderCenter = null;
			this.gridSaleProduct.PageHeaderLeft = null;
			this.gridSaleProduct.PageHeaderRight = null;
			this.gridSaleProduct.Pager = null;
			this.gridSaleProduct.PrintFooter = null;
			this.gridSaleProduct.PrintHeader = null;
			this.gridSaleProduct.ReadOnly = false;
			this.gridSaleProduct.ShowFooter = false;
			this.gridSaleProduct.ShowGroupPanel = false;
			this.gridSaleProduct.Size = new System.Drawing.Size(485, 140);
			this.gridSaleProduct.TabIndex = 8;
			// 
			// lcGroupSaleCustomer
			// 
			this.lcGroupSaleCustomer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridSaleCustomer});
			this.lcGroupSaleCustomer.Location = new System.Drawing.Point(499, 0);
			this.lcGroupSaleCustomer.Name = "lcGroupSaleCustomer";
			this.lcGroupSaleCustomer.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSaleCustomer.Size = new System.Drawing.Size(499, 173);
			this.lcGroupSaleCustomer.Text = "거래처별 매출현황";
			// 
			// lcGridSaleCustomer
			// 
			this.lcGridSaleCustomer.Control = this.gridSaleCustomer;
			this.lcGridSaleCustomer.Location = new System.Drawing.Point(0, 0);
			this.lcGridSaleCustomer.Name = "lcGridSaleCustomer";
			this.lcGridSaleCustomer.Size = new System.Drawing.Size(489, 144);
			this.lcGridSaleCustomer.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridSaleCustomer.TextVisible = false;
			// 
			// gridSaleCustomer
			// 
			this.gridSaleCustomer.Compress = false;
			this.gridSaleCustomer.DataSource = null;
			this.gridSaleCustomer.Editable = true;
			this.gridSaleCustomer.FocusedRowHandle = -2147483648;
			this.gridSaleCustomer.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridSaleCustomer.Location = new System.Drawing.Point(513, 90);
			this.gridSaleCustomer.Name = "gridSaleCustomer";
			this.gridSaleCustomer.PageFooterCenter = null;
			this.gridSaleCustomer.PageFooterLeft = null;
			this.gridSaleCustomer.PageFooterRight = null;
			this.gridSaleCustomer.PageHeaderCenter = null;
			this.gridSaleCustomer.PageHeaderLeft = null;
			this.gridSaleCustomer.PageHeaderRight = null;
			this.gridSaleCustomer.Pager = null;
			this.gridSaleCustomer.PrintFooter = null;
			this.gridSaleCustomer.PrintHeader = null;
			this.gridSaleCustomer.ReadOnly = false;
			this.gridSaleCustomer.ShowFooter = false;
			this.gridSaleCustomer.ShowGroupPanel = false;
			this.gridSaleCustomer.Size = new System.Drawing.Size(485, 140);
			this.gridSaleCustomer.TabIndex = 9;
			// 
			// lcGroupSaleCategory
			// 
			this.lcGroupSaleCategory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridSaleCategory});
			this.lcGroupSaleCategory.Location = new System.Drawing.Point(0, 173);
			this.lcGroupSaleCategory.Name = "lcGroupSaleCategory";
			this.lcGroupSaleCategory.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSaleCategory.Size = new System.Drawing.Size(499, 174);
			this.lcGroupSaleCategory.Text = "카테고리별 매출현황";
			// 
			// lcGridSaleCategory
			// 
			this.lcGridSaleCategory.Control = this.gridSaleCategory;
			this.lcGridSaleCategory.Location = new System.Drawing.Point(0, 0);
			this.lcGridSaleCategory.Name = "lcGridSaleCategory";
			this.lcGridSaleCategory.Size = new System.Drawing.Size(489, 145);
			this.lcGridSaleCategory.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridSaleCategory.TextVisible = false;
			// 
			// gridSaleCategory
			// 
			this.gridSaleCategory.Compress = false;
			this.gridSaleCategory.DataSource = null;
			this.gridSaleCategory.Editable = true;
			this.gridSaleCategory.FocusedRowHandle = -2147483648;
			this.gridSaleCategory.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridSaleCategory.Location = new System.Drawing.Point(14, 263);
			this.gridSaleCategory.Name = "gridSaleCategory";
			this.gridSaleCategory.PageFooterCenter = null;
			this.gridSaleCategory.PageFooterLeft = null;
			this.gridSaleCategory.PageFooterRight = null;
			this.gridSaleCategory.PageHeaderCenter = null;
			this.gridSaleCategory.PageHeaderLeft = null;
			this.gridSaleCategory.PageHeaderRight = null;
			this.gridSaleCategory.Pager = null;
			this.gridSaleCategory.PrintFooter = null;
			this.gridSaleCategory.PrintHeader = null;
			this.gridSaleCategory.ReadOnly = false;
			this.gridSaleCategory.ShowFooter = false;
			this.gridSaleCategory.ShowGroupPanel = false;
			this.gridSaleCategory.Size = new System.Drawing.Size(485, 141);
			this.gridSaleCategory.TabIndex = 10;
			// 
			// lcGroupSalePayType
			// 
			this.lcGroupSalePayType.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridSalePayType});
			this.lcGroupSalePayType.Location = new System.Drawing.Point(499, 173);
			this.lcGroupSalePayType.Name = "lcGroupSalePayType";
			this.lcGroupSalePayType.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSalePayType.Size = new System.Drawing.Size(499, 174);
			this.lcGroupSalePayType.Text = "결제방법별 매출현황";
			// 
			// lcGridSalePayType
			// 
			this.lcGridSalePayType.Control = this.gridSalePayType;
			this.lcGridSalePayType.Location = new System.Drawing.Point(0, 0);
			this.lcGridSalePayType.Name = "lcGridSalePayType";
			this.lcGridSalePayType.Size = new System.Drawing.Size(489, 145);
			this.lcGridSalePayType.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridSalePayType.TextVisible = false;
			// 
			// gridSalePayType
			// 
			this.gridSalePayType.Compress = false;
			this.gridSalePayType.DataSource = null;
			this.gridSalePayType.Editable = true;
			this.gridSalePayType.FocusedRowHandle = -2147483648;
			this.gridSalePayType.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridSalePayType.Location = new System.Drawing.Point(513, 263);
			this.gridSalePayType.Name = "gridSalePayType";
			this.gridSalePayType.PageFooterCenter = null;
			this.gridSalePayType.PageFooterLeft = null;
			this.gridSalePayType.PageFooterRight = null;
			this.gridSalePayType.PageHeaderCenter = null;
			this.gridSalePayType.PageHeaderLeft = null;
			this.gridSalePayType.PageHeaderRight = null;
			this.gridSalePayType.Pager = null;
			this.gridSalePayType.PrintFooter = null;
			this.gridSalePayType.PrintHeader = null;
			this.gridSalePayType.ReadOnly = false;
			this.gridSalePayType.ShowFooter = false;
			this.gridSalePayType.ShowGroupPanel = false;
			this.gridSalePayType.Size = new System.Drawing.Size(485, 141);
			this.gridSalePayType.TabIndex = 11;
			// 
			// SaleStatListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "SaleStatListForm";
			this.Text = "SaleStatListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSaleDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupStat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSaleCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSaleCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSalePayType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridSalePayType)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Controls.Common.XPeriod datSaleDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSaleDate;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupStat;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSaleProduct;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSaleCustomer;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSaleCategory;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSalePayType;
		private Controls.Grid.XGrid gridSalePayType;
		private Controls.Grid.XGrid gridSaleCategory;
		private Controls.Grid.XGrid gridSaleCustomer;
		private Controls.Grid.XGrid gridSaleProduct;
		private DevExpress.XtraLayout.LayoutControlItem lcGridSaleProduct;
		private DevExpress.XtraLayout.LayoutControlItem lcGridSaleCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcGridSaleCategory;
		private DevExpress.XtraLayout.LayoutControlItem lcGridSalePayType;
	}
}