namespace 系统
{
    partial class 需求管理_编辑
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
            this.cmb类型 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb级别 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt标题 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt内容 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt开发人 = new System.Windows.Forms.TextBox();
            this.btn选择 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dt完成日期 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dt完成日期);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn选择);
            this.panel1.Controls.Add(this.txt开发人);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt内容);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt标题);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb级别);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb类型);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(487, 271);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型";
            // 
            // cmb类型
            // 
            this.cmb类型.FormattingEnabled = true;
            this.cmb类型.Items.AddRange(new object[] {
            "功能新增",
            "Bug修改"});
            this.cmb类型.Location = new System.Drawing.Point(64, 15);
            this.cmb类型.MaxDropDownItems = 50;
            this.cmb类型.Name = "cmb类型";
            this.cmb类型.Size = new System.Drawing.Size(96, 20);
            this.cmb类型.TabIndex = 1;
            this.cmb类型.Tag = "类型";
            this.cmb类型.DropDown += new System.EventHandler(this.cmb类型_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "级别";
            // 
            // cmb级别
            // 
            this.cmb级别.FormattingEnabled = true;
            this.cmb级别.Items.AddRange(new object[] {
            "一般",
            "加急"});
            this.cmb级别.Location = new System.Drawing.Point(221, 15);
            this.cmb级别.MaxDropDownItems = 50;
            this.cmb级别.Name = "cmb级别";
            this.cmb级别.Size = new System.Drawing.Size(96, 20);
            this.cmb级别.TabIndex = 3;
            this.cmb级别.Tag = "级别";
            this.cmb级别.DropDown += new System.EventHandler(this.cmb级别_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "标题";
            // 
            // txt标题
            // 
            this.txt标题.Location = new System.Drawing.Point(64, 41);
            this.txt标题.Name = "txt标题";
            this.txt标题.Size = new System.Drawing.Size(406, 21);
            this.txt标题.TabIndex = 5;
            this.txt标题.Tag = "标题";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "内容";
            // 
            // txt内容
            // 
            this.txt内容.Location = new System.Drawing.Point(64, 68);
            this.txt内容.Multiline = true;
            this.txt内容.Name = "txt内容";
            this.txt内容.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt内容.Size = new System.Drawing.Size(406, 165);
            this.txt内容.TabIndex = 7;
            this.txt内容.Tag = "内容";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "开发人";
            // 
            // txt开发人
            // 
            this.txt开发人.BackColor = System.Drawing.SystemColors.Info;
            this.txt开发人.Location = new System.Drawing.Point(64, 239);
            this.txt开发人.Name = "txt开发人";
            this.txt开发人.ReadOnly = true;
            this.txt开发人.Size = new System.Drawing.Size(378, 21);
            this.txt开发人.TabIndex = 9;
            this.txt开发人.Tag = "开发人";
            // 
            // btn选择
            // 
            this.btn选择.Image = global::系统.Properties.Resources.加;
            this.btn选择.Location = new System.Drawing.Point(449, 237);
            this.btn选择.Name = "btn选择";
            this.btn选择.Size = new System.Drawing.Size(21, 23);
            this.btn选择.TabIndex = 10;
            this.btn选择.UseVisualStyleBackColor = true;
            this.btn选择.Click += new System.EventHandler(this.btn选择_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "完成日期";
            // 
            // dt完成日期
            // 
            this.dt完成日期.CustomFormat = "yyyy-MM-dd";
            this.dt完成日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt完成日期.Location = new System.Drawing.Point(382, 14);
            this.dt完成日期.Name = "dt完成日期";
            this.dt完成日期.Size = new System.Drawing.Size(88, 21);
            this.dt完成日期.TabIndex = 12;
            this.dt完成日期.Tag = "完成日期";
            // 
            // 需求管理_编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 311);
            this.Name = "需求管理_编辑";
            this.Text = "需求管理_编辑";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb类型;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb级别;
        private System.Windows.Forms.TextBox txt标题;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt内容;
        private System.Windows.Forms.TextBox txt开发人;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn选择;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt完成日期;
    }
}