using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client
{
    public partial class ChangePasswordForm : Form
    {
        string sdt;

        public ChangePasswordForm(string SDT)
        {
            this.sdt = SDT;
            InitializeComponent();
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (txt_MatKhauCu.Text.Equals("") || txt_MatKhauMoi.Text.Equals(""))
                MessageBox.Show("Lỗi");
            else
            {
                if (txt_MatKhauMoi.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải dài hơn 6 ký tự");
                    txt_MatKhauMoi.Text = "";
                }
                else
                {
                    if (!CheckValidPassword(txt_MatKhauMoi.Text))
                    {
                        MessageBox.Show("Mật khẩu chỉ cho phép các ký tự số, chữ hoa, chữ thường và ký tự '.'");
                        txt_MatKhauMoi.Text = "";
                    }
                    else
                    {
                        if (!txt_MatKhauMoi.Text.Equals(txt_NhapLaiMatKhau.Text))
                        {
                            MessageBox.Show("Mật khẩu không khớp");
                            txt_NhapLaiMatKhau.Clear();
                        }
                        else
                        {
                            GlobalConnect.SendData(GlobalConnect.svcn, "DoiMatKhau-" + sdt + "-" + txt_MatKhauCu.Text + "-" + txt_MatKhauMoi.Text);
                            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                            if (nhan == "1")
                            {
                                this.Close();
                                MessageBox.Show("Đổi thành công!");
                            }
                            else
                                MessageBox.Show("Mật khẩu cũ không đúng!");
                        }
                    }    
                }
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool CheckValidPassword(string pass)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            string password = pass.Replace(".", ""); // Mật khẩu cho phép dùng dấu chấm.
            if (regexItem.IsMatch(password)) // Kiểm tra xem còn ký tự đặc biệt khác không.
                return true; // Không chứa ký tự đặc biệt
            return false;
        }
    }
}
