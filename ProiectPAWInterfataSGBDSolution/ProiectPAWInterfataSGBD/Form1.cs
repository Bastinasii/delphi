using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingMondule
{
    public partial class Form1 : Form
    {

        DBConnect db = new DBConnect();
        public Form1()
        {
            InitializeComponent();
        }

        //public void loadChart()
        //{
            
        //}

        private void btn_chart_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT Count(*) FROM angajati";
            string query2 = "SELECT Count(*) FROM autori";
            string query3 = "SELECT Count(*) FROM carti";
            string query4 = "SELECT Count(*) FROM cititori";
            string query5 = "SELECT Count(*) FROM contacte";
            string query6 = "SELECT Count(*) FROM departamente";
            string query7 = "SELECT Count(*) FROM edituri";
            string query8 = "SELECT Count(*) FROM fise";
            int count1 = -1;
            int count2 = -1;
            int count3 = -1;
            int count4 = -1;
            int count5 = -1;
            int count6 = -1;
            int count7 = -1;
            int count8 = -1;

            using (MySqlCommand cmd1 = new MySqlCommand(query1, db.conn))
            {
                db.conn.Open();
                count1 = int.Parse(cmd1.ExecuteScalar().ToString());
            }


            using (MySqlCommand cmd2 = new MySqlCommand(query2, db.conn))
            {
                //db.conn.Open();
                count2 = int.Parse(cmd2.ExecuteScalar().ToString());
            }

            using (MySqlCommand cmd3 = new MySqlCommand(query3, db.conn))
            {
                //db.conn.Open();
                count3 = int.Parse(cmd3.ExecuteScalar().ToString());
            }

            using (MySqlCommand cmd4 = new MySqlCommand(query4, db.conn))
            {
                //db.conn.Open();
                count4 = int.Parse(cmd4.ExecuteScalar().ToString());
            }

            using (MySqlCommand cmd5 = new MySqlCommand(query5, db.conn))
            {
                //db.conn.Open();
                count5 = int.Parse(cmd5.ExecuteScalar().ToString());
            }

            using (MySqlCommand cmd6 = new MySqlCommand(query6, db.conn))
            {
                //db.conn.Open();
                count6 = int.Parse(cmd6.ExecuteScalar().ToString());
            }


            using (MySqlCommand cmd7 = new MySqlCommand(query7, db.conn))
            {
                //db.conn.Open();
                count7 = int.Parse(cmd7.ExecuteScalar().ToString());
            }

            using (MySqlCommand cmd8 = new MySqlCommand(query8, db.conn))
            {
                //db.conn.Open();
                count8 = int.Parse(cmd8.ExecuteScalar().ToString());
            }

            this.chart1.Series["Number of records"].Points.AddXY("Angajati", count1);
            this.chart1.Series["Number of records"].Points.AddXY("Autori", count2);
            this.chart1.Series["Number of records"].Points.AddXY("Carti", count3);
            this.chart1.Series["Number of records"].Points.AddXY("Cititor", count4);
            this.chart1.Series["Number of records"].Points.AddXY("Contacte", count5);
            this.chart1.Series["Number of records"].Points.AddXY("Departamente", count6);
            this.chart1.Series["Number of records"].Points.AddXY("Edituri", count7);
            this.chart1.Series["Number of records"].Points.AddXY("Fise", count8);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }
    }
}
