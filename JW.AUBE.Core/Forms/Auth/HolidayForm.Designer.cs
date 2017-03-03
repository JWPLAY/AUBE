namespace JW.AUBE.Core.Forms.Auth
{
	partial class HolidayForm
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
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemHolidayName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtHolidayName = new DevExpress.XtraEditors.TextEdit();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemInsTime = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtInsTime = new DevExpress.XtraEditors.TextEdit();
			this.lcItemInsUserName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtInsUser = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdTime = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdTime = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdUserName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdUser = new DevExpress.XtraEditors.TextEdit();
			this.datHolidayDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemHolidayDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHolidayName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHolidayName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsUserName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdUserName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datHolidayDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datHolidayDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHolidayDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.datHolidayDate);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.txtUpdUser);
			this.lc.Controls.Add(this.txtUpdTime);
			this.lc.Controls.Add(this.txtInsUser);
			this.lc.Controls.Add(this.txtInsTime);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtHolidayName);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 47);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(892, 256, 250, 350);
			this.lc.Size = new System.Drawing.Size(1028, 412);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.lcGroupEdit,
            this.splitterItem1,
            this.lcGroupRegInfo});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1028, 412);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem3});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(418, 408);
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
			this.lcGroupSearch.Size = new System.Drawing.Size(404, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(390, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(133, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(271, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 57);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(404, 337);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
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
			this.gridList.ShowGroupPanel = false;
			this.gridList.Size = new System.Drawing.Size(400, 333);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemHolidayName,
            this.emptySpaceItem3,
            this.lcItemDescription,
            this.lcItemHolidayDate,
            this.emptySpaceItem2});
			this.lcGroupEdit.Location = new System.Drawing.Point(423, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(601, 346);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcItemHolidayName
			// 
			this.lcItemHolidayName.Control = this.txtHolidayName;
			this.lcItemHolidayName.Location = new System.Drawing.Point(0, 24);
			this.lcItemHolidayName.Name = "lcItemHolidayName";
			this.lcItemHolidayName.Size = new System.Drawing.Size(400, 24);
			this.lcItemHolidayName.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtHolidayName
			// 
			this.txtHolidayName.Location = new System.Drawing.Point(549, 35);
			this.txtHolidayName.Name = "txtHolidayName";
			this.txtHolidayName.Size = new System.Drawing.Size(281, 20);
			this.txtHolidayName.StyleController = this.lc;
			this.txtHolidayName.TabIndex = 6;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(400, 24);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(187, 24);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 48);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(587, 284);
			this.lcItemDescription.TextSize = new System.Drawing.Size(111, 14);
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(549, 59);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(468, 280);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 14;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(418, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(5, 408);
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemInsTime,
            this.lcItemInsUserName,
            this.lcItemUpdTime,
            this.lcItemUpdUserName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(423, 346);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(601, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemInsTime
			// 
			this.lcItemInsTime.Control = this.txtInsTime;
			this.lcItemInsTime.Location = new System.Drawing.Point(0, 0);
			this.lcItemInsTime.Name = "lcItemInsTime";
			this.lcItemInsTime.Size = new System.Drawing.Size(292, 24);
			this.lcItemInsTime.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtInsTime
			// 
			this.txtInsTime.Location = new System.Drawing.Point(549, 357);
			this.txtInsTime.Name = "txtInsTime";
			this.txtInsTime.Size = new System.Drawing.Size(173, 20);
			this.txtInsTime.StyleController = this.lc;
			this.txtInsTime.TabIndex = 10;
			// 
			// lcItemInsUserName
			// 
			this.lcItemInsUserName.Control = this.txtInsUser;
			this.lcItemInsUserName.Location = new System.Drawing.Point(0, 24);
			this.lcItemInsUserName.Name = "lcItemInsUserName";
			this.lcItemInsUserName.Size = new System.Drawing.Size(292, 24);
			this.lcItemInsUserName.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtInsUser
			// 
			this.txtInsUser.Location = new System.Drawing.Point(549, 381);
			this.txtInsUser.Name = "txtInsUser";
			this.txtInsUser.Size = new System.Drawing.Size(173, 20);
			this.txtInsUser.StyleController = this.lc;
			this.txtInsUser.TabIndex = 11;
			// 
			// lcItemUpdTime
			// 
			this.lcItemUpdTime.Control = this.txtUpdTime;
			this.lcItemUpdTime.Location = new System.Drawing.Point(292, 0);
			this.lcItemUpdTime.Name = "lcItemUpdTime";
			this.lcItemUpdTime.Size = new System.Drawing.Size(295, 24);
			this.lcItemUpdTime.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtUpdTime
			// 
			this.txtUpdTime.Location = new System.Drawing.Point(841, 357);
			this.txtUpdTime.Name = "txtUpdTime";
			this.txtUpdTime.Size = new System.Drawing.Size(176, 20);
			this.txtUpdTime.StyleController = this.lc;
			this.txtUpdTime.TabIndex = 12;
			// 
			// lcItemUpdUserName
			// 
			this.lcItemUpdUserName.Control = this.txtUpdUser;
			this.lcItemUpdUserName.Location = new System.Drawing.Point(292, 24);
			this.lcItemUpdUserName.Name = "lcItemUpdUserName";
			this.lcItemUpdUserName.Size = new System.Drawing.Size(295, 24);
			this.lcItemUpdUserName.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtUpdUser
			// 
			this.txtUpdUser.Location = new System.Drawing.Point(841, 381);
			this.txtUpdUser.Name = "txtUpdUser";
			this.txtUpdUser.Size = new System.Drawing.Size(176, 20);
			this.txtUpdUser.StyleController = this.lc;
			this.txtUpdUser.TabIndex = 13;
			// 
			// datHolidayDate
			// 
			this.datHolidayDate.EditValue = null;
			this.datHolidayDate.Location = new System.Drawing.Point(549, 11);
			this.datHolidayDate.Name = "datHolidayDate";
			this.datHolidayDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datHolidayDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datHolidayDate.Size = new System.Drawing.Size(181, 20);
			this.datHolidayDate.StyleController = this.lc;
			this.datHolidayDate.TabIndex = 15;
			// 
			// lcItemHolidayDate
			// 
			this.lcItemHolidayDate.Control = this.datHolidayDate;
			this.lcItemHolidayDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemHolidayDate.Name = "lcItemHolidayDate";
			this.lcItemHolidayDate.Size = new System.Drawing.Size(300, 24);
			this.lcItemHolidayDate.TextSize = new System.Drawing.Size(111, 14);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(300, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(287, 24);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// HolidayForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1028, 484);
			this.LookAndFeel.UseDefaultLookAndFeel = false;
			this.Name = "HolidayForm";
			this.Text = "HolidayForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHolidayName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHolidayName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInsUserName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdUserName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datHolidayDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datHolidayDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHolidayDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
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
		private DevExpress.XtraEditors.TextEdit txtHolidayName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemHolidayName;
		private JW.AUBE.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdUser;
		private DevExpress.XtraEditors.TextEdit txtUpdTime;
		private DevExpress.XtraEditors.TextEdit txtInsUser;
		private DevExpress.XtraEditors.TextEdit txtInsTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInsTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInsUserName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdTime;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdUserName;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraEditors.DateEdit datHolidayDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemHolidayDate;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
	}
}