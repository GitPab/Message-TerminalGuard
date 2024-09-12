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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin
            if (txt_HovaTen.Text == "" || txt_MatKhau.Text == "" || txt_RetypeMatKhau.Text == "" || txt_SDT.Text == "" || txt_NgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }    
            else
            {
                if (!CheckValidName(txt_HovaTen.Text))
                {
                    MessageBox.Show("Tên không phù hợp");
                }    
                else
                {
                    // Kiểm tra đã chọn giới tính hay chưa
                    if (rdo_Nam.Checked || rdo_Nu.Checked)
                    {
                        string gioiTinh = "Nữ";
                        if (rdo_Nam.Checked)
                            gioiTinh = "Nam";
                        // Kiểm tra sự hợp lệ của SĐT
                        if (!txt_SDT.Text.All(char.IsDigit) || txt_SDT.Text.Length != 10)
                            MessageBox.Show("Số điện thoại không hợp lệ!");
                        else
                        {
                            if (txt_MatKhau.Text.Length < 6)
                            {
                                MessageBox.Show("Mật khẩu phải dài hơn 6 ký tự");
                                txt_MatKhau.Text = "";
                            }
                            else
                            {
                                if (!CheckValidPassword(txt_MatKhau.Text))
                                {
                                    MessageBox.Show("Mật khẩu chỉ cho phép các ký tự số, chữ hoa, chữ thường và ký tự '.'");
                                    txt_MatKhau.Text = "";
                                }
                                else
                                {
                                    if (txt_MatKhau.Text != txt_RetypeMatKhau.Text)
                                    {
                                        MessageBox.Show("Mật khẩu không khớp");
                                        txt_RetypeMatKhau.Text = "";
                                    }
                                    else
                                    {
                                        string send = "DangKy-" + txt_HovaTen.Text.Trim() + "-" + txt_SDT.Text + "-" + gioiTinh + "-" + txt_NgaySinh.Text + "-" + txt_MatKhau.Text;
                                        GlobalConnect.SendData(GlobalConnect.svcn, send);
                                        // Đợi phản hồi
                                        string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                                        if (nhan == "0")
                                            MessageBox.Show("SĐT đã được sử dụng.");
                                        else
                                        {
                                            MessageBox.Show("Đăng ký thành công ^^");
                                            this.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn giới tính");
                    }
                }
            }    
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datePicker_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            txt_NgaySinh.Text = datePicker_NgaySinh.Value.ToString("dd / MM / yyyy");
        }

        public bool CheckValidPassword(string pass)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            string password = pass.Replace(".", ""); // Mật khẩu cho phép dùng dấu chấm.
            if (regexItem.IsMatch(password)) // Kiểm tra xem còn ký tự đặc biệt khác không.
                return true; // Không chứa ký tự đặc biệt
            return false;
        }

        public bool CheckValidName(string name)
        {
            var regexItem = new Regex(@"^\w[\w0-9 ]*$");
            if (regexItem.IsMatch(name) && name.Length >= 2) // Kiểm tra xem còn ký tự đặc biệt khác không.
                return true; // Không chứa ký tự đặc biệt
            return false;
        }
    }
}
