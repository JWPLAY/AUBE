namespace JW.AUBE
{
    partial class PasswordForm
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
			this.TextEdit3 = new DevExpress.XtraEditors.TextEdit();
			this.TextEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.TextEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemPwd1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemPwd2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemPwd3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonConfirm = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TextEdit3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonConfirm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.AllowCustomization = false;
			this.lc.Controls.Add(this.btnConfirm);
			this.lc.Controls.Add(this.TextEdit3);
			this.lc.Controls.Add(this.TextEdit2);
			this.lc.Controls.Add(this.TextEdit1);
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 0);
			this.lc.Name = "lc";
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(572, 173, 596, 350);
			this.lc.Root = this.lcGroupBase;
			this.lc.Size = new System.Drawing.Size(392, 270);
			this.lc.TabIndex = 0;
			// 
			// TextEdit3
			// 
			this.TextEdit3.Location = new System.Drawing.Point(80, 138);
			this.TextEdit3.Name = "TextEdit3";
			this.TextEdit3.Size = new System.Drawing.Size(300, 20);
			this.TextEdit3.StyleController = this.lc;
			this.TextEdit3.TabIndex = 6;
			// 
			// TextEdit2
			// 
			this.TextEdit2.Location = new System.Drawing.Point(80, 114);
			this.TextEdit2.Name = "TextEdit2";
			this.TextEdit2.Size = new System.Drawing.Size(300, 20);
			this.TextEdit2.StyleController = this.lc;
			this.TextEdit2.TabIndex = 5;
			// 
			// TextEdit1
			// 
			this.TextEdit1.Location = new System.Drawing.Point(80, 90);
			this.TextEdit1.Name = "TextEdit1";
			this.TextEdit1.Size = new System.Drawing.Size(300, 20);
			this.TextEdit1.StyleController = this.lc;
			this.TextEdit1.TabIndex = 4;
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.BackgroundImage = global::JW.AUBE.Properties.Resources.back_white;
			this.lcGroupBase.BackgroundImageVisible = true;
			this.lcGroupBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.lcGroupBase.GroupBordersVisible = false;
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemPwd1,
            this.lcItemPwd2,
            this.lcItemPwd3,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.lcButtonConfirm,
            this.emptySpaceItem5,
            this.emptySpaceItem6});
			this.lcGroupBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Size = new System.Drawing.Size(392, 270);
			this.lcGroupBase.TextVisible = false;
			// 
			// lcItemPwd1
			// 
			this.lcItemPwd1.Control = this.TextEdit1;
			this.lcItemPwd1.Location = new System.Drawing.Point(0, 78);
			this.lcItemPwd1.Name = "lcItemPwd1";
			this.lcItemPwd1.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd1.TextSize = new System.Drawing.Size(65, 14);
			// 
			// lcItemPwd2
			// 
			this.lcItemPwd2.Control = this.TextEdit2;
			this.lcItemPwd2.Location = new System.Drawing.Point(0, 102);
			this.lcItemPwd2.Name = "lcItemPwd2";
			this.lcItemPwd2.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd2.TextSize = new System.Drawing.Size(65, 14);
			// 
			// lcItemPwd3
			// 
			this.lcItemPwd3.Control = this.TextEdit3;
			this.lcItemPwd3.Location = new System.Drawing.Point(0, 126);
			this.lcItemPwd3.Name = "lcItemPwd3";
			this.lcItemPwd3.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd3.TextSize = new System.Drawing.Size(65, 14);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 240);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(372, 10);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(372, 78);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(0, 150);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(372, 64);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(105, 226);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(182, 22);
			this.btnConfirm.StyleController = this.lc;
			this.btnConfirm.TabIndex = 0;
			this.btnConfirm.TabStop = false;
			this.btnConfirm.Text = "확인";
			// 
			// lcButtonConfirm
			// 
			this.lcButtonConfirm.Control = this.btnConfirm;
			this.lcButtonConfirm.Location = new System.Drawing.Point(93, 214);
			this.lcButtonConfirm.Name = "lcButtonConfirm";
			this.lcButtonConfirm.Size = new System.Drawing.Size(186, 26);
			this.lcButtonConfirm.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonConfirm.TextVisible = false;
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(0, 214);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(93, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(279, 214);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(93, 26);
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// PasswordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 270);
			this.Controls.Add(this.lc);
			this.Name = "PasswordForm";
			this.Text = "PasswordForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TextEdit3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPwd3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonConfirm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit TextEdit3;
        private DevExpress.XtraEditors.TextEdit TextEdit2;
        private DevExpress.XtraEditors.TextEdit TextEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lcItemPwd1;
        private DevExpress.XtraLayout.LayoutControlItem lcItemPwd2;
        private DevExpress.XtraLayout.LayoutControlItem lcItemPwd3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		public DevExpress.XtraLayout.LayoutControl lc;
		public DevExpress.XtraLayout.LayoutControlGroup lcGroupBase;
		private DevExpress.XtraEditors.SimpleButton btnConfirm;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonConfirm;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
	}
}