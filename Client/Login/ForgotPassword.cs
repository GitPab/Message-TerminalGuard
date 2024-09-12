using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ptcBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if(!txt_Sdt.Text.Equals("") && !txt_Email.Text.Equals(""))
            {
                if (!txt_Sdt.Text.All(char.IsDigit) || txt_Sdt.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    pictureBox1.Visible = true;
                }
                else
                {
                    if (CheckValidEmail(txt_Email.Text))
                    {
                        GlobalConnect.SendData(GlobalConnect.svcn, "ForgotPassword-" + txt_Sdt.Text.Trim() + "-" + txt_Email.Text.Trim());
                        string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn); // Nhận kết quả kiểm tra thông tin tài khoản
                        if (nhan.Equals("No"))
                            label_Nofi.Text = "SĐT hoặc Email không tồn tại";
                        else
                        {
                            GlobalConnect.SendData(GlobalConnect.svcn, "GetNumberValiddationEmail-" + txt_Email.Text);
                            ValidationEmail validation = new ValidationEmail(GlobalConnect.RecieveData(GlobalConnect.svcn), txt_Email.Text);
                            validation.ShowDialog();
                            if (validation.ReturnValidation())
                            {
                                panel.Visible = true;
                            }    
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Email không hợp lệ");
                        pictureBox2.Visible = true;
                    }
                }    
            }    
        }

        public bool CheckValidEmail(string email)
        {
            if (email.Any(Char.IsWhiteSpace)) // Chứa khoảng trắng thì trả về không hợp lệ.
                return false;
            else
            {
                if (email.Length >= 11 && email.Substring(email.Length - 10) == "@gmail.com") // 10 ký tự cuối mà là @gmail.com thì kiểm tra tiếp
                {
                    var regexItem = new Regex("^[a-zA-Z0-9]*$");
                    string domain = email.Substring(0, email.Length - 10);
                    if (regexItem.IsMatch(domain.Replace(".", ""))) // Vì Email cho phép sử dụng dấu ".", nên xóa dấu chấm rồi kiểm tra xem còn ký tự đặc biệt khác không.
                        return true; // Không chứa ký tự đặc biệt
                }
            }
            return false;
        }

        private void txt_Sdt_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label_Nofi.Text = "";
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            label_Nofi.Text = "";
        }

        public bool CheckValidPassword(string pass)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            string password = pass.Replace(".", ""); // Mật khẩu cho phép dùng dấu chấm.
            if (regexItem.IsMatch(password)) // Kiểm tra xem còn ký tự đặc biệt khác không.
                return true; // Không chứa ký tự đặc biệt
            return false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
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
                        GlobalConnect.SendData(GlobalConnect.svcn, "ForgotPassword_ChangePassword-" + txt_Sdt.Text.Trim() + "-" + txt_MatKhauMoi.Text.Trim());
                        {
                            string nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
                            if (nhan == "1")
                            {
                                MessageBox.Show("Thành Công!");
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
