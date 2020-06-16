using AplikacjaStomatologiczna;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApStomat
{
    public partial class FormPacjentEditShow : Form
    {
        Pacjent pacjDoPokazania;
        Form1 mainForm;
        bool readOnlyMode;
        string[] sciezkiZdjec;
        string katalogPacjenta;
        internal FormPacjentEditShow(Pacjent pacpac, Form1 mf)
        {
            InitializeComponent();
            pacjDoPokazania = pacpac;
            mainForm = mf;
            mainForm.TopMost = false;
            mainForm.Enabled = false;
            readOnlyMode = false;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
            string[] nazwyPol = Pacjent.pobierzNazwydanych();
            string[] danePacjenta = pacjDoPokazania.pobierzDane();
            for (int i = 0; i < nazwyPol.Length; i++)
            {
                dataGridView1.Rows.Add(nazwyPol[i], danePacjenta[i]);
            }
            sciezkiZdjec = new string[0];
            katalogPacjenta = "";
            if(Directory.Exists(mainForm.KatalogGlowny+@"\pacjenci\"+pacpac.Id.ToString()))
            {
                katalogPacjenta= mainForm.KatalogGlowny + @"\pacjenci\" + pacpac.Id.ToString();
                sciezkiZdjec = Directory.GetFiles(katalogPacjenta + @"\zdjecia");
            }
            else if(Directory.Exists(mainForm.KatalogGlowny + @"\pacjenciUsunieci\" + pacpac.Id.ToString()))
            {
                katalogPacjenta = mainForm.KatalogGlowny + @"\pacjenciUsunieci\" + pacpac.Id.ToString();
                sciezkiZdjec = Directory.GetFiles(katalogPacjenta+  @"\zdjecia");
            }
            odswiezZdjecia();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            



            dataGridView1.AllowUserToResizeRows = false;
            for(int i=0;i<dataGridView1.ColumnCount;i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            List<KluczWizyty> wizytyKlucze = pacpac.przeprowadzoneZabiegi;
            foreach (KluczWizyty k in wizytyKlucze)
            {
                Wizyta w = mainForm.bufor.ZnajdzWizyte(k.Data, k.KluczOd, k.KluczDo);
                if (w != null && !listBoxWizyty.Items.Contains(w.ToString()))
                {
                    listBoxWizyty.Items.Add(w.ToString());
                }
                
            }
        }

        void odswiezZdjecia()
        {
            listBoxZdjecia.Items.Clear();
            sciezkiZdjec = new string[0];
            if(Directory.Exists(katalogPacjenta + @"\zdjecia"))
            {
                sciezkiZdjec = Directory.GetFiles(katalogPacjenta + @"\zdjecia");
                int offset = 9;
                foreach(string nazwaPliku in sciezkiZdjec)
                {
                    string samaNazwa = nazwaPliku.Substring(katalogPacjenta.Length + offset);
                    listBoxZdjecia.Items.Add(samaNazwa);
                }
            }
        }

        internal FormPacjentEditShow(Pacjent pacpac, Form1 mf, int v) : this(pacpac, mf)
        {
            buttonZapisz.Enabled = false;
            buttonZapisz.Visible = false;
            readOnlyMode = true;
            buttonZapisz.Visible = false;
            buttonZDjDodaj.Visible = false;
            buttonZdjUsun.Visible = false;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "";
                }
            }

            if (dataGridView1.Rows[1].Cells[1].Value.ToString()=="" || dataGridView1.Rows[2].Cells[1].Value.ToString() == "" ||
                dataGridView1.Rows[4].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("Imię, nazwisko i numer telefonu muszą mieć podane wartości", "Brakujące dane", MessageBoxButtons.OK);
                return;
            }
            string[] noweDane = new string[12];
            for(int i=1; i< dataGridView1.Rows.Count; i++)
            {
                noweDane[i - 1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            }
            pacjDoPokazania.przekazNoweDane(noweDane);
            mainForm.odswiezKartoteke();

        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPacjentEditShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            this.TopMost = false;
            mainForm.TopMost = true;
            mainForm.odswiez();
            mainForm.BringToFront();
            if(pacjDoPokazania.Touched)
            {
                mainForm.zapiszPacjentaDoPliku(pacjDoPokazania);
            }
            mainForm.PokazKartoteke();
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {

            FormDiagram formularzZebowy = new FormDiagram(pacjDoPokazania, mainForm,this, !readOnlyMode);
        }

        private void buttonZdjZobacz_Click(object sender, EventArgs e)
        {
            if(listBoxZdjecia.SelectedIndex==-1)
            { return; }
            sciezkiZdjec = Directory.GetFiles(katalogPacjenta + @"\zdjecia");
            if(sciezkiZdjec.Length<listBoxZdjecia.SelectedIndex)
            { return; }
            Image img = Image.FromFile(sciezkiZdjec[listBoxZdjecia.SelectedIndex]);
            
            FormZdjecie fz = new FormZdjecie(mainForm, this, img);
        }

        private void buttonZDjDodaj_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    int idx_last_slash = 0;
                        idx_last_slash=filePath.LastIndexOf(@"\");
                    string nameOnly = filePath.Substring(idx_last_slash + 1);

                    File.Copy(filePath, katalogPacjenta + @"\zdjecia\" + Pacjent.LicznikZdjec.ToString()+"_"+nameOnly );
                    odswiezZdjecia();
                }
            }
        }

        private void buttonZdjUsun_Click(object sender, EventArgs e)
        {
            if(listBoxZdjecia.SelectedIndex==-1)
            {
                return;
            }
            try
            {
                if (listBoxZdjecia.SelectedIndex < sciezkiZdjec.Length)
                {
                    File.Delete(sciezkiZdjec[listBoxZdjecia.SelectedIndex]);
                }
            }
            catch(Exception eeeee)
            {
                MessageBox.Show("Nie udało się skasować pliku.");
            }
            odswiezZdjecia();
        }

        private void buttonEksport_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sciezka = fbd.SelectedPath;
                string nazwa_folderu = sciezka + @"\" + pacjDoPokazania.Imie + "_" + pacjDoPokazania.Nazwisko + "_" + pacjDoPokazania.Id;
                string nazwa_folderu2 = nazwa_folderu;
                int i = 1;
                while(Directory.Exists(nazwa_folderu2))
                {
                    nazwa_folderu2 = nazwa_folderu +"_"+ i.ToString();
                    i++;
                }
                Directory.CreateDirectory(nazwa_folderu2);
                string[] danePacjenta = pacjDoPokazania.pobierzDane();
                string[] nazwyDanych = Pacjent.pobierzNazwydanych();
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(nazwa_folderu2+@"\dane"))
                {
                    for (int ii = 0; ii < danePacjenta.Length; ii++)
                    {
                        file.WriteLine(nazwyDanych[ii]+": "+danePacjenta[ii]);
                    }
                }
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(nazwa_folderu2 + @"\wizyty"))
                {
                    List<KluczWizyty> lista = pacjDoPokazania.getKluczeWizyt();
                    foreach(KluczWizyty k in lista)
                    {
                        Wizyta w = mainForm.bufor.ZnajdzWizyte(k.Data, k.KluczOd, k.KluczDo);
                        if (w != null)
                        {
                            file.WriteLine(w.ToString());
                        }
                    }
                }
                Directory.CreateDirectory(nazwa_folderu2 + @"\zdjecia");
                string[] sciezkiZdjec = new string[0];
                if (Directory.Exists(mainForm.KatalogGlowny + @"\pacjenci\" + pacjDoPokazania.Id.ToString()))
                {
                    sciezkiZdjec = Directory.GetFiles(mainForm.KatalogGlowny + @"\pacjenci\" + pacjDoPokazania.Id.ToString() + @"\zdjecia");
                }
                else
                {
                    sciezkiZdjec = Directory.GetFiles(mainForm.KatalogGlowny + @"\pacjenciUsunieci\" + pacjDoPokazania.Id.ToString() + @"\zdjecia");
                }
                foreach(string sciezkaZdjecia in sciezkiZdjec)
                {
                    int last_slash = sciezkaZdjecia.LastIndexOf(@"\");
                    string nazwaPlikuZdjecia = "";
                    if (last_slash != -1)
                    {
                        nazwaPlikuZdjecia = sciezkaZdjecia.Substring(last_slash + 1);
                    }
                    File.Copy(sciezkaZdjecia, nazwa_folderu2 + @"\zdjecia\"+nazwaPlikuZdjecia);
                   
                }
                pacjDoPokazania.diagramZebowy.generujIZapiszObraz(nazwa_folderu2);
            }


        }
    }
}
