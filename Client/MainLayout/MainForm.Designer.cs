namespace Client
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_DoiMatKhau = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.account = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Tuoi = new System.Windows.Forms.Label();
            this.trangThai = new System.Windows.Forms.Label();
            this.myName = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.myPicture = new System.Windows.Forms.PictureBox();
            this.ghepNgauNhien = new System.Windows.Forms.Button();
            this.btn_Loc = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.PictureBox();
            this.ptcBox_Loc = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcBox_Loc)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.flowLayoutPanel.Location = new System.Drawing.Point(248, 47);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(559, 456);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.btn_DoiMatKhau);
            this.panel1.Controls.Add(this.logout);
            this.panel1.Controls.Add(this.account);
            this.panel1.Controls.Add(this.history);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 503);
            this.panel1.TabIndex = 1;
            // 
            // btn_DoiMatKhau
            // 
            this.btn_DoiMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.btn_DoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DoiMatKhau.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btn_DoiMatKhau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_DoiMatKhau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btn_DoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btn_DoiMatKhau.Location = new System.Drawing.Point(0, 356);
            this.btn_DoiMatKhau.Name = "btn_DoiMatKhau";
            this.btn_DoiMatKhau.Size = new System.Drawing.Size(210, 47);
            this.btn_DoiMatKhau.TabIndex = 4;
            this.btn_DoiMatKhau.Text = "Đổi Mật Khẩu";
            this.btn_DoiMatKhau.UseVisualStyleBackColor = false;
            this.btn_DoiMatKhau.Click += new System.EventHandler(this.btn_DoiMatKhau_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Transparent;
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(0, 437);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(210, 47);
            this.logout.TabIndex = 3;
            this.logout.Text = "Đăng Xuất";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // account
            // 
            this.account.BackColor = System.Drawing.Color.Transparent;
            this.account.Cursor = System.Windows.Forms.Cursors.Hand;
            this.account.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.account.FlatAppearance.BorderSize = 0;
            this.account.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.account.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.account.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account.ForeColor = System.Drawing.Color.White;
            this.account.Location = new System.Drawing.Point(0, 275);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(210, 47);
            this.account.TabIndex = 2;
            this.account.Text = "Tài Khoản";
            this.account.UseVisualStyleBackColor = false;
            this.account.Click += new System.EventHandler(this.account_Click);
            // 
            // history
            // 
            this.history.BackColor = System.Drawing.Color.Transparent;
            this.history.Cursor = System.Windows.Forms.Cursors.Hand;
            this.history.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.history.FlatAppearance.BorderSize = 0;
            this.history.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.history.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.history.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.history.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.history.ForeColor = System.Drawing.Color.White;
            this.history.Location = new System.Drawing.Point(0, 196);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(210, 47);
            this.history.TabIndex = 1;
            this.history.Text = "Lịch Sử";
            this.history.UseVisualStyleBackColor = false;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.label_Tuoi);
            this.panel2.Controls.Add(this.trangThai);
            this.panel2.Controls.Add(this.myName);
            this.panel2.Controls.Add(this.comboBox);
            this.panel2.Controls.Add(this.myPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 182);
            this.panel2.TabIndex = 0;
            // 
            // label_Tuoi
            // 
            this.label_Tuoi.AutoSize = true;
            this.label_Tuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tuoi.ForeColor = System.Drawing.Color.DarkCyan;
            this.label_Tuoi.Location = new System.Drawing.Point(3, 162);
            this.label_Tuoi.Name = "label_Tuoi";
            this.label_Tuoi.Size = new System.Drawing.Size(43, 16);
            this.label_Tuoi.TabIndex = 5;
            this.label_Tuoi.Text = "Tuổi:";
            this.label_Tuoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trangThai
            // 
            this.trangThai.BackColor = System.Drawing.Color.White;
            this.trangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangThai.ForeColor = System.Drawing.Color.OrangeRed;
            this.trangThai.Location = new System.Drawing.Point(139, 162);
            this.trangThai.Name = "trangThai";
            this.trangThai.Size = new System.Drawing.Size(57, 18);
            this.trangThai.TabIndex = 5;
            this.trangThai.Text = "Online";
            this.trangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myName
            // 
            this.myName.BackColor = System.Drawing.Color.Transparent;
            this.myName.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myName.ForeColor = System.Drawing.Color.SteelBlue;
            this.myName.Location = new System.Drawing.Point(0, 126);
            this.myName.Name = "myName";
            this.myName.Size = new System.Drawing.Size(210, 23);
            this.myName.TabIndex = 1;
            this.myName.Text = "Nguyễn Gia Bách";
            this.myName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.White;
            this.comboBox.DropDownWidth = 50;
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox.ForeColor = System.Drawing.Color.Black;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Online",
            "Vắng",
            "Bận"});
            this.comboBox.Location = new System.Drawing.Point(193, 162);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(16, 21);
            this.comboBox.TabIndex = 4;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // myPicture
            // 
            this.myPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.myPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPicture.Image = ((System.Drawing.Image)(resources.GetObject("myPicture.Image")));
            this.myPicture.InitialImage = null;
            this.myPicture.Location = new System.Drawing.Point(50, 8);
            this.myPicture.Margin = new System.Windows.Forms.Padding(0);
            this.myPicture.Name = "myPicture";
            this.myPicture.Size = new System.Drawing.Size(106, 101);
            this.myPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myPicture.TabIndex = 0;
            this.myPicture.TabStop = false;
            this.myPicture.Click += new System.EventHandler(this.myPicture_Click);
            // 
            // ghepNgauNhien
            // 
            this.ghepNgauNhien.BackColor = System.Drawing.Color.Transparent;
            this.ghepNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ghepNgauNhien.FlatAppearance.BorderSize = 0;
            this.ghepNgauNhien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.ghepNgauNhien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ghepNgauNhien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghepNgauNhien.ForeColor = System.Drawing.Color.Tomato;
            this.ghepNgauNhien.Location = new System.Drawing.Point(248, 3);
            this.ghepNgauNhien.Name = "ghepNgauNhien";
            this.ghepNgauNhien.Size = new System.Drawing.Size(165, 38);
            this.ghepNgauNhien.TabIndex = 2;
            this.ghepNgauNhien.Text = "Ghép Ngẫu Nhiên";
            this.ghepNgauNhien.UseVisualStyleBackColor = false;
            this.ghepNgauNhien.Click += new System.EventHandler(this.ghepNgauNhien_Click);
            // 
            // btn_Loc
            // 
            this.btn_Loc.BackColor = System.Drawing.Color.Transparent;
            this.btn_Loc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Loc.FlatAppearance.BorderSize = 0;
            this.btn_Loc.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_Loc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Loc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Loc.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Loc.Location = new System.Drawing.Point(207, 66);
            this.btn_Loc.Name = "btn_Loc";
            this.btn_Loc.Size = new System.Drawing.Size(40, 24);
            this.btn_Loc.TabIndex = 3;
            this.btn_Loc.Text = "Lọc";
            this.btn_Loc.UseVisualStyleBackColor = false;
            this.btn_Loc.Click += new System.EventHandler(this.btn_Loc_Click);
            // 
            // Refresh
            // 
            this.Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Refresh.Image")));
            this.Refresh.Location = new System.Drawing.Point(774, 26);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(33, 33);
            this.Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Refresh.TabIndex = 4;
            this.Refresh.TabStop = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // ptcBox_Loc
            // 
            this.ptcBox_Loc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptcBox_Loc.Image = ((System.Drawing.Image)(resources.GetObject("ptcBox_Loc.Image")));
            this.ptcBox_Loc.Location = new System.Drawing.Point(210, 35);
            this.ptcBox_Loc.Name = "ptcBox_Loc";
            this.ptcBox_Loc.Size = new System.Drawing.Size(37, 35);
            this.ptcBox_Loc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptcBox_Loc.TabIndex = 5;
            this.ptcBox_Loc.TabStop = false;
            this.ptcBox_Loc.Click += new System.EventHandler(this.ptcBox_Loc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 503);
            this.ControlBox = false;
            this.Controls.Add(this.ptcBox_Loc);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.btn_Loc);
            this.Controls.Add(this.ghepNgauNhien);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Trang Chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcBox_Loc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button account;
        private System.Windows.Forms.Button history;
        private System.Windows.Forms.Label myName;
        private System.Windows.Forms.PictureBox myPicture;
        private System.Windows.Forms.Button btn_DoiMatKhau;
        private System.Windows.Forms.Button ghepNgauNhien;
        private System.Windows.Forms.Button btn_Loc;
        private System.Windows.Forms.Label trangThai;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label_Tuoi;
        private System.Windows.Forms.PictureBox Refresh;
        private System.Windows.Forms.PictureBox ptcBox_Loc;
    }
}

