namespace ERP
{
    partial class 登陆界面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(登陆界面));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txt用户 = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txt密码 = new System.Windows.Forms.TextBox();
            this.btn取消 = new System.Windows.Forms.Button();
            this.btn登陆 = new System.Windows.Forms.Button();
            this.rdb内网 = new System.Windows.Forms.RadioButton();
            this.rdb外网 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(34, 114);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户：";
            // 
            // txt用户
            // 
            this.txt用户.Location = new System.Drawing.Point(81, 111);
            this.txt用户.Name = "txt用户";
            this.txt用户.Size = new System.Drawing.Size(120, 21);
            this.txt用户.TabIndex = 1;
            this.txt用户.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt用户_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(34, 141);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "密码：";
            // 
            // txt密码
            // 
            this.txt密码.Location = new System.Drawing.Point(81, 138);
            this.txt密码.Name = "txt密码";
            this.txt密码.PasswordChar = '*';
            this.txt密码.Size = new System.Drawing.Size(120, 21);
            this.txt密码.TabIndex = 2;
            this.txt密码.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt密码_KeyDown);
            // 
            // btn取消
            // 
            this.btn取消.Location = new System.Drawing.Point(126, 192);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 4;
            this.btn取消.Text = "取消(&C)";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // btn登陆
            // 
            this.btn登陆.Location = new System.Drawing.Point(36, 192);
            this.btn登陆.Name = "btn登陆";
            this.btn登陆.Size = new System.Drawing.Size(75, 23);
            this.btn登陆.TabIndex = 3;
            this.btn登陆.Text = "登陆(&L)";
            this.btn登陆.UseVisualStyleBackColor = true;
            this.btn登陆.Click += new System.EventHandler(this.btn登陆_Click);
            // 
            // rdb内网
            // 
            this.rdb内网.AutoSize = true;
            this.rdb内网.BackColor = System.Drawing.Color.Transparent;
            this.rdb内网.Checked = true;
            this.rdb内网.Location = new System.Drawing.Point(36, 169);
            this.rdb内网.Name = "rdb内网";
            this.rdb内网.Size = new System.Drawing.Size(47, 16);
            this.rdb内网.TabIndex = 5;
            this.rdb内网.TabStop = true;
            this.rdb内网.Text = "内网";
            this.rdb内网.UseVisualStyleBackColor = false;
            // 
            // rdb外网
            // 
            this.rdb外网.AutoSize = true;
            this.rdb外网.BackColor = System.Drawing.Color.Transparent;
            this.rdb外网.Location = new System.Drawing.Point(154, 170);
            this.rdb外网.Name = "rdb外网";
            this.rdb外网.Size = new System.Drawing.Size(47, 16);
            this.rdb外网.TabIndex = 6;
            this.rdb外网.Text = "外网";
            this.rdb外网.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 72);
            this.label1.TabIndex = 9;
            this.label1.Text = "    ERP\r\n信息管理系统";
            // 
            // 登陆界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 220);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb外网);
            this.Controls.Add(this.rdb内网);
            this.Controls.Add(this.btn登陆);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.txt密码);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txt用户);
            this.Controls.Add(this.lblUserName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "登陆界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txt用户;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txt密码;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.Button btn登陆;
        private System.Windows.Forms.RadioButton rdb内网;
        private System.Windows.Forms.RadioButton rdb外网;
        private System.Windows.Forms.Label label1;

    }
}

