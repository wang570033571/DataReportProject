namespace 系统
{
    partial class 加密解密
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(加密解密));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn解密 = new System.Windows.Forms.Button();
            this.btn加密 = new System.Windows.Forms.Button();
            this.lbl密钥 = new System.Windows.Forms.Label();
            this.txt密钥 = new System.Windows.Forms.TextBox();
            this.scData = new System.Windows.Forms.SplitContainer();
            this.gpb转换前 = new System.Windows.Forms.GroupBox();
            this.txt转换前 = new System.Windows.Forms.TextBox();
            this.gpb转换后 = new System.Windows.Forms.GroupBox();
            this.txt转换后 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.scData.Panel1.SuspendLayout();
            this.scData.Panel2.SuspendLayout();
            this.scData.SuspendLayout();
            this.gpb转换前.SuspendLayout();
            this.gpb转换后.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn解密);
            this.panel1.Controls.Add(this.btn加密);
            this.panel1.Controls.Add(this.lbl密钥);
            this.panel1.Controls.Add(this.txt密钥);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 40);
            this.panel1.TabIndex = 5;
            // 
            // btn解密
            // 
            this.btn解密.Location = new System.Drawing.Point(93, 7);
            this.btn解密.Name = "btn解密";
            this.btn解密.Size = new System.Drawing.Size(75, 23);
            this.btn解密.TabIndex = 7;
            this.btn解密.Text = "解密";
            this.btn解密.UseVisualStyleBackColor = true;
            this.btn解密.Click += new System.EventHandler(this.btn解密_Click);
            // 
            // btn加密
            // 
            this.btn加密.Location = new System.Drawing.Point(12, 7);
            this.btn加密.Name = "btn加密";
            this.btn加密.Size = new System.Drawing.Size(75, 23);
            this.btn加密.TabIndex = 6;
            this.btn加密.Text = "加密";
            this.btn加密.UseVisualStyleBackColor = true;
            this.btn加密.Click += new System.EventHandler(this.btn加密_Click);
            // 
            // lbl密钥
            // 
            this.lbl密钥.AutoSize = true;
            this.lbl密钥.Location = new System.Drawing.Point(174, 12);
            this.lbl密钥.Name = "lbl密钥";
            this.lbl密钥.Size = new System.Drawing.Size(29, 12);
            this.lbl密钥.TabIndex = 5;
            this.lbl密钥.Text = "密钥";
            // 
            // txt密钥
            // 
            this.txt密钥.BackColor = System.Drawing.SystemColors.Info;
            this.txt密钥.Location = new System.Drawing.Point(209, 9);
            this.txt密钥.MaxLength = 8;
            this.txt密钥.Name = "txt密钥";
            this.txt密钥.ReadOnly = true;
            this.txt密钥.Size = new System.Drawing.Size(116, 21);
            this.txt密钥.TabIndex = 4;
            this.txt密钥.Text = "sfiecpmc";
            this.txt密钥.UseSystemPasswordChar = true;
            // 
            // scData
            // 
            this.scData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scData.Location = new System.Drawing.Point(0, 40);
            this.scData.Name = "scData";
            this.scData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scData.Panel1
            // 
            this.scData.Panel1.Controls.Add(this.gpb转换前);
            // 
            // scData.Panel2
            // 
            this.scData.Panel2.Controls.Add(this.gpb转换后);
            this.scData.Size = new System.Drawing.Size(347, 233);
            this.scData.SplitterDistance = 157;
            this.scData.TabIndex = 6;
            // 
            // gpb转换前
            // 
            this.gpb转换前.Controls.Add(this.txt转换前);
            this.gpb转换前.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb转换前.Location = new System.Drawing.Point(0, 0);
            this.gpb转换前.Name = "gpb转换前";
            this.gpb转换前.Size = new System.Drawing.Size(347, 157);
            this.gpb转换前.TabIndex = 1;
            this.gpb转换前.TabStop = false;
            this.gpb转换前.Text = "转换前";
            // 
            // txt转换前
            // 
            this.txt转换前.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt转换前.Location = new System.Drawing.Point(3, 17);
            this.txt转换前.Multiline = true;
            this.txt转换前.Name = "txt转换前";
            this.txt转换前.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt转换前.Size = new System.Drawing.Size(341, 137);
            this.txt转换前.TabIndex = 1;
            // 
            // gpb转换后
            // 
            this.gpb转换后.Controls.Add(this.txt转换后);
            this.gpb转换后.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb转换后.Location = new System.Drawing.Point(0, 0);
            this.gpb转换后.Name = "gpb转换后";
            this.gpb转换后.Size = new System.Drawing.Size(347, 72);
            this.gpb转换后.TabIndex = 1;
            this.gpb转换后.TabStop = false;
            this.gpb转换后.Text = "转换后";
            // 
            // txt转换后
            // 
            this.txt转换后.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt转换后.Location = new System.Drawing.Point(3, 17);
            this.txt转换后.Multiline = true;
            this.txt转换后.Name = "txt转换后";
            this.txt转换后.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt转换后.Size = new System.Drawing.Size(341, 52);
            this.txt转换后.TabIndex = 1;
            // 
            // 加密解密
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 273);
            this.Controls.Add(this.scData);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "加密解密";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加密解密";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.scData.Panel1.ResumeLayout(false);
            this.scData.Panel2.ResumeLayout(false);
            this.scData.ResumeLayout(false);
            this.gpb转换前.ResumeLayout(false);
            this.gpb转换前.PerformLayout();
            this.gpb转换后.ResumeLayout(false);
            this.gpb转换后.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn解密;
        private System.Windows.Forms.Button btn加密;
        private System.Windows.Forms.Label lbl密钥;
        private System.Windows.Forms.TextBox txt密钥;
        private System.Windows.Forms.SplitContainer scData;
        private System.Windows.Forms.GroupBox gpb转换前;
        private System.Windows.Forms.TextBox txt转换前;
        private System.Windows.Forms.GroupBox gpb转换后;
        private System.Windows.Forms.TextBox txt转换后;

    }
}