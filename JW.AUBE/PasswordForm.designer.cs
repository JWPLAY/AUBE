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
			this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
			this.txtChkPwd = new DevExpress.XtraEditors.TextEdit();
			this.txtChgPwd = new DevExpress.XtraEditors.TextEdit();
			this.txtCurPwd = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemPwd1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemPwd2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemPwd3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcButtonConfirm = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
			this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtChkPwd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtChgPwd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurPwd.Properties)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.AllowCustomization = false;
			this.lc.Controls.Add(this.btnConfirm);
			this.lc.Controls.Add(this.txtChkPwd);
			this.lc.Controls.Add(this.txtChgPwd);
			this.lc.Controls.Add(this.txtCurPwd);
			this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lc.Location = new System.Drawing.Point(0, 0);
			this.lc.Name = "lc";
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(572, 173, 596, 350);
			this.lc.Root = this.lcGroupBase;
			this.lc.Size = new System.Drawing.Size(392, 270);
			this.lc.TabIndex = 0;
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(162, 222);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(68, 22);
			this.btnConfirm.StyleController = this.lc;
			this.btnConfirm.TabIndex = 0;
			this.btnConfirm.TabStop = false;
			this.btnConfirm.Text = "확인";
			// 
			// txtChkPwd
			// 
			this.txtChkPwd.Location = new System.Drawing.Point(80, 175);
			this.txtChkPwd.Name = "txtChkPwd";
			this.txtChkPwd.Properties.PasswordChar = '*';
			this.txtChkPwd.Size = new System.Drawing.Size(300, 20);
			this.txtChkPwd.StyleController = this.lc;
			this.txtChkPwd.TabIndex = 6;
			// 
			// txtChgPwd
			// 
			this.txtChgPwd.Location = new System.Drawing.Point(80, 151);
			this.txtChgPwd.Name = "txtChgPwd";
			this.txtChgPwd.Properties.PasswordChar = '*';
			this.txtChgPwd.Size = new System.Drawing.Size(300, 20);
			this.txtChgPwd.StyleController = this.lc;
			this.txtChgPwd.TabIndex = 5;
			// 
			// txtCurPwd
			// 
			this.txtCurPwd.Location = new System.Drawing.Point(80, 127);
			this.txtCurPwd.Name = "txtCurPwd";
			this.txtCurPwd.Properties.PasswordChar = '*';
			this.txtCurPwd.Size = new System.Drawing.Size(300, 20);
			this.txtCurPwd.StyleController = this.lc;
			this.txtCurPwd.TabIndex = 4;
			// 
			// lcGroupBase
			// 
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
            this.emptySpaceItem6,
            this.simpleSeparator1,
            this.simpleSeparator2});
			this.lcGroupBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Size = new System.Drawing.Size(392, 270);
			this.lcGroupBase.TextVisible = false;
			// 
			// lcItemPwd1
			// 
			this.lcItemPwd1.Control = this.txtCurPwd;
			this.lcItemPwd1.Location = new System.Drawing.Point(0, 115);
			this.lcItemPwd1.Name = "lcItemPwd1";
			this.lcItemPwd1.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd1.TextSize = new System.Drawing.Size(65, 14);
			// 
			// lcItemPwd2
			// 
			this.lcItemPwd2.Control = this.txtChgPwd;
			this.lcItemPwd2.Location = new System.Drawing.Point(0, 139);
			this.lcItemPwd2.Name = "lcItemPwd2";
			this.lcItemPwd2.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd2.TextSize = new System.Drawing.Size(65, 14);
			// 
			// lcItemPwd3
			// 
			this.lcItemPwd3.Control = this.txtChkPwd;
			this.lcItemPwd3.Location = new System.Drawing.Point(0, 163);
			this.lcItemPwd3.Name = "lcItemPwd3";
			this.lcItemPwd3.Size = new System.Drawing.Size(372, 24);
			this.lcItemPwd3.TextSize = new System.Drawing.Size(65, 14);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 236);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(372, 14);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(372, 114);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(0, 188);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(372, 22);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcButtonConfirm
			// 
			this.lcButtonConfirm.Control = this.btnConfirm;
			this.lcButtonConfirm.Location = new System.Drawing.Point(150, 210);
			this.lcButtonConfirm.Name = "lcButtonConfirm";
			this.lcButtonConfirm.Size = new System.Drawing.Size(72, 26);
			this.lcButtonConfirm.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonConfirm.TextVisible = false;
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(0, 210);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(150, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(222, 210);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(150, 26);
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// simpleSeparator1
			// 
			this.simpleSeparator1.AllowHotTrack = false;
			this.simpleSeparator1.Location = new System.Drawing.Point(0, 114);
			this.simpleSeparator1.Name = "simpleSeparator1";
			this.simpleSeparator1.Size = new System.Drawing.Size(372, 1);
			// 
			// simpleSeparator2
			// 
			this.simpleSeparator2.AllowHotTrack = false;
			this.simpleSeparator2.Location = new System.Drawing.Point(0, 187);
			this.simpleSeparator2.Name = "simpleSeparator2";
			this.simpleSeparator2.Size = new System.Drawing.Size(372, 1);
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
			((System.ComponentModel.ISupportInitialize)(this.txtChkPwd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtChgPwd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurPwd.Properties)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtChkPwd;
        private DevExpress.XtraEditors.TextEdit txtChgPwd;
        private DevExpress.XtraEditors.TextEdit txtCurPwd;
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
		private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
		private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
	}
}