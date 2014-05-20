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
using System.Data.SqlServerCe;

namespace LocalDatabase1
{
    public partial class PopulareTreeView : Form
    {
        public static string connString = "user id=dima.david1;" +
                                   "password=12345;server=localhost;" +
                                   "database=david; " +
                                   "connection timeout=10";
        SqlCeConnection cn = new SqlCeConnection(@"Data Source = D:\structuri de date probleme\proiect paw\LocalDatabase\LocalDatabase1\Angajatori.sdf");

        public static DataTable table = new DataTable();

        public PopulareTreeView()
        {
            InitializeComponent();
        }

        public PopulareTreeView(DataTable t)
        {
            table = t;
            InitializeComponent();
        }

        private void PopulareTreeView_Shown(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
            }
            catch(SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            SqlCeCommand cm = new SqlCeCommand("SELECT * from AngajatiInfo ORDER BY nume",cn);

            try
            {
               SqlCeDataReader datar = cm.ExecuteReader();

               while (datar.Read())
               {
                   TreeNode nod = new TreeNode(datar["id"].ToString());
                   nod.Nodes.Add(datar["nume"].ToString());
                   nod.Nodes.Add(datar["prenume"].ToString());
                   nod.Nodes.Add(datar["varsta"].ToString());
                   nod.Nodes.Add(datar["salariu"].ToString());

                   treeView1.Nodes.Add(nod);
               }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("bag pula in ma-ta");

            }

        private void PopulareTreeView_Load(object sender, EventArgs e)
        {

        }

        }
    }
