namespace 系统
{
    partial class 流程代理
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
            this.txt代理人 = new System.Windows.Forms.TextBox();
            this.txt被代理人 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn被代理人 = new System.Windows.Forms.Button();
            this.btn代理人 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.chblist = new System.Windows.Forms.CheckedListBox();
            this.chk全选流程 = new System.Windows.Forms.CheckBox();
            this.gbTable = new System.Windows.Forms.GroupBox();
            this.chkTable = new System.Windows.Forms.CheckedListBox();
            this.chk全选数据 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbList.SuspendLayout();
            this.gbTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn代理人);
            this.panel1.Controls.Add(this.btn被代理人);
            this.panel1.Controls.Add(this.txt代理人);
            this.panel1.Controls.Add(this.txt被代理人);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(712, 34);
            this.panel1.Tag = "";
            // 
            // txt代理人
            // 
            this.txt代理人.Location = new System.Drawing.Point(245, 8);
            this.txt代理人.Name = "txt代理人";
            this.txt代理人.ReadOnly = true;
            this.txt代理人.Size = new System.Drawing.Size(100, 21);
            this.txt代理人.TabIndex = 7;
            // 
            // txt被代理人
            // 
            this.txt被代理人.Location = new System.Drawing.Point(66, 8);
            this.txt被代理人.Name = "txt被代理人";
            this.txt被代理人.ReadOnly = true;
            this.txt被代理人.Size = new System.Drawing.Size(100, 21);
            this.txt被代理人.TabIndex = 6;
            this.txt被代理人.TextChanged += new System.EventHandler(this.txt被代理人_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "代理人";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "被代理人";
            // 
            // btn被代理人
            // 
            this.btn被代理人.Location = new System.Drawing.Point(172, 7);
            this.btn被代理人.Name = "btn被代理人";
            this.btn被代理人.Size = new System.Drawing.Size(20, 21);
            this.btn被代理人.TabIndex = 8;
            this.btn被代理人.Text = "选";
            this.btn被代理人.UseVisualStyleBackColor = true;
            this.btn被代理人.Click += new System.EventHandler(this.btn被代理人_Click);
            // 
            // btn代理人
            // 
            this.btn代理人.Location = new System.Drawing.Point(351, 8);
            this.btn代理人.Name = "btn代理人";
            this.btn代理人.Size = new System.Drawing.Size(20, 21);
            this.btn代理人.TabIndex = 9;
            this.btn代理人.Text = "选";
            this.btn代理人.UseVisualStyleBackColor = true;
            this.btn代理人.Click += new System.EventHandler(this.btn代理人_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbTable, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 74);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(712, 314);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.chblist);
            this.gbList.Controls.Add(this.chk全选流程);
            this.gbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbList.Location = new System.Drawing.Point(359, 3);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(350, 308);
            this.gbList.TabIndex = 7;
            this.gbList.TabStop = false;
            this.gbList.Text = "业务流程";
            // 
            // chblist
            // 
            this.chblist.CheckOnClick = true;
            this.chblist.ColumnWidth = 200;
            this.chblist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chblist.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chblist.FormattingEnabled = true;
            this.chblist.Location = new System.Drawing.Point(3, 33);
            this.chblist.MultiColumn = true;
            this.chblist.Name = "chblist";
            this.chblist.Size = new System.Drawing.Size(344, 260);
            this.chblist.TabIndex = 2;
            // 
            // chk全选流程
            // 
            this.chk全选流程.AutoSize = true;
            this.chk全选流程.Dock = System.Windows.Forms.DockStyle.Top;
            this.chk全选流程.Location = new System.Drawing.Point(3, 17);
            this.chk全选流程.Name = "chk全选流程";
            this.chk全选流程.Size = new System.Drawing.Size(344, 16);
            this.chk全选流程.TabIndex = 3;
            this.chk全选流程.Text = "全选";
            this.chk全选流程.UseVisualStyleBackColor = true;
            // 
            // gbTable
            // 
            this.gbTable.Controls.Add(this.chkTable);
            this.gbTable.Controls.Add(this.chk全选数据);
            this.gbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTable.Location = new System.Drawing.Point(3, 3);
            this.gbTable.Name = "gbTable";
            this.gbTable.Size = new System.Drawing.Size(350, 308);
            this.gbTable.TabIndex = 8;
            this.gbTable.TabStop = false;
            this.gbTable.Text = "业务数据";
            // 
            // chkTable
            // 
            this.chkTable.CheckOnClick = true;
            this.chkTable.ColumnWidth = 200;
            this.chkTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTable.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkTable.FormattingEnabled = true;
            this.chkTable.Location = new System.Drawing.Point(3, 33);
            this.chkTable.MultiColumn = true;
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(344, 260);
            this.chkTable.TabIndex = 3;
            // 
            // chk全选数据
            // 
            this.chk全选数据.AutoSize = true;
            this.chk全选数据.Dock = System.Windows.Forms.DockStyle.Top;
            this.chk全选数据.Location = new System.Drawing.Point(3, 17);
            this.chk全选数据.Name = "chk全选数据";
            this.chk全选数据.Size = new System.Drawing.Size(344, 16);
            this.chk全选数据.TabIndex = 4;
            this.chk全选数据.Text = "全选";
            this.chk全选数据.UseVisualStyleBackColor = true;
            // 
            // 流程代理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 388);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "流程代理";
            this.Text = "流程代理";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            this.gbTable.ResumeLayout(false);
            this.gbTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt代理人;
        private System.Windows.Forms.TextBox txt被代理人;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn被代理人;
        private System.Windows.Forms.Button btn代理人;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.CheckedListBox chblist;
        private System.Windows.Forms.GroupBox gbTable;
        private System.Windows.Forms.CheckedListBox chkTable;
        private System.Windows.Forms.CheckBox chk全选流程;
        private System.Windows.Forms.CheckBox chk全选数据;
    }
}