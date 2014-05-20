using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace LocalDatabase1
{
    public partial class Form1 : Form
    {
        public static string connString = "user id=dima.david1;" +
                                   "password=12345;server=localhost;" +
                                   "database=david; " +
                                   "connection timeout=10";
        public Form1()
        {
            InitializeComponent();
        }

        private void angajatiInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.angajatiInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.angajatoriDataSet1);

        }

        private void angajatiInfoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.angajatiInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.angajatoriDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'angajatoriDataSet1.AngajatiInfo' table. You can move, or remove it, as needed.
            this.angajatiInfoTableAdapter.Fill(this.angajatoriDataSet1.AngajatiInfo);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.angajatiInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.angajatoriDataSet1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.angajatiInfoBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.angajatiInfoBindingSource.AddNew();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PopulareTreeView f2 = new PopulareTreeView();
            f2.ShowDialog();
        }
    }
}
