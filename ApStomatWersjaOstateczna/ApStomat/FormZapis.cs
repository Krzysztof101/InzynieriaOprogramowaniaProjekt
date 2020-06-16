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
    public partial class FormZapis : Form
    {

        Pacjent wybrany;
        Zeby kopiaZebowWybranego;
        List<Pacjent> WyszukaniPacjenci;
        private DateTime godzinaOd;
        private DateTime godzinaDo;
        private List<Pacjent> pacjenci;
        private BuforZmian bufor;
        private Form1 mainForm;

        private bool editMode;

        internal FormZapis(DateTime godzinaOd, DateTime godzinaDo, List<Pacjent> pacjenci, BuforZmian bufor, Form1 mf, bool editMode)
        {
            //konstruktor przygotowujący formularz do zapisania na wizytę
            try
            {
                InitializeComponent();
                this.editMode = editMode;
                WyszukaniPacjenci = new List<Pacjent>();
                wybrany = null;
                kopiaZebowWybranego = null;
                this.godzinaOd = godzinaOd;
                this.godzinaDo = godzinaDo;
                this.pacjenci = pacjenci;
                this.bufor = bufor;
                comboBoxId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                mainForm = mf;
                mainForm.Enabled = false;
                this.Text = "Zapisz na wizytę: " + String.Format("{0:yyyy/MM/dd HH:mm}", godzinaOd) + " - " + String.Format("{0:HH:mm}", godzinaDo);
                this.Show();
                mainForm.TopMost = false;
                this.TopMost = true;
            }
            catch(Exception e)
            {
                
            }
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        internal FormZapis(Form1 form1, Wizyta w, bool editMode)
        {
            this.editMode = editMode;
            InitializeComponent();
            this.mainForm = form1;
            this.mainForm.Enabled = false;
            form1.TopMost = false;
            this.Show();
            this.TopMost = true;
            //konstruktor przygotowujący formularz do oglądania wizyty
            textBoxImie.Enabled = false;
            textBoxNazwisko.Enabled = false;
            buttonZapisz.Enabled = false;
            comboBoxId.Enabled = false;
            textBoxImie.Visible = false;
            textBoxNazwisko.Visible = false;
            comboBoxId.Visible = false;
            buttonZapisz.Visible = false;
            labelImie.Visible = false;
            labelNazwisko.Visible = false;
            label4.Visible = false;
            form1.TopMost = false;
            this.TopMost = true;
            Pacjent pacpac = w.Pacj;
            


            kopiaZebowWybranego = pacpac.diagramZebowy.DeepCopy();
            string[] pola = Pacjent.pobierzNazwydanych();
            string[] dane = pacpac.pobierzDane();
            wybrany = pacpac;
            dataGridView1.Rows.Clear();
            for(int i=0;i<pola.Length;i++)
            {
                dataGridView1.Rows.Add(pola[i], dane[i]);
            }
            textBoxOpis.Text = w.opis;
            textBoxCena.Text = Convert.ToString(w.cena);
            this.Text = "wizyta " + String.Format("{0:yyyy/MM/dd HH:mm}",w.DataWizytyOd)+"-" + String.Format("{0:HH:mm}", w.DataWizytyDo);

            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToAddRows = false;

        }



        private void Form2_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }
        private void wyszukajPoImieniuINazwisku(string imie, string nazwisko)
        {
            dataGridView1.Rows.Clear();
            WyszukaniPacjenci.Clear();
            comboBoxId.Items.Clear();
            if(imie=="" && nazwisko =="")
            {
                return;
            }

            //nowe wyszukiwanie
            List<Pacjent> wyszukaniPoNazwisku = new List<Pacjent>();
            List<Pacjent> wyszukaniPoImieniu = new List<Pacjent>();
            if (nazwisko != "")
            {
                foreach (Pacjent p in pacjenci)
                {
                    if (p.Nazwisko.Length < nazwisko.Length)
                    {
                        continue;
                    }
                    if (p.Nazwisko.ToLower().Substring(0, nazwisko.Length) == nazwisko.ToLower())
                    {
                        wyszukaniPoNazwisku.Add(p);
                    }
                }
            }
            if (imie != "")
            {
                foreach (Pacjent p in pacjenci)
                {
                    if (p.Imie.Length < imie.Length)
                    {
                        continue;
                    }
                    if (p.Imie.ToLower().Substring(0, imie.Length) == imie.ToLower())
                    {
                        wyszukaniPoImieniu.Add(p);
                    }
                }
            }

            if(nazwisko !="" && imie != "")
            {
                foreach(Pacjent p in pacjenci)
                {
                    if(wyszukaniPoImieniu.Contains(p) && wyszukaniPoNazwisku.Contains(p))
                    {
                        WyszukaniPacjenci.Add(p);
                    }
                }

            }
            else if(nazwisko =="" && imie != "")
            {
                foreach (Pacjent p in pacjenci)
                {
                    if (wyszukaniPoImieniu.Contains(p))
                    {
                        WyszukaniPacjenci.Add(p);
                    }
                }
            }
            else if(imie == "" && nazwisko!="" )
            {
                foreach (Pacjent p in pacjenci)
                {
                    if (wyszukaniPoNazwisku.Contains(p))
                    {
                        WyszukaniPacjenci.Add(p);
                    }
                }

            }

            //t

            foreach(Pacjent p in WyszukaniPacjenci)
            {
                comboBoxId.Items.Add(Convert.ToString(p.Id));
            }
            if(WyszukaniPacjenci.Count>0)
            {
                wybrany = WyszukaniPacjenci.First();
                comboBoxId.SelectedIndex = 0;
            }

            
        }

        private void textBoxImie_TextChanged(object sender, EventArgs e)
        {
            wyszukajPoImieniuINazwisku(textBoxImie.Text, textBoxNazwisko.Text);
        }

        private void textBoxNazwisko_TextChanged(object sender, EventArgs e)
        {
            wyszukajPoImieniuINazwisku(textBoxImie.Text, textBoxNazwisko.Text);
        }


        private void comboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Pacjent wybranyPacjent = null;
            dataGridView1.Rows.Clear();
            int wybraneId;
            bool konwersjaudana=true;
            
                konwersjaudana = int.TryParse(comboBoxId.SelectedItem.ToString() ,  out wybraneId);
                if(!konwersjaudana)
                {
                return;
                }
            foreach(Pacjent p in WyszukaniPacjenci)
            {
                if(p.Id == wybraneId)
                {
                    wybranyPacjent = p;
                    break;
                }
            }
            if(wybranyPacjent != null)
            {
                wybrany = wybranyPacjent;
                kopiaZebowWybranego = wybrany.diagramZebowy.DeepCopy();


                string[] dane = wybranyPacjent.pobierzDane();
                string[] nazwyDanych = Pacjent.pobierzNazwydanych();
                for(int i=0;i<dane.Length;i++)
                {
                    dataGridView1.Rows.Add(nazwyDanych[i], dane[i]);
                }
            }
        }
        
        /*
        private void buttonWyszukaj_Click(object sender, EventArgs e)
        {
            wybrany = null;
            kopiaZebowWybranego = null;
            wyszukajPoImieniuINazwisku(textBoxImie.Text, textBoxNazwisko.Text);
        }
        */
        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            int idWybranegoPacj;
            Pacjent p = null;
            double cena;
            try
            {
                if(comboBoxId.Items.Count==0)
                {
                    return;
                }
                if(comboBoxId.Text=="")
                {
                    return;
                }
                if(!int.TryParse(comboBoxId.SelectedItem.ToString(),out idWybranegoPacj))
                {
                    throw new Exception();
                }
                foreach (Pacjent pp in WyszukaniPacjenci)
                {
                    if(pp.Id==idWybranegoPacj)
                    {
                        p = pp;
                        break;
                    }
                }
                if(!double.TryParse(textBoxCena.Text, out cena) || p==null)
                {
                    throw new Exception();
                }
            }
            catch(Exception eree)
            {
                return;
            }
            if(textBoxOpis.Text=="" )
            {
                MessageBox.Show("Podaj opis wiyty", "brakujące dane", MessageBoxButtons.OK);
                return;
            }
            
            DateTime dataWizyty = new DateTime(godzinaOd.Year, godzinaOd.Month, godzinaOd.Day);
            if(kopiaZebowWybranego.Touched)
            {
                p.diagramZebowy = kopiaZebowWybranego;
                
            }
            Wizyta w = new Wizyta(dataWizyty, godzinaOd.Hour, godzinaOd.Minute, godzinaDo.Hour, godzinaDo.Minute, textBoxOpis.Text, cena, p);
            bufor.ZapiszNaWizyte(dataWizyty, w);
            mainForm.odswiez();
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void FormZapisUsuwanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(wybrany!=null && wybrany.Touched)
            {
                mainForm.zapiszPacjentaDoPliku(wybrany);
            }
            mainForm.TopMost = true;
            mainForm.Enabled = true;
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            if(wybrany==null || kopiaZebowWybranego==null)
            { return; }
            FormDiagram fK = new FormDiagram(wybrany, kopiaZebowWybranego , this, editMode);
        }
        
    }
}



/*
  // stare wyszukiwanie

            if (nazwisko=="")
            {
                return;
            }
            foreach(Pacjent p in pacjenci)
            {
                if(p.Nazwisko.Length < nazwisko.Length)
                {
                    continue;
                }
                if(p.Nazwisko.ToLower().Substring(0,nazwisko.Length)==nazwisko.ToLower())
                {
                    WyszukaniPacjenci.Add(p);
                }
            }
            if(imie!="")
            {
                for(int pp=0; pp<WyszukaniPacjenci.Count;pp++)
                { 
                    if( WyszukaniPacjenci.ElementAt(pp).Imie.Length < imie.Length)
                    {
                        continue;
                    }
                    if(WyszukaniPacjenci.ElementAt(pp).Imie.ToLower().Substring(0,imie.Length)!=imie.ToLower())
                    {
                        WyszukaniPacjenci.RemoveAt(pp);
                    }
                }
            }
            */
