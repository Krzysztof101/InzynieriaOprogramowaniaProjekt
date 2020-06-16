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

namespace AplikacjaStomatologiczna
{
    public partial class FormPobierzHaslo : Form
    {
        bool b;
        Form1 mainForm;
        public FormPobierzHaslo(Form1 mf)
        {
            mainForm = mf;
            mainForm.Enabled = false;
            b = true;
            InitializeComponent();
            this.BringToFront();
            textBoxHaslo.UseSystemPasswordChar = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            mainForm.TopMost = false;
            this.TopMost = true;
            BringToFront();

        }

        private void buttonPotwierdz_Click(object sender, EventArgs e)
        {
            if (textBoxHaslo.Text == mainForm.Haslo)
            {
                mainForm.Enabled = true;
                mainForm.przywrocWidocznoscDGVGrafik();
                b = false;
                this.TopMost = false;
                mainForm.TopMost = true;
                mainForm.DoubleOdswiez();
                this.Close();
            }
            else
            {
                string message = "Hasło niepoprawne";
                string caption = "Hasło niepoprawne";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            string message = "Czy na pewno zamknąć aplikację?";
            string caption = "Zamykanie aplikacji";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult d = MessageBox.Show(message, caption, buttons);
            if (d == System.Windows.Forms.DialogResult.Yes)
            { mainForm.Close(); }
        }

        private void FormPobierzHaslo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b)
            {
                string message = "Czy na pewno zamknąć aplikację?";
                string caption = "Zamykanie aplikacji";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult d = MessageBox.Show(message, caption, buttons);
                if (d == System.Windows.Forms.DialogResult.No)
                { e.Cancel = true; }
                else
                {
                    mainForm.Close();
                }

            }
        }

        private void buttonPotwierdz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPotwierdz_Click(null, null);
            }
        }

        private void FormPobierzHaslo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPotwierdz_Click(null, null);
            }
        }

        private void textBoxHaslo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPotwierdz_Click(null, null);
            }
        }
    }
}
