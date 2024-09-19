using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.MainLayout
{
    public partial class GroupChat : UserControl
    {
        public GroupChat()
        {
            InitializeComponent();
        }

        private string groupName;

        #region
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; name.Text = value; }
        }
        #endregion

        private void name_Click(object sender, EventArgs e)
        {
            GroupForm.groupForm.LoadGroupMessage(groupName);

        }
        private void HistoryUser_OnClick(object sender, EventArgs e)
        {
            GroupForm.groupForm.LoadGroupMessage(groupName);
        }
    }
}
