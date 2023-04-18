namespace 系统
{
    partial class 日志查询
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt用户 = new System.Windows.Forms.TextBox();
            this.txt描述 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt脚本 = new System.Windows.Forms.TextBox();
            this.cbb结果 = new System.Windows.Forms.ComboBox();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt结束日期 = new System.Windows.Forms.TextBox();
            this.txt开始日期 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb结果);
            this.panel1.Controls.Add(this.txt结束日期);
            this.panel1.Controls.Add(this.txt开始日期);
            this.panel1.Controls.Add(this.txt脚本);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt描述);
            this.panel1.Controls.Add(this.txt用户);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(527, 66);
            this.panel1.Tag = "v日志";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "脚本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "开始日期";
            // 
            // txt用户
            // 
            this.txt用户.Location = new System.Drawing.Point(69, 9);
            this.txt用户.Name = "txt用户";
            this.txt用户.Size = new System.Drawing.Size(100, 21);
            this.txt用户.TabIndex = 4;
            this.txt用户.Tag = "用户 = @值";
            // 
            // txt描述
            // 
            this.txt描述.Location = new System.Drawing.Point(234, 9);
            this.txt描述.Name = "txt描述";
            this.txt描述.Size = new System.Drawing.Size(100, 21);
            this.txt描述.TabIndex = 5;
            this.txt描述.Tag = "描述 Like \'%@值%\'";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "结束日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "结果";
            // 
            // txt脚本
            // 
            this.txt脚本.Location = new System.Drawing.Point(375, 9);
            this.txt脚本.Name = "txt脚本";
            this.txt脚本.Size = new System.Drawing.Size(100, 21);
            this.txt脚本.TabIndex = 8;
            this.txt脚本.Tag = "脚本 Like \'%@值%\'";
            // 
            // cbb结果
            // 
            this.cbb结果.FormattingEnabled = true;
            this.cbb结果.Items.AddRange(new object[] {
            "成功",
            "失败"});
            this.cbb结果.Location = new System.Drawing.Point(375, 36);
            this.cbb结果.MaxDropDownItems = 50;
            this.cbb结果.Name = "cbb结果";
            this.cbb结果.Size = new System.Drawing.Size(100, 20);
            this.cbb结果.TabIndex = 11;
            this.cbb结果.Tag = "结果 Like \'@值%\'";
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.Location = new System.Drawing.Point(0, 106);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.gc1);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.txt1);
            this.sc1.Size = new System.Drawing.Size(527, 208);
            this.sc1.SplitterDistance = 152;
            this.sc1.TabIndex = 3;
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 0);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(527, 152);
            this.gc1.TabIndex = 4;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
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
            this.gv1.Tag = "v日志";
            // 
            // txt1
            // 
            this.txt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt1.Location = new System.Drawing.Point(0, 0);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(527, 52);
            this.txt1.TabIndex = 0;
            // 
            // txt结束日期
            // 
            this.txt结束日期.Location = new System.Drawing.Point(234, 36);
            this.txt结束日期.Name = "txt结束日期";
            this.txt结束日期.Size = new System.Drawing.Size(100, 21);
            this.txt结束日期.TabIndex = 10;
            this.txt结束日期.Tag = "日期<=@值";
            // 
            // txt开始日期
            // 
            this.txt开始日期.Location = new System.Drawing.Point(69, 36);
            this.txt开始日期.Name = "txt开始日期";
            this.txt开始日期.Size = new System.Drawing.Size(100, 21);
            this.txt开始日期.TabIndex = 9;
            this.txt开始日期.Tag = "日期>=@值";
            // 
            // 日志查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 314);
            this.Controls.Add(this.sc1);
            this.Name = "日志查询";
            this.Text = "日志查询";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.sc1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            this.sc1.Panel2.PerformLayout();
            this.sc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt描述;
        private System.Windows.Forms.TextBox txt用户;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb结果;
        private System.Windows.Forms.TextBox txt脚本;
        private System.Windows.Forms.SplitContainer sc1;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt结束日期;
        private System.Windows.Forms.TextBox txt开始日期;
    }
}