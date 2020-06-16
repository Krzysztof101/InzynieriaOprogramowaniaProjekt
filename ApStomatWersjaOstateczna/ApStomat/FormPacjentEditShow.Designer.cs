namespace ApStomat
{
    partial class FormPacjentEditShow
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
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColPole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBoxWizyty = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxZdjecia = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonZdjZobacz = new System.Windows.Forms.Button();
            this.buttonZDjDodaj = new System.Windows.Forms.Button();
            this.buttonZdjUsun = new System.Windows.Forms.Button();
            this.buttonEksport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Location = new System.Drawing.Point(12, 377);
            this.buttonZapisz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(143, 62);
            this.buttonZapisz.TabIndex = 0;
            this.buttonZapisz.Text = "zapisz";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(161, 377);
            this.buttonDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(143, 62);
            this.buttonDiagram.TabIndex = 1;
            this.buttonDiagram.Text = "pokaż diagram";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Location = new System.Drawing.Point(309, 377);
            this.buttonAnuluj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(143, 62);
            this.buttonAnuluj.TabIndex = 2;
            this.buttonAnuluj.Text = "zamknij";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPole,
            this.ColInfo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(551, 359);
            this.dataGridView1.TabIndex = 3;
            // 
            // ColPole
            // 
            this.ColPole.HeaderText = "Pole";
            this.ColPole.MinimumWidth = 6;
            this.ColPole.Name = "ColPole";
            this.ColPole.ReadOnly = true;
            this.ColPole.Width = 75;
            // 
            // ColInfo
            // 
            this.ColInfo.HeaderText = "Dana";
            this.ColInfo.MinimumWidth = 6;
            this.ColInfo.Name = "ColInfo";
            this.ColInfo.Width = 400;
            // 
            // listBoxWizyty
            // 
            this.listBoxWizyty.FormattingEnabled = true;
            this.listBoxWizyty.ItemHeight = 16;
            this.listBoxWizyty.Location = new System.Drawing.Point(603, 31);
            this.listBoxWizyty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxWizyty.Name = "listBoxWizyty";
            this.listBoxWizyty.Size = new System.Drawing.Size(540, 148);
            this.listBoxWizyty.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "wizyty";
            // 
            // listBoxZdjecia
            // 
            this.listBoxZdjecia.FormattingEnabled = true;
            this.listBoxZdjecia.ItemHeight = 16;
            this.listBoxZdjecia.Location = new System.Drawing.Point(603, 239);
            this.listBoxZdjecia.Name = "listBoxZdjecia";
            this.listBoxZdjecia.Size = new System.Drawing.Size(540, 132);
            this.listBoxZdjecia.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "zdjęcia rentgenowskie";
            // 
            // buttonZdjZobacz
            // 
            this.buttonZdjZobacz.Location = new System.Drawing.Point(603, 377);
            this.buttonZdjZobacz.Name = "buttonZdjZobacz";
            this.buttonZdjZobacz.Size = new System.Drawing.Size(143, 62);
            this.buttonZdjZobacz.TabIndex = 8;
            this.buttonZdjZobacz.Text = "otwórz";
            this.buttonZdjZobacz.UseVisualStyleBackColor = true;
            this.buttonZdjZobacz.Click += new System.EventHandler(this.buttonZdjZobacz_Click);
            // 
            // buttonZDjDodaj
            // 
            this.buttonZDjDodaj.Location = new System.Drawing.Point(752, 377);
            this.buttonZDjDodaj.Name = "buttonZDjDodaj";
            this.buttonZDjDodaj.Size = new System.Drawing.Size(143, 62);
            this.buttonZDjDodaj.TabIndex = 9;
            this.buttonZDjDodaj.Text = "dodaj zdjęcie";
            this.buttonZDjDodaj.UseVisualStyleBackColor = true;
            this.buttonZDjDodaj.Click += new System.EventHandler(this.buttonZDjDodaj_Click);
            // 
            // buttonZdjUsun
            // 
            this.buttonZdjUsun.Location = new System.Drawing.Point(901, 377);
            this.buttonZdjUsun.Name = "buttonZdjUsun";
            this.buttonZdjUsun.Size = new System.Drawing.Size(144, 62);
            this.buttonZdjUsun.TabIndex = 10;
            this.buttonZdjUsun.Text = "usuń zdjęcie";
            this.buttonZdjUsun.UseVisualStyleBackColor = true;
            this.buttonZdjUsun.Click += new System.EventHandler(this.buttonZdjUsun_Click);
            // 
            // buttonEksport
            // 
            this.buttonEksport.Location = new System.Drawing.Point(458, 377);
            this.buttonEksport.Name = "buttonEksport";
            this.buttonEksport.Size = new System.Drawing.Size(105, 61);
            this.buttonEksport.TabIndex = 11;
            this.buttonEksport.Text = "eksportuj";
            this.buttonEksport.UseVisualStyleBackColor = true;
            this.buttonEksport.Click += new System.EventHandler(this.buttonEksport_Click);
            // 
            // FormPacjentEditShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 450);
            this.Controls.Add(this.buttonEksport);
            this.Controls.Add(this.buttonZdjUsun);
            this.Controls.Add(this.buttonZDjDodaj);
            this.Controls.Add(this.buttonZdjZobacz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxZdjecia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxWizyty);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.buttonZapisz);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPacjentEditShow";
            this.Text = "Pacjent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPacjentEditShow_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonDiagram;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPole;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInfo;
        private System.Windows.Forms.ListBox listBoxWizyty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxZdjecia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonZdjZobacz;
        private System.Windows.Forms.Button buttonZDjDodaj;
        private System.Windows.Forms.Button buttonZdjUsun;
        private System.Windows.Forms.Button buttonEksport;
    }
}