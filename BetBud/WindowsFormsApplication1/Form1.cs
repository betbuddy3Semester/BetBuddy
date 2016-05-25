using ModelLibrary.Bruger;
using WCFBetBuddy;
using WindowsFormsApplication1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        ServicesClient sr = new ServicesClient();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Bruger b = sr.getBrugerEfterBrugernavn(textBox1.Text);

            if (b != null)
            {

                dataGridView1.Rows.Add(b.BrugerId, b.BrugerNavn, b.Email, b.Navn);
                
            }
            else
            {
                textBox1.Text = "Brugeren kunne ikke finde";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bruger[] brugerList = sr.getBrugere();
            foreach (Bruger b in brugerList)
            {
                dataGridView1.Rows.Add(b.BrugerId, b.Navn, b.Email, b.BrugerNavn, b.Password, b.Alias, b.Point);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var form = new OpretBruger();
            form.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            sr.opdaterBruger(new Bruger() {
                
               
                
               
                
            });
                


        }
           
            
        }
    }

