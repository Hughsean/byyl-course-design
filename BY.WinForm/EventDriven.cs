//定义事件驱动函数

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BY.WinForm
{

    internal static partial class Program
    {
        /// <summary>
        /// 可视化获取文件路径
        /// </summary>
        /// <returns>
        /// 返回文件路径
        /// </returns>
        public static string GetFilePath()
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择文件",
                Filter = "文本文件(*.txt)|*.*",
                InitialDirectory = @"D:\Data\Data\Desktop"

            };
            dialog.ShowDialog();
            if (Path.GetExtension(dialog.FileName) == ".txt" || dialog.FileName.Length == 0)
            { return dialog.FileName; }
            else
            {
                MessageBox.Show("文件类型错误，不为文本文件(.txt)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path"> 
        /// 打开文件的路径 
        /// </param>
        /// <returns>
        /// 初始化是否成功
        /// </returns>
        public static bool Init(string path)
        {
            try
            {
                StreamReader sr = new(path);
                Program.Clear();

                Program.Vn.Add(Program.Start);
                Program.All.Add(Program.Start);

                string? line;//文件中的每一行
                var begin = sr.Peek();
                if (begin == -1) { throw new(); }
                Program.S.Add(Program.Start, new HashSet<string> { Convert.ToString((char)begin) });
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        Program.Vn.Add(line[0]);
                        Program.All.Add(line[0]);
                        Program.S.Add(Program.Vn.Last(), new());
                        var temp = line.Remove(0, 3).Split('|');
                        foreach (string s in temp)
                        {
                            Program.S[Program.Vn.Last()].Add(s);
                            foreach (char c in s)
                            { Program.All.Add(c); }
                        }
                    }
                }
                //创建终结符集
                foreach (var E in Program.All)
                {
                    if (Program.Vn.Count(e => e == E) == 0)
                    { Program.Tn.Add(E); }
                }
                sr.Close();
                Program.StoXM();
            }
            catch { return false; }
            Program.Is_DFA_Creater();
            return true;
        }
        /// <summary>
        /// listview展示文法
        /// </summary>
        /// <param name="listView">
        /// 传入的控件
        /// </param>
        public static void ShowS(ListView listView)
        {
            listView.Clear();
            listView.Columns.Add("序号", 150, HorizontalAlignment.Center);
            listView.Columns.Add("非终结符", 150, HorizontalAlignment.Center);
            listView.Columns.Add("候选式", 150, HorizontalAlignment.Center);
            listView.BeginUpdate();
            int i = 1;
            foreach (var item in Program.Vn)
            {
                foreach (var e in Program.S[item])
                {

                    ListViewItem temp = new(Convert.ToString(i++));
                    temp.SubItems.Add(Convert.ToString(item));
                    temp.SubItems.Add(e);
                    listView.Items.Add(temp);
                }
            }
            listView.EndUpdate();
        }
        /// <summary>
        /// 展示项目
        /// </summary>
        /// <param name="listView">
        /// 展示项目的控件
        /// </param>
        public static void ShowXM(ListView listView)
        {
            listView.Clear();
            listView.Columns.Add("序号", 150, HorizontalAlignment.Center);
            listView.Columns.Add("非终结符", 150, HorizontalAlignment.Center);
            listView.Columns.Add("项目", 150, HorizontalAlignment.Center);
            int i = 1;
            listView.BeginUpdate();
            foreach (var item in Program.Vn)
            {
                foreach (var e in Program.XM[item])
                {
                    ListViewItem temp = new(Convert.ToString(i++));
                    temp.SubItems.Add(Convert.ToString(item));
                    temp.SubItems.Add(e);
                    listView.Items.Add(temp);
                }
            }
            listView.EndUpdate();
        }
    }
}
