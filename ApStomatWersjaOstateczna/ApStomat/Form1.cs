using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AplikacjaStomatologiczna;
using System.Linq.Expressions;
using ApStomat;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace AplikacjaStomatologiczna
{
    public partial class Form1 : Form
    {
        private int kolumna_wyszukiwania_DGVKartoteka;
        Point staraLokPanelKonfOdswiez;
        private static int szerPolDGVGraf;
        public static int szerokoscKolumnyDGVGrafik
        {
            get { return 19; } 
        }
        public DateTime GodzinaOtwarcia { get { return bufor.GodzinaRozpoczeciaPracy; }  }
        public DateTime GodzinaZamkniecia { get { return bufor.GodzinaZakonczeniaPracy; } }

        List<Control> panelTerminarza, panelKartoteki;
        internal List<Pacjent> pacjenci;
        private List<Pacjent> pacjenciUsunieci;
        internal BuforZmian bufor;
        private ZapelniaczDGV grafik;
        bool pierwszeUruchomienie;
        public string KatalogGlowny
        {
            get { return Path.GetPathRoot(Environment.SystemDirectory) + @"\Users\" + Environment.UserName + @"\aplikacjaStomatologiczna"; }
        }

        internal void DoubleOdswiez()
        {
            buttonDzienPoz_Click(this, null);
            buttonDzienWcz_Click(this, null);
        }

        private string haslo;
        public string Haslo { get { return haslo; } }
        public Form1()
        {
            InitializeComponent();
            groupBoxPacjenci.Controls.Add(radioButtonPacj);
            groupBoxPacjenci.Controls.Add(radioButtonPacjUs);
            //etap 1 - dodanie do list kartoteki i terminarza ich obiektów
            panelTerminarza = new List<Control>();
            panelKartoteki = new List<Control>();
            panelTerminarza.Add(dataGridViewGrafik);
            panelTerminarza.Add(dateTimePicker1);
            panelTerminarza.Add(buttonDzienWcz);
            panelTerminarza.Add(buttonDzienPoz);
            panelTerminarza.Add(dateTimePicker2);
            panelTerminarza.Add(comboBoxGodzOd);
            panelTerminarza.Add(comboBoxMinOd);
            panelTerminarza.Add(comboBoxGodzDo);
            panelTerminarza.Add(comboBoxMinDo);
            panelTerminarza.Add(buttonZapisz);
            panelTerminarza.Add(buttonPokaz);
            panelTerminarza.Add(buttonUsun);
            panelTerminarza.Add(labelGodzRoz);
            panelTerminarza.Add(labelGodzZak);
            staraLokPanelKonfOdswiez = panelKonfigOdswiez.Location;

            panelKartoteki.Add(dataGridViewKartLista);
            panelKartoteki.Add(buttonKartEdytuj);
            panelKartoteki.Add(buttonKartNowy);
            panelKartoteki.Add(buttonKartPokaz);
            panelKartoteki.Add(buttonKartUsun);
            panelKartoteki.Add(groupBoxPacjenci);
            panelKartoteki.Add(radioButtonPacj);
            panelKartoteki.Add(radioButtonPacjUs);
            panelKartoteki.Add(buttonKartPrzywroc);
            panelKartoteki.Add(buttonNastepny);
            panelKartoteki.Add(textBoxWyszukaj);
            panelKartoteki.Add(labelWyszukaj);
            panelKartoteki.Add(flowLayoutPanel1);
            foreach( Control elementKartoteki in panelKartoteki )
            {
                elementKartoteki.Visible = false;
            }
            kolumna_wyszukiwania_DGVKartoteka = 2;

            //etap 2 - inicjalizacja list pacjentów
            pacjenci = new List<Pacjent>();
            pacjenciUsunieci = new List<Pacjent>();
            //etap 3 - jeśli pierwszy raz uruchamiamy program, to tworzymy strukturę plików
            if (!Directory.Exists(KatalogGlowny))
            {
                zbudujStrukturePlikow(KatalogGlowny);
            }
            //etap 4 - wczytanie danych do deszyfracji plików
            byte[] aesKey = null;
            byte[] aesIV = null;
            BinaryReader aesBR = new BinaryReader(File.Open(KatalogGlowny + @"\plikiKonfiguracyjne\bit", FileMode.Open));
            int keyLength = aesBR.ReadInt32();
            aesKey = aesBR.ReadBytes(keyLength);
            int vectLength = aesBR.ReadInt32();
            aesIV = aesBR.ReadBytes(vectLength);
            Cipher.Key = aesKey;
            Cipher.Iv = aesIV;
            aesBR.Close();

            //etap 5 - wczytanie hasła - jeśli hasło to abcdef, to znaczy, że ono hasło jeszcze nie zostało ustawione
            BinaryReader brHaslo = new BinaryReader(File.Open(KatalogGlowny + @"\plikiKonfiguracyjne\i", FileMode.Open));
            string hasloZPliku = Cipher.ReadString(brHaslo);
            brHaslo.Close();
            string hasloZPlikuOdszyfrowane = hasloZPliku;
            haslo = hasloZPlikuOdszyfrowane;
            if(hasloZPlikuOdszyfrowane=="abcdef")
            {
                pierwszeUruchomienie = true;
            }

            

            //etap 6 - wczytanie pacjentów
            Pacjent.wczytajLicznik(KatalogGlowny + @"\plikiKonfiguracyjne\licznikPacjenta");
            string[] listaKatalogowPacjentow = Directory.GetDirectories(KatalogGlowny + @"\pacjenci");

            foreach (string katPacjenta in listaKatalogowPacjentow)
            {
                Pacjent pacpac = new Pacjent(katPacjenta);
                pacjenci.Add(pacpac);
            }
            string[] listaKatalogowPacjentowUsunietych = Directory.GetDirectories(KatalogGlowny + @"\pacjenciUsunieci");
            foreach (string katPacjenta in listaKatalogowPacjentowUsunietych)
            {
                Pacjent pacpac = new Pacjent(katPacjenta);
                pacjenciUsunieci.Add(pacpac);
            }



            //etap 7 - wczytanie danych do utworzenia bufora zmian i utworzenie obkietu tej klasy
            List<int> daneKonfiguracyjneBufora = BuforZmian.WczytajGodzinyPracyIIlociDni(KatalogGlowny + @"\plikiKonfiguracyjne\buforZmian");
            DateTime godzOtw = new DateTime(2000, 1, 1, daneKonfiguracyjneBufora.ElementAt(0), daneKonfiguracyjneBufora.ElementAt(1), 0);
            DateTime godzZam = new DateTime(2000, 1, 1, daneKonfiguracyjneBufora.ElementAt(2), daneKonfiguracyjneBufora.ElementAt(3), 0);
            bufor = new BuforZmian(pacjenci, pacjenciUsunieci, daneKonfiguracyjneBufora.ElementAt(4), daneKonfiguracyjneBufora.ElementAt(5),
                godzOtw, godzZam, 15);
            DateTime teraz = DateTime.Now;
            DateTime Dzis = teraz.Date;


            //etap 8 - wyłączenie niektórych funkcjonalności obiektów DataGridView tworzących terminarz i okno kartoteki pacjentów
            dataGridViewKartLista.AllowUserToAddRows = false;
            dataGridViewKartLista.AllowUserToDeleteRows = false;
            dataGridViewKartLista.AllowUserToOrderColumns = false;
            dataGridViewGrafik.MultiSelect = false;
            dataGridViewKartLista.MultiSelect = false;
            dataGridViewKartLista.AllowUserToResizeRows = false;
            dataGridViewGrafik.AllowUserToAddRows = false;
            dataGridViewGrafik.AllowUserToDeleteRows = false;
            dataGridViewGrafik.AllowUserToOrderColumns = false;
            dataGridViewGrafik.AllowUserToResizeRows = false;
            dataGridViewGrafik.AllowDrop = false;
            szerPolDGVGraf = dataGridViewGrafik.Columns[1].Width;

            //etap 9 - utworzenie obiektu zapełniaczDGV
            grafik = new ZapelniaczDGV(Dzis, bufor, dataGridViewGrafik);
            //etap 10 - przygotowanie pozostałych obiektów interfejsu do pracy
            for(int i=0;i<24;i++)
            {
                string godzinaNapis = Convert.ToString(i);
                if(godzinaNapis.Length==1)
                {
                    godzinaNapis = "0" + godzinaNapis;
                }
                comboBoxGodzOd.Items.Add(godzinaNapis);
                comboBoxGodzDo.Items.Add(godzinaNapis);
            }
            comboBoxMinOd.Items.Add("00");
            comboBoxMinOd.Items.Add("15");
            comboBoxMinOd.Items.Add("30");
            comboBoxMinOd.Items.Add("45");
            comboBoxMinDo.Items.Add("00");
            comboBoxMinDo.Items.Add("15");
            comboBoxMinDo.Items.Add("30");
            comboBoxMinDo.Items.Add("45");
            comboBoxGodzOd.SelectedIndex = 0;
            comboBoxMinOd.SelectedIndex = 0;
            comboBoxGodzDo.SelectedIndex = 0;
            comboBoxMinDo.SelectedIndex = 0;
            comboBoxGodzOd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxMinOd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxGodzDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxMinDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            radioButtonPacj.Checked = true;
        }

        internal void PokazKartoteke()
        {
            buttonKartoteka_Click(this, null);
            //odświeżanie kartoteki

        }
        internal void pobierzPacjenta(Pacjent pacpac)
        {
            //funkcja wywoływana w formularzu FormPacjent - przy tworzeniu nowego pacjenta
            pacjenci.Add(pacpac);
            odswiezKartoteke();
        }

        internal void pobierzHaslo(string text)
        {
            //funkcja wywoływana przy tworzeniu lub zmianie hasła
            BinaryWriter bw = new BinaryWriter(File.Open(KatalogGlowny + @"\plikiKonfiguracyjne\i", FileMode.Truncate));
            Cipher.Write(bw, text);
            bw.Close();
            haslo = text;    
        }

        //funkcje odświeżające interfejs
        internal void odswiez()
        {
            grafik.zapelnijDGV();
            odswiezKartoteke();
        }
        internal void odswiezKartoteke()
        {
            dataGridViewKartLista.Rows.Clear();
            if (radioButtonPacj.Checked==true)
            {
                foreach (Pacjent p in pacjenci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            }
            else
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            } 

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(pierwszeUruchomienie)
            {
                this.Enabled = false;
                FormTworzenieHasla fth = new FormTworzenieHasla(this);
                // tworzymy nowe hasło - formularz główny zostaje zablokowany przez powyższy formularz
                //formularz główny zostanie odblokwany po utworzeniu hasła wtedy
                fth.Show();
                fth.BringToFront();

            }
            else
            {
                //wczytywanie hasła
                BinaryReader br = new BinaryReader(File.Open(KatalogGlowny + @"\plikiKonfiguracyjne\i", FileMode.Open));
                haslo = Cipher.ReadString(br);
                br.Close();

                
                FormPobierzHaslo fph = new FormPobierzHaslo(this);
                //formularz pobrania hasła - blokuje formularz główny do momentu pobrania hasła
                dataGridViewGrafik.Visible = false; //grafik niewidoczny, by przed autoryzacją przez podanie hasła nie dało się go przeczytać
                fph.Show();
                
                fph.BringToFront();
            }
        }
        internal void przywrocWidocznoscDGVGrafik()
        {
            //metoda wywoływana przy poprawnym podaniu hasła
            dataGridViewGrafik.Visible = true;
        }

        private void zbudujStrukturePlikow(string katalogGlowny)
        {
            try
            {

                DirectoryInfo di = Directory.CreateDirectory(katalogGlowny);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                //utwórz katalogi
                Directory.CreateDirectory(katalogGlowny + @"\plikiKonfiguracyjne");
                Directory.CreateDirectory(katalogGlowny + @"\pacjenci");
                Directory.CreateDirectory(katalogGlowny + @"\pacjenciUsunieci");
                Directory.CreateDirectory(katalogGlowny + @"\zmiany");
                FileStream fs = File.Create(katalogGlowny + @"\plikiKonfiguracyjne\i");
                fs.Close();
                //utwórz pliki potrzebne do szyfrowania plików
                BinaryWriter bwAes = new BinaryWriter(File.Open(katalogGlowny + @"\plikiKonfiguracyjne\bit", FileMode.Create));
                Aes myAes = Aes.Create();
                Cipher.Key = myAes.Key;
                Cipher.Iv = myAes.IV;
                bwAes.Write(Buffer.ByteLength(Cipher.Key)); 
                bwAes.Write(Cipher.Key);
                bwAes.Write(Buffer.ByteLength(Cipher.Iv)); 
                bwAes.Write(Cipher.Iv);
                bwAes.Close();

                //utwórz plik z hasłem
                BinaryWriter bwHaslo = new BinaryWriter(File.Open(katalogGlowny + @"\plikiKonfiguracyjne\i", FileMode.Open));
                Cipher.Write(bwHaslo, "abcdef");
                bwHaslo.Close();
                //utwórz plik przechowujący informacje o zmiennych statycznych klasy pacjent - licznik id pacjenta i licznik zdjęć rentgenowskich
                BinaryWriter bw = new BinaryWriter(File.Open(katalogGlowny + @"\plikiKonfiguracyjne\licznikPacjenta", FileMode.Create));
                bw.Write(0);
                bw.Write(0);
                bw.Close();
                //utwórz plik konfiguracyjny bufora zmian
                bw = new BinaryWriter(File.Open(katalogGlowny + @"\plikiKonfiguracyjne\buforZmian", FileMode.Create));
                bw.Write(8); //godzina rozpoczęcia
                bw.Write(0); //minuta rozpoczęcia
                bw.Write(16); //godzina zakończenia
                bw.Write(0); //minuta zakończenia
                bw.Write(20); //ilość wczytywanych dni wstecz
                bw.Write(68); //ilość wczytywanych dni naprzód
                bw.Close();

                
            }
            catch (Exception e)
            {
                //jeśli coś się nie udało to skasuj całą strukturę plików
                if (Directory.Exists(katalogGlowny))
                {
                    Directory.Delete(katalogGlowny, true);
                    this.Close();
                }
            }

            
        }

        internal void zapiszPacjentaDoPliku(Pacjent przekazanyPacjent)
        {
            string sciezka = "";
            foreach (Pacjent pacpac in pacjenci)
            {
                if(przekazanyPacjent.Id == pacpac.Id)
                {
                    sciezka = KatalogGlowny + @"\pacjenci\" + pacpac.Id.ToString();
                    break;
                }
            }
            if(sciezka=="")
            {
                foreach(Pacjent pacpac in pacjenciUsunieci)
                {
                    if(pacpac.Id == przekazanyPacjent.Id)
                    {
                        sciezka = KatalogGlowny + @"\pacjenciUsunieci\" + pacpac.Id.ToString();
                        break;
                    }
                }
            }
            if(sciezka!="")
            {
                przekazanyPacjent.zapiszPacjenta(sciezka);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZapiszPacjentowZmodyfikowanych(pacjenci, KatalogGlowny + @"\pacjenci");
            ZapiszPacjentowZmodyfikowanych(pacjenciUsunieci, KatalogGlowny + @"\pacjenciUsunieci");
            Pacjent.ZapiszDaneKonfiguracyjne(KatalogGlowny + @"\plikiKonfiguracyjne");
            bufor.ZapiszDaneKonfiguracyjne(KatalogGlowny + @"\plikiKonfiguracyjne");
            bufor.ZapiszZmiany();
        }

        private void ZapiszPacjentowZmodyfikowanych(List<Pacjent> listaPacjentow, string sciezkaKataloguPacjentow)
        {
            foreach (Pacjent pacpac in listaPacjentow)
            {
                if (pacpac.Touched)
                {
                    string nazwaFoderuPacjenta = pacpac.NazwaFolderu;
                    pacpac.zapiszPacjenta(sciezkaKataloguPacjentow + @"\" + nazwaFoderuPacjenta);
                }

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataZDatePicker = dateTimePicker1.Value;
            grafik.pokazDzien(dataZDatePicker);
        }

        private void buttonDzienWcz_Click(object sender, EventArgs e)
        {
            grafik.dzienWczesniej();
        }

        private void buttonDzienPoz_Click(object sender, EventArgs e)
        {
            grafik.dzienPozniej();
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            DateTime teraz = DateTime.Now;
            DateTime dzis = new DateTime(teraz.Year, teraz.Month, teraz.Day);

            DateTime dataWizyty;
            int godzinaOd;
            int minutaOd;
            int godzinaDo;
            int minutaDo;
            try
            {
                //walidacja danych
                DateTime d= dateTimePicker2.Value;
                dataWizyty = new DateTime(d.Year, d.Month, d.Day);
                godzinaOd = comboBoxGodzOd.SelectedIndex;
                minutaOd = comboBoxMinOd.SelectedIndex * 15;
                godzinaDo = comboBoxGodzDo.SelectedIndex;
                minutaDo = comboBoxMinDo.SelectedIndex * 15;
            }
            catch(Exception e1)
            {
                return;
            }
            if(DateTime.Compare(dzis,dataWizyty)>0 )
            {
                MessageBox.Show("Data wizyty nie może być wcześniejsza niż "+String.Format("{0:yyyy/MM/dd}", dzis), "Niepoprawne dane wizyty", MessageBoxButtons.OK);
                return;
            }
            //walidacja danych - utworzenie obiektów DateTime odpowiadających początkowi i końcu wizyty
            DateTime godzOd = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaOd, minutaOd,0);
            DateTime godzDo = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaDo, minutaDo, 0);
            if( DateTime.Compare(godzOd,godzDo)>=0 )
            {
                MessageBox.Show("Godzina zakończenia wizyty musi być późniejsza niż godzina rozpoczęcia", "Niepoprawne dane wizyty", MessageBoxButtons.OK);
                return;
            }
            //sprawdzenie czy nie ma kolizji z inną wizytą
            if(!bufor.MoznaZapisacNaWizyte(dataWizyty,dataWizyty,godzinaOd,minutaOd,godzinaDo,minutaDo))
            {
                MessageBox.Show("Ten termin pokrywa się czasowo z innym terminem", "Kolizja wizyty", MessageBoxButtons.OK);
                return;
            }
            //walidacja pomyślna - uruchom formularz zapisu na wizytę
            FormZapis fZU = new FormZapis(godzOd, godzDo, pacjenci, bufor, this, true);
            //this.Enabled = false; - zablokowanie formularza głównego w formularzu zapisu
        }

        private void buttonPokaz_Click(object sender, EventArgs e)
        {
            DateTime teraz = DateTime.Now;
            DateTime dzis = new DateTime(teraz.Year, teraz.Month, teraz.Day);

            DateTime dataWizyty;
            int godzinaOd;
            int minutaOd;
            int godzinaDo;
            int minutaDo;
            try
            {
                //walidacja
                DateTime d = dateTimePicker2.Value;
                dataWizyty = new DateTime(d.Year, d.Month, d.Day);
                godzinaOd = comboBoxGodzOd.SelectedIndex;
                minutaOd = comboBoxMinOd.SelectedIndex * 15;
                godzinaDo = comboBoxGodzDo.SelectedIndex;
                minutaDo = comboBoxMinDo.SelectedIndex * 15;
            }
            catch (Exception e1)
            {
                return;
            }
            
            DateTime godzOd = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaOd, minutaOd, 0);
            DateTime godzDo = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaDo, minutaDo, 0);
            if (DateTime.Compare(godzOd, godzDo) >= 0)
            {
                MessageBox.Show("Godzina zakończenia wizyty musi być późniejsza niż godzina rozpoczęcia", "Niepoprawne dane wizyty", MessageBoxButtons.OK);
                return;
            }

            Wizyta w = bufor.ZnajdzWizyte(dataWizyty, godzOd, godzDo);
            if(w == null)
            {
                MessageBox.Show("Nie ma zapisanej na te godziny wizyty", "Niepoprawne dane wizyty", MessageBoxButtons.OK);
                return;
            }
            FormZapis fZU = new FormZapis(this, w, false);
            //this.Enabled = false; - zablokowanie formularza głównego w formularzu zapisu

        }

        private void buttonTerminarz_Click(object sender, EventArgs e)
        {
            foreach(Control elementTerminarza in panelTerminarza)
            {
                elementTerminarza.Visible = true;
            }
            foreach(Control elementKartoteki in panelKartoteki)
            {
                elementKartoteki.Visible = false;
            }
            //przemieść przyciski odśwież i konfiguracja
            panelKonfigOdswiez.Location = staraLokPanelKonfOdswiez;
        }

        private void buttonKartoteka_Click(object sender, EventArgs e)
        {
            foreach (Control elementTerminarza in panelTerminarza)
            {
                elementTerminarza.Visible = false;
            }
            foreach (Control elementKartoteki in panelKartoteki)
            {
                elementKartoteki.Visible = true;
            }
            //przemieść przyciski odśwież i konfiguracja
            panelKonfigOdswiez.Location = new Point(buttonKartPrzywroc.Location.X,
                                             buttonKartPrzywroc.Location.Y - 2 - panelKonfigOdswiez.Size.Height);

            dataGridViewKartLista.Rows.Clear();
            if (radioButtonPacj.Checked==true)
            {
                foreach (Pacjent p in pacjenci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            }
            else
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            }
        }

        private void buttonKartNowy_Click(object sender, EventArgs e)
        {
            FormPacjent fP = new FormPacjent(this);
            //this.TopMost = false;
            //fP.TopMost = false; //instrukcje wykonane w konstruktorze formularza FormPacjent
            //this.Enabled = false;
            fP.Show();
        }

       

        private void buttonKartEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridViewKartLista.SelectedCells.Count == 0)
            {
                return;
            }
            int id_row_idx = dataGridViewKartLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridViewKartLista.Rows[id_row_idx].Cells[0].Value.ToString());
            bool znalezionoPacjenta = false;
            Pacjent pacpac=null;
            foreach(Pacjent p in pacjenci)
            {
                if(p.Id == id)
                {
                    pacpac = p;
                    znalezionoPacjenta = true;
                    break;
                }
            }
            if(!znalezionoPacjenta)
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    if (p.Id == id)
                    {
                        pacpac = p;
                        znalezionoPacjenta = true;
                        break;
                    }
                }

            }
            if(!znalezionoPacjenta)
            {
                MessageBox.Show("Nie ma w bazie pacjenta o podanym id", "Błąd wyszukiwania", MessageBoxButtons.OK);
                return;
            }
            FormPacjentEditShow fPES = new FormPacjentEditShow(pacpac, this);

        }

        private void buttonKartPokaz_Click(object sender, EventArgs e)
        {
            if (dataGridViewKartLista.SelectedCells.Count == 0)
            {
                return;
            }
            int id_row_idx = dataGridViewKartLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridViewKartLista.Rows[id_row_idx].Cells[0].Value.ToString());
            bool znalezionoPacjenta = false;
            Pacjent pacpac = null;
            foreach (Pacjent p in pacjenci)
            {
                if (p.Id == id)
                {
                    pacpac = p;
                    znalezionoPacjenta = true;
                    break;
                }
            }
            if (!znalezionoPacjenta)
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    if (p.Id == id)
                    {
                        pacpac = p;
                        znalezionoPacjenta = true;
                        break;
                    }
                }

            }
            if (!znalezionoPacjenta)
            {
                MessageBox.Show("Nie ma w bazie pacjenta o podanym id", "Błąd wyszukiwania", MessageBoxButtons.OK);
                return;
            }
            FormPacjentEditShow fPES = new FormPacjentEditShow(pacpac, this, 1);
        }

        private void buttonKartUsun_Click(object sender, EventArgs e)
        {
            if (dataGridViewKartLista.SelectedCells.Count == 0)
            {
                return;
            }
            int id_row_idx = dataGridViewKartLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridViewKartLista.Rows[id_row_idx].Cells[0].Value.ToString());
            bool znalezionoPacjenta = false;
            Pacjent pacpac = null;
            foreach (Pacjent p in pacjenci)
            {
                if (p.Id == id)
                {
                    pacpac = p;
                    znalezionoPacjenta = true;
                    break;
                }
            }
            if (!znalezionoPacjenta)
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    if (p.Id == id)
                    {
                        pacpac = p;
                        znalezionoPacjenta = true;
                        break;
                    }
                }

            }
            if(!znalezionoPacjenta)
            {
                MessageBox.Show("Brak pacjenta o takim id w bazie", "Niepoprawne dane", MessageBoxButtons.OK);
                return;
            }
            this.UsunPacjenta(pacpac);
            odswiez();
        }

        private void UsunPacjenta(Pacjent pacpac)
       {
            List<KluczWizyty> wizytyPacjentaUsuwanego = pacpac.getKluczeWizyt();
            if(wizytyPacjentaUsuwanego.Count==0)
            {
                //pacjent nie ma żadnych wizyt - usuń permanentie
                if(Directory.Exists(KatalogGlowny+@"\pacjenci\"+ Convert.ToString( pacpac.Id)))
                {
                    Directory.Delete(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacpac.Id), true);
                }
                else if(Directory.Exists(KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacpac.Id)))
                {
                    Directory.Delete(KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacpac.Id), true);
                }
            foreach(Pacjent p in pacjenci)
                {
                    if(pacpac.Id == p.Id)
                    {
                        pacjenci.Remove(p);
                        return;
                    }
                }
            foreach (Pacjent p in pacjenciUsunieci)
                {
                    if (pacpac.Id == p.Id)
                    {
                        pacjenciUsunieci.Remove(p);
                        return;
                    }
                }
            }
            else
            {
                //pacjent ma jakieś wizyty - przenieś go pacjentów usuniętych
                bool pacZnaleziony = false;
                foreach (Pacjent p in pacjenci)
                {
                    if (pacpac.Id == p.Id)
                    {
                        pacjenci.Remove(p);
                        pacZnaleziony = true;
                        break;
                    }
                }
                if(!pacZnaleziony)
                {
                    MessageBox.Show("Brak pacjenta o podannym id w bazie", "Niewłaściwe id", MessageBoxButtons.OK);
                    return;
                }
                pacjenciUsunieci.Add(pacpac);
                pacpac.setTouched();
                //przenieś pliki usuwanego pacjenta do pacjentów usuniętych
                if (Directory.Exists(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacpac.Id)))
                {
                    Directory.Move(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacpac.Id), KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacpac.Id));
                    
                }
                
                if (Directory.Exists(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacpac.Id)))
                {
                    Directory.Delete(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacpac.Id), true );
                }
                
            }
        }

        private void groupBoxPacjenci_Enter(object sender, EventArgs e)
        {
            
        }

        private void radioButtonPacj_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewKartLista.Rows.Clear();
            if (radioButtonPacj.Checked == true)
            {
                foreach (Pacjent p in pacjenci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            }
            else
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    dataGridViewKartLista.Rows.Add(Convert.ToString(p.Id), p.Imie, p.Nazwisko);
                }
            }
        }

        private void buttonKartPrzywroc_Click(object sender, EventArgs e)
        {
            if(dataGridViewKartLista.SelectedCells.Count == 0)
            {
                return;
            }
            int id_row_idx = dataGridViewKartLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridViewKartLista.Rows[id_row_idx].Cells[0].Value.ToString() );
            Pacjent pacjPrzywracany = null;
            foreach(Pacjent p in pacjenciUsunieci)
            {
                if(p.Id==id)
                {
                    pacjPrzywracany = p;
                    pacjenciUsunieci.Remove(p);
                    break;
                }

            }
            if(pacjPrzywracany==null)
            {
                MessageBox.Show("Nie znaleziono usuniętego pacjenta o podanym id", "Niewłaściwe id", MessageBoxButtons.OK);
                return;
            }
            pacjenci.Add(pacjPrzywracany);
            odswiezKartoteke();
            pacjPrzywracany.setTouched();
            if (Directory.Exists(KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacjPrzywracany.Id)))
            {
                if (!Directory.Exists(KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacjPrzywracany.Id)))
                { Directory.Move(KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacjPrzywracany.Id), KatalogGlowny + @"\pacjenci\" + Convert.ToString(pacjPrzywracany.Id)); }
            }
            if (Directory.Exists(KatalogGlowny+@"\pacjenciUsunieci\"+Convert.ToString(pacjPrzywracany.Id)))
            {
                
                Directory.Delete(KatalogGlowny + @"\pacjenciUsunieci\" + Convert.ToString(pacjPrzywracany.Id), true);
            }
        }

        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            buttonDzienPoz_Click(this,null);
            buttonDzienWcz_Click(this, null);
            odswiezKartoteke();
        }

        private void buttonKonfiguracja_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            FormKonfig fKonf = new FormKonfig(this);
        }

        private void buttonNastepny_Click(object sender, EventArgs e)
        {

            if(dataGridViewKartLista.CurrentCell == null)
            { return; }
            if(dataGridViewKartLista.CurrentCell.RowIndex < dataGridViewKartLista.Rows.Count -1)
            {
                int selectedIdx = dataGridViewKartLista.CurrentCell.RowIndex;
                dataGridViewKartLista.CurrentCell = dataGridViewKartLista.Rows[dataGridViewKartLista.CurrentCell.RowIndex + 1].
                                                                            Cells[dataGridViewKartLista.CurrentCell.ColumnIndex];
                textBoxWyszukaj_TextChanged(null, null);
            }

        }

        private void dataGridViewKartLista_SelectionChanged(object sender, EventArgs e)
        {
            switch (dataGridViewKartLista.CurrentCell.ColumnIndex)
            {

                case 1:
                    labelWyszukaj.Text = "imie";
                    kolumna_wyszukiwania_DGVKartoteka = 1;
                    break;
                case 2:
                    labelWyszukaj.Text = "nazwisko";
                    kolumna_wyszukiwania_DGVKartoteka = 2;
                    break;
                default:
                    labelWyszukaj.Text = "id";
                    kolumna_wyszukiwania_DGVKartoteka = 0;
                    break;
            }
        }

        private void textBoxWyszukaj_TextChanged(object sender, EventArgs e)
        {
            //przeszukaj kartotekę po wybranej kolumnie, zatrzymaj przeszukiwanie na pierwszym pasującym do wzorca
            //substringu z wybranej kolumny kartoteki
            if (textBoxWyszukaj.Text == "")
            {
                return;
            }
            string patt = textBoxWyszukaj.Text.ToLower();
            int c = 0;
            /*
            for (int k = 0; k < dataGridViewKartLista.Rows.Count; k++)
            {


                if (dataGridViewKartLista.Rows[k].Cells[kolumna_wyszukiwania_DGVKartoteka].Selected == true)
                { c = k; }

            }
            */
            // c=0 --- kod powyżej zakomentowany bo powodował nieintuicyjne działanie interfejsu
            for (int i = c; i < dataGridViewKartLista.Rows.Count; i++)
            {
                string comparedValue = dataGridViewKartLista.Rows[i].Cells[kolumna_wyszukiwania_DGVKartoteka].Value.ToString().ToLower();
                if (comparedValue.Length < patt.Length)
                { continue; }
                comparedValue = comparedValue.Substring(0, patt.Length);
                if (comparedValue == patt)
                {
                    dataGridViewKartLista.Rows[i].Cells[kolumna_wyszukiwania_DGVKartoteka].Selected = true;
                    return;
                }
            }
            MessageBox.Show("Nie znaleziono szukanej osoby");
        }

        private void dataGridViewKartLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewGrafik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender == null || !(sender is DataGridView))
            {
                return;
            }
            DataGridView DGVgrafik = sender as DataGridView;
            DateTime najwczesGodz = grafik.NajwczesniejszaGodzina;
            DateTime najpozGodz = grafik.NajpozniejszaGodzina;
            int najwczesniejszaGodzinaWKwadransach = najwczesGodz.Hour * 4 + najwczesGodz.Minute / 15;
            int najPozniejszaGodzinaWKwadransach = najpozGodz.Hour * 4 + najwczesGodz.Minute / 15;
            int indexPoczWizyty = DGVgrafik.CurrentCell.RowIndex;
            if (!(DGVgrafik.CurrentCell.Style.BackColor == Color.LightBlue || DGVgrafik.CurrentCell.Style.BackColor == Color.LightGreen))
            {
                return;
            }
            Color currColor = DGVgrafik.CurrentCell.Style.BackColor;
            int idx1 = DGVgrafik.CurrentCell.RowIndex;
            int idx2 = idx1;
            while (idx1 > 0 && DGVgrafik.Rows[idx1 - 1].Cells[DGVgrafik.CurrentCell.ColumnIndex].Style.BackColor == currColor)
            {
                idx1--;
            }
            while (idx2 < DGVgrafik.Rows.Count - 1 && DGVgrafik.Rows[idx2 + 1].Cells[DGVgrafik.CurrentCell.ColumnIndex].Style.BackColor == currColor)
            {
                idx2++;
            }
            idx2++;
            int godzPocz = najwczesGodz.Hour + idx1 / 4;
            int minPocz = idx1 % 4;
            int godzKon = godzPocz + (idx2 - idx1) / 4;
            int minKon = idx2 % 4;
            dateTimePicker2.Value = grafik.PierwszyWyswietlanyDzien.AddDays(DGVgrafik.CurrentCell.ColumnIndex - 1);
            dateTimePicker2.Refresh();
            comboBoxGodzOd.SelectedIndex = godzPocz;
            comboBoxMinOd.SelectedIndex = minPocz;
            comboBoxGodzDo.SelectedIndex = godzKon;
            comboBoxMinDo.SelectedIndex = minKon;
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            DateTime teraz = DateTime.Now;
            DateTime dzis = new DateTime(teraz.Year, teraz.Month, teraz.Day);

            DateTime dataWizyty;
            int godzinaOd;
            int minutaOd;
            int godzinaDo;
            int minutaDo;
            try
            {
                DateTime d = dateTimePicker2.Value;
                dataWizyty = new DateTime(d.Year, d.Month, d.Day);
                godzinaOd = comboBoxGodzOd.SelectedIndex;
                minutaOd = comboBoxMinOd.SelectedIndex * 15;
                godzinaDo = comboBoxGodzDo.SelectedIndex;
                minutaDo = comboBoxMinDo.SelectedIndex * 15;
            }
            catch (Exception e1)
            {
                return;
            }

            DateTime godzOd = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaOd, minutaOd, 0);
            DateTime godzDo = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, godzinaDo, minutaDo, 0);
            if (DateTime.Compare(godzOd, godzDo) >= 0)
            {
                MessageBox.Show("Godzina zakończenia wizyty musi być późniejsza niż godzina rozpoczęcia", "Niepoprawne dane wizyty", MessageBoxButtons.OK);
                return;
            }

            KluczWizyty key = new KluczWizyty(dataWizyty, godzinaOd, minutaOd, godzinaDo, minutaDo);
            bufor.UsunWizyte(key);
            odswiez();
        }
    }


    public class Cipher
    {

        private static byte[] key;
        private static byte[] iv;
        public static byte[] Key { get => key; set => key = value; }
        public static byte[] Iv { get => iv; set => iv = value; }


        internal static string ReadString(BinaryReader br)
        {
            int ByteLength = br.ReadInt32();
            if (ByteLength != 0)
            {
                byte[] bytesToDecipher = br.ReadBytes(ByteLength);
                string decipheredString = DecryptStringFromBytes_Aes(bytesToDecipher, key, iv);
                return decipheredString;
            }
            else
            { return ""; }
        }
        internal static void Write(BinaryWriter bw, string toEncrypt)
        {
            if (toEncrypt.Length != 0)
            {
                byte[] encryptedString = EncryptStringToBytes_Aes(toEncrypt, key, iv);
                bw.Write(Buffer.ByteLength(encryptedString));
                bw.Write(encryptedString);
            }
            else
            {
                bw.Write(0);
            }
        }


        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null )
                throw new ArgumentNullException("plainText");
            if (plainText.Length <= 0)
            {
                return null;
            }
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }



    }


}
