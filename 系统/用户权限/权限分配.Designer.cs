namespace 系统
{
    partial class 权限分配
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(权限分配));
            this.il树 = new System.Windows.Forms.ImageList(this.components);
            this.tv1 = new DevExpress.XtraTreeList.TreeList();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tv1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Size = new System.Drawing.Size(284, 376);
            // 
            // il树
            // 
            this.il树.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il树.ImageStream")));
            this.il树.TransparentColor = System.Drawing.Color.Transparent;
            this.il树.Images.SetKeyName(0, "");
            this.il树.Images.SetKeyName(1, "");
            this.il树.Images.SetKeyName(2, "");
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.ImageIndexFieldName = "是否末级";
            this.tv1.KeyFieldName = "fID";
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.OptionsView.ShowColumns = false;
            this.tv1.OptionsView.ShowHorzLines = false;
            this.tv1.OptionsView.ShowIndicator = false;
            this.tv1.OptionsView.ShowVertLines = false;
            this.tv1.ParentFieldName = "上级ID";
            this.tv1.PreviewFieldName = "名称";
            this.tv1.SelectImageList = this.il树;
            this.tv1.Size = new System.Drawing.Size(284, 376);
            this.tv1.TabIndex = 4;
            this.tv1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tv1_AfterCheckNode);
            // 
            // 权限分配
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 416);
            this.Name = "权限分配";
            this.Text = "权限分配";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ImageList il树;
        private DevExpress.XtraTreeList.TreeList tv1;
    }
}