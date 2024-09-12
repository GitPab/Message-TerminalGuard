
namespace Client.MainLayout
{
    partial class HistoryForm
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
        private void InitializeComponent()
        {
            this.flowLayoutPanel_HistoryUser = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_HistoryMessage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_HistoryUser
            // 
            this.flowLayoutPanel_HistoryUser.AutoScroll = true;
            this.flowLayoutPanel_HistoryUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel_HistoryUser.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_HistoryUser.Name = "flowLayoutPanel_HistoryUser";
            this.flowLayoutPanel_HistoryUser.Size = new System.Drawing.Size(191, 434);
            this.flowLayoutPanel_HistoryUser.TabIndex = 0;
            // 
            // panel_HistoryMessage
            // 
            this.panel_HistoryMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_HistoryMessage.Location = new System.Drawing.Point(198, 0);
            this.panel_HistoryMessage.Name = "panel_HistoryMessage";
            this.panel_HistoryMessage.Size = new System.Drawing.Size(422, 434);
            this.panel_HistoryMessage.TabIndex = 1;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 434);
            this.Controls.Add(this.panel_HistoryMessage);
            this.Controls.Add(this.flowLayoutPanel_HistoryUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HistoryForm";
            this.Text = "Lịch Sử Nhắn Tin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_HistoryUser;
        private System.Windows.Forms.Panel panel_HistoryMessage;
    }
}