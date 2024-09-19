using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public partial class GroupChatForm : Form
    {
        string group_Name; // Số điện thoại của đối phương.
        string sdt; // Số điện thoại của người dùng đang đăng nhập
        Thread t;
        bool isChatting;

        public GroupChatForm(string sdt)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.sdt = sdt;
            LoadGroupChatMessage();
            isChatting = true;
            t = new Thread(UpdateChat);
            t.Start();
        }

        public GroupChatForm(string sdt, string groupName)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.sdt = sdt;
            this.group_Name = groupName;
            // Load dữ liệu của đối phương lên Form
            LoadDuLieu();
            LoadGroupChatMessage();
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
            label_Name.Text = group_Name;
        }

        public void LoadGroupChatMessage()
        {
            if (group_Name != null)
            {
                GlobalConnect.SendData(GlobalConnect.svcn, "LoadGroupChatMessage-" + sdt + "-" + group_Name);

            }

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
                    string[] parts = nhan.Split(new char[] { ':' }, 4);

                    string phoneNumber = parts[0]; // Số điện thoại
                    string usename = parts[1]; // Loại nội dung (FILE hoặc CHAT)
                    string type = parts[2]; // Loại nội dung (FILE hoặc CHAT)

                    if (phoneNumber.Equals(sdt))
                    {
                        if (type.Equals("FILE"))
                        {
                            AddMyGroupChatFile(parts[3]); 
                        }
                        else
                        {
                            AddMyGroupChatChat(type);
                        }
                    }
                    else
                    {
                        if (type.Equals("FILE"))
                        {
                            AddTheyGroupChatFile(usename + ":" + parts[3]);
                        }
                        else
                        {
                            AddTheyGroupChatChat(usename + ":" + type);
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
                if (nhan.StartsWith("ReceivingFileGroup"))
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
            if (parts.Length != 4)
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
            string senderGroupChatDir = Path.GetDirectoryName($"GroupChat/{fileName}");

            if (!Directory.Exists(senderGroupChatDir))
            {
                Directory.CreateDirectory(senderGroupChatDir);
            }

            string senderGroupChatPath = $"GroupChat/{fileName}";

            File.Copy(tempFilePath, senderGroupChatPath, true);

            // Hiển thị thông tin file lên view
            AddFileToView(parts[3], senderGroupChatPath);

        }
        void AddFileToView(string usename, string filePath)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    AddFileToView(usename, filePath);
                });
                return;
            }
            Comming comming = new Comming();
            comming.Message = usename;
            flowLayoutPanel.Controls.Add(comming);
            flowLayoutPanel.ScrollControlIntoView(comming);

            CommingFile commingFile = new CommingFile();
            commingFile.FilePath = filePath;
            flowLayoutPanel.Controls.Add(commingFile);
            flowLayoutPanel.ScrollControlIntoView(commingFile);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn kết thúc cuộc trò truyện ?", "Kết thúc!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                if (group_Name != null)
                    GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiGroupChat-" + sdt + "-" + group_Name);
                string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                if (nhan.Equals("OK"))
                    this.Close();
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            AddMyChat(txt_Message.Text);
        }

        void AddMyGroupChatChat(string text)
        {
            GoingMessage goingMessage = new GoingMessage();
            goingMessage.Message = text;
            flowLayoutPanel.Controls.Add(goingMessage);
            flowLayoutPanel.ScrollControlIntoView(goingMessage);
        }

        void AddTheyGroupChatChat(string text)
        {
            string[] value = text.Split(':');

            Comming comming = new Comming();
            comming.Message = value[0];
            flowLayoutPanel.Controls.Add(comming);
            flowLayoutPanel.ScrollControlIntoView(comming);

            CommingMessage commingMessage = new CommingMessage();
            commingMessage.Message = value[1];
            flowLayoutPanel.Controls.Add(commingMessage);
            flowLayoutPanel.ScrollControlIntoView(commingMessage);
        }

        void AddMyGroupChatFile(string fileName)
        {
            string filePath = $"GroupChat/{fileName}";
            GoingFile goingFile = new GoingFile();
            goingFile.FilePath = filePath;
            flowLayoutPanel.Controls.Add(goingFile);
            flowLayoutPanel.ScrollControlIntoView(goingFile);
        }

        void AddTheyGroupChatFile (string text)
        {
            string[] value = text.Split(':');

            Comming comming = new Comming();
            comming.Message = value[0];
            flowLayoutPanel.Controls.Add(comming);
            flowLayoutPanel.ScrollControlIntoView(comming);

            string fileName = value[1];
            string filePath = $"GroupChat/{fileName}";
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
                SendingMessage(txt_Message.Text.Trim());
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
                    AddTheyGroupChatChat(text);
                });
            }
            else
            {
                AddTheyGroupChatChat(text);
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
            if (group_Name != null)
                GlobalConnect.SendData(GlobalConnect.svcn, "SendingGroupMessage-" + sdt + "-" + group_Name + "-" + message);
        }

        private void picture_Click(object sender, EventArgs e)
        {
            if (group_Name != null)
            {
                AccountForm ac = new AccountForm(group_Name);
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


                string senderGroupChatDir = Path.GetDirectoryName($"GroupChat/{fileName}");

                if (!Directory.Exists(senderGroupChatDir))
                {
                    Directory.CreateDirectory(senderGroupChatDir);
                }

                string senderGroupChatPath = $"GroupChat/{fileName}";

                File.Copy(filePath, senderGroupChatPath, true);

                GoingFile goingFile = new GoingFile();
                goingFile.FilePath = senderGroupChatPath;
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
                string fileInfo = $"SendingGroupFile-{sdt}-{group_Name}-{fileName}-{fileSize}";
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
