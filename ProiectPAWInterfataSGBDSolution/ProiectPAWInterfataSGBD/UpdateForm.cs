using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace ProiectPAWInterfataSGBD
{
    public partial class UpdateForm : Form
    {
        private  List<string> colName = new List<string>();
        private  List<string> varCells = new List<string>();
        private  List<string> newVarCells = new List<string>();
        private ArrayList textBoxList=new ArrayList();
        private  string tableName;
        private string connString;

        public UpdateForm()
        {
            InitializeComponent();
        }

        public UpdateForm(List<string> c, List<string> v,string s,string t)
        {
            InitializeComponent();
            colName = c;
            varCells = v;
            connString = s;
            tableName = t;
            Initiate();
        }

        private void Initiate()
        {
            int x = 0;
            if (colName.Count != 0)
            {
                for (int i = 0; i < colName.Count; i++)
                {
                    Label mylabel = new Label();
                    mylabel.Text = colName[i];
                    mylabel.Location = new Point(50 + x,30);
                    TextBox mytext = new TextBox();
                    mytext.Text = varCells[i];
                    mytext.Location = new Point(50 + x, 50);

                    //adaugare pe formular
                    this.Controls.Add(mylabel);
                    this.Controls.Add(mytext);

                    //adaugare in lista controale
                    
                    textBoxList.Add(mytext);

                    //redimensionare formular
                    this.Width = x + 50 + mytext.Width + 40;

                    x += 120;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect(connString);
            MySqlCommand com = new MySqlCommand(getCommandString(), db.conn);
            Console.WriteLine(getCommandString());
            try
            {
                db.conn.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.conn.Close();
                this.Close();
            }
        }

        public string getCommandString()
        {
            string s = "UPDATE `"+tableName+"` SET ";
            foreach(TextBox element in textBoxList)
            {
                newVarCells.Add(element.Text);
            }
            int m = colName.Count;

            for (int i = 0; i < m; i++)
            {
                string v = newVarCells[i];
                if (v == "True" || s == "False")
                {
                    if (i != m - 1)
                    {
                        s += "" + colName[i] + "=";
                        s += "" + newVarCells[i] + ",";
                    }
                    else
                    {
                        s += "" + colName[i] + "=";
                        s += "" + newVarCells[i] + " ";
                    }
                }
                else
                {
                    if (v.ToLowerInvariant().Contains("/"))
                    {
                        Console.WriteLine("A intrat unde trebuie");
                        
                        if (i == m - 1)
                        {
                            s += "" + colName[i] + "=";
                            s += "DATE(STR_TO_DATE(";
                            s += "'" + newVarCells[i] + "'," + "'%m/%d/%Y" + "')) ";
                        }
                        else
                        {
                            s += "" + colName[i] + "=";
                            s += "DATE(STR_TO_DATE(";
                            s += "'" + newVarCells[i] + "'," + "'%m/%d/%Y" + "')), ";
                        }
                    }else{
                    if (i != m - 1)
                    {
                        s += "" + colName[i] + "=";
                        s += "'" + newVarCells[i] + "',";
                    }
                    else
                    {
                        s += "" + colName[i] + "=";
                        s += "'" + newVarCells[i] + "' ";
                    }
                    }
                }
            }
            string v2 = varCells[0];
            if (v2.ToLowerInvariant().Contains("/"))
            {
                //+ colName[0] + "="
                s += "WHERE "  + "DATE(STR_TO_DATE(" + "'" + varCells[0] + "'," + "'%m/%d/%Y" + "')) <> '0000-00-00'";
            }
            else
            {
                s += "WHERE " + colName[0] + "=" + varCells[0];
                
            }

                return s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
