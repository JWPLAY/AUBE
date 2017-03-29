namespace JW.AUBE.Core.Forms.Production
{
	partial class ProdStatForm
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
			this.lcItemProdDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datProdDate = new JW.AUBE.Core.Controls.Common.XPeriod();
			this.lcItemProduct = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtProductId = new JW.AUBE.Core.Controls.Common.XSearch();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemMaterial = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtMaterialId = new JW.AUBE.Core.Controls.Common.XSearch();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProdDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMaterial)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtMaterialId);
			this.lc.Controls.Add(this.txtProductId);
			this.lc.Controls.Add(this.datProdDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(992, 517, 450, 400);
			this.lc.Size = new System.Drawing.Size(1012, 418);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGridList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1012, 418);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemProdDate,
            this.lcItemProduct,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.lcItemMaterial,
            this.emptySpaceItem2});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(1008, 105);
			// 
			// lcItemProdDate
			// 
			this.lcItemProdDate.Control = this.datProdDate;
			this.lcItemProdDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemProdDate.Name = "lcItemProdDate";
			this.lcItemProdDate.Size = new System.Drawing.Size(497, 24);
			this.lcItemProdDate.TextSize = new System.Drawing.Size(85, 14);
			// 
			// datProdDate
			// 
			this.datProdDate.FromEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			this.datProdDate.Location = new System.Drawing.Point(100, 30);
			this.datProdDate.MaximumSize = new System.Drawing.Size(0, 20);
			this.datProdDate.MinimumSize = new System.Drawing.Size(215, 20);
			this.datProdDate.Name = "datProdDate";
			this.datProdDate.Size = new System.Drawing.Size(404, 20);
			this.datProdDate.TabIndex = 5;
			this.datProdDate.ToEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			// 
			// lcItemProduct
			// 
			this.lcItemProduct.Control = this.txtProductId;
			this.lcItemProduct.Location = new System.Drawing.Point(0, 24);
			this.lcItemProduct.Name = "lcItemProduct";
			this.lcItemProduct.Size = new System.Drawing.Size(497, 24);
			this.lcItemProduct.TextSize = new System.Drawing.Size(85, 14);
			// 
			// txtProductId
			// 
			this.txtProductId.CodeField = "CodeId";
			this.txtProductId.CodeGroup = "Codes";
			this.txtProductId.CodeWidth = 100;
			this.txtProductId.DisplayFields = new string[] {
        "CodeId",
        "CodeName"};
			this.txtProductId.EditText = null;
			this.txtProductId.EditValue = null;
			this.txtProductId.Location = new System.Drawing.Point(100, 54);
			this.txtProductId.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtProductId.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtProductId.Name = "txtProductId";
			this.txtProductId.NameField = "CodeName";
			this.txtProductId.Parameters = null;
			this.txtProductId.Size = new System.Drawing.Size(404, 20);
			this.txtProductId.TabIndex = 7;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(497, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(497, 24);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemMaterial
			// 
			this.lcItemMaterial.Control = this.txtMaterialId;
			this.lcItemMaterial.Location = new System.Drawing.Point(0, 48);
			this.lcItemMaterial.Name = "lcItemMaterial";
			this.lcItemMaterial.Size = new System.Drawing.Size(497, 24);
			this.lcItemMaterial.TextSize = new System.Drawing.Size(85, 14);
			// 
			// txtMaterialId
			// 
			this.txtMaterialId.CodeField = "CODE";
			this.txtMaterialId.CodeGroup = "CODES";
			this.txtMaterialId.CodeWidth = 100;
			this.txtMaterialId.DisplayFields = new string[] {
        "CODE",
        "NAME"};
			this.txtMaterialId.EditText = null;
			this.txtMaterialId.EditValue = null;
			this.txtMaterialId.Location = new System.Drawing.Point(100, 78);
			this.txtMaterialId.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtMaterialId.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtMaterialId.Name = "txtMaterialId";
			this.txtMaterialId.NameField = "NAME";
			this.txtMaterialId.Parameters = null;
			this.txtMaterialId.Size = new System.Drawing.Size(404, 20);
			this.txtMaterialId.TabIndex = 8;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(497, 48);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(497, 24);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
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
			this.gridList.ShowFooter = false;
			this.gridList.ShowGroupPanel = false;
			this.gridList.Size = new System.Drawing.Size(1004, 305);
			this.gridList.TabIndex = 4;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 105);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(1008, 309);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// ProdStatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "ProdStatForm";
			this.Text = "ProdStatForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProdDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMaterial)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private Controls.Common.XPeriod datProdDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemProdDate;
		private Controls.Common.XSearch txtProductId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemProduct;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private Controls.Common.XSearch txtMaterialId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemMaterial;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
	}
}