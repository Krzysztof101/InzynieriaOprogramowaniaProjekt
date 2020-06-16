using ApStomat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaStomatologiczna
{
    public partial class FormDiagram : Form
    {
        Pacjent przekazanyPacjent;
        Form1 mainForm;
        FormPacjent formPacj;
        FormPacjentEditShow formEditShow;
        public bool czyMleczne = false;
        Zeby ze;
        Pen p = new Pen(Color.Black, 2);
        int[,,] kopia;

        private FormZapis formZapisUsuwanie;
        private bool editMode;

        public FormDiagram(Zeby zebyPacjenta)
        {
            InitializeComponent();
            ze = zebyPacjenta;
            canvas.BackColor = Color.DeepSkyBlue;
            this.Visible = false;
            mainForm = null;
            formPacj = null;
            formZapisUsuwanie = null;
            formEditShow = null;
        }
        internal FormDiagram(Pacjent nowyPacjent, Form1 mf, FormPacjent fp, bool editMode)
        {
            
            InitializeComponent();
            przekazanyPacjent = nowyPacjent;
            ze = nowyPacjent.diagramZebowy;
            canvas.BackColor = Color.DeepSkyBlue;

            if (!editMode)
            {
                ZebyPrzycisk.Visible = false;
            }


            mainForm = mf;
            formPacj = fp;
            formEditShow = null;
            formZapisUsuwanie = null;
            formPacj.TopMost = false;
            formPacj.Enabled = false;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
        }


        internal FormDiagram(Pacjent pacjentDoPokazania, Form1 mf, FormPacjentEditShow fPES, bool editMode)
        {

            InitializeComponent();
            ze = pacjentDoPokazania.diagramZebowy;
            przekazanyPacjent = pacjentDoPokazania;
            canvas.BackColor = Color.DeepSkyBlue;

            if (!editMode)
            {
                ZebyPrzycisk.Visible = false;
            }


            mainForm = mf;
            formPacj = null;
            formZapisUsuwanie = null;
            formEditShow = fPES;
            fPES.TopMost = false;
            fPES.Enabled = false;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
        }

        internal FormDiagram(Pacjent zapisywanyPacjent, Zeby diagramZebowy, FormZapis formZapisUsuwanie, bool editMode)
        {
            InitializeComponent();
            ze = diagramZebowy;
            przekazanyPacjent = zapisywanyPacjent;
            canvas.BackColor = Color.DeepSkyBlue;
            this.formZapisUsuwanie = formZapisUsuwanie;

            formPacj = null;
            formEditShow = null;


            this.editMode = editMode;
            if(!editMode)
            {
                ZebyPrzycisk.Visible = false;
            }

            formZapisUsuwanie.Enabled = false;
            formZapisUsuwanie.TopMost = false;


            this.TopMost = true;
            this.Show();
            this.BringToFront();

        }

        private void Przycisk(object sender, EventArgs e)
        {
            if (RzadBox.SelectedIndex == -1 || NumerBox.SelectedIndex == -1 || string.IsNullOrEmpty(CzescBox.Text) || string.IsNullOrEmpty(KolorBox.Text))
            {
                MessageBox.Show("Wybierz wszystkie wartości!");
                return;
            }
            int rzad=RzadBox.SelectedIndex;
            int numer=NumerBox.SelectedIndex;
            int czesc=CzescBox.SelectedIndex;
            int kolor=KolorBox.SelectedIndex+1;
            if (czyMleczne == true)
            {
                numer = numer + 3;
                if (ze.tabMleczne[rzad, numer, czesc] == 0)
                {
                    MessageBox.Show("Ząb nie posiada takiej części!");
                    return;
                }
                ze.tabMleczne[rzad, numer, czesc] = kolor;
            }
            else
            {
                if (ze.tabTrzonowe[rzad, numer, czesc] == 0)
                {
                    MessageBox.Show("Ząb nie posiada takiej części!");
                    return;
                }
                ze.tabTrzonowe[rzad, numer, czesc] = kolor;
            }
            kopia[rzad, numer, czesc] = kolor;
            canvas.Invalidate();
            
            ze.setTouched();
        }

        void RysujDiagram(object sender, PaintEventArgs e)
        {
            if (czyMleczne == true)
            {
                kopia = (int[,,])ze.tabMleczne.Clone();
            }
            else
            {
                kopia = (int[,,])ze.tabTrzonowe.Clone();
            }
            int rzad = 0;
            int x = 1;
            int i = 0;
            int limit = 16;
            int przerwa = 15;
            if (czyMleczne == true)
            {
                x = 211;
                i = 3;
                limit = 13;
                przerwa = 12;
            }
            int y = 100;
            int z = 0;
            Graphics g = e.Graphics;
            for (; i < limit; i++)
            {
                Rectangle circle = new Rectangle(x, y, 64, 64);
                Rectangle circle2 = new Rectangle(x + 16, y + 16, 32, 32);
                Point[] po1 = { new Point(x + 1, y + 25), new Point(x + 32, y + 25), new Point(x + 1, z) };
                Point[] po2 = { new Point(x + 1, y + 25), new Point(x + 63, y + 25), new Point(x + 32, z) };
                Point[] po3 = { new Point(x + 32, y + 25), new Point(x + 63, y + 25), new Point(x + 63, z) };
                if (kopia[rzad, i, 6] != 0)
                {
                    g.FillPolygon(StanZeba(kopia[rzad, i, 6]), po2);
                    g.DrawPolygon(p, po2);
                }
                if (kopia[rzad, i, 5] != 0)
                {
                    g.FillPolygon(StanZeba(kopia[rzad, i, 5]), po1);
                    g.FillPolygon(StanZeba(kopia[rzad, i, 7]), po3);
                    g.DrawPolygon(p, po1);
                    g.DrawPolygon(p, po3);
                }
                g.FillPie(StanZeba(kopia[rzad, i, 1]), x, y, 64, 64, 45, 90);
                g.FillPie(StanZeba(kopia[rzad, i, 2]), x, y, 64, 64, 135, 90);
                g.FillPie(StanZeba(kopia[rzad, i, 3]), x, y, 64, 64, 225, 90);
                g.FillPie(StanZeba(kopia[rzad, i, 4]), x, y, 64, 64, 315, 90);
                g.DrawLine(p, x + 9, y + 9, x + 55, y + 55);
                g.DrawLine(p, x + 9, y + 55, x + 55, y + 9);
                g.FillEllipse(StanZeba(kopia[rzad, i, 0]), circle2);
                g.DrawEllipse(p, circle2);
                g.DrawEllipse(p, circle);
                x = x + 70;
                if (rzad == 0 && i == przerwa)
                {
                    if (czyMleczne == true)
                    {
                        i = 2;
                        x = 211;
                    }
                    else
                    {
                        i = -1;
                        x = 1;
                    }
                    rzad = 1;
                    y = y + 100;
                    z = 350;
                }
            }
        }

        public Brush StanZeba(int kolor)
        {
            Brush kolorek = new SolidBrush(Color.White);
            if (kolor == 1) //brak zęba (czarny)
                kolorek = new SolidBrush(Color.Black);
            else if (kolor == 2) //chirurgia (czerwony)
                kolorek = new SolidBrush(Color.Red);
            else if (kolor == 3) //dewitalizacja (zielony)
                kolorek = new SolidBrush(Color.Green);
            else if (kolor == 4) //do obserwacji (blue)
                kolorek = new SolidBrush(Color.Blue);
            else if (kolor == 5) //ekstrakcja (fiołkowy)
                kolorek = new SolidBrush(Color.BlueViolet);
            else if (kolor == 6) //hemisekcja (cyjan)
                kolorek = new SolidBrush(Color.Aqua);
            else if (kolor == 7) //implant (brązowy)
                kolorek = new SolidBrush(Color.Brown);
            else if (kolor == 8) //kiretaż otwarty (oliwkowy)
                kolorek = new SolidBrush(Color.Olive);
            else if (kolor == 9) //kiretaż ręczny (łososiowy)
                kolorek = new SolidBrush(Color.Salmon);
            else if (kolor == 10) //konsultacja stomatologiczna (szary)
                kolorek = new SolidBrush(Color.Gray);
            else if (kolor == 11) //korona pełnoceramiczna (indygo) 
                kolorek = new SolidBrush(Color.Indigo);
            else if (kolor == 12) //korona porcelanowa na metalu (żółty)
                kolorek = new SolidBrush(Color.Yellow);
            else if (kolor == 13) //korona protetyczna obca (fiolet) 
                kolorek = new SolidBrush(Color.Purple);
            else if (kolor == 14) //korona tymczasowa (złoty) 
                kolorek = new SolidBrush(Color.Gold);
            else if (kolor == 15) //leczenie endod (srebrny)
                kolorek = new SolidBrush(Color.Silver);
            else if (kolor == 16) //most (turkusowy)
                kolorek = new SolidBrush(Color.Turquoise);
            else if (kolor == 17) //mycie zęba-opłukiwanie (limonkowy)
                kolorek = new SolidBrush(Color.Lime);
            else if (kolor == 18) //opatrunek do kanału (magenta) 
                kolorek = new SolidBrush(Color.Magenta);
            else if (kolor == 19) //opracowanie 1 kanału (pomarańczowy) 
                kolorek = new SolidBrush(Color.Orange);
            else if (kolor == 20) //piaskowanie (różowy)
                kolorek = new SolidBrush(Color.Pink);
            else if (kolor == 21) //proteza akrylowa (fuksja) 
                kolorek = new SolidBrush(Color.Fuchsia);
            else if (kolor == 22) //proteza szkieletowa (akwamaryna)
                kolorek = new SolidBrush(Color.Aquamarine);
            else if (kolor == 23) //próchnica głeboka (peru)
                kolorek = new SolidBrush(Color.Peru);
            else if (kolor == 24) //skaling (morski)
                kolorek = new SolidBrush(Color.Teal);
            else if (kolor == 25) //skaling ultradźwiękowy szczęki (karmazynowy) 
                kolorek = new SolidBrush(Color.Crimson);
            else if (kolor == 26) //ubytek próchnicowy (beis)
                kolorek = new SolidBrush(Color.Beige);
            else if (kolor == 27) //wypełnienie (bordo)
                kolorek = new SolidBrush(Color.Maroon);
            else if (kolor == 28) //wypełnienie amalgamatowe (moccasin) 
                kolorek = new SolidBrush(Color.Moccasin);
            else if (kolor == 29) //wypełnienie amalgamatowe obce (czekoladowy)
                kolorek = new SolidBrush(Color.Chocolate);
            else if (kolor == 30) //wypełnienie glasjonomerowe (khaki)
                kolorek = new SolidBrush(Color.Khaki);
            else if (kolor == 31) //wypełnienie kanału (lawendowy) 
                kolorek = new SolidBrush(Color.Lavender);
            else if (kolor == 32) //wypełnienie tymczasowe (cytrynowy) 
                kolorek = new SolidBrush(Color.LemonChiffon);
            else if (kolor == 33) //wypełnienie uv (tan)
                kolorek = new SolidBrush(Color.Tan);
            else if (kolor == 34) //wypełnienie uv obce (pomidorowy)
                kolorek = new SolidBrush(Color.Tomato);
            else if (kolor == 35) //zdrowy (biały)
                kolorek = new SolidBrush(Color.White);
            else if (kolor == 36) //znieczulenie (śliwkowy)
                kolorek = new SolidBrush(Color.Plum);
            else if (kolor == 37) //znieczulenie nasiękowe (morska zieleń) 
                kolorek = new SolidBrush(Color.SeaGreen);
            else if (kolor == 38) //znieczulenie przewodowe (chartreuse)
                kolorek = new SolidBrush(Color.Chartreuse);
            return kolorek;
        }

        private void przelacznik_Click(object sender, EventArgs e)
        {
            czyMleczne = !czyMleczne;
            if(czyMleczne==true)
            {
                lab11.Text = "";
                lab12.Text = "";
                lab13.Text = "";
                lab14.Text = "55";
                lab15.Text = "54";
                lab16.Text = "53";
                lab17.Text = "52";
                lab18.Text = "51";
                lab19.Text = "61";
                lab110.Text = "62";
                lab111.Text = "63";
                lab112.Text = "64";
                lab113.Text = "65";
                lab114.Text = "";
                lab115.Text = "";
                lab116.Text = "";
                lab21.Text = "";
                lab22.Text = "";
                lab23.Text = "";
                lab24.Text = "85";
                lab25.Text = "84";
                lab26.Text = "83";
                lab27.Text = "82";
                lab28.Text = "81";
                lab29.Text = "71";
                lab210.Text = "72";
                lab211.Text = "73";
                lab212.Text = "74";
                lab213.Text = "75";
                lab214.Text = "";
                lab215.Text = "";
                lab216.Text = "";
            }
            else
            {
                lab11.Text = "18";
                lab12.Text = "17";
                lab13.Text = "16";
                lab14.Text = "15";
                lab15.Text = "14";
                lab16.Text = "13";
                lab17.Text = "12";
                lab18.Text = "11";
                lab19.Text = "21";
                lab110.Text = "22";
                lab111.Text = "23";
                lab112.Text = "24";
                lab113.Text = "25";
                lab114.Text = "26";
                lab115.Text = "27";
                lab116.Text = "28";
                lab21.Text = "48";
                lab22.Text = "47";
                lab23.Text = "46";
                lab24.Text = "45";
                lab25.Text = "44";
                lab26.Text = "43";
                lab27.Text = "42";
                lab28.Text = "41";
                lab29.Text = "31";
                lab210.Text = "32";
                lab211.Text = "33";
                lab212.Text = "34";
                lab213.Text = "35";
                lab214.Text = "36";
                lab215.Text = "37";
                lab216.Text = "38";
            }
            RzadBox.Text = "Od góry do dołu";
            NumerBox.Text = "Od lewej do prawej";
            NumerBox.Items.Clear();
            canvas.Invalidate();
        }

        private void FormDiagram_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.TopMost = false;
            //formPacj.TopMost = true;
            //formPacj.Enabled = true;
            //formPacj.BringToFront();
            if (formPacj != null)
            {
                mainForm.zapiszPacjentaDoPliku(przekazanyPacjent);
                formPacj.Close();
                
            }
            if(formEditShow!=null)
            {
                this.TopMost = false;
                formEditShow.TopMost = true;
                formEditShow.Enabled = true;
                
                formEditShow.BringToFront();
            }
            if(formZapisUsuwanie!=null)
            {
                this.TopMost = false;
                formZapisUsuwanie.Enabled = true;
                formZapisUsuwanie.TopMost = true;
                formZapisUsuwanie.BringToFront();
            }
            

        }

        private void buttonZakoncz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void comboZmien(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RzadBox.Text))
                NumerBox.Items.Clear();
            else
            {
                NumerBox.Text = "Od lewej do prawej";
                if (czyMleczne == false)
                {
                    if (RzadBox.SelectedIndex == 0)
                    {
                        NumerBox.Items.Clear();
                        NumerBox.Items.Add("18");
                        NumerBox.Items.Add("17");
                        NumerBox.Items.Add("16");
                        NumerBox.Items.Add("15");
                        NumerBox.Items.Add("14");
                        NumerBox.Items.Add("13");
                        NumerBox.Items.Add("12");
                        NumerBox.Items.Add("11");
                        NumerBox.Items.Add("21");
                        NumerBox.Items.Add("22");
                        NumerBox.Items.Add("23");
                        NumerBox.Items.Add("24");
                        NumerBox.Items.Add("25");
                        NumerBox.Items.Add("26");
                        NumerBox.Items.Add("27");
                        NumerBox.Items.Add("28");
                    }
                    else if (RzadBox.SelectedIndex == 1)
                    {
                        NumerBox.Items.Clear();
                        NumerBox.Items.Add("48");
                        NumerBox.Items.Add("47");
                        NumerBox.Items.Add("46");
                        NumerBox.Items.Add("45");
                        NumerBox.Items.Add("44");
                        NumerBox.Items.Add("43");
                        NumerBox.Items.Add("42");
                        NumerBox.Items.Add("41");
                        NumerBox.Items.Add("31");
                        NumerBox.Items.Add("32");
                        NumerBox.Items.Add("33");
                        NumerBox.Items.Add("34");
                        NumerBox.Items.Add("35");
                        NumerBox.Items.Add("36");
                        NumerBox.Items.Add("37");
                        NumerBox.Items.Add("38");
                    }
                }
                else
                {
                    if (RzadBox.SelectedIndex == 0)
                    {
                        NumerBox.Items.Clear();
                        NumerBox.Items.Add("55");
                        NumerBox.Items.Add("54");
                        NumerBox.Items.Add("53");
                        NumerBox.Items.Add("52");
                        NumerBox.Items.Add("51");
                        NumerBox.Items.Add("61");
                        NumerBox.Items.Add("62");
                        NumerBox.Items.Add("63");
                        NumerBox.Items.Add("64");
                        NumerBox.Items.Add("65");
                    }
                    else if (RzadBox.SelectedIndex == 1)
                    {
                        NumerBox.Items.Clear();
                        NumerBox.Items.Add("85");
                        NumerBox.Items.Add("84");
                        NumerBox.Items.Add("83");
                        NumerBox.Items.Add("82");
                        NumerBox.Items.Add("81");
                        NumerBox.Items.Add("71");
                        NumerBox.Items.Add("72");
                        NumerBox.Items.Add("73");
                        NumerBox.Items.Add("74");
                        NumerBox.Items.Add("75");
                    }
                }
            }
        }

    }
}
