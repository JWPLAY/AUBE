namespace JW.AUBE.Core.Forms.Sales
{
	partial class SaleRegForm
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
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupList = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupItem = new DevExpress.XtraLayout.LayoutControlGroup();
			this.gridList = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupListButtons = new DevExpress.XtraLayout.LayoutControlGroup();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupListButtons)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.simpleButton3);
			this.lc.Controls.Add(this.textEdit1);
			this.lc.Controls.Add(this.simpleButton2);
			this.lc.Controls.Add(this.simpleButton1);
			this.lc.Controls.Add(this.gridList);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Size = new System.Drawing.Size(1012, 418);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupList,
            this.lcGroupItem});
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(1012, 418);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(204, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(280, 27);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcGroupList
			// 
			this.lcGroupList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lcGroupListButtons});
			this.lcGroupList.Location = new System.Drawing.Point(0, 0);
			this.lcGroupList.Name = "lcGroupList";
			this.lcGroupList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupList.Size = new System.Drawing.Size(504, 414);
			this.lcGroupList.TextVisible = false;
			// 
			// lcGroupItem
			// 
			this.lcGroupItem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
			this.lcGroupItem.Location = new System.Drawing.Point(504, 0);
			this.lcGroupItem.Name = "lcGroupItem";
			this.lcGroupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupItem.Size = new System.Drawing.Size(504, 414);
			this.lcGroupItem.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
			this.gridList.Appearance.Options.UseFont = true;
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(9, 46);
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
			this.gridList.Size = new System.Drawing.Size(490, 363);
			this.gridList.TabIndex = 4;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridList;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 37);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(494, 367);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// lcGroupListButtons
			// 
			this.lcGroupListButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
			this.lcGroupListButtons.Location = new System.Drawing.Point(0, 0);
			this.lcGroupListButtons.Name = "lcGroupListButtons";
			this.lcGroupListButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupListButtons.Size = new System.Drawing.Size(494, 37);
			this.lcGroupListButtons.TextVisible = false;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
			this.simpleButton1.Appearance.Options.UseFont = true;
			this.simpleButton1.Location = new System.Drawing.Point(14, 14);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(98, 23);
			this.simpleButton1.StyleController = this.lc;
			this.simpleButton1.TabIndex = 5;
			this.simpleButton1.Text = "simpleButton1";
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.simpleButton1;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(102, 27);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
			this.simpleButton2.Appearance.Options.UseFont = true;
			this.simpleButton2.Location = new System.Drawing.Point(116, 14);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(98, 23);
			this.simpleButton2.StyleController = this.lc;
			this.simpleButton2.TabIndex = 6;
			this.simpleButton2.Text = "simpleButton2";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.simpleButton2;
			this.layoutControlItem3.Location = new System.Drawing.Point(102, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(102, 27);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(0, 34);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(494, 370);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// textEdit1
			// 
			this.textEdit1.Location = new System.Drawing.Point(622, 9);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
			this.textEdit1.Properties.Appearance.Options.UseFont = true;
			this.textEdit1.Size = new System.Drawing.Size(134, 30);
			this.textEdit1.StyleController = this.lc;
			this.textEdit1.TabIndex = 7;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.textEdit1;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(247, 34);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(105, 14);
			// 
			// simpleButton3
			// 
			this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
			this.simpleButton3.Appearance.Options.UseFont = true;
			this.simpleButton3.Location = new System.Drawing.Point(760, 9);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new System.Drawing.Size(243, 29);
			this.simpleButton3.StyleController = this.lc;
			this.simpleButton3.TabIndex = 8;
			this.simpleButton3.Text = "simpleButton3";
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.simpleButton3;
			this.layoutControlItem5.Location = new System.Drawing.Point(247, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(247, 34);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// SaleRegForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 484);
			this.Name = "SaleRegForm";
			this.Text = "SaleRegForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupListButtons)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupItem;
		private Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupListButtons;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
	}
}