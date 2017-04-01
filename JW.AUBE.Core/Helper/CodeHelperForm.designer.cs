namespace JW.AUBE.Core.Helper
{
	partial class CodeHelperForm
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
			this.lupUseYn = new JW.AUBE.Core.Controls.Common.XLookup();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemUseYn = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lupUseYn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.AllowCustomization = false;
			this.lc.Controls.Add(this.lupUseYn);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Controls.Add(this.gridList);
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 0);
			this.lc.Name = "lc";
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(540, 254, 250, 350);
			this.lc.Root = this.layoutControlGroup1;
			this.lc.Size = new System.Drawing.Size(492, 452);
			this.lc.TabIndex = 0;
			this.lc.Text = "xLayout1";
			// 
			// lupUseYn
			// 
			this.lupUseYn.DataSource = null;
			this.lupUseYn.DisplayMember = "";
			this.lupUseYn.GroupCode = null;
			this.lupUseYn.ListMember = "LIST_NAME";
			this.lupUseYn.Location = new System.Drawing.Point(104, 43);
			this.lupUseYn.Name = "lupUseYn";
			this.lupUseYn.NullText = "[EditValue is null]";
			this.lupUseYn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lupUseYn.SelectedIndex = -1;
			this.lupUseYn.Size = new System.Drawing.Size(140, 20);
			this.lupUseYn.StyleController = this.lc;
			this.lupUseYn.TabIndex = 6;
			this.lupUseYn.ValueMember = "";
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 19);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(369, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 5;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(12, 74);
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
			this.gridList.Size = new System.Drawing.Size(468, 366);
			this.gridList.TabIndex = 4;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.BackgroundImage = global::JW.AUBE.Core.Properties.Resources.back_gray;
			this.layoutControlGroup1.BackgroundImageVisible = true;
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(492, 452);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.BackgroundImage = global::JW.AUBE.Core.Properties.Resources.back_gray;
			this.lcGroupSearch.BackgroundImageVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemUseYn,
            this.emptySpaceItem1});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(472, 62);
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
			this.lcItemUseYn.Control = this.lupUseYn;
			this.lcItemUseYn.Location = new System.Drawing.Point(0, 24);
			this.lcItemUseYn.Name = "lcItemUseYn";
			this.lcItemUseYn.Size = new System.Drawing.Size(229, 24);
			this.lcItemUseYn.TextSize = new System.Drawing.Size(82, 14);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(229, 24);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(229, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridList;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 62);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(472, 370);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// CodeHelperForm
			// 
			this.Appearance.Options.UseFont = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 452);
			this.Controls.Add(this.lc);
			this.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "CodeHelperForm";
			this.Text = "CodeHelperForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lupUseYn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl lc;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private Controls.Common.XLookup lupUseYn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUseYn;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}