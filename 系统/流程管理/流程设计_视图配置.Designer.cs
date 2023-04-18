namespace 系统
{
    partial class 流程设计_视图配置
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
            this.gc表头 = new DevExpress.XtraGrid.GridControl();
            this.gv表头 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc表体 = new DevExpress.XtraGrid.GridControl();
            this.gv表体 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc表头)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv表头)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc表体)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv表体)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gc表体);
            this.panel1.Controls.Add(this.gc表头);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(747, 450);
            // 
            // gc表头
            // 
            this.gc表头.ContextMenu = this.cmData;
            this.gc表头.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc表头.Location = new System.Drawing.Point(0, 0);
            this.gc表头.MainView = this.gv表头;
            this.gc表头.Name = "gc表头";
            this.gc表头.Size = new System.Drawing.Size(747, 450);
            this.gc表头.TabIndex = 0;
            this.gc表头.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv表头,
            this.gridView2});
            // 
            // gv表头
            // 
            this.gv表头.GridControl = this.gc表头;
            this.gv表头.IndicatorWidth = 50;
            this.gv表头.Name = "gv表头";
            this.gv表头.OptionsSelection.MultiSelect = true;
            this.gv表头.OptionsView.ColumnAutoWidth = false;
            this.gv表头.OptionsView.RowAutoHeight = true;
            this.gv表头.OptionsView.ShowFooter = true;
            this.gv表头.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gc表头;
            this.gridView2.Name = "gridView2";
            // 
            // gc表体
            // 
            this.gc表体.ContextMenu = this.cmData;
            this.gc表体.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gc表体.Location = new System.Drawing.Point(0, 260);
            this.gc表体.MainView = this.gv表体;
            this.gc表体.Name = "gc表体";
            this.gc表体.Size = new System.Drawing.Size(747, 190);
            this.gc表体.TabIndex = 1;
            this.gc表体.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv表体});
            // 
            // gv表体
            // 
            this.gv表体.GridControl = this.gc表体;
            this.gv表体.IndicatorWidth = 50;
            this.gv表体.Name = "gv表体";
            this.gv表体.OptionsSelection.MultiSelect = true;
            this.gv表体.OptionsView.ColumnAutoWidth = false;
            this.gv表体.OptionsView.RowAutoHeight = true;
            this.gv表体.OptionsView.ShowFooter = true;
            this.gv表体.OptionsView.ShowGroupPanel = false;
            // 
            // 流程设计_视图配置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 490);
            this.Name = "流程设计_视图配置";
            this.Text = "流程设计_视图配置";
            this.Shown += new System.EventHandler(this.流程设计_视图配置_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc表头)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv表头)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc表体)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv表体)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc表头;
        private DevExpress.XtraGrid.Views.Grid.GridView gv表头;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gc表体;
        private DevExpress.XtraGrid.Views.Grid.GridView gv表体;
    }
}