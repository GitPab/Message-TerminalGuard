namespace Client
{
    partial class GoingMessage
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
            this.MessageOut = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageOut
            // 
            this.MessageOut.BackColor = System.Drawing.Color.LightBlue;
            this.MessageOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.MessageOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageOut.ForeColor = System.Drawing.Color.Black;
            this.MessageOut.Location = new System.Drawing.Point(221, 0);
            this.MessageOut.Name = "MessageOut";
            this.MessageOut.Size = new System.Drawing.Size(179, 20);
            this.MessageOut.TabIndex = 0;
            this.MessageOut.Text = "label1";
            this.MessageOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // GoingMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MessageOut);
            this.Name = "GoingMessage";
            this.Size = new System.Drawing.Size(400, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MessageOut;
    }
}
