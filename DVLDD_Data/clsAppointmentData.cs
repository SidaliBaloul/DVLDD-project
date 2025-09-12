using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsAppointmentData
    {
        public static DataTable GetAppointmentListData(int testid, string nationalno, string classname)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM TestAppointments_View";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testid", testid);
            command.Parameters.AddWithValue("@nationalno", nationalno);
            command.Parameters.AddWithValue("@classname", classname);

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

        public static int AddppointmentData(int testtypeid ,int LDappid, double fees, DateTime date, int userid,
            bool islocked, int RetakeTestApplicationID)
        {
            int id = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO TestAppointments VALUES (@testtypeid ,@ldappid ,@date ,@fees ,@userid ,@islocked,@RetakeTestApplicationID); SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testtypeid", testtypeid);
            command.Parameters.AddWithValue("@ldappid", LDappid);
            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@islocked", islocked);

            if (RetakeTestApplicationID == -1 || RetakeTestApplicationID == 0)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inseted))
                {
                    id = inseted;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return id;
        }

        public static bool UpdateAppointmentData(int appointmentid , DateTime date)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE TestAppointments SET AppointmentDate = @date  WHERE TestAppointmentID = @appointmentid ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@appointmentid", appointmentid);
            command.Parameters.AddWithValue("@date", date);

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

        public static bool Find(int appointmentid ,ref int testtypeid,ref int LDappid,ref double fees,ref DateTime date,ref int userid,ref bool islocked)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @appointmentid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@appointmentid", appointmentid);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    testtypeid = (int)reader["TestTypeID"];
                    LDappid = (int)reader["LocalDrivingLicenseApplicationID"];
                    fees = Convert.ToDouble(reader["PaidFees"]);
                    islocked = (bool)reader["IsLocked"];

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

        public static bool GetLastTestAppointment(
             int LocalDrivingLicenseApplicationID, int TestTypeID,
            ref int TestAppointmentID, ref DateTime AppointmentDate,
            ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"SELECT       top 1 *
                FROM            TestAppointments
                WHERE        (TestTypeID = @TestTypeID) 
                AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                order by TestAppointmentID Desc";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static void UpdateIsLocked(int appointmentid)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE TestAppointments SET IsLocked = 1  WHERE TestAppointmentID = @appointmentid ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@appointmentid", appointmentid);


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

        }

        public static bool DeleteAppointment(int ldappid)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "DELETE TestAppointments WHERE LocalDrivingLicenseApplicationID = @ldappid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ldappid", ldappid);


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

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;

        }

    }
}
