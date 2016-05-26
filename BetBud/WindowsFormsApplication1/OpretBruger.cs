using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFBetBuddy;
using ModelLibrary.Bruger;
using WindowsFormsApplication1.ServiceReference1;

namespace WindowsFormsApplication1
{
    public partial class OpretBruger: Form
    {
        ServicesClient sr = new ServicesClient();
        public OpretBruger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sr.opretBruger(new Bruger()
            {
                Navn = textBox1.Text,
                Email = textBox2.Text,
                BrugerNavn = textBox3.Text,
                Password = textBox4.Text,
                Alias = textBox5.Text,
                Point = double.Parse(textBox6.Text)
            });
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e) { 
}

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
