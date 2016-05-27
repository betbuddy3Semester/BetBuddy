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
    public partial class BrugerMenu : Form
    {
        public BrugerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var form = new SæsonMenu {Visible = true};
        }

        private void Bruger_Click(object sender, EventArgs e)
        {
            var form = new BrugerMenu {Visible = true};
        }
    }
}
