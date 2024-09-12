namespace Client
{
    partial class ChooseAvatar
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_DongY = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(530, 386);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // btn_DongY
            // 
            this.btn_DongY.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DongY.Location = new System.Drawing.Point(363, 405);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.Size = new System.Drawing.Size(75, 33);
            this.btn_DongY.TabIndex = 1;
            this.btn_DongY.Text = "Đồng Ý";
            this.btn_DongY.UseVisualStyleBackColor = true;
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.Location = new System.Drawing.Point(454, 405);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(75, 33);
            this.btn_Huy.TabIndex = 2;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // ChooseAvatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(554, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_DongY);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ChooseAvatar";
            this.Text = "Đổi Ảnh Đại Diện";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btn_DongY;
        private System.Windows.Forms.Button btn_Huy;
    }
}