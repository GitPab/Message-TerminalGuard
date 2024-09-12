using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Client
{
    public partial class ChooseAvatar : Form
    {
        static PictureBox[] arr_Picture;
        public string path, sdt;

        public string Path { get => path; set => path = value; }

        public ChooseAvatar(string SDT)
        {
            InitializeComponent();
            this.sdt = SDT;
            btn_DongY.Enabled = false;
            LoadAvatar();
        }

        public void LoadAvatar()
        {
            // Lấy số lượng hình ảnh và đường dẫn chúng lưu vào mảng
            string[] filesPath = Directory.GetFiles("Picture", "*.png");
            // Tạo mảng các hình ảnh, biến đường dẫn ==> hình ảnh
            arr_Picture = new PictureBox[filesPath.Length];
            // Tạo các thông số hình ảnh và thêm vào Form.
            for (int i = 0; i < filesPath.Length; i++)
            {
                try
                {
                    arr_Picture[i] = new PictureBox();
                    // filesPath[i] = đường dẫn file.
                    arr_Picture[i].Tag = filesPath[i];
                    arr_Picture[i].Size = new Size(160, 140);
                    arr_Picture[i].Margin = new Padding(5,10,0,20);
                    arr_Picture[i].SizeMode = PictureBoxSizeMode.Zoom;
                    arr_Picture[i].Image = Image.FromFile(filesPath[i]);
                    arr_Picture[i].Cursor = Cursors.Hand;
                    // Thêm hình ảnh vào Form
                    flowLayoutPanel.Controls.Add(arr_Picture[i]);
                    // Set sự kiện Onlick cho hình ảnh
                    arr_Picture[i].Click += new EventHandler(Ptb_Click);
                }
                catch
                {
                    continue;
                }
            }
        }

        public void Ptb_Click(object sender, EventArgs e)
        {
            PictureBox ptb = (PictureBox)sender;
            foreach (PictureBox pic in arr_Picture)
            {
                try
                {
                    if (pic.Tag == ptb.Tag)
                        pic.BorderStyle = BorderStyle.Fixed3D;
                    else
                        pic.BorderStyle = BorderStyle.None;
                }
                catch
                {
                    continue;
                }
            }
            btn_DongY.Enabled = true;
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pic in arr_Picture)
            {
                try
                {
                    if (pic.BorderStyle == BorderStyle.Fixed3D)
                        path = pic.Tag.ToString();
                }
                catch
                {
                    continue;
                }
            }
            GlobalConnect.SendData(GlobalConnect.svcn, "DoiAvatar-" + sdt + "-" + path);
            this.Close();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            path = null;
            this.Close();
        }
    }
}
