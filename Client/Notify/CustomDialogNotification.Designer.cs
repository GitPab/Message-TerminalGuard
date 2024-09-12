namespace Client
{
    partial class CustomDialogNotification
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
            this.label_Notification = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Notification
            // 
            this.label_Notification.BackColor = System.Drawing.Color.White;
            this.label_Notification.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Notification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Notification.Location = new System.Drawing.Point(0, 0);
            this.label_Notification.Name = "label_Notification";
            this.label_Notification.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_Notification.Size = new System.Drawing.Size(222, 119);
            this.label_Notification.TabIndex = 0;
            this.label_Notification.Text = "Notification";
            this.label_Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Cancel.Location = new System.Drawing.Point(156, 122);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(54, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_OK.Location = new System.Drawing.Point(96, 122);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(54, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // CustomDialogNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(222, 148);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label_Notification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomDialogNotification";
            this.Text = "CustomDialogNotification";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Notification;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}