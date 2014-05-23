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
    public partial class Create : Form
    {
        private  string connString;
        private string dbname;
        private List<TextBox> textList = new List<TextBox>();
        private List<ComboBox> typeList = new List<ComboBox>();
        private List<TextBox> sizeList = new List<TextBox>();
        private int x = 0;
        private string comanda;
        public Create()
        {
            InitializeComponent();
            addColumn();
            Console.WriteLine(creareStringComanda());
        }
        public Create(string s,string d)
        {
            InitializeComponent();
            connString = s;
            dbname = d;
            addColumn();
            Console.WriteLine(creareStringComanda());
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        public void addColumn()
        {
            
            if (textList.Count<10)
            {
                
                    Label nlabel = new Label();
                    nlabel.Text = "Nume coloana: ";
                    nlabel.Location = new Point(50, 35+x);

                    TextBox ntext = new TextBox();
                    ntext.Location = new Point(50, 60+x);

                    Label vlabel = new Label();
                    vlabel.Text = "Tip: ";
                    vlabel.Location = new Point(50 + nlabel.Width+30, 35 + x);

                    ComboBox vcombo = new ComboBox();
                    vcombo.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
                    //vcombo.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
                    vcombo.Items.Add("VARCHAR");
                    vcombo.Items.Add("INT");
                    vcombo.Items.Add("DATE");
                    vcombo.Items.Add("BOOL");
                    vcombo.Location = new Point(50 + ntext.Width + 30, 60 + x);

                    Label slabel = new Label();
                    slabel.Text = "Marime: ";
                    slabel.Location = new Point(50 + nlabel.Width + vlabel.Width + 60 , 35 + x);
                    
                    TextBox stext = new TextBox();
                    stext.Location = new Point(50 + ntext.Width + vcombo.Width +60, 60 + x);
                    

                    //adaugare pe formular
                    this.Controls.Add(nlabel);
                    this.Controls.Add(vlabel);
                    this.Controls.Add(slabel);
                    this.Controls.Add(ntext);
                    this.Controls.Add(vcombo);
                    this.Controls.Add(stext);

                    //adaugare in lista controale

                    textList.Add(ntext);

                    typeList.Add(vcombo);

                    sizeList.Add(stext);

                    //redimensionare formular
                    this.Height = x + 60 + ntext.Height + 40;

                    x += 60;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addColumn();
        }

        private void removeColumn()
        {
            int i = textList.Count;
            if(i<2){

            }else{
            Console.WriteLine(i);
            Console.WriteLine(textList[i - 1]);
            this.Height += -50;
            x += -60;
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls.RemoveAt(this.Controls.Count - 1);

            textList.RemoveAt(i - 1);
            typeList.RemoveAt(i - 1);
            sizeList.RemoveAt(i - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeColumn();
        }

        private string creareStringComanda()
        {
            //CREATE TABLE example ( id INT, data VARCHAR(100) 
            string s = "CREATE TABLE "+textBox1.Text+" ( ";
            int n=textList.Count;
            for (int i = 0; i < n;i++)
            {
                if (sizeList[i].Text == "None")
                {
                    if (i != n - 1)
                    { s += textList[i].Text + " " + typeList[i].Text +  ", "; }
                    else
                    {
                        s += textList[i].Text + " " + typeList[i].Text  + ")";
                    }
                }
                else
                {
                    if (i != n - 1)
                    { s += textList[i].Text + " " + typeList[i].Text + "(" + sizeList[i].Text + ") " + ", "; }
                    else
                    {
                        s += textList[i].Text + " " + typeList[i].Text + "(" + sizeList[i].Text + ") " + ")";
                    }
                }
            }
            //s += " USE " + dbname + ";";

            return s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect(connString);
            try
            {
                Console.WriteLine(creareStringComanda());
                comanda = creareStringComanda();

                
                MySqlCommand com=new MySqlCommand(comanda,db.conn);
                db.conn.Open();
                com.ExecuteNonQuery();
                label2.Text = "Done";
            }catch(Exception ex)
            {
                label2.Text = "Error";
                MessageBox.Show(ex.Message);
            }finally{
                db.conn.Close();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            
            Console.WriteLine(combo.SelectedText);
            if(combo.SelectedText=="BOOL" || combo.SelectedText=="DATE")
            {
                int i = typeList.FindIndex(item => item == combo);
                TextBox text =sizeList[i];
                text.Text = "None";
                text.Enabled = false;
            }
            else
            {
                int i = typeList.FindIndex(item => item == combo);
                TextBox text = sizeList[i];
                text.Text = "";
                text.Enabled = true;
            }
            

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        


    }
}
