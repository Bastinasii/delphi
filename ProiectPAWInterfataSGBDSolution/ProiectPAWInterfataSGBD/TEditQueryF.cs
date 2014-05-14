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

namespace ProiectPAWInterfataSGBD
{
    public partial class EditQueryF : Form
    {
        static List<string> tabele = new List<string>();
        static List<List<string>> output = new List<List<string>>();
        static List<string> coloane = new List<string>();
        public EditQueryF()
        {
            InitializeComponent();
            updateGrid();
        }

        public void updateGrid()
        {
            string connString = "user id=Tanase;" +
                                   "password=badabing;server=localhost;" +
                                   "database=test1; " +
                                   "connection timeout=10";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM ANGAJATI;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dataT = new DataTable();
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
            string connString = "user id=Tanase;" +
                                   "password=badabing;server=localhost;" +
                                   "database=test1; " +
                                   "connection timeout=10";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = com;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dataT = new DataTable();
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

        public void afisareTabele()
        {
            //foreach(var element in tabele)
            //{
            //    ListViewItem nou = new ListViewItem();
            //    nou.SubItems.Add(element);
            //    listViewTabeleSQLEditor.Items.Add(nou);
            //}
        }

        public void refreashTabele()
        {
            //for (int i = 0; i < listViewTabeleSQLEditor.Items.Count; i++)
            //{
            //    listViewTabeleSQLEditor.Items[i].Remove();
            //}
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
            List<string> list = new List<string>();
            string text = textBox1.Text;
            //string [] data = text.Split('\n');
            string[] data = Regex.Split(text, "\r\n");
            foreach (var element in data)
            {
                list.Add(element);
            }
            TSaveQuery save = new TSaveQuery(list);
            save.SaveToFile();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            string text = textBox1.Text;
            //string [] data = text.Split('\n');
            string[] data = Regex.Split(text, "\r\n");
            foreach (var element in data)
            {
                list.Add(element);
            }
            TSaveQuery save = new TSaveQuery(list);
            save.SaveToFile();
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
    }
}
