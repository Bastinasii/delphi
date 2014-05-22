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
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();
        }

        PopulareTreeView f2;
        private void populareTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new PopulareTreeView();
                f2.MdiParent = this;
                f2.FormClosed += f2_FormClosed;   
                f2.Show();
            }
            else
                f2.Activate();


        }

        void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2 = null;
            //throw new NotImplementedException();
        }

        private void populareTreeViewMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulareTreeView f3 = new PopulareTreeView();
            f3.MdiParent = this;
            f3.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
