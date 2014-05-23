using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;

namespace ProiectPAWInterfataSGBD
{
    public partial class FormularPrincipal : Form
    {
        public static MDIParent fMDI;
        GroupBox group = new GroupBox();
        RadioButton radio1 = new RadioButton();
        RadioButton radio2 = new RadioButton();
        Label label1 = new Label();
        Label label2 = new Label();
        TextBox text1 = new TextBox();
        TextBox text2 = new TextBox();
        CheckBox check = new CheckBox();
        ComboBox combo1 = new ComboBox();
        ComboBox combo2 = new ComboBox();
        Label label3 = new Label();
        TextBox text3 = new TextBox();
        Label label4 = new Label();
        TextBox pass = new TextBox();
        Button button3 = new Button();
        Button button2 = new Button();
        Button rmButton1 = new Button();
        Button rmButton2 = new Button();

        XmlReadWrite dbConf = new XmlReadWrite();

        public FormularPrincipal()
        {
            InitializeComponent();
            this.Text = "Login";
            this.Size = new Size(600, 350);
            this.AcceptButton = button2;
            this.CancelButton = button3;

            this.group.Location = new Point(20, 20);
            this.group.Size = new Size(150, 90);
            this.group.Text = "Connection:";

            this.radio1.Text = "New Connection";
            this.radio1.Location = new Point(10, 20);
            this.radio1.Size = new Size(130, 30);

            this.radio2.Text = "Existing Connection";
            this.radio2.Location = new Point(10, 50);
            this.radio2.Size = new Size(130, 30);

            this.group.Controls.Add(radio1);
            this.group.Controls.Add(radio2);

            this.Controls.Add(group);

            this.label1.Location = new Point(200, 47);
            this.label1.Size = new Size(60, 20);
            this.label1.Text = "Server:";
            this.label1.Visible = false;
            this.Controls.Add(label1);

            this.text1.Location = new Point(270, 44);
            this.text1.Size = new Size(150, 20);
            this.text1.Visible = false;
            this.Controls.Add(text1);

            this.label2.Location = new Point(200, 77);
            this.label2.Size = new Size(60, 20);
            this.label2.Text = "Database:";
            this.label2.Visible = false;
            this.Controls.Add(label2);

            this.text2.Location = new Point(270, 74);
            this.text2.Size = new Size(150, 20);
            this.text2.Visible = false;
            this.Controls.Add(text2);

            this.combo1.Location = new Point(270, 44);
            this.combo1.Size = new Size(150, 20);
            this.combo1.Visible = false;
            this.combo1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combo1);

            this.combo2.Location = new Point(270, 74);
            this.combo2.Size = new Size(150, 20);
            this.combo2.Visible = false;
            this.combo2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combo2);

            this.rmButton1.Location = new Point(430, 74);
            this.rmButton1.Size = new Size(110, 20);
            this.rmButton1.Text = "Remove this entry";
            this.rmButton1.Visible = false;
            this.Controls.Add(rmButton1);

            this.rmButton2.Location = new Point(430, 44);
            this.rmButton2.Size = new Size(110, 20);
            this.rmButton2.Text = "Remove all entries";
            this.rmButton2.Visible = false;
            this.Controls.Add(rmButton2);

            this.check.Location = new Point(205, 107);
            this.check.Size = new Size(150, 20);
            this.check.Text = "Remember this connection";
            this.check.Visible = false;
            this.Controls.Add(check);

            this.label3.Location = new Point(203, 140);
            this.label3.Size = new Size(150, 20);
            this.label3.Text = "Username:";
            this.label3.Visible = false;
            this.Controls.Add(label3);

            this.text3.Location = new Point(205, 160);
            this.text3.Size = new Size(150, 20);
            this.text3.Visible = false;
            this.Controls.Add(text3);

            this.label4.Location = new Point(363, 140);
            this.label4.Size = new Size(150, 20);
            this.label4.Text = "Password:";
            this.label4.Visible = false;
            this.Controls.Add(label4);

            this.pass.Location = new Point(365, 160);
            this.pass.Size = new Size(150, 20);
            this.pass.Visible = false;
            this.pass.PasswordChar = '*';
            this.Controls.Add(pass);

            this.button2.Location = new Point(205, 190);
            this.button2.Size = new Size(310, 25);
            this.button2.Text = "Login";
            this.button2.Visible = false;
            this.Controls.Add(button2);

            this.button3.Location = new Point(465, 250);
            this.button3.Size = new Size(50, 20);
            this.button3.Text = "Exit";
            this.Controls.Add(button3);

            this.radio1.CheckedChanged += new EventHandler(this.choice);
            this.radio2.CheckedChanged += new EventHandler(this.choice);

            this.combo1.SelectedIndexChanged += new EventHandler(this.getDbs);
            
            this.button3.Click += new EventHandler(this.exit);

            this.button2.Click += new EventHandler(this.login);

            this.rmButton1.Click += new EventHandler(this.removeEntry);

            this.rmButton2.Click += new EventHandler(this.removeAllEntries);
        }

        void removeEntry(object sender, EventArgs e)
        {
            string entry;
            try
            {
                if (this.combo2.Items.Count <= 1)
                {
                    entry = this.combo1.Text;
                    dbConf.removeServer(entry);
                    //combo1.Items.Remove(entry);
                    combo1.DataSource = dbConf.readXml();
                    combo2.DataSource = dbConf.readXml(combo1.Text);
                }
                else
                {
                    string srv = this.combo1.Text;
                    entry = this.combo2.Text;
                    dbConf.removeDb(srv, entry);
                    //combo2.Items.Remove(entry);
                    combo2.DataSource = dbConf.readXml(combo1.Text);
                }
            }
            catch (Exception e2)
            {
            }
        }

        void removeAllEntries(object sender, EventArgs e)
        {
            try
            {
                File.Delete("config.xml");
                combo1.DataSource = dbConf.readXml();
                combo2.DataSource = dbConf.readXml(combo1.Text);
            }
            catch (Exception t)
            {
            }
        }

        void choice(object sender, EventArgs e)
        {
            if (this.radio1.Checked)
            {
                this.label1.Visible = true;
                this.text1.Text = "";
                this.text1.Visible = true;
                this.label2.Visible = true;
                this.text2.Text = "";
                this.text2.Visible = true;
                this.rmButton1.Visible = false;
                this.rmButton2.Visible = false;
                this.check.Checked = false;
                this.check.Visible = true;
                this.label3.Visible = true;
                this.text3.Text = "";
                this.text3.Visible = true;
                this.label4.Visible = true;
                this.pass.Text = "";
                this.pass.Visible = true;
                this.button2.Visible = true;
                this.combo1.Visible = false;
                this.combo1.Text = "";
                this.combo2.Visible = false;
                this.combo2.Text = "";
            }
            else if (this.radio2.Checked)
            {
                this.label1.Visible = true;
                this.combo1.Text = "";
                this.combo1.Visible = true;
                this.label2.Visible = true;
                this.combo2.Text = "";
                this.combo2.Visible = true;
                this.rmButton1.Visible = true;
                this.rmButton2.Visible = true;
                this.label3.Visible = true;
                this.text3.Text = "";
                this.text3.Visible = true;
                this.label4.Visible = true;
                this.pass.Text = "";
                this.pass.Visible = true;
                this.button2.Visible = true;
                this.text1.Visible = false;
                this.text1.Text = "";
                this.text2.Visible = false;
                this.text2.Text = "";
                this.check.Visible = false;
                this.check.Checked = false;
                //Console.Write("A intrat");
                combo1.DataSource = dbConf.readXml();
                combo2.DataSource = dbConf.readXml(combo1.Text);
            }
        }

        void getDbs(object sender, EventArgs e)
        {
            //Console.WriteLine(combo2.Text + "\n");
            combo2.DataSource = dbConf.readXml(combo1.Text);
        }

        void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        void login(object sender, EventArgs e)
        {
            //Console.WriteLine(combo1.Text);
            //Console.WriteLine(combo2.Text);
            //Console.WriteLine(text3.Text);
            //Console.WriteLine(pass.Text);
            string server;
            string database;
            if (this.radio1.Checked)
            {
                server = text1.Text;
                database = text2.Text;

                if (String.IsNullOrWhiteSpace(server) || String.IsNullOrWhiteSpace(database))
                {
                    MessageBox.Show("Trebuie introduse toate datele de conectare!");
                }
                else
                {
                    if (this.check.Checked)
                    {
                        if (!File.Exists("config.xml"))
                        {
                            dbConf.createXml();
                        }

                        if (!(dbConf.exists(server, database)))
                        {
                            if (!(dbConf.exists(server)))
                            {
                                dbConf.writeXml(server, database);
                            }
                            else
                            {
                                dbConf.writeXmlDb(server, database);
                            }
                        }
                    }
                }
            }
            else
            {
                server = combo1.Text;
                database = combo2.Text;
            }
            string user = text3.Text;
            string passwd = pass.Text;

            //EditQueryF f = new EditQueryF(server, database, user, passwd);
            //f.ShowDialog();

            if (!(String.IsNullOrWhiteSpace(server) || String.IsNullOrWhiteSpace(database)))
            {
                try
                {
                    fMDI = new MDIParent(server, database, user, passwd);
                    this.Hide();
                    fMDI.ShowDialog();
                    this.Show();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //EditQueryF f = new EditQueryF();
            //f.Show();
            //MDIParent f = new MDIParent();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            MDIParent f = new MDIParent();
            f.Show();
        }

        private void FormularPrincipal_Load(object sender, EventArgs e)
        {

        }



    }
}
