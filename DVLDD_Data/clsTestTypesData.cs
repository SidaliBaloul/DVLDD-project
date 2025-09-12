using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsTestTypesData
    {
        public static DataTable GetAllTestTypesData()
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM TestTypes";

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

        public static bool Find(int testid , ref string testname , ref string testdesc , ref double testfees)


        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            bool isfound = false;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @testid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testid", testid);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    testname = (string)reader["TestTypeTitle"];
                    testdesc = (string)reader["TestTypeDescription"];
                    testfees = Convert.ToDouble(reader["TestTypeFees"]);
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

        public static bool UpdateTestData(int testid , string testname, string testdesc, double testfees)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE TestTypes SET TestTypeTitle = @testname ,TestTypeDescription = @testdesc, TestTypeFees = @testfees WHERE TestTypeID = @testid";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testid", testid);
            command.Parameters.AddWithValue("@testname", testname);
            command.Parameters.AddWithValue("@testdesc", testdesc);
            command.Parameters.AddWithValue("@testfees", testfees);

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
