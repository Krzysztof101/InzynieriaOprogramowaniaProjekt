namespace AplikacjaStomatologiczna
{
    partial class FormTworzenieHasla
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
            this.textBoxHaslo1 = new System.Windows.Forms.TextBox();
            this.textBoxHaslo2 = new System.Windows.Forms.TextBox();
            this.buttonPotwierdz = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxHaslo1
            // 
            this.textBoxHaslo1.Location = new System.Drawing.Point(111, 53);
            this.textBoxHaslo1.Name = "textBoxHaslo1";
            this.textBoxHaslo1.Size = new System.Drawing.Size(239, 22);
            this.textBoxHaslo1.TabIndex = 0;
            // 
            // textBoxHaslo2
            // 
            this.textBoxHaslo2.Location = new System.Drawing.Point(111, 81);
            this.textBoxHaslo2.Name = "textBoxHaslo2";
            this.textBoxHaslo2.Size = new System.Drawing.Size(239, 22);
            this.textBoxHaslo2.TabIndex = 1;
            // 
            // buttonPotwierdz
            // 
            this.buttonPotwierdz.Location = new System.Drawing.Point(111, 109);
            this.buttonPotwierdz.Name = "buttonPotwierdz";
            this.buttonPotwierdz.Size = new System.Drawing.Size(239, 47);
            this.buttonPotwierdz.TabIndex = 2;
            this.buttonPotwierdz.Text = "Potwierdź";
            this.buttonPotwierdz.UseVisualStyleBackColor = true;
            this.buttonPotwierdz.Click += new System.EventHandler(this.buttonPotwierdz_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Location = new System.Drawing.Point(111, 162);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(239, 47);
            this.buttonAnuluj.TabIndex = 3;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "hasło";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "powtórz hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Utwórz hasło";
            // 
            // FormTworzenieHasla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 228);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonPotwierdz);
            this.Controls.Add(this.textBoxHaslo2);
            this.Controls.Add(this.textBoxHaslo1);
            this.Name = "FormTworzenieHasla";
            this.Text = "Tworzenie hasła";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTworzenieHasla_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHaslo1;
        private System.Windows.Forms.TextBox textBoxHaslo2;
        private System.Windows.Forms.Button buttonPotwierdz;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}