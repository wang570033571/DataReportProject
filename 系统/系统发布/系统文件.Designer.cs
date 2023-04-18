namespace 系统
{
    partial class 系统文件
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
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(869, 38);
            this.panel1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 78);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gc1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gc2);
            this.splitContainer1.Size = new System.Drawing.Size(869, 479);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 15;
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 0);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(869, 239);
            this.gc1.TabIndex = 14;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
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
            this.gv1.DoubleClick += new System.EventHandler(this.gv1_DoubleClick);
            // 
            // gc2
            // 
            this.gc2.ContextMenu = this.cmData;
            this.gc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc2.Location = new System.Drawing.Point(0, 0);
            this.gc2.MainView = this.gv2;
            this.gc2.Name = "gc2";
            this.gc2.Size = new System.Drawing.Size(869, 236);
            this.gc2.TabIndex = 15;
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
            // 
            // 系统文件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 557);
            this.Controls.Add(this.splitContainer1);
            this.Name = "系统文件";
            this.Text = "系统文件";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.GridControl gc2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;


    }
}