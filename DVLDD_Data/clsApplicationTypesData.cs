using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsApplicationTypesData
    {

        public static DataTable GetApplicationTypesData()
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM ApplicationTypes";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }



            return dt;
        }

        public static bool FindApp(int appid , ref string appname , ref double appfees)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            bool isfound = false;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @appid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@appid", appid);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    appname = (string)reader["ApplicationTypeTitle"];
                    appfees = Convert.ToDouble(reader["ApplicationFees"]);
                    isfound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isfound;

        }

        public static bool UpdateAppData(int appid, string appname , double appfees)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @appname , ApplicationFees = @appfees WHERE ApplicationTypeID = @appid";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@appid", appid);
            command.Parameters.AddWithValue("@appname", appname);
            command.Parameters.AddWithValue("@appfees", appfees);
            
            try
            {
                connection.Open();

                rowsaffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsaffected > 0);
        }

    }
}
