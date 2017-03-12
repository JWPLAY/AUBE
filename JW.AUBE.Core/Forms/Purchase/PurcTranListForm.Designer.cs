namespace JW.AUBE.Core.Forms.Purchase
{
	partial class PurcTranListForm
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
			this.lcItemPurcDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datPurcDate = new JW.AUBE.Core.Controls.Common.XPeriod();
			this.lcItemCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCustomer = new JW.AUBE.Core.Controls.Common.XSearch();
			this.lcItemProduct = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtProduct = new JW.AUBE.Core.Controls.Common.XSearch();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtProduct);
			this.lc.Controls.Add(this.txtCustomer);
			this.lc.Controls.Add(this.datPurcDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 47);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1173, 264, 450, 400);
			this.lc.Size = new System.Drawing.Size(1012, 412);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGridList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1012, 412);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemPurcDate,
            this.lcItemCustomer,
            this.lcItemProduct,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(1008, 105);
			// 
			// lcItemPurcDate
			// 
			this.lcItemPurcDate.Control = this.datPurcDate;
			this.lcItemPurcDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemPurcDate.Name = "lcItemPurcDate";
			this.lcItemPurcDate.Size = new System.Drawing.Size(497, 24);
			this.lcItemPurcDate.TextSize = new System.Drawing.Size(86, 14);
			// 
			// datPurcDate
			// 
			this.datPurcDate.FromEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			this.datPurcDate.Location = new System.Drawing.Point(101, 30);
			this.datPurcDate.MaximumSize = new System.Drawing.Size(0, 20);
			this.datPurcDate.MinimumSize = new System.Drawing.Size(215, 20);
			this.datPurcDate.Name = "datPurcDate";
			this.datPurcDate.Size = new System.Drawing.Size(403, 20);
			this.datPurcDate.TabIndex = 5;
			this.datPurcDate.ToEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			// 
			// lcItemCustomer
			// 
			this.lcItemCustomer.Control = this.txtCustomer;
			this.lcItemCustomer.Location = new System.Drawing.Point(0, 24);
			this.lcItemCustomer.Name = "lcItemCustomer";
			this.lcItemCustomer.Size = new System.Drawing.Size(497, 24);
			this.lcItemCustomer.TextSize = new System.Drawing.Size(86, 14);
			// 
			// txtCustomer
			// 
			this.txtCustomer.CodeField = "CODE";
			this.txtCustomer.CodeGroup = "CUSTOMER";
			this.txtCustomer.CodeWidth = 100;
			this.txtCustomer.DisplayFields = new string[] {
        "CodeId",
        "CodeName"};
			this.txtCustomer.EditValue = null;
			this.txtCustomer.Location = new System.Drawing.Point(101, 54);
			this.txtCustomer.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.NameField = "NAME";
			this.txtCustomer.Parameters = null;
			this.txtCustomer.Size = new System.Drawing.Size(403, 20);
			this.txtCustomer.TabIndex = 6;
			// 
			// lcItemProduct
			// 
			this.lcItemProduct.Control = this.txtProduct;
			this.lcItemProduct.Location = new System.Drawing.Point(0, 48);
			this.lcItemProduct.Name = "lcItemProduct";
			this.lcItemProduct.Size = new System.Drawing.Size(497, 24);
			this.lcItemProduct.TextSize = new System.Drawing.Size(86, 14);
			// 
			// txtProduct
			// 
			this.txtProduct.CodeField = "CodeId";
			this.txtProduct.CodeGroup = "Codes";
			this.txtProduct.CodeWidth = 100;
			this.txtProduct.DisplayFields = new string[] {
        "CodeId",
        "CodeName"};
			this.txtProduct.EditValue = null;
			this.txtProduct.Location = new System.Drawing.Point(101, 78);
			this.txtProduct.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtProduct.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtProduct.Name = "txtProduct";
			this.txtProduct.NameField = "CodeName";
			this.txtProduct.Parameters = null;
			this.txtProduct.Size = new System.Drawing.Size(403, 20);
			this.txtProduct.TabIndex = 7;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(497, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(497, 24);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(497, 48);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(4, 109);
			this.gridList.Name = "gridList";
			this.gridList.PageFooterCenter = null;
			this.gridList.PageFooterLeft = null;
			this.gridList.PageFooterRight = null;
			this.gridList.PageHeaderCenter = null;
			this.gridList.PageHeaderLeft = null;
			this.gridList.PageHeaderRight = null;
			this.gridList.Pager = null;
			this.gridList.PrintFooter = null;
			this.gridList.PrintHeader = null;
			this.gridList.ReadOnly = false;
			this.gridList.ShowGroupPanel = false;
			this.gridList.Size = new System.Drawing.Size(1004, 299);
			this.gridList.TabIndex = 4;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 105);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(1008, 303);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// PurchaseListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "PurcTranListForm";
			this.Text = "PurcTranListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private Controls.Common.XPeriod datPurcDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPurcDate;
		private Controls.Common.XSearch txtProduct;
		private Controls.Common.XSearch txtCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcItemProduct;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
	}
}