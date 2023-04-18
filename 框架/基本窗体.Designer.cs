namespace 框架
{
    partial class 基本窗体
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
            this.cmData = new System.Windows.Forms.ContextMenu();
            this.mi导出到Excel = new System.Windows.Forms.MenuItem();
            this.mi选择数据 = new System.Windows.Forms.MenuItem();
            this.mu全选 = new System.Windows.Forms.MenuItem();
            this.mu相同 = new System.Windows.Forms.MenuItem();
            this.mi保存布局 = new System.Windows.Forms.MenuItem();
            this.mi复制数据 = new System.Windows.Forms.MenuItem();
            this.mi字段配置 = new System.Windows.Forms.MenuItem();
            this.mi字体设置 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // cmData
            // 
            this.cmData.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mi导出到Excel,
            this.mi选择数据,
            this.mi保存布局,
            this.mi复制数据,
            this.mi字段配置,
            this.mi字体设置});
            this.cmData.Popup += new System.EventHandler(this.cmData_Popup);
            // 
            // mi导出到Excel
            // 
            this.mi导出到Excel.Index = 0;
            this.mi导出到Excel.Text = "导出Excel";
            this.mi导出到Excel.Click += new System.EventHandler(this.mi导出到Excel_Click);
            // 
            // mi选择数据
            // 
            this.mi选择数据.Index = 1;
            this.mi选择数据.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mu全选,
            this.mu相同});
            this.mi选择数据.Text = "选择数据";
            // 
            // mu全选
            // 
            this.mu全选.Index = 0;
            this.mu全选.Text = "全选";
            this.mu全选.Click += new System.EventHandler(this.mu全选_Click);
            // 
            // mu相同
            // 
            this.mu相同.Index = 1;
            this.mu相同.Text = "相同";
            this.mu相同.Click += new System.EventHandler(this.mu相同_Click);
            // 
            // mi保存布局
            // 
            this.mi保存布局.Index = 2;
            this.mi保存布局.Text = "保存布局";
            this.mi保存布局.Click += new System.EventHandler(this.mi保存布局_Click);
            // 
            // mi复制数据
            // 
            this.mi复制数据.Index = 3;
            this.mi复制数据.Text = "复制数据";
            this.mi复制数据.Click += new System.EventHandler(this.mi复制数据_Click);
            // 
            // mi字段配置
            // 
            this.mi字段配置.Index = 4;
            this.mi字段配置.Text = "字段配置";
            this.mi字段配置.Click += new System.EventHandler(this.mi字段配置_Click);
            // 
            // mi字体设置
            // 
            this.mi字体设置.Index = 5;
            this.mi字体设置.Text = "字体设置";
            this.mi字体设置.Click += new System.EventHandler(this.mi字体设置_Click);
            // 
            // 基本窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "基本窗体";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基本窗体";
            this.Shown += new System.EventHandler(this.基本窗体_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ContextMenu cmData;
        private System.Windows.Forms.MenuItem mi导出到Excel;
        private System.Windows.Forms.MenuItem mi选择数据;
        private System.Windows.Forms.MenuItem mi保存布局;
        private System.Windows.Forms.MenuItem mi复制数据;
        private System.Windows.Forms.MenuItem mi字段配置;
        private System.Windows.Forms.MenuItem mu全选;
        private System.Windows.Forms.MenuItem mu相同;
        private System.Windows.Forms.MenuItem mi字体设置;
    }
}