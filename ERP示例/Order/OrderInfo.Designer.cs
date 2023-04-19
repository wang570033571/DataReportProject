
namespace ERP示例
{
    partial class OrderInfo
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
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt_OrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_OrderNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(800, 34);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.txt_OrderNumber, 0);
            // 
            // gc1
            // 
            this.gc1.ContextMenu = this.cmData;
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 74);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(800, 376);
            this.gc1.TabIndex = 4;
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
            // 
            // txt_OrderNumber
            // 
            this.txt_OrderNumber.Location = new System.Drawing.Point(56, 5);
            this.txt_OrderNumber.Name = "txt_OrderNumber";
            this.txt_OrderNumber.Size = new System.Drawing.Size(100, 21);
            this.txt_OrderNumber.TabIndex = 9;
            this.txt_OrderNumber.Tag = "OrderNumber Like \'@值%\'";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "订单号";
            // 
            // OrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gc1);
            this.Name = "OrderInfo";
            this.Text = "OrderInfo";
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

        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private System.Windows.Forms.TextBox txt_OrderNumber;
        private System.Windows.Forms.Label label1;
    }
}