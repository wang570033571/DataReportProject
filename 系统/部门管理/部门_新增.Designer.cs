namespace 系统
{
    partial class 部门_新增
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
            this.txt名称 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt负责人 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt主管 = new System.Windows.Forms.TextBox();
            this.chb是否可用 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chb是否可用);
            this.panel1.Controls.Add(this.txt主管);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt负责人);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt名称);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(341, 85);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // txt名称
            // 
            this.txt名称.Location = new System.Drawing.Point(66, 22);
            this.txt名称.Name = "txt名称";
            this.txt名称.Size = new System.Drawing.Size(100, 21);
            this.txt名称.TabIndex = 1;
            this.txt名称.Tag = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "负责人";
            // 
            // txt负责人
            // 
            this.txt负责人.Location = new System.Drawing.Point(231, 22);
            this.txt负责人.Name = "txt负责人";
            this.txt负责人.Size = new System.Drawing.Size(100, 21);
            this.txt负责人.TabIndex = 3;
            this.txt负责人.Tag = "负责人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "主管";
            // 
            // txt主管
            // 
            this.txt主管.Location = new System.Drawing.Point(66, 49);
            this.txt主管.Name = "txt主管";
            this.txt主管.Size = new System.Drawing.Size(100, 21);
            this.txt主管.TabIndex = 5;
            this.txt主管.Tag = "主管";
            // 
            // chb是否可用
            // 
            this.chb是否可用.AutoSize = true;
            this.chb是否可用.Checked = true;
            this.chb是否可用.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb是否可用.Location = new System.Drawing.Point(257, 52);
            this.chb是否可用.Name = "chb是否可用";
            this.chb是否可用.Size = new System.Drawing.Size(72, 16);
            this.chb是否可用.TabIndex = 6;
            this.chb是否可用.Tag = "状态";
            this.chb是否可用.Text = "是否可用";
            this.chb是否可用.UseVisualStyleBackColor = true;
            // 
            // 部门_新增
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 125);
            this.Name = "部门_新增";
            this.Text = "部门_新增";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb是否可用;
        private System.Windows.Forms.TextBox txt主管;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt负责人;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt名称;
        private System.Windows.Forms.Label label1;
    }
}