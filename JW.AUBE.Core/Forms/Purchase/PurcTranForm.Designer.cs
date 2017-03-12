namespace JW.AUBE.Core.Forms.Purchase
{
	partial class PurcTranForm
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
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCustomer = new JW.AUBE.Core.Controls.Common.XSearch();
			this.lcItemPurcDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datPurcDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemPurcId = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtPurcId = new DevExpress.XtraEditors.TextEdit();
			this.lcItemPurcNo = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtPurcNo = new DevExpress.XtraEditors.TextEdit();
			this.lcItemPurcType = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupPurcType = new JW.AUBE.Core.Controls.Common.XLookup();
			this.lcItemRemarks = new DevExpress.XtraLayout.LayoutControlItem();
			this.memRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcTab = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcTabGroupItem = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcTabGroupItemButtons = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcButtonItemAdd = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnItemAdd = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonItemDel = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnItemDel = new DevExpress.XtraEditors.SimpleButton();
			this.lcGroupInfoReg = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemInsTime = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtInsTime = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdTime = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdTime = new DevExpress.XtraEditors.TextEdit();
			this.lcItemInsUserName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtInsUserName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdUserName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdUserName = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datPurcDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datPurcDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPurcId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPurcNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupPurcType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemRemarks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabGroupItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabGroupItemButtons)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonItemAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonItemDel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInfoReg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsUserName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsUserName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdUserName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdUserName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtUpdUserName);
			this.lc.Controls.Add(this.txtInsUserName);
			this.lc.Controls.Add(this.txtUpdTime);
			this.lc.Controls.Add(this.txtInsTime);
			this.lc.Controls.Add(this.memRemarks);
			this.lc.Controls.Add(this.txtPurcNo);
			this.lc.Controls.Add(this.txtPurcId);
			this.lc.Controls.Add(this.lupPurcType);
			this.lc.Controls.Add(this.datPurcDate);
			this.lc.Controls.Add(this.btnItemDel);
			this.lc.Controls.Add(this.btnItemAdd);
			this.lc.Controls.Add(this.txtCustomer);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 47);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1034, 345, 450, 400);
			this.lc.Size = new System.Drawing.Size(1012, 412);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit,
            this.lcTab,
            this.lcGroupInfoReg,
            this.lcGroupEdit2});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1012, 412);
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCustomer,
            this.lcItemPurcDate,
            this.lcItemPurcId,
            this.lcItemPurcNo,
            this.lcItemPurcType});
			this.lcGroupEdit.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(514, 86);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcItemCustomer
			// 
			this.lcItemCustomer.Control = this.txtCustomer;
			this.lcItemCustomer.Location = new System.Drawing.Point(0, 48);
			this.lcItemCustomer.MaxSize = new System.Drawing.Size(500, 24);
			this.lcItemCustomer.MinSize = new System.Drawing.Size(500, 24);
			this.lcItemCustomer.Name = "lcItemCustomer";
			this.lcItemCustomer.Size = new System.Drawing.Size(500, 24);
			this.lcItemCustomer.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemCustomer.TextSize = new System.Drawing.Size(111, 14);
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
			this.txtCustomer.Location = new System.Drawing.Point(126, 59);
			this.txtCustomer.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.NameField = "NAME";
			this.txtCustomer.Parameters = null;
			this.txtCustomer.Size = new System.Drawing.Size(381, 20);
			this.txtCustomer.TabIndex = 6;
			// 
			// lcItemPurcDate
			// 
			this.lcItemPurcDate.Control = this.datPurcDate;
			this.lcItemPurcDate.Location = new System.Drawing.Point(0, 24);
			this.lcItemPurcDate.MaxSize = new System.Drawing.Size(250, 24);
			this.lcItemPurcDate.MinSize = new System.Drawing.Size(250, 24);
			this.lcItemPurcDate.Name = "lcItemPurcDate";
			this.lcItemPurcDate.Size = new System.Drawing.Size(250, 24);
			this.lcItemPurcDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemPurcDate.TextSize = new System.Drawing.Size(111, 14);
			// 
			// datPurcDate
			// 
			this.datPurcDate.EditValue = null;
			this.datPurcDate.Location = new System.Drawing.Point(126, 35);
			this.datPurcDate.Name = "datPurcDate";
			this.datPurcDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datPurcDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datPurcDate.Size = new System.Drawing.Size(131, 20);
			this.datPurcDate.StyleController = this.lc;
			this.datPurcDate.TabIndex = 10;
			// 
			// lcItemPurcId
			// 
			this.lcItemPurcId.Control = this.txtPurcId;
			this.lcItemPurcId.Location = new System.Drawing.Point(0, 0);
			this.lcItemPurcId.Name = "lcItemPurcId";
			this.lcItemPurcId.Size = new System.Drawing.Size(250, 24);
			this.lcItemPurcId.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtPurcId
			// 
			this.txtPurcId.Location = new System.Drawing.Point(126, 11);
			this.txtPurcId.Name = "txtPurcId";
			this.txtPurcId.Size = new System.Drawing.Size(131, 20);
			this.txtPurcId.StyleController = this.lc;
			this.txtPurcId.TabIndex = 12;
			// 
			// lcItemPurcNo
			// 
			this.lcItemPurcNo.Control = this.txtPurcNo;
			this.lcItemPurcNo.Location = new System.Drawing.Point(250, 0);
			this.lcItemPurcNo.Name = "lcItemPurcNo";
			this.lcItemPurcNo.Size = new System.Drawing.Size(250, 24);
			this.lcItemPurcNo.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtPurcNo
			// 
			this.txtPurcNo.Location = new System.Drawing.Point(376, 11);
			this.txtPurcNo.Name = "txtPurcNo";
			this.txtPurcNo.Size = new System.Drawing.Size(131, 20);
			this.txtPurcNo.StyleController = this.lc;
			this.txtPurcNo.TabIndex = 13;
			// 
			// lcItemPurcType
			// 
			this.lcItemPurcType.Control = this.lupPurcType;
			this.lcItemPurcType.Location = new System.Drawing.Point(250, 24);
			this.lcItemPurcType.MaxSize = new System.Drawing.Size(250, 24);
			this.lcItemPurcType.MinSize = new System.Drawing.Size(250, 24);
			this.lcItemPurcType.Name = "lcItemPurcType";
			this.lcItemPurcType.Size = new System.Drawing.Size(250, 24);
			this.lcItemPurcType.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemPurcType.TextSize = new System.Drawing.Size(111, 14);
			// 
			// lupPurcType
			// 
			this.lupPurcType.DataSource = null;
			this.lupPurcType.DisplayMember = "";
			this.lupPurcType.GroupCode = null;
			this.lupPurcType.ListMember = "LIST_NAME";
			this.lupPurcType.Location = new System.Drawing.Point(376, 35);
			this.lupPurcType.Name = "lupPurcType";
			this.lupPurcType.NullText = "[EditValue is null]";
			this.lupPurcType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lupPurcType.SelectedIndex = -1;
			this.lupPurcType.Size = new System.Drawing.Size(131, 20);
			this.lupPurcType.StyleController = this.lc;
			this.lupPurcType.TabIndex = 11;
			this.lupPurcType.ValueMember = "";
			// 
			// lcItemRemarks
			// 
			this.lcItemRemarks.Control = this.memRemarks;
			this.lcItemRemarks.Location = new System.Drawing.Point(0, 0);
			this.lcItemRemarks.Name = "lcItemRemarks";
			this.lcItemRemarks.Size = new System.Drawing.Size(480, 72);
			this.lcItemRemarks.TextSize = new System.Drawing.Size(111, 14);
			// 
			// memRemarks
			// 
			this.memRemarks.Location = new System.Drawing.Point(640, 11);
			this.memRemarks.Name = "memRemarks";
			this.memRemarks.Size = new System.Drawing.Size(361, 68);
			this.memRemarks.StyleController = this.lc;
			this.memRemarks.TabIndex = 14;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(9, 154);
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
			this.gridList.Size = new System.Drawing.Size(994, 187);
			this.gridList.TabIndex = 4;
			// 
			// lcTab
			// 
			this.lcTab.Location = new System.Drawing.Point(0, 86);
			this.lcTab.Name = "lcTab";
			this.lcTab.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTab.SelectedTabPage = this.lcTabGroupItem;
			this.lcTab.SelectedTabPageIndex = 0;
			this.lcTab.Size = new System.Drawing.Size(1008, 260);
			this.lcTab.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcTabGroupItem});
			// 
			// lcTabGroupItem
			// 
			this.lcTabGroupItem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridList,
            this.lcTabGroupItemButtons});
			this.lcTabGroupItem.Location = new System.Drawing.Point(0, 0);
			this.lcTabGroupItem.Name = "lcTabGroupItem";
			this.lcTabGroupItem.Size = new System.Drawing.Size(998, 227);
			this.lcTabGroupItem.Text = "품목등록";
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 36);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(998, 191);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// lcTabGroupItemButtons
			// 
			this.lcTabGroupItemButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem4,
            this.lcButtonItemAdd,
            this.lcButtonItemDel});
			this.lcTabGroupItemButtons.Location = new System.Drawing.Point(0, 0);
			this.lcTabGroupItemButtons.Name = "lcTabGroupItemButtons";
			this.lcTabGroupItemButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabGroupItemButtons.Size = new System.Drawing.Size(998, 36);
			this.lcTabGroupItemButtons.TextVisible = false;
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(191, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(797, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcButtonItemAdd
			// 
			this.lcButtonItemAdd.Control = this.btnItemAdd;
			this.lcButtonItemAdd.Location = new System.Drawing.Point(0, 0);
			this.lcButtonItemAdd.MaxSize = new System.Drawing.Size(91, 26);
			this.lcButtonItemAdd.MinSize = new System.Drawing.Size(91, 26);
			this.lcButtonItemAdd.Name = "lcButtonItemAdd";
			this.lcButtonItemAdd.Size = new System.Drawing.Size(91, 26);
			this.lcButtonItemAdd.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonItemAdd.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonItemAdd.TextVisible = false;
			// 
			// btnItemAdd
			// 
			this.btnItemAdd.Location = new System.Drawing.Point(14, 123);
			this.btnItemAdd.Name = "btnItemAdd";
			this.btnItemAdd.Size = new System.Drawing.Size(87, 22);
			this.btnItemAdd.StyleController = this.lc;
			this.btnItemAdd.TabIndex = 8;
			this.btnItemAdd.Text = "추가";
			// 
			// lcButtonItemDel
			// 
			this.lcButtonItemDel.Control = this.btnItemDel;
			this.lcButtonItemDel.Location = new System.Drawing.Point(91, 0);
			this.lcButtonItemDel.MaxSize = new System.Drawing.Size(100, 26);
			this.lcButtonItemDel.MinSize = new System.Drawing.Size(100, 26);
			this.lcButtonItemDel.Name = "lcButtonItemDel";
			this.lcButtonItemDel.Size = new System.Drawing.Size(100, 26);
			this.lcButtonItemDel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonItemDel.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonItemDel.TextVisible = false;
			// 
			// btnItemDel
			// 
			this.btnItemDel.Location = new System.Drawing.Point(105, 123);
			this.btnItemDel.Name = "btnItemDel";
			this.btnItemDel.Size = new System.Drawing.Size(96, 22);
			this.btnItemDel.StyleController = this.lc;
			this.btnItemDel.TabIndex = 9;
			this.btnItemDel.Text = "삭제";
			// 
			// lcGroupInfoReg
			// 
			this.lcGroupInfoReg.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemInsTime,
            this.lcItemUpdTime,
            this.lcItemInsUserName,
            this.lcItemUpdUserName});
			this.lcGroupInfoReg.Location = new System.Drawing.Point(0, 346);
			this.lcGroupInfoReg.Name = "lcGroupInfoReg";
			this.lcGroupInfoReg.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupInfoReg.Size = new System.Drawing.Size(1008, 62);
			this.lcGroupInfoReg.TextVisible = false;
			// 
			// lcItemInsTime
			// 
			this.lcItemInsTime.Control = this.txtInsTime;
			this.lcItemInsTime.Location = new System.Drawing.Point(0, 0);
			this.lcItemInsTime.Name = "lcItemInsTime";
			this.lcItemInsTime.Size = new System.Drawing.Size(497, 24);
			this.lcItemInsTime.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtInsTime
			// 
			this.txtInsTime.Location = new System.Drawing.Point(126, 357);
			this.txtInsTime.Name = "txtInsTime";
			this.txtInsTime.Size = new System.Drawing.Size(378, 20);
			this.txtInsTime.StyleController = this.lc;
			this.txtInsTime.TabIndex = 15;
			// 
			// lcItemUpdTime
			// 
			this.lcItemUpdTime.Control = this.txtUpdTime;
			this.lcItemUpdTime.Location = new System.Drawing.Point(497, 0);
			this.lcItemUpdTime.Name = "lcItemUpdTime";
			this.lcItemUpdTime.Size = new System.Drawing.Size(497, 24);
			this.lcItemUpdTime.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtUpdTime
			// 
			this.txtUpdTime.Location = new System.Drawing.Point(623, 357);
			this.txtUpdTime.Name = "txtUpdTime";
			this.txtUpdTime.Size = new System.Drawing.Size(378, 20);
			this.txtUpdTime.StyleController = this.lc;
			this.txtUpdTime.TabIndex = 16;
			// 
			// lcItemInsUserName
			// 
			this.lcItemInsUserName.Control = this.txtInsUserName;
			this.lcItemInsUserName.Location = new System.Drawing.Point(0, 24);
			this.lcItemInsUserName.Name = "lcItemInsUserName";
			this.lcItemInsUserName.Size = new System.Drawing.Size(497, 24);
			this.lcItemInsUserName.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtInsUserName
			// 
			this.txtInsUserName.Location = new System.Drawing.Point(126, 381);
			this.txtInsUserName.Name = "txtInsUserName";
			this.txtInsUserName.Size = new System.Drawing.Size(378, 20);
			this.txtInsUserName.StyleController = this.lc;
			this.txtInsUserName.TabIndex = 17;
			// 
			// lcItemUpdUserName
			// 
			this.lcItemUpdUserName.Control = this.txtUpdUserName;
			this.lcItemUpdUserName.Location = new System.Drawing.Point(497, 24);
			this.lcItemUpdUserName.Name = "lcItemUpdUserName";
			this.lcItemUpdUserName.Size = new System.Drawing.Size(497, 24);
			this.lcItemUpdUserName.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtUpdUserName
			// 
			this.txtUpdUserName.Location = new System.Drawing.Point(623, 381);
			this.txtUpdUserName.Name = "txtUpdUserName";
			this.txtUpdUserName.Size = new System.Drawing.Size(378, 20);
			this.txtUpdUserName.StyleController = this.lc;
			this.txtUpdUserName.TabIndex = 18;
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemRemarks});
			this.lcGroupEdit2.Location = new System.Drawing.Point(514, 0);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit2.Size = new System.Drawing.Size(494, 86);
			this.lcGroupEdit2.TextVisible = false;
			// 
			// PurcTranForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "PurcTranForm";
			this.Text = "PurcTranForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datPurcDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datPurcDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPurcId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPurcNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPurcType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupPurcType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemRemarks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabGroupItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabGroupItemButtons)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonItemAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonItemDel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInfoReg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsUserName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsUserName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdUserName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdUserName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private Controls.Grid.XGrid gridList;
		private Controls.Common.XSearch txtCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCustomer;
		private DevExpress.XtraLayout.TabbedControlGroup lcTab;
		private DevExpress.XtraLayout.LayoutControlGroup lcTabGroupItem;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private DevExpress.XtraLayout.LayoutControlGroup lcTabGroupItemButtons;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraEditors.SimpleButton btnItemDel;
		private DevExpress.XtraEditors.SimpleButton btnItemAdd;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonItemAdd;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonItemDel;
		private DevExpress.XtraEditors.DateEdit datPurcDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPurcDate;
		private Controls.Common.XLookup lupPurcType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPurcType;
		private DevExpress.XtraEditors.TextEdit txtPurcNo;
		private DevExpress.XtraEditors.TextEdit txtPurcId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPurcId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPurcNo;
		private DevExpress.XtraEditors.MemoEdit memRemarks;
		private DevExpress.XtraLayout.LayoutControlItem lcItemRemarks;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupInfoReg;
		private DevExpress.XtraEditors.TextEdit txtUpdUserName;
		private DevExpress.XtraEditors.TextEdit txtInsUserName;
		private DevExpress.XtraEditors.TextEdit txtUpdTime;
		private DevExpress.XtraEditors.TextEdit txtInsTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInsTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInsUserName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdUserName;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
	}
}