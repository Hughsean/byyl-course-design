/*
 *                        _oo0oo_
 *                       o8888888o
 *                       88" . "88
 *                       (| -_- |)
 *                       0\  =  /0
 *                     ___/`---'\___
 *                   .' \\|     |// '.
 *                  / \\|||  :  |||// \
 *                 / _||||| -:- |||||- \
 *                |   | \\\  - /// |   |
 *                | \_|  ''\---/''  |_/ |
 *                \  .-\__  '-'  ___/-. /
 *              ___'. .'  /--.--\  `. .'___
 *           ."" '<  `.___\_<|>_/___.' >' "".
 *          | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *          \  \ `_.   \_ __\ /__ _/   .-` /  /
 *      =====`-.____`.___ \_____/___.-`___.-'=====
 *                        `=---='
 * 
 * 
 *      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * 
 *            佛祖保佑     永不宕机     永无BUG
 */


namespace BY.WinForm
{

    internal static class Program
    {
        private static readonly char Start = 'S';                                               //拓广文法的开始符号
        private static readonly string Sign = "∘";                                              //项目里的标记符号
        private static readonly Dictionary<char, HashSet<string>> S = new();                    //文法
        private static readonly Dictionary<char, HashSet<string>> XM = new();                   //由文法构建的项目
        private static readonly List<char> Vn = new();                                          //拓广非终结符
        private static readonly List<char> Tn = new();                                          //终结符
        private static readonly HashSet<char> All = new();                                      //文法里出现的所有字符
        private static readonly Dictionary<int, HashSet<KeyValuePair<char, string>>> Is = new();//项目集
        private static readonly Dictionary<int, Dictionary<char, int>> DFA = new();             //DFA
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

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
        /// 从文件中读取文法，被写入S中
        /// </summary>
        /// <param name="path"> 
        /// 打开文件的路径 
        /// </param>
        /// <returns>
        /// 文件是否成功打开
        /// </returns>
        public static bool FileReader(string path)
        {
            try
            {
                StreamReader sr = new(path);
                Program.Clear();
                Program.Vn.Add(Program.Start);
                string? line;//文件中的每一行
                string[] temp;//

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        Program.Vn.Add(line[0]);
                        Program.S.Add(Program.Vn.Last(), new());
                        temp = line.Remove(0, 3).Split('|');
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
                    if (Program.Vn.Count(e => { return e == E; }) == 0)
                    {
                        Program.Tn.Add(E);
                    }
                }
                Program.S.Add(Program.Start, new HashSet<string> { Convert.ToString(Program.Vn[0]) });
                Program.StoXM();
                sr.Close();
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// 通过文法构建项目
        /// </summary>
        private static void StoXM()
        {

            foreach (var E in Program.Vn)
            {
                Program.XM.Add(E, new());
                //int i = 0;
                foreach (var e in Program.S[E])
                {
                    for (int i = 0; i < e.Length + 1; i++)
                    { Program.XM[E].Add(e.Insert(i, Program.Sign)); }
                }
            }
        }
        /// <summary>
        /// 构建拓广文法的DFA
        /// </summary>
        public static void DFACreater()
        {
            foreach (var E in Program.DFA)
            {

            }
        }
        public static void IsCreater()
        {
            int i = 0;//统计项目集
            bool same;
            Program.Is.Add(i, Program.CLOSURE(new()
            {
                new(Program.Start, Program.XM[Program.Start].Where(e => e.IndexOf(Program.Sign) == 0).First())
            }));//先求I0
            while (true)
            {
                same = false;
                foreach (var E in Program.Is)
                {
                    foreach (var e in Program.All)
                    {
                        var temp = Program.GO(E.Value, e);
                        foreach (var e_ in Program.Is)
                        {
                            if (temp.IsSame(e_.Value)) { same = true; }
                        }
                        if (!same)
                        {
                            Program.Is.Add(i++, temp);
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="I">
        /// 项目集I
        /// </param>
        /// <returns>
        /// 返回I的闭包
        /// </returns>
        private static HashSet<KeyValuePair<char, string>> CLOSURE(HashSet<KeyValuePair<char, string>> I)
        {

            HashSet<KeyValuePair<char, string>> list = new();
            int pos;
            foreach (var E in I)//对于I中的每一个项目E
            {
                list.Add(E);//E加入list
                pos = E.Value.IndexOf(Program.Sign);//寻找E标记符位置
                if (pos != E.Value.Length)//如果标记符不在字符串末尾
                {
                    char c = E.Value[pos + 1];//c为标记符后的字符
                    if (Program.Vn.Count((t) => { return t == c; }) != 0)//若c是非终结符
                    {
                        foreach (var e in Program.XM[c])//将c的所有标记符开始的项目添加到list中
                        { if (e.IndexOf(Program.Sign) == 0) { list.Add(new(c, e)); } }
                    }
                }

            }

            return list.OrderBy(e => e.Key).ToHashSet();
        }

        /// <summary>
        /// 转换函数
        /// </summary>
        /// <param name="I">
        /// 项目集I
        /// </param>
        /// <param name="X">
        /// 文法符号X
        /// </param>
        /// <returns>
        /// 返回转换的项目集
        /// </returns>
        private static HashSet<KeyValuePair<char, string>> GO(HashSet<KeyValuePair<char, string>> I, char X)
        {
            HashSet<KeyValuePair<char, string>> list = new HashSet<KeyValuePair<char, string>>();

            foreach (var E in I)//对于项目集I中的每一个项目
            {
                int i = E.Value.IndexOf(Program.Sign);//指出候选式的标记符号位置
                if (i != 0)//如果不在开头
                {
                    if (E.Value[i - 1] == X)//且标记符后一位与X相同
                    { list.Add(E); }//将E加入list
                }
            }
            return Program.CLOSURE(list);//最后返回list的闭包
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
        /// <summary>
        /// 成员变量清除
        ///// </summary>
        public static void Clear()
        {
            Program.S.Clear();
            Program.XM.Clear();
            Program.Vn.Clear();
            Program.Tn.Clear();
        }
        /// <summary>
        /// 判断两张哈希集合成员是否相同
        /// </summary>
        /// <param name="src">
        /// 原哈希集合
        /// </param>
        /// <param name="tar">
        /// 用于比较的哈希集合
        /// </param>
        /// <returns>
        /// 元素相等则返回true，否则为false
        /// </returns>
        public static bool IsSame(this HashSet<KeyValuePair<char, string>> src, HashSet<KeyValuePair<char, string>> tar)
        {
            if (src.Count != tar.Count)
            { return false; }
            var src_list = src.ToList();
            var tar_list = tar.ToList();
            for (int i = 0; i < src_list.Count; i++)
            {
                if (src_list[i].Key != tar_list[i].Key) { return false; }
                if (src_list[i].Value != tar_list[i].Value) { return false; }
            }
            return true;
        }
        public static void test()
        {
            Program.IsCreater();
        }
    }
}