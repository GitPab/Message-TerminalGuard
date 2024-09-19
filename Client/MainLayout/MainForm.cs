using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm;
        string sdtLogin;
        Thread t;
        bool cancelRandom = false; // Biến kiểm tra xem người dùng có ngắt tìm kiếm RandomChat hay không.

        public MainForm(string Sdt)
        {
            mainForm = this;
            this.sdtLogin = Sdt;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            LoadDuLieu();
            LoadOnlineUsers();
            t = new Thread(Listening);
            t.Start();
        }

        public void LoadDuLieu()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadDuLieuDangNhap-" + sdtLogin);
            string nhan;
            while(true)
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
                        myName.Text = value[1];
                        break;
                    case "2":
                        label_Tuoi.Text = Caculate_Age(value[1]);
                        break;
                    case "3":
                        SetTrangThai(value[1]);
                        break;
                    case "5":
                        myPicture.Image = Image.FromFile(value[1]);
                        break;
                }
            }
        }

        public void RefreshMainForm()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadDuLieuDangNhap-" + sdtLogin);
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
                        myName.Text = value[1];
                        break;
                    case "2":
                        label_Tuoi.Text = Caculate_Age(value[1]);
                        break;
                    case "3":
                        SetTrangThai(value[1]);
                        break;
                    case "5":
                        myPicture.Image = Image.FromFile(value[1]);
                        break;
                }
            }
        }

        public void LoadOnlineUsers()
        {
            OnlineUser onlineUser;
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadOnlineUsers-" + sdtLogin);
            string nhan;
            //
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    flowLayoutPanel.Controls.Clear();
                    // Vòng lặp 1 để kiểm tra Server đã truyền xong chưa, mỗi vòng lặp = tổng thông tin 1 người.
                    while (true)
                    {
                        nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                        if (nhan == "End")
                            break;
                        onlineUser = new OnlineUser();
                        onlineUser.SDT = nhan;
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
                                    onlineUser.UserName = value[1];
                                    break;
                                case "3":
                                    onlineUser.TrangThai = value[1];
                                    break;
                                case "5":
                                    onlineUser.Avatar = value[1];
                                    break;
                                case "7":
                                    onlineUser.GioiThieu += value[1];
                                    break;
                            }
                        }
                        onlineUser.SdtLogin = sdtLogin;
                        this.flowLayoutPanel.Controls.Add(onlineUser);
                    }
                });
            }
            else
            {
                flowLayoutPanel.Controls.Clear();
                // Vòng lặp 1 để kiểm tra Server đã truyền xong chưa, mỗi vòng lặp = tổng thông tin 1 người.
                while (true)
                {
                    nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                    if (nhan == "End")
                        break;
                    onlineUser = new OnlineUser();
                    onlineUser.SDT = nhan;
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
                                onlineUser.UserName = value[1];
                                break;
                            case "3":
                                onlineUser.TrangThai = value[1];
                                break;
                            case "5":
                                onlineUser.Avatar = value[1];
                                break;
                            case "7":
                                onlineUser.GioiThieu += value[1];
                                break;
                        }
                    }
                    onlineUser.SdtLogin = sdtLogin;
                    this.flowLayoutPanel.Controls.Add(onlineUser);
                }
            }    
            
        }

        public string Caculate_Age(string birth)
        {
            int Age = 0;
            // Lấy ngày giờ hôm nay.
            string toDay = DateTime.Now.ToString("dd/MM/yyyy");
            // Cắt chuỗi để lấy giá trị tính toán
            string[] arrBirth = birth.Replace(" ", "").Split('/');
            int ngaySinh = int.Parse(arrBirth[0]);
            int thangSinh = int.Parse(arrBirth[1]);
            int namSinh = int.Parse(arrBirth[2]);
            string[] arrToDay = toDay.Split('/');
            int ngayHienTai = int.Parse(arrToDay[0]);
            int thangHienTai = int.Parse(arrToDay[1]);
            int namHienTai = int.Parse(arrToDay[2]);
            Age = namHienTai - namSinh + 1;
            // So sánh để tính được tuổi chính xác.
            if (thangSinh == thangHienTai && ngaySinh < ngayHienTai)
                Age--;
            if (thangSinh < thangHienTai)
                Age--;
            return "Tuổi: " + Age.ToString();
        }

        public void SetTrangThai(string TrangThai)
        {
            trangThai.Text = TrangThai;
            switch (TrangThai)
            {
                case "Online":
                    trangThai.ForeColor = Color.Lime;
                    break;
                case "Bận":
                    trangThai.ForeColor = Color.Gold;
                    break;
                case "Vắng":
                    trangThai.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTrangThai(comboBox.Text);
            // Gửi = Lệnh - SĐT - Trạng Thái
            GlobalConnect.SendData(GlobalConnect.svcn, "DoiTrangThai-" + sdtLogin + "-" + trangThai.Text);
        }

        private void myPicture_Click(object sender, EventArgs e)
        {
            ChooseAvatar ca = new ChooseAvatar(sdtLogin);
            ca.ShowDialog();
            if (ca.path != null)
                myPicture.Image = Image.FromFile(ca.path);
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpw = new ChangePasswordForm(sdtLogin);
            cpw.ShowDialog();
        }

        private void account_Click(object sender, EventArgs e)
        {
            AccountForm ac = new AccountForm(sdtLogin);
            ac.ShowLabel_ChinhSua(true);
            ac.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "Logout-" + sdtLogin);
            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            if (nhan == "1")
            {
                Environment.Exit(0);
                GlobalConnect.DisConnect();
            }
            else
                MessageBox.Show("Vui lòng thử lại sau");
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "Logout-" + sdtLogin);
            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            if (nhan == "1")
            {
                Environment.Exit(0);
            }
            else
                MessageBox.Show("Vui lòng thử lại sau");
        }

        void Listening()
        {
            string nhan;
            while(true)
            {
                nhan = GlobalConnect.RecieveData(GlobalConnect.listen);
                Thread.Sleep(300);
                switch (nhan)
                {
                    case "Logout":
                        break;
                    case "Connect":
                        // Hàm nhận yêu cầu kết nối từ người khác
                        Thread t = new Thread(Connect);
                        t.Start();
                        continue;
                    case "Refresh":
                        // Server gửi thông tin có người đăng nhập hoặc đang Chat, người dùng load lại trang chủ.
                        this.LoadOnlineUsers();
                        continue;
                }
            }    
        }

        private void Connect()
        {
            DialogResult dialogResult = MessageBox.Show("Có người muốn kết nối với bạn!", "Kết nối ghép đôi!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                GlobalConnect.SendData(GlobalConnect.listen, "Ok");
                string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                // nhan = sđt đối phương
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        ChatForm chatF = new ChatForm(sdtLogin, nhan);
                        chatF.Show();
                    });
                }
            }
            else
            {
                GlobalConnect.SendData(GlobalConnect.listen, "Cancel");
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadOnlineUsers();
        }

        private void ghepNgauNhien_Click(object sender, EventArgs e)
        {
            // Tạo Thread lắng nghe lựa chọn người dùng
            Thread t2 = new Thread(ListenChoosen);
            t2.Start();
            this.Enabled = false;
            // Gửi yêu cầu RandomChat, nếu không có kết quả thì gửi lại yêu cầu, gửi tổng cộng 5 lần;
            for (int i = 0; i < 6; i++)
            {
                if (i == 5) // Chạy 5 lần mà k có kquả thì sẽ đóng tìm kiếm.
                {
                    GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiRandomChat-" + sdtLogin);
                    string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                    if (nhan.Equals("OK"))
                    {
                        t2.Abort();
                        cancelRandom = false;                        
                        MessageBox.Show("Thời gian tìm kiếm quá lâu, hãy thử lại!");
                        this.Enabled = true;
                        break;
                    }
                }
                else
                {
                    if (!cancelRandom) // Người dùng chưa hủy tìm kiếm Random.
                    {
                        GlobalConnect.SendData(GlobalConnect.svcn, "RandomChat-" + sdtLogin);
                        string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                        if (nhan.Equals("Fail")) // Không có kết quả tìm kiếm.
                        {
                            Thread.Sleep(500);
                            continue;
                        }
                        else if (nhan.Equals("Success")) // Có kết quả, bắt đầu chat.
                        {
                            t2.Abort();
                            cancelRandom = false;
                            this.Enabled = true;
                            ChatForm chatForm = new ChatForm(sdtLogin);
                            chatForm.Show();
                            break;
                        }
                    }
                    else
                    {
                        t2.Abort();
                        cancelRandom = false;
                        this.Enabled = true;
                        break;
                    }
                }
            }
        }

        public void ListenChoosen()
        {
            // Gọi Dialog thông báo rằng đang tìm kiếm và cho phép người dùng hủy tìm kiếm.
            CustomDialogNotification customDialog = new CustomDialogNotification();
            customDialog.ShowButton_OK(false);
            customDialog.Title = "Searching";
            customDialog.Notification = "Đang tìm người ghép đôi";
            customDialog.ShowDialog();
            // Bắt sự kiện người dùng hủy tìm kiếm Random.
            if (customDialog.ReturnChoosen() == "Cancel")
            {
                cancelRandom = true; // Đổi biến này để ngắt vòng lặp yêu cầu RandomChat
                GlobalConnect.SendData(GlobalConnect.svcn, "NgatKetNoiRandomChat-" + sdtLogin);
                string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            }
        }

        private void ptcBox_Loc_Click(object sender, EventArgs e)
        {
            //FilterForm filterForm = new FilterForm();
            //filterForm.ShowDialog();
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            //FilterForm filterForm = new FilterForm();
            //filterForm.ShowDialog();
        }

        private void history_Click(object sender, EventArgs e)
        {
            MainLayout.HistoryForm historyForm = new MainLayout.HistoryForm(sdtLogin);
            historyForm.Show();
        }

        private void group_Click(object sender, EventArgs e)
        {
            MainLayout.GroupForm groupForm = new MainLayout.GroupForm(sdtLogin);
            groupForm.Show();
        }
        // End
    }
}
