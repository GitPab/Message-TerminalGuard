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
    public partial class EditAccountForm : Form
    {
        string sdt;

        public EditAccountForm(string sdt)
        {
            InitializeComponent();
            this.sdt = sdt;
        }

        public void SetLayoutValue(string ten, string gioiTinh, string ngaySinh)
        {
            txt_HovaTen.Text = ten;
            txt_NgaySinh.Text = ngaySinh;
            if (gioiTinh == "Nữ")
                rdo_Nu.Checked = true;
            else
                rdo_Nam.Checked = true;
        }

        public void SetLayoutValue(string tieuSu)
        {
            txt_TieuSu.Text = tieuSu;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_HovaTen.Text.Equals("") || txt_NgaySinh.Text.Equals(""))
            {
                pictureBox1.Visible = true;
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
                    if (!txt_TieuSu.Text.Equals(""))
                    {
                        if (!CheckValidTieuSu(txt_TieuSu.Text))
                        {
                            MessageBox.Show(@"Tiểu sử không được chứa các ký tự / \ - _");
                            return;
                        }
                    }
                    if (!txt_Email.Text.Equals(""))
                    {
                        if (CheckValidEmail(txt_Email.Text))
                        {
                            GlobalConnect.SendData(GlobalConnect.svcn, "GetNumberValiddationEmail-" + txt_Email.Text);
                            ValidationEmail validation = new ValidationEmail(GlobalConnect.RecieveData(GlobalConnect.svcn), txt_Email.Text);
                            validation.ShowDialog();
                            if (validation.ReturnValidation()) // Mã xác minh đúng.
                            {
                                pictureBox3.Visible = true;
                                string gioiTinh = "Nữ";
                                if (rdo_Nam.Checked)
                                    gioiTinh = "Nam";
                                // Gửi dữ liệu lên Server để lưu.
                                string ten = txt_HovaTen.Text.Trim();
                                string ngaySinh = txt_NgaySinh.Text;
                                string email = txt_Email.Text.Trim();
                                string tieuSu = txt_TieuSu.Text;
                                GlobalConnect.SendData(GlobalConnect.svcn, "ChangeInfoAccount-" + sdt + "-" + ten + "-" + gioiTinh + "-" + ngaySinh + "-" + email + "-" + tieuSu);
                                if (GlobalConnect.RecieveData(GlobalConnect.svcn).Equals("Done"))
                                {
                                    this.Close();
                                    MainForm.mainForm.RefreshMainForm();
                                }
                            }
                            else
                            {
                                txt_Email.Text = "";
                                pictureBox3.Visible = false;
                            }
                        }
                        else
                            MessageBox.Show("Email không hợp lệ");
                    }
                    else
                    {
                        pictureBox3.Visible = false;
                        string gioiTinh = "Nữ";
                        if (rdo_Nam.Checked)
                            gioiTinh = "Nam";
                        // Gửi dữ liệu lên Server để lưu.
                        string ten = txt_HovaTen.Text.Trim();
                        string ngaySinh = txt_NgaySinh.Text;
                        string tieuSu = txt_TieuSu.Text;
                        GlobalConnect.SendData(GlobalConnect.svcn, "ChangeInfoAccount-" + sdt + "-" + ten + "-" + gioiTinh + "-" + ngaySinh + "-" + tieuSu);
                        if (GlobalConnect.RecieveData(GlobalConnect.svcn).Equals("Done"))
                        {
                            this.Close();
                            MainForm.mainForm.RefreshMainForm();
                        }
                    }
                }
            }
        }

        private void txt_HovaTen_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
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
                    if ( regexItem.IsMatch(domain.Replace(".", "")) ) // Vì Email cho phép sử dụng dấu ".", nên xóa dấu chấm rồi kiểm tra xem còn ký tự đặc biệt khác không.
                        return true; // Không chứa ký tự đặc biệt
                }    
            }    
            return false;
        }

        public bool CheckValidName(string name)
        {
            var regexItem = new Regex(@"^\w[\w0-9 ]*$");
            if (regexItem.IsMatch(name) && name.Length >= 2) // Kiểm tra xem còn ký tự đặc biệt khác không.
                return true; // Không chứa ký tự đặc biệt
            return false;
        }

        public bool CheckValidTieuSu(string tieuSu)
        {
            if (tieuSu.Contains('-') || tieuSu.Contains('/') || tieuSu.Contains(@"\") || tieuSu.Contains('_') )
                return false; // Chứa các ký tự cấm.
            return true;
        }

        private void datePicker_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            txt_NgaySinh.Text = datePicker_NgaySinh.Value.ToString("dd / MM / yyyy");
        }
    }
}
