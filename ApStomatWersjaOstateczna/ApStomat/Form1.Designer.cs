namespace AplikacjaStomatologiczna
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTerminarz = new System.Windows.Forms.Button();
            this.buttonKartoteka = new System.Windows.Forms.Button();
            this.dataGridViewGrafik = new System.Windows.Forms.DataGridView();
            this.ColGodziny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDzien7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonDzienWcz = new System.Windows.Forms.Button();
            this.buttonDzienPoz = new System.Windows.Forms.Button();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonPokaz = new System.Windows.Forms.Button();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxGodzOd = new System.Windows.Forms.ComboBox();
            this.comboBoxMinOd = new System.Windows.Forms.ComboBox();
            this.comboBoxGodzDo = new System.Windows.Forms.ComboBox();
            this.comboBoxMinDo = new System.Windows.Forms.ComboBox();
            this.labelGodzRoz = new System.Windows.Forms.Label();
            this.labelGodzZak = new System.Windows.Forms.Label();
            this.dataGridViewKartLista = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNazwisko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonKartPokaz = new System.Windows.Forms.Button();
            this.buttonKartNowy = new System.Windows.Forms.Button();
            this.buttonKartUsun = new System.Windows.Forms.Button();
            this.buttonKartEdytuj = new System.Windows.Forms.Button();
            this.textBoxKartId = new System.Windows.Forms.TextBox();
            this.labelKartId = new System.Windows.Forms.Label();
            this.groupBoxPacjenci = new System.Windows.Forms.GroupBox();
            this.radioButtonPacjUs = new System.Windows.Forms.RadioButton();
            this.radioButtonPacj = new System.Windows.Forms.RadioButton();
            this.buttonKartPrzywroc = new System.Windows.Forms.Button();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            this.buttonKonfiguracja = new System.Windows.Forms.Button();
            this.textBoxWyszukaj = new System.Windows.Forms.TextBox();
            this.buttonNastepny = new System.Windows.Forms.Button();
            this.labelWyszukaj = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelKonfigOdswiez = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrafik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKartLista)).BeginInit();
            this.groupBoxPacjenci.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelKonfigOdswiez.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTerminarz
            // 
            this.buttonTerminarz.Location = new System.Drawing.Point(12, 12);
            this.buttonTerminarz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTerminarz.Name = "buttonTerminarz";
            this.buttonTerminarz.Size = new System.Drawing.Size(187, 87);
            this.buttonTerminarz.TabIndex = 0;
            this.buttonTerminarz.Text = "Termiarz";
            this.buttonTerminarz.UseVisualStyleBackColor = true;
            this.buttonTerminarz.Click += new System.EventHandler(this.buttonTerminarz_Click);
            // 
            // buttonKartoteka
            // 
            this.buttonKartoteka.Location = new System.Drawing.Point(204, 12);
            this.buttonKartoteka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartoteka.Name = "buttonKartoteka";
            this.buttonKartoteka.Size = new System.Drawing.Size(187, 87);
            this.buttonKartoteka.TabIndex = 1;
            this.buttonKartoteka.Text = "Kartoteka";
            this.buttonKartoteka.UseVisualStyleBackColor = true;
            this.buttonKartoteka.Click += new System.EventHandler(this.buttonKartoteka_Click);
            // 
            // dataGridViewGrafik
            // 
            this.dataGridViewGrafik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrafik.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColGodziny,
            this.ColDzien1,
            this.ColDzien2,
            this.ColDzien3,
            this.ColDzien4,
            this.ColDzien5,
            this.ColDzien6,
            this.ColDzien7});
            this.dataGridViewGrafik.Location = new System.Drawing.Point(12, 214);
            this.dataGridViewGrafik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewGrafik.Name = "dataGridViewGrafik";
            this.dataGridViewGrafik.RowHeadersWidth = 51;
            this.dataGridViewGrafik.RowTemplate.Height = 24;
            this.dataGridViewGrafik.Size = new System.Drawing.Size(1428, 413);
            this.dataGridViewGrafik.TabIndex = 2;
            this.dataGridViewGrafik.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrafik_CellClick);
            // 
            // ColGodziny
            // 
            this.ColGodziny.HeaderText = "Column1";
            this.ColGodziny.MinimumWidth = 6;
            this.ColGodziny.Name = "ColGodziny";
            this.ColGodziny.ReadOnly = true;
            this.ColGodziny.Width = 125;
            // 
            // ColDzien1
            // 
            this.ColDzien1.HeaderText = "Column1";
            this.ColDzien1.MinimumWidth = 6;
            this.ColDzien1.Name = "ColDzien1";
            this.ColDzien1.ReadOnly = true;
            this.ColDzien1.Width = 125;
            // 
            // ColDzien2
            // 
            this.ColDzien2.HeaderText = "Column1";
            this.ColDzien2.MinimumWidth = 6;
            this.ColDzien2.Name = "ColDzien2";
            this.ColDzien2.ReadOnly = true;
            this.ColDzien2.Width = 125;
            // 
            // ColDzien3
            // 
            this.ColDzien3.HeaderText = "Column1";
            this.ColDzien3.MinimumWidth = 6;
            this.ColDzien3.Name = "ColDzien3";
            this.ColDzien3.ReadOnly = true;
            this.ColDzien3.Width = 125;
            // 
            // ColDzien4
            // 
            this.ColDzien4.HeaderText = "Column1";
            this.ColDzien4.MinimumWidth = 6;
            this.ColDzien4.Name = "ColDzien4";
            this.ColDzien4.ReadOnly = true;
            this.ColDzien4.Width = 125;
            // 
            // ColDzien5
            // 
            this.ColDzien5.HeaderText = "Column1";
            this.ColDzien5.MinimumWidth = 6;
            this.ColDzien5.Name = "ColDzien5";
            this.ColDzien5.ReadOnly = true;
            this.ColDzien5.Width = 125;
            // 
            // ColDzien6
            // 
            this.ColDzien6.HeaderText = "Column1";
            this.ColDzien6.MinimumWidth = 6;
            this.ColDzien6.Name = "ColDzien6";
            this.ColDzien6.ReadOnly = true;
            this.ColDzien6.Width = 125;
            // 
            // ColDzien7
            // 
            this.ColDzien7.HeaderText = "Column1";
            this.ColDzien7.MinimumWidth = 6;
            this.ColDzien7.Name = "ColDzien7";
            this.ColDzien7.ReadOnly = true;
            this.ColDzien7.Width = 125;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 105);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(377, 22);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonDzienWcz
            // 
            this.buttonDzienWcz.Location = new System.Drawing.Point(12, 133);
            this.buttonDzienWcz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDzienWcz.Name = "buttonDzienWcz";
            this.buttonDzienWcz.Size = new System.Drawing.Size(187, 75);
            this.buttonDzienWcz.TabIndex = 4;
            this.buttonDzienWcz.Text = "Dzień Wcześniej";
            this.buttonDzienWcz.UseVisualStyleBackColor = true;
            this.buttonDzienWcz.Click += new System.EventHandler(this.buttonDzienWcz_Click);
            // 
            // buttonDzienPoz
            // 
            this.buttonDzienPoz.Location = new System.Drawing.Point(204, 133);
            this.buttonDzienPoz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDzienPoz.Name = "buttonDzienPoz";
            this.buttonDzienPoz.Size = new System.Drawing.Size(187, 75);
            this.buttonDzienPoz.TabIndex = 5;
            this.buttonDzienPoz.Text = "Dzień Później";
            this.buttonDzienPoz.UseVisualStyleBackColor = true;
            this.buttonDzienPoz.Click += new System.EventHandler(this.buttonDzienPoz_Click);
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Location = new System.Drawing.Point(763, 12);
            this.buttonZapisz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(187, 34);
            this.buttonZapisz.TabIndex = 6;
            this.buttonZapisz.Text = "Zapisz na Wizytę";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // buttonPokaz
            // 
            this.buttonPokaz.Location = new System.Drawing.Point(763, 53);
            this.buttonPokaz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPokaz.Name = "buttonPokaz";
            this.buttonPokaz.Size = new System.Drawing.Size(187, 34);
            this.buttonPokaz.TabIndex = 7;
            this.buttonPokaz.Text = "Pokaż wizytę";
            this.buttonPokaz.UseVisualStyleBackColor = true;
            this.buttonPokaz.Click += new System.EventHandler(this.buttonPokaz_Click);
            // 
            // buttonUsun
            // 
            this.buttonUsun.Location = new System.Drawing.Point(763, 94);
            this.buttonUsun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(187, 34);
            this.buttonUsun.TabIndex = 8;
            this.buttonUsun.Text = "Usuń wizytę";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(556, 12);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // comboBoxGodzOd
            // 
            this.comboBoxGodzOd.FormattingEnabled = true;
            this.comboBoxGodzOd.Location = new System.Drawing.Point(556, 39);
            this.comboBoxGodzOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGodzOd.Name = "comboBoxGodzOd";
            this.comboBoxGodzOd.Size = new System.Drawing.Size(95, 24);
            this.comboBoxGodzOd.TabIndex = 10;
            // 
            // comboBoxMinOd
            // 
            this.comboBoxMinOd.FormattingEnabled = true;
            this.comboBoxMinOd.Location = new System.Drawing.Point(661, 39);
            this.comboBoxMinOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMinOd.Name = "comboBoxMinOd";
            this.comboBoxMinOd.Size = new System.Drawing.Size(95, 24);
            this.comboBoxMinOd.TabIndex = 11;
            // 
            // comboBoxGodzDo
            // 
            this.comboBoxGodzDo.FormattingEnabled = true;
            this.comboBoxGodzDo.Location = new System.Drawing.Point(556, 70);
            this.comboBoxGodzDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGodzDo.Name = "comboBoxGodzDo";
            this.comboBoxGodzDo.Size = new System.Drawing.Size(95, 24);
            this.comboBoxGodzDo.TabIndex = 12;
            // 
            // comboBoxMinDo
            // 
            this.comboBoxMinDo.FormattingEnabled = true;
            this.comboBoxMinDo.Location = new System.Drawing.Point(661, 70);
            this.comboBoxMinDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMinDo.Name = "comboBoxMinDo";
            this.comboBoxMinDo.Size = new System.Drawing.Size(95, 24);
            this.comboBoxMinDo.TabIndex = 13;
            // 
            // labelGodzRoz
            // 
            this.labelGodzRoz.AutoSize = true;
            this.labelGodzRoz.Location = new System.Drawing.Point(409, 43);
            this.labelGodzRoz.Name = "labelGodzRoz";
            this.labelGodzRoz.Size = new System.Drawing.Size(138, 17);
            this.labelGodzRoz.TabIndex = 14;
            this.labelGodzRoz.Text = "godzina rozpoczęcia";
            // 
            // labelGodzZak
            // 
            this.labelGodzZak.AutoSize = true;
            this.labelGodzZak.Location = new System.Drawing.Point(409, 73);
            this.labelGodzZak.Name = "labelGodzZak";
            this.labelGodzZak.Size = new System.Drawing.Size(141, 17);
            this.labelGodzZak.TabIndex = 15;
            this.labelGodzZak.Text = "godzina zakończenia";
            // 
            // dataGridViewKartLista
            // 
            this.dataGridViewKartLista.AllowUserToAddRows = false;
            this.dataGridViewKartLista.AllowUserToDeleteRows = false;
            this.dataGridViewKartLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKartLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColImie,
            this.ColNazwisko});
            this.dataGridViewKartLista.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewKartLista.Location = new System.Drawing.Point(1010, 11);
            this.dataGridViewKartLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewKartLista.MultiSelect = false;
            this.dataGridViewKartLista.Name = "dataGridViewKartLista";
            this.dataGridViewKartLista.ReadOnly = true;
            this.dataGridViewKartLista.RowHeadersWidth = 51;
            this.dataGridViewKartLista.RowTemplate.Height = 24;
            this.dataGridViewKartLista.Size = new System.Drawing.Size(471, 719);
            this.dataGridViewKartLista.TabIndex = 16;
            this.dataGridViewKartLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKartLista_CellContentClick);
            this.dataGridViewKartLista.SelectionChanged += new System.EventHandler(this.dataGridViewKartLista_SelectionChanged);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "id";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Width = 50;
            // 
            // ColImie
            // 
            this.ColImie.HeaderText = "imię";
            this.ColImie.MinimumWidth = 6;
            this.ColImie.Name = "ColImie";
            this.ColImie.ReadOnly = true;
            this.ColImie.Width = 125;
            // 
            // ColNazwisko
            // 
            this.ColNazwisko.HeaderText = "nazwisko";
            this.ColNazwisko.MinimumWidth = 6;
            this.ColNazwisko.Name = "ColNazwisko";
            this.ColNazwisko.ReadOnly = true;
            this.ColNazwisko.Width = 125;
            // 
            // buttonKartPokaz
            // 
            this.buttonKartPokaz.Location = new System.Drawing.Point(871, 172);
            this.buttonKartPokaz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartPokaz.Name = "buttonKartPokaz";
            this.buttonKartPokaz.Size = new System.Drawing.Size(133, 33);
            this.buttonKartPokaz.TabIndex = 17;
            this.buttonKartPokaz.Text = "Pokaż pacjenta";
            this.buttonKartPokaz.UseVisualStyleBackColor = true;
            this.buttonKartPokaz.Click += new System.EventHandler(this.buttonKartPokaz_Click);
            // 
            // buttonKartNowy
            // 
            this.buttonKartNowy.Location = new System.Drawing.Point(731, 172);
            this.buttonKartNowy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartNowy.Name = "buttonKartNowy";
            this.buttonKartNowy.Size = new System.Drawing.Size(133, 36);
            this.buttonKartNowy.TabIndex = 18;
            this.buttonKartNowy.Text = "Nowy pacjent";
            this.buttonKartNowy.UseVisualStyleBackColor = true;
            this.buttonKartNowy.Click += new System.EventHandler(this.buttonKartNowy_Click);
            // 
            // buttonKartUsun
            // 
            this.buttonKartUsun.Location = new System.Drawing.Point(731, 210);
            this.buttonKartUsun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartUsun.Name = "buttonKartUsun";
            this.buttonKartUsun.Size = new System.Drawing.Size(133, 33);
            this.buttonKartUsun.TabIndex = 19;
            this.buttonKartUsun.Text = "Usuń pacjenta";
            this.buttonKartUsun.UseVisualStyleBackColor = true;
            this.buttonKartUsun.Click += new System.EventHandler(this.buttonKartUsun_Click);
            // 
            // buttonKartEdytuj
            // 
            this.buttonKartEdytuj.Location = new System.Drawing.Point(871, 210);
            this.buttonKartEdytuj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartEdytuj.Name = "buttonKartEdytuj";
            this.buttonKartEdytuj.Size = new System.Drawing.Size(133, 33);
            this.buttonKartEdytuj.TabIndex = 20;
            this.buttonKartEdytuj.Text = "Edytuj pacjenta";
            this.buttonKartEdytuj.UseVisualStyleBackColor = true;
            this.buttonKartEdytuj.Click += new System.EventHandler(this.buttonKartEdytuj_Click);
            // 
            // textBoxKartId
            // 
            this.textBoxKartId.Location = new System.Drawing.Point(731, 140);
            this.textBoxKartId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKartId.Name = "textBoxKartId";
            this.textBoxKartId.Size = new System.Drawing.Size(135, 22);
            this.textBoxKartId.TabIndex = 21;
            this.textBoxKartId.Visible = false;
            // 
            // labelKartId
            // 
            this.labelKartId.AutoSize = true;
            this.labelKartId.Location = new System.Drawing.Point(707, 143);
            this.labelKartId.Name = "labelKartId";
            this.labelKartId.Size = new System.Drawing.Size(19, 17);
            this.labelKartId.TabIndex = 22;
            this.labelKartId.Text = "id";
            this.labelKartId.Visible = false;
            // 
            // groupBoxPacjenci
            // 
            this.groupBoxPacjenci.Controls.Add(this.radioButtonPacjUs);
            this.groupBoxPacjenci.Controls.Add(this.radioButtonPacj);
            this.groupBoxPacjenci.Location = new System.Drawing.Point(535, 172);
            this.groupBoxPacjenci.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPacjenci.Name = "groupBoxPacjenci";
            this.groupBoxPacjenci.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPacjenci.Size = new System.Drawing.Size(181, 71);
            this.groupBoxPacjenci.TabIndex = 27;
            this.groupBoxPacjenci.TabStop = false;
            this.groupBoxPacjenci.Enter += new System.EventHandler(this.groupBoxPacjenci_Enter);
            // 
            // radioButtonPacjUs
            // 
            this.radioButtonPacjUs.AutoSize = true;
            this.radioButtonPacjUs.Location = new System.Drawing.Point(29, 46);
            this.radioButtonPacjUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPacjUs.Name = "radioButtonPacjUs";
            this.radioButtonPacjUs.Size = new System.Drawing.Size(137, 21);
            this.radioButtonPacjUs.TabIndex = 1;
            this.radioButtonPacjUs.TabStop = true;
            this.radioButtonPacjUs.Text = "pacjenci usunieci";
            this.radioButtonPacjUs.UseVisualStyleBackColor = true;
            // 
            // radioButtonPacj
            // 
            this.radioButtonPacj.AutoSize = true;
            this.radioButtonPacj.Location = new System.Drawing.Point(29, 18);
            this.radioButtonPacj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPacj.Name = "radioButtonPacj";
            this.radioButtonPacj.Size = new System.Drawing.Size(81, 21);
            this.radioButtonPacj.TabIndex = 0;
            this.radioButtonPacj.TabStop = true;
            this.radioButtonPacj.Text = "pacjenci";
            this.radioButtonPacj.UseVisualStyleBackColor = true;
            this.radioButtonPacj.CheckedChanged += new System.EventHandler(this.radioButtonPacj_CheckedChanged);
            // 
            // buttonKartPrzywroc
            // 
            this.buttonKartPrzywroc.Location = new System.Drawing.Point(871, 133);
            this.buttonKartPrzywroc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKartPrzywroc.Name = "buttonKartPrzywroc";
            this.buttonKartPrzywroc.Size = new System.Drawing.Size(133, 36);
            this.buttonKartPrzywroc.TabIndex = 28;
            this.buttonKartPrzywroc.Text = "Przywróć pacjenta";
            this.buttonKartPrzywroc.UseVisualStyleBackColor = true;
            this.buttonKartPrzywroc.Click += new System.EventHandler(this.buttonKartPrzywroc_Click);
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.Location = new System.Drawing.Point(0, 33);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(138, 28);
            this.buttonOdswiez.TabIndex = 29;
            this.buttonOdswiez.Text = "odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = true;
            this.buttonOdswiez.Click += new System.EventHandler(this.buttonOdswiez_Click);
            // 
            // buttonKonfiguracja
            // 
            this.buttonKonfiguracja.Location = new System.Drawing.Point(0, 1);
            this.buttonKonfiguracja.Name = "buttonKonfiguracja";
            this.buttonKonfiguracja.Size = new System.Drawing.Size(138, 28);
            this.buttonKonfiguracja.TabIndex = 30;
            this.buttonKonfiguracja.Text = "Konfiguracja";
            this.buttonKonfiguracja.UseVisualStyleBackColor = true;
            this.buttonKonfiguracja.Click += new System.EventHandler(this.buttonKonfiguracja_Click);
            // 
            // textBoxWyszukaj
            // 
            this.textBoxWyszukaj.Location = new System.Drawing.Point(731, 248);
            this.textBoxWyszukaj.Name = "textBoxWyszukaj";
            this.textBoxWyszukaj.Size = new System.Drawing.Size(133, 22);
            this.textBoxWyszukaj.TabIndex = 31;
            this.textBoxWyszukaj.TextChanged += new System.EventHandler(this.textBoxWyszukaj_TextChanged);
            // 
            // buttonNastepny
            // 
            this.buttonNastepny.Location = new System.Drawing.Point(871, 248);
            this.buttonNastepny.Name = "buttonNastepny";
            this.buttonNastepny.Size = new System.Drawing.Size(133, 36);
            this.buttonNastepny.TabIndex = 32;
            this.buttonNastepny.Text = "następny";
            this.buttonNastepny.UseVisualStyleBackColor = true;
            this.buttonNastepny.Click += new System.EventHandler(this.buttonNastepny_Click);
            // 
            // labelWyszukaj
            // 
            this.labelWyszukaj.AutoSize = true;
            this.labelWyszukaj.Location = new System.Drawing.Point(16, 0);
            this.labelWyszukaj.Name = "labelWyszukaj";
            this.labelWyszukaj.Size = new System.Drawing.Size(60, 20);
            this.labelWyszukaj.TabIndex = 33;
            this.labelWyszukaj.Text = "nazwisko";
            this.labelWyszukaj.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelWyszukaj.UseCompatibleTextRendering = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelWyszukaj);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(646, 248);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(79, 23);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // panelKonfigOdswiez
            // 
            this.panelKonfigOdswiez.Controls.Add(this.buttonKonfiguracja);
            this.panelKonfigOdswiez.Controls.Add(this.buttonOdswiez);
            this.panelKonfigOdswiez.Location = new System.Drawing.Point(408, 99);
            this.panelKonfigOdswiez.Name = "panelKonfigOdswiez";
            this.panelKonfigOdswiez.Size = new System.Drawing.Size(139, 63);
            this.panelKonfigOdswiez.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 736);
            this.Controls.Add(this.panelKonfigOdswiez);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonNastepny);
            this.Controls.Add(this.textBoxWyszukaj);
            this.Controls.Add(this.buttonKartPrzywroc);
            this.Controls.Add(this.groupBoxPacjenci);
            this.Controls.Add(this.labelKartId);
            this.Controls.Add(this.textBoxKartId);
            this.Controls.Add(this.buttonKartEdytuj);
            this.Controls.Add(this.buttonKartUsun);
            this.Controls.Add(this.buttonKartNowy);
            this.Controls.Add(this.buttonKartPokaz);
            this.Controls.Add(this.dataGridViewKartLista);
            this.Controls.Add(this.labelGodzZak);
            this.Controls.Add(this.labelGodzRoz);
            this.Controls.Add(this.comboBoxMinDo);
            this.Controls.Add(this.comboBoxGodzDo);
            this.Controls.Add(this.comboBoxMinOd);
            this.Controls.Add(this.comboBoxGodzOd);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.buttonUsun);
            this.Controls.Add(this.buttonPokaz);
            this.Controls.Add(this.buttonZapisz);
            this.Controls.Add(this.buttonDzienPoz);
            this.Controls.Add(this.buttonDzienWcz);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridViewGrafik);
            this.Controls.Add(this.buttonKartoteka);
            this.Controls.Add(this.buttonTerminarz);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ApStomat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrafik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKartLista)).EndInit();
            this.groupBoxPacjenci.ResumeLayout(false);
            this.groupBoxPacjenci.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelKonfigOdswiez.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTerminarz;
        private System.Windows.Forms.Button buttonKartoteka;
        private System.Windows.Forms.DataGridView dataGridViewGrafik;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGodziny;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDzien7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonDzienWcz;
        private System.Windows.Forms.Button buttonDzienPoz;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonPokaz;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBoxGodzOd;
        private System.Windows.Forms.ComboBox comboBoxMinOd;
        private System.Windows.Forms.ComboBox comboBoxGodzDo;
        private System.Windows.Forms.ComboBox comboBoxMinDo;
        private System.Windows.Forms.Label labelGodzRoz;
        private System.Windows.Forms.Label labelGodzZak;
        private System.Windows.Forms.DataGridView dataGridViewKartLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColImie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNazwisko;
        private System.Windows.Forms.Button buttonKartPokaz;
        private System.Windows.Forms.Button buttonKartNowy;
        private System.Windows.Forms.Button buttonKartUsun;
        private System.Windows.Forms.Button buttonKartEdytuj;
        private System.Windows.Forms.TextBox textBoxKartId;
        private System.Windows.Forms.Label labelKartId;
        private System.Windows.Forms.GroupBox groupBoxPacjenci;
        private System.Windows.Forms.RadioButton radioButtonPacjUs;
        private System.Windows.Forms.RadioButton radioButtonPacj;
        private System.Windows.Forms.Button buttonKartPrzywroc;
        private System.Windows.Forms.Button buttonOdswiez;
        private System.Windows.Forms.Button buttonKonfiguracja;
        private System.Windows.Forms.TextBox textBoxWyszukaj;
        private System.Windows.Forms.Button buttonNastepny;
        private System.Windows.Forms.Label labelWyszukaj;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelKonfigOdswiez;
    }
}

