namespace JW.AUBE.Core.Controls.Common
{
	partial class XSearch
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.txtCodeName = new DevExpress.XtraEditors.ButtonEdit();
			this.txtCodeId = new DevExpress.XtraEditors.TextEdit();
			this.splitter = new DevExpress.XtraEditors.SplitterControl();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeId.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtCodeName
			// 
			this.txtCodeName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCodeName.Location = new System.Drawing.Point(0, 0);
			this.txtCodeName.Margin = new System.Windows.Forms.Padding(0);
			this.txtCodeName.Name = "txtCodeName";
			this.txtCodeName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Delete", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)), serializableAppearanceObject2, "Delete", null, null, true)});
			this.txtCodeName.Size = new System.Drawing.Size(300, 20);
			this.txtCodeName.TabIndex = 2;
			// 
			// txtCodeId
			// 
			this.txtCodeId.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtCodeId.Location = new System.Drawing.Point(305, 0);
			this.txtCodeId.Margin = new System.Windows.Forms.Padding(0);
			this.txtCodeId.Name = "txtCodeId";
			this.txtCodeId.Properties.AllowFocused = false;
			this.txtCodeId.Size = new System.Drawing.Size(95, 20);
			this.txtCodeId.TabIndex = 1;
			this.txtCodeId.TabStop = false;
			// 
			// splitter
			// 
			this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter.Location = new System.Drawing.Point(300, 0);
			this.splitter.Margin = new System.Windows.Forms.Padding(0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(5, 20);
			this.splitter.TabIndex = 0;
			this.splitter.TabStop = false;
			// 
			// XSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtCodeName);
			this.Controls.Add(this.splitter);
			this.Controls.Add(this.txtCodeId);
			this.Name = "XSearch";
			this.Size = new System.Drawing.Size(400, 20);
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeId.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private DevExpress.XtraEditors.TextEdit txtCodeId;
		private DevExpress.XtraEditors.ButtonEdit txtCodeName;
		private DevExpress.XtraEditors.SplitterControl splitter;
	}
}
