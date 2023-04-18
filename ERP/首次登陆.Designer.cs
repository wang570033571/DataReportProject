namespace ERP
{
    partial class 首次登陆
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(首次登陆));
            this.txt确认新密码 = new System.Windows.Forms.TextBox();
            this.txt新密码 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn取消 = new System.Windows.Forms.Button();
            this.btn确认 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt确认新密码
            // 
            this.txt确认新密码.Location = new System.Drawing.Point(91, 37);
            this.txt确认新密码.Name = "txt确认新密码";
            this.txt确认新密码.PasswordChar = '*';
            this.txt确认新密码.Size = new System.Drawing.Size(100, 21);
            this.txt确认新密码.TabIndex = 46;
            // 
            // txt新密码
            // 
            this.txt新密码.Location = new System.Drawing.Point(91, 10);
            this.txt新密码.Name = "txt新密码";
            this.txt新密码.PasswordChar = '*';
            this.txt新密码.Size = new System.Drawing.Size(100, 21);
            this.txt新密码.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 48;
            this.label10.Text = "确认新密码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 47;
            this.label9.Text = "新密码";
            // 
            // btn取消
            // 
            this.btn取消.Location = new System.Drawing.Point(116, 64);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 50;
            this.btn取消.Text = "取消";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // btn确认
            // 
            this.btn确认.Location = new System.Drawing.Point(40, 64);
            this.btn确认.Name = "btn确认";
            this.btn确认.Size = new System.Drawing.Size(75, 23);
            this.btn确认.TabIndex = 49;
            this.btn确认.Text = "确认";
            this.btn确认.UseVisualStyleBackColor = true;
            this.btn确认.Click += new System.EventHandler(this.btn确认_Click);
            // 
            // 首次登陆
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 90);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn确认);
            this.Controls.Add(this.txt确认新密码);
            this.Controls.Add(this.txt新密码);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "首次登陆";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "首次登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt确认新密码;
        private System.Windows.Forms.TextBox txt新密码;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.Button btn确认;
    }
}