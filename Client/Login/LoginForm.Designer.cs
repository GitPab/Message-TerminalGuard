namespace Client
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label_TaiKhoan = new System.Windows.Forms.Label();
            this.label_MatKhau = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_DangKy = new System.Windows.Forms.Label();
            this.label_QuenMatKhau = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(100, 2);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(207, 162);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label_TaiKhoan
            // 
            this.label_TaiKhoan.AutoSize = true;
            this.label_TaiKhoan.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TaiKhoan.Location = new System.Drawing.Point(32, 229);
            this.label_TaiKhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TaiKhoan.Name = "label_TaiKhoan";
            this.label_TaiKhoan.Size = new System.Drawing.Size(103, 23);
            this.label_TaiKhoan.TabIndex = 1;
            this.label_TaiKhoan.Text = "Tài Khoản:";
            // 
            // label_MatKhau
            // 
            this.label_MatKhau.AutoSize = true;
            this.label_MatKhau.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MatKhau.Location = new System.Drawing.Point(33, 286);
            this.label_MatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_MatKhau.Name = "label_MatKhau";
            this.label_MatKhau.Size = new System.Drawing.Size(100, 23);
            this.label_MatKhau.TabIndex = 2;
            this.label_MatKhau.Text = "Mật Khẩu:";
            // 
            // txt_UserName
            // 
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(156, 224);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(185, 22);
            this.txt_UserName.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(156, 281);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(183, 22);
            this.txt_Password.TabIndex = 4;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DangNhap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DangNhap.FlatAppearance.BorderSize = 0;
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_DangNhap.Location = new System.Drawing.Point(127, 352);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(167, 38);
            this.btn_DangNhap.TabIndex = 5;
            this.btn_DangNhap.Text = "Đăng Nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(155, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 1);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(152, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 1);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 418);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Chưa có tài khoản ?";
            // 
            // label_DangKy
            // 
            this.label_DangKy.AutoSize = true;
            this.label_DangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_DangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DangKy.ForeColor = System.Drawing.Color.DarkCyan;
            this.label_DangKy.Location = new System.Drawing.Point(233, 416);
            this.label_DangKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DangKy.Name = "label_DangKy";
            this.label_DangKy.Size = new System.Drawing.Size(81, 24);
            this.label_DangKy.TabIndex = 9;
            this.label_DangKy.Text = "Đăng Ký";
            this.label_DangKy.Click += new System.EventHandler(this.label_DangKy_Click);
            // 
            // label_QuenMatKhau
            // 
            this.label_QuenMatKhau.AutoSize = true;
            this.label_QuenMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_QuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_QuenMatKhau.ForeColor = System.Drawing.Color.DarkRed;
            this.label_QuenMatKhau.Location = new System.Drawing.Point(140, 454);
            this.label_QuenMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_QuenMatKhau.Name = "label_QuenMatKhau";
            this.label_QuenMatKhau.Size = new System.Drawing.Size(111, 18);
            this.label_QuenMatKhau.TabIndex = 10;
            this.label_QuenMatKhau.Text = "Quên Mật Khẩu";
            this.label_QuenMatKhau.Click += new System.EventHandler(this.label_QuenMatKhau_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 486);
            this.Controls.Add(this.label_QuenMatKhau);
            this.Controls.Add(this.label_DangKy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.label_MatKhau);
            this.Controls.Add(this.label_TaiKhoan);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.Text = "Đăng Nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosedForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_TaiKhoan;
        private System.Windows.Forms.Label label_MatKhau;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_DangKy;
        private System.Windows.Forms.Label label_QuenMatKhau;
    }
}