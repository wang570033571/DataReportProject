namespace 系统
{
    partial class 流程设计_节点移动
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
            this.cbb改后节点 = new System.Windows.Forms.ComboBox();
            this.txt改前节点 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt改前节点);
            this.panel1.Controls.Add(this.cbb改后节点);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(185, 67);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "改前节点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "改后节点";
            // 
            // cbb改后节点
            // 
            this.cbb改后节点.FormattingEnabled = true;
            this.cbb改后节点.Location = new System.Drawing.Point(71, 34);
            this.cbb改后节点.Name = "cbb改后节点";
            this.cbb改后节点.Size = new System.Drawing.Size(100, 20);
            this.cbb改后节点.TabIndex = 3;
            this.cbb改后节点.DropDown += new System.EventHandler(this.cbb改后节点_DropDown);
            // 
            // txt改前节点
            // 
            this.txt改前节点.Location = new System.Drawing.Point(71, 8);
            this.txt改前节点.Name = "txt改前节点";
            this.txt改前节点.ReadOnly = true;
            this.txt改前节点.Size = new System.Drawing.Size(100, 21);
            this.txt改前节点.TabIndex = 4;
            // 
            // 流程设计_节点移动
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 107);
            this.Name = "流程设计_节点移动";
            this.Text = "流程设计_节点移动";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb改后节点;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt改前节点;
    }
}