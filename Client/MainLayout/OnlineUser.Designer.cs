namespace Client
{
    partial class OnlineUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineUser));
            this.picBox_Avatar = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.label_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_KetNoi = new System.Windows.Forms.Button();
            this.label_GioiThieu = new System.Windows.Forms.Label();
            this.btn_XemThongTin = new System.Windows.Forms.Button();
            this.label_TrangThai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Avatar)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox_Avatar
            // 
            this.picBox_Avatar.Image = ((System.Drawing.Image)(resources.GetObject("picBox_Avatar.Image")));
            this.picBox_Avatar.Location = new System.Drawing.Point(17, 9);
            this.picBox_Avatar.Name = "picBox_Avatar";
            this.picBox_Avatar.Size = new System.Drawing.Size(115, 115);
            this.picBox_Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_Avatar.TabIndex = 0;
            this.picBox_Avatar.TabStop = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel.Controls.Add(this.picBox_Avatar);
            this.panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 133);
            this.panel.TabIndex = 0;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.ForeColor = System.Drawing.Color.Tomato;
            this.label_Name.Location = new System.Drawing.Point(156, 12);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(128, 25);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "User Name";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Giới thiệu:";
            // 
            // btn_KetNoi
            // 
            this.btn_KetNoi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_KetNoi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_KetNoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btn_KetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KetNoi.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_KetNoi.Location = new System.Drawing.Point(453, 104);
            this.btn_KetNoi.Name = "btn_KetNoi";
            this.btn_KetNoi.Size = new System.Drawing.Size(75, 23);
            this.btn_KetNoi.TabIndex = 5;
            this.btn_KetNoi.Text = "Kết Nối";
            this.btn_KetNoi.UseVisualStyleBackColor = false;
            this.btn_KetNoi.Click += new System.EventHandler(this.btn_KetNoi_Click);
            // 
            // label_GioiThieu
            // 
            this.label_GioiThieu.BackColor = System.Drawing.Color.White;
            this.label_GioiThieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_GioiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GioiThieu.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_GioiThieu.Location = new System.Drawing.Point(161, 71);
            this.label_GioiThieu.Name = "label_GioiThieu";
            this.label_GioiThieu.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.label_GioiThieu.Size = new System.Drawing.Size(272, 56);
            this.label_GioiThieu.TabIndex = 8;
            // 
            // btn_XemThongTin
            // 
            this.btn_XemThongTin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_XemThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_XemThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btn_XemThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_XemThongTin.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemThongTin.Location = new System.Drawing.Point(453, 71);
            this.btn_XemThongTin.Name = "btn_XemThongTin";
            this.btn_XemThongTin.Size = new System.Drawing.Size(75, 23);
            this.btn_XemThongTin.TabIndex = 10;
            this.btn_XemThongTin.Text = "Thông Tin";
            this.btn_XemThongTin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_XemThongTin.UseVisualStyleBackColor = false;
            this.btn_XemThongTin.Click += new System.EventHandler(this.btn_XemThongTin_Click);
            // 
            // label_TrangThai
            // 
            this.label_TrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TrangThai.Location = new System.Drawing.Point(428, 0);
            this.label_TrangThai.Name = "label_TrangThai";
            this.label_TrangThai.Size = new System.Drawing.Size(100, 23);
            this.label_TrangThai.TabIndex = 11;
            this.label_TrangThai.Text = "Trạng Thái";
            this.label_TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OnlineUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label_TrangThai);
            this.Controls.Add(this.btn_XemThongTin);
            this.Controls.Add(this.label_GioiThieu);
            this.Controls.Add(this.btn_KetNoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Name = "OnlineUser";
            this.Size = new System.Drawing.Size(542, 133);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Avatar)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Avatar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_KetNoi;
        private System.Windows.Forms.Label label_GioiThieu;
        private System.Windows.Forms.Button btn_XemThongTin;
        private System.Windows.Forms.Label label_TrangThai;
    }
}
