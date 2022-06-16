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

    internal static partial class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

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
                    if (Program.Vn.Count(e => { return e == E; }) == 0)
                    {
                        Program.Tn.Add(E);
                    }
                }
                sr.Close();

                Program.StoXM();
            }
            catch { return false; }

            Program.Is_DFA_Creater();

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
                    for (int i = 0; i <= e.Length; i++)
                    { Program.XM[E].Add(e.Insert(i, Program.Sign)); }
                }
            }
        }
        /// <summary>
        /// 构建拓广文法的DFA
        /// </summary>
        private static void Is_DFA_Creater()
        {
            int i = 0, j = 1;//统计项目集
            bool flag;
            //先求I0
            Program.Is.Add(i, Program.CLOSURE(new() { { Program.Start,
                    Program.XM[Program.Start].Where(e => e.IndexOf(Program.Sign) == 0).ToHashSet() } }));
            while (true)
            {
                flag = true;
                Program.DFA.Add(i, new());//向DFA中添加第i个项目集
                //foreach (var item in Program.All)//对于所有字符
                foreach (var item in Program.Is[i].GetCh())
                {
                    var temp = Program.GO(Program.Is[i], item);//求GO(I,X)
                    Program.DFA[i].Add(item, j);
                    if (!Program.Is.Has(temp))
                    { Program.Is.Add(j++, temp); }
                    flag = false;
                }
                if (flag && i >= Program.Is.Count - 1)
                { break; }
                i++;
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
        private static Dictionary<char, HashSet<string>> CLOSURE(Dictionary<char, HashSet<string>> I)
        {

            Dictionary<char, HashSet<string>> list = new();
            int pos;
            foreach (var E in I)
            {
                list.Add(E.Key, new(E.Value));//E加入list
                foreach (var e in E.Value)//对于E中的每一个项目
                {
                    pos = e.IndexOf(Program.Sign);
                    if (pos != e.Length - 1)//e的标记符号不在最后
                    {
                        char c = e[pos + 1];
                        if (Program.Vn.Count(it => it == c) != 0)//如果c是非终结符
                        {
                            //if (list.Keys.Count(it => it == c) == 0)//list没有c关键字则加入c关键字
                            list.TryAdd(c, new());
                            foreach (var v in Program.XM[c])//将c的所有标记符开始的项目添加到list中
                            { if (v.IndexOf(Program.Sign) == 0) { list[c].Add(v); } }
                        }
                    }
                }
            }
            return list;
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
        private static Dictionary<char, HashSet<string>> GO(Dictionary<char, HashSet<string>> I, char X)
        {
            Dictionary<char, HashSet<string>> list = new();
            foreach (var E in I)
            {
                foreach (var e in E.Value)//对于项目集E中的每一个项目e
                {
                    int pos = e.IndexOf(Program.Sign);//指出候选式的标记符号位置
                    if (pos != e.Length - 1)//如果不在开头
                    {
                        if (e[pos + 1] == X)//且标记符后一位与X相同
                        {
                            //合适的项目添加到list中
                            list.Add(E.Key, new(Program.XM[E.Key].Where((it) =>
                            {
                                int p = it.IndexOf(Program.Sign);
                                if (p != 0) { if (it[p - 1] == X) { return true; } }
                                return false;
                            }).ToHashSet()));
                        }
                    }
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
        private static void Clear()
        {
            Program.S.Clear();
            Program.XM.Clear();
            Program.Vn.Clear();
            Program.Tn.Clear();
            Program.Is.Clear();
            Program.All.Clear();
            Program.DFA.Clear();
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
        private static bool IsSame(this Dictionary<char, HashSet<string>> src, Dictionary<char, HashSet<string>> tar)
        {
            if (!src.Keys.OrderBy(e => e).SequenceEqual(tar.Keys.OrderBy(e => e))) { return false; }
            foreach (var item in src) { if (!item.Value.OrderBy(e => e).SequenceEqual(tar[item.Key].OrderBy(e => e))) { return false; } }
            return true;
        }
        public static bool Has(this Dictionary<int, Dictionary<char, HashSet<string>>> src, Dictionary<char, HashSet<string>> tar)
        {
            foreach (var item in src) { if (item.Value.IsSame(tar)) { return true; } }
            return false;
        }

        public static HashSet<char> GetCh(this Dictionary<char, HashSet<string>> src)
        {
            HashSet<char> list = new();
            foreach (var item in src)
            {
                foreach (var e in item.Value)
                {
                    var pos = e.IndexOf(Program.Sign);
                    if (pos != e.Length - 1) { list.Add(e[pos + 1]); }
                }
            }
            return list;
        }

        /// <summary>
        /// 测试调用
        /// </summary>
        public static void test()
        {
            var c = Program.CLOSURE(new() { { 'S', new HashSet<string>() { "∘E" } } });
            //var b = Program.GO(c, 'a');
            //(new Dictionary<char, HashSet<string>>() { { 'c', new() { "1111" } } }).IsSame(new Dictionary<char, HashSet<string>>() { { 'c', new() { "111" } } });
            //Program.IsCreater();
        }
    }
}