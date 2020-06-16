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
    public partial class FormKonfig : Form
    {
        Form1 mainForm;
        public FormKonfig(Form1 mf)
        {
            InitializeComponent();
            mainForm = mf;
            mf.Enabled = false;
            this.TopMost = true;
            this.Show();
            textBoxStareHaslo.UseSystemPasswordChar = true;
            textBoxNoweHaslo1.UseSystemPasswordChar = true;
            textBoxNoweHaslo2.UseSystemPasswordChar = true;
            DateTime godzOtw = mainForm.GodzinaOtwarcia;
            DateTime godzZam = mainForm.GodzinaZamkniecia;
            numericUpDownGodzStart.Value = godzOtw.Hour;
            numericUpDownMinStart.Value = godzOtw.Minute;
            numericUpDownGodzKon.Value = godzZam.Hour;
            numericUpDownMinKon.Value = godzZam.Minute;
            numericUpDownDniWstecz.Value = mainForm.bufor.LiczbaZmianWstecz;
            numericUpDownDniNaprzod.Value = mainForm.bufor.LiczbaZmianNaprzod;
        }

        private void FormKonfig_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void FormKonfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.TopMost = true;
            if(mainForm.bufor.Touched)
            {
                mainForm.odswiez();
            }
            mainForm.BringToFront();
        }

        private void buttonZmianaHasla_Click(object sender, EventArgs e)
        {
            if(textBoxStareHaslo.Text=="" || textBoxNoweHaslo1.Text=="" || textBoxNoweHaslo2.Text=="")
            {
                return;
            }
            if(textBoxStareHaslo.Text!=mainForm.Haslo)
            {
                MessageBox.Show("Niepoprawne stare hasło");
                return;
            }
            if(textBoxNoweHaslo1.Text!=textBoxNoweHaslo2.Text)
            {
                MessageBox.Show("Nowe hasło i jego powtórzenie różnią się");
                return;
            }
            if(!FormTworzenieHasla.hasloMocne(textBoxNoweHaslo1.Text))
            {

                return;
            }
            mainForm.pobierzHaslo(textBoxNoweHaslo1.Text);
            MessageBox.Show("Zmiana hasła pomyślna");
            return;
        }

        private void buttonZmianaGodzin_Click(object sender, EventArgs e)
        {
            int minutyRozp = ((int)numericUpDownGodzStart.Value) * 60 + ((int)numericUpDownMinStart.Value);
            int minutyZak = ((int)numericUpDownGodzKon.Value) * 60 + ((int)numericUpDownMinKon.Value);
            if(minutyZak<=minutyRozp)
            {
                MessageBox.Show("Niepoprawne godziny rozpoczecia");
                return;
            }
            mainForm.bufor.noweGodzinyOtwarcia((int)numericUpDownGodzStart.Value, (int)numericUpDownMinStart.Value,
                                                (int)numericUpDownGodzKon.Value, (int)numericUpDownMinKon.Value);
        }

        private void buttonDniPotwierdz_Click(object sender, EventArgs e)
        {
            mainForm.bufor.noweIlosciWczytywanychDni((int)numericUpDownDniWstecz.Value, (int)numericUpDownDniNaprzod.Value);
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
