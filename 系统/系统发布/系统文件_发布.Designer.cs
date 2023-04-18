namespace 系统
{
    partial class 系统文件_发布
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
            this.cb强制更新 = new System.Windows.Forms.CheckBox();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.txt更新说明 = new System.Windows.Forms.TextBox();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.lst1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.grp1.SuspendLayout();
            this.grp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb强制更新);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(488, 31);
            // 
            // cb强制更新
            // 
            this.cb强制更新.AutoSize = true;
            this.cb强制更新.Location = new System.Drawing.Point(12, 9);
            this.cb强制更新.Name = "cb强制更新";
            this.cb强制更新.Size = new System.Drawing.Size(96, 16);
            this.cb强制更新.TabIndex = 5;
            this.cb强制更新.Text = "是否强制更新";
            this.cb强制更新.UseVisualStyleBackColor = true;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.txt更新说明);
            this.grp1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp1.Location = new System.Drawing.Point(0, 228);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(488, 100);
            this.grp1.TabIndex = 3;
            this.grp1.TabStop = false;
            this.grp1.Text = "更新说明";
            // 
            // txt更新说明
            // 
            this.txt更新说明.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt更新说明.Location = new System.Drawing.Point(3, 17);
            this.txt更新说明.Multiline = true;
            this.txt更新说明.Name = "txt更新说明";
            this.txt更新说明.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt更新说明.Size = new System.Drawing.Size(482, 80);
            this.txt更新说明.TabIndex = 5;
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.lst1);
            this.grp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp2.Location = new System.Drawing.Point(0, 71);
            this.grp2.Name = "grp2";
            this.grp2.Size = new System.Drawing.Size(488, 157);
            this.grp2.TabIndex = 4;
            this.grp2.TabStop = false;
            this.grp2.Text = "文件清单";
            // 
            // lst1
            // 
            this.lst1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst1.FormattingEnabled = true;
            this.lst1.ItemHeight = 12;
            this.lst1.Location = new System.Drawing.Point(3, 17);
            this.lst1.Name = "lst1";
            this.lst1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst1.Size = new System.Drawing.Size(482, 136);
            this.lst1.TabIndex = 3;
            // 
            // 系统文件_发布
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 328);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.grp1);
            this.Name = "系统文件_发布";
            this.Text = "系统文件_发布";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grp1, 0);
            this.Controls.SetChildIndex(this.grp2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.grp2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb强制更新;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.TextBox txt更新说明;
        private System.Windows.Forms.GroupBox grp2;
        private System.Windows.Forms.ListBox lst1;
    }
}