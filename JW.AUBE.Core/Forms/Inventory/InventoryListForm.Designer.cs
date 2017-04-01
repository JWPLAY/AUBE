namespace JW.AUBE.Core.Forms.Inventory
{
	partial class InventoryListForm
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
			this.lcItemInvDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datInvDate = new JW.AUBE.Core.Controls.Common.XPeriod();
			this.lcItemProduct = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtProduct = new JW.AUBE.Core.Controls.Common.XSearch();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemProductType = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupProductType = new JW.AUBE.Core.Controls.Common.XLookup();
			this.lcItemCategory = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory = new JW.AUBE.Core.Controls.Common.XLookup();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInvDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProductType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupProductType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.lupCategory);
			this.lc.Controls.Add(this.lupProductType);
			this.lc.Controls.Add(this.txtProduct);
			this.lc.Controls.Add(this.datInvDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1173, 264, 450, 400);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
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
            this.lcItemInvDate,
            this.lcItemProduct,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.lcItemProductType,
            this.lcItemCategory});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(1008, 81);
			// 
			// lcItemInvDate
			// 
			this.lcItemInvDate.Control = this.datInvDate;
			this.lcItemInvDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemInvDate.Name = "lcItemInvDate";
			this.lcItemInvDate.Size = new System.Drawing.Size(497, 24);
			this.lcItemInvDate.TextSize = new System.Drawing.Size(105, 14);
			// 
			// datInvDate
			// 
			this.datInvDate.FromEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			this.datInvDate.Location = new System.Drawing.Point(120, 30);
			this.datInvDate.MaximumSize = new System.Drawing.Size(0, 20);
			this.datInvDate.MinimumSize = new System.Drawing.Size(215, 20);
			this.datInvDate.Name = "datInvDate";
			this.datInvDate.Size = new System.Drawing.Size(384, 20);
			this.datInvDate.TabIndex = 5;
			this.datInvDate.ToEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			// 
			// lcItemProduct
			// 
			this.lcItemProduct.Control = this.txtProduct;
			this.lcItemProduct.Location = new System.Drawing.Point(0, 24);
			this.lcItemProduct.Name = "lcItemProduct";
			this.lcItemProduct.Size = new System.Drawing.Size(497, 24);
			this.lcItemProduct.TextSize = new System.Drawing.Size(105, 14);
			// 
			// txtProduct
			// 
			this.txtProduct.CodeField = "CodeId";
			this.txtProduct.CodeGroup = "Codes";
			this.txtProduct.CodeWidth = 100;
			this.txtProduct.DisplayFields = new string[] {
        "CodeId",
        "CodeName"};
			this.txtProduct.EditText = null;
			this.txtProduct.EditValue = null;
			this.txtProduct.Location = new System.Drawing.Point(120, 54);
			this.txtProduct.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtProduct.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtProduct.Name = "txtProduct";
			this.txtProduct.NameField = "CodeName";
			this.txtProduct.Parameters = null;
			this.txtProduct.Size = new System.Drawing.Size(384, 20);
			this.txtProduct.TabIndex = 7;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(797, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(197, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(797, 24);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(197, 24);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemProductType
			// 
			this.lcItemProductType.Control = this.lupProductType;
			this.lcItemProductType.Location = new System.Drawing.Point(497, 0);
			this.lcItemProductType.Name = "lcItemProductType";
			this.lcItemProductType.Size = new System.Drawing.Size(300, 24);
			this.lcItemProductType.TextSize = new System.Drawing.Size(105, 14);
			// 
			// lupProductType
			// 
			this.lupProductType.DataSource = null;
			this.lupProductType.DisplayMember = "";
			this.lupProductType.GroupCode = null;
			this.lupProductType.ListMember = "LIST_NAME";
			this.lupProductType.Location = new System.Drawing.Point(617, 30);
			this.lupProductType.Name = "lupProductType";
			this.lupProductType.NullText = "[EditValue is null]";
			this.lupProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lupProductType.SelectedIndex = -1;
			this.lupProductType.Size = new System.Drawing.Size(187, 20);
			this.lupProductType.StyleController = this.lc;
			this.lupProductType.TabIndex = 8;
			this.lupProductType.ValueMember = "";
			// 
			// lcItemCategory
			// 
			this.lcItemCategory.Control = this.lupCategory;
			this.lcItemCategory.Location = new System.Drawing.Point(497, 24);
			this.lcItemCategory.Name = "lcItemCategory";
			this.lcItemCategory.Size = new System.Drawing.Size(300, 24);
			this.lcItemCategory.TextSize = new System.Drawing.Size(105, 14);
			// 
			// lupCategory
			// 
			this.lupCategory.DataSource = null;
			this.lupCategory.DisplayMember = "";
			this.lupCategory.GroupCode = null;
			this.lupCategory.ListMember = "LIST_NAME";
			this.lupCategory.Location = new System.Drawing.Point(617, 54);
			this.lupCategory.Name = "lupCategory";
			this.lupCategory.NullText = "[EditValue is null]";
			this.lupCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lupCategory.SelectedIndex = -1;
			this.lupCategory.Size = new System.Drawing.Size(187, 20);
			this.lupCategory.StyleController = this.lc;
			this.lupCategory.TabIndex = 9;
			this.lupCategory.ValueMember = "";
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(4, 85);
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
			this.gridList.Size = new System.Drawing.Size(1004, 329);
			this.gridList.TabIndex = 4;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 81);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(1008, 333);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// InventoryListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "InventoryListForm";
			this.Text = "InventoryListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInvDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemProductType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupProductType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private Controls.Common.XPeriod datInvDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInvDate;
		private Controls.Common.XSearch txtProduct;
		private DevExpress.XtraLayout.LayoutControlItem lcItemProduct;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private Controls.Common.XLookup lupCategory;
		private Controls.Common.XLookup lupProductType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemProductType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCategory;
	}
}