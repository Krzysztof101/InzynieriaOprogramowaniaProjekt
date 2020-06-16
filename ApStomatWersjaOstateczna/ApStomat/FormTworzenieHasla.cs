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
    public partial class FormTworzenieHasla : Form
    {
        bool b;
        private Form1 mainForm;
        public FormTworzenieHasla(Form1 mf)
        {
            InitializeComponent();
            mainForm = mf;
            b = true;
            textBoxHaslo1.UseSystemPasswordChar = true;
            textBoxHaslo2.UseSystemPasswordChar = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mainForm.TopMost = false;
            this.TopMost = true;
            BringToFront();
        }

        private void buttonPotwierdz_Click(object sender, EventArgs e)
        {
            
            if (textBoxHaslo1.Text!=textBoxHaslo2.Text)
            {
                string message = "hasło i jego powtórzenie nie są są ze sobą zgodne";
                string caption = "Niepoprawne hasło";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                return;
            }
            if(! FormTworzenieHasla.hasloMocne(textBoxHaslo1.Text))
            {

                return;
            }
            mainForm.pobierzHaslo(textBoxHaslo1.Text);
            mainForm.Enabled = true;
            b = false;
            this.TopMost = false;
            mainForm.TopMost = true;
            this.Close();
        }

        public static bool hasloMocne(string text)
        {
            string message = "hasło musi mieć co najmniej 8 znaków oraz zawierać liczbę i znak specjalny: ! @ # $ % ^ & *";
            string caption = "hasło za słabe";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            if (text.Length<8)
            {
                result = MessageBox.Show(message, caption, buttons);
                return false;
            }
            string liczby = "0123456789";
            bool znalezionoLiczbe = false;
            foreach(char c in liczby)
            {
                int pos = text.IndexOf(c);
                if(pos!=-1)
                {
                    znalezionoLiczbe = true;
                    break;
                }
            }
            if(!znalezionoLiczbe)
            {
                result = MessageBox.Show(message, caption, buttons);
                return false;
            }

            bool znalezionoZnak = false;
            string znaki = "!@#$%^&*";
            foreach (char c in znaki)
            {
                int pos = text.IndexOf(c);
                if (pos != -1)
                {
                    znalezionoZnak = true;
                    break;
                }
            }
            if (!znalezionoZnak)
            {
                result = MessageBox.Show(message, caption, buttons);
                return false;
            }
            return true;
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

        private void FormTworzenieHasla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b)
            {
                string message = "Nie twórz hasła i zamknij aplikację?";
                string caption = "Przerwanie tworzenia hasła";
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
    }
}
