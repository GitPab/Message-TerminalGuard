namespace Client
{
    partial class EditAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountForm));
            this.txt_NgaySinh = new System.Windows.Forms.TextBox();
            this.datePicker_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_Nu = new System.Windows.Forms.RadioButton();
            this.rdo_Nam = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_HovaTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TieuSu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_NgaySinh
            // 
            this.txt_NgaySinh.BackColor = System.Drawing.Color.White;
            this.txt_NgaySinh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_NgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NgaySinh.ForeColor = System.Drawing.Color.DarkCyan;
            this.txt_NgaySinh.Location = new System.Drawing.Point(155, 121);
            this.txt_NgaySinh.Name = "txt_NgaySinh";
            this.txt_NgaySinh.ReadOnly = true;
            this.txt_NgaySinh.Size = new System.Drawing.Size(158, 17);
            this.txt_NgaySinh.TabIndex = 41;
            this.txt_NgaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // datePicker_NgaySinh
            // 
            this.datePicker_NgaySinh.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker_NgaySinh.CalendarForeColor = System.Drawing.Color.DarkCyan;
            this.datePicker_NgaySinh.CustomFormat = "dd / MM / yyyy";
            this.datePicker_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker_NgaySinh.Location = new System.Drawing.Point(324, 119);
            this.datePicker_NgaySinh.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.datePicker_NgaySinh.Name = "datePicker_NgaySinh";
            this.datePicker_NgaySinh.Size = new System.Drawing.Size(10, 20);
            this.datePicker_NgaySinh.TabIndex = 40;
            this.datePicker_NgaySinh.Value = new System.DateTime(2022, 4, 15, 17, 8, 30, 0);
            this.datePicker_NgaySinh.ValueChanged += new System.EventHandler(this.datePicker_NgaySinh_ValueChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(154, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 1);
            this.label10.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Ngày Sinh:";
            // 
            // btn_Huy
            // 
            this.btn_Huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Huy.FlatAppearance.BorderSize = 0;
            this.btn_Huy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_Huy.Location = new System.Drawing.Point(199, 330);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(102, 32);
            this.btn_Huy.TabIndex = 37;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Luu.FlatAppearance.BorderSize = 0;
            this.btn_Luu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_Luu.Location = new System.Drawing.Point(61, 330);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(102, 32);
            this.btn_Luu.TabIndex = 36;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdo_Nu);
            this.panel1.Controls.Add(this.rdo_Nam);
            this.panel1.Location = new System.Drawing.Point(38, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 31);
            this.panel1.TabIndex = 35;
            // 
            // rdo_Nu
            // 
            this.rdo_Nu.AutoSize = true;
            this.rdo_Nu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Nu.Location = new System.Drawing.Point(191, 4);
            this.rdo_Nu.Name = "rdo_Nu";
            this.rdo_Nu.Size = new System.Drawing.Size(47, 24);
            this.rdo_Nu.TabIndex = 1;
            this.rdo_Nu.TabStop = true;
            this.rdo_Nu.Text = "Nữ";
            this.rdo_Nu.UseVisualStyleBackColor = true;
            // 
            // rdo_Nam
            // 
            this.rdo_Nam.AutoSize = true;
            this.rdo_Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Nam.Location = new System.Drawing.Point(51, 4);
            this.rdo_Nam.Name = "rdo_Nam";
            this.rdo_Nam.Size = new System.Drawing.Size(60, 24);
            this.rdo_Nam.TabIndex = 0;
            this.rdo_Nam.TabStop = true;
            this.rdo_Nam.Text = "Nam";
            this.rdo_Nam.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(153, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 1);
            this.label6.TabIndex = 28;
            // 
            // txt_HovaTen
            // 
            this.txt_HovaTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_HovaTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HovaTen.Location = new System.Drawing.Point(154, 24);
            this.txt_HovaTen.Name = "txt_HovaTen";
            this.txt_HovaTen.Size = new System.Drawing.Size(179, 17);
            this.txt_HovaTen.TabIndex = 27;
            this.txt_HovaTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_HovaTen.TextChanged += new System.EventHandler(this.txt_HovaTen_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Họ và Tên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Email:";
            // 
            // txt_Email
            // 
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(134, 175);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(179, 17);
            this.txt_Email.TabIndex = 31;
            this.txt_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(133, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 1);
            this.label8.TabIndex = 32;
            // 
            // txt_TieuSu
            // 
            this.txt_TieuSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TieuSu.Location = new System.Drawing.Point(26, 236);
            this.txt_TieuSu.Margin = new System.Windows.Forms.Padding(5);
            this.txt_TieuSu.Multiline = true;
            this.txt_TieuSu.Name = "txt_TieuSu";
            this.txt_TieuSu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_TieuSu.Size = new System.Drawing.Size(308, 75);
            this.txt_TieuSu.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tiểu Sử:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(339, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(319, 176);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // EditAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 373);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TieuSu);
            this.Controls.Add(this.txt_NgaySinh);
            this.Controls.Add(this.datePicker_NgaySinh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_HovaTen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "EditAccountForm";
            this.Text = "Chỉnh Sửa Thông Tin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NgaySinh;
        private System.Windows.Forms.DateTimePicker datePicker_NgaySinh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_Nu;
        private System.Windows.Forms.RadioButton rdo_Nam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_HovaTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_TieuSu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}