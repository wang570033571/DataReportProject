namespace 框架
{
    partial class 基本操作窗体
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
            this.ts工具栏 = new System.Windows.Forms.ToolStrip();
            this.panel查询 = new System.Windows.Forms.Panel();
            this.panel扩展 = new System.Windows.Forms.Panel();
            this.splitter左 = new System.Windows.Forms.Splitter();
            this.tabControl明细 = new System.Windows.Forms.TabControl();
            this.tabPage基本信息 = new System.Windows.Forms.TabPage();
            this.splitterGrid = new System.Windows.Forms.Splitter();
            this.groupBox扩展 = new System.Windows.Forms.GroupBox();
            this.splitter拓展 = new System.Windows.Forms.Splitter();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt记录数 = new System.Windows.Forms.MaskedTextBox();
            this.lbl记录数 = new System.Windows.Forms.Label();
            this.panel查询.SuspendLayout();
            this.tabControl明细.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ts工具栏
            // 
            this.ts工具栏.Location = new System.Drawing.Point(0, 0);
            this.ts工具栏.Name = "ts工具栏";
            this.ts工具栏.Size = new System.Drawing.Size(787, 25);
            this.ts工具栏.TabIndex = 0;
            this.ts工具栏.Text = "toolStrip1";
            // 
            // panel查询
            // 
            this.panel查询.Controls.Add(this.txt记录数);
            this.panel查询.Controls.Add(this.lbl记录数);
            this.panel查询.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel查询.Location = new System.Drawing.Point(0, 25);
            this.panel查询.Name = "panel查询";
            this.panel查询.Size = new System.Drawing.Size(787, 30);
            this.panel查询.TabIndex = 2;
            // 
            // panel扩展
            // 
            this.panel扩展.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel扩展.Location = new System.Drawing.Point(0, 55);
            this.panel扩展.Name = "panel扩展";
            this.panel扩展.Size = new System.Drawing.Size(0, 384);
            this.panel扩展.TabIndex = 3;
            this.panel扩展.Visible = false;
            // 
            // splitter左
            // 
            this.splitter左.Location = new System.Drawing.Point(0, 55);
            this.splitter左.Name = "splitter左";
            this.splitter左.Size = new System.Drawing.Size(3, 384);
            this.splitter左.TabIndex = 4;
            this.splitter左.TabStop = false;
            // 
            // tabControl明细
            // 
            this.tabControl明细.Controls.Add(this.tabPage基本信息);
            this.tabControl明细.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl明细.Location = new System.Drawing.Point(3, 314);
            this.tabControl明细.Name = "tabControl明细";
            this.tabControl明细.SelectedIndex = 0;
            this.tabControl明细.Size = new System.Drawing.Size(784, 125);
            this.tabControl明细.TabIndex = 8;
            // 
            // tabPage基本信息
            // 
            this.tabPage基本信息.AutoScroll = true;
            this.tabPage基本信息.Location = new System.Drawing.Point(4, 22);
            this.tabPage基本信息.Name = "tabPage基本信息";
            this.tabPage基本信息.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage基本信息.Size = new System.Drawing.Size(776, 99);
            this.tabPage基本信息.TabIndex = 0;
            this.tabPage基本信息.Text = "基本信息";
            this.tabPage基本信息.UseVisualStyleBackColor = true;
            // 
            // splitterGrid
            // 
            this.splitterGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterGrid.Location = new System.Drawing.Point(3, 311);
            this.splitterGrid.Name = "splitterGrid";
            this.splitterGrid.Size = new System.Drawing.Size(784, 1);
            this.splitterGrid.TabIndex = 15;
            this.splitterGrid.TabStop = false;
            this.splitterGrid.Visible = false;
            // 
            // groupBox扩展
            // 
            this.groupBox扩展.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox扩展.Location = new System.Drawing.Point(3, 312);
            this.groupBox扩展.Name = "groupBox扩展";
            this.groupBox扩展.Size = new System.Drawing.Size(784, 1);
            this.groupBox扩展.TabIndex = 14;
            this.groupBox扩展.TabStop = false;
            this.groupBox扩展.Visible = false;
            // 
            // splitter拓展
            // 
            this.splitter拓展.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter拓展.Location = new System.Drawing.Point(3, 313);
            this.splitter拓展.Name = "splitter拓展";
            this.splitter拓展.Size = new System.Drawing.Size(784, 1);
            this.splitter拓展.TabIndex = 13;
            this.splitter拓展.TabStop = false;
            this.splitter拓展.Visible = false;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenu = this.cmData;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 55);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(784, 256);
            this.gridControl.TabIndex = 17;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.IndicatorWidth = 50;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // txt记录数
            // 
            this.txt记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt记录数.HidePromptOnLeave = true;
            this.txt记录数.Location = new System.Drawing.Point(722, 4);
            this.txt记录数.Mask = "99999999999";
            this.txt记录数.Name = "txt记录数";
            this.txt记录数.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt记录数.Size = new System.Drawing.Size(60, 21);
            this.txt记录数.TabIndex = 17;
            this.txt记录数.Text = "1000";
            this.txt记录数.ValidatingType = typeof(int);
            this.txt记录数.Visible = false;
            // 
            // lbl记录数
            // 
            this.lbl记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl记录数.AutoSize = true;
            this.lbl记录数.Location = new System.Drawing.Point(678, 8);
            this.lbl记录数.Name = "lbl记录数";
            this.lbl记录数.Size = new System.Drawing.Size(41, 12);
            this.lbl记录数.TabIndex = 16;
            this.lbl记录数.Text = "记录数";
            this.lbl记录数.Visible = false;
            // 
            // 基本操作窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 439);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.splitterGrid);
            this.Controls.Add(this.groupBox扩展);
            this.Controls.Add(this.splitter拓展);
            this.Controls.Add(this.tabControl明细);
            this.Controls.Add(this.splitter左);
            this.Controls.Add(this.panel扩展);
            this.Controls.Add(this.panel查询);
            this.Controls.Add(this.ts工具栏);
            this.Name = "基本操作窗体";
            this.Text = "基本操作窗体";
            this.panel查询.ResumeLayout(false);
            this.panel查询.PerformLayout();
            this.tabControl明细.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts工具栏;
        public System.Windows.Forms.Panel panel查询;
        public System.Windows.Forms.Panel panel扩展;
        private System.Windows.Forms.Splitter splitter左;
        public System.Windows.Forms.TabControl tabControl明细;
        private System.Windows.Forms.TabPage tabPage基本信息;
        private System.Windows.Forms.Splitter splitterGrid;
        protected System.Windows.Forms.GroupBox groupBox扩展;
        public DevExpress.XtraGrid.GridControl gridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;
        public System.Windows.Forms.Splitter splitter拓展;
        public System.Windows.Forms.MaskedTextBox txt记录数;
        private System.Windows.Forms.Label lbl记录数;
    }
}