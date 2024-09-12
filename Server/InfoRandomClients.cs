using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class InfoRandomClients
    {
        Socket chatting;
        string sdt;

        public InfoRandomClients(Socket chatting, string sdt)
        {
            this.chatting = chatting;
            this.sdt = sdt;
        }

        public Socket Chatting { get => chatting; set => chatting = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
