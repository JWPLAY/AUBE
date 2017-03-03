namespace JW.AUBE.Core.Base.Forms
{
	partial class CodeHelpForm
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
			this.lc = new DevExpress.XtraLayout.LayoutControl();
			this.chkUseYn = new DevExpress.XtraEditors.CheckEdit();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.xGrid = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemUseYn = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chkUseYn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.AllowCustomization = false;
			this.lc.Controls.Add(this.chkUseYn);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Controls.Add(this.xGrid);
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 0);
			this.lc.Name = "lc";
			this.lc.Root = this.layoutControlGroup1;
			this.lc.Size = new System.Drawing.Size(492, 452);
			this.lc.TabIndex = 0;
			this.lc.Text = "xLayout1";
			// 
			// chkUseYn
			// 
			this.chkUseYn.EditValue = "N";
			this.chkUseYn.Location = new System.Drawing.Point(104, 43);
			this.chkUseYn.Name = "chkUseYn";
			this.chkUseYn.Properties.AutoWidth = true;
			this.chkUseYn.Properties.Caption = "(현재 사용중인 코드만 조회합니다.)";
			this.chkUseYn.Properties.ValueChecked = "Y";
			this.chkUseYn.Properties.ValueUnchecked = "N";
			this.chkUseYn.Size = new System.Drawing.Size(188, 19);
			this.chkUseYn.StyleController = this.lc;
			this.chkUseYn.TabIndex = 6;
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 19);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(369, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 5;
			// 
			// xGrid
			// 
			this.xGrid.Compress = false;
			this.xGrid.DataSource = null;
			this.xGrid.Editable = true;
			this.xGrid.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.xGrid.Location = new System.Drawing.Point(12, 73);
			this.xGrid.Name = "xGrid";
			this.xGrid.PageFooterCenter = null;
			this.xGrid.PageFooterLeft = null;
			this.xGrid.PageFooterRight = null;
			this.xGrid.PageHeaderCenter = null;
			this.xGrid.PageHeaderLeft = null;
			this.xGrid.PageHeaderRight = null;
			this.xGrid.Pager = null;
			this.xGrid.PrintFooter = null;
			this.xGrid.PrintHeader = null;
			this.xGrid.ReadOnly = false;
			this.xGrid.ShowGroupPanel = false;
			this.xGrid.Size = new System.Drawing.Size(468, 367);
			this.xGrid.TabIndex = 4;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(492, 452);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemUseYn});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(472, 61);
			this.lcGroupSearch.TextVisible = false;
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(458, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// lcItemUseYn
			// 
			this.lcItemUseYn.Control = this.chkUseYn;
			this.lcItemUseYn.Location = new System.Drawing.Point(0, 24);
			this.lcItemUseYn.Name = "lcItemUseYn";
			this.lcItemUseYn.Size = new System.Drawing.Size(458, 23);
			this.lcItemUseYn.TextSize = new System.Drawing.Size(82, 14);
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.xGrid;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 61);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(472, 371);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// CodeHelpForm
			// 
			this.Appearance.Options.UseFont = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 452);
			this.Controls.Add(this.lc);
			this.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "CodeHelpForm";
			this.Text = "CodeHelpForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chkUseYn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl lc;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private Controls.Grid.XGrid xGrid;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private DevExpress.XtraEditors.CheckEdit chkUseYn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUseYn;
	}
}