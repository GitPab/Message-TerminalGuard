using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.MainLayout
{
    public partial class HistoryUsers : UserControl
    {
        public HistoryUsers()
        {
            InitializeComponent();
        }

        private string userName, sdt, sdtLogin, pathAvatar;

        #region
        public string UserName
        {
            get { return userName; }
            set { userName = value; name.Text = value; }
        }

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Avatar
        {
            get { return pathAvatar; }
            set { pathAvatar = value; avatar.Image = Image.FromFile(value); }
        }

        public string SdtLogin
        {
            get => sdtLogin;
            set => sdtLogin = value;
        }
        #endregion

        private void name_Click(object sender, EventArgs e)
        {
            if(sdt == null)
                HistoryForm.historyForm.LoadHistoryMessage("Stranger");
            else
                HistoryForm.historyForm.LoadHistoryMessage(sdt);
        }

        private void avatar_Click(object sender, EventArgs e)
        {
            if (sdt == null)
                HistoryForm.historyForm.LoadHistoryMessage("Stranger");
            else
                HistoryForm.historyForm.LoadHistoryMessage(sdt);
        }

        private void HistoryUser_OnClick(object sender, EventArgs e)
        {
            if (sdt == null)
                HistoryForm.historyForm.LoadHistoryMessage("Stranger");
            else
                HistoryForm.historyForm.LoadHistoryMessage(sdt);
        }
    }
}
