using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static List<Clients> lstClient;
        static LinkedList<InfoRandomClients> listRandoms;

        private static void LogoutAllUsers()
        {
            // Lấy ra tất cả Folder chứa thông tin của các User, lưu đường dẫn Folder vào mảng
            string[] folderPath = Directory.GetDirectories("Profile");
            for (int i = 0; i < folderPath.Length; i++)
            {
                // Tạo đường dẫn tới thư mục thông tin người dùng
                string path = folderPath[i] + "/Info.txt";
                // Đọc thông tin
                string[] info = File.ReadAllLines(path);
                // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Tiểu Sử
                info[4] = "Logout";
                File.WriteAllLines(path, info);
            }
        }

        public static bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                // Mất kết nối tới client
                return false;
            else
                return true;
        }

        private static int SendData(Socket a, string nhan)
        {
            byte[] data = new byte[1024];
            data = Encoding.Unicode.GetBytes(nhan);
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = a.Send(datasize);
            while (total < size)
            {
                sent = a.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        private static string RecieveData(Socket a)
        {
            int recv, total = 0;
            byte[] datasize = new byte[4];
            recv = a.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = a.Receive(data, total, dataleft, 0);
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

        private static void SendRefreshNoitice()
        {
            // Gửi tín hiệu có người mới đăng nhập cho các User khác
            foreach (Clients client in lstClient)
            {
                if (!client.IsBusy)
                    SendData(client.Listen, "Refresh");
            }
        }

        private static void AddClientToList(Socket socket, Socket listen, Socket chatting, string sdt)
        {
            // Add thông tin Client vào List
            Clients client = new Clients(sdt, socket, listen, chatting);
            lstClient.Add(client);
        }

        private static void DelClientFromList(string sdt)
        {
            foreach (Clients client in lstClient)
            {
                if (client.Sdt == sdt)
                {
                    client.Socket.Close();
                    client.Listen.Close();
                    client.Chatting.Close();
                    lstClient.Remove(client);
                    break;
                }
            }
        }

        public static bool CheckLogin(Socket socket, Socket listen, Socket chatting, string nhan)
        {
            bool isLoginSuccess = false;
            // nhan = Yêu Cầu - Tài Khoản - Mật Khẩu.
            string[] info = nhan.Split('-');
            string sdt = info[1];
            string matkhau = info[2];
            // Đặt biến kiểm tra thông tin tài khoản
            bool check = false;
            // Lưu dữ liệu File tài khoản người dùng
            string[] tmp = File.ReadAllLines("Account.txt");
            // Check
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].Equals(""))
                    continue;
                string[] account = tmp[i].Split('-');
                if (account[0] == sdt && account[1] == matkhau)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                SendData(socket, "0"); // Login fail
            }
            else
            {
                // Kiểm tra người dùng này đang Login hay chưa
                string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
                // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                if (info_User[4] == "Login")
                    SendData(socket, "2"); // Đang đăng nhập nơi khác
                else
                {
                    // Đổi trạng thái đăng nhập thành Login cho người dùng
                    info_User[4] = "Login";
                    File.WriteAllLines("Profile/" + sdt + "/Info.txt", info_User);
                    // Gửi tín hiệu có người mới đăng nhập cho các User khác
                    SendRefreshNoitice();
                    // Thêm User vào List để quản lý.
                    AddClientToList(socket, listen, chatting, sdt);
                    SendData(socket, "1"); // Login success
                    isLoginSuccess = true;
                }
            }
            return isLoginSuccess;
        }

        public static void Logout(Socket socket, string sdt)
        {
            string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            if (info_User[4] == "Login")
            {
                // Đổi trạng thái đăng nhập thành Logout cho người dùng
                info_User[4] = "Logout";
                File.WriteAllLines("Profile/" + sdt + "/Info.txt", info_User);
                // Gửi thông báo cho phép Logout
                SendData(socket, "1");
                DelClientFromList(sdt);
            }
            else
            {
                SendData(socket, "0");
            }
            SendRefreshNoitice();
        }

        public static void DangKyTaiKhoan(Socket socket, string nhan)
        {
            // nhan = Yêu Cầu - Tên - SĐT - Giới Tính - Ngày Sinh - Mật Khẩu
            string[] info = nhan.Split('-');
            string ten = info[1];
            string sdt = info[2];
            string gioiTinh = info[3];
            string ngaySinh = info[4];
            string matKhau = info[5];
            // Bắt đầu kiểm tra tài khoản tồn tại hay chưa
            bool exist = false;
            string[] allAccount = File.ReadAllLines("Account.txt"); // Đọc danh sách các tài khoản
            for (int i = 0; i < allAccount.Length; i++)
            {
                if (allAccount[i] == "" || allAccount == null)
                    continue;
                string[] account = allAccount[i].Split('-');
                if (account[0] == sdt)
                {
                    exist = true;
                    break;
                }
            }
            if (exist == true) // Tài khoản tồn tại.
                SendData(socket, "0");
            else
            {
                // Lưu tài khoản người dùng
                // Tạo mảng mới để lưu tài khoản, tạo nhiều hơn 1 dòng để ghi dữ liệu
                string[] insert = new string[allAccount.Length + 1];
                // Copy mảng dữ liệu cũ vô mảng mới
                Array.Copy(allAccount, insert, allAccount.Length);
                insert[allAccount.Length] = sdt + "-" + matKhau;
                File.WriteAllLines("Account.txt", insert);
                // Tạo folder Profile cho người dùng để lưu các thông tin riêng.
                Directory.CreateDirectory("Profile/" + sdt);
                Directory.CreateDirectory("Profile/" + sdt + "/History");
                // Chép dữ liệu vào thư mục người dùng
                string[] tmp = new string[8];
                tmp[0] = ten;
                tmp[1] = gioiTinh;
                tmp[2] = ngaySinh;
                tmp[3] = "Online";
                tmp[4] = "Logout";
                tmp[6] = "Chưa có!";
                tmp[7] = "";
                if (gioiTinh == "Nữ")
                    tmp[5] = "Picture/2.png";
                else
                    tmp[5] = "Picture/3.png";
                // Tạo file Info.txt nằm trong thư mục người dùng để lưu dữ liệu người dùng.
                FileStream fs = File.Create("Profile/" + sdt + "/Info.txt");
                fs.Close();
                File.WriteAllLines("Profile/" + sdt + "/Info.txt", tmp);
                SendData(socket, "1");
            }
        }

        public static void LoadDuLieuDangNhap(Socket socket, string sdt)
        {
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
            for (int i = 0; i < info_User.Length; i++)
            {
                SendData(socket, i + "-" + info_User[i]);
            }
            SendData(socket, "End");
        }

        public static void DoiTrangThai(string sdt, string trangThai)
        {
            string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            info_User[3] = trangThai;
            File.WriteAllLines("Profile/" + sdt + "/Info.txt", info_User);
            SendRefreshNoitice();
        }

        public static void DoiAvatar(string sdt, string path)
        {
            string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            info_User[5] = path;
            File.WriteAllLines("Profile/" + sdt + "/Info.txt", info_User);
            SendRefreshNoitice();
        }

        public static void DoiMatKhau(Socket socket, string nhan)
        {
            // Nhận = Lệnh - SĐT - Mật Khẩu Cũ - Mật Khẩu Mới
            // Check mật khẩu cũ
            string[] info = nhan.Split('-');
            string sdt = info[1];
            string matKhauCu = info[2];
            string matKhauMoi = info[3];
            // Đặt biến kiểm tra
            bool check = false;
            // Lưu dữ liệu file tài khoản người dùng
            string[] tmp = File.ReadAllLines("Account.txt");
            // Check
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == "")
                    continue;
                string[] account = tmp[i].Split('-');
                if (account[0] == sdt && account[1] == matKhauCu)
                {
                    tmp[i] = sdt + "-" + matKhauMoi;
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                SendData(socket, "0");
            }
            else
            {
                File.WriteAllLines("Account.txt", tmp);
                SendData(socket, "1");
            }
        }

        public static void LoadOnlineUsers(Socket socket, string sdt)
        {
            // nhan = Lệnh - SĐT người gọi hàm
            // Lấy ra tất cả Folder chứa thông tin của các User, lưu đường dẫn Folder vào mảng
            string[] folderPath = Directory.GetDirectories("Profile");
            // Duyệt qua từng Folder, tìm thông tin người dùng nào đang Online thì trả về.
            for (int i = 0; i < folderPath.Length; i++)
            {
                if (folderPath[i].Contains(sdt))
                    continue;
                //
                string path = folderPath[i] + "/Info.txt";
                // Đọc thông tin
                string[] info = File.ReadAllLines(path);
                // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                if (info[4] == "Login")
                {
                    string sdt_DoiPhuong = folderPath[i].Substring(folderPath[i].Length - 10);
                    if (!IsChatting_OR_RandomChat(sdt_DoiPhuong))
                    {
                        // Gửi sđt
                        SendData(socket, sdt_DoiPhuong);
                        // Tạo vòng lặp gửi từng dòng dữ liệu.
                        for (int j = 0; j < info.Length; j++)
                        {
                            if (j >= 7)
                                SendData(socket, 7 + "-" + info[j] + " ");
                            else
                                SendData(socket, j + "-" + info[j]);
                        }
                        SendData(socket, "Next");
                    }
                }
            }
            SendData(socket, "End");
        }

        public static void LoadThongTinUser(Socket socket, string sdt)
        {
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            string[] info_User = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
            for (int i = 0; i < info_User.Length; i++)
            {
                if (i >= 7)
                    SendData(socket, 7 + "-" + info_User[i] + " ");
                else
                    SendData(socket, i + "-" + info_User[i]);
            }
            SendData(socket, "End");
        }

        public static bool IsChatting_OR_RandomChat(string sdt)
        {
            foreach (Clients client in lstClient)
            {
                if (client.Sdt == sdt && client.IsChatting)
                {
                    return true;
                }
            }
            return false;
        }

        public static void KetNoiChat(Socket socket, string nhan)
        {
            // nhan = Lệnh gọi hàm - SĐT người gọi hàm - SĐT muốn kết nối
            string[] tmp = nhan.Split('-');
            string sdt_CallConnect = tmp[1], sdt_ConnectTo = tmp[2];
            // SĐT_CallConnect là số của người muốn chủ động kết nối tới người còn lại.
            // SĐT_ConnectTo là số của đối phương.
            // Tìm thông tin của người gọi kết nối
            foreach (Clients client_CallConnect in lstClient)
            {
                if (client_CallConnect.Sdt == sdt_CallConnect)
                {
                    if (client_CallConnect.IsChatting == true)
                    {
                        SendData(socket, "StopChatting");
                        break;
                    }
                    client_CallConnect.IsBusy = true;
                    // Tìm thông tin đối phương.
                    foreach (Clients client_ToConnect in lstClient)
                    {
                        // Ktra sđt đó có rảnh hay không, nếu không rảnh thì phản hồi lại cho client.
                        // Phòng trường hợp có nhiều ng cùng lúc bấm kết nối tới 1 ng.
                        if (client_ToConnect.Sdt == sdt_ConnectTo && IsChatting_OR_RandomChat(client_ToConnect.Sdt))
                        {
                            SendData(socket, "Fail");
                            break;
                        }
                        else
                        {
                            if (client_ToConnect.Sdt == sdt_ConnectTo && !IsChatting_OR_RandomChat(client_ToConnect.Sdt))
                            {
                                // Gửi thông báo kết nối tới sđt đối phương.
                                SendData(client_ToConnect.Listen, "Connect");
                                // Nhận thông báo phản hồi về (chấp nhận or từ chối);
                                string recieve = RecieveData(client_ToConnect.Listen);
                                if (recieve == "Ok")
                                {
                                    // Gửi thông tin đối phương cho người gọi kết nối.
                                    SendData(socket, client_ToConnect.Sdt);
                                    // Gửi sđt cho người được yêu cầu kết nối.
                                    SendData(client_ToConnect.Socket, client_CallConnect.Sdt);
                                    client_CallConnect.IsChatting = true;
                                    client_ToConnect.IsChatting = true;
                                    client_CallConnect.IsBusy = false;
                                    // Tạo file lưu lịch sử Chat
                                    CreateHistoryFile(sdt_CallConnect, sdt_ConnectTo);
                                    CreateHistoryFile(sdt_ConnectTo, sdt_CallConnect);
                                }
                                else
                                {
                                    SendData(socket, "Refuse");
                                    client_CallConnect.IsBusy = false;
                                }
                                break;
                            }
                        }
                    }
                    SendRefreshNoitice();
                    break;
                }
            }
        }

        public static void CreateHistoryFile(string sdt, string sdt_History)
        {
            string path = "Profile/" + sdt + "/History/" + sdt_History + ".txt";
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }
        }

        public static void NgatKetNoiChat(string sdt, string sdtDoiPhuong)
        {
            foreach (Clients client in lstClient)
            {
                if (client.Sdt.Equals(sdt))
                {
                    client.IsBusy = true;
                    // Tìm đối phương
                    foreach (Clients destination in lstClient)
                    {
                        if (destination.Sdt.Equals(sdtDoiPhuong) && destination.IsChatting)
                        {
                            SendData(destination.Chatting, "-1-EndChat");
                            SendData(client.Chatting, "-1-EndChat");
                            // Gửi kết quả và chỉnh sửa trạng thái Client.
                            SendData(client.Socket, "OK");
                            client.IsRandom = false;
                            client.IsChatting = false;
                            client.IsBusy = false;
                            break;
                        }
                        if (destination.Sdt.Equals(sdtDoiPhuong) && !destination.IsChatting)
                        {
                            // Gửi kết quả và chỉnh sửa trạng thái Client.
                            SendData(client.Socket, "OK");
                            client.IsRandom = false;
                            client.IsChatting = false;
                            client.IsBusy = false;
                            break;
                        }
                    }
                    break;
                }
            }
            SendRefreshNoitice();
        }

        public static void NgatKetNoiRandomChat(string sdt)
        {
            foreach (Clients client in lstClient) // Tìm người dùng hủy kết nối
            {
                if (client.Sdt == sdt)
                {
                    client.IsBusy = true;
                    // Tìm và xóa người dùng trong danh sách Random
                    LinkedListNode<InfoRandomClients> node = listRandoms.First;
                    int j = 1;
                    while (node != null)
                    {
                        if (node.Value.Sdt.Equals(sdt))
                        {
                            if (j % 2 == 0) // Stt chẵn, xóa thêm người dùng phía trước.
                            {
                                SendData(node.Previous.Value.Chatting, "-1-EndChat");
                                SendData(node.Value.Chatting, "-1-EndChat");
                                listRandoms.Remove(node.Previous);
                                listRandoms.Remove(node);
                                break;
                            }
                            else // Stt lẻ, xóa thêm người dùng phía sau.
                            {
                                if (node.Next != null)
                                {
                                    SendData(node.Next.Value.Chatting, "-1-EndChat");
                                    SendData(node.Value.Chatting, "-1-EndChat");
                                    listRandoms.Remove(node.Next);
                                    listRandoms.Remove(node);
                                    break;
                                }
                                else
                                {
                                    listRandoms.Remove(node);
                                    break;
                                }
                            }
                        }
                        j++;
                        node = node.Next;
                    }
                    // Gửi thông báo và đổi trạng thái người dùng
                    SendData(client.Socket, "OK");
                    client.IsRandom = false;
                    client.IsChatting = false;
                    client.IsBusy = false;
                    break;
                }
            }
            SendRefreshNoitice();
        }

        public static void AddMessageToHistory(string sdt, string sdtDoiPhuong, string message)
        {
            string path = "Profile/" + sdt + "/History/" + sdtDoiPhuong + ".txt";
            // Ghi tin nhắn
            string[] data = File.ReadAllLines(path);
            // Tạo mảng mới nhiều hơn 1 dòng để ghi dữ liệu
            string[] insert = new string[data.Length + 1];
            // Copy mảng cũ vô mảng mới gòi ghi đè file.
            Array.Copy(data, insert, data.Length);
            insert[data.Length] = message;
            File.WriteAllLines(path, insert);
        }

        public static void SendingMessage(string nhan)
        {
            // nhan = Lệnh - SĐT - SĐT đối phương - Message
            string[] value = nhan.Split("-");
            string sdt = value[1];
            // Nối chuỗi nếu người dùng nhập các ký tự đặc biệt gây lỗi tin nhắn.
            string message = "";
            for (int i = 3; i < value.Length; i++)
                message += value[i];
            foreach (Clients client in lstClient)
            {
                if (client.Sdt.Equals(sdt))
                {
                    // Tìm đối phương
                    foreach (Clients destination in lstClient)
                    {
                        if (destination.Sdt.Equals(value[2]))
                        {
                            SendData(destination.Chatting, message.Substring(1));
                            // Thêm tin nhắn vào file
                            AddMessageToHistory(sdt, value[2], message); // Thêm vào lịch sử người gửi
                            AddMessageToHistory(value[2], sdt, "0" + message.Substring(1)); // Thêm vào lịch sử người nhận
                        }
                    }
                }
            }
        }

        public static void SendingRandomMessage(string nhan)
        {
            // nhan = Lệnh - SĐT - Stranger - Message
            string[] value = nhan.Split("-");
            string sdt = value[1];
            // Nối chuỗi nếu người dùng nhập các ký tự đặc biệt gây lỗi tin nhắn.
            string message = "";
            for (int i = 3; i < value.Length; i++)
                message += value[i];
            int j = 1;
            LinkedListNode<InfoRandomClients> node = listRandoms.First;
            while (node != null)
            {
                if (node.Value.Sdt.Equals(sdt)) // Tìm người dùng
                {
                    if (j % 2 == 0) // stt chẵn thì gửi tin nhắn cho người đứng trước
                    {
                        SendData(node.Previous.Value.Chatting, message.Substring(1));
                        // Thêm tin nhắn vào file
                        AddMessageToHistory(sdt, value[2], message); // Thêm vào lịch sử người gửi
                        AddMessageToHistory(node.Previous.Value.Sdt, value[2], "0" + message.Substring(1)); // Thêm vào lịch sử người nhận
                    }
                    else // stt lẻ thì gửi tin nhắn cho ng đứng sau.
                    {
                        if (node.Next != null) //Người đứng sau có tồn tại.
                        {
                            SendData(node.Next.Value.Chatting, message.Substring(1));
                            // Thêm tin nhắn vào file
                            AddMessageToHistory(sdt, value[2], message); // Thêm vào lịch sử người gửi
                            AddMessageToHistory(node.Next.Value.Sdt, value[2], "0" + message.Substring(1)); // Thêm vào lịch sử người nhận
                        }
                    }
                    break;
                }
                j++;
                node = node.Next;
            }
        }

        public static void LoadHistoryMessage(Socket socket, string nhan)
        {
            // nhan = Lệnh - SĐT - SĐT đối phương
            string[] value = nhan.Split("-");
            string sdt = value[1];
            string path = "Profile/" + sdt + "/History/" + value[2] + ".txt";
            string message = "";
            // Đọc file, gửi tin nhắn cho client.
            string[] data_chat = File.ReadAllLines(path);
            // Đổi trạng thái người dùng sang đang bận để load tin nhắn.
            foreach (Clients client in lstClient)
            {
                if (client.Sdt.Equals(sdt))
                {
                    client.IsBusy = true;
                    for (int i = 0; i < data_chat.Length; i++)
                    {
                        if (data_chat[i].Equals("") || data_chat[i] == null)
                            continue;
                        if (i == data_chat.Length - 1)
                        {
                            message += data_chat[i];
                            SendData(socket, message);
                            message = "";
                        }
                        else
                        {
                            if (data_chat[i + 1].Substring(0, 1).Equals("0") || data_chat[i + 1].Substring(0, 1).Equals("1"))
                            {
                                message += data_chat[i];
                                SendData(socket, message);
                                message = "";
                            }
                            else
                            {
                                message += data_chat[i];
                            }
                        }
                    }
                    SendData(socket, "-1");
                    client.IsBusy = false;
                    break;
                }
            }
        }

        public static void LoadHistory(Socket socket, string sdt)
        {
            // Đọc toàn bộ sđt của các người dùng đã từng kết nối tới
            string[] historyNumber = Directory.GetFiles("Profile/" + sdt + "/History/", "*.txt");
            // Lấy thông tin của các người dùng đó và gửi cho Client
            // Duyệt qua từng tên file, tìm thông tin người dùng và trả về.
            for (int i = 0; i < historyNumber.Length; i++)
            {
                if (Path.GetFileName(historyNumber[i]).Equals("Stranger.txt"))
                {
                    SendData(socket, "Stranger");
                    continue;
                }
                string path = "Profile/" + Path.GetFileName(historyNumber[i]).Substring(0, 10) + "/Info.txt";
                // Directory.GetFiles sẽ trả về đường dẫn đầy đủ của file đó nên dùng GetFileName để lấy mỗi tên file, sau đó cắt chuỗi 10 ký tự để lấy SĐT.
                // Đọc thông tin
                string[] info = File.ReadAllLines(path);
                // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                SendData(socket, Path.GetFileName(historyNumber[i]).Substring(0, 10));
                // Tạo vòng lặp gửi từng dòng dữ liệu.
                for (int j = 0; j < info.Length; j++)
                {
                    SendData(socket, j + "-" + info[j]);
                }
                SendData(socket, "Next");
            }
            SendData(socket, "End");
        }

        public static void AddClientToRandomList(Socket socket, string sdt)
        {
            if (listRandoms.Count == 0)
            {
                listRandoms.AddFirst(new InfoRandomClients(socket, sdt));
            }
            else
            {
                // Kiểm tra node đó có trong list hay chưa, chưa thì thêm vô.
                LinkedListNode<InfoRandomClients> node = listRandoms.First;
                while (node != null)
                {
                    if (node.Value.Sdt.Equals(sdt))
                        return;
                    node = node.Next;
                }
                listRandoms.AddLast(new InfoRandomClients(socket, sdt));
            }
        }

        public static void RandomChat(Socket socket, string sdt)
        {
            // Lặp 2 lần, 1 lần để đổi trạng thái người dùng, lần 2 để tìm người ghép đôi.
            foreach (Clients thisClient in lstClient)
            {
                // Đổi chế độ người dùng thành đang RandomChat
                if (thisClient.Sdt.Equals(sdt))
                {
                    thisClient.IsRandom = true;
                    thisClient.IsBusy = true;
                    AddClientToRandomList(thisClient.Chatting, sdt);
                    // Lặp lần nữa để tìm người chat.
                    // Thuật toán ở đây là, chỉ khi LinkedList chứa các người dùng đang Random có số lượng >= 2 thì mới bắt đầu ghép đôi.
                    // Người giữ vị trí lẻ sẽ ghép với người đứng sau, stt 1 ghép với stt 2, 5 ghép với 6.
                    // Người giữ vị trí chẵn sẽ ghép với người đứng trước, stt 2 ghép với stt 1, 10 ghép với 9. Như vậy sẽ giải quyết đc vấn đề về việc dữ liệu tự động update.
                    for (int i = 0; i <= 5; i++) // Server thực hiện tìm kiếm 5 lần cho client.
                    {
                        if (i == 5) // Lặp hết 5 lần mà k có kquả
                        {
                            SendData(socket, "Fail");
                            break;
                        }
                        if (listRandoms.Count >= 2)
                        {
                            int j = 1;
                            LinkedListNode<InfoRandomClients> node = listRandoms.First;
                            while (node != null) // Lặp lần 2
                            {
                                if (node.Value.Sdt.Equals(sdt)) // Tìm người dùng
                                {
                                    if (j % 2 == 0) // stt chẵn
                                    {
                                        SendData(socket, "Success");
                                        thisClient.IsChatting = true;
                                        thisClient.IsBusy = false;
                                        SendRefreshNoitice();
                                        CreateHistoryFile(sdt, "Stranger");
                                        return;
                                    }
                                    else // stt lẻ
                                    {
                                        if (node.Next != null) //Người đứng sau có tồn tại.
                                        {
                                            SendData(socket, "Success");
                                            thisClient.IsChatting = true;
                                            thisClient.IsBusy = false;
                                            SendRefreshNoitice();
                                            CreateHistoryFile(sdt, "Stranger");
                                            return;
                                        }
                                    }
                                    break;
                                }
                                j++;
                                node = node.Next;
                            }
                        }
                        Thread.Sleep(200);
                    }
                    break; // Phá vòng lặp 1
                }
            }
        }

        public static void GetNumberValiddationEmail(Socket socket, string email)
        {
            MailAddress gui = new MailAddress("bakamiri2016@gmail.com");
            MailAddress nhan = new MailAddress(email);
            // Random Mã Xác Minh
            Random ran = new Random();
            int maXacMinh = ran.Next(111111, 999999);
            MailMessage con = new MailMessage();
            con.From = gui;
            con.To.Add(nhan);
            con.Subject = "Mã xác minh tài khoản người dùng.";
            con.Body = "Chào bạn! <br/> Chúng tôi rất vui vì bạn đã lựa chọn sử dụng ứng dụng của chúng tôi. <br/>" +
                       " Đây là mã xác minh cho tài khoản của bạn: " + maXacMinh.ToString() + "<br/> Chân thành cám ơn!";
            con.Priority = MailPriority.High;
            con.IsBodyHtml = true;
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("bakamiri2016@gmail.com", "bach2908");
                client.Send(con);
                SendData(socket, maXacMinh.ToString());
            }
            catch
            {
                return;
            }
        }

        public static void ChangeInfoAccount(Socket socket, string nhan)
        {
            // nhan = Lệnh - Sđt - Tên - Giới Tính - Ngày Sinh - Email (Có khoặc không) - Tiểu Sử
            string[] tmp = nhan.Split('-');
            // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
            string[] info_User = File.ReadAllLines("Profile/" + tmp[1] + "/Info.txt");
            if (tmp.Length == 7) // Có thay đổi Email
            {
                info_User[0] = tmp[2];
                info_User[1] = tmp[3];
                info_User[2] = tmp[4];
                info_User[6] = tmp[5];
                info_User[7] = tmp[6];
            }
            else
            {
                info_User[0] = tmp[2];
                info_User[1] = tmp[3];
                info_User[2] = tmp[4];
                info_User[7] = tmp[5];
            }
            File.WriteAllLines("Profile/" + tmp[1] + "/Info.txt", info_User);
            SendData(socket, "Done");
            SendRefreshNoitice();
        }

        public static void ForgotPassword_Check(Socket socket, string nhan)
        {
            bool exist = false;
            // nhan = Lệnh - Sđt - Email
            string[] tmp = nhan.Split('-');
            string sdt = tmp[1];
            string email = tmp[2];
            // Tìm số điện thoại
            string[] allAccount = File.ReadAllLines("Account.txt");
            for (int i = 0; i < allAccount.Length; i++)
            {
                if (allAccount[i].Equals(""))
                    continue;
                string[] sdt_passwd = tmp[i].Split('-');
                if (sdt_passwd[0] == sdt)
                {
                    exist = true;
                    break;
                }
            }
            if (exist) // SĐT có tồn tại thì tìm tiếp Email.
            {
                // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                string[] infoAccount = File.ReadAllLines("Profile/" + sdt + "/Info.txt");
                if (infoAccount[6].Equals(email))
                {
                    SendData(socket, "Yes");
                }
                else
                    SendData(socket, "No");
            }
            else
            {
                SendData(socket, "No");
            }
        }

        public static void ForgotPassword_ChangePassword(Socket socket, string nhan)
        {
            // Nhận = Lệnh - SĐT - Mật Khẩu Mới
            string[] tmp = nhan.Split('-');
            string sdt = tmp[1];
            string newPasswd = tmp[2];
            // Đọc dữ liệu từ file tài khoản người dùng
            string[] allAccount = File.ReadAllLines("Account.txt");
            // Lọc ra dòng thông tin tương ứng để đổi.
            for (int i = 0; i < allAccount.Length; i++)
            {
                if (allAccount[i].Equals(""))
                    continue;
                string[] account = allAccount[i].Split('-');
                if (account[0].Equals(sdt))
                {
                    allAccount[i] = sdt + "-" + newPasswd;
                    File.WriteAllLines("Account.txt", allAccount);
                    SendData(socket, "1");
                    break;
                }
            }
        }

        public static void HandleClient(Socket socket)
        {
            string nhan;
            while (SocketConnected(socket))
            {
                try
                {
                    nhan = RecieveData(socket);
                    Console.WriteLine(nhan);
                    string[] tmp = nhan.Split('-');
                    // Chuỗi đầu luôn là từ khoá để gọi hàm
                    switch (tmp[0])
                    {
                        case "LoadDuLieuDangNhap":
                            LoadDuLieuDangNhap(socket, tmp[1]);
                            break;
                        case "DoiTrangThai":
                            DoiTrangThai(tmp[1], tmp[2]);
                            break;
                        case "DoiAvatar":
                            DoiAvatar(tmp[1], tmp[2]);
                            break;
                        case "DoiMatKhau":
                            DoiMatKhau(socket, nhan);
                            break;
                        case "LoadOnlineUsers":
                            LoadOnlineUsers(socket, tmp[1]);
                            break;
                        case "LoadThongTinUser":
                            LoadThongTinUser(socket, tmp[1]);
                            break;
                        case "KetNoiChat":
                            KetNoiChat(socket, nhan);
                            break;
                        case "NgatKetNoiChat":
                            NgatKetNoiChat(tmp[1], tmp[2]);
                            break;
                        case "NgatKetNoiRandomChat":
                            NgatKetNoiRandomChat(tmp[1]);
                            break;
                        case "RandomChat":
                            RandomChat(socket, tmp[1]);
                            break;
                        case "GetNumberValiddationEmail":
                            GetNumberValiddationEmail(socket, tmp[1]);
                            break;
                        case "Logout":
                            Logout(socket, tmp[1]);
                            return;
                        case "ChangeInfoAccount":
                            ChangeInfoAccount(socket, nhan);
                            break;
                        case "LoadHistory":
                            LoadHistory(socket, tmp[1]);
                            break;
                        case "SendingMessage":
                            SendingMessage(nhan);
                            break;
                        case "SendingRandomMessage":
                            SendingRandomMessage(nhan);
                            break;
                        case "LoadHistoryMessage":
                            LoadHistoryMessage(socket, nhan);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        static void Main(string[] args)
        {
            LogoutAllUsers();
            Console.WriteLine("Server:");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipep = new IPEndPoint(ip, 12501);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(50);
            lstClient = new List<Clients>();
            listRandoms = new LinkedList<InfoRandomClients>();
            // Xử lý Client
            while (true)
            {
                string nhan;
                Socket listen = server.Accept();
                Socket socket = server.Accept();
                Socket chatting = server.Accept();
                Thread t = new Thread(() =>
                {
                    bool login = false;
                    // Kiểm tra bước Login của người dùng
                    while (SocketConnected(socket))
                    {
                        try
                        {
                            nhan = RecieveData(socket);
                            Console.WriteLine(nhan);
                            string[] tmp = nhan.Split('-');
                            // Chuỗi đầu luôn là từ khoá để gọi hàm
                            if (tmp[0].Equals("CancelLogin"))
                            {
                                break;
                            }
                            if (tmp[0].Equals("ForgotPassword"))
                                ForgotPassword_Check(socket, nhan);
                            if (tmp[0].Equals("GetNumberValiddationEmail"))
                                GetNumberValiddationEmail(socket, tmp[1]);
                            if (tmp[0].Equals("ForgotPassword_ChangePassword"))
                                ForgotPassword_ChangePassword(socket, nhan);
                            if (tmp[0].Equals("DangKy"))
                                DangKyTaiKhoan(socket, nhan);
                            if (tmp[0].Equals("Login"))
                            {
                                if (CheckLogin(socket, listen, chatting, nhan))
                                {
                                    login = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e); }
                    }
                    if (login)
                        HandleClient(socket);
                    else
                    {
                        socket.Close();
                        chatting.Close();
                        listen.Close();
                        return;
                    }
                });
                t.Start();
            }
            // END
        }

    }
}
