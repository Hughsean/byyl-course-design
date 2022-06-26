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

using System.Net.Sockets;

namespace BY.WinForm
{
    internal partial class BYKS
    {


        /// <summary> DEBUG调用 </summary>
        public void Init(string[] strs, Data data)
        {

            data.Vn.Add(data.Start);
            data.All.Add(data.Start);
            data.S.Add(data.Start, new HashSet<string> { Convert.ToString(strs[0][0]) });
            foreach (var E in strs)
            {
                data.Vn.Add(E[0]);
                data.All.Add(E[0]);
                data.S.Add(data.Vn.Last(), new());
                foreach (var e in E.Remove(0, 3).Split('|'))
                {
                    data.S[data.Vn.Last()].Add(e);
                    foreach (var c in e)
                    { data.All.Add(c); }
                }
            }
            //创建终结符集
            foreach (var e in data.All)
            {
                if (data.Vn.Count(ee => ee == e) == 0)
                { data.Tn.Add(e); }
            }
            this.StoXM(data);
            this.Is_DFA_Creater(data);
        }

        public void Connect(Socket? st)
        {
            if (st == null)
            { return; }
            Console.WriteLine(st.RemoteEndPoint + "接入");
            Data data = new();
            byte[] buffer = new byte[8 * 1024 * 1024];

            string? str;
            //先接收文件字符串
            int len = st.Receive(buffer);

            str = (string?)ByteConverter.ByteToObj(buffer[0..len], typeof(string));
            if (str == null) { return; }

            this.Init(str.Split("\r\n"), data);
            st.Send(ByteConverter.ObjToByte(data.S));
            Thread.Sleep(8);
            st.Send(ByteConverter.ObjToByte(data.All));
            Thread.Sleep(8);
            st.Send(ByteConverter.ObjToByte(data.XM));
            Thread.Sleep(8);
            st.Send(ByteConverter.ObjToByte(data.Is));
            Thread.Sleep(8);
            st.Send(ByteConverter.ObjToByte(data.DFA));
            st.Close();
            Console.WriteLine(st.RemoteEndPoint + "断开");
        }
    }
}
