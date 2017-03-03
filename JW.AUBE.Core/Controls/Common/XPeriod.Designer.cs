namespace JW.AUBE.Core.Controls.Common
{
	partial class XPeriod
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
			this.lbl = new System.Windows.Forms.Label();
			this.datDateTo = new DevExpress.XtraEditors.DateEdit();
			this.datDateFr = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.datDateTo.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateFr.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateFr.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl
			// 
			this.lbl.AutoSize = true;
			this.lbl.Location = new System.Drawing.Point(103, 3);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(15, 14);
			this.lbl.TabIndex = 1;
			this.lbl.Text = "--";
			// 
			// datDateTo
			// 
			this.datDateTo.EditValue = null;
			this.datDateTo.Location = new System.Drawing.Point(120, 0);
			this.datDateTo.Name = "datDateTo";
			this.datDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
			this.datDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.datDateTo.Size = new System.Drawing.Size(100, 20);
			this.datDateTo.TabIndex = 2;
			// 
			// datDateFr
			// 
			this.datDateFr.EditValue = null;
			this.datDateFr.Location = new System.Drawing.Point(0, 0);
			this.datDateFr.Name = "datDateFr";
			this.datDateFr.Properties.AllowMouseWheel = false;
			this.datDateFr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
			this.datDateFr.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datDateFr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.datDateFr.Properties.ShowWeekNumbers = true;
			this.datDateFr.Size = new System.Drawing.Size(100, 20);
			this.datDateFr.TabIndex = 0;
			// 
			// XPeriod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.datDateTo);
			this.Controls.Add(this.lbl);
			this.Controls.Add(this.datDateFr);
			this.Name = "XPeriod";
			this.Size = new System.Drawing.Size(220, 20);
			((System.ComponentModel.ISupportInitialize)(this.datDateTo.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateFr.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datDateFr.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.DateEdit datDateFr;
		private System.Windows.Forms.Label lbl;
		private DevExpress.XtraEditors.DateEdit datDateTo;

	}
}
