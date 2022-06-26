using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BY.WinForm
{

    internal class SocketServer
    {
        private Socket socket;
        public SocketServer(int port, int maxlisten)
        {
            this.socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Bind(new IPEndPoint(IPAddress.Any, port));
            this.socket.Listen(maxlisten);
            //Console.WriteLine("已绑定端口: " + socket.LocalEndPoint);
        }

        public Socket? MyAccept()
        { return this.socket.Accept(); }
    }
}
