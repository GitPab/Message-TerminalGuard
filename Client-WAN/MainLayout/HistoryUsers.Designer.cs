
namespace Client.MainLayout
{
    partial class HistoryUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryUsers));
            this.avatar = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.Image = ((System.Drawing.Image)(resources.GetObject("avatar.Image")));
            this.avatar.Location = new System.Drawing.Point(31, 7);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(107, 99);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(1, 109);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(164, 31);
            this.name.TabIndex = 1;
            this.name.Text = "Người Lạ";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // HistoryUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.name);
            this.Controls.Add(this.avatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "HistoryUsers";
            this.Size = new System.Drawing.Size(167, 144);
            this.Click += new System.EventHandler(this.HistoryUser_OnClick);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label name;
    }
}
