namespace JW.AUBE.Core.Forms.Auth
{
	partial class TableDefinitionForm
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
			this.lcItemDbName = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupDbName = new JW.AUBE.Core.Controls.Common.XLookup();
			this.lcGridTables = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridTables = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemSchemaName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtSchemaName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemTableName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtTableName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtDescription = new DevExpress.XtraEditors.TextEdit();
			this.lcItemRemarks = new DevExpress.XtraLayout.LayoutControlItem();
			this.memRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemTableId = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtTableId = new DevExpress.XtraEditors.TextEdit();
			this.gridColumns = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcTabColumns = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupColumns = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridColumns = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDbName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDbName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridTables)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSchemaName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSchemaName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemRemarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtTableId);
			this.lc.Controls.Add(this.lupDbName);
			this.lc.Controls.Add(this.memRemarks);
			this.lc.Controls.Add(this.txtDescription);
			this.lc.Controls.Add(this.txtTableName);
			this.lc.Controls.Add(this.txtSchemaName);
			this.lc.Controls.Add(this.gridColumns);
			this.lc.Controls.Add(this.gridTables);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 176, 635, 350);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.splitterItem1,
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGridTables});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(459, 495);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemDbName});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(445, 81);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 24);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(431, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(108, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(130, 61);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(315, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcItemDbName
			// 
			this.lcItemDbName.Control = this.lupDbName;
			this.lcItemDbName.Location = new System.Drawing.Point(0, 0);
			this.lcItemDbName.Name = "lcItemDbName";
			this.lcItemDbName.Size = new System.Drawing.Size(431, 24);
			this.lcItemDbName.TextSize = new System.Drawing.Size(108, 14);
			// 
			// lupDbName
			// 
			this.lupDbName.DataSource = null;
			this.lupDbName.DisplayMember = "";
			this.lupDbName.GroupCode = null;
			this.lupDbName.ListMember = "LIST_NAME";
			this.lupDbName.Location = new System.Drawing.Point(130, 37);
			this.lupDbName.Name = "lupDbName";
			this.lupDbName.NullText = "[EditValue is null]";
			this.lupDbName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lupDbName.SelectedIndex = -1;
			this.lupDbName.Size = new System.Drawing.Size(315, 20);
			this.lupDbName.StyleController = this.lc;
			this.lupDbName.TabIndex = 14;
			this.lupDbName.ValueMember = "";
			// 
			// lcGridTables
			// 
			this.lcGridTables.Control = this.gridTables;
			this.lcGridTables.Location = new System.Drawing.Point(0, 81);
			this.lcGridTables.Name = "lcGridTables";
			this.lcGridTables.Size = new System.Drawing.Size(445, 400);
			this.lcGridTables.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridTables.TextVisible = false;
			// 
			// gridTables
			// 
			this.gridTables.Compress = false;
			this.gridTables.DataSource = null;
			this.gridTables.Editable = true;
			this.gridTables.FocusedRowHandle = -2147483648;
			this.gridTables.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridTables.Location = new System.Drawing.Point(11, 92);
			this.gridTables.Name = "gridTables";
			this.gridTables.PageFooterCenter = null;
			this.gridTables.PageFooterLeft = null;
			this.gridTables.PageFooterRight = null;
			this.gridTables.PageHeaderCenter = null;
			this.gridTables.PageHeaderLeft = null;
			this.gridTables.PageHeaderRight = null;
			this.gridTables.Pager = null;
			this.gridTables.PrintFooter = null;
			this.gridTables.PrintHeader = null;
			this.gridTables.ReadOnly = false;
			this.gridTables.ShowFooter = false;
			this.gridTables.ShowGroupPanel = false;
			this.gridTables.Size = new System.Drawing.Size(441, 396);
			this.gridTables.TabIndex = 7;
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemSchemaName,
            this.lcItemTableName,
            this.lcItemDescription,
            this.lcItemRemarks,
            this.lcItemTableId});
			this.lcGroupEdit.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(515, 152);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcItemSchemaName
			// 
			this.lcItemSchemaName.Control = this.txtSchemaName;
			this.lcItemSchemaName.Location = new System.Drawing.Point(0, 0);
			this.lcItemSchemaName.Name = "lcItemSchemaName";
			this.lcItemSchemaName.Size = new System.Drawing.Size(305, 24);
			this.lcItemSchemaName.TextSize = new System.Drawing.Size(108, 14);
			// 
			// txtSchemaName
			// 
			this.txtSchemaName.Location = new System.Drawing.Point(594, 11);
			this.txtSchemaName.Name = "txtSchemaName";
			this.txtSchemaName.Size = new System.Drawing.Size(189, 20);
			this.txtSchemaName.StyleController = this.lc;
			this.txtSchemaName.TabIndex = 10;
			// 
			// lcItemTableName
			// 
			this.lcItemTableName.Control = this.txtTableName;
			this.lcItemTableName.Location = new System.Drawing.Point(0, 24);
			this.lcItemTableName.Name = "lcItemTableName";
			this.lcItemTableName.Size = new System.Drawing.Size(501, 24);
			this.lcItemTableName.TextSize = new System.Drawing.Size(108, 14);
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(594, 35);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(385, 20);
			this.txtTableName.StyleController = this.lc;
			this.txtTableName.TabIndex = 11;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.txtDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 48);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(501, 24);
			this.lcItemDescription.TextSize = new System.Drawing.Size(108, 14);
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(594, 59);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(385, 20);
			this.txtDescription.StyleController = this.lc;
			this.txtDescription.TabIndex = 12;
			// 
			// lcItemRemarks
			// 
			this.lcItemRemarks.Control = this.memRemarks;
			this.lcItemRemarks.Location = new System.Drawing.Point(0, 72);
			this.lcItemRemarks.MaxSize = new System.Drawing.Size(0, 66);
			this.lcItemRemarks.MinSize = new System.Drawing.Size(126, 66);
			this.lcItemRemarks.Name = "lcItemRemarks";
			this.lcItemRemarks.Size = new System.Drawing.Size(501, 66);
			this.lcItemRemarks.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemRemarks.TextSize = new System.Drawing.Size(108, 14);
			// 
			// memRemarks
			// 
			this.memRemarks.Location = new System.Drawing.Point(594, 83);
			this.memRemarks.Name = "memRemarks";
			this.memRemarks.Size = new System.Drawing.Size(385, 62);
			this.memRemarks.StyleController = this.lc;
			this.memRemarks.TabIndex = 13;
			// 
			// lcItemTableId
			// 
			this.lcItemTableId.Control = this.txtTableId;
			this.lcItemTableId.Location = new System.Drawing.Point(305, 0);
			this.lcItemTableId.Name = "lcItemTableId";
			this.lcItemTableId.Size = new System.Drawing.Size(196, 24);
			this.lcItemTableId.TextSize = new System.Drawing.Size(108, 14);
			// 
			// txtTableId
			// 
			this.txtTableId.Location = new System.Drawing.Point(899, 11);
			this.txtTableId.Name = "txtTableId";
			this.txtTableId.Size = new System.Drawing.Size(80, 20);
			this.txtTableId.StyleController = this.lc;
			this.txtTableId.TabIndex = 15;
			// 
			// gridColumns
			// 
			this.gridColumns.Compress = false;
			this.gridColumns.DataSource = null;
			this.gridColumns.Editable = true;
			this.gridColumns.FocusedRowHandle = -2147483648;
			this.gridColumns.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridColumns.Location = new System.Drawing.Point(480, 185);
			this.gridColumns.Name = "gridColumns";
			this.gridColumns.PageFooterCenter = null;
			this.gridColumns.PageFooterLeft = null;
			this.gridColumns.PageFooterRight = null;
			this.gridColumns.PageHeaderCenter = null;
			this.gridColumns.PageHeaderLeft = null;
			this.gridColumns.PageHeaderRight = null;
			this.gridColumns.Pager = null;
			this.gridColumns.PrintFooter = null;
			this.gridColumns.PrintHeader = null;
			this.gridColumns.ReadOnly = false;
			this.gridColumns.ShowFooter = false;
			this.gridColumns.ShowGroupPanel = false;
			this.gridColumns.Size = new System.Drawing.Size(501, 305);
			this.gridColumns.TabIndex = 8;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(459, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 495);
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit,
            this.lcTabColumns});
			this.lcGroupEditBase.Location = new System.Drawing.Point(471, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEditBase.Size = new System.Drawing.Size(515, 495);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// lcTabColumns
			// 
			this.lcTabColumns.Location = new System.Drawing.Point(0, 152);
			this.lcTabColumns.Name = "lcTabColumns";
			this.lcTabColumns.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabColumns.SelectedTabPage = this.lcGroupColumns;
			this.lcTabColumns.SelectedTabPageIndex = 0;
			this.lcTabColumns.Size = new System.Drawing.Size(515, 343);
			this.lcTabColumns.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupColumns});
			// 
			// lcGroupColumns
			// 
			this.lcGroupColumns.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridColumns});
			this.lcGroupColumns.Location = new System.Drawing.Point(0, 0);
			this.lcGroupColumns.Name = "lcGroupColumns";
			this.lcGroupColumns.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupColumns.Size = new System.Drawing.Size(505, 309);
			this.lcGroupColumns.Text = "컬럼리스트";
			// 
			// lcGridColumns
			// 
			this.lcGridColumns.Control = this.gridColumns;
			this.lcGridColumns.Location = new System.Drawing.Point(0, 0);
			this.lcGridColumns.Name = "lcGridColumns";
			this.lcGridColumns.Size = new System.Drawing.Size(505, 309);
			this.lcGridColumns.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridColumns.TextVisible = false;
			// 
			// TableDefinitionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "TableDefinitionForm";
			this.Text = "TableDefinitionForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDbName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDbName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridTables)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSchemaName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSchemaName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemRemarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridColumns)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private JW.AUBE.Core.Controls.Grid.XGrid gridTables;
		private DevExpress.XtraLayout.LayoutControlItem lcGridTables;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Controls.Grid.XGrid gridColumns;
		private DevExpress.XtraEditors.TextEdit txtSchemaName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSchemaName;
		private DevExpress.XtraEditors.TextEdit txtDescription;
		private DevExpress.XtraEditors.TextEdit txtTableName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemTableName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraEditors.MemoEdit memRemarks;
		private DevExpress.XtraLayout.LayoutControlItem lcItemRemarks;
		private Controls.Common.XLookup lupDbName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDbName;
		private DevExpress.XtraLayout.TabbedControlGroup lcTabColumns;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupColumns;
		private DevExpress.XtraLayout.LayoutControlItem lcGridColumns;
		private DevExpress.XtraEditors.TextEdit txtTableId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemTableId;
	}
}