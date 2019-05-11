namespace VcfEdit
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最近文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于VcfEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpentoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SavetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportExceltoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExportVCFtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OptiontoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.HelptoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSearch = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.设置OToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.最近文件ToolStripMenuItem,
            this.toolStripSeparator3,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.文件FToolStripMenuItem.Text = "文件[&F]";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开OToolStripMenuItem.Text = "打开[&O]...";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // 最近文件ToolStripMenuItem
            // 
            this.最近文件ToolStripMenuItem.Name = "最近文件ToolStripMenuItem";
            this.最近文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.最近文件ToolStripMenuItem.Text = "最近文件[&F]";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出XToolStripMenuItem.Text = "退出[&X]";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 设置OToolStripMenuItem
            // 
            this.设置OToolStripMenuItem.Name = "设置OToolStripMenuItem";
            this.设置OToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.设置OToolStripMenuItem.Text = "设置[&O]";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助VToolStripMenuItem,
            this.关于VcfEditToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.帮助HToolStripMenuItem.Text = "帮助[&H]";
            // 
            // 查看帮助VToolStripMenuItem
            // 
            this.查看帮助VToolStripMenuItem.Image = global::VcfEdit.Properties.Resources.help;
            this.查看帮助VToolStripMenuItem.Name = "查看帮助VToolStripMenuItem";
            this.查看帮助VToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.查看帮助VToolStripMenuItem.Text = "查看帮助[&V]";
            // 
            // 关于VcfEditToolStripMenuItem
            // 
            this.关于VcfEditToolStripMenuItem.Name = "关于VcfEditToolStripMenuItem";
            this.关于VcfEditToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.关于VcfEditToolStripMenuItem.Text = "关于VcfEdit";
            this.关于VcfEditToolStripMenuItem.Click += new System.EventHandler(this.关于VcfEditToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(742, 29);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Image = global::VcfEdit.Properties.Resources.rescue;
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpentoolStripButton,
            this.SavetoolStripButton,
            this.toolStripSeparator1,
            this.ExportExceltoolStripButton,
            this.ExportVCFtoolStripButton,
            this.toolStripSeparator2,
            this.OptiontoolStripButton,
            this.HelptoolStripButton,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.toolStripSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(742, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpentoolStripButton
            // 
            this.OpentoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpentoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpentoolStripButton.Image")));
            this.OpentoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpentoolStripButton.Name = "OpentoolStripButton";
            this.OpentoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.OpentoolStripButton.Text = "打开";
            this.OpentoolStripButton.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // SavetoolStripButton
            // 
            this.SavetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SavetoolStripButton.Enabled = false;
            this.SavetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SavetoolStripButton.Image")));
            this.SavetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SavetoolStripButton.Name = "SavetoolStripButton";
            this.SavetoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.SavetoolStripButton.Text = "保存";
            this.SavetoolStripButton.Click += new System.EventHandler(this.SavetoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ExportExceltoolStripButton
            // 
            this.ExportExceltoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportExceltoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportExceltoolStripButton.Image")));
            this.ExportExceltoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportExceltoolStripButton.Name = "ExportExceltoolStripButton";
            this.ExportExceltoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.ExportExceltoolStripButton.Text = "导出到Excel文件";
            this.ExportExceltoolStripButton.Click += new System.EventHandler(this.ExportExceltoolStripButton_Click);
            // 
            // ExportVCFtoolStripButton
            // 
            this.ExportVCFtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportVCFtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportVCFtoolStripButton.Image")));
            this.ExportVCFtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportVCFtoolStripButton.Name = "ExportVCFtoolStripButton";
            this.ExportVCFtoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.ExportVCFtoolStripButton.Text = "导出到VCF文件";
            this.ExportVCFtoolStripButton.Click += new System.EventHandler(this.ExportVCFtoolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // OptiontoolStripButton
            // 
            this.OptiontoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OptiontoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OptiontoolStripButton.Image")));
            this.OptiontoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptiontoolStripButton.Name = "OptiontoolStripButton";
            this.OptiontoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.OptiontoolStripButton.Text = "设置";
            // 
            // HelptoolStripButton
            // 
            this.HelptoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelptoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HelptoolStripButton.Image")));
            this.HelptoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelptoolStripButton.Name = "HelptoolStripButton";
            this.HelptoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.HelptoolStripButton.Text = "帮助";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 28);
            this.toolStripLabel1.Text = "查找";
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(100, 31);
            this.toolStripSearch.TextChanged += new System.EventHandler(this.toolStripSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(742, 394);
            this.dataGridView1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 478);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯录";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ExportExceltoolStripButton;
        private System.Windows.Forms.ToolStripButton SavetoolStripButton;
        private System.Windows.Forms.ToolStripButton OptiontoolStripButton;
        private System.Windows.Forms.ToolStripButton HelptoolStripButton;
        private System.Windows.Forms.ToolStripButton ExportVCFtoolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 设置OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton OpentoolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 最近文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于VcfEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}

