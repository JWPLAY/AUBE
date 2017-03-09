namespace JW.AUBE.Core.Forms.Auth
{
	partial class UserMenusForm
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
			this.gridUsers = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridMenus = new JW.AUBE.Core.Controls.Grid.XGrid();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridMenus);
			this.lc.Controls.Add(this.gridUsers);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 42);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1326, 256, 250, 350);
			this.lc.Size = new System.Drawing.Size(990, 495);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.splitterItem1,
            this.lcGroupRegInfo});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 495);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem3});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(250, 491);
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
			this.lcGroupSearch.Size = new System.Drawing.Size(236, 59);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(222, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 39);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(132, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridUsers;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 59);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(236, 418);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// gridUsers
			// 
			this.gridUsers.Compress = false;
			this.gridUsers.DataSource = null;
			this.gridUsers.Editable = true;
			this.gridUsers.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridUsers.Location = new System.Drawing.Point(11, 70);
			this.gridUsers.Name = "gridUsers";
			this.gridUsers.PageFooterCenter = null;
			this.gridUsers.PageFooterLeft = null;
			this.gridUsers.PageFooterRight = null;
			this.gridUsers.PageHeaderCenter = null;
			this.gridUsers.PageHeaderLeft = null;
			this.gridUsers.PageHeaderRight = null;
			this.gridUsers.Pager = null;
			this.gridUsers.PrintFooter = null;
			this.gridUsers.PrintHeader = null;
			this.gridUsers.ReadOnly = false;
			this.gridUsers.ShowGroupPanel = false;
			this.gridUsers.Size = new System.Drawing.Size(232, 414);
			this.gridUsers.TabIndex = 7;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(250, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(7, 491);
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(257, 0);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(729, 491);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridMenus;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(715, 477);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// gridMenus
			// 
			this.gridMenus.Compress = false;
			this.gridMenus.DataSource = null;
			this.gridMenus.Editable = true;
			this.gridMenus.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridMenus.Location = new System.Drawing.Point(268, 11);
			this.gridMenus.Name = "gridMenus";
			this.gridMenus.PageFooterCenter = null;
			this.gridMenus.PageFooterLeft = null;
			this.gridMenus.PageFooterRight = null;
			this.gridMenus.PageHeaderCenter = null;
			this.gridMenus.PageHeaderLeft = null;
			this.gridMenus.PageHeaderRight = null;
			this.gridMenus.Pager = null;
			this.gridMenus.PrintFooter = null;
			this.gridMenus.PrintHeader = null;
			this.gridMenus.ReadOnly = false;
			this.gridMenus.ShowGroupPanel = false;
			this.gridMenus.Size = new System.Drawing.Size(711, 473);
			this.gridMenus.TabIndex = 8;
			// 
			// UserMenusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "UserMenusForm";
			this.Text = "UserMenusForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private JW.AUBE.Core.Controls.Grid.XGrid gridUsers;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private Controls.Grid.XGrid gridMenus;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}