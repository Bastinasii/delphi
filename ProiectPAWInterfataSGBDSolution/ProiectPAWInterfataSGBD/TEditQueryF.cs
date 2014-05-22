using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.IO;


namespace ProiectPAWInterfataSGBD
{
    public partial class EditQueryF : Form
    {
        public static string connString = "user id=root;" +
                                   "password=;server=localhost;" +
                                   "database=paw; " +
                                   "connection timeout=10";
        public DataTable dataT = new DataTable();
        public static string tableName;
        public static List<string> tablecolumns;
        public static int rowcount;

        
        public EditQueryF()
        {
            InitializeComponent();
            //updateGrid();
            updateTables();
        }

        

        public static List<string> GetTables()
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        public static List<string> GetColumn()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT COLUMN_NAME FROM information_schema.COLUMNS C WHERE table_name = '"+ tableName +"'";
            List<string> list = new List<string>();
            try
            {
                conn.Open();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
            return list;
        }

        public void updateGrid()
        {
            
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM " +tableName+ ";";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                dataT = new DataTable();
                BindingSource bs = new BindingSource();
                sda.Fill(dataT);
                bs.DataSource = dataT;
                dataGridView1.DataSource = bs;
                sda.Update(dataT);
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        public void updateGridCommand(string com)
        {
            //string connString = "user id=Tanase;" +
            //                       "password=badabing;server=localhost;" +
            //                       "database=test1; " +
            //                       "connection timeout=10";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = com;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                dataT = new DataTable();
                BindingSource bs = new BindingSource();
                sda.Fill(dataT);
                bs.DataSource = dataT;
                dataGridView1.DataSource = bs;
                sda.Update(dataT);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        public void updateTables()
        {
            refreashTabel();
            List<string> tabel = new List<string>();
            tabel = GetTables();
            foreach (var element in tabel)
            {
                ListViewItem nou = new ListViewItem();
                nou.SubItems.Add(element);
                listView1.Items.Add(nou);
            }
            
        }

        public void refreashTabel()
        {
            
                listView1.Items.Clear();
            
        }

        public void afisareOutput()
        {
            //refreashOutput();
            //int m = coloane.Count();
            //for(int i=0;i<m;i++){
            //    listViewOutputSQLEditor.Columns[i + 1].Text = coloane[i];
            //}
            
            //int n = output.Count();
            //for(int i=0;i<n;i++)
            //{
            //    ListViewItem nou = new ListViewItem();
            //    foreach (var element in output[i])
            //    {

            //        nou.SubItems.Add(element);

                    
            //    }
            //    listViewOutputSQLEditor.Items.Add(nou);
            //}
        }

        public void refreashOutput()
        {
            //for (int i = 0; i < listViewOutputSQLEditor.Items.Count; i++)
            //{
            //    listViewOutputSQLEditor.Items[i].Remove();
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void runSQLScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveSQLScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void listViewTabeleSQLEditor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisareOutput();
        }

        private void saveCurrentOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<string> list = new List<string>();
            //string text="";
            //int n = listViewOutputSQLEditor.Items.Count;
            //for(int i=0;i<n;i++)
            //{
            //    int m = listViewOutputSQLEditor.Items[i].SubItems.Count; 
            //    for(int j=0;j<m;j++)
            //    {
            //        text += listViewOutputSQLEditor.Items[i].SubItems[j].Text + "  ";
            //    }
            //    text += "\r\n";
            //}
            //string[] data = Regex.Split(text, "\r\n");
            //foreach (var element in data)
            //{
            //    list.Add(element);
            //}
            //TSaveQuery save = new TSaveQuery(list);
            //save.SaveToFile();
        }

        private void refreashGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            updateGridCommand(textBox1.Text);
        }

        private void EditQueryF_Load(object sender, EventArgs e)
        {

        }

        private void testSaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(rowcount);
            for (int i = rowcount-1; i < dataGridView1.Rows.Count-1; i++)
            {
                insertGrid(i);
            }
            rowcount = dataGridView1.Rows.Count;
            
        }

        public void insertGrid(int n)
        {
            int i=n;
            int j, m;
            try
            {
                Console.WriteLine("Click");
                    MySqlConnection conn = new MySqlConnection(connString);
                    MySqlCommand command = conn.CreateCommand();
                    string com = "insert into `" + tableName + "` (";
                    m = tablecolumns.Count;
                    for (j = 0; j < m;j++)
                    {
                        if (j == m - 1)
                        {
                            com += "`" + tablecolumns[j] + "`) ";
                        }
                        else
                        {
                            com += "`" + tablecolumns[j] + "`, ";
                        }
                    }
                    com += "values (";
                    for (j = 0; j < m; j++)
                    {
                        if (j == m - 1)
                        {
                            com += "'" + dataGridView1.Rows[i].Cells[j].Value + "') ";
                        }
                        else
                        {
                            com += "'" + dataGridView1.Rows[i].Cells[j].Value + "', ";
                        }
                    }
                    //com += "values (" + dataGridView1.Rows[i].Cells[0].Value + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + ")";
                        command = new MySqlCommand(com, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    label1.Text = "Records inserted successfully";

                
            }
            catch (Exception ex)
            {
                String s = ex.Message;
                String [] a = s.Split(';');
                String[] b = s.Split(' ');
                String p1 = "You have an error in your SQL syntax";
                String p2 = "Duplicate";
                //Console.WriteLine(a[0]);
                if(a[0]!=p1 && b[0]!=p2){
                MessageBox.Show(ex.Message);
                label1.Text = "Error!";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Index = dataGridView1.CurrentCell.ColumnIndex;
            string name = dataGridView1.Columns[Index].Name;
            string command = "Select "+name+" from angajati;";
            textBox1.Text = command;
            updateGridCommand(textBox1.Text);
        }

        private void refreashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTables();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Click");
            //int i = this.listView1.SelectedIndices[0];
            //textBox1.Text = this.listView1.Items[i].SubItems[1].Text;
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedItems[0].Index;
                //tableName = listView1.SelectedItems[i].Text;
                tableName = listView1.Items[i].SubItems[1].Text;
                Console.WriteLine(tableName);
                updateGrid();
                //listView1.SelectedItems
            //    this.listView1.Focus();
            //    this.listView1.Items[0].Selected = true;
                
            }
            rowcount=dataGridView1.Rows.Count;
            tablecolumns = GetColumn();
            Console.WriteLine(rowcount);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //tableName = this.listView1.Items[1].SubItems[1].Text;
            //Console.WriteLine(tableName);
        }

        private void testQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetColumn();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Test!");
            Console.WriteLine(dataGridView1.CurrentCell.RowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void updateG(int n)
        {
            int i = n;
            int j, m;
            try
            {
                Console.WriteLine("Click");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                string com = "update `" + tableName + "` (";
                m = tablecolumns.Count;
                for (j = 0; j < m; j++)
                {
                    if (j == m - 1)
                    {
                        com += "`" + tablecolumns[j] + "`) ";
                    }
                    else
                    {
                        com += "`" + tablecolumns[j] + "`, ";
                    }
                }
                com += "values (";
                for (j = 0; j < m; j++)
                {
                    if (j == m - 1)
                    {
                        com += "'" + dataGridView1.Rows[i].Cells[j].Value + "') ";
                    }
                    else
                    {
                        com += "'" + dataGridView1.Rows[i].Cells[j].Value + "', ";
                    }
                }
                //com += "values (" + dataGridView1.Rows[i].Cells[0].Value + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + ")";
                command = new MySqlCommand(com, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                label1.Text = "Records inserted successfully";


            }
            catch (Exception ex)
            {
                String s = ex.Message;
                String[] a = s.Split(';');
                String[] b = s.Split(' ');
                String p1 = "You have an error in your SQL syntax";
                String p2 = "Duplicate";
                //Console.WriteLine(a[0]);
                if (a[0] != p1 && b[0] != p2)
                {
                    MessageBox.Show(ex.Message);
                    label1.Text = "Error!";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                string com = "drop table `" + tableName + "`";
                command = new MySqlCommand(com, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                label1.Text = "Table has been dropped";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PopulareTreeView f2 = new PopulareTreeView();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
