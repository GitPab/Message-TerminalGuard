using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatForm : Form
    {
        string sdt_DoiPhuong; // Số điện thoại của đối phương.
        string sdt; // Số điện thoại của người dùng đang đăng nhập
        Thread t;
        bool isChatting;

        public ChatForm(string sdt)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.sdt = sdt;
            LoadHistoryMessage();
            isChatting = true;
            t = new Thread(UpdateChat);
            t.Start();
        }

        public ChatForm(string sdt, string sdtDoiPhuong)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.sdt = sdt;
            this.sdt_DoiPhuong = sdtDoiPhuong;
            // Load dữ liệu của đối phương lên Form
            LoadDuLieu();
            LoadHistoryMessage();
            isChatting = true;
            t = new Thread(UpdateChat);
            t.Start();
        }

        public void HiddenCloseButton()
        {
            btn_Close.Visible = false;
        }

        public void LoadDuLieu()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadThongTinUser-" + sdt_DoiPhuong);
            string nhan;
            while (true)
            {
                nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                if (nhan == "End")
                    break;
                // nhan = Key - Value
                string[] value = nhan.Split('-');
                switch (value[0])
                {
                    // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                    case "0":
                        label_Name.Text = value[1];
                        break;
                    case "5":
                        picture.Image = Image.FromFile(value[1]);
                        break;
                }
            }
        }

        public void LoadHistoryMessage()
        {
            if (sdt_DoiPhuong != null)
                GlobalConnect.SendData(GlobalConnect.svcn, "LoadHistoryMessage-" + sdt + "-" + sdt_DoiPhuong);
            else
                GlobalConnect.SendData(GlobalConnect.svcn, "LoadHistoryMessage-" + sdt + "-Stranger");
            string nhan = "";
            // Load tin nhắn cũ lên
            while (true)
            {
                nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                if (nhan == "-1")
                {
                    break;
                }
                else
                {
                    if (nhan.Substring(0, 1).Equals("1")) 
                    {
                        if (nhan.Substring(1).StartsWith("FILE:"))
                        {
                            AddMyHistoryFile(nhan.Substring(1));
                        }
                        else
                        {
                            AddMyHistoryChat(nhan.Substring(1));
                        }
                    }
                    else
                    {
                        if (nhan.Substring(1).StartsWith("FILE:"))
                        {
                            AddTheyHistoryFile(nhan.Substring(1));
                        }
                        else
                        {
                            AddTheyHistoryChat(nhan.Substring(1));
                        }
                    }

                }

            }
        }

        void UpdateChat()
        {
            while (t.IsAlive)
            {
                string nhan = GlobalConnect.RecieveData(GlobalConnect.chatting);
                if (nhan.Equals("-1-EndChat") && isChatting) // Người đang Chatting là người nhận thông báo kết thúc chat từ đối phương
                {
                    isChatting = false;
                    btn_Send.Enabled = false;
                    txt_Message.ReadOnly = true;
                    txt_Message.Text = "Bạn không thể trả lời cuộc trò truyện này \n Đối phương đã ngắt kết nối!";
                    t.Abort();
                    break;
                }
                if (nhan.Equals("-1-EndChat") && !isChatting) // Đây là người gửi thông báo kết thúc chat, Server trả kết quả về để phá vòng lặp.
                {
                    t.Abort();
                    break;
                }
                if (nhan.StartsWith("ReceivingFile-"))
                {
                    HandleFileMessage(nhan);
                }else
                {
                    AddTheyChat(nhan);
                }
            }
        }
        void HandleFileMessage(string fileMessage)
        {
            // Phân tích thông tin file
            string[] parts = fileMessage.Split('-');
            if (parts.Length != 3)
            {
                Console.WriteLine("Thông tin file không hợp lệ.");
                return;
            }

            string fileName = parts[1];
            long fileSize;
            if (!long.TryParse(parts[2], out fileSize))
            {
                Console.WriteLine("Kích thước file không hợp lệ.");
                return;
            }

            // Tạo thư mục lưu trữ tạm thời cho file
            string tempFilePath = Path.GetTempFileName();
            using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                long totalBytesReceived = 0;

                // Nhận dữ liệu file từ socket và lưu vào tệp tạm thời
                while (totalBytesReceived < fileSize)
                {
                    string chunk = GlobalConnect.RecieveData(GlobalConnect.chatting);
                    byte[] data = Convert.FromBase64String(chunk);
                    fileStream.Write(data, 0, data.Length);
                    totalBytesReceived += data.Length;
                }
            }
            string senderHistoryDir = Path.GetDirectoryName($"Profile/History/{fileName}");

            if (!Directory.Exists(senderHistoryDir))
            {
                Directory.CreateDirectory(senderHistoryDir);
            }

            string senderHistoryPath = $"Profile/History/{fileName}";

            File.Copy(tempFilePath, senderHistoryPath, true);

            // Hiển thị thông tin file lên view
            AddFileToView(senderHistoryPath);

        }
        void AddFileToView(string filePath)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    AddFileToView(filePath);
                });
                return;
            }

            CommingFile commingFile = new CommingFile();
            commingFile.FilePath = filePath;
            flowLayoutPanel.Controls.Add(commingFile);
            flowLayoutPanel.ScrollControlIntoView(commingFile);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (isChatting) // Khi biến này đang True tức người này là người chủ động gửi thông báo Kết Thúc Chat
            {
                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn kết thúc cuộc trò truyện ?", "Kết thúc!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    if (sdt_DoiPhuong != null)
                        GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiChat-" + sdt + "-" + sdt_DoiPhuong);
                    else
                        GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiRandomChat-" + sdt);
                    isChatting = false; // Đổi biến này để hàm Update nhận biết người nào chủ động Kết Thúc Chat, người nào nhận thông báo.
                    string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                    if (nhan.Equals("OK"))
                        this.Close();
                }
            }
            else
            {
                if (sdt_DoiPhuong != null)
                    GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiChat-" + sdt + "-" + sdt_DoiPhuong);
                else
                    GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiRandomChat-" + sdt);
                string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                if (nhan.Equals("OK"))
                    this.Close();
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            AddMyChat(txt_Message.Text);
        }

        void AddMyHistoryChat(string text)
        {
            GoingMessage goingMessage = new GoingMessage();
            goingMessage.Message = text;
            flowLayoutPanel.Controls.Add(goingMessage);
            flowLayoutPanel.ScrollControlIntoView(goingMessage);
        }

        void AddTheyHistoryChat(string text)
        {
            CommingMessage commingMessage = new CommingMessage();
            commingMessage.Message = text;
            flowLayoutPanel.Controls.Add(commingMessage);
            flowLayoutPanel.ScrollControlIntoView(commingMessage);
        }

        void AddMyHistoryFile(string fileName)
        {
            string[] parts = fileName.Split(':');
            string filePath = $"Profile/History/{parts[1]}";
            GoingFile goingFile = new GoingFile();
            goingFile.FilePath = filePath;
            flowLayoutPanel.Controls.Add(goingFile);
            flowLayoutPanel.ScrollControlIntoView(goingFile);
        }

        void AddTheyHistoryFile (string fileName)
        {
            string[] parts = fileName.Split(':');
            string filePath = $"Profile/History/{parts[1]}";
            CommingFile goingFile = new CommingFile();
            goingFile.FilePath = filePath;
            flowLayoutPanel.Controls.Add(goingFile);
            flowLayoutPanel.ScrollControlIntoView(goingFile);
        }

        void AddMyChat(string text)
        {
            if (text.Equals("-1-EndChat"))
            {
                MessageBox.Show("Lỗi! Hãy thử nhập kiểu dữ liệu khác.");
                txt_Message.Text = "";
                return;
            }
            if (!text.Equals("") && isChatting)
            {
                GoingMessage goingMessage = new GoingMessage();
                goingMessage.Message = text;
                flowLayoutPanel.Controls.Add(goingMessage);
                SendingMessage("1" + txt_Message.Text.Trim());
                txt_Message.Text = "";
                flowLayoutPanel.ScrollControlIntoView(goingMessage);
            }
        }

        void AddTheyChat(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    CommingMessage commingMessage = new CommingMessage();
                    commingMessage.Message = text;
                    flowLayoutPanel.Controls.Add(commingMessage);
                    flowLayoutPanel.ScrollControlIntoView(commingMessage);
                });
            }
            else
            {
                CommingMessage commingMessage = new CommingMessage();
                commingMessage.Message = text;
                flowLayoutPanel.Controls.Add(commingMessage);
                flowLayoutPanel.ScrollControlIntoView(commingMessage);
            }
        }

        private void Click_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMyChat(txt_Message.Text);
            }
        }

        public void SendingMessage(string message)
        {
            if (sdt_DoiPhuong != null)
                GlobalConnect.SendData(GlobalConnect.svcn, "SendingMessage-" + sdt + "-" + sdt_DoiPhuong + "-" + message);
            else
                GlobalConnect.SendData(GlobalConnect.svcn, "SendingRandomMessage-" + sdt + "-Stranger-" + message);
        }

        private void picture_Click(object sender, EventArgs e)
        {
            if (sdt_DoiPhuong != null)
            {
                AccountForm ac = new AccountForm(sdt_DoiPhuong);
                ac.ShowLabel_ChinhSua(false);
                ac.ShowDialog();
            }
        }

        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);


                string senderHistoryDir = Path.GetDirectoryName($"Profile/History/{fileName}");

                if (!Directory.Exists(senderHistoryDir))
                {
                    Directory.CreateDirectory(senderHistoryDir);
                }

                string senderHistoryPath = $"Profile/History/{fileName}";

                File.Copy(filePath, senderHistoryPath, true);

                GoingFile goingFile = new GoingFile();
                goingFile.FilePath = senderHistoryPath;
                goingFile.Padding = new Padding(0, 0, 10, 0);
                flowLayoutPanel.Controls.Add(goingFile);
                flowLayoutPanel.ScrollControlIntoView(goingFile); 

                SendFile(filePath);
            }
        }
        private void SendFile(string filePath)
        {
            try
            {
                string fileName = Path.GetFileName(filePath);
                long fileSize = new FileInfo(filePath).Length;

                // Tạo thông tin file và gửi
                string fileInfo = $"SendingFile-{sdt}-{sdt_DoiPhuong}-{fileName}-{fileSize}";
                GlobalConnect.SendData(GlobalConnect.svcn, fileInfo);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;

                    // Gửi dữ liệu file
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // Chuyển đổi dữ liệu thành chuỗi Base64 và gửi
                        string chunk = Convert.ToBase64String(buffer, 0, bytesRead);
                        GlobalConnect.SendData(GlobalConnect.svcn, chunk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi file: {ex.Message}");
            }
        }

    }
}
