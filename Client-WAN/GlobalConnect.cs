using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class GlobalConnect
    {
        // Local
        //static IPAddress ip = IPAddress.Parse("127.0.0.1");
        //static IPEndPoint ipep = new IPEndPoint(ip, 12501);

        // Server 1
        static IPAddress ip = IPAddress.Parse("118.69.78.248");
        static IPEndPoint ipep = new IPEndPoint(ip, 54545);

        // Server 2
        //static IPAddress ip = IPAddress.Parse("118.69.78.248");
        //static IPEndPoint ipep = new IPEndPoint(ip, 56565);

        public static Socket svcn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket chatting = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static int SendData(Socket socket, string send)
        {
            byte[] data = new byte[1024];
            data = Encoding.Unicode.GetBytes(send);
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = socket.Send(datasize);
            while (total < size)
            {
                sent = socket.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        public static string RecieveData(Socket socket)
        {
            int recv, total = 0;
            byte[] datasize = new byte[4];
            recv = socket.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = socket.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    data = Encoding.Unicode.GetBytes("exit ");
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            string nhan = Encoding.Unicode.GetString(data);
            return nhan;
        }

        public static void Connect()
        {
            try
            {
                listen.Connect(ipep);
                svcn.Connect(ipep);
                chatting.Connect(ipep);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void DisConnect()
        {
            try
            {
                listen.Disconnect(false);
                svcn.Disconnect(false);
                chatting.Disconnect(false);
                listen.Close();
                svcn.Close();
                chatting.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
