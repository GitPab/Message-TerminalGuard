
namespace Client.MainLayout
{
    partial class GroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Button button_CreateGroup;

        private void InitializeComponent()
        {
            this.flowLayoutPanel_GroupChat = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_groupMessage = new System.Windows.Forms.Panel();
            this.button_CreateGroup = new System.Windows.Forms.Button();
            this.panel_groupMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_GroupChat
            // 
            this.flowLayoutPanel_GroupChat.AutoScroll = true;
            this.flowLayoutPanel_GroupChat.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel_GroupChat.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_GroupChat.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel_GroupChat.Name = "flowLayoutPanel_GroupChat";
            this.flowLayoutPanel_GroupChat.Size = new System.Drawing.Size(255, 534);
            this.flowLayoutPanel_GroupChat.TabIndex = 0;
            // 
            // panel_groupMessage
            // 
            this.panel_groupMessage.Controls.Add(this.button_CreateGroup);
            this.panel_groupMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_groupMessage.Location = new System.Drawing.Point(264, 0);
            this.panel_groupMessage.Margin = new System.Windows.Forms.Padding(4);
            this.panel_groupMessage.Name = "panel_groupMessage";
            this.panel_groupMessage.Size = new System.Drawing.Size(563, 534);
            this.panel_groupMessage.TabIndex = 1;
            // 
            // button_CreateGroup
            // 
            this.button_CreateGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_CreateGroup.Location = new System.Drawing.Point(0, 0);
            this.button_CreateGroup.Name = "button_CreateGroup";
            this.button_CreateGroup.Size = new System.Drawing.Size(563, 40);
            this.button_CreateGroup.TabIndex = 2;
            this.button_CreateGroup.Text = "Tạo Nhóm";
            this.button_CreateGroup.UseVisualStyleBackColor = true;
            this.button_CreateGroup.Click += new System.EventHandler(this.button_CreateGroup_Click);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 534);
            this.Controls.Add(this.panel_groupMessage);
            this.Controls.Add(this.flowLayoutPanel_GroupChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GroupForm";
            this.Text = "Nhóm Chat";
            this.panel_groupMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_GroupChat;
        private System.Windows.Forms.Panel panel_groupMessage;
    }
}
