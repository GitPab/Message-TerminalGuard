using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.MainLayout
{
    public partial class HistoryForm : Form
    {
        string sdtLogin, sdtDoiPhuong = "";
        public static HistoryForm historyForm; // Phục vụ cho việc gọi lịch sử chat của các người dùng từ form khác.

        public HistoryForm(string sdt)
        {
            historyForm = this;
            InitializeComponent();
            this.sdtLogin = sdt;
            LoadHistory();
        }

        public void LoadHistory()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadHistory-" + sdtLogin);
            flowLayoutPanel_HistoryUser.Controls.Clear();
            HistoryUsers historyUsers;
            string nhan;
            while (true)
            {
                nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                if (nhan == "End")
                    break;
                if(nhan.Equals("Stranger"))
                {
                    historyUsers = new HistoryUsers();
                    this.flowLayoutPanel_HistoryUser.Controls.Add(historyUsers);
                    continue;
                }    
                historyUsers = new HistoryUsers();
                historyUsers.SDT = nhan;
                // Vòng lặp 2 nhận từng dòng thông tin về 1 người và set dữ liệu lên form.
                while (true)
                {
                    nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                    if (nhan == "Next")
                        break;
                    // nhan = Key - Value ------ Value[0] = Key 
                    string[] value = nhan.Split('-');
                    switch (value[0])
                    {
                        // 0 = Tên; 1 = Giới Tính; 2 = Ngày Sinh; 3 = Trạng Thái; 4 = Login or Log out; 5 = Path Avatar; 6 = Email; 7 = Tiểu Sử
                        case "0":
                            historyUsers.UserName = value[1];
                            break;
                        case "5":
                            historyUsers.Avatar = value[1];
                            break;
                    }
                }
                historyUsers.SdtLogin = sdtLogin;
                this.flowLayoutPanel_HistoryUser.Controls.Add(historyUsers);
            }
        }

        private Form historyMessage;

        public void LoadHistoryMessage(string sdtDoiPhuong)
        {
            if(!this.sdtDoiPhuong.Equals(sdtDoiPhuong)) // SĐT cần xem lịch sử không trùng với SĐT hiện tại đang hiển thị thì mới load lại lịch sử.
            {
                this.sdtDoiPhuong = sdtDoiPhuong;
                if (sdtDoiPhuong.Equals("Stranger"))
                {
                    if (historyMessage != null)
                    {
                        historyMessage.Close(); // Form đã tạo thì đóng lại để load Form mới lên
                    }
                    ChatForm chatForm = new ChatForm(sdtLogin);
                    chatForm.HiddenCloseButton();
                    historyMessage = chatForm;
                    historyMessage.TopLevel = false;
                    historyMessage.FormBorderStyle = FormBorderStyle.None;
                    historyMessage.Dock = DockStyle.Fill;
                    panel_HistoryMessage.Controls.Add(historyMessage);
                    historyMessage.BringToFront();
                    historyMessage.Show();
                }
                else
                {
                    if (historyMessage != null)
                    {
                        historyMessage.Close(); // Form đã tạo thì đóng lại để load Form mới lên
                    }
                    ChatForm chatForm = new ChatForm(sdtLogin, sdtDoiPhuong);
                    chatForm.HiddenCloseButton();
                    historyMessage = chatForm;
                    historyMessage.TopLevel = false;
                    historyMessage.FormBorderStyle = FormBorderStyle.None;
                    historyMessage.Dock = DockStyle.Fill;
                    panel_HistoryMessage.Controls.Add(historyMessage);
                    historyMessage.BringToFront();
                    historyMessage.Show();
                }
            }

        }
    }
}
