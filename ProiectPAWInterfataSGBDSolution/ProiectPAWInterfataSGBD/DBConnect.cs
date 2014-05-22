using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAWInterfataSGBD
{
    public class DBConnect
    {
        public MySqlConnection conn;
            private string server;
            private string database;
            private string uid;
            private string pwd;

    //Constructor
            public DBConnect()
            {
                Initialize();
            }

            public DBConnect(string c)
            {
                InitializeString(c);
            }

        public void InitializeString(string c)
            {
                conn = new MySqlConnection(c);
            }

    //Initialize values
            private void Initialize()
            {
                server = "localhost";
                database = "paw";
                uid = "test";
                pwd = "123456";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pwd + ";";

                conn = new MySqlConnection(connectionString);
            }

            //open connection to database
            private bool OpenConnection()
            {
                
                try
                {
                    conn.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }


            

            //Close connection
            private bool CloseConnection()
            {
                try
                {
                    conn.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

           
    }
}
