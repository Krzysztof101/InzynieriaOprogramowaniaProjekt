namespace AplikacjaStomatologiczna
{
    partial class FormZapis
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
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxOpis = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pacjent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.labelImie = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNazwisko = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDiagram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(12, 25);
            this.textBoxImie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(153, 22);
            this.textBoxImie.TabIndex = 0;
            this.textBoxImie.TextChanged += new System.EventHandler(this.textBoxImie_TextChanged);
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(172, 25);
            this.textBoxNazwisko.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(153, 22);
            this.textBoxNazwisko.TabIndex = 1;
            this.textBoxNazwisko.TextChanged += new System.EventHandler(this.textBoxNazwisko_TextChanged);
            // 
            // textBoxOpis
            // 
            this.textBoxOpis.Location = new System.Drawing.Point(421, 121);
            this.textBoxOpis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOpis.Name = "textBoxOpis";
            this.textBoxOpis.Size = new System.Drawing.Size(249, 22);
            this.textBoxOpis.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dana,
            this.pacjent});
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(364, 358);
            this.dataGridView1.TabIndex = 4;
            // 
            // dana
            // 
            this.dana.HeaderText = "dana";
            this.dana.MinimumWidth = 6;
            this.dana.Name = "dana";
            this.dana.ReadOnly = true;
            this.dana.Width = 75;
            // 
            // pacjent
            // 
            this.pacjent.HeaderText = "pacjent";
            this.pacjent.MinimumWidth = 6;
            this.pacjent.Name = "pacjent";
            this.pacjent.ReadOnly = true;
            this.pacjent.Width = 125;
            // 
            // comboBoxId
            // 
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(507, 30);
            this.comboBoxId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(143, 24);
            this.comboBoxId.TabIndex = 5;
            this.comboBoxId.SelectedIndexChanged += new System.EventHandler(this.comboBoxId_SelectedIndexChanged);
            // 
            // textBoxCena
            // 
            this.textBoxCena.Location = new System.Drawing.Point(472, 210);
            this.textBoxCena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(176, 22);
            this.textBoxCena.TabIndex = 6;
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Location = new System.Drawing.Point(472, 292);
            this.buttonZapisz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(176, 49);
            this.buttonZapisz.TabIndex = 7;
            this.buttonZapisz.Text = "Zapisz na wizytę";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Location = new System.Drawing.Point(472, 345);
            this.buttonAnuluj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(176, 49);
            this.buttonAnuluj.TabIndex = 8;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // labelImie
            // 
            this.labelImie.AutoSize = true;
            this.labelImie.Location = new System.Drawing.Point(35, 5);
            this.labelImie.Name = "labelImie";
            this.labelImie.Size = new System.Drawing.Size(33, 17);
            this.labelImie.TabIndex = 9;
            this.labelImie.Text = "imię";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "opis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "cena";
            // 
            // labelNazwisko
            // 
            this.labelNazwisko.AutoSize = true;
            this.labelNazwisko.Location = new System.Drawing.Point(189, 5);
            this.labelNazwisko.Name = "labelNazwisko";
            this.labelNazwisko.Size = new System.Drawing.Size(65, 17);
            this.labelNazwisko.TabIndex = 14;
            this.labelNazwisko.Text = "nazwisko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "wyniki wyszukiwania";
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(472, 239);
            this.buttonDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(176, 49);
            this.buttonDiagram.TabIndex = 16;
            this.buttonDiagram.Text = "pokaż diagram";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // FormZapis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelNazwisko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelImie);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonZapisz);
            this.Controls.Add(this.textBoxCena);
            this.Controls.Add(this.comboBoxId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxOpis);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxImie);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormZapis";
            this.Text = "Wizyta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormZapisUsuwanie_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxId;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Label labelImie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNazwisko;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dana;
        private System.Windows.Forms.DataGridViewTextBoxColumn pacjent;
        private System.Windows.Forms.Button buttonDiagram;
    }
}