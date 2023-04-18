namespace ERP示例
{
    partial class 例子
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel查询.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel容器
            // 
            this.panel查询.Controls.Add(this.label1);
            this.panel查询.Controls.Add(this.textBox1);
            this.panel查询.Location = new System.Drawing.Point(0, 40);
            this.panel查询.Controls.SetChildIndex(this.textBox1, 0);
            this.panel查询.Controls.SetChildIndex(this.label1, 0);
            // 
            // panel扩展
            // 
            this.panel扩展.Location = new System.Drawing.Point(0, 70);
            this.panel扩展.Size = new System.Drawing.Size(0, 369);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 14;
            // 
            // 例子
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 439);
            this.Name = "例子";
            this.Text = "例子";
            this.panel查询.ResumeLayout(false);
            this.panel查询.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}