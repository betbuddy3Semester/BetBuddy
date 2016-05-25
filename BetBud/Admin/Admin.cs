using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLibrary.Bruger;
using WCFBetBuddy;
using System.Web.UI;

namespace Admin

{
    public partial class Form1 : Form
    {
        ServiceReference1.ServicesClient svc = new ServiceReference1.ServicesClient();
        public Form1()
        {
            InitializeComponent();
        }
   
   

        private void button1_Click(object sender, EventArgs e)
        {
            Bruger bruger = svc.getBrugerEfterBrugernavn(textBox1.Text);

                        if (bruger != null)
                           {
                dataGridView1.Rows.Add(bruger.BrugerId, bruger.BrugerNavn, bruger.Email, bruger.Navn);
                
                           }
                        else {
                textBox1.Text = "Brugeren kunne ikke finde";
                
                            }
        }
    }
}
