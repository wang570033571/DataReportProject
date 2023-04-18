namespace ERP
{
    partial class 退出系统
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
            this.btn退出 = new System.Windows.Forms.Button();
            this.btn取消 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn注销 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn退出
            // 
            this.btn退出.Location = new System.Drawing.Point(23, 52);
            this.btn退出.Name = "btn退出";
            this.btn退出.Size = new System.Drawing.Size(50, 23);
            this.btn退出.TabIndex = 0;
            this.btn退出.Text = "退出";
            this.btn退出.UseVisualStyleBackColor = true;
            this.btn退出.Click += new System.EventHandler(this.btn确认_Click);
            // 
            // btn取消
            // 
            this.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn取消.Location = new System.Drawing.Point(157, 52);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(50, 23);
            this.btn取消.TabIndex = 1;
            this.btn取消.Text = "取消";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "您确定要退出系统吗?";
            // 
            // btn注销
            // 
            this.btn注销.Location = new System.Drawing.Point(90, 52);
            this.btn注销.Name = "btn注销";
            this.btn注销.Size = new System.Drawing.Size(50, 23);
            this.btn注销.TabIndex = 3;
            this.btn注销.Text = "注销";
            this.btn注销.UseVisualStyleBackColor = true;
            this.btn注销.Click += new System.EventHandler(this.btn注销_Click);
            // 
            // 退出系统
            // 
            this.AcceptButton = this.btn退出;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn取消;
            this.ClientSize = new System.Drawing.Size(239, 94);
            this.Controls.Add(this.btn注销);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn退出);
            this.Name = "退出系统";
            this.Text = "退出系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn退出;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn注销;

    }
}