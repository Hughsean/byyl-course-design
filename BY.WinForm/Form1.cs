namespace BY.WinForm
{
    public partial class Form1 : Form
    {

        public Form1()
        { InitializeComponent(); }

        private void button2_Click(object sender, EventArgs e)
        { this.textBox1.Text = BYKS.GetFilePath(); }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!BYKS.Init(this.textBox1.Text))
            { MessageBox.Show("文件读取错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            { BYKS.ShowS(this.dataGridView); }
        }

        private void 拓广文法ToolStripMenuItem_Click(object sender, EventArgs e)
        { BYKS.ShowS(this.dataGridView); }

        private void 展示项目ToolStripMenuItem_Click(object sender, EventArgs e)
        { BYKS.ShowXM(this.dataGridView); }

        private void dFAToolStripMenuItem_Click(object sender, EventArgs e)
        { BYKS.ShowIsAndDFA(this.dataGridView); }
    }
}