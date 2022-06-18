//项目核心函数
namespace BY.WinForm
{
    internal static partial class BYKS
    {
        /// <summary> 通过文法构建项目 </summary>
        private static void StoXM()
        {
            foreach (var E in BYKS.Vn)
            {
                BYKS.XM.Add(E, new());
                foreach (var e in BYKS.S[E])
                {
                    for (int i = 0; i <= e.Length; i++)
                    { BYKS.XM[E].Add(e.Insert(i, BYKS.Sign)); }
                }
            }
        }
        /// <summary> 构建拓广文法的DFA </summary>
        private static void Is_DFA_Creater()
        {
            int IteratorsOfIs = 0, j = 1, pos;//统计项目集
            bool flag;
            //先求I0
            BYKS.Is.Add(IteratorsOfIs, BYKS.CLOSURE(new() { { BYKS.Start,
                    BYKS.XM[BYKS.Start].Where(e => e.IndexOf(BYKS.Sign) == 0).ToHashSet() } }));
            while (true)
            {
                flag = true;
                BYKS.DFA.Add(IteratorsOfIs, new());//向DFA中添加第i个项目集
                foreach (var item in BYKS.Is[IteratorsOfIs].GetCh())
                {
                    var temp = BYKS.GO(BYKS.Is[IteratorsOfIs], item);//求GO(I,X)，记作temp
                    pos = BYKS.Is.KeyOf(temp);//
                    if (pos == -1)//如果项目集族不含有temp
                    { pos = j; BYKS.Is.Add(j++, temp); }//项目集族添加temp
                    BYKS.DFA[IteratorsOfIs].Add(item, pos);
                    flag = false;
                }
                if (flag && IteratorsOfIs >= BYKS.Is.Count - 1)
                { break; }
                IteratorsOfIs++;
            }
        }
        /// <summary> 求I闭包 </summary>
        /// <param name="I"> 项目集I </param>
        /// <returns> 返回I的闭包 </returns>
        private static Dictionary<char, HashSet<string>> CLOSURE(Dictionary<char, HashSet<string>> I)
        {

            Dictionary<char, HashSet<string>> list = new();
            int pos;
            foreach (var E in I)
            {
                list.Add(E.Key, new(E.Value));//E加入list
                foreach (var e in E.Value)//对于E中的每一个项目
                {
                    pos = e.IndexOf(BYKS.Sign);
                    if (pos != e.Length - 1)//e的标记符号不在最后
                    {
                        char c = e[pos + 1];
                        if (BYKS.Vn.Count(it => it == c) != 0)//如果c是非终结符
                        {
                            list.TryAdd(c, new());
                            foreach (var v in BYKS.XM[c])//将c的所有标记符开始的项目添加到list中
                            { if (v.IndexOf(BYKS.Sign) == 0) { list[c].Add(v); } }
                        }
                    }
                }
            }
            return list;
        }

        /// <summary> 转换函数 </summary>
        /// <param name="I"> 项目集I </param>
        /// <param name="X"> 文法符号X </param>
        /// <returns> 返回转换的项目集 </returns>
        private static Dictionary<char, HashSet<string>> GO(Dictionary<char, HashSet<string>> I, char X)
        {
            Dictionary<char, HashSet<string>> list = new();
            foreach (var E in I)
            {
                foreach (var e in E.Value)//对于项目集E中的每一个项目e
                {
                    int pos = e.IndexOf(BYKS.Sign);//指出候选式的标记符号位置
                    if (pos != e.Length - 1)//如果不在开头
                    {
                        if (e[pos + 1] == X)//且标记符后一位与X相同
                        {
                            //合适的项目添加到list中
                            list.Add(E.Key, new(BYKS.XM[E.Key].Where((it) =>
                            {
                                int p = it.IndexOf(BYKS.Sign);
                                if (p != 0) { if (it[p - 1] == X) { return true; } }
                                return false;
                            }).ToHashSet()));
                        }
                    }
                }
            }
            return BYKS.CLOSURE(list);//最后返回list的闭包
        }
    }
}
