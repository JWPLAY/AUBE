namespace JW.AUBE.Core.Controls.Grid
{
    partial class XGrid
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
			this.Grid = new DevExpress.XtraGrid.GridControl();
			this.View = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.SuspendLayout();
			// 
			// Grid
			// 
			this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid.Location = new System.Drawing.Point(0, 0);
			this.Grid.MainView = this.View;
			this.Grid.Name = "Grid";
			this.Grid.Size = new System.Drawing.Size(700, 300);
			this.Grid.TabIndex = 4;
			this.Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View});
			// 
			// View
			// 
			this.View.GridControl = this.Grid;
			this.View.Name = "View";
			// 
			// XGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Grid);
			this.Name = "XGrid";
			this.Size = new System.Drawing.Size(700, 300);
			((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
		private DevExpress.XtraGrid.Views.Grid.GridView View;
		public DevExpress.XtraGrid.GridControl Grid;
	}
}
