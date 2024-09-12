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
    public partial class CustomDialogNotification : Form
    {
        public CustomDialogNotification()
        {
            InitializeComponent();
        }

        #region
        string notification;

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value;}
        }

        public string Notification
        {
            get { return notification; }
            set { notification = value; label_Notification.Text = value; }
        }

        public void ShowButton_OK(bool Visible_Or_Not)
        {
            btn_OK.Visible = Visible_Or_Not;
        }

        public void ShowButton_Cancel(bool Visible_Or_Not)
        {
            btn_Cancel.Visible = Visible_Or_Not;
        }
        #endregion

        string Choosen;

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Choosen = "Cancel";
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Choosen = "Ok";
            this.Close();
        }

        public string ReturnChoosen()
        {
            return Choosen;
        }
    }
}
