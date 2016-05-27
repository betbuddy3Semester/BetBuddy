using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class SæsonMenu : Form
    {
        ServiceReference1.ServicesClient _srv = new ServiceReference1.ServicesClient();
        public SæsonMenu()
        {
            InitializeComponent();
        }

        private void SæsonMenu_Load(object sender, EventArgs e)
        {
            StartDatoTextBox.Text = _srv.HentBeskrivelse().StartDato;
            SlutDatoTextBox.Text = _srv.HentBeskrivelse().SlutDato;
            textBoxBeskrivelse.Text = _srv.HentBeskrivelse().Beskrivelse;
            SæsonIdLblShow.Text = _srv.GetSeasonId().ToString();
            TilmeldteBrugereLblShow.Text = _srv.getBrugere().Length.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string redigering = textBoxBeskrivelse.Text;
            string start = StartDatoTextBox.Text;
            string slut = SlutDatoTextBox.Text;
            _srv.RedigerBeskrivelse(redigering, start, slut);
        }

        private void SæsonIdLblShow_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxBeskrivelse_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartDatoTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TilmeldteBrugereLblShow_Click(object sender, EventArgs e)
        {

        }
    }
}
