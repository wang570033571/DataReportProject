namespace 系统
{
    partial class 流程代理人_选择
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
            this.txt姓名 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt姓名);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(730, 34);
            // 
            // txt姓名
            // 
            this.txt姓名.Location = new System.Drawing.Point(42, 7);
            this.txt姓名.Name = "txt姓名";
            this.txt姓名.Size = new System.Drawing.Size(100, 21);
            this.txt姓名.TabIndex = 5;
            this.txt姓名.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt姓名_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "姓名";
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 74);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(255, 384);
            this.tv1.TabIndex = 4;
            this.tv1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseClick);
            this.tv1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterExpand);
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
            this.gv1.Tag = "v通讯录";
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gc1.Location = new System.Drawing.Point(258, 74);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(472, 384);
            this.gc1.TabIndex = 3;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
            this.gc1.DoubleClick += new System.EventHandler(this.gc1_DoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(255, 74);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 384);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // 流程代理人_选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 458);
            this.Controls.Add(this.tv1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gc1);
            this.Name = "流程代理人_选择";
            this.Text = "流程代理人_选择";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gc1, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.tv1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt姓名;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tv1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.GridControl gc1;
        private System.Windows.Forms.Splitter splitter1;
    }
}