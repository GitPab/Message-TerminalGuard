using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Clients
    {
        private string sdt;
        private bool isChatting, isRandom, isBusy;
        Socket socket, listen, chatting;

        public Clients(string sdt, Socket socket, Socket listen, Socket chatting)
        {
            this.sdt = sdt;
            this.isChatting = false; ;
            this.isRandom = false;
            this.isBusy = false;
            this.socket = socket;
            this.listen = listen;
            this.chatting = chatting;
        }

        public string Sdt { get => sdt; set => sdt = value; }
        public bool IsChatting { get => isChatting; set => isChatting = value; }
        public Socket Socket { get => socket; set => socket = value; }
        public Socket Listen { get => listen; set => listen = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }
        public bool IsRandom { get => isRandom; set => isRandom = value; }
        public Socket Chatting { get => chatting; set => chatting = value; }
    }
}
