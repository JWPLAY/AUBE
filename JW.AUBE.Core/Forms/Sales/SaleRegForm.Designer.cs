﻿namespace JW.AUBE.Core.Forms.Sales
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.esMonSaleAmt = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gridItems = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridItems = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridCategories = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridCategories = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridFindItems = new JW.AUBE.Core.Controls.Grid.XGrid();
			this.lcGridFindItems = new DevExpress.XtraLayout.LayoutControlItem();
			this.esSaleDate = new DevExpress.XtraLayout.EmptySpaceItem();
			this.esSaleTime = new DevExpress.XtraLayout.EmptySpaceItem();
			this.esDaySaleAmt = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupHeader = new DevExpress.XtraLayout.LayoutControlGroup();
			this.txtInput = new DevExpress.XtraEditors.TextEdit();
			this.lcItemInput = new DevExpress.XtraLayout.LayoutControlItem();
			this.spnTotSupAmt = new DevExpress.XtraEditors.SpinEdit();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.spnTotTaxAmt = new DevExpress.XtraEditors.SpinEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.spnTotSumAmt = new DevExpress.XtraEditors.SpinEdit();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupAmount = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupInput = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupItems = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esMonSaleAmt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridCategories)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridFindItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSaleDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSaleTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esDaySaleAmt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupHeader)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotSupAmt.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotTaxAmt.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotSumAmt.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupItems)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.spnTotSumAmt);
			this.lc.Controls.Add(this.spnTotTaxAmt);
			this.lc.Controls.Add(this.spnTotSupAmt);
			this.lc.Controls.Add(this.txtInput);
			this.lc.Controls.Add(this.gridFindItems);
			this.lc.Controls.Add(this.gridCategories);
			this.lc.Controls.Add(this.gridItems);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1090, 184, 450, 400);
			this.lc.Size = new System.Drawing.Size(998, 590);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupHeader,
            this.lcGroupAmount,
            this.lcGroupSearch,
            this.lcGroupInput,
            this.lcGroupItems});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(998, 590);
			// 
			// esMonSaleAmt
			// 
			this.esMonSaleAmt.AllowHotTrack = false;
			this.esMonSaleAmt.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esMonSaleAmt.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.esMonSaleAmt.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkGray;
			this.esMonSaleAmt.AppearanceItemCaption.Options.UseBackColor = true;
			this.esMonSaleAmt.AppearanceItemCaption.Options.UseFont = true;
			this.esMonSaleAmt.AppearanceItemCaption.Options.UseForeColor = true;
			this.esMonSaleAmt.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esMonSaleAmt.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.esMonSaleAmt.Location = new System.Drawing.Point(738, 0);
			this.esMonSaleAmt.Name = "esMonSaleAmt";
			this.esMonSaleAmt.Size = new System.Drawing.Size(246, 40);
			this.esMonSaleAmt.Text = "10,000,000 ";
			this.esMonSaleAmt.TextSize = new System.Drawing.Size(0, 0);
			this.esMonSaleAmt.TextVisible = true;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 72);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(366, 210);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.AppearanceItemCaption.BackColor = System.Drawing.Color.Gainsboro;
			this.emptySpaceItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F);
			this.emptySpaceItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
			this.emptySpaceItem6.AppearanceItemCaption.Options.UseBackColor = true;
			this.emptySpaceItem6.AppearanceItemCaption.Options.UseFont = true;
			this.emptySpaceItem6.AppearanceItemCaption.Options.UseForeColor = true;
			this.emptySpaceItem6.Location = new System.Drawing.Point(200, 36);
			this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 36);
			this.emptySpaceItem6.MinSize = new System.Drawing.Size(10, 36);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(166, 36);
			this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem6.Text = "JW-PLAY";
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			this.emptySpaceItem6.TextVisible = true;
			// 
			// gridItems
			// 
			this.gridItems.Compress = false;
			this.gridItems.DataSource = null;
			this.gridItems.Editable = true;
			this.gridItems.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridItems.Location = new System.Drawing.Point(319, 59);
			this.gridItems.Name = "gridItems";
			this.gridItems.PageFooterCenter = null;
			this.gridItems.PageFooterLeft = null;
			this.gridItems.PageFooterRight = null;
			this.gridItems.PageHeaderCenter = null;
			this.gridItems.PageHeaderLeft = null;
			this.gridItems.PageHeaderRight = null;
			this.gridItems.Pager = null;
			this.gridItems.PrintFooter = null;
			this.gridItems.PrintHeader = null;
			this.gridItems.ReadOnly = false;
			this.gridItems.ShowGroupPanel = false;
			this.gridItems.Size = new System.Drawing.Size(294, 522);
			this.gridItems.TabIndex = 4;
			// 
			// lcGridItems
			// 
			this.lcGridItems.Control = this.gridItems;
			this.lcGridItems.Location = new System.Drawing.Point(0, 0);
			this.lcGridItems.Name = "lcGridItems";
			this.lcGridItems.Size = new System.Drawing.Size(298, 526);
			this.lcGridItems.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridItems.TextVisible = false;
			// 
			// gridCategories
			// 
			this.gridCategories.Compress = false;
			this.gridCategories.DataSource = null;
			this.gridCategories.Editable = true;
			this.gridCategories.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridCategories.Location = new System.Drawing.Point(627, 59);
			this.gridCategories.Name = "gridCategories";
			this.gridCategories.PageFooterCenter = null;
			this.gridCategories.PageFooterLeft = null;
			this.gridCategories.PageFooterRight = null;
			this.gridCategories.PageHeaderCenter = null;
			this.gridCategories.PageHeaderLeft = null;
			this.gridCategories.PageHeaderRight = null;
			this.gridCategories.Pager = null;
			this.gridCategories.PrintFooter = null;
			this.gridCategories.PrintHeader = null;
			this.gridCategories.ReadOnly = false;
			this.gridCategories.ShowGroupPanel = false;
			this.gridCategories.Size = new System.Drawing.Size(184, 230);
			this.gridCategories.TabIndex = 5;
			// 
			// lcGridCategories
			// 
			this.lcGridCategories.Control = this.gridCategories;
			this.lcGridCategories.Location = new System.Drawing.Point(0, 0);
			this.lcGridCategories.Name = "lcGridCategories";
			this.lcGridCategories.Size = new System.Drawing.Size(188, 234);
			this.lcGridCategories.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridCategories.TextVisible = false;
			// 
			// gridFindItems
			// 
			this.gridFindItems.Compress = false;
			this.gridFindItems.DataSource = null;
			this.gridFindItems.Editable = true;
			this.gridFindItems.GridViewType = JW.AUBE.Core.Controls.Grid.GridViewType.GridView;
			this.gridFindItems.Location = new System.Drawing.Point(815, 59);
			this.gridFindItems.Name = "gridFindItems";
			this.gridFindItems.PageFooterCenter = null;
			this.gridFindItems.PageFooterLeft = null;
			this.gridFindItems.PageFooterRight = null;
			this.gridFindItems.PageHeaderCenter = null;
			this.gridFindItems.PageHeaderLeft = null;
			this.gridFindItems.PageHeaderRight = null;
			this.gridFindItems.Pager = null;
			this.gridFindItems.PrintFooter = null;
			this.gridFindItems.PrintHeader = null;
			this.gridFindItems.ReadOnly = false;
			this.gridFindItems.ShowGroupPanel = false;
			this.gridFindItems.Size = new System.Drawing.Size(174, 230);
			this.gridFindItems.TabIndex = 6;
			// 
			// lcGridFindItems
			// 
			this.lcGridFindItems.Control = this.gridFindItems;
			this.lcGridFindItems.Location = new System.Drawing.Point(188, 0);
			this.lcGridFindItems.Name = "lcGridFindItems";
			this.lcGridFindItems.Size = new System.Drawing.Size(178, 234);
			this.lcGridFindItems.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridFindItems.TextVisible = false;
			// 
			// esSaleDate
			// 
			this.esSaleDate.AllowHotTrack = false;
			this.esSaleDate.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esSaleDate.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.esSaleDate.AppearanceItemCaption.Options.UseBackColor = true;
			this.esSaleDate.AppearanceItemCaption.Options.UseFont = true;
			this.esSaleDate.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esSaleDate.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.esSaleDate.Location = new System.Drawing.Point(0, 0);
			this.esSaleDate.MaxSize = new System.Drawing.Size(0, 40);
			this.esSaleDate.MinSize = new System.Drawing.Size(10, 40);
			this.esSaleDate.Name = "esSaleDate";
			this.esSaleDate.Size = new System.Drawing.Size(246, 40);
			this.esSaleDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esSaleDate.Text = "2017-03-08";
			this.esSaleDate.TextSize = new System.Drawing.Size(0, 0);
			this.esSaleDate.TextVisible = true;
			// 
			// esSaleTime
			// 
			this.esSaleTime.AllowHotTrack = false;
			this.esSaleTime.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esSaleTime.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.esSaleTime.AppearanceItemCaption.Options.UseBackColor = true;
			this.esSaleTime.AppearanceItemCaption.Options.UseFont = true;
			this.esSaleTime.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esSaleTime.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.esSaleTime.Location = new System.Drawing.Point(246, 0);
			this.esSaleTime.Name = "esSaleTime";
			this.esSaleTime.Size = new System.Drawing.Size(246, 40);
			this.esSaleTime.Text = "21:39:59";
			this.esSaleTime.TextSize = new System.Drawing.Size(0, 0);
			this.esSaleTime.TextVisible = true;
			// 
			// esDaySaleAmt
			// 
			this.esDaySaleAmt.AllowHotTrack = false;
			this.esDaySaleAmt.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esDaySaleAmt.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.esDaySaleAmt.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkGray;
			this.esDaySaleAmt.AppearanceItemCaption.Options.UseBackColor = true;
			this.esDaySaleAmt.AppearanceItemCaption.Options.UseFont = true;
			this.esDaySaleAmt.AppearanceItemCaption.Options.UseForeColor = true;
			this.esDaySaleAmt.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esDaySaleAmt.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.esDaySaleAmt.Location = new System.Drawing.Point(492, 0);
			this.esDaySaleAmt.Name = "esDaySaleAmt";
			this.esDaySaleAmt.Size = new System.Drawing.Size(246, 40);
			this.esDaySaleAmt.Text = "1,000,000 ";
			this.esDaySaleAmt.TextSize = new System.Drawing.Size(0, 0);
			this.esDaySaleAmt.TextVisible = true;
			// 
			// lcGroupHeader
			// 
			this.lcGroupHeader.AppearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lcGroupHeader.AppearanceGroup.Options.UseBackColor = true;
			this.lcGroupHeader.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esSaleDate,
            this.esSaleTime,
            this.esDaySaleAmt,
            this.esMonSaleAmt});
			this.lcGroupHeader.Location = new System.Drawing.Point(0, 0);
			this.lcGroupHeader.Name = "lcGroupHeader";
			this.lcGroupHeader.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupHeader.Size = new System.Drawing.Size(994, 50);
			this.lcGroupHeader.TextVisible = false;
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(827, 303);
			this.txtInput.Name = "txtInput";
			this.txtInput.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
			this.txtInput.Properties.Appearance.Options.UseFont = true;
			this.txtInput.Size = new System.Drawing.Size(162, 32);
			this.txtInput.StyleController = this.lc;
			this.txtInput.TabIndex = 7;
			// 
			// lcItemInput
			// 
			this.lcItemInput.AppearanceItemCaption.BackColor = System.Drawing.Color.DarkRed;
			this.lcItemInput.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.lcItemInput.AppearanceItemCaption.Options.UseBackColor = true;
			this.lcItemInput.AppearanceItemCaption.Options.UseFont = true;
			this.lcItemInput.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcItemInput.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcItemInput.Control = this.txtInput;
			this.lcItemInput.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.lcItemInput.Location = new System.Drawing.Point(0, 0);
			this.lcItemInput.MaxSize = new System.Drawing.Size(0, 36);
			this.lcItemInput.MinSize = new System.Drawing.Size(126, 36);
			this.lcItemInput.Name = "lcItemInput";
			this.lcItemInput.Size = new System.Drawing.Size(366, 36);
			this.lcItemInput.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemInput.Text = "상품등록  ";
			this.lcItemInput.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
			this.lcItemInput.TextSize = new System.Drawing.Size(200, 24);
			this.lcItemInput.TextToControlDistance = 0;
			// 
			// spnTotSupAmt
			// 
			this.spnTotSupAmt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spnTotSupAmt.Location = new System.Drawing.Point(129, 59);
			this.spnTotSupAmt.Name = "spnTotSupAmt";
			this.spnTotSupAmt.Properties.Appearance.BackColor = System.Drawing.Color.Black;
			this.spnTotSupAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.spnTotSupAmt.Properties.Appearance.ForeColor = System.Drawing.Color.White;
			this.spnTotSupAmt.Properties.Appearance.Options.UseBackColor = true;
			this.spnTotSupAmt.Properties.Appearance.Options.UseFont = true;
			this.spnTotSupAmt.Properties.Appearance.Options.UseForeColor = true;
			this.spnTotSupAmt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
			this.spnTotSupAmt.Size = new System.Drawing.Size(176, 30);
			this.spnTotSupAmt.StyleController = this.lc;
			this.spnTotSupAmt.TabIndex = 8;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
			this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
			this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
			this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.layoutControlItem2.Control = this.spnTotSupAmt;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 34);
			this.layoutControlItem2.MinSize = new System.Drawing.Size(122, 34);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(300, 34);
			this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem2.Text = "공급가액 ";
			this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(120, 22);
			this.layoutControlItem2.TextToControlDistance = 0;
			// 
			// spnTotTaxAmt
			// 
			this.spnTotTaxAmt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spnTotTaxAmt.Location = new System.Drawing.Point(129, 93);
			this.spnTotTaxAmt.Name = "spnTotTaxAmt";
			this.spnTotTaxAmt.Properties.Appearance.BackColor = System.Drawing.Color.Black;
			this.spnTotTaxAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.spnTotTaxAmt.Properties.Appearance.ForeColor = System.Drawing.Color.White;
			this.spnTotTaxAmt.Properties.Appearance.Options.UseBackColor = true;
			this.spnTotTaxAmt.Properties.Appearance.Options.UseFont = true;
			this.spnTotTaxAmt.Properties.Appearance.Options.UseForeColor = true;
			this.spnTotTaxAmt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
			this.spnTotTaxAmt.Size = new System.Drawing.Size(176, 30);
			this.spnTotTaxAmt.StyleController = this.lc;
			this.spnTotTaxAmt.TabIndex = 9;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.layoutControlItem3.AppearanceItemCaption.Options.UseBackColor = true;
			this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
			this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
			this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.layoutControlItem3.Control = this.spnTotTaxAmt;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(300, 34);
			this.layoutControlItem3.Text = "부가세액 ";
			this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(120, 22);
			this.layoutControlItem3.TextToControlDistance = 0;
			// 
			// spnTotSumAmt
			// 
			this.spnTotSumAmt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spnTotSumAmt.Location = new System.Drawing.Point(129, 127);
			this.spnTotSumAmt.Name = "spnTotSumAmt";
			this.spnTotSumAmt.Properties.Appearance.BackColor = System.Drawing.Color.Black;
			this.spnTotSumAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.spnTotSumAmt.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow;
			this.spnTotSumAmt.Properties.Appearance.Options.UseBackColor = true;
			this.spnTotSumAmt.Properties.Appearance.Options.UseFont = true;
			this.spnTotSumAmt.Properties.Appearance.Options.UseForeColor = true;
			this.spnTotSumAmt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
			this.spnTotSumAmt.Size = new System.Drawing.Size(176, 30);
			this.spnTotSumAmt.StyleController = this.lc;
			this.spnTotSumAmt.TabIndex = 10;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Yellow;
			this.layoutControlItem4.AppearanceItemCaption.Options.UseBackColor = true;
			this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
			this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
			this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.layoutControlItem4.Control = this.spnTotSumAmt;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 68);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(300, 458);
			this.layoutControlItem4.Text = "합계금액 ";
			this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
			this.layoutControlItem4.TextSize = new System.Drawing.Size(120, 22);
			this.layoutControlItem4.TextToControlDistance = 0;
			// 
			// lcGroupAmount
			// 
			this.lcGroupAmount.AppearanceGroup.BackColor = System.Drawing.Color.Black;
			this.lcGroupAmount.AppearanceGroup.Options.UseBackColor = true;
			this.lcGroupAmount.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.lcGroupAmount.AppearanceItemCaption.Options.UseBackColor = true;
			this.lcGroupAmount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
			this.lcGroupAmount.Location = new System.Drawing.Point(0, 50);
			this.lcGroupAmount.Name = "lcGroupAmount";
			this.lcGroupAmount.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupAmount.Size = new System.Drawing.Size(310, 536);
			this.lcGroupAmount.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridCategories,
            this.lcGridFindItems});
			this.lcGroupSearch.Location = new System.Drawing.Point(618, 50);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSearch.Size = new System.Drawing.Size(376, 244);
			this.lcGroupSearch.TextVisible = false;
			// 
			// lcGroupInput
			// 
			this.lcGroupInput.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemInput,
            this.emptySpaceItem6,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
			this.lcGroupInput.Location = new System.Drawing.Point(618, 294);
			this.lcGroupInput.Name = "lcGroupInput";
			this.lcGroupInput.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupInput.Size = new System.Drawing.Size(376, 292);
			this.lcGroupInput.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Maroon;
			this.emptySpaceItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseBackColor = true;
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseFont = true;
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
			this.emptySpaceItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 36);
			this.emptySpaceItem1.MaxSize = new System.Drawing.Size(200, 0);
			this.emptySpaceItem1.MinSize = new System.Drawing.Size(200, 10);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(200, 36);
			this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem1.Text = "거래처 ";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			this.emptySpaceItem1.TextVisible = true;
			// 
			// lcGroupItems
			// 
			this.lcGroupItems.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridItems});
			this.lcGroupItems.Location = new System.Drawing.Point(310, 50);
			this.lcGroupItems.Name = "lcGroupItems";
			this.lcGroupItems.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupItems.Size = new System.Drawing.Size(308, 536);
			this.lcGroupItems.TextVisible = false;
			// 
			// SaleRegForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 618);
			this.Name = "SaleRegForm";
			this.Text = "SaleRegForm";
			this.VisibleToolbar = false;
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esMonSaleAmt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridItems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridCategories)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridFindItems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSaleDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSaleTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esDaySaleAmt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupHeader)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotSupAmt.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotTaxAmt.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTotSumAmt.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.EmptySpaceItem esMonSaleAmt;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
		private Controls.Grid.XGrid gridFindItems;
		private Controls.Grid.XGrid gridCategories;
		private Controls.Grid.XGrid gridItems;
		private DevExpress.XtraLayout.LayoutControlItem lcGridItems;
		private DevExpress.XtraLayout.LayoutControlItem lcGridCategories;
		private DevExpress.XtraLayout.LayoutControlItem lcGridFindItems;
		private DevExpress.XtraLayout.EmptySpaceItem esSaleDate;
		private DevExpress.XtraLayout.EmptySpaceItem esSaleTime;
		private DevExpress.XtraLayout.EmptySpaceItem esDaySaleAmt;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupHeader;
		private DevExpress.XtraEditors.TextEdit txtInput;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInput;
		private DevExpress.XtraEditors.SpinEdit spnTotSumAmt;
		private DevExpress.XtraEditors.SpinEdit spnTotTaxAmt;
		private DevExpress.XtraEditors.SpinEdit spnTotSupAmt;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupAmount;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupInput;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupItems;
	}
}