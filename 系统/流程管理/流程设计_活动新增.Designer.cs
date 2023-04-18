namespace 系统
{
    partial class 流程设计_活动新增
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
            this.cbb方向 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb数据库 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb存储过程 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt形参 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt实参 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt实参);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt形参);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbb存储过程);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbb数据库);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbb方向);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(665, 157);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "方向";
            // 
            // cbb方向
            // 
            this.cbb方向.DisplayMember = "0";
            this.cbb方向.FormattingEnabled = true;
            this.cbb方向.Items.AddRange(new object[] {
            "正向",
            "逆向"});
            this.cbb方向.Location = new System.Drawing.Point(47, 12);
            this.cbb方向.MaxDropDownItems = 50;
            this.cbb方向.Name = "cbb方向";
            this.cbb方向.Size = new System.Drawing.Size(121, 20);
            this.cbb方向.TabIndex = 1;
            this.cbb方向.Tag = "方向";
            this.cbb方向.Text = "正向";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库";
            // 
            // cbb数据库
            // 
            this.cbb数据库.FormattingEnabled = true;
            this.cbb数据库.Location = new System.Drawing.Point(221, 12);
            this.cbb数据库.MaxDropDownItems = 50;
            this.cbb数据库.Name = "cbb数据库";
            this.cbb数据库.Size = new System.Drawing.Size(121, 20);
            this.cbb数据库.TabIndex = 3;
            this.cbb数据库.Tag = "数据库";
            this.cbb数据库.DropDown += new System.EventHandler(this.cbb数据库_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "存储过程";
            // 
            // cbb存储过程
            // 
            this.cbb存储过程.FormattingEnabled = true;
            this.cbb存储过程.Location = new System.Drawing.Point(407, 12);
            this.cbb存储过程.MaxDropDownItems = 50;
            this.cbb存储过程.Name = "cbb存储过程";
            this.cbb存储过程.Size = new System.Drawing.Size(246, 20);
            this.cbb存储过程.TabIndex = 5;
            this.cbb存储过程.Tag = "存储过程";
            this.cbb存储过程.SelectedIndexChanged += new System.EventHandler(this.cbb存储过程_SelectedIndexChanged);
            this.cbb存储过程.DropDown += new System.EventHandler(this.cbb存储过程_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "形参";
            // 
            // txt形参
            // 
            this.txt形参.Location = new System.Drawing.Point(47, 38);
            this.txt形参.Name = "txt形参";
            this.txt形参.Size = new System.Drawing.Size(606, 21);
            this.txt形参.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "实参";
            // 
            // txt实参
            // 
            this.txt实参.Location = new System.Drawing.Point(47, 65);
            this.txt实参.Name = "txt实参";
            this.txt实参.Size = new System.Drawing.Size(606, 21);
            this.txt实参.TabIndex = 9;
            this.txt实参.Tag = "参数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "实参说明";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "1.\"@\"开头的参数表示变量,从视图中获取的参数,其他表示常量";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "2.当前操作员直接用\"操作员\"表示";
            // 
            // 流程设计_活动新增
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 197);
            this.Name = "流程设计_活动新增";
            this.Text = "流程设计_活动新增";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb方向;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt实参;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt形参;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb存储过程;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb数据库;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}