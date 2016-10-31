using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.ComponentModel;

namespace ERP
{
    public class DbConnect
    {
        private SqlConnection connection;
        public DataTable dt = new DataTable();
        public string batchid = "";
        public string conString = "";



        public DbConnect()
        {
            //Initialze connection with connectionString
            conString = "Data Source = 192.168.2.15\\SQLEXPRESS; Initial Catalog = IA5-5-16; User ID = sa; Password = " + "netlab_1";
            connection = new SqlConnection(conString);
            dt.Columns.Add("TypeOfCup", typeof(int));
            dt.Columns.Add("OrderedWeight", typeof(int));
            dt.Columns.Add("BatchID", typeof(int));
        }
        public bool PingHost()
        {
            string nameOrAddress = "192.168.2.15";
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
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

        public void InsertDataIntoDB(int cupID, int measuredWeight, bool approved)
        {
            try
            {
                    string query = "UPDATE ActualWeight, INTO CupOrdre(TypeOfCup, OrderedWeight, BatchID)VALUES(@typeOfCup, @orderedWeight, @batchID);";
                    if (OpenConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@typeOfCup", typeOfCup);
                            cmd.Parameters.AddWithValue("@orderedWeight", fillLevel);
                            cmd.Parameters.AddWithValue("@batchID", batchid);
                            cmd.ExecuteNonQuery();
                            CloseConnection();
                        }
                    }

                
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void ArduinoDataToDb(byte[] data)
        {
            
            try
            {
                string query = "UPDATE CupOrdre SET ActualWeight = @ActualWeight, CompletedApproved = @CompletedApproved, CompletedDiscard = @CompletedDiscard WHERE CupID = @CupID";
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        OpenConnection();
                        cmd.Parameters.AddWithValue("@CupID", Convert.ToInt32(data[0]));
                        cmd.Parameters.AddWithValue("@ActualWeight",  Convert.ToDouble(data[1]));
                        cmd.Parameters.AddWithValue("@CompletedApproved", data[2]);
                        cmd.Parameters.AddWithValue("@CompletedDiscard", data[3]);
                        cmd.ExecuteNonQuery();
                        CloseConnection();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    
    }
}

