using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAWInterfataSGBD
{
    public partial class FormularPrincipal : Form
    {
        public FormularPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditQueryF f = new EditQueryF();
            f.ShowDialog();
            
        }
    }
}
