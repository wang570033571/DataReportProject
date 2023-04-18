namespace 系统
{
    partial class 菜单维护
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
            this.tv1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tp菜单 = new System.Windows.Forms.TabPage();
            this.gc菜单 = new DevExpress.XtraGrid.GridControl();
            this.gv菜单 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tp按钮 = new System.Windows.Forms.TabPage();
            this.gc按钮 = new DevExpress.XtraGrid.GridControl();
            this.gv按钮 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tp字段 = new System.Windows.Forms.TabPage();
            this.gc字段 = new DevExpress.XtraGrid.GridControl();
            this.gv字段 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tc1.SuspendLayout();
            this.tp菜单.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc菜单)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv菜单)).BeginInit();
            this.tp按钮.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc按钮)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv按钮)).BeginInit();
            this.tp字段.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc字段)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv字段)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(459, 34);
            this.panel1.Visible = false;
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv1.Location = new System.Drawing.Point(0, 74);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(145, 241);
            this.tv1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(145, 74);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 241);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tp菜单);
            this.tc1.Controls.Add(this.tp按钮);
            this.tc1.Controls.Add(this.tp字段);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.Location = new System.Drawing.Point(148, 74);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(311, 241);
            this.tc1.TabIndex = 5;
            // 
            // tp菜单
            // 
            this.tp菜单.Controls.Add(this.gc菜单);
            this.tp菜单.Location = new System.Drawing.Point(4, 22);
            this.tp菜单.Name = "tp菜单";
            this.tp菜单.Padding = new System.Windows.Forms.Padding(3);
            this.tp菜单.Size = new System.Drawing.Size(303, 215);
            this.tp菜单.TabIndex = 0;
            this.tp菜单.Text = "菜单";
            // 
            // gc菜单
            // 
            this.gc菜单.ContextMenu = this.cmData;
            this.gc菜单.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc菜单.Location = new System.Drawing.Point(3, 3);
            this.gc菜单.MainView = this.gv菜单;
            this.gc菜单.Name = "gc菜单";
            this.gc菜单.Size = new System.Drawing.Size(297, 209);
            this.gc菜单.TabIndex = 0;
            this.gc菜单.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv菜单});
            // 
            // gv菜单
            // 
            this.gv菜单.GridControl = this.gc菜单;
            this.gv菜单.IndicatorWidth = 50;
            this.gv菜单.Name = "gv菜单";
            this.gv菜单.OptionsSelection.MultiSelect = true;
            this.gv菜单.OptionsView.ColumnAutoWidth = false;
            this.gv菜单.OptionsView.RowAutoHeight = true;
            this.gv菜单.OptionsView.ShowFooter = true;
            this.gv菜单.OptionsView.ShowGroupPanel = false;
            this.gv菜单.Tag = "v菜单";
            // 
            // tp按钮
            // 
            this.tp按钮.Controls.Add(this.gc按钮);
            this.tp按钮.Location = new System.Drawing.Point(4, 22);
            this.tp按钮.Name = "tp按钮";
            this.tp按钮.Padding = new System.Windows.Forms.Padding(3);
            this.tp按钮.Size = new System.Drawing.Size(303, 215);
            this.tp按钮.TabIndex = 1;
            this.tp按钮.Text = "按钮";
            // 
            // gc按钮
            // 
            this.gc按钮.ContextMenu = this.cmData;
            this.gc按钮.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc按钮.Location = new System.Drawing.Point(3, 3);
            this.gc按钮.MainView = this.gv按钮;
            this.gc按钮.Name = "gc按钮";
            this.gc按钮.Size = new System.Drawing.Size(297, 209);
            this.gc按钮.TabIndex = 0;
            this.gc按钮.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv按钮});
            // 
            // gv按钮
            // 
            this.gv按钮.GridControl = this.gc按钮;
            this.gv按钮.IndicatorWidth = 50;
            this.gv按钮.Name = "gv按钮";
            this.gv按钮.OptionsSelection.MultiSelect = true;
            this.gv按钮.OptionsView.ColumnAutoWidth = false;
            this.gv按钮.OptionsView.RowAutoHeight = true;
            this.gv按钮.OptionsView.ShowFooter = true;
            this.gv按钮.OptionsView.ShowGroupPanel = false;
            this.gv按钮.Tag = "v按钮";
            // 
            // tp字段
            // 
            this.tp字段.Controls.Add(this.gc字段);
            this.tp字段.Location = new System.Drawing.Point(4, 22);
            this.tp字段.Name = "tp字段";
            this.tp字段.Padding = new System.Windows.Forms.Padding(3);
            this.tp字段.Size = new System.Drawing.Size(303, 215);
            this.tp字段.TabIndex = 2;
            this.tp字段.Text = "字段";
            // 
            // gc字段
            // 
            this.gc字段.ContextMenu = this.cmData;
            this.gc字段.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc字段.Location = new System.Drawing.Point(3, 3);
            this.gc字段.MainView = this.gv字段;
            this.gc字段.Name = "gc字段";
            this.gc字段.Size = new System.Drawing.Size(297, 209);
            this.gc字段.TabIndex = 0;
            this.gc字段.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv字段});
            // 
            // gv字段
            // 
            this.gv字段.GridControl = this.gc字段;
            this.gv字段.IndicatorWidth = 50;
            this.gv字段.Name = "gv字段";
            this.gv字段.OptionsSelection.MultiSelect = true;
            this.gv字段.OptionsView.ColumnAutoWidth = false;
            this.gv字段.OptionsView.RowAutoHeight = true;
            this.gv字段.OptionsView.ShowFooter = true;
            this.gv字段.OptionsView.ShowGroupPanel = false;
            this.gv字段.Tag = "v字段";
            // 
            // 菜单维护
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 315);
            this.Controls.Add(this.tc1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tv1);
            this.Name = "菜单维护";
            this.Text = "菜单维护";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tv1, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.tc1, 0);
            this.tc1.ResumeLayout(false);
            this.tp菜单.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc菜单)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv菜单)).EndInit();
            this.tp按钮.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc按钮)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv按钮)).EndInit();
            this.tp字段.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc字段)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv字段)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tp菜单;
        private DevExpress.XtraGrid.GridControl gc菜单;
        private DevExpress.XtraGrid.Views.Grid.GridView gv菜单;
        private System.Windows.Forms.TabPage tp按钮;
        private DevExpress.XtraGrid.GridControl gc按钮;
        private DevExpress.XtraGrid.Views.Grid.GridView gv按钮;
        private System.Windows.Forms.TabPage tp字段;
        private DevExpress.XtraGrid.GridControl gc字段;
        private DevExpress.XtraGrid.Views.Grid.GridView gv字段;
    }
}