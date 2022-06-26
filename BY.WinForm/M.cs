using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BY.WinForm
{
    internal class M
    {

        public static void Main()
        {
            int port = 1100;
            int max = 100;//最大监听数量
            SocketServer socketServer = new(port, max);

            BYKS byks = new();
            Socket? st = null;

            while (true)
            {
                st = socketServer.MyAccept();
                (new Thread(() => { byks.Connect(st); })).Start();
            }
        }
    }
}
