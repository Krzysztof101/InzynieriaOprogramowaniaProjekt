namespace AplikacjaStomatologiczna
{
    partial class FormPobierzHaslo
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
            this.buttonPotwierdz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPotwierdz
            // 
            this.buttonPotwierdz.Location = new System.Drawing.Point(60, 162);
            this.buttonPotwierdz.Name = "buttonPotwierdz";
            this.buttonPotwierdz.Size = new System.Drawing.Size(177, 49);
            this.buttonPotwierdz.TabIndex = 0;
            this.buttonPotwierdz.Text = "Potwierdź hasło";
            this.buttonPotwierdz.UseVisualStyleBackColor = true;
            this.buttonPotwierdz.Click += new System.EventHandler(this.buttonPotwierdz_Click);
            this.buttonPotwierdz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonPotwierdz_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj hasło";
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(60, 134);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.Size = new System.Drawing.Size(177, 22);
            this.textBoxHaslo.TabIndex = 2;
            this.textBoxHaslo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHaslo_KeyDown);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Location = new System.Drawing.Point(60, 217);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(177, 49);
            this.buttonAnuluj.TabIndex = 3;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // FormPobierzHaslo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 297);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPotwierdz);
            this.Name = "FormPobierzHaslo";
            this.Text = "Wprowadź hasło";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPobierzHaslo_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPobierzHaslo_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPotwierdz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.Button buttonAnuluj;
    }
}