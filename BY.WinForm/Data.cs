//定义数据结构
namespace BY.WinForm
{
    internal partial class Data
    {
        public readonly char Start = 'S';                                               //拓广文法的开始符号
        public readonly string Sign = "∘";                                              //项目里的标记符号
        public readonly Dictionary<char, HashSet<string>> S = new();                    //文法
        public readonly Dictionary<char, HashSet<string>> XM = new();                   //由文法构建的项目
        public readonly List<char> Vn = new();                                          //拓广非终结符
        public readonly List<char> Tn = new();                                          //终结符
        public readonly HashSet<char> All = new();                                      //文法里出现的所有字符
        public readonly Dictionary<int, Dictionary<char, HashSet<string>>> Is = new();  //项目集
        public readonly Dictionary<int, Dictionary<char, int>> DFA = new();             //DFA
    }
}
