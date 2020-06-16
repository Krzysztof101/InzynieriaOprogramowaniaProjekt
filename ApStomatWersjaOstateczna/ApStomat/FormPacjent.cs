using AplikacjaStomatologiczna;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApStomat
{
   

    public partial class FormPacjent : Form
    {
        Form1 mainForm;

        public FormPacjent(Form1 mf)
        {

            InitializeComponent();
            mainForm = mf;
            mainForm.Enabled = false;
            mf.TopMost = false;
            this.TopMost = true;

            string[] nazwyDanych = new string[] {"imie", "nazwisko", "adres", "telefon", "email", //
                "higiena", "stan błony", "stan przyzębia", "leki", "alergie", "choroby", "inne"};
            for(int i=0; i< nazwyDanych.Length; i++)
            {
                dataGridViewDane.Rows.Add();
                dataGridViewDane.Rows[i].Cells[0].Value = nazwyDanych[i];
                dataGridViewDane.Rows[i].Cells[1].Value = "";
            }
            buttonDiagram.Enabled = false;//edycja diagramu następuje w chwili zapisania pacjenta 
            //na razie button tylko niewidoczny i nieaktywny

            //skonfigurowanie dataGridView
            dataGridViewDane.AllowUserToOrderColumns = false;
            dataGridViewDane.AllowUserToAddRows = false;
            dataGridViewDane.AllowUserToDeleteRows = false;

            dataGridViewDane.AllowUserToResizeRows = false;
            for(int i=0; i<dataGridViewDane.ColumnCount;i++)
            {
                dataGridViewDane.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }
        
        

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void FormPacjent_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.odswiezKartoteke();
            this.TopMost = false;
            mainForm.TopMost = true;
        }

        private void buttonDodZap_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGridViewDane.Rows.Count;i++)
            {
                if(dataGridViewDane.Rows[i].Cells[1].Value == null)
                {
                    dataGridViewDane.Rows[i].Cells[1].Value = "";
                }
            }

            if (dataGridViewDane.Rows[0].Cells[1].Value.ToString() == "" || dataGridViewDane.Rows[1].Cells[1].Value.ToString() == "" ||
                    dataGridViewDane.Rows[3].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("Pola imię, nazwisko i telefon nie mogą być puste", "Brakujące dane pacjenta", MessageBoxButtons.OK);
                return;
            }
            

            string[] dane = new string[12];
            for(int i=0;i<dane.Length;i++)
            {
                dane[i] = dataGridViewDane.Rows[i].Cells[1].Value.ToString();
            }



            string tel = dataGridViewDane.Rows[3].Cells[1].Value.ToString();
            string znakiNumeru = "0123456789*#";
            for(int i=0;i<tel.Length;i++)
            {
                int c = tel[i];
                bool blednyZnak = true;
                for(int j=0;j<znakiNumeru.Length;j++)
                {
                    if(c==znakiNumeru[j])
                    { blednyZnak = false; break; }
                }
                if(blednyZnak)
                {
                    MessageBox.Show("Numer telefonu może zawierać tylko cyfry i znaki * #.", "Niepoprawny format numeru telefonu", MessageBoxButtons.OK);
                    return;
                }
            }
            //walidacja pomyślna
            Zeby ZebyPacjenta = new Zeby();
            Pacjent pacpac = new Pacjent(dane, ZebyPacjenta);
            mainForm.pobierzPacjenta(pacpac);
            FormDiagram formZeb = new FormDiagram(pacpac,mainForm, this, true);
            this.Enabled = false;
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.odswiez();
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {

        }
    }

    
    
}



