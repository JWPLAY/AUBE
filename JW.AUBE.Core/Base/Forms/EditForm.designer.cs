namespace JW.AUBE.Core.Base.Forms
{
    partial class EditForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
			this.barManager = new DevExpress.XtraBars.BarManager();
			this.barTools = new DevExpress.XtraBars.Bar();
			this.barButtonRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonSave = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonCancel = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonExport = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonPrint = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonHelp = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonClose = new DevExpress.XtraBars.BarButtonItem();
			this.barTitle = new DevExpress.XtraBars.BarStaticItem();
			this.barStatus = new DevExpress.XtraBars.Bar();
			this.barStaticMessage = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticTotalRecords = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticEditMode = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticViewName = new DevExpress.XtraBars.BarStaticItem();
			this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barStaticItemBlank = new DevExpress.XtraBars.BarStaticItem();
			this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
			this.lc = new DevExpress.XtraLayout.LayoutControl();
			this.lcGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			this.SuspendLayout();
			// 
			// barManager
			// 
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools,
            this.barStatus});
			this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("EditToolbar", new System.Guid("f9353982-6a5e-40af-a175-0d23da100202")),
            new DevExpress.XtraBars.BarManagerCategory("BaseToolbar", new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a")),
            new DevExpress.XtraBars.BarManagerCategory("Statusbar", new System.Guid("5ec799ad-04c4-4dc1-b808-b4da40b4d58e"))});
			this.barManager.Controller = this.barAndDockingController;
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticMessage,
            this.barButtonRefresh,
            this.barButtonNew,
            this.barButtonSave,
            this.barButtonSaveAndNew,
            this.barButtonSaveAndClose,
            this.barButtonDelete,
            this.barButtonCancel,
            this.barButtonExport,
            this.barButtonPrint,
            this.barButtonHelp,
            this.barButtonClose,
            this.barStaticEditMode,
            this.barStaticTotalRecords,
            this.barStaticViewName,
            this.barStaticItemBlank,
            this.barHeaderItem1,
            this.barTitle});
			this.barManager.MaxItemId = 24;
			this.barManager.StatusBar = this.barStatus;
			// 
			// barTools
			// 
			this.barTools.BarName = "Tools";
			this.barTools.DockCol = 0;
			this.barTools.DockRow = 0;
			this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonSaveAndNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonSaveAndClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonCancel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonHelp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barTitle)});
			this.barTools.OptionsBar.AllowQuickCustomization = false;
			this.barTools.OptionsBar.DrawBorder = false;
			this.barTools.OptionsBar.DrawDragBorder = false;
			this.barTools.OptionsBar.UseWholeRow = true;
			this.barTools.Text = "Tools";
			// 
			// barButtonRefresh
			// 
			this.barButtonRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonRefresh.Caption = "Refresh";
			this.barButtonRefresh.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barButtonRefresh.Id = 11;
			this.barButtonRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonRefresh.ImageOptions.Image")));
			this.barButtonRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonRefresh.ImageOptions.LargeImage")));
			this.barButtonRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
			this.barButtonRefresh.Name = "barButtonRefresh";
			this.barButtonRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			// 
			// barButtonNew
			// 
			this.barButtonNew.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonNew.Caption = "New";
			this.barButtonNew.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonNew.Id = 1;
			this.barButtonNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonNew.ImageOptions.Image")));
			this.barButtonNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonNew.ImageOptions.LargeImage")));
			this.barButtonNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
			this.barButtonNew.Name = "barButtonNew";
			this.barButtonNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			// 
			// barButtonSave
			// 
			this.barButtonSave.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonSave.Caption = "Save";
			this.barButtonSave.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonSave.Id = 2;
			this.barButtonSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonSave.ImageOptions.Image")));
			this.barButtonSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonSave.ImageOptions.LargeImage")));
			this.barButtonSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
			this.barButtonSave.Name = "barButtonSave";
			this.barButtonSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			// 
			// barButtonSaveAndNew
			// 
			this.barButtonSaveAndNew.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonSaveAndNew.Caption = "Save and new";
			this.barButtonSaveAndNew.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonSaveAndNew.Id = 3;
			this.barButtonSaveAndNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAndNew.ImageOptions.Image")));
			this.barButtonSaveAndNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAndNew.ImageOptions.LargeImage")));
			this.barButtonSaveAndNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
			this.barButtonSaveAndNew.Name = "barButtonSaveAndNew";
			// 
			// barButtonSaveAndClose
			// 
			this.barButtonSaveAndClose.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonSaveAndClose.Caption = "Save and close";
			this.barButtonSaveAndClose.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonSaveAndClose.Id = 4;
			this.barButtonSaveAndClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAndClose.ImageOptions.Image")));
			this.barButtonSaveAndClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAndClose.ImageOptions.LargeImage")));
			this.barButtonSaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
			this.barButtonSaveAndClose.Name = "barButtonSaveAndClose";
			// 
			// barButtonDelete
			// 
			this.barButtonDelete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonDelete.Caption = "Delete";
			this.barButtonDelete.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonDelete.Id = 5;
			this.barButtonDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonDelete.ImageOptions.Image")));
			this.barButtonDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonDelete.ImageOptions.LargeImage")));
			this.barButtonDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
			this.barButtonDelete.Name = "barButtonDelete";
			// 
			// barButtonCancel
			// 
			this.barButtonCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonCancel.Caption = "Cancel";
			this.barButtonCancel.CategoryGuid = new System.Guid("f9353982-6a5e-40af-a175-0d23da100202");
			this.barButtonCancel.Id = 7;
			this.barButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonCancel.ImageOptions.Image")));
			this.barButtonCancel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonCancel.ImageOptions.LargeImage")));
			this.barButtonCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F10);
			this.barButtonCancel.Name = "barButtonCancel";
			// 
			// barButtonExport
			// 
			this.barButtonExport.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonExport.Caption = "Export";
			this.barButtonExport.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barButtonExport.Id = 8;
			this.barButtonExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonExport.ImageOptions.Image")));
			this.barButtonExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonExport.ImageOptions.LargeImage")));
			this.barButtonExport.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F11);
			this.barButtonExport.Name = "barButtonExport";
			// 
			// barButtonPrint
			// 
			this.barButtonPrint.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonPrint.Caption = "Print";
			this.barButtonPrint.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barButtonPrint.Id = 9;
			this.barButtonPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonPrint.ImageOptions.Image")));
			this.barButtonPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonPrint.ImageOptions.LargeImage")));
			this.barButtonPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
			this.barButtonPrint.Name = "barButtonPrint";
			// 
			// barButtonHelp
			// 
			this.barButtonHelp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonHelp.Caption = "Help";
			this.barButtonHelp.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barButtonHelp.Id = 19;
			this.barButtonHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonHelp.ImageOptions.Image")));
			this.barButtonHelp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonHelp.ImageOptions.LargeImage")));
			this.barButtonHelp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
			this.barButtonHelp.Name = "barButtonHelp";
			// 
			// barButtonClose
			// 
			this.barButtonClose.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barButtonClose.Caption = "Close";
			this.barButtonClose.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barButtonClose.Id = 10;
			this.barButtonClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonClose.ImageOptions.Image")));
			this.barButtonClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonClose.ImageOptions.LargeImage")));
			this.barButtonClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
			this.barButtonClose.Name = "barButtonClose";
			// 
			// barTitle
			// 
			this.barTitle.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
			this.barTitle.Caption = "barStaticItem1";
			this.barTitle.Id = 23;
			this.barTitle.ItemAppearance.Normal.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.barTitle.ItemAppearance.Normal.Options.UseFont = true;
			this.barTitle.Name = "barTitle";
			this.barTitle.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barStatus
			// 
			this.barStatus.BarName = "Status bar";
			this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.barStatus.DockCol = 0;
			this.barStatus.DockRow = 0;
			this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticTotalRecords),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticEditMode),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticViewName)});
			this.barStatus.OptionsBar.AllowQuickCustomization = false;
			this.barStatus.OptionsBar.DrawDragBorder = false;
			this.barStatus.OptionsBar.UseWholeRow = true;
			this.barStatus.Text = "Status bar";
			// 
			// barStaticMessage
			// 
			this.barStaticMessage.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
			this.barStaticMessage.Caption = "Message";
			this.barStaticMessage.CategoryGuid = new System.Guid("5ec799ad-04c4-4dc1-b808-b4da40b4d58e");
			this.barStaticMessage.Id = 0;
			this.barStaticMessage.Name = "barStaticMessage";
			this.barStaticMessage.Size = new System.Drawing.Size(32, 0);
			this.barStaticMessage.TextAlignment = System.Drawing.StringAlignment.Near;
			this.barStaticMessage.Width = 32;
			// 
			// barStaticTotalRecords
			// 
			this.barStaticTotalRecords.Caption = "TotalRecords";
			this.barStaticTotalRecords.CategoryGuid = new System.Guid("5ec799ad-04c4-4dc1-b808-b4da40b4d58e");
			this.barStaticTotalRecords.Id = 15;
			this.barStaticTotalRecords.Name = "barStaticTotalRecords";
			this.barStaticTotalRecords.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barStaticEditMode
			// 
			this.barStaticEditMode.Caption = "EditMode";
			this.barStaticEditMode.CategoryGuid = new System.Guid("5ec799ad-04c4-4dc1-b808-b4da40b4d58e");
			this.barStaticEditMode.Id = 14;
			this.barStaticEditMode.Name = "barStaticEditMode";
			this.barStaticEditMode.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barStaticViewName
			// 
			this.barStaticViewName.Caption = "ViewName";
			this.barStaticViewName.CategoryGuid = new System.Guid("5ec799ad-04c4-4dc1-b808-b4da40b4d58e");
			this.barStaticViewName.Id = 16;
			this.barStaticViewName.Name = "barStaticViewName";
			this.barStaticViewName.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barAndDockingController
			// 
			this.barAndDockingController.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
			this.barAndDockingController.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager;
			this.barDockControlTop.Size = new System.Drawing.Size(998, 44);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 455);
			this.barDockControlBottom.Manager = this.barManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(998, 22);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
			this.barDockControlLeft.Manager = this.barManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 411);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(998, 44);
			this.barDockControlRight.Manager = this.barManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 411);
			// 
			// barStaticItemBlank
			// 
			this.barStaticItemBlank.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barStaticItemBlank.Caption = "...";
			this.barStaticItemBlank.CategoryGuid = new System.Guid("dc5db40c-8502-47c0-9ffc-98d280c2c66a");
			this.barStaticItemBlank.Id = 21;
			this.barStaticItemBlank.Name = "barStaticItemBlank";
			this.barStaticItemBlank.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barHeaderItem1
			// 
			this.barHeaderItem1.Caption = "barHeaderItem1";
			this.barHeaderItem1.Id = 22;
			this.barHeaderItem1.Name = "barHeaderItem1";
			// 
			// lc
			// 
			this.lc.AllowCustomization = false;
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Name = "lc";
			this.lc.Root = this.lcGroupBase;
			this.lc.Size = new System.Drawing.Size(998, 411);
			this.lc.TabIndex = 4;
			this.lc.Text = "lc";
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.lcGroupBase.GroupBordersVisible = false;
			this.lcGroupBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupBase.Name = "lcGroupBase";
			this.lcGroupBase.Size = new System.Drawing.Size(998, 411);
			this.lcGroupBase.TextVisible = false;
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 477);
			this.Controls.Add(this.lc);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "EditForm";
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticMessage;
        private DevExpress.XtraBars.BarButtonItem barButtonNew;
        private DevExpress.XtraBars.BarButtonItem barButtonSave;
        private DevExpress.XtraBars.BarButtonItem barButtonSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem barButtonSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem barButtonRefresh;
        private DevExpress.XtraBars.BarButtonItem barButtonDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonCancel;
        private DevExpress.XtraBars.BarButtonItem barButtonExport;
        private DevExpress.XtraBars.BarButtonItem barButtonPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonClose;
        private DevExpress.XtraBars.BarStaticItem barStaticEditMode;
        private DevExpress.XtraBars.BarStaticItem barStaticTotalRecords;
        private DevExpress.XtraBars.BarStaticItem barStaticViewName;
		public DevExpress.XtraLayout.LayoutControl lc;
		public DevExpress.XtraLayout.LayoutControlGroup lcGroupBase;
		private DevExpress.XtraBars.BarButtonItem barButtonHelp;
		private DevExpress.XtraBars.BarStaticItem barStaticItemBlank;
		private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
		private DevExpress.XtraBars.BarStaticItem barTitle;
		private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
	}
}
