namespace AplikacjaStomatologiczna
{
    partial class FormDiagram
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
            this.canvas = new System.Windows.Forms.Panel();
            this.labRzad = new System.Windows.Forms.Label();
            this.labNumer = new System.Windows.Forms.Label();
            this.labKolor = new System.Windows.Forms.Label();
            this.ZebyPrzycisk = new System.Windows.Forms.Button();
            this.labCzesc = new System.Windows.Forms.Label();
            this.KolorBox = new System.Windows.Forms.ComboBox();
            this.CzescBox = new System.Windows.Forms.ComboBox();
            this.NumerBox = new System.Windows.Forms.ComboBox();
            this.RzadBox = new System.Windows.Forms.ComboBox();
            this.przelacznik = new System.Windows.Forms.Button();
            this.buttonZakoncz = new System.Windows.Forms.Button();
            this.lab11 = new System.Windows.Forms.Label();
            this.lab12 = new System.Windows.Forms.Label();
            this.lab13 = new System.Windows.Forms.Label();
            this.lab14 = new System.Windows.Forms.Label();
            this.lab15 = new System.Windows.Forms.Label();
            this.lab16 = new System.Windows.Forms.Label();
            this.lab17 = new System.Windows.Forms.Label();
            this.lab18 = new System.Windows.Forms.Label();
            this.lab19 = new System.Windows.Forms.Label();
            this.lab110 = new System.Windows.Forms.Label();
            this.lab111 = new System.Windows.Forms.Label();
            this.lab112 = new System.Windows.Forms.Label();
            this.lab113 = new System.Windows.Forms.Label();
            this.lab114 = new System.Windows.Forms.Label();
            this.lab115 = new System.Windows.Forms.Label();
            this.lab116 = new System.Windows.Forms.Label();
            this.lab21 = new System.Windows.Forms.Label();
            this.lab22 = new System.Windows.Forms.Label();
            this.lab23 = new System.Windows.Forms.Label();
            this.lab24 = new System.Windows.Forms.Label();
            this.lab25 = new System.Windows.Forms.Label();
            this.lab26 = new System.Windows.Forms.Label();
            this.lab27 = new System.Windows.Forms.Label();
            this.lab28 = new System.Windows.Forms.Label();
            this.lab29 = new System.Windows.Forms.Label();
            this.lab210 = new System.Windows.Forms.Label();
            this.lab211 = new System.Windows.Forms.Label();
            this.lab212 = new System.Windows.Forms.Label();
            this.lab213 = new System.Windows.Forms.Label();
            this.lab214 = new System.Windows.Forms.Label();
            this.lab215 = new System.Windows.Forms.Label();
            this.lab216 = new System.Windows.Forms.Label();
            this.labRzad1 = new System.Windows.Forms.Label();
            this.labRzad2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canvas.Location = new System.Drawing.Point(160, 246);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1493, 430);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.RysujDiagram);
            // 
            // labRzad
            // 
            this.labRzad.AutoSize = true;
            this.labRzad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labRzad.Location = new System.Drawing.Point(381, 48);
            this.labRzad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRzad.Name = "labRzad";
            this.labRzad.Size = new System.Drawing.Size(111, 20);
            this.labRzad.TabIndex = 2;
            this.labRzad.Text = "Rząd zębów";
            // 
            // labNumer
            // 
            this.labNumer.AutoSize = true;
            this.labNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNumer.Location = new System.Drawing.Point(696, 48);
            this.labNumer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNumer.Name = "labNumer";
            this.labNumer.Size = new System.Drawing.Size(110, 20);
            this.labNumer.TabIndex = 3;
            this.labNumer.Text = "Numer zęba";
            // 
            // labKolor
            // 
            this.labKolor.AutoSize = true;
            this.labKolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labKolor.Location = new System.Drawing.Point(1309, 48);
            this.labKolor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labKolor.Name = "labKolor";
            this.labKolor.Size = new System.Drawing.Size(48, 20);
            this.labKolor.TabIndex = 4;
            this.labKolor.Text = "Opis";
            // 
            // ZebyPrzycisk
            // 
            this.ZebyPrzycisk.Location = new System.Drawing.Point(864, 162);
            this.ZebyPrzycisk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ZebyPrzycisk.Name = "ZebyPrzycisk";
            this.ZebyPrzycisk.Size = new System.Drawing.Size(133, 28);
            this.ZebyPrzycisk.TabIndex = 7;
            this.ZebyPrzycisk.Text = "Ustaw";
            this.ZebyPrzycisk.UseVisualStyleBackColor = true;
            this.ZebyPrzycisk.Click += new System.EventHandler(this.Przycisk);
            // 
            // labCzesc
            // 
            this.labCzesc.AutoSize = true;
            this.labCzesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labCzesc.Location = new System.Drawing.Point(1019, 48);
            this.labCzesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCzesc.Name = "labCzesc";
            this.labCzesc.Size = new System.Drawing.Size(134, 20);
            this.labCzesc.TabIndex = 11;
            this.labCzesc.Text = "Fragment zęba";
            // 
            // KolorBox
            // 
            this.KolorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.KolorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.KolorBox.DropDownHeight = 75;
            this.KolorBox.FormattingEnabled = true;
            this.KolorBox.IntegralHeight = false;
            this.KolorBox.Items.AddRange(new object[] {
            "brak zęba (czarny)",
            "chirurgia (czerwony)",
            "dewitalizacja (zielony)",
            "do obserwacji (niebieski)",
            "ekstrakcja (fiołkowy)",
            "hemisekcja (cyjan)",
            "implant (brązowy)",
            "kiretaż otwarty (oliwkowy)",
            "kiretaż ręczny (łososiowy)",
            "konsultacja stomatologiczna (szary)",
            "korona pełnoceramiczna (indygo)",
            "korona porcelanowa na metalu (żółty)",
            "korona protetyczna obca (fioletowy)",
            "korona tymczasowa (złoty)",
            "leczenie endod (srebrny)",
            "most (turkusowy)",
            "mycie zęba-opłukiwanie (limonkowy) ",
            "opatrunek do kanału (magenta)",
            "opracowanie 1 kanału (pomarańczowy)",
            "piaskowanie (różowy)",
            "proteza akrylowa (fuksja)",
            "proteza szkieletowa (akwamaryna)",
            "próchnica głeboka (peru)",
            "skaling (morski)",
            "skaling ultradźwiękowy szczęki (karmazynowy)",
            "ubytek próchnicowy (beis)",
            "wypełnienie (bordo)",
            "wypełnienie amalgamatowe (moccasin)",
            "wypełnienie amalgamatowe obce (czekoladowy)",
            "wypełnienie glasjonomerowe (khaki)",
            "wypełnienie kanału (lawendowy)",
            "wypełnienie tymczasowe (cytrynowy)",
            "wypełnienie uv (tan)",
            "wypełnienie uv obce (pomidorowy)",
            "zdrowy (biały)",
            "znieczulenie (śliwkowy)",
            "znieczulenie nasiękowe (morska zieleń)",
            "znieczulenie przewodowe (chartreuse)"});
            this.KolorBox.Location = new System.Drawing.Point(1313, 73);
            this.KolorBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KolorBox.Name = "KolorBox";
            this.KolorBox.Size = new System.Drawing.Size(340, 24);
            this.KolorBox.TabIndex = 12;
            // 
            // CzescBox
            // 
            this.CzescBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CzescBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CzescBox.DropDownHeight = 75;
            this.CzescBox.FormattingEnabled = true;
            this.CzescBox.IntegralHeight = false;
            this.CzescBox.Items.AddRange(new object[] {
            "Środkowy fragment",
            "Dolny fragment",
            "Lewy fragment",
            "Górny fragment",
            "Prawy fragment ",
            "Lewy korzeń",
            "Środkowy korzeń",
            "Prawy korzeń"});
            this.CzescBox.Location = new System.Drawing.Point(1023, 73);
            this.CzescBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CzescBox.Name = "CzescBox";
            this.CzescBox.Size = new System.Drawing.Size(160, 24);
            this.CzescBox.TabIndex = 13;
            // 
            // NumerBox
            // 
            this.NumerBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NumerBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NumerBox.DropDownHeight = 75;
            this.NumerBox.FormattingEnabled = true;
            this.NumerBox.IntegralHeight = false;
            this.NumerBox.Location = new System.Drawing.Point(700, 73);
            this.NumerBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NumerBox.Name = "NumerBox";
            this.NumerBox.Size = new System.Drawing.Size(160, 24);
            this.NumerBox.TabIndex = 14;
            this.NumerBox.Text = "Od lewej do prawej";
            // 
            // RzadBox
            // 
            this.RzadBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.RzadBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RzadBox.DropDownHeight = 75;
            this.RzadBox.FormattingEnabled = true;
            this.RzadBox.IntegralHeight = false;
            this.RzadBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.RzadBox.Location = new System.Drawing.Point(385, 73);
            this.RzadBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RzadBox.Name = "RzadBox";
            this.RzadBox.Size = new System.Drawing.Size(160, 24);
            this.RzadBox.Sorted = true;
            this.RzadBox.TabIndex = 15;
            this.RzadBox.Text = "Od góry do dołu";
            this.RzadBox.SelectedIndexChanged += new System.EventHandler(this.comboZmien);
            // 
            // przelacznik
            // 
            this.przelacznik.Location = new System.Drawing.Point(160, 70);
            this.przelacznik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.przelacznik.Name = "przelacznik";
            this.przelacznik.Size = new System.Drawing.Size(113, 28);
            this.przelacznik.TabIndex = 16;
            this.przelacznik.Text = "Zmień diagram ";
            this.przelacznik.UseVisualStyleBackColor = true;
            this.przelacznik.Click += new System.EventHandler(this.przelacznik_Click);
            // 
            // buttonZakoncz
            // 
            this.buttonZakoncz.Location = new System.Drawing.Point(1531, 162);
            this.buttonZakoncz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZakoncz.Name = "buttonZakoncz";
            this.buttonZakoncz.Size = new System.Drawing.Size(123, 28);
            this.buttonZakoncz.TabIndex = 17;
            this.buttonZakoncz.Text = "Zakończ";
            this.buttonZakoncz.UseVisualStyleBackColor = true;
            this.buttonZakoncz.Click += new System.EventHandler(this.buttonZakoncz_Click);
            // 
            // lab11
            // 
            this.lab11.AutoSize = true;
            this.lab11.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab11.Location = new System.Drawing.Point(187, 209);
            this.lab11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab11.Name = "lab11";
            this.lab11.Size = new System.Drawing.Size(43, 32);
            this.lab11.TabIndex = 18;
            this.lab11.Text = "18";
            // 
            // lab12
            // 
            this.lab12.AutoSize = true;
            this.lab12.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab12.Location = new System.Drawing.Point(280, 209);
            this.lab12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab12.Name = "lab12";
            this.lab12.Size = new System.Drawing.Size(43, 32);
            this.lab12.TabIndex = 19;
            this.lab12.Text = "17";
            // 
            // lab13
            // 
            this.lab13.AutoSize = true;
            this.lab13.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab13.Location = new System.Drawing.Point(373, 209);
            this.lab13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab13.Name = "lab13";
            this.lab13.Size = new System.Drawing.Size(43, 32);
            this.lab13.TabIndex = 20;
            this.lab13.Text = "16";
            // 
            // lab14
            // 
            this.lab14.AutoSize = true;
            this.lab14.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab14.Location = new System.Drawing.Point(467, 209);
            this.lab14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab14.Name = "lab14";
            this.lab14.Size = new System.Drawing.Size(43, 32);
            this.lab14.TabIndex = 21;
            this.lab14.Text = "15";
            // 
            // lab15
            // 
            this.lab15.AutoSize = true;
            this.lab15.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab15.Location = new System.Drawing.Point(560, 209);
            this.lab15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab15.Name = "lab15";
            this.lab15.Size = new System.Drawing.Size(43, 32);
            this.lab15.TabIndex = 22;
            this.lab15.Text = "14";
            // 
            // lab16
            // 
            this.lab16.AutoSize = true;
            this.lab16.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab16.Location = new System.Drawing.Point(653, 209);
            this.lab16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab16.Name = "lab16";
            this.lab16.Size = new System.Drawing.Size(43, 32);
            this.lab16.TabIndex = 23;
            this.lab16.Text = "13";
            // 
            // lab17
            // 
            this.lab17.AutoSize = true;
            this.lab17.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab17.Location = new System.Drawing.Point(747, 209);
            this.lab17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab17.Name = "lab17";
            this.lab17.Size = new System.Drawing.Size(43, 32);
            this.lab17.TabIndex = 24;
            this.lab17.Text = "12";
            // 
            // lab18
            // 
            this.lab18.AutoSize = true;
            this.lab18.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab18.Location = new System.Drawing.Point(840, 209);
            this.lab18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab18.Name = "lab18";
            this.lab18.Size = new System.Drawing.Size(43, 32);
            this.lab18.TabIndex = 25;
            this.lab18.Text = "11";
            // 
            // lab19
            // 
            this.lab19.AutoSize = true;
            this.lab19.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab19.Location = new System.Drawing.Point(933, 209);
            this.lab19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab19.Name = "lab19";
            this.lab19.Size = new System.Drawing.Size(43, 32);
            this.lab19.TabIndex = 26;
            this.lab19.Text = "21";
            // 
            // lab110
            // 
            this.lab110.AutoSize = true;
            this.lab110.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab110.Location = new System.Drawing.Point(1027, 209);
            this.lab110.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab110.Name = "lab110";
            this.lab110.Size = new System.Drawing.Size(43, 32);
            this.lab110.TabIndex = 27;
            this.lab110.Text = "22";
            // 
            // lab111
            // 
            this.lab111.AutoSize = true;
            this.lab111.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab111.Location = new System.Drawing.Point(1120, 209);
            this.lab111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab111.Name = "lab111";
            this.lab111.Size = new System.Drawing.Size(43, 32);
            this.lab111.TabIndex = 28;
            this.lab111.Text = "23";
            // 
            // lab112
            // 
            this.lab112.AutoSize = true;
            this.lab112.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab112.Location = new System.Drawing.Point(1213, 209);
            this.lab112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab112.Name = "lab112";
            this.lab112.Size = new System.Drawing.Size(43, 32);
            this.lab112.TabIndex = 29;
            this.lab112.Text = "24";
            // 
            // lab113
            // 
            this.lab113.AutoSize = true;
            this.lab113.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab113.Location = new System.Drawing.Point(1307, 209);
            this.lab113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab113.Name = "lab113";
            this.lab113.Size = new System.Drawing.Size(43, 32);
            this.lab113.TabIndex = 30;
            this.lab113.Text = "25";
            // 
            // lab114
            // 
            this.lab114.AutoSize = true;
            this.lab114.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab114.Location = new System.Drawing.Point(1400, 209);
            this.lab114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab114.Name = "lab114";
            this.lab114.Size = new System.Drawing.Size(43, 32);
            this.lab114.TabIndex = 31;
            this.lab114.Text = "26";
            // 
            // lab115
            // 
            this.lab115.AutoSize = true;
            this.lab115.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab115.Location = new System.Drawing.Point(1493, 209);
            this.lab115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab115.Name = "lab115";
            this.lab115.Size = new System.Drawing.Size(43, 32);
            this.lab115.TabIndex = 32;
            this.lab115.Text = "27";
            // 
            // lab116
            // 
            this.lab116.AutoSize = true;
            this.lab116.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab116.Location = new System.Drawing.Point(1587, 209);
            this.lab116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab116.Name = "lab116";
            this.lab116.Size = new System.Drawing.Size(43, 32);
            this.lab116.TabIndex = 33;
            this.lab116.Text = "28";
            // 
            // lab21
            // 
            this.lab21.AutoSize = true;
            this.lab21.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab21.Location = new System.Drawing.Point(187, 687);
            this.lab21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab21.Name = "lab21";
            this.lab21.Size = new System.Drawing.Size(43, 32);
            this.lab21.TabIndex = 34;
            this.lab21.Text = "48";
            // 
            // lab22
            // 
            this.lab22.AutoSize = true;
            this.lab22.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab22.Location = new System.Drawing.Point(280, 687);
            this.lab22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab22.Name = "lab22";
            this.lab22.Size = new System.Drawing.Size(43, 32);
            this.lab22.TabIndex = 35;
            this.lab22.Text = "47";
            // 
            // lab23
            // 
            this.lab23.AutoSize = true;
            this.lab23.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab23.Location = new System.Drawing.Point(373, 687);
            this.lab23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab23.Name = "lab23";
            this.lab23.Size = new System.Drawing.Size(43, 32);
            this.lab23.TabIndex = 46;
            this.lab23.Text = "46";
            // 
            // lab24
            // 
            this.lab24.AutoSize = true;
            this.lab24.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab24.Location = new System.Drawing.Point(467, 687);
            this.lab24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab24.Name = "lab24";
            this.lab24.Size = new System.Drawing.Size(43, 32);
            this.lab24.TabIndex = 47;
            this.lab24.Text = "45";
            // 
            // lab25
            // 
            this.lab25.AutoSize = true;
            this.lab25.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab25.Location = new System.Drawing.Point(560, 687);
            this.lab25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab25.Name = "lab25";
            this.lab25.Size = new System.Drawing.Size(43, 32);
            this.lab25.TabIndex = 48;
            this.lab25.Text = "44";
            // 
            // lab26
            // 
            this.lab26.AutoSize = true;
            this.lab26.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab26.Location = new System.Drawing.Point(653, 687);
            this.lab26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab26.Name = "lab26";
            this.lab26.Size = new System.Drawing.Size(43, 32);
            this.lab26.TabIndex = 49;
            this.lab26.Text = "43";
            // 
            // lab27
            // 
            this.lab27.AutoSize = true;
            this.lab27.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab27.Location = new System.Drawing.Point(747, 687);
            this.lab27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab27.Name = "lab27";
            this.lab27.Size = new System.Drawing.Size(43, 32);
            this.lab27.TabIndex = 50;
            this.lab27.Text = "42";
            // 
            // lab28
            // 
            this.lab28.AutoSize = true;
            this.lab28.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab28.Location = new System.Drawing.Point(840, 687);
            this.lab28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab28.Name = "lab28";
            this.lab28.Size = new System.Drawing.Size(43, 32);
            this.lab28.TabIndex = 51;
            this.lab28.Text = "41";
            // 
            // lab29
            // 
            this.lab29.AutoSize = true;
            this.lab29.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab29.Location = new System.Drawing.Point(933, 687);
            this.lab29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab29.Name = "lab29";
            this.lab29.Size = new System.Drawing.Size(43, 32);
            this.lab29.TabIndex = 52;
            this.lab29.Text = "31";
            // 
            // lab210
            // 
            this.lab210.AutoSize = true;
            this.lab210.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab210.Location = new System.Drawing.Point(1027, 687);
            this.lab210.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab210.Name = "lab210";
            this.lab210.Size = new System.Drawing.Size(43, 32);
            this.lab210.TabIndex = 53;
            this.lab210.Text = "32";
            // 
            // lab211
            // 
            this.lab211.AutoSize = true;
            this.lab211.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab211.Location = new System.Drawing.Point(1120, 687);
            this.lab211.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab211.Name = "lab211";
            this.lab211.Size = new System.Drawing.Size(43, 32);
            this.lab211.TabIndex = 54;
            this.lab211.Text = "33";
            // 
            // lab212
            // 
            this.lab212.AutoSize = true;
            this.lab212.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab212.Location = new System.Drawing.Point(1213, 687);
            this.lab212.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab212.Name = "lab212";
            this.lab212.Size = new System.Drawing.Size(43, 32);
            this.lab212.TabIndex = 55;
            this.lab212.Text = "34";
            // 
            // lab213
            // 
            this.lab213.AutoSize = true;
            this.lab213.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab213.Location = new System.Drawing.Point(1307, 687);
            this.lab213.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab213.Name = "lab213";
            this.lab213.Size = new System.Drawing.Size(43, 32);
            this.lab213.TabIndex = 56;
            this.lab213.Text = "35";
            // 
            // lab214
            // 
            this.lab214.AutoSize = true;
            this.lab214.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab214.Location = new System.Drawing.Point(1400, 687);
            this.lab214.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab214.Name = "lab214";
            this.lab214.Size = new System.Drawing.Size(43, 32);
            this.lab214.TabIndex = 57;
            this.lab214.Text = "36";
            // 
            // lab215
            // 
            this.lab215.AutoSize = true;
            this.lab215.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab215.Location = new System.Drawing.Point(1493, 687);
            this.lab215.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab215.Name = "lab215";
            this.lab215.Size = new System.Drawing.Size(43, 32);
            this.lab215.TabIndex = 58;
            this.lab215.Text = "37";
            // 
            // lab216
            // 
            this.lab216.AutoSize = true;
            this.lab216.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab216.Location = new System.Drawing.Point(1587, 687);
            this.lab216.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab216.Name = "lab216";
            this.lab216.Size = new System.Drawing.Size(43, 32);
            this.lab216.TabIndex = 59;
            this.lab216.Text = "38";
            // 
            // labRzad1
            // 
            this.labRzad1.AutoSize = true;
            this.labRzad1.Font = new System.Drawing.Font("Malgun Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRzad1.Location = new System.Drawing.Point(69, 308);
            this.labRzad1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRzad1.Name = "labRzad1";
            this.labRzad1.Size = new System.Drawing.Size(70, 81);
            this.labRzad1.TabIndex = 60;
            this.labRzad1.Text = "1";
            // 
            // labRzad2
            // 
            this.labRzad2.AutoSize = true;
            this.labRzad2.Font = new System.Drawing.Font("Malgun Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRzad2.Location = new System.Drawing.Point(69, 535);
            this.labRzad2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRzad2.Name = "labRzad2";
            this.labRzad2.Size = new System.Drawing.Size(70, 81);
            this.labRzad2.TabIndex = 61;
            this.labRzad2.Text = "2";
            // 
            // FormDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.labRzad2);
            this.Controls.Add(this.labRzad1);
            this.Controls.Add(this.lab216);
            this.Controls.Add(this.lab215);
            this.Controls.Add(this.lab214);
            this.Controls.Add(this.lab213);
            this.Controls.Add(this.lab212);
            this.Controls.Add(this.lab211);
            this.Controls.Add(this.lab210);
            this.Controls.Add(this.lab29);
            this.Controls.Add(this.lab28);
            this.Controls.Add(this.lab27);
            this.Controls.Add(this.lab26);
            this.Controls.Add(this.lab25);
            this.Controls.Add(this.lab24);
            this.Controls.Add(this.lab23);
            this.Controls.Add(this.lab22);
            this.Controls.Add(this.lab21);
            this.Controls.Add(this.lab116);
            this.Controls.Add(this.lab115);
            this.Controls.Add(this.lab114);
            this.Controls.Add(this.lab113);
            this.Controls.Add(this.lab112);
            this.Controls.Add(this.lab111);
            this.Controls.Add(this.lab110);
            this.Controls.Add(this.lab19);
            this.Controls.Add(this.lab18);
            this.Controls.Add(this.lab17);
            this.Controls.Add(this.lab16);
            this.Controls.Add(this.lab15);
            this.Controls.Add(this.lab14);
            this.Controls.Add(this.lab13);
            this.Controls.Add(this.lab12);
            this.Controls.Add(this.lab11);
            this.Controls.Add(this.buttonZakoncz);
            this.Controls.Add(this.przelacznik);
            this.Controls.Add(this.RzadBox);
            this.Controls.Add(this.NumerBox);
            this.Controls.Add(this.CzescBox);
            this.Controls.Add(this.KolorBox);
            this.Controls.Add(this.labCzesc);
            this.Controls.Add(this.ZebyPrzycisk);
            this.Controls.Add(this.labKolor);
            this.Controls.Add(this.labNumer);
            this.Controls.Add(this.labRzad);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDiagram";
            this.Text = "Diagram zębowy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDiagram_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label labRzad;
        private System.Windows.Forms.Label labNumer;
        private System.Windows.Forms.Label labKolor;
        private System.Windows.Forms.Button ZebyPrzycisk;
        private System.Windows.Forms.Label labCzesc;
        private System.Windows.Forms.ComboBox KolorBox;
        private System.Windows.Forms.ComboBox CzescBox;
        private System.Windows.Forms.ComboBox NumerBox;
        private System.Windows.Forms.ComboBox RzadBox;
        private System.Windows.Forms.Button przelacznik;
        private System.Windows.Forms.Button buttonZakoncz;
        private System.Windows.Forms.Label lab11;
        private System.Windows.Forms.Label lab12;
        private System.Windows.Forms.Label lab13;
        private System.Windows.Forms.Label lab14;
        private System.Windows.Forms.Label lab15;
        private System.Windows.Forms.Label lab16;
        private System.Windows.Forms.Label lab17;
        private System.Windows.Forms.Label lab18;
        private System.Windows.Forms.Label lab19;
        private System.Windows.Forms.Label lab110;
        private System.Windows.Forms.Label lab111;
        private System.Windows.Forms.Label lab112;
        private System.Windows.Forms.Label lab113;
        private System.Windows.Forms.Label lab114;
        private System.Windows.Forms.Label lab115;
        private System.Windows.Forms.Label lab116;
        private System.Windows.Forms.Label lab21;
        private System.Windows.Forms.Label lab22;
        private System.Windows.Forms.Label lab23;
        private System.Windows.Forms.Label lab24;
        private System.Windows.Forms.Label lab25;
        private System.Windows.Forms.Label lab26;
        private System.Windows.Forms.Label lab27;
        private System.Windows.Forms.Label lab28;
        private System.Windows.Forms.Label lab29;
        private System.Windows.Forms.Label lab210;
        private System.Windows.Forms.Label lab211;
        private System.Windows.Forms.Label lab212;
        private System.Windows.Forms.Label lab213;
        private System.Windows.Forms.Label lab214;
        private System.Windows.Forms.Label lab215;
        private System.Windows.Forms.Label lab216;
        private System.Windows.Forms.Label labRzad1;
        private System.Windows.Forms.Label labRzad2;
    }
}

