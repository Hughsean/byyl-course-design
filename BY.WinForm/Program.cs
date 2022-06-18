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

//主函数
namespace BY.WinForm
{
    internal static partial class BYKS
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }


        /// <summary> DEBUG调用 </summary>
        public static void test()
        {
            var c = BYKS.CLOSURE(new() { { 'S', new HashSet<string>() { "∘E" } } });
            //var b = Program.GO(c, 'a');
            //(new Dictionary<char, HashSet<string>>() { { 'c', new() { "1111" } } }).IsSame(new Dictionary<char, HashSet<string>>() { { 'c', new() { "111" } } });
            //Program.IsCreater();
        }
    }
}