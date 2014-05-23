using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace ProiectPAWInterfataSGBD
{
    public partial class MDIParent : Form
    {
        private DataTable dataT = new DataTable();
        private static string tableName;
        private static List<string> tablecolumns;
        private static int rowcount;
        private static string user;
        private static string pass;
        private static string databasename;
        private static string server;
        private static int delIndex;
        private static string connString;

        public MDIParent getMdi()
        {
            return this;
        }

        public MDIParent()
        {
            InitializeComponent();
        }

        public MDIParent(string ser, string dataB, string us, string p)
        {
            InitializeComponent();
            server = ser;
            databasename = dataB;
            user = us;
            pass = p;
            connString = "user id=" + user + ";" +
                                   "password=" + pass + ";server=" + server + ";" +
                                   "database=" + databasename + ";" +
                                   "connection timeout=10";
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

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularPrincipal f = new FormularPrincipal();
            f.MdiParent = this;
            f.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {

        }

        private void sQLEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditQueryF f = new EditQueryF(server, databasename, user, pass);
            f.MdiParent = this;
            f.Show();
        }

        private void dBTreeviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulareTreeView f = new PopulareTreeView(databasename,GetColumnLists(),GetTables());
            f.MdiParent = this;
            f.Show();
        }

        public static List<string> GetTables()
        {
            DBConnect db = new DBConnect(connString);
            List<string> TableNames = new List<string>();
            try
            {
                //using (MySqlConnection connection = new MySqlConnection(connString))
                //{
                    //connection.Open();
                
                db.conn.Open();
                    DataTable schema = db.conn.GetSchema("Tables");

                    foreach (DataRow row in schema.Rows)
                    {
                        TableNames.Add(row[2].ToString());
                    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.conn.Close();
            }
            return TableNames;
        }

        public static List<List<string>> GetColumnLists()
        {
            List<string> tables = GetTables();
            List<List<string>> list = new List<List<string>>();

            for (int i = 0; i < tables.Count; i++)
            {
                string s = tables[i];
                list.Add(GetColumnString(s));
            }

            return list;
        }

        public static List<string> GetColumnString(string s)
        {
            DBConnect db = new DBConnect(connString);
            //MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = db.conn.CreateCommand();
            command.CommandText = "SELECT COLUMN_NAME FROM information_schema.COLUMNS C WHERE table_name = '" + s + "'";
            List<string> list = new List<string>();
            try
            {
                db.conn.Open();
                using (var reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                    //var table = reader.GetSchemaTable();
                    //foreach (DataColumn column in table.Columns)
                    //{
                    //    Console.WriteLine(column.ColumnName.ToString());
                    //    list.Add(column.ColumnName);
                    //}
                    foreach (var element in list)
                    {
                        Console.WriteLine(element);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { db.conn.Close(); }
            return list;
        }

        public string getConnString()
        {
            return connString;
        }
    }
}
