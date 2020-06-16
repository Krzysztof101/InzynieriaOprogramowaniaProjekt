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
    public partial class FormZdjecie : Form
    {
        Form1 mainForm;
        FormPacjentEditShow formPacjEdShow;
        Image img;
        public FormZdjecie(Form1 mf, FormPacjentEditShow fPES, Image zdj)
        {
            mainForm = mf;
            formPacjEdShow = fPES;
            InitializeComponent();
            formPacjEdShow.Enabled = false;
            formPacjEdShow.TopMost = false;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
            pictureBoxZdjecie.Image = zdj;
            img = zdj;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBoxZdjecie.Refresh();
        }

        private void FormZdjecie_FormClosing(object sender, FormClosingEventArgs e)
        {
            img.Dispose();
            formPacjEdShow.Enabled = true;
            this.TopMost = false;
            formPacjEdShow.TopMost = true;
            formPacjEdShow.BringToFront();
            
        }
    }
}
