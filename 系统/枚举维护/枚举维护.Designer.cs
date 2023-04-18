namespace 系统
{
    partial class 枚举维护
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tp枚举 = new System.Windows.Forms.TabPage();
            this.gc枚举 = new DevExpress.XtraGrid.GridControl();
            this.gv枚举 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tp值 = new System.Windows.Forms.TabPage();
            this.gc值 = new DevExpress.XtraGrid.GridControl();
            this.gv值 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tc1.SuspendLayout();
            this.tp枚举.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc枚举)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv枚举)).BeginInit();
            this.tp值.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc值)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv值)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(547, 34);
            this.panel1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tc1);
            this.splitContainer1.Size = new System.Drawing.Size(547, 247);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 2;
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(72, 247);
            this.tv1.TabIndex = 0;
            this.tv1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseClick);
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tp枚举);
            this.tc1.Controls.Add(this.tp值);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.Location = new System.Drawing.Point(0, 0);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(471, 247);
            this.tc1.TabIndex = 1;
            this.tc1.SelectedIndexChanged += new System.EventHandler(this.tc1_SelectedIndexChanged);
            // 
            // tp枚举
            // 
            this.tp枚举.Controls.Add(this.gc枚举);
            this.tp枚举.Location = new System.Drawing.Point(4, 22);
            this.tp枚举.Name = "tp枚举";
            this.tp枚举.Padding = new System.Windows.Forms.Padding(3);
            this.tp枚举.Size = new System.Drawing.Size(463, 221);
            this.tp枚举.TabIndex = 0;
            this.tp枚举.Text = "枚举";
            this.tp枚举.UseVisualStyleBackColor = true;
            // 
            // gc枚举
            // 
            this.gc枚举.ContextMenu = this.cmData;
            this.gc枚举.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc枚举.Location = new System.Drawing.Point(3, 3);
            this.gc枚举.MainView = this.gv枚举;
            this.gc枚举.Name = "gc枚举";
            this.gc枚举.Size = new System.Drawing.Size(457, 215);
            this.gc枚举.TabIndex = 0;
            this.gc枚举.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv枚举});
            // 
            // gv枚举
            // 
            this.gv枚举.GridControl = this.gc枚举;
            this.gv枚举.IndicatorWidth = 50;
            this.gv枚举.Name = "gv枚举";
            this.gv枚举.OptionsSelection.MultiSelect = true;
            this.gv枚举.OptionsView.ColumnAutoWidth = false;
            this.gv枚举.OptionsView.RowAutoHeight = true;
            this.gv枚举.OptionsView.ShowFooter = true;
            this.gv枚举.OptionsView.ShowGroupPanel = false;
            // 
            // tp值
            // 
            this.tp值.Controls.Add(this.gc值);
            this.tp值.Location = new System.Drawing.Point(4, 22);
            this.tp值.Name = "tp值";
            this.tp值.Padding = new System.Windows.Forms.Padding(3);
            this.tp值.Size = new System.Drawing.Size(463, 221);
            this.tp值.TabIndex = 1;
            this.tp值.Text = "值";
            this.tp值.UseVisualStyleBackColor = true;
            // 
            // gc值
            // 
            this.gc值.ContextMenu = this.cmData;
            this.gc值.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc值.Location = new System.Drawing.Point(3, 3);
            this.gc值.MainView = this.gv值;
            this.gc值.Name = "gc值";
            this.gc值.Size = new System.Drawing.Size(457, 215);
            this.gc值.TabIndex = 1;
            this.gc值.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv值});
            // 
            // gv值
            // 
            this.gv值.GridControl = this.gc值;
            this.gv值.IndicatorWidth = 50;
            this.gv值.Name = "gv值";
            this.gv值.OptionsSelection.MultiSelect = true;
            this.gv值.OptionsView.ColumnAutoWidth = false;
            this.gv值.OptionsView.RowAutoHeight = true;
            this.gv值.OptionsView.ShowFooter = true;
            this.gv值.OptionsView.ShowGroupPanel = false;
            // 
            // 枚举维护
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 321);
            this.Controls.Add(this.splitContainer1);
            this.Name = "枚举维护";
            this.Text = "枚举维护";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tc1.ResumeLayout(false);
            this.tp枚举.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc枚举)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv枚举)).EndInit();
            this.tp值.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc值)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv值)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tp枚举;
        private DevExpress.XtraGrid.GridControl gc枚举;
        private DevExpress.XtraGrid.Views.Grid.GridView gv枚举;
        private System.Windows.Forms.TabPage tp值;
        private DevExpress.XtraGrid.GridControl gc值;
        private DevExpress.XtraGrid.Views.Grid.GridView gv值;
    }
}