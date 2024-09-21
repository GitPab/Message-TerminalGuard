using System;
using System.Windows.Forms;

namespace Client.MainLayout
{
    public partial class GroupForm : Form
    {
        string sdtLogin;
        public static GroupForm groupForm; // Phục vụ cho việc gọi lịch sử chat của các người dùng từ form khác.

        public GroupForm(string sdt)
        {
            groupForm = this;
            InitializeComponent();
            this.sdtLogin = sdt;
            LoadGroupChat();
        }
        public void LoadGroupChat()
        {
            GlobalConnect.SendData(GlobalConnect.svcn, "LoadGroudChat");
            flowLayoutPanel_GroupChat.Controls.Clear();

            string nhan;
            while (true)
            {
                nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);

                // Kiểm tra tín hiệu kết thúc
                if (nhan == "End")
                    break;

                // Tạo đối tượng GroupChat mới với tên file làm số điện thoại
                GroupChat historyUsers = new GroupChat();
                historyUsers.GroupName = nhan;  

                // Thêm đối tượng vào flowLayoutPanel
                this.flowLayoutPanel_GroupChat.Controls.Add(historyUsers);
            }
        }


        private Form groupMessage;

        private void button_CreateGroup_Click(object sender, EventArgs e)
        {
            using (InputBox inputBox = new InputBox("Nhập tên nhóm:"))
            {
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    string groupName = inputBox.InputText;
                    if (!string.IsNullOrWhiteSpace(groupName))
                    {
                        string fileInfo = $"CreateGroup-{groupName}-{sdtLogin}";
                        GlobalConnect.SendData(GlobalConnect.svcn, fileInfo);
                        LoadGroupChat();
                    }
                    else
                    {
                        MessageBox.Show("Tên nhóm không thể để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void LoadGroupMessage(string groupName)
        {
            if (groupMessage != null)
            {
                groupMessage.Close();
            }

            // Gửi yêu cầu tham gia nhóm chat
            GlobalConnect.SendData(GlobalConnect.svcn, "JoinGroupChat-" + sdtLogin + "-" + groupName);

            // Tạo một instance của GroupChatForm
            GroupChatForm groupChatForm = new GroupChatForm(sdtLogin, groupName);

            // Cấu hình GroupChatForm để hoạt động như một control trong panel
            groupChatForm.TopLevel = false;
            groupChatForm.FormBorderStyle = FormBorderStyle.None;
            groupChatForm.Dock = DockStyle.Fill; // Điều chỉnh kích thước của groupChatForm để phù hợp với panel

            // Thêm GroupChatForm vào panel_groupMessage
            panel_groupMessage.Controls.Add(groupChatForm);

            // Đảm bảo rằng GroupChatForm nằm trên cùng
            groupChatForm.BringToFront();

            // Hiển thị GroupChatForm
            groupChatForm.Show();

            // Lưu trữ tham chiếu đến GroupChatForm
            groupMessage = groupChatForm;
        }
        public void DeleteGroupMessage(string groupName)
        {
            if (groupMessage != null)
            {
                groupMessage.Close();
            }

            // Gửi yêu cầu tham gia nhóm chat
            GlobalConnect.SendData(GlobalConnect.svcn, "DeleteGroupChat-" + sdtLogin + "-" + groupName);
            string nhan = "";
            nhan = GlobalConnect.RecieveData(GlobalConnect.svcn);
            if (nhan != "0")
            {
                MessageBox.Show("Bạn không có quyền xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Xóa nhóm chat thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGroupChat();
            }
        }
    }
}
