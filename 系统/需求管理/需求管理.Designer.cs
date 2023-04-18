namespace 系统
{
    partial class 需求管理
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt标题 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt开发人 = new System.Windows.Forms.TextBox();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb状态 = new System.Windows.Forms.ComboBox();
            this.cmb日期 = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt描述 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl流程进度 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb日期);
            this.panel1.Controls.Add(this.cmb状态);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt开发人);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt标题);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(801, 34);
            this.panel1.Tag = "v需求管理";
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.txt标题, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.txt开发人, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.cmb状态, 0);
            this.panel1.Controls.SetChildIndex(this.cmb日期, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "标题";
            // 
            // txt标题
            // 
            this.txt标题.Location = new System.Drawing.Point(171, 7);
            this.txt标题.Name = "txt标题";
            this.txt标题.Size = new System.Drawing.Size(167, 21);
            this.txt标题.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "开发人";
            // 
            // txt开发人
            // 
            this.txt开发人.Location = new System.Drawing.Point(392, 7);
            this.txt开发人.Name = "txt开发人";
            this.txt开发人.Size = new System.Drawing.Size(100, 21);
            this.txt开发人.TabIndex = 7;
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gc1.Location = new System.Drawing.Point(0, 74);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(801, 343);
            this.gc1.TabIndex = 3;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1,
            this.gridView2});
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
            this.gv1.Click += new System.EventHandler(this.gv1_Click);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gc1;
            this.gridView2.Name = "gridView2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "状态";
            // 
            // cmb状态
            // 
            this.cmb状态.FormattingEnabled = true;
            this.cmb状态.Location = new System.Drawing.Point(533, 8);
            this.cmb状态.MaxDropDownItems = 50;
            this.cmb状态.Name = "cmb状态";
            this.cmb状态.Size = new System.Drawing.Size(83, 20);
            this.cmb状态.TabIndex = 9;
            this.cmb状态.DropDown += new System.EventHandler(this.cmb状态_DropDown);
            // 
            // cmb日期
            // 
            this.cmb日期.FormattingEnabled = true;
            this.cmb日期.Location = new System.Drawing.Point(47, 7);
            this.cmb日期.MaxDropDownItems = 50;
            this.cmb日期.Name = "cmb日期";
            this.cmb日期.Size = new System.Drawing.Size(83, 20);
            this.cmb日期.TabIndex = 10;
            this.cmb日期.DropDown += new System.EventHandler(this.cmb日期_DropDown);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 417);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(801, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 454);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 25);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt描述);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "需求内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt描述
            // 
            this.txt描述.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt描述.Location = new System.Drawing.Point(3, 3);
            this.txt描述.Multiline = true;
            this.txt描述.Name = "txt描述";
            this.txt描述.Size = new System.Drawing.Size(787, 0);
            this.txt描述.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl流程进度);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 34);
            this.panel2.TabIndex = 6;
            // 
            // lbl流程进度
            // 
            this.lbl流程进度.AutoSize = true;
            this.lbl流程进度.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl流程进度.Location = new System.Drawing.Point(6, 12);
            this.lbl流程进度.Name = "lbl流程进度";
            this.lbl流程进度.Size = new System.Drawing.Size(0, 12);
            this.lbl流程进度.TabIndex = 0;
            // 
            // 需求管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 479);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gc1);
            this.Name = "需求管理";
            this.Text = "需求管理";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gc1, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt标题;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt开发人;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.ComboBox cmb状态;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb日期;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt描述;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl流程进度;
    }
}