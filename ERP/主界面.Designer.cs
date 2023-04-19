namespace ERP
{
    partial class 主界面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(主界面));
            this.mmu主菜单 = new System.Windows.Forms.MenuStrip();
            this.ssData = new System.Windows.Forms.StatusStrip();
            this.lbl服务器 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl服务器 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl操作员 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl操作员 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl时间 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl时间 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl内存占用 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl内存占用 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer();
            this.tm1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.cm菜单页 = new System.Windows.Forms.ContextMenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nf1 = new System.Windows.Forms.NotifyIcon();
            this.cmnf = new System.Windows.Forms.ContextMenuStrip();
            this.主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tm1)).BeginInit();
            this.cm菜单页.SuspendLayout();
            this.cmnf.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmu主菜单
            // 
            this.mmu主菜单.Location = new System.Drawing.Point(0, 0);
            this.mmu主菜单.Name = "mmu主菜单";
            this.mmu主菜单.Size = new System.Drawing.Size(861, 24);
            this.mmu主菜单.TabIndex = 1;
            // 
            // ssData
            // 
            this.ssData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl服务器,
            this.sslbl服务器,
            this.lbl操作员,
            this.sslbl操作员,
            this.lbl时间,
            this.sslbl时间,
            this.lbl内存占用,
            this.sslbl内存占用,
            this.toolStripStatusLabel1});
            this.ssData.Location = new System.Drawing.Point(0, 466);
            this.ssData.Name = "ssData";
            this.ssData.Size = new System.Drawing.Size(861, 26);
            this.ssData.TabIndex = 3;
            // 
            // lbl服务器
            // 
            this.lbl服务器.Name = "lbl服务器";
            this.lbl服务器.Size = new System.Drawing.Size(47, 21);
            this.lbl服务器.Text = "服务器:";
            // 
            // sslbl服务器
            // 
            this.sslbl服务器.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslbl服务器.Name = "sslbl服务器";
            this.sslbl服务器.Size = new System.Drawing.Size(39, 21);
            this.sslbl服务器.Text = "local";
            // 
            // lbl操作员
            // 
            this.lbl操作员.Name = "lbl操作员";
            this.lbl操作员.Size = new System.Drawing.Size(47, 21);
            this.lbl操作员.Text = "操作员:";
            // 
            // sslbl操作员
            // 
            this.sslbl操作员.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslbl操作员.Name = "sslbl操作员";
            this.sslbl操作员.Size = new System.Drawing.Size(44, 21);
            this.sslbl操作员.Text = "None";
            // 
            // lbl时间
            // 
            this.lbl时间.Name = "lbl时间";
            this.lbl时间.Size = new System.Drawing.Size(59, 21);
            this.lbl时间.Text = "登陆时间:";
            // 
            // sslbl时间
            // 
            this.sslbl时间.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslbl时间.Name = "sslbl时间";
            this.sslbl时间.Size = new System.Drawing.Size(44, 21);
            this.sslbl时间.Text = "None";
            // 
            // lbl内存占用
            // 
            this.lbl内存占用.Name = "lbl内存占用";
            this.lbl内存占用.Size = new System.Drawing.Size(59, 21);
            this.lbl内存占用.Text = "内存占用:";
            // 
            // sslbl内存占用
            // 
            this.sslbl内存占用.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslbl内存占用.Name = "sslbl内存占用";
            this.sslbl内存占用.Size = new System.Drawing.Size(31, 21);
            this.sslbl内存占用.Text = "1M";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 21);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tm1
            // 
            this.tm1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.tm1.MdiParent = this;
            this.tm1.SelectedPageChanged += new System.EventHandler(this.tm1_SelectedPageChanged);
            this.tm1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tm1_MouseDown);
            this.tm1.SetNextMdiChild += new DevExpress.XtraTabbedMdi.SetNextMdiChildEventHandler(this.tm1_SetNextMdiChild);
            // 
            // cm菜单页
            // 
            this.cm菜单页.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem,
            this.关闭其他ToolStripMenuItem,
            this.关闭全部ToolStripMenuItem});
            this.cm菜单页.Name = "contextMenuPage";
            this.cm菜单页.Size = new System.Drawing.Size(125, 70);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 关闭其他ToolStripMenuItem
            // 
            this.关闭其他ToolStripMenuItem.Name = "关闭其他ToolStripMenuItem";
            this.关闭其他ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭其他ToolStripMenuItem.Text = "关闭其他";
            this.关闭其他ToolStripMenuItem.Click += new System.EventHandler(this.关闭其他ToolStripMenuItem_Click);
            // 
            // 关闭全部ToolStripMenuItem
            // 
            this.关闭全部ToolStripMenuItem.Name = "关闭全部ToolStripMenuItem";
            this.关闭全部ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭全部ToolStripMenuItem.Text = "关闭全部";
            this.关闭全部ToolStripMenuItem.Click += new System.EventHandler(this.关闭全部ToolStripMenuItem_Click);
            // 
            // nf1
            // 
            this.nf1.ContextMenuStrip = this.cmnf;
            this.nf1.Icon = ((System.Drawing.Icon)(resources.GetObject("nf1.Icon")));
            this.nf1.Text = "Report";
            this.nf1.Visible = true;
            this.nf1.DoubleClick += new System.EventHandler(this.nf1_DoubleClick);
            // 
            // cmnf
            // 
            this.cmnf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主界面ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.cmnf.Name = "cmnf";
            this.cmnf.Size = new System.Drawing.Size(113, 48);
            // 
            // 主界面ToolStripMenuItem
            // 
            this.主界面ToolStripMenuItem.Name = "主界面ToolStripMenuItem";
            this.主界面ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.主界面ToolStripMenuItem.Text = "主界面";
            this.主界面ToolStripMenuItem.Click += new System.EventHandler(this.主界面ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 主界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(861, 492);
            this.Controls.Add(this.ssData);
            this.Controls.Add(this.mmu主菜单);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mmu主菜单;
            this.Name = "主界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表管理系统_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.主界面_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.主界面_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ssData.ResumeLayout(false);
            this.ssData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tm1)).EndInit();
            this.cm菜单页.ResumeLayout(false);
            this.cmnf.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mmu主菜单;
        private System.Windows.Forms.StatusStrip ssData;
        private System.Windows.Forms.ToolStripStatusLabel sslbl操作员;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel lbl服务器;
        private System.Windows.Forms.ToolStripStatusLabel lbl操作员;
        private System.Windows.Forms.ToolStripStatusLabel lbl时间;
        private System.Windows.Forms.ToolStripStatusLabel sslbl时间;
        private System.Windows.Forms.ToolStripStatusLabel lbl内存占用;
        private System.Windows.Forms.ToolStripStatusLabel sslbl内存占用;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tm1;
        private System.Windows.Forms.ContextMenuStrip cm菜单页;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭全部ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon nf1;
        private System.Windows.Forms.ContextMenuStrip cmnf;
        private System.Windows.Forms.ToolStripMenuItem 主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel sslbl服务器;

    }
}

