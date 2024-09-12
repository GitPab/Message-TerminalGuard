using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Client
{
    class GlobalConnect
    {
        // Local
        static IPAddress ip = IPAddress.Parse("127.0.0.1");
        static IPEndPoint ipep = new IPEndPoint(ip, 12501);

        // Server 1
        //static IPAddress ip = IPAddress.Parse("118.69.78.248");
        //static IPEndPoint ipep = new IPEndPoint(ip, 54545);

        // Server 2
        //static IPAddress ip = IPAddress.Parse("118.69.78.248");
        //static IPEndPoint ipep = new IPEndPoint(ip, 56565);

        public static Socket svcn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket chatting = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Khóa mã hóa phải là 16, 24 hoặc 32 ký tự
        private static readonly string key = "1234567890123456"; // 16 ký tự = 128 bit

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // IV mặc định là 0

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // IV mặc định là 0

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static int SendData(Socket socket, string send)
        {
            string encryptedData = Encrypt(send);
            byte[] data = Encoding.Unicode.GetBytes(encryptedData);
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
            string encryptedData = Encoding.Unicode.GetString(data);
            return Decrypt(encryptedData);
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