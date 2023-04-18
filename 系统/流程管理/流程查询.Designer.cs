namespace 系统
{
    partial class 流程查询
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
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.sc2 = new System.Windows.Forms.SplitContainer();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tp明细 = new System.Windows.Forms.TabPage();
            this.gc2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb制单日期 = new System.Windows.Forms.ComboBox();
            this.cbb状态 = new System.Windows.Forms.ComboBox();
            this.txt流程ID = new System.Windows.Forms.TextBox();
            this.txt流程名称 = new System.Windows.Forms.TextBox();
            this.txt单号 = new System.Windows.Forms.TextBox();
            this.lbl流程进度 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            this.sc2.Panel1.SuspendLayout();
            this.sc2.Panel2.SuspendLayout();
            this.sc2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tc1.SuspendLayout();
            this.tp明细.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl流程进度);
            this.panel1.Controls.Add(this.txt单号);
            this.panel1.Controls.Add(this.txt流程名称);
            this.panel1.Controls.Add(this.txt流程ID);
            this.panel1.Controls.Add(this.cbb状态);
            this.panel1.Controls.Add(this.cbb制单日期);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(796, 67);
            this.panel1.Tag = "v流程实例表头";
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.Location = new System.Drawing.Point(0, 107);
            this.sc1.Name = "sc1";
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.tv1);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.sc2);
            this.sc1.Size = new System.Drawing.Size(796, 385);
            this.sc1.SplitterDistance = 149;
            this.sc1.TabIndex = 2;
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(149, 385);
            this.tv1.TabIndex = 1;
            this.tv1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseClick);
            // 
            // sc2
            // 
            this.sc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc2.Location = new System.Drawing.Point(0, 0);
            this.sc2.Name = "sc2";
            this.sc2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc2.Panel1
            // 
            this.sc2.Panel1.Controls.Add(this.gc1);
            // 
            // sc2.Panel2
            // 
            this.sc2.Panel2.Controls.Add(this.tc1);
            this.sc2.Size = new System.Drawing.Size(643, 385);
            this.sc2.SplitterDistance = 192;
            this.sc2.TabIndex = 1;
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 0);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(643, 192);
            this.gc1.TabIndex = 2;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1,
            this.gridView2});
            this.gc1.Click += new System.EventHandler(this.gc1_Click);
            // 
            // gv1
            // 
            this.gv1.GridControl = this.gc1;
            this.gv1.IndicatorWidth = 50;
            this.gv1.Name = "gv1";
            this.gv1.OptionsSelection.MultiSelect = true;
            this.gv1.OptionsView.ColumnAutoWidth = false;
            this.gv1.OptionsView.RowAutoHeight = true;
            this.gv1.OptionsView.ShowFooter = true;
            this.gv1.OptionsView.ShowGroupPanel = false;
            this.gv1.Tag = "v流程实例表头";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gc1;
            this.gridView2.Name = "gridView2";
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tp明细);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.Location = new System.Drawing.Point(0, 0);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(643, 189);
            this.tc1.TabIndex = 1;
            this.tc1.SelectedIndexChanged += new System.EventHandler(this.tc1_SelectedIndexChanged);
            // 
            // tp明细
            // 
            this.tp明细.Controls.Add(this.gc2);
            this.tp明细.Location = new System.Drawing.Point(4, 22);
            this.tp明细.Name = "tp明细";
            this.tp明细.Padding = new System.Windows.Forms.Padding(3);
            this.tp明细.Size = new System.Drawing.Size(635, 163);
            this.tp明细.TabIndex = 0;
            this.tp明细.Text = "明细";
            this.tp明细.UseVisualStyleBackColor = true;
            // 
            // gc2
            // 
            this.gc2.ContextMenu = this.cmData;
            this.gc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc2.Location = new System.Drawing.Point(3, 3);
            this.gc2.MainView = this.gv2;
            this.gc2.Name = "gc2";
            this.gc2.Size = new System.Drawing.Size(629, 157);
            this.gc2.TabIndex = 1;
            this.gc2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv2});
            // 
            // gv2
            // 
            this.gv2.GridControl = this.gc2;
            this.gv2.IndicatorWidth = 50;
            this.gv2.Name = "gv2";
            this.gv2.OptionsSelection.MultiSelect = true;
            this.gv2.OptionsView.ColumnAutoWidth = false;
            this.gv2.OptionsView.RowAutoHeight = true;
            this.gv2.OptionsView.ShowFooter = true;
            this.gv2.OptionsView.ShowGroupPanel = false;
            this.gv2.Tag = "v流程实例表体";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "流程进度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "流程ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "流程名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "单号";
            // 
            // cbb制单日期
            // 
            this.cbb制单日期.FormattingEnabled = true;
            this.cbb制单日期.Location = new System.Drawing.Point(54, 9);
            this.cbb制单日期.MaxDropDownItems = 50;
            this.cbb制单日期.Name = "cbb制单日期";
            this.cbb制单日期.Size = new System.Drawing.Size(100, 20);
            this.cbb制单日期.TabIndex = 6;
            this.cbb制单日期.Tag = "制单日期 Between @值";
            this.cbb制单日期.DropDown += new System.EventHandler(this.cbb制单日期_DropDown);
            // 
            // cbb状态
            // 
            this.cbb状态.FormattingEnabled = true;
            this.cbb状态.Location = new System.Drawing.Point(216, 9);
            this.cbb状态.MaxDropDownItems = 50;
            this.cbb状态.Name = "cbb状态";
            this.cbb状态.Size = new System.Drawing.Size(100, 20);
            this.cbb状态.TabIndex = 7;
            this.cbb状态.Tag = "状态 = (Select fID from 系统..v状态 With (Nolock) Where 名称=@值)";
            this.cbb状态.DropDown += new System.EventHandler(this.cbb状态_DropDown);
            // 
            // txt流程ID
            // 
            this.txt流程ID.Location = new System.Drawing.Point(54, 34);
            this.txt流程ID.Name = "txt流程ID";
            this.txt流程ID.Size = new System.Drawing.Size(100, 21);
            this.txt流程ID.TabIndex = 8;
            this.txt流程ID.Tag = "流程ID = @值";
            // 
            // txt流程名称
            // 
            this.txt流程名称.Location = new System.Drawing.Point(216, 34);
            this.txt流程名称.Name = "txt流程名称";
            this.txt流程名称.Size = new System.Drawing.Size(100, 21);
            this.txt流程名称.TabIndex = 9;
            this.txt流程名称.Tag = "流程名称 Like \'%@值%\'";
            // 
            // txt单号
            // 
            this.txt单号.Location = new System.Drawing.Point(357, 34);
            this.txt单号.Name = "txt单号";
            this.txt单号.Size = new System.Drawing.Size(100, 21);
            this.txt单号.TabIndex = 10;
            this.txt单号.Tag = "单号=@值";
            // 
            // lbl流程进度
            // 
            this.lbl流程进度.AutoSize = true;
            this.lbl流程进度.Location = new System.Drawing.Point(381, 12);
            this.lbl流程进度.Name = "lbl流程进度";
            this.lbl流程进度.Size = new System.Drawing.Size(0, 12);
            this.lbl流程进度.TabIndex = 11;
            // 
            // 流程查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 492);
            this.Controls.Add(this.sc1);
            this.Name = "流程查询";
            this.Text = "流程查询";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.sc1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            this.sc1.ResumeLayout(false);
            this.sc2.Panel1.ResumeLayout(false);
            this.sc2.Panel2.ResumeLayout(false);
            this.sc2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tc1.ResumeLayout(false);
            this.tp明细.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.SplitContainer sc2;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl流程进度;
        private System.Windows.Forms.TextBox txt单号;
        private System.Windows.Forms.TextBox txt流程名称;
        private System.Windows.Forms.TextBox txt流程ID;
        private System.Windows.Forms.ComboBox cbb状态;
        private System.Windows.Forms.ComboBox cbb制单日期;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tp明细;
        private DevExpress.XtraGrid.GridControl gc2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;

    }
}