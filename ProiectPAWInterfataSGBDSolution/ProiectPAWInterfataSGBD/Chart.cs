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

namespace ProiectPAWInterfataSGBD
{
    public partial class Chart : Form
    {
        public static List<string> tabelList = new List<string>();
        public static string connString;

        public static DBConnect db;
        public Chart()
        {
            InitializeComponent();
        }
        public Chart(string s)
        {
            InitializeComponent();
            connString = s;
            updateChart();
        }

        //public void loadChart()
        //{
            
        //}

        private void btn_chart_Click(object sender, EventArgs e)
        {
            updateChart();

        }

        public void updateChart()
        {
            tabelList = GetTables();

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            db = new DBConnect(connString);
            try
            {
                db.conn.Open();
                for (int i = 0; i < tabelList.Count; i++)
                {
                    string comandString = "SELECT COUNT(*) FROM ";
                    comandString += tabelList[i];
                    int count = 0;

                    using (MySqlCommand cmd1 = new MySqlCommand(comandString, db.conn))
                    {
                        //db.conn.Open();
                        count = int.Parse(cmd1.ExecuteScalar().ToString());
                    }
                    this.chart1.Series["Number of records"].Points.AddXY(tabelList[i], count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.conn.Close();
            }
        }

        public List<string> GetTables()
        {
            List<string> TableNames = new List<string>();
            try
            {
                //MySqlConnection connection = new MySqlConnection(connString)
                db = new DBConnect(connString);
                db.conn.Open();
                //using (db.conn.Open())
                //{
                    //connection.Open();
                    DataTable schema = db.conn.GetSchema("Tables");

                    foreach (DataRow row in schema.Rows)
                    {
                        TableNames.Add(row[2].ToString());
                    }

                ////}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.conn.Close();
            }
            //foreach (var element in TableNames)
            //{
            //    Console.WriteLine(element);
            //}

            return TableNames;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }
    }
}
