namespace 系统
{
    partial class 密码设置
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(密码设置));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt旧密码 = new System.Windows.Forms.TextBox();
            this.txt新密码 = new System.Windows.Forms.TextBox();
            this.txt确认新密码 = new System.Windows.Forms.TextBox();
            this.btn确认 = new System.Windows.Forms.Button();
            this.btn取消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认新密码";
            // 
            // txt旧密码
            // 
            this.txt旧密码.BackColor = System.Drawing.SystemColors.Info;
            this.txt旧密码.Location = new System.Drawing.Point(105, 16);
            this.txt旧密码.Name = "txt旧密码";
            this.txt旧密码.PasswordChar = '*';
            this.txt旧密码.ReadOnly = true;
            this.txt旧密码.Size = new System.Drawing.Size(100, 21);
            this.txt旧密码.TabIndex = 1;
            this.txt旧密码.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt旧密码_KeyDown);
            // 
            // txt新密码
            // 
            this.txt新密码.Location = new System.Drawing.Point(105, 43);
            this.txt新密码.Name = "txt新密码";
            this.txt新密码.PasswordChar = '*';
            this.txt新密码.Size = new System.Drawing.Size(100, 21);
            this.txt新密码.TabIndex = 2;
            this.txt新密码.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt新密码_KeyDown);
            // 
            // txt确认新密码
            // 
            this.txt确认新密码.Location = new System.Drawing.Point(105, 70);
            this.txt确认新密码.Name = "txt确认新密码";
            this.txt确认新密码.PasswordChar = '*';
            this.txt确认新密码.Size = new System.Drawing.Size(100, 21);
            this.txt确认新密码.TabIndex = 3;
            this.txt确认新密码.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt确认新密码_KeyDown);
            // 
            // btn确认
            // 
            this.btn确认.Location = new System.Drawing.Point(60, 102);
            this.btn确认.Name = "btn确认";
            this.btn确认.Size = new System.Drawing.Size(75, 23);
            this.btn确认.TabIndex = 6;
            this.btn确认.Text = "确认";
            this.btn确认.UseVisualStyleBackColor = true;
            this.btn确认.Click += new System.EventHandler(this.btn确认_Click);
            // 
            // btn取消
            // 
            this.btn取消.Location = new System.Drawing.Point(152, 102);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 7;
            this.btn取消.Text = "取消";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // 密码设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 135);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn确认);
            this.Controls.Add(this.txt确认新密码);
            this.Controls.Add(this.txt新密码);
            this.Controls.Add(this.txt旧密码);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "密码设置";
            this.Text = "密码设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt旧密码;
        private System.Windows.Forms.TextBox txt新密码;
        private System.Windows.Forms.TextBox txt确认新密码;
        private System.Windows.Forms.Button btn确认;
        private System.Windows.Forms.Button btn取消;
    }
}