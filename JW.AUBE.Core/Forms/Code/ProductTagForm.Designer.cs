namespace JW.AUBE.Core.Forms.Code
{
	partial class ProductTagForm
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
			this.lcGroupFind = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupTagPreview = new DevExpress.XtraLayout.LayoutControlGroup();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.dvTag = new DevExpress.XtraPrinting.Preview.DocumentViewer();
			this.lcTag = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupPrint = new DevExpress.XtraLayout.LayoutControlGroup();
			this.spnPrintCount = new DevExpress.XtraEditors.SpinEdit();
			this.lcItemPrintCount = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonPrint = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupTagPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTag)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupPrint)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnPrintCount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPrintCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonPrint)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnPrint);
			this.lc.Controls.Add(this.spnPrintCount);
			this.lc.Controls.Add(this.dvTag);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1157, 224, 457, 350);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(998, 502);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.lcGroupEditBase,
            this.splitterItem1});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(998, 502);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGridList});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(475, 498);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(461, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(447, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(92, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(114, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(347, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 57);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(461, 427);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(11, 68);
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
			this.gridList.Size = new System.Drawing.Size(457, 423);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupTagPreview,
            this.lcGroupPrint});
			this.lcGroupEditBase.Location = new System.Drawing.Point(487, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(507, 498);
			// 
			// lcGroupTagPreview
			// 
			this.lcGroupTagPreview.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcTag});
			this.lcGroupTagPreview.Location = new System.Drawing.Point(0, 0);
			this.lcGroupTagPreview.Name = "lcGroupTagPreview";
			this.lcGroupTagPreview.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupTagPreview.Size = new System.Drawing.Size(507, 458);
			this.lcGroupTagPreview.TextVisible = false;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(475, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 498);
			// 
			// dvTag
			// 
			this.dvTag.IsMetric = true;
			this.dvTag.Location = new System.Drawing.Point(498, 11);
			this.dvTag.Name = "dvTag";
			this.dvTag.Size = new System.Drawing.Size(489, 440);
			this.dvTag.TabIndex = 8;
			// 
			// lcTag
			// 
			this.lcTag.Control = this.dvTag;
			this.lcTag.Location = new System.Drawing.Point(0, 0);
			this.lcTag.Name = "lcTag";
			this.lcTag.Size = new System.Drawing.Size(493, 444);
			this.lcTag.TextSize = new System.Drawing.Size(0, 0);
			this.lcTag.TextVisible = false;
			// 
			// lcGroupPrint
			// 
			this.lcGroupPrint.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemPrintCount,
            this.lcButtonPrint});
			this.lcGroupPrint.Location = new System.Drawing.Point(0, 458);
			this.lcGroupPrint.Name = "lcGroupPrint";
			this.lcGroupPrint.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupPrint.Size = new System.Drawing.Size(507, 40);
			this.lcGroupPrint.TextVisible = false;
			// 
			// spnPrintCount
			// 
			this.spnPrintCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spnPrintCount.Location = new System.Drawing.Point(594, 469);
			this.spnPrintCount.Name = "spnPrintCount";
			this.spnPrintCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.spnPrintCount.Size = new System.Drawing.Size(146, 20);
			this.spnPrintCount.StyleController = this.lc;
			this.spnPrintCount.TabIndex = 9;
			// 
			// lcItemPrintCount
			// 
			this.lcItemPrintCount.Control = this.spnPrintCount;
			this.lcItemPrintCount.Location = new System.Drawing.Point(0, 0);
			this.lcItemPrintCount.Name = "lcItemPrintCount";
			this.lcItemPrintCount.Size = new System.Drawing.Size(246, 26);
			this.lcItemPrintCount.TextSize = new System.Drawing.Size(92, 14);
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(744, 469);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(243, 22);
			this.btnPrint.StyleController = this.lc;
			this.btnPrint.TabIndex = 10;
			this.btnPrint.Text = "인쇄하기";
			// 
			// lcButtonPrint
			// 
			this.lcButtonPrint.Control = this.btnPrint;
			this.lcButtonPrint.Location = new System.Drawing.Point(246, 0);
			this.lcButtonPrint.Name = "lcButtonPrint";
			this.lcButtonPrint.Size = new System.Drawing.Size(247, 26);
			this.lcButtonPrint.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonPrint.TextVisible = false;
			// 
			// ProductTagForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.Name = "ProductTagForm";
			this.Text = "ProductTagForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupTagPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTag)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupPrint)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnPrintCount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPrintCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonPrint)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private JW.AUBE.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupTagPreview;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraPrinting.Preview.DocumentViewer dvTag;
		private DevExpress.XtraLayout.LayoutControlItem lcTag;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupPrint;
		private DevExpress.XtraEditors.SimpleButton btnPrint;
		private DevExpress.XtraEditors.SpinEdit spnPrintCount;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPrintCount;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonPrint;
	}
}