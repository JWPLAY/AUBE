namespace JW.AUBE.Core.Controls
{
    partial class XPager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XPager));
            this.lc = new DevExpress.XtraLayout.LayoutControl();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextBlock = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.spnTotalPages = new DevExpress.XtraEditors.SpinEdit();
            this.spnPageNo = new DevExpress.XtraEditors.SpinEdit();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevBlock = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.lupPageSize = new JW.AUBE.Core.Controls.Common.XLookup();
            this.lcGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemPageSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonFirst = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonBlockPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonPagePrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemPageNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcItemTotalPages = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonNext = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonNextBlock = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcButtonLast = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
            this.lc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalPages.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPageNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPageSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemPageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonBlockPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonPagePrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemPageNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTotalPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonNextBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lc
            // 
            this.lc.Controls.Add(this.btnLast);
            this.lc.Controls.Add(this.btnNextBlock);
            this.lc.Controls.Add(this.btnNext);
            this.lc.Controls.Add(this.spnTotalPages);
            this.lc.Controls.Add(this.spnPageNo);
            this.lc.Controls.Add(this.btnPrev);
            this.lc.Controls.Add(this.btnPrevBlock);
            this.lc.Controls.Add(this.btnFirst);
            this.lc.Controls.Add(this.lupPageSize);
            this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc.Location = new System.Drawing.Point(0, 0);
            this.lc.Name = "lc";
            this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 182, 1240, 535);
            this.lc.Root = this.lcGroupBase;
            this.lc.Size = new System.Drawing.Size(888, 26);
            this.lc.TabIndex = 0;
            this.lc.Text = "lc";
            // 
            // btnLast
            // 
            this.btnLast.AutoWidthInLayoutControl = true;
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLast.Location = new System.Drawing.Point(597, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(46, 20);
            this.btnLast.StyleController = this.lc;
            this.btnLast.TabIndex = 12;
            this.btnLast.ToolTip = "Last Page";
            this.btnLast.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnNextBlock
            // 
            this.btnNextBlock.AutoWidthInLayoutControl = true;
            this.btnNextBlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNextBlock.Image = ((System.Drawing.Image)(resources.GetObject("btnNextBlock.Image")));
            this.btnNextBlock.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNextBlock.Location = new System.Drawing.Point(547, 3);
            this.btnNextBlock.Name = "btnNextBlock";
            this.btnNextBlock.Size = new System.Drawing.Size(46, 20);
            this.btnNextBlock.StyleController = this.lc;
            this.btnNextBlock.TabIndex = 11;
            this.btnNextBlock.ToolTip = "Block Next";
            this.btnNextBlock.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnNext
            // 
            this.btnNext.AutoWidthInLayoutControl = true;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNext.Location = new System.Drawing.Point(497, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(46, 20);
            this.btnNext.StyleController = this.lc;
            this.btnNext.TabIndex = 10;
            this.btnNext.ToolTip = "Next";
            this.btnNext.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // spnTotalPages
            // 
            this.spnTotalPages.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnTotalPages.Location = new System.Drawing.Point(418, 3);
            this.spnTotalPages.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.spnTotalPages.Name = "spnTotalPages";
            this.spnTotalPages.Properties.AllowFocused = false;
            this.spnTotalPages.Properties.AllowMouseWheel = false;
            this.spnTotalPages.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnTotalPages.Size = new System.Drawing.Size(75, 20);
            this.spnTotalPages.StyleController = this.lc;
            this.spnTotalPages.TabIndex = 0;
            this.spnTotalPages.TabStop = false;
            // 
            // spnPageNo
            // 
            this.spnPageNo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnPageNo.Location = new System.Drawing.Point(329, 3);
            this.spnPageNo.Name = "spnPageNo";
            this.spnPageNo.Properties.AllowMouseWheel = false;
            this.spnPageNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnPageNo.Size = new System.Drawing.Size(55, 20);
            this.spnPageNo.StyleController = this.lc;
            this.spnPageNo.TabIndex = 8;
            // 
            // btnPrev
            // 
            this.btnPrev.AutoWidthInLayoutControl = true;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrev.Location = new System.Drawing.Point(279, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(46, 20);
            this.btnPrev.StyleController = this.lc;
            this.btnPrev.TabIndex = 7;
            this.btnPrev.ToolTip = "Previous";
            this.btnPrev.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnPrevBlock
            // 
            this.btnPrevBlock.AutoWidthInLayoutControl = true;
            this.btnPrevBlock.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevBlock.Image")));
            this.btnPrevBlock.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrevBlock.Location = new System.Drawing.Point(230, 3);
            this.btnPrevBlock.Name = "btnPrevBlock";
            this.btnPrevBlock.Size = new System.Drawing.Size(45, 20);
            this.btnPrevBlock.StyleController = this.lc;
            this.btnPrevBlock.TabIndex = 6;
            this.btnPrevBlock.ToolTip = "Block Previous";
            this.btnPrevBlock.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnFirst
            // 
            this.btnFirst.AutoWidthInLayoutControl = true;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFirst.Location = new System.Drawing.Point(181, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(45, 20);
            this.btnFirst.StyleController = this.lc;
            this.btnFirst.TabIndex = 5;
            this.btnFirst.ToolTip = "First Page";
            this.btnFirst.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lupPageSize
            // 
            this.lupPageSize.DataSource = null;
            this.lupPageSize.DisplayMember = "";
            this.lupPageSize.Location = new System.Drawing.Point(60, 3);
            this.lupPageSize.Name = "lupPageSize";
            this.lupPageSize.NullText = "[EditValue is null]";
            this.lupPageSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPageSize.SelectedIndex = -1;
            this.lupPageSize.Size = new System.Drawing.Size(117, 20);
            this.lupPageSize.StyleController = this.lc;
            this.lupPageSize.TabIndex = 4;
            this.lupPageSize.ValueMember = "";
            // 
            // lcGroupBase
            // 
            this.lcGroupBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcGroupBase.GroupBordersVisible = false;
            this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemPageSize,
            this.lcButtonFirst,
            this.lcButtonBlockPrev,
            this.lcButtonPagePrev,
            this.lcItemPageNo,
            this.emptySpaceItem2,
            this.lcItemTotalPages,
            this.lcButtonNext,
            this.lcButtonNextBlock,
            this.lcButtonLast,
            this.emptySpaceItem1});
            this.lcGroupBase.Location = new System.Drawing.Point(0, 0);
            this.lcGroupBase.Name = "Root";
            this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.lcGroupBase.Size = new System.Drawing.Size(888, 26);
            this.lcGroupBase.TextVisible = false;
            // 
            // lcItemPageSize
            // 
            this.lcItemPageSize.Control = this.lupPageSize;
            this.lcItemPageSize.Location = new System.Drawing.Point(0, 0);
            this.lcItemPageSize.MaxSize = new System.Drawing.Size(178, 24);
            this.lcItemPageSize.MinSize = new System.Drawing.Size(178, 24);
            this.lcItemPageSize.Name = "lcItemPageSize";
            this.lcItemPageSize.Size = new System.Drawing.Size(178, 24);
            this.lcItemPageSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcItemPageSize.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.lcItemPageSize.Text = "페이지크기";
            this.lcItemPageSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lcItemPageSize.TextSize = new System.Drawing.Size(50, 14);
            this.lcItemPageSize.TextToControlDistance = 5;
            // 
            // lcButtonFirst
            // 
            this.lcButtonFirst.Control = this.btnFirst;
            this.lcButtonFirst.Location = new System.Drawing.Point(178, 0);
            this.lcButtonFirst.MaxSize = new System.Drawing.Size(49, 24);
            this.lcButtonFirst.MinSize = new System.Drawing.Size(49, 24);
            this.lcButtonFirst.Name = "lcButtonFirst";
            this.lcButtonFirst.Size = new System.Drawing.Size(49, 24);
            this.lcButtonFirst.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonFirst.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonFirst.TextVisible = false;
            // 
            // lcButtonBlockPrev
            // 
            this.lcButtonBlockPrev.Control = this.btnPrevBlock;
            this.lcButtonBlockPrev.Location = new System.Drawing.Point(227, 0);
            this.lcButtonBlockPrev.MaxSize = new System.Drawing.Size(49, 24);
            this.lcButtonBlockPrev.MinSize = new System.Drawing.Size(49, 24);
            this.lcButtonBlockPrev.Name = "lcButtonBlockPrev";
            this.lcButtonBlockPrev.Size = new System.Drawing.Size(49, 24);
            this.lcButtonBlockPrev.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonBlockPrev.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonBlockPrev.TextVisible = false;
            // 
            // lcButtonPagePrev
            // 
            this.lcButtonPagePrev.Control = this.btnPrev;
            this.lcButtonPagePrev.Location = new System.Drawing.Point(276, 0);
            this.lcButtonPagePrev.MaxSize = new System.Drawing.Size(50, 24);
            this.lcButtonPagePrev.MinSize = new System.Drawing.Size(50, 24);
            this.lcButtonPagePrev.Name = "lcButtonPagePrev";
            this.lcButtonPagePrev.Size = new System.Drawing.Size(50, 24);
            this.lcButtonPagePrev.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonPagePrev.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonPagePrev.TextVisible = false;
            // 
            // lcItemPageNo
            // 
            this.lcItemPageNo.Control = this.spnPageNo;
            this.lcItemPageNo.Location = new System.Drawing.Point(326, 0);
            this.lcItemPageNo.MaxSize = new System.Drawing.Size(59, 24);
            this.lcItemPageNo.MinSize = new System.Drawing.Size(59, 24);
            this.lcItemPageNo.Name = "lcItemPageNo";
            this.lcItemPageNo.Size = new System.Drawing.Size(59, 24);
            this.lcItemPageNo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcItemPageNo.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemPageNo.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.emptySpaceItem2.Location = new System.Drawing.Point(385, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(30, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(30, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(30, 24);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "of";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem2.TextVisible = true;
            // 
            // lcItemTotalPages
            // 
            this.lcItemTotalPages.Control = this.spnTotalPages;
            this.lcItemTotalPages.Location = new System.Drawing.Point(415, 0);
            this.lcItemTotalPages.MaxSize = new System.Drawing.Size(79, 24);
            this.lcItemTotalPages.MinSize = new System.Drawing.Size(79, 24);
            this.lcItemTotalPages.Name = "lcItemTotalPages";
            this.lcItemTotalPages.Size = new System.Drawing.Size(79, 24);
            this.lcItemTotalPages.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcItemTotalPages.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemTotalPages.TextVisible = false;
            // 
            // lcButtonNext
            // 
            this.lcButtonNext.Control = this.btnNext;
            this.lcButtonNext.Location = new System.Drawing.Point(494, 0);
            this.lcButtonNext.MaxSize = new System.Drawing.Size(50, 24);
            this.lcButtonNext.MinSize = new System.Drawing.Size(50, 24);
            this.lcButtonNext.Name = "lcButtonNext";
            this.lcButtonNext.Size = new System.Drawing.Size(50, 24);
            this.lcButtonNext.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonNext.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonNext.TextVisible = false;
            // 
            // lcButtonNextBlock
            // 
            this.lcButtonNextBlock.Control = this.btnNextBlock;
            this.lcButtonNextBlock.Location = new System.Drawing.Point(544, 0);
            this.lcButtonNextBlock.MaxSize = new System.Drawing.Size(50, 24);
            this.lcButtonNextBlock.MinSize = new System.Drawing.Size(50, 24);
            this.lcButtonNextBlock.Name = "lcButtonNextBlock";
            this.lcButtonNextBlock.Size = new System.Drawing.Size(50, 24);
            this.lcButtonNextBlock.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonNextBlock.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonNextBlock.TextVisible = false;
            // 
            // lcButtonLast
            // 
            this.lcButtonLast.Control = this.btnLast;
            this.lcButtonLast.Location = new System.Drawing.Point(594, 0);
            this.lcButtonLast.MaxSize = new System.Drawing.Size(50, 24);
            this.lcButtonLast.MinSize = new System.Drawing.Size(50, 24);
            this.lcButtonLast.Name = "lcButtonLast";
            this.lcButtonLast.Size = new System.Drawing.Size(50, 24);
            this.lcButtonLast.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcButtonLast.TextSize = new System.Drawing.Size(0, 0);
            this.lcButtonLast.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(644, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(242, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UxPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lc);
            this.Name = "XPager";
            this.Size = new System.Drawing.Size(888, 26);
            ((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
            this.lc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalPages.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPageNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPageSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemPageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonBlockPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonPagePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemPageNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTotalPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonNextBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcButtonLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lc;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupBase;
        private Controls.Common.XLookup lupPageSize;
        private DevExpress.XtraLayout.LayoutControlItem lcItemPageSize;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private  DevExpress.XtraEditors.SimpleButton btnPrevBlock;
        private  DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonFirst;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonBlockPrev;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonPagePrev;
        private  DevExpress.XtraEditors.SimpleButton btnLast;
        private  DevExpress.XtraEditors.SimpleButton btnNextBlock;
        private  DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SpinEdit spnTotalPages;
        private DevExpress.XtraEditors.SpinEdit spnPageNo;
        private DevExpress.XtraLayout.LayoutControlItem lcItemPageNo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lcItemTotalPages;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonNext;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonNextBlock;
        private DevExpress.XtraLayout.LayoutControlItem lcButtonLast;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
