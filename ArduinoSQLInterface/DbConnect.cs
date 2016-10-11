using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ArduinoSQLInterface
{
    public class DbConnect
    {

        private string server;
        private string database;
        private string uid;
        private string password;
        private SqlConnection connection;

        public DbConnect()
        {
            server = "192.168.2.15";                                                    //Host
            database = "IA5-5-16";                                                      //Database
            uid = "sa";                                                                 //Username
            password = "netlab_1";                                                      //Password
            string connectionString;                                                    //Declare connectionString
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +                 //Format connectiongString
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new SqlConnection(connectionString);                           //Initialze connection with connectionString
        }
        public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Close();
                    connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool CloseConnection()
        {

            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        
    }
}
