//定义一些辅助函数
namespace BY.WinForm
{
    internal static partial class BYKS
    {
        /// <summary> 成员变量清除 </summary>
        private static void Clear()
        {
            BYKS.S.Clear();
            BYKS.XM.Clear();
            BYKS.Vn.Clear();
            BYKS.Tn.Clear();
            BYKS.Is.Clear();
            BYKS.All.Clear();
            BYKS.DFA.Clear();
        }
        /// <summary> 判断两张哈希集合是否值相等 </summary>
        /// <param name="src"> 原哈希集合 </param>
        /// <param name="tar"> 用于比较的哈希集合 </param>
        /// <returns> 元素相等则返回true，否则为false </returns>
        private static bool IsSame(this Dictionary<char, HashSet<string>> src, Dictionary<char, HashSet<string>> tar)
        {
            if (!src.Keys.OrderBy(e => e).SequenceEqual(tar.Keys.OrderBy(e => e))) { return false; }
            foreach (var item in src) { if (!item.Value.OrderBy(e => e).SequenceEqual(tar[item.Key].OrderBy(e => e))) { return false; } }
            return true;
        }
        /// <summary> 返回字典值相等的成员的key </summary>
        /// <param name="src"> 源字典 </param>
        /// <param name="tar"> 目标字典 </param>
        /// <returns> 如果src含有与tar值相同成员，返回成员key；否则返回-1 </returns>
        public static int KeyOf(this Dictionary<int, Dictionary<char, HashSet<string>>> src, Dictionary<char, HashSet<string>> tar)
        {
            foreach (var item in src) { if (item.Value.IsSame(tar)) { return item.Key; } }
            return -1;
        }
        /// <summary> 获取项目集src可识别的活前缀 </summary>
        /// <param name="src"> 略 </param>
        /// <returns> 返回活前缀集合 </returns>
        public static HashSet<char> GetCh(this Dictionary<char, HashSet<string>> src)
        {
            return (from E in src
                    from e in E.Value
                    let pos = e.IndexOf(BYKS.Sign)
                    where pos != e.Length - 1
                    select e[pos + 1]).ToHashSet();
        }

        /// <summary> 项目集族的字符串形式 </summary>
        /// <param name="src"> 源 </param>
        /// <returns> 字符串 </returns>
        public static string MyToString(this Dictionary<char, HashSet<string>> src)
        {
            string str = "\n";
            foreach (var E in src.Keys)
            {
                foreach (var e in src[E])
                { str += E.ToString() + "->" + e + "\n"; }
            }
            return str;
        }

        public static void SetNoSort(this DataGridView dgv)
        {
            foreach (var item in dgv.Columns)
            {
                var e = item as DataGridViewColumn;
                if (e == null) { return; }
                e.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
