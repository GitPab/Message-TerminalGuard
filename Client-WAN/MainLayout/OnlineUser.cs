using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class OnlineUser : UserControl
    {
        public OnlineUser()
        {
            InitializeComponent();
        }

        private string userName, gioiThieu, trangThai, sdt, sdtLogin, pathAvatar;
        // SĐTLogin là SĐT của tài khoản đang đăng nhập và gọi hàm
        // SĐT là số điện thoại của các người dùng trong danh sách online và hiển thị trên trang chủ.

        #region
        public string UserName
        {
            get { return userName; }
            set { userName = value; label_Name .Text = value; }
        }

        public string GioiThieu
        {
            get { return gioiThieu; }
            set { gioiThieu = value; label_GioiThieu.Text = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; SetTrangThai(value); }
        }

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Avatar
        {
            get { return pathAvatar; }
            set { pathAvatar = value; picBox_Avatar.Image = Image.FromFile(value); }
        }

        public string SdtLogin 
        { 
            get => sdtLogin; 
            set => sdtLogin = value; 
        }
        #endregion

        public void SetTrangThai(string TrangThai)
        {
            label_TrangThai.Text = TrangThai;
            switch (TrangThai)
            {
                case "Online":
                    label_TrangThai.ForeColor = Color.Lime;
                    break;
                case "Bận":
                    label_TrangThai.ForeColor = Color.Gold;
                    break;
                case "Vắng":
                    label_TrangThai.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void btn_XemThongTin_Click(object sender, EventArgs e)
        {
            AccountForm ac = new AccountForm(sdt);
            ac.ShowLabel_ChinhSua(false);
            ac.ShowDialog();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "KetNoiChat-" + sdtLogin + "-" + sdt);
            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            if (nhan == "StopChatting")
                MessageBox.Show("Hãy kết thúc phiên chat hiện tại!");
            else
            {
                if (nhan == "Fail")
                    MessageBox.Show(" Đã xảy ra lỗi! \n Vui lòng thử lại sau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (nhan == "Refuse")
                    {
                        MessageBox.Show("Đối phương từ chối kết nối");
                    }
                    else
                    {
                        // nhan = sđt đối phương
                        ChatForm chatF = new ChatForm(SdtLogin, nhan);
                        chatF.Show();
                    }
                }
            }
        }
        
    }
}
