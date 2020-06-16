namespace ApStomat
{
    partial class FormZdjecie
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
            this.pictureBoxZdjecie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZdjecie)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxZdjecie
            // 
            this.pictureBoxZdjecie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxZdjecie.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxZdjecie.Name = "pictureBoxZdjecie";
            this.pictureBoxZdjecie.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxZdjecie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxZdjecie.TabIndex = 0;
            this.pictureBoxZdjecie.TabStop = false;
            // 
            // FormZdjecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxZdjecie);
            this.Name = "FormZdjecie";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormZdjecie_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZdjecie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxZdjecie;
    }
}