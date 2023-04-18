namespace 框架
{
    partial class 消息窗体
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btn发送报告 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.btn详细 = new System.Windows.Forms.Button();
            this.txt信息 = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txt类型 = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.txtMessageDetail = new System.Windows.Forms.TextBox();
            this.tabPageProperty = new System.Windows.Forms.TabPage();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMessage.SuspendLayout();
            this.tabPageProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btn发送报告);
            this.pnlTop.Controls.Add(this.btn确定);
            this.pnlTop.Controls.Add(this.btn详细);
            this.pnlTop.Controls.Add(this.txt信息);
            this.pnlTop.Controls.Add(this.lblMessage);
            this.pnlTop.Controls.Add(this.txt类型);
            this.pnlTop.Controls.Add(this.lblType);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(494, 176);
            this.pnlTop.TabIndex = 0;
            // 
            // btn发送报告
            // 
            this.btn发送报告.Enabled = false;
            this.btn发送报告.Location = new System.Drawing.Point(407, 142);
            this.btn发送报告.Name = "btn发送报告";
            this.btn发送报告.Size = new System.Drawing.Size(75, 23);
            this.btn发送报告.TabIndex = 8;
            this.btn发送报告.Text = "发送报告";
            this.btn发送报告.UseVisualStyleBackColor = true;
            // 
            // btn确定
            // 
            this.btn确定.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn确定.Location = new System.Drawing.Point(247, 142);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(75, 23);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定(&O)";
            // 
            // btn详细
            // 
            this.btn详细.Location = new System.Drawing.Point(327, 142);
            this.btn详细.Name = "btn详细";
            this.btn详细.Size = new System.Drawing.Size(75, 23);
            this.btn详细.TabIndex = 6;
            this.btn详细.Text = "详细 >>";
            // 
            // txt信息
            // 
            this.txt信息.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt信息.BackColor = System.Drawing.SystemColors.Control;
            this.txt信息.Location = new System.Drawing.Point(56, 40);
            this.txt信息.Multiline = true;
            this.txt信息.Name = "txt信息";
            this.txt信息.ReadOnly = true;
            this.txt信息.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt信息.Size = new System.Drawing.Size(430, 96);
            this.txt信息.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(8, 40);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 12);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "信息：";
            // 
            // txt类型
            // 
            this.txt类型.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt类型.BackColor = System.Drawing.SystemColors.Control;
            this.txt类型.Location = new System.Drawing.Point(56, 8);
            this.txt类型.Name = "txt类型";
            this.txt类型.ReadOnly = true;
            this.txt类型.Size = new System.Drawing.Size(430, 21);
            this.txt类型.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(8, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 12);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "类型：";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMessage);
            this.tabControl.Controls.Add(this.tabPageProperty);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 176);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(494, 190);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.Controls.Add(this.txtMessageDetail);
            this.tabPageMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Size = new System.Drawing.Size(486, 164);
            this.tabPageMessage.TabIndex = 0;
            this.tabPageMessage.Text = "Message";
            // 
            // txtMessageDetail
            // 
            this.txtMessageDetail.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessageDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageDetail.Location = new System.Drawing.Point(0, 0);
            this.txtMessageDetail.Multiline = true;
            this.txtMessageDetail.Name = "txtMessageDetail";
            this.txtMessageDetail.ReadOnly = true;
            this.txtMessageDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessageDetail.Size = new System.Drawing.Size(486, 164);
            this.txtMessageDetail.TabIndex = 8;
            // 
            // tabPageProperty
            // 
            this.tabPageProperty.Controls.Add(this.propertyGrid);
            this.tabPageProperty.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperty.Name = "tabPageProperty";
            this.tabPageProperty.Size = new System.Drawing.Size(486, 164);
            this.tabPageProperty.TabIndex = 1;
            this.tabPageProperty.Text = "Property";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid.Size = new System.Drawing.Size(486, 164);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // 消息窗体
            // 
            this.AcceptButton = this.btn确定;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btn确定;
            this.ClientSize = new System.Drawing.Size(494, 366);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "消息窗体";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息提示";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.消息提示_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageMessage.ResumeLayout(false);
            this.tabPageMessage.PerformLayout();
            this.tabPageProperty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txt信息;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txt类型;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.TabPage tabPageProperty;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TextBox txtMessageDetail;
        private System.Windows.Forms.Button btn详细;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.Button btn发送报告;
    }
}