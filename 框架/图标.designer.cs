namespace 框架
{
    partial class 图标
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(图标));
            this.il树 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // il树
            // 
            this.il树.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il树.ImageStream")));
            this.il树.TransparentColor = System.Drawing.Color.Transparent;
            this.il树.Images.SetKeyName(0, "文件夹.png");
            this.il树.Images.SetKeyName(1, "文件.png");
            this.il树.Images.SetKeyName(2, "属性.png");
            this.il树.Images.SetKeyName(3, "打开.png");
            // 
            // 图标
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "图标";
            this.Text = "图标";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList il树;

    }
}