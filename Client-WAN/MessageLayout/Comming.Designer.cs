namespace Client
{
    partial class Comming
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
            this.MessageIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageIn
            // 
            this.MessageIn.BackColor = System.Drawing.Color.Transparent;
            this.MessageIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.MessageIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageIn.ForeColor = System.Drawing.Color.Black;
            this.MessageIn.Location = new System.Drawing.Point(0, 0);
            this.MessageIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MessageIn.Name = "MessageIn";
            this.MessageIn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.MessageIn.Size = new System.Drawing.Size(331, 26);
            this.MessageIn.TabIndex = 0;
            this.MessageIn.Text = "label1";
            // 
            // Comming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MessageIn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Comming";
            this.Size = new System.Drawing.Size(533, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MessageIn;
    }
}
