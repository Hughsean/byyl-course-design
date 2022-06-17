//定义一些辅助函数

namespace BY.WinForm
{
    internal static partial class Program
    {
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
        /// <summary>
        /// 返回字典值相等的成员的key
        /// </summary>
        /// <param name="src">
        /// 源字典
        /// </param>
        /// <param name="tar">
        /// 目标字典
        /// </param>
        /// <returns>
        /// 如果src含有与tar值相同成员，返回成员key；否则返回-1
        /// </returns>
        public static int KeyOf(this Dictionary<int, Dictionary<char, HashSet<string>>> src, Dictionary<char, HashSet<string>> tar)
        {
            foreach (var item in src) { if (item.Value.IsSame(tar)) { return item.Key; } }
            return -1;
        }

        public static HashSet<char> GetCh(this Dictionary<char, HashSet<string>> src)
        {
            return (from E in src
                    from e in E.Value
                    let pos = e.IndexOf(Program.Sign)
                    where pos != e.Length - 1
                    select e[pos + 1]).ToHashSet();
        }
    }
}
