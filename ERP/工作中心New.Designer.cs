namespace ERP
{
    partial class 工作中心New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(工作中心));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("待处理(0)", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("待完成(0)", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("已处理", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("已完成", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("已中止", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("审批", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("成功", 1, 1);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("失败", 1, 1);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("超时", 1, 1);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("日志", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("收藏");
            this.sc窗体 = new System.Windows.Forms.SplitContainer();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.il树 = new System.Windows.Forms.ImageList();
            this.sc任务菜单 = new System.Windows.Forms.SplitContainer();
            this.tv2 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb日期 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tp任务 = new System.Windows.Forms.TabPage();
            this.sc任务 = new System.Windows.Forms.SplitContainer();
            this.sb进度 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sc任务汇总 = new System.Windows.Forms.SplitContainer();
            this.gc任务汇总 = new DevExpress.XtraGrid.GridControl();
            this.gv任务汇总 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc任务 = new DevExpress.XtraGrid.GridControl();
            this.gv任务 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbl流程进度 = new System.Windows.Forms.Label();
            this.sc任务明细 = new System.Windows.Forms.SplitContainer();
            this.gc任务表头 = new DevExpress.XtraGrid.GridControl();
            this.gv任务表头 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc任务表体 = new DevExpress.XtraGrid.GridControl();
            this.gv任务表体 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn转发 = new System.Windows.Forms.Button();
            this.txt批注 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn单证 = new System.Windows.Forms.Button();
            this.btn确认 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb驳回 = new System.Windows.Forms.RadioButton();
            this.rb同意 = new System.Windows.Forms.RadioButton();
            this.tp日志 = new System.Windows.Forms.TabPage();
            this.sc日志 = new System.Windows.Forms.SplitContainer();
            this.gc日志 = new DevExpress.XtraGrid.GridControl();
            this.gv日志 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt日志 = new System.Windows.Forms.TextBox();
            this.流程名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.流程节点 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.内容 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.发起人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.参与者 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.审批意见 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.审批日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.单证 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.表头ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tip = new System.Windows.Forms.ToolTip();
            this.tm任务 = new System.Windows.Forms.Timer();
            this.sc窗体.Panel1.SuspendLayout();
            this.sc窗体.Panel2.SuspendLayout();
            this.sc窗体.SuspendLayout();
            this.sc任务菜单.Panel1.SuspendLayout();
            this.sc任务菜单.Panel2.SuspendLayout();
            this.sc任务菜单.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tc1.SuspendLayout();
            this.tp任务.SuspendLayout();
            this.sc任务.Panel1.SuspendLayout();
            this.sc任务.Panel2.SuspendLayout();
            this.sc任务.SuspendLayout();
            this.sb进度.SuspendLayout();
            this.sc任务汇总.Panel1.SuspendLayout();
            this.sc任务汇总.Panel2.SuspendLayout();
            this.sc任务汇总.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务汇总)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务汇总)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.sc任务明细.Panel1.SuspendLayout();
            this.sc任务明细.Panel2.SuspendLayout();
            this.sc任务明细.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务表头)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务表头)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务表体)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务表体)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tp日志.SuspendLayout();
            this.sc日志.Panel1.SuspendLayout();
            this.sc日志.Panel2.SuspendLayout();
            this.sc日志.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc日志)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv日志)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sc窗体
            // 
            this.sc窗体.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc窗体.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc窗体.Location = new System.Drawing.Point(0, 0);
            this.sc窗体.Name = "sc窗体";
            // 
            // sc窗体.Panel1
            // 
            this.sc窗体.Panel1.Controls.Add(this.tv1);
            // 
            // sc窗体.Panel2
            // 
            this.sc窗体.Panel2.Controls.Add(this.sc任务菜单);
            this.sc窗体.Size = new System.Drawing.Size(900, 548);
            this.sc窗体.SplitterDistance = 143;
            this.sc窗体.TabIndex = 0;
            // 
            // tv1
            // 
            this.tv1.AllowDrop = true;
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.ImageIndex = 0;
            this.tv1.ImageList = this.il树;
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.SelectedImageIndex = 0;
            this.tv1.Size = new System.Drawing.Size(143, 548);
            this.tv1.TabIndex = 0;
            this.tv1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tv1_ItemDrag);
            this.tv1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseDoubleClick);
            this.tv1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv1_DragDrop);
            this.tv1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv1_DragEnter);
            // 
            // il树
            // 
            this.il树.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il树.ImageStream")));
            this.il树.TransparentColor = System.Drawing.Color.Transparent;
            this.il树.Images.SetKeyName(0, "文件夹.png");
            this.il树.Images.SetKeyName(1, "文件.png");
            this.il树.Images.SetKeyName(2, "属性.png");
            this.il树.Images.SetKeyName(3, "打开.png");
            this.il树.Images.SetKeyName(4, "喇叭.png");
            this.il树.Images.SetKeyName(5, "PAS.ico");
            // 
            // sc任务菜单
            // 
            this.sc任务菜单.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc任务菜单.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc任务菜单.Location = new System.Drawing.Point(0, 0);
            this.sc任务菜单.Name = "sc任务菜单";
            // 
            // sc任务菜单.Panel1
            // 
            this.sc任务菜单.Panel1.Controls.Add(this.tv2);
            this.sc任务菜单.Panel1.Controls.Add(this.panel1);
            // 
            // sc任务菜单.Panel2
            // 
            this.sc任务菜单.Panel2.Controls.Add(this.tc1);
            this.sc任务菜单.Size = new System.Drawing.Size(753, 548);
            this.sc任务菜单.SplitterDistance = 143;
            this.sc任务菜单.TabIndex = 0;
            // 
            // tv2
            // 
            this.tv2.AllowDrop = true;
            this.tv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv2.ImageIndex = 0;
            this.tv2.ImageList = this.il树;
            this.tv2.Location = new System.Drawing.Point(0, 32);
            this.tv2.Name = "tv2";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "待处理";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "待处理(0)";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "待完成";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "待完成(0)";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "已处理";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "已处理";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "已完成";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "已完成";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "已中止";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "已中止";
            treeNode6.ImageIndex = 3;
            treeNode6.Name = "审批";
            treeNode6.SelectedImageIndex = 3;
            treeNode6.Text = "审批";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "成功";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Text = "成功";
            treeNode8.ImageIndex = 1;
            treeNode8.Name = "失败";
            treeNode8.SelectedImageIndex = 1;
            treeNode8.Text = "失败";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "超时";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Text = "超时";
            treeNode10.ImageIndex = 3;
            treeNode10.Name = "日志";
            treeNode10.SelectedImageIndex = 3;
            treeNode10.Text = "日志";
            treeNode11.Name = "收藏";
            treeNode11.Text = "收藏";
            this.tv2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode10,
            treeNode11});
            this.tv2.SelectedImageIndex = 0;
            this.tv2.Size = new System.Drawing.Size(143, 516);
            this.tv2.TabIndex = 1;
            this.tv2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tv2_ItemDrag);
            this.tv2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv2_NodeMouseClick);
            this.tv2.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv2_DragDrop);
            this.tv2.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv2_DragEnter);
            this.tv2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv2_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb日期);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 32);
            this.panel1.TabIndex = 0;
            // 
            // cbb日期
            // 
            this.cbb日期.FormattingEnabled = true;
            this.cbb日期.Location = new System.Drawing.Point(38, 6);
            this.cbb日期.MaxDropDownItems = 50;
            this.cbb日期.Name = "cbb日期";
            this.cbb日期.Size = new System.Drawing.Size(100, 20);
            this.cbb日期.TabIndex = 1;
            this.cbb日期.DropDown += new System.EventHandler(this.cbb日期_DropDown);
            this.cbb日期.SelectedIndexChanged += new System.EventHandler(this.cbb日期_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tp任务);
            this.tc1.Controls.Add(this.tp日志);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.Location = new System.Drawing.Point(0, 0);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(606, 548);
            this.tc1.TabIndex = 0;
            this.tc1.SelectedIndexChanged += new System.EventHandler(this.tc1_SelectedIndexChanged);
            // 
            // tp任务
            // 
            this.tp任务.Controls.Add(this.sc任务);
            this.tp任务.Controls.Add(this.panel2);
            this.tp任务.Location = new System.Drawing.Point(4, 22);
            this.tp任务.Name = "tp任务";
            this.tp任务.Padding = new System.Windows.Forms.Padding(3);
            this.tp任务.Size = new System.Drawing.Size(598, 522);
            this.tp任务.TabIndex = 0;
            this.tp任务.Text = "审批";
            this.tp任务.UseVisualStyleBackColor = true;
            // 
            // sc任务
            // 
            this.sc任务.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc任务.Location = new System.Drawing.Point(3, 47);
            this.sc任务.Name = "sc任务";
            this.sc任务.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc任务.Panel1
            // 
            this.sc任务.Panel1.Controls.Add(this.sb进度);
            this.sc任务.Panel1.Controls.Add(this.sc任务汇总);
            this.sc任务.Panel1.Controls.Add(this.lbl流程进度);
            // 
            // sc任务.Panel2
            // 
            this.sc任务.Panel2.Controls.Add(this.sc任务明细);
            this.sc任务.Size = new System.Drawing.Size(592, 472);
            this.sc任务.SplitterDistance = 264;
            this.sc任务.TabIndex = 1;
            // 
            // sb进度
            // 
            this.sb进度.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sb进度.Location = new System.Drawing.Point(0, 247);
            this.sb进度.Name = "sb进度";
            this.sb进度.Size = new System.Drawing.Size(678, 22);
            this.sb进度.TabIndex = 0;
            this.sb进度.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "流程进度:";
            // 
            // sc任务汇总
            // 
            this.sc任务汇总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc任务汇总.Location = new System.Drawing.Point(0, 0);
            this.sc任务汇总.Name = "sc任务汇总";
            // 
            // sc任务汇总.Panel1
            // 
            this.sc任务汇总.Panel1.Controls.Add(this.gc任务汇总);
            // 
            // sc任务汇总.Panel2
            // 
            this.sc任务汇总.Panel2.Controls.Add(this.gc任务);
            this.sc任务汇总.Size = new System.Drawing.Size(592, 247);
            this.sc任务汇总.SplitterDistance = 163;
            this.sc任务汇总.TabIndex = 3;
            // 
            // gc任务汇总
            // 
            this.gc任务汇总.ContextMenu = this.cmData;
            this.gc任务汇总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc任务汇总.Location = new System.Drawing.Point(0, 0);
            this.gc任务汇总.MainView = this.gv任务汇总;
            this.gc任务汇总.Name = "gc任务汇总";
            this.gc任务汇总.Size = new System.Drawing.Size(163, 247);
            this.gc任务汇总.TabIndex = 4;
            this.gc任务汇总.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv任务汇总,
            this.gridView6});
            this.gc任务汇总.Click += new System.EventHandler(this.gc任务汇总_Click);
            // 
            // gv任务汇总
            // 
            this.gv任务汇总.GridControl = this.gc任务汇总;
            this.gv任务汇总.IndicatorWidth = 50;
            this.gv任务汇总.Name = "gv任务汇总";
            this.gv任务汇总.OptionsSelection.MultiSelect = true;
            this.gv任务汇总.OptionsView.ColumnAutoWidth = false;
            this.gv任务汇总.OptionsView.RowAutoHeight = true;
            this.gv任务汇总.OptionsView.ShowFooter = true;
            this.gv任务汇总.OptionsView.ShowGroupPanel = false;
            this.gv任务汇总.Tag = "v任务汇总";
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gc任务汇总;
            this.gridView6.Name = "gridView6";
            // 
            // gc任务
            // 
            this.gc任务.ContextMenu = this.cmData;
            this.gc任务.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc任务.Location = new System.Drawing.Point(0, 0);
            this.gc任务.MainView = this.gv任务;
            this.gc任务.Name = "gc任务";
            this.gc任务.Size = new System.Drawing.Size(425, 247);
            this.gc任务.TabIndex = 3;
            this.gc任务.Tag = "";
            this.tip.SetToolTip(this.gc任务, "任务");
            this.gc任务.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv任务,
            this.gridView5});
            this.gc任务.Click += new System.EventHandler(this.gc任务_Click);
            this.gc任务.DoubleClick += new System.EventHandler(this.gc任务_DoubleClick);
            // 
            // gv任务
            // 
            this.gv任务.GridControl = this.gc任务;
            this.gv任务.IndicatorWidth = 50;
            this.gv任务.Name = "gv任务";
            this.gv任务.OptionsSelection.MultiSelect = true;
            this.gv任务.OptionsView.ColumnAutoWidth = false;
            this.gv任务.OptionsView.RowAutoHeight = true;
            this.gv任务.OptionsView.ShowFooter = true;
            this.gv任务.OptionsView.ShowGroupPanel = false;
            this.gv任务.Tag = "v任务";
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gc任务;
            this.gridView5.Name = "gridView5";
            // 
            // lbl流程进度
            // 
            this.lbl流程进度.BackColor = System.Drawing.Color.Transparent;
            this.lbl流程进度.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl流程进度.Location = new System.Drawing.Point(0, 247);
            this.lbl流程进度.Name = "lbl流程进度";
            this.lbl流程进度.Size = new System.Drawing.Size(592, 17);
            this.lbl流程进度.TabIndex = 4;
            this.lbl流程进度.Text = "流程进度:";
            this.lbl流程进度.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sc任务明细
            // 
            this.sc任务明细.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc任务明细.Location = new System.Drawing.Point(0, 0);
            this.sc任务明细.Name = "sc任务明细";
            this.sc任务明细.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc任务明细.Panel1
            // 
            this.sc任务明细.Panel1.Controls.Add(this.gc任务表头);
            // 
            // sc任务明细.Panel2
            // 
            this.sc任务明细.Panel2.Controls.Add(this.gc任务表体);
            this.sc任务明细.Size = new System.Drawing.Size(592, 204);
            this.sc任务明细.SplitterDistance = 74;
            this.sc任务明细.TabIndex = 1;
            // 
            // gc任务表头
            // 
            this.gc任务表头.ContextMenu = this.cmData;
            this.gc任务表头.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc任务表头.Location = new System.Drawing.Point(0, 0);
            this.gc任务表头.MainView = this.gv任务表头;
            this.gc任务表头.Name = "gc任务表头";
            this.gc任务表头.Size = new System.Drawing.Size(592, 74);
            this.gc任务表头.TabIndex = 1;
            this.gc任务表头.Tag = "";
            this.gc任务表头.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv任务表头,
            this.gridView4});
            // 
            // gv任务表头
            // 
            this.gv任务表头.GridControl = this.gc任务表头;
            this.gv任务表头.IndicatorWidth = 50;
            this.gv任务表头.Name = "gv任务表头";
            this.gv任务表头.OptionsBehavior.ReadOnly = true;
            this.gv任务表头.OptionsSelection.MultiSelect = true;
            this.gv任务表头.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gv任务表头.OptionsView.ColumnAutoWidth = false;
            this.gv任务表头.OptionsView.RowAutoHeight = true;
            this.gv任务表头.OptionsView.ShowFooter = true;
            this.gv任务表头.OptionsView.ShowGroupPanel = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gc任务表头;
            this.gridView4.Name = "gridView4";
            // 
            // gc任务表体
            // 
            this.gc任务表体.ContextMenu = this.cmData;
            this.gc任务表体.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc任务表体.Location = new System.Drawing.Point(0, 0);
            this.gc任务表体.MainView = this.gv任务表体;
            this.gc任务表体.Name = "gc任务表体";
            this.gc任务表体.Size = new System.Drawing.Size(592, 126);
            this.gc任务表体.TabIndex = 0;
            this.gc任务表体.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv任务表体,
            this.gridView3});
            // 
            // gv任务表体
            // 
            this.gv任务表体.GridControl = this.gc任务表体;
            this.gv任务表体.IndicatorWidth = 50;
            this.gv任务表体.Name = "gv任务表体";
            this.gv任务表体.OptionsBehavior.ReadOnly = true;
            this.gv任务表体.OptionsSelection.MultiSelect = true;
            this.gv任务表体.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gv任务表体.OptionsView.ColumnAutoWidth = false;
            this.gv任务表体.OptionsView.RowAutoHeight = true;
            this.gv任务表体.OptionsView.ShowFooter = true;
            this.gv任务表体.OptionsView.ShowGroupPanel = false;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gc任务表体;
            this.gridView3.Name = "gridView3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn转发);
            this.panel2.Controls.Add(this.txt批注);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn单证);
            this.panel2.Controls.Add(this.btn确认);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 44);
            this.panel2.TabIndex = 0;
            // 
            // btn转发
            // 
            this.btn转发.Location = new System.Drawing.Point(236, 10);
            this.btn转发.Name = "btn转发";
            this.btn转发.Size = new System.Drawing.Size(50, 23);
            this.btn转发.TabIndex = 5;
            this.btn转发.Text = "转发";
            this.btn转发.UseVisualStyleBackColor = true;
            this.btn转发.Visible = false;
            this.btn转发.Click += new System.EventHandler(this.btn转发_Click);
            // 
            // txt批注
            // 
            this.txt批注.Location = new System.Drawing.Point(325, 12);
            this.txt批注.Name = "txt批注";
            this.txt批注.Size = new System.Drawing.Size(262, 21);
            this.txt批注.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "批注";
            // 
            // btn单证
            // 
            this.btn单证.Location = new System.Drawing.Point(180, 10);
            this.btn单证.Name = "btn单证";
            this.btn单证.Size = new System.Drawing.Size(50, 23);
            this.btn单证.TabIndex = 2;
            this.btn单证.Text = "单证";
            this.btn单证.UseVisualStyleBackColor = true;
            this.btn单证.Click += new System.EventHandler(this.btn单证_Click);
            // 
            // btn确认
            // 
            this.btn确认.Location = new System.Drawing.Point(124, 10);
            this.btn确认.Name = "btn确认";
            this.btn确认.Size = new System.Drawing.Size(50, 23);
            this.btn确认.TabIndex = 1;
            this.btn确认.Text = "确认";
            this.btn确认.UseVisualStyleBackColor = true;
            this.btn确认.Click += new System.EventHandler(this.btn确认_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rb驳回);
            this.panel3.Controls.Add(this.rb同意);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 28);
            this.panel3.TabIndex = 0;
            // 
            // rb驳回
            // 
            this.rb驳回.AutoSize = true;
            this.rb驳回.Location = new System.Drawing.Point(56, 5);
            this.rb驳回.Name = "rb驳回";
            this.rb驳回.Size = new System.Drawing.Size(47, 16);
            this.rb驳回.TabIndex = 1;
            this.rb驳回.Text = "驳回";
            this.rb驳回.UseVisualStyleBackColor = true;
            // 
            // rb同意
            // 
            this.rb同意.AutoSize = true;
            this.rb同意.Checked = true;
            this.rb同意.Location = new System.Drawing.Point(3, 5);
            this.rb同意.Name = "rb同意";
            this.rb同意.Size = new System.Drawing.Size(47, 16);
            this.rb同意.TabIndex = 0;
            this.rb同意.TabStop = true;
            this.rb同意.Text = "同意";
            this.rb同意.UseVisualStyleBackColor = true;
            // 
            // tp日志
            // 
            this.tp日志.Controls.Add(this.sc日志);
            this.tp日志.Location = new System.Drawing.Point(4, 22);
            this.tp日志.Name = "tp日志";
            this.tp日志.Padding = new System.Windows.Forms.Padding(3);
            this.tp日志.Size = new System.Drawing.Size(598, 522);
            this.tp日志.TabIndex = 2;
            this.tp日志.Text = "日志";
            this.tp日志.UseVisualStyleBackColor = true;
            // 
            // sc日志
            // 
            this.sc日志.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc日志.Location = new System.Drawing.Point(3, 3);
            this.sc日志.Name = "sc日志";
            this.sc日志.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc日志.Panel1
            // 
            this.sc日志.Panel1.Controls.Add(this.gc日志);
            // 
            // sc日志.Panel2
            // 
            this.sc日志.Panel2.Controls.Add(this.txt日志);
            this.sc日志.Size = new System.Drawing.Size(592, 516);
            this.sc日志.SplitterDistance = 375;
            this.sc日志.TabIndex = 2;
            // 
            // gc日志
            // 
            this.gc日志.ContextMenu = this.cmData;
            this.gc日志.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc日志.Location = new System.Drawing.Point(0, 0);
            this.gc日志.MainView = this.gv日志;
            this.gc日志.Name = "gc日志";
            this.gc日志.Size = new System.Drawing.Size(592, 375);
            this.gc日志.TabIndex = 1;
            this.gc日志.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv日志,
            this.gridView1});
            this.gc日志.Click += new System.EventHandler(this.gc日志_Click);
            // 
            // gv日志
            // 
            this.gv日志.GridControl = this.gc日志;
            this.gv日志.IndicatorWidth = 50;
            this.gv日志.Name = "gv日志";
            this.gv日志.OptionsSelection.MultiSelect = true;
            this.gv日志.OptionsView.ColumnAutoWidth = false;
            this.gv日志.OptionsView.RowAutoHeight = true;
            this.gv日志.OptionsView.ShowFooter = true;
            this.gv日志.OptionsView.ShowGroupPanel = false;
            this.gv日志.Tag = "v日志";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gc日志;
            this.gridView1.Name = "gridView1";
            // 
            // txt日志
            // 
            this.txt日志.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt日志.Location = new System.Drawing.Point(0, 0);
            this.txt日志.Multiline = true;
            this.txt日志.Name = "txt日志";
            this.txt日志.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt日志.Size = new System.Drawing.Size(592, 137);
            this.txt日志.TabIndex = 2;
            // 
            // 流程名称
            // 
            this.流程名称.Caption = "流程名称";
            this.流程名称.FieldName = "流程名称";
            this.流程名称.Name = "流程名称";
            this.流程名称.Visible = true;
            this.流程名称.VisibleIndex = 0;
            // 
            // 流程节点
            // 
            this.流程节点.Caption = "流程节点";
            this.流程节点.FieldName = "流程节点";
            this.流程节点.Name = "流程节点";
            this.流程节点.Visible = true;
            this.流程节点.VisibleIndex = 1;
            this.流程节点.Width = 113;
            // 
            // 内容
            // 
            this.内容.Caption = "内容";
            this.内容.FieldName = "内容";
            this.内容.Name = "内容";
            this.内容.Visible = true;
            this.内容.VisibleIndex = 2;
            this.内容.Width = 195;
            // 
            // 发起人
            // 
            this.发起人.Caption = "发起人";
            this.发起人.FieldName = "发起人";
            this.发起人.Name = "发起人";
            this.发起人.Visible = true;
            this.发起人.VisibleIndex = 3;
            // 
            // 单号
            // 
            this.单号.Caption = "单号";
            this.单号.FieldName = "单号";
            this.单号.Name = "单号";
            this.单号.Visible = true;
            this.单号.VisibleIndex = 4;
            // 
            // 参与者
            // 
            this.参与者.Caption = "参与者";
            this.参与者.FieldName = "参与者";
            this.参与者.Name = "参与者";
            this.参与者.Visible = true;
            this.参与者.VisibleIndex = 5;
            // 
            // 审批意见
            // 
            this.审批意见.Caption = "审批意见";
            this.审批意见.FieldName = "审批意见";
            this.审批意见.Name = "审批意见";
            this.审批意见.Visible = true;
            this.审批意见.VisibleIndex = 6;
            // 
            // 审批日期
            // 
            this.审批日期.Caption = "审批日期";
            this.审批日期.FieldName = "审批日期";
            this.审批日期.Name = "审批日期";
            this.审批日期.Visible = true;
            this.审批日期.VisibleIndex = 7;
            // 
            // 单证
            // 
            this.单证.Caption = "单证";
            this.单证.FieldName = "单证";
            this.单证.Name = "单证";
            this.单证.Visible = true;
            this.单证.VisibleIndex = 8;
            // 
            // 表头ID
            // 
            this.表头ID.Caption = "表头ID";
            this.表头ID.FieldNameSortGroup = "表头ID";
            this.表头ID.Name = "表头ID";
            this.表头ID.Visible = true;
            this.表头ID.VisibleIndex = 9;
            // 
            // fID
            // 
            this.fID.Caption = "fID";
            this.fID.FieldName = "fID";
            this.fID.Name = "fID";
            this.fID.Visible = true;
            this.fID.VisibleIndex = 10;
            // 
            // tm任务
            // 
            this.tm任务.Enabled = true;
            this.tm任务.Interval = 10000;
            this.tm任务.Tick += new System.EventHandler(this.tm任务_Tick);
            // 
            // 工作中心
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 548);
            this.Controls.Add(this.sc窗体);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "工作中心";
            this.Text = "工作中心";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.工作中心_FormClosed);
            this.Shown += new System.EventHandler(this.工作中心_Shown);
            this.sc窗体.Panel1.ResumeLayout(false);
            this.sc窗体.Panel2.ResumeLayout(false);
            this.sc窗体.ResumeLayout(false);
            this.sc任务菜单.Panel1.ResumeLayout(false);
            this.sc任务菜单.Panel2.ResumeLayout(false);
            this.sc任务菜单.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tc1.ResumeLayout(false);
            this.tp任务.ResumeLayout(false);
            this.sc任务.Panel1.ResumeLayout(false);
            this.sc任务.Panel1.PerformLayout();
            this.sc任务.Panel2.ResumeLayout(false);
            this.sc任务.ResumeLayout(false);
            this.sb进度.ResumeLayout(false);
            this.sb进度.PerformLayout();
            this.sc任务汇总.Panel1.ResumeLayout(false);
            this.sc任务汇总.Panel2.ResumeLayout(false);
            this.sc任务汇总.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc任务汇总)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务汇总)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.sc任务明细.Panel1.ResumeLayout(false);
            this.sc任务明细.Panel2.ResumeLayout(false);
            this.sc任务明细.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc任务表头)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务表头)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc任务表体)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv任务表体)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tp日志.ResumeLayout(false);
            this.sc日志.Panel1.ResumeLayout(false);
            this.sc日志.Panel2.ResumeLayout(false);
            this.sc日志.Panel2.PerformLayout();
            this.sc日志.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc日志)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv日志)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc窗体;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.SplitContainer sc任务菜单;
        private System.Windows.Forms.TreeView tv2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbb日期;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ImageList il树;
        private DevExpress.XtraGrid.Columns.GridColumn 流程名称;
        private DevExpress.XtraGrid.Columns.GridColumn 流程节点;
        private DevExpress.XtraGrid.Columns.GridColumn 内容;
        private DevExpress.XtraGrid.Columns.GridColumn 发起人;
        private DevExpress.XtraGrid.Columns.GridColumn 单号;
        private DevExpress.XtraGrid.Columns.GridColumn 参与者;
        private DevExpress.XtraGrid.Columns.GridColumn 审批意见;
        private DevExpress.XtraGrid.Columns.GridColumn 审批日期;
        private DevExpress.XtraGrid.Columns.GridColumn 单证;
        private DevExpress.XtraGrid.Columns.GridColumn 表头ID;
        private DevExpress.XtraGrid.Columns.GridColumn fID;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Timer tm任务;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tp任务;
        private System.Windows.Forms.SplitContainer sc任务;
        private System.Windows.Forms.StatusStrip sb进度;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer sc任务汇总;
        private DevExpress.XtraGrid.GridControl gc任务汇总;
        private DevExpress.XtraGrid.Views.Grid.GridView gv任务汇总;
        private DevExpress.XtraGrid.GridControl gc任务;
        private DevExpress.XtraGrid.Views.Grid.GridView gv任务;
        private System.Windows.Forms.Label lbl流程进度;
        private System.Windows.Forms.SplitContainer sc任务明细;
        private DevExpress.XtraGrid.GridControl gc任务表头;
        private DevExpress.XtraGrid.Views.Grid.GridView gv任务表头;
        private DevExpress.XtraGrid.GridControl gc任务表体;
        private DevExpress.XtraGrid.Views.Grid.GridView gv任务表体;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn转发;
        private System.Windows.Forms.TextBox txt批注;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn单证;
        private System.Windows.Forms.Button btn确认;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rb驳回;
        private System.Windows.Forms.RadioButton rb同意;
        private System.Windows.Forms.TabPage tp日志;
        private System.Windows.Forms.SplitContainer sc日志;
        private DevExpress.XtraGrid.GridControl gc日志;
        private DevExpress.XtraGrid.Views.Grid.GridView gv日志;
        private System.Windows.Forms.TextBox txt日志;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
    }
}