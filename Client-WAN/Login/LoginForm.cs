using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            try
            {
                GlobalConnect.Connect();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server!");
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sdt = txt_UserName.Text;
            string passwd = txt_Password.Text;
            if (sdt == "" || passwd == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string send = "Login-" + sdt + "-" + passwd;
            GlobalConnect.SendData(GlobalConnect.svcn, send);
            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            if (nhan == "0")
            {
                MessageBox.Show("Đăng Nhập Thất Bại");
                txt_Password.Clear();
            }
            else
            {
                if (nhan == "2")
                {
                    MessageBox.Show("Tài Khoản Đang Được Đăng Nhập Nơi Khác");
                    txt_Password.Clear();
                }
                else
                {
                    MainForm mf = new MainForm(txt_UserName.Text);
                    mf.Show();
                    this.Hide();
                }
            }
        }

        private void label_DangKy_Click(object sender, EventArgs e)
        {
            RegisterForm rg = new RegisterForm();
            rg.ShowDialog();
        }

        private void label_QuenMatKhau_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
        }

        private void OnClosedForm(object sender, FormClosedEventArgs e)
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "CancelLogin");
            GlobalConnect.DisConnect();
        }
    }
}


