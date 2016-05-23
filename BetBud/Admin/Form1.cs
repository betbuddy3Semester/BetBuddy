using ModelLibrary.Bruger;
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

namespace Admin
{
    
    
    public partial class Form1 : Form
    {

        ServiceReference1.ServicesClient svc = new ServiceReference1.ServicesClient();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
   
        private void button2_Click(object sender, EventArgs e)

        {
            
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bruger bruger = svc.getBrugerEfterBrugernavn(richTextBox1.Text);

            if (bruger != null)
            {
                dataGridView1.Rows.Add(bruger.BrugerId, bruger.BrugerNavn, bruger.Email, bruger.Navn);

            }
            else {
                richTextBox1.Text = "Brugeren kunne ikke finde";

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Bruger[] brugerList = svc.getBrugere();
            foreach (Bruger b in brugerList)
            {
             dataGridView1.Rows.Add(b.BrugerId, b.BrugerNavn, b.Email, b.Navn);
            }
        }
    }
}
