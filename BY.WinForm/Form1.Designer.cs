namespace BY.WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region 窗口设计代码

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.拓广文法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.展示项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目集规范族ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(450, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(540, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.678757F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26943F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 351);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 36);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(461, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "浏览···";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(642, 351);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拓广文法ToolStripMenuItem,
            this.展示项目ToolStripMenuItem,
            this.dFAToolStripMenuItem,
            this.项目集规范族ToolStripMenuItem,
            this.分析表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 134);
            // 
            // 拓广文法ToolStripMenuItem
            // 
            this.拓广文法ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("拓广文法ToolStripMenuItem.Image")));
            this.拓广文法ToolStripMenuItem.Name = "拓广文法ToolStripMenuItem";
            this.拓广文法ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.拓广文法ToolStripMenuItem.Text = "拓广文法";
            this.拓广文法ToolStripMenuItem.Click += new System.EventHandler(this.拓广文法ToolStripMenuItem_Click);
            // 
            // 展示项目ToolStripMenuItem
            // 
            this.展示项目ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("展示项目ToolStripMenuItem.Image")));
            this.展示项目ToolStripMenuItem.Name = "展示项目ToolStripMenuItem";
            this.展示项目ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.展示项目ToolStripMenuItem.Text = "项目";
            this.展示项目ToolStripMenuItem.Click += new System.EventHandler(this.展示项目ToolStripMenuItem_Click);
            // 
            // dFAToolStripMenuItem
            // 
            this.dFAToolStripMenuItem.Image = global::BY.WinForm.Properties.Resources.sYgiWsBqeaZQli1;
            this.dFAToolStripMenuItem.Name = "dFAToolStripMenuItem";
            this.dFAToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.dFAToolStripMenuItem.Text = "DFA转换矩阵";
            this.dFAToolStripMenuItem.Click += new System.EventHandler(this.dFAToolStripMenuItem_Click);
            // 
            // 项目集规范族ToolStripMenuItem
            // 
            this.项目集规范族ToolStripMenuItem.Image = global::BY.WinForm.Properties.Resources.sYgiWsBqeaZQli1;
            this.项目集规范族ToolStripMenuItem.Name = "项目集规范族ToolStripMenuItem";
            this.项目集规范族ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.项目集规范族ToolStripMenuItem.Text = "项目集规范族";
            // 
            // 分析表ToolStripMenuItem
            // 
            this.分析表ToolStripMenuItem.Image = global::BY.WinForm.Properties.Resources.sYgiWsBqeaZQli1;
            this.分析表ToolStripMenuItem.Name = "分析表ToolStripMenuItem";
            this.分析表ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.分析表ToolStripMenuItem.Text = "分析表";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(642, 387);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(577, 412);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编译原理课设（凤旭昇）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 拓广文法ToolStripMenuItem;
        private ToolStripMenuItem 展示项目ToolStripMenuItem;
        private ToolStripMenuItem dFAToolStripMenuItem;
        private ToolStripMenuItem 项目集规范族ToolStripMenuItem;
        private ToolStripMenuItem 分析表ToolStripMenuItem;
    }
}