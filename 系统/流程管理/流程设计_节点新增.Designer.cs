namespace 系统
{
    partial class 流程设计_节点新增
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
            this.txtfID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt节点 = new System.Windows.Forms.TextBox();
            this.cbb类型 = new System.Windows.Forms.ComboBox();
            this.cbb参与者类型 = new System.Windows.Forms.ComboBox();
            this.txt周期 = new System.Windows.Forms.TextBox();
            this.txt名称 = new System.Windows.Forms.TextBox();
            this.cbb参与者 = new System.Windows.Forms.ComboBox();
            this.cbb周期单位 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb重复过滤 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb重复过滤);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbb周期单位);
            this.panel1.Controls.Add(this.cbb参与者);
            this.panel1.Controls.Add(this.txt名称);
            this.panel1.Controls.Add(this.txt周期);
            this.panel1.Controls.Add(this.cbb参与者类型);
            this.panel1.Controls.Add(this.cbb类型);
            this.panel1.Controls.Add(this.txt节点);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtfID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(361, 144);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "fID";
            // 
            // txtfID
            // 
            this.txtfID.Location = new System.Drawing.Point(80, 8);
            this.txtfID.Name = "txtfID";
            this.txtfID.Size = new System.Drawing.Size(100, 21);
            this.txtfID.TabIndex = 1;
            this.txtfID.Tag = "fID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型";
            // 
            // txt节点
            // 
            this.txt节点.Location = new System.Drawing.Point(80, 35);
            this.txt节点.Name = "txt节点";
            this.txt节点.Size = new System.Drawing.Size(100, 21);
            this.txt节点.TabIndex = 3;
            this.txt节点.Tag = "节点";
            // 
            // cbb类型
            // 
            this.cbb类型.FormattingEnabled = true;
            this.cbb类型.Location = new System.Drawing.Point(245, 8);
            this.cbb类型.MaxDropDownItems = 50;
            this.cbb类型.Name = "cbb类型";
            this.cbb类型.Size = new System.Drawing.Size(100, 20);
            this.cbb类型.TabIndex = 4;
            this.cbb类型.Tag = "类型";
            this.cbb类型.SelectedIndexChanged += new System.EventHandler(this.cbb类型_SelectedIndexChanged);
            this.cbb类型.DropDown += new System.EventHandler(this.cbb类型_DropDown);
            // 
            // cbb参与者类型
            // 
            this.cbb参与者类型.FormattingEnabled = true;
            this.cbb参与者类型.Location = new System.Drawing.Point(80, 62);
            this.cbb参与者类型.MaxDropDownItems = 50;
            this.cbb参与者类型.Name = "cbb参与者类型";
            this.cbb参与者类型.Size = new System.Drawing.Size(100, 20);
            this.cbb参与者类型.TabIndex = 5;
            this.cbb参与者类型.Tag = "参与者类型";
            this.cbb参与者类型.DropDown += new System.EventHandler(this.cbb参与者类型_DropDown);
            // 
            // txt周期
            // 
            this.txt周期.Location = new System.Drawing.Point(80, 114);
            this.txt周期.Name = "txt周期";
            this.txt周期.Size = new System.Drawing.Size(100, 21);
            this.txt周期.TabIndex = 6;
            this.txt周期.Tag = "周期";
            // 
            // txt名称
            // 
            this.txt名称.Location = new System.Drawing.Point(245, 35);
            this.txt名称.Name = "txt名称";
            this.txt名称.Size = new System.Drawing.Size(100, 21);
            this.txt名称.TabIndex = 7;
            this.txt名称.Tag = "名称";
            // 
            // cbb参与者
            // 
            this.cbb参与者.FormattingEnabled = true;
            this.cbb参与者.Location = new System.Drawing.Point(80, 88);
            this.cbb参与者.MaxDropDownItems = 50;
            this.cbb参与者.Name = "cbb参与者";
            this.cbb参与者.Size = new System.Drawing.Size(265, 20);
            this.cbb参与者.TabIndex = 8;
            this.cbb参与者.Tag = "参与者";
            this.cbb参与者.DropDown += new System.EventHandler(this.cbb参与者_DropDown);
            // 
            // cbb周期单位
            // 
            this.cbb周期单位.FormattingEnabled = true;
            this.cbb周期单位.Location = new System.Drawing.Point(245, 114);
            this.cbb周期单位.MaxDropDownItems = 50;
            this.cbb周期单位.Name = "cbb周期单位";
            this.cbb周期单位.Size = new System.Drawing.Size(100, 20);
            this.cbb周期单位.TabIndex = 9;
            this.cbb周期单位.Tag = "周期单位";
            this.cbb周期单位.DropDown += new System.EventHandler(this.cbb周期单位_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "节点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "参与者类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "参与者";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "周期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "周期单位";
            // 
            // cb重复过滤
            // 
            this.cb重复过滤.AutoSize = true;
            this.cb重复过滤.Location = new System.Drawing.Point(273, 66);
            this.cb重复过滤.Name = "cb重复过滤";
            this.cb重复过滤.Size = new System.Drawing.Size(72, 16);
            this.cb重复过滤.TabIndex = 16;
            this.cb重复过滤.Tag = "重复标志";
            this.cb重复过滤.Text = "重复过滤";
            this.cb重复过滤.UseVisualStyleBackColor = true;
            // 
            // 流程设计_节点新增
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 184);
            this.Name = "流程设计_节点新增";
            this.Text = "流程设计_节点新增";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb重复过滤;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb周期单位;
        private System.Windows.Forms.ComboBox cbb参与者;
        private System.Windows.Forms.TextBox txt名称;
        private System.Windows.Forms.TextBox txt周期;
        private System.Windows.Forms.ComboBox cbb参与者类型;
        private System.Windows.Forms.ComboBox cbb类型;
        private System.Windows.Forms.TextBox txt节点;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfID;
        private System.Windows.Forms.Label label1;
    }
}