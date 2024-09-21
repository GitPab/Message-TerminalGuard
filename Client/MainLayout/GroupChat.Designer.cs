
namespace Client.MainLayout
{
    partial class GroupChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupChat));
            this.name = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(-4, 21);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(219, 38);
            this.name.TabIndex = 1;
            this.name.Text = "Người Lạ";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Gray;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.Location = new System.Drawing.Point(171, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(38, 40);
            this.btn_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_Close.TabIndex = 3;
            this.btn_Close.TabStop = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // GroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.name);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GroupChat";
            this.Size = new System.Drawing.Size(209, 78);
            this.Click += new System.EventHandler(this.HistoryUser_OnClick);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox btn_Close;
    }
}
