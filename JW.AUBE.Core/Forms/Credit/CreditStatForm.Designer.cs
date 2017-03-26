namespace JW.AUBE.Core.Forms.Credit
{
	partial class CreditStatForm
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
			this.lcItemCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCustomer = new JW.AUBE.Core.Controls.Common.XSearch();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSaleDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtCustomer);
			this.lc.Controls.Add(this.datSaleDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1173, 264, 450, 400);
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
            this.lcItemSaleDate,
            this.lcItemCustomer,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(1008, 81);
			// 
			// lcItemSaleDate
			// 
			this.lcItemSaleDate.Control = this.datSaleDate;
			this.lcItemSaleDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemSaleDate.Name = "lcItemSaleDate";
			this.lcItemSaleDate.Size = new System.Drawing.Size(497, 24);
			this.lcItemSaleDate.TextSize = new System.Drawing.Size(86, 14);
			// 
			// datSaleDate
			// 
			this.datSaleDate.FromEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
			this.datSaleDate.Location = new System.Drawing.Point(101, 30);
			this.datSaleDate.MaximumSize = new System.Drawing.Size(0, 20);
			this.datSaleDate.MinimumSize = new System.Drawing.Size(215, 20);
			this.datSaleDate.Name = "datSaleDate";
			this.datSaleDate.Size = new System.Drawing.Size(403, 20);
			this.datSaleDate.TabIndex = 5;
			this.datSaleDate.ToEditValue = new System.DateTime(2017, 3, 8, 14, 6, 25, 648);
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
			this.txtCustomer.CodeField = "CodeId";
			this.txtCustomer.CodeGroup = "Codes";
			this.txtCustomer.CodeWidth = 100;
			this.txtCustomer.DisplayFields = new string[] {
        "CodeId",
        "CodeName"};
			this.txtCustomer.EditText = null;
			this.txtCustomer.EditValue = null;
			this.txtCustomer.Location = new System.Drawing.Point(101, 54);
			this.txtCustomer.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.NameField = "CodeName";
			this.txtCustomer.Parameters = null;
			this.txtCustomer.Size = new System.Drawing.Size(403, 20);
			this.txtCustomer.TabIndex = 6;
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
			// CreditStatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "CreditStatForm";
			this.Text = "CreditStatForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSaleDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private Controls.Common.XPeriod datSaleDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSaleDate;
		private Controls.Common.XSearch txtCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCustomer;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
	}
}