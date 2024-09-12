using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ValidationEmail : Form
    {
        string code, email;
        bool validation = false;

        public ValidationEmail(string code, string email)
        {
            InitializeComponent();
            this.code = code;
            this.email = email;
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (txt_MaXacMinh.Text != code)
                pictureBox1.Visible = true;
            else
            {
                validation = true;
                this.Close();
            }    
        }

        private void label_GuiLaiMa_Click(object sender, EventArgs e)
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "GetNumberValiddationEmail-" + email);
            this.code = GlobalConnect.RecieveData(GlobalConnect.svcn);
        }

        public bool ReturnValidation()
        {
            return validation;
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
