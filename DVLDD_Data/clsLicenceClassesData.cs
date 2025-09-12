using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsLicenceClassesData
    {
        public static DataTable GetLicenceClassesListData()
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM LicenseClasses";

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

        public static bool Find(int licenseid , ref string classname , ref string classdesc, ref int minage,
            ref int validity , ref int fees)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @licenseid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseid", licenseid);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    classname = (string)reader["ClassName"];
                    classdesc = (string)reader["ClassDescription"];
                    minage = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    validity = Convert.ToInt32(reader["DefaultValidityLength"]);
                    fees = Convert.ToInt32(reader["ClassFees"]);

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

        public static bool Find(ref int licenseid,string classname, ref string classdesc, ref int minage,
            ref int validity, ref int fees)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @classname";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classname", classname);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    licenseid = (int)reader["LicenseClassID"];
                    classdesc = (string)reader["ClassDescription"];
                    minage = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    validity = Convert.ToInt32(reader["DefaultValidityLength"]);
                    fees = Convert.ToInt32(reader["ClassFees"]);

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

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            int MinimumAllowedAge, int DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"Insert Into LicenseClasses 
           (
            ClassName,ClassDescription,MinimumAllowedAge, 
            DefaultValidityLength,ClassFees)
                            Values ( 
            @ClassName,@ClassDescription,@MinimumAllowedAge, 
            @DefaultValidityLength,@ClassFees)
                            where LicenseClassID = @LicenseClassID;
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseClassID;

        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            int MinimumAllowedAge, int DefaultValidityLength, float ClassFees)
        {

            int rowsAffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"Update  LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
