namespace 系统
{
    partial class 流程设计
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
            this.txtfID = new System.Windows.Forms.TextBox();
            this.txt流程名称 = new System.Windows.Forms.TextBox();
            this.txt单证 = new System.Windows.Forms.TextBox();
            this.txt视图 = new System.Windows.Forms.TextBox();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt视图);
            this.panel1.Controls.Add(this.txt单证);
            this.panel1.Controls.Add(this.txt流程名称);
            this.panel1.Controls.Add(this.txtfID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(662, 36);
            this.panel1.Tag = "v流程定义表头";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "流程ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "流程名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "单证";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "视图";
            // 
            // txtfID
            // 
            this.txtfID.Location = new System.Drawing.Point(56, 7);
            this.txtfID.Name = "txtfID";
            this.txtfID.Size = new System.Drawing.Size(100, 21);
            this.txtfID.TabIndex = 7;
            this.txtfID.Tag = "fID=@值";
            // 
            // txt流程名称
            // 
            this.txt流程名称.Location = new System.Drawing.Point(221, 7);
            this.txt流程名称.Name = "txt流程名称";
            this.txt流程名称.Size = new System.Drawing.Size(100, 21);
            this.txt流程名称.TabIndex = 8;
            this.txt流程名称.Tag = "名称=@值";
            // 
            // txt单证
            // 
            this.txt单证.Location = new System.Drawing.Point(362, 7);
            this.txt单证.Name = "txt单证";
            this.txt单证.Size = new System.Drawing.Size(100, 21);
            this.txt单证.TabIndex = 9;
            this.txt单证.Tag = "单证=@值";
            // 
            // txt视图
            // 
            this.txt视图.Location = new System.Drawing.Point(503, 7);
            this.txt视图.Name = "txt视图";
            this.txt视图.Size = new System.Drawing.Size(100, 21);
            this.txt视图.TabIndex = 10;
            this.txt视图.Tag = "视图=@值";
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 76);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(662, 376);
            this.gc1.TabIndex = 2;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
            this.gc1.DoubleClick += new System.EventHandler(this.gc1_DoubleClick);
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
            this.gv1.Tag = "v流程定义表头";
            // 
            // 流程设计
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 452);
            this.Controls.Add(this.gc1);
            this.Name = "流程设计";
            this.Text = "流程设计";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gc1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt视图;
        private System.Windows.Forms.TextBox txt单证;
        private System.Windows.Forms.TextBox txt流程名称;
        private System.Windows.Forms.TextBox txtfID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
    }
}