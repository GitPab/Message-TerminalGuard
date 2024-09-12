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
    public partial class AccountForm : Form
    {
        string sdt;

        public AccountForm(string SDT)
        {
            this.sdt = SDT;
            InitializeComponent();
            LoadDuLieu();
            label_SDT.Text = sdt;
        }

        public void ShowLabel_ChinhSua(bool Visible_Or_Not)
        {
            label_SuaThongTin.Visible = Visible_Or_Not;
        }

        public void LoadDuLieu()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadThongTinUser-" + sdt);
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
                        label_Ten.Text = value[1];
                        break;
                    case "1":
                        label_GioiTinh.Text = value[1];
                        break;
                    case "2":
                        label_NgaySinh.Text = value[1];
                        label_Tuoi.Text = Caculate_Age(value[1]);
                        break;
                    case "5":
                        pictureBox_Avatar.Image = Image.FromFile(value[1]);
                        break;
                    case "6":
                        label_Email.Text = value[1];
                        break;
                    case "7":
                        label_GioiThieu.Text += value[1];
                        break;
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

        private void label_SuaThongTin_Click(object sender, EventArgs e)
        {
            EditAccountForm editAccount = new EditAccountForm(sdt);
            editAccount.SetLayoutValue(label_Ten.Text, label_GioiTinh.Text, label_NgaySinh.Text);
            editAccount.SetLayoutValue(label_GioiThieu.Text);
            editAccount.Show();
            this.Close();
        }

    }
}
