namespace 框架
{
    partial class 选择数据
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(选择数据));
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb查询 = new System.Windows.Forms.ToolStripButton();
            this.tsb确认 = new System.Windows.Forms.ToolStripButton();
            this.tsb更多查询 = new System.Windows.Forms.ToolStripButton();
            this.tsb关闭 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 35);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(632, 28);
            this.gbTop.TabIndex = 0;
            this.gbTop.TabStop = false;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 63);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(632, 468);
            this.gc.TabIndex = 1;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb查询,
            this.tsb确认,
            this.tsb更多查询,
            this.tsb关闭});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb查询
            // 
            this.tsb查询.Image = ((System.Drawing.Image)(resources.GetObject("tsb查询.Image")));
            this.tsb查询.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb查询.Name = "tsb查询";
            this.tsb查询.Size = new System.Drawing.Size(33, 32);
            this.tsb查询.Text = "查询";
            this.tsb查询.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb确认
            // 
            this.tsb确认.Image = ((System.Drawing.Image)(resources.GetObject("tsb确认.Image")));
            this.tsb确认.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb确认.Name = "tsb确认";
            this.tsb确认.Size = new System.Drawing.Size(33, 32);
            this.tsb确认.Text = "确认";
            this.tsb确认.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb更多查询
            // 
            this.tsb更多查询.Image = ((System.Drawing.Image)(resources.GetObject("tsb更多查询.Image")));
            this.tsb更多查询.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb更多查询.Name = "tsb更多查询";
            this.tsb更多查询.Size = new System.Drawing.Size(57, 32);
            this.tsb更多查询.Text = "更多查询";
            this.tsb更多查询.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb关闭
            // 
            this.tsb关闭.Image = ((System.Drawing.Image)(resources.GetObject("tsb关闭.Image")));
            this.tsb关闭.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb关闭.Name = "tsb关闭";
            this.tsb关闭.Size = new System.Drawing.Size(33, 32);
            this.tsb关闭.Text = "关闭";
            this.tsb关闭.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 选择数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 531);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "选择数据";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择数据";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTop;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb查询;
        private System.Windows.Forms.ToolStripButton tsb确认;
        private System.Windows.Forms.ToolStripButton tsb关闭;
        private System.Windows.Forms.ToolStripButton tsb更多查询;
    }
}