//定义事件驱动函数

namespace BY.WinForm
{

    internal static partial class BYKS
    {
        /// <summary> 可视化获取文件路径 </summary>
        /// <returns> 返回文件路径 </returns>
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

        /// <summary> 初始化 </summary>
        /// <param name="path"> 打开文件的路径 </param>
        /// <returns> 初始化是否成功 </returns>
        public static bool Init(string path)
        {
            try
            {
                StreamReader sr = new(path);
                BYKS.Clear();

                BYKS.Vn.Add(BYKS.Start);
                BYKS.All.Add(BYKS.Start);

                string? line;//文件中的每一行
                var begin = sr.Peek();//取文法开始符号
                if (begin == -1) { throw new(); }
                BYKS.S.Add(BYKS.Start, new HashSet<string> { Convert.ToString((char)begin) });
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        BYKS.Vn.Add(line[0]);
                        BYKS.All.Add(line[0]);
                        BYKS.S.Add(BYKS.Vn.Last(), new());
                        foreach (var s in line.Remove(0, 3).Split('|'))
                        {
                            BYKS.S[BYKS.Vn.Last()].Add(s);
                            foreach (var c in s)
                            { BYKS.All.Add(c); }
                        }
                    }
                }
                //创建终结符集
                foreach (var E in BYKS.All)
                {
                    if (BYKS.Vn.Count(e => e == E) == 0)
                    { BYKS.Tn.Add(E); }
                }
                sr.Close();
                BYKS.StoXM();
                BYKS.Is_DFA_Creater();
            }
            catch { return false; }
            return true;
        }
        /// <summary> listview展示文法 </summary>
        /// <param name="dataGridView"> 传入的控件 </param>
        public static void ShowS(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("序号", "序号");
            dataGridView.Columns.Add("非终结符", "非终结符");
            dataGridView.Columns.Add("候选式", "候选式");
            dataGridView.SetNoSort();

            int i = 0;
            foreach (var E in BYKS.S)
            {
                foreach (var e in E.Value)
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[i].Cells[0].Value = i;
                    dataGridView.Rows[i].Cells[1].Value = E.Key;
                    dataGridView.Rows[i++].Cells[2].Value = e;
                }
            }
        }
        /// <summary> 展示项目 </summary>
        /// <param name="dataGridView"> 展示项目的控件 </param>
        public static void ShowXM(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("序号", "序号");
            dataGridView.Columns.Add("非终结符", "非终结符");
            dataGridView.Columns.Add("项目", "项目");
            dataGridView.SetNoSort();

            int i = 0;
            foreach (var E in BYKS.XM)
            {
                foreach (var e in E.Value)
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[i].Cells[0].Value = i;
                    dataGridView.Rows[i].Cells[1].Value = E.Key;
                    dataGridView.Rows[i++].Cells[2].Value = e;
                }
            }
        }
        /// <summary>
        /// 展示项目集族与DFA
        /// </summary>
        /// <param name="dataGridView">控件</param>
        public static void ShowIsAndDFA(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("状态", "状态");
            dataGridView.Columns.Add("项目集", "项目集");

            foreach (var e in BYKS.All) { dataGridView.Columns.Add(e.ToString(), e.ToString()); }
            dataGridView.Columns.Remove(BYKS.Start.ToString());


            dataGridView.SetNoSort();
            for (int i = 0; i < BYKS.Is.Count; i++)
            {
                dataGridView.Rows.Add(i, BYKS.Is[i].MyToString());
                foreach (var e in BYKS.Is[i].GetCh())
                {
                    for (int n = 0; n < dataGridView.Columns.Count; n++)
                    {
                        if (dataGridView.Columns[n].Name == e.ToString())
                        { dataGridView.Rows[i].Cells[n].Value = BYKS.DFA[i][e]; break; }
                    }
                }
            }
        }
        #region //
        //public static void ShowTable(DataGridView dataGridView)
        //{
        //    dataGridView.Columns.Clear();
        //    dataGridView.Columns.Add("项目集(参考)", "项目集(参考)");
        //    dataGridView.Columns.Add("状态", "状态");

        //    List<char> list = new();

        //    foreach (var e in BYKS.Tn) { list.Add(e); }
        //    list.Add('#');
        //    foreach (var e in BYKS.Vn) { list.Add(e); }
        //    list.Remove(BYKS.Start);
        //    foreach (var e in list) { dataGridView.Columns.Add(e.ToString(), e.ToString()); }

        //    dataGridView.SetNoSort();


        //    foreach (var E in BYKS.DFA)
        //    {
        //        dataGridView.Rows.Add();
        //        dataGridView.Rows[E.Key].Cells[0].Value = BYKS.Is[E.Key].MyToString();
        //        dataGridView.Rows[E.Key].Cells[1].Value = E.Key.ToString();
        //        foreach (var e in BYKS.Is[E.Key].GetCh())
        //        {
        //            if (!BYKS.Vn.Contains(e))
        //            { dataGridView.Rows[E.Key].Cells[e.ToString()].Value = "S" + BYKS.DFA[E.Key][e].ToString(); }
        //        }
        //        foreach (var e in BYKS.Is[E.Key])
        //        {
        //            if (e.Value.Where(ee => ee.IndexOf(BYKS.Sign) == ee.Length - 1).Count() != 0)
        //            {
        //                foreach (var ee in BYKS.Tn.Concat("#"))
        //                {
        //                }
        //            }
        //        }
        //    }

        //}
        #endregion
    }
}
