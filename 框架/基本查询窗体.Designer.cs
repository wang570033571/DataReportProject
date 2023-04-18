namespace 框架
{
    partial class 基本查询窗体
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
            this.ts工具栏 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt记录数 = new System.Windows.Forms.MaskedTextBox();
            this.lbl记录数 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts工具栏
            // 
            this.ts工具栏.Location = new System.Drawing.Point(0, 0);
            this.ts工具栏.Name = "ts工具栏";
            this.ts工具栏.Size = new System.Drawing.Size(787, 25);
            this.ts工具栏.TabIndex = 0;
            this.ts工具栏.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt记录数);
            this.panel1.Controls.Add(this.lbl记录数);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 34);
            this.panel1.TabIndex = 2;
            // 
            // txt记录数
            // 
            this.txt记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt记录数.HidePromptOnLeave = true;
            this.txt记录数.Location = new System.Drawing.Point(721, 5);
            this.txt记录数.Mask = "99999999999";
            this.txt记录数.Name = "txt记录数";
            this.txt记录数.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt记录数.Size = new System.Drawing.Size(60, 21);
            this.txt记录数.TabIndex = 7;
            this.txt记录数.Text = "1000";
            this.txt记录数.ValidatingType = typeof(int);
            this.txt记录数.Visible = false;
            // 
            // lbl记录数
            // 
            this.lbl记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl记录数.AutoSize = true;
            this.lbl记录数.Location = new System.Drawing.Point(674, 8);
            this.lbl记录数.Name = "lbl记录数";
            this.lbl记录数.Size = new System.Drawing.Size(41, 12);
            this.lbl记录数.TabIndex = 6;
            this.lbl记录数.Text = "记录数";
            this.lbl记录数.Visible = false;
            // 
            // 基本查询窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts工具栏);
            this.Name = "基本查询窗体";
            this.Text = "基本查询窗体";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts工具栏;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txt记录数;
        private System.Windows.Forms.Label lbl记录数;
    }
}