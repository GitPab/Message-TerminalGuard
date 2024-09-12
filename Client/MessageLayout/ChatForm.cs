using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
                    if (nhan.Substring(0, 1).Equals("1")) // Tin nhắn của mình
                    {
                        AddMyHistoryChat(nhan.Substring(1));
                    }
                    else
                    {
                        AddTheyHistoryChat(nhan.Substring(1));
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
                AddTheyChat(nhan);
            }
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
            if(e.KeyCode == Keys.Enter)
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
    }
}
