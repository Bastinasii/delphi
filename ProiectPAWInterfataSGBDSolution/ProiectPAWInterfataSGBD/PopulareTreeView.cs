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
//using System.Data.SqlServerCe;

namespace ProiectPAWInterfataSGBD
{
    public partial class PopulareTreeView : Form
    {
        public static string connString = "user id=dima.david1;" +
                                   "password=12345;server=localhost;" +
                                   "database=david; " +
                                   "connection timeout=10";
        MySqlConnection cn = new MySqlConnection(connString);
        List<string> list = new List<string>();
        string numetab;
        public static DataTable table = new DataTable();

        public void updateTree()
        {

        }

        public PopulareTreeView()
        {
            InitializeComponent();

        }

        public PopulareTreeView(DataTable t, List<string> columnList, string tablename)
        {
            
            InitializeComponent();
            table = t;
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            
        }

        private void PopulareTreeView_Shown(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            MySqlCommand cm = new MySqlCommand("SELECT * from Angajati",cn);

            try
            {
               
               MySqlDataReader datar = cm.ExecuteReader();

               while (datar.Read())
               {
                   TreeNode nod = new TreeNode(datar["id"].ToString());
                   nod.Nodes.Add(datar["nume"].ToString());
                   TreeNode Nod2 = new TreeNode();
                   Nod2.Text = "Mata";
                   Nod2.Nodes.Add(new TreeNode("Tactu"));
                   nod.Nodes.Add(Nod2);

                   //nod.Nodes.Add(datar["prenume"].ToString());
                   //nod.Nodes.Add(datar["varsta"].ToString());
                   nod.Nodes.Add(datar["Salariul"].ToString());
                   treeView1.Nodes.Add(nod);

               }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void PopulareTreeView_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Console.WriteLine("click!");
            
            TreeNode ChildNode1 = new TreeNode();
            ChildNode1.Text = "Next Child 1";
            TreeNode ChildNode2 = new TreeNode();
            ChildNode2.Text = "Next Child 2";
            ChildNode1.Nodes.Add(ChildNode2);
            treeView1.SelectedNode.Nodes.Add(ChildNode1);
        }

        }
    }
