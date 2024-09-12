namespace Client
{
    partial class ValidationEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaXacMinh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_GuiLaiMa = new System.Windows.Forms.Label();
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã xác minh đã được gửi tới Email của bạn:";
            // 
            // txt_MaXacMinh
            // 
            this.txt_MaXacMinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaXacMinh.Location = new System.Drawing.Point(107, 71);
            this.txt_MaXacMinh.Name = "txt_MaXacMinh";
            this.txt_MaXacMinh.Size = new System.Drawing.Size(120, 21);
            this.txt_MaXacMinh.TabIndex = 1;
            this.txt_MaXacMinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã xác minh:";
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XacNhan.FlatAppearance.BorderSize = 0;
            this.btn_XacNhan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_XacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XacNhan.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_XacNhan.Location = new System.Drawing.Point(168, 112);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(86, 24);
            this.btn_XacNhan.TabIndex = 39;
            this.btn_XacNhan.Text = "Xác Nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(233, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label_GuiLaiMa
            // 
            this.label_GuiLaiMa.AutoSize = true;
            this.label_GuiLaiMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_GuiLaiMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GuiLaiMa.ForeColor = System.Drawing.Color.DarkCyan;
            this.label_GuiLaiMa.Location = new System.Drawing.Point(10, 120);
            this.label_GuiLaiMa.Name = "label_GuiLaiMa";
            this.label_GuiLaiMa.Size = new System.Drawing.Size(63, 15);
            this.label_GuiLaiMa.TabIndex = 41;
            this.label_GuiLaiMa.Text = "Gửi lại mã";
            this.label_GuiLaiMa.Click += new System.EventHandler(this.label_GuiLaiMa_Click);
            // 
            // pictureBox_Close
            // 
            this.pictureBox_Close.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Close.Image")));
            this.pictureBox_Close.Location = new System.Drawing.Point(264, -3);
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.Size = new System.Drawing.Size(29, 25);
            this.pictureBox_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Close.TabIndex = 42;
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            // 
            // ValidationEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 144);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_Close);
            this.Controls.Add(this.label_GuiLaiMa);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaXacMinh);
            this.Controls.Add(this.label1);
            this.Name = "ValidationEmail";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaXacMinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_GuiLaiMa;
        private System.Windows.Forms.PictureBox pictureBox_Close;
    }
}