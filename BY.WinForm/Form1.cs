
namespace BY.WinForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = Program.GetFilePath();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Program.Init(this.textBox1.Text))
            {
                MessageBox.Show("文件读取错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { Program.ShowS(this.listView1); }
        }

        private void 拓广文法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowS(this.listView1);
        }

        private void 展示项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowXM(this.listView1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.test();
        }

        private void dFAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}