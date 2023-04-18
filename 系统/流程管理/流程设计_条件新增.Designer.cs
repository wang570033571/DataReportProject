namespace 系统
{
    partial class 流程设计_条件新增
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
            this.cbb字段 = new System.Windows.Forms.ComboBox();
            this.cbb运算符 = new System.Windows.Forms.ComboBox();
            this.txt内容 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb下一节点 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb下一节点);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt内容);
            this.panel1.Controls.Add(this.cbb运算符);
            this.panel1.Controls.Add(this.cbb字段);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(433, 47);
            // 
            // cbb字段
            // 
            this.cbb字段.FormattingEnabled = true;
            this.cbb字段.Location = new System.Drawing.Point(12, 15);
            this.cbb字段.Name = "cbb字段";
            this.cbb字段.Size = new System.Drawing.Size(121, 20);
            this.cbb字段.TabIndex = 0;
            this.cbb字段.Tag = "字段";
            this.cbb字段.DropDown += new System.EventHandler(this.cbb字段_DropDown);
            // 
            // cbb运算符
            // 
            this.cbb运算符.FormattingEnabled = true;
            this.cbb运算符.Location = new System.Drawing.Point(139, 15);
            this.cbb运算符.Name = "cbb运算符";
            this.cbb运算符.Size = new System.Drawing.Size(47, 20);
            this.cbb运算符.TabIndex = 1;
            this.cbb运算符.Tag = "运算符";
            this.cbb运算符.DropDown += new System.EventHandler(this.cbb运算符_DropDown);
            // 
            // txt内容
            // 
            this.txt内容.Location = new System.Drawing.Point(192, 15);
            this.txt内容.Name = "txt内容";
            this.txt内容.Size = new System.Drawing.Size(100, 21);
            this.txt内容.TabIndex = 2;
            this.txt内容.Tag = "内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "下一节点";
            // 
            // cbb下一节点
            // 
            this.cbb下一节点.FormattingEnabled = true;
            this.cbb下一节点.Location = new System.Drawing.Point(380, 15);
            this.cbb下一节点.Name = "cbb下一节点";
            this.cbb下一节点.Size = new System.Drawing.Size(43, 20);
            this.cbb下一节点.TabIndex = 5;
            this.cbb下一节点.Tag = "下一节点";
            this.cbb下一节点.DropDown += new System.EventHandler(this.cbb下一节点_DropDown);
            // 
            // 流程设计_条件新增
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 87);
            this.Name = "流程设计_条件新增";
            this.Text = "流程设计_条件新增";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb下一节点;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt内容;
        private System.Windows.Forms.ComboBox cbb运算符;
        private System.Windows.Forms.ComboBox cbb字段;
    }
}