using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Data
{
    public static class clsDetatinedLicensesData
    {

        public static DataTable GetDetainedLicensesData()
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM detainedLicenses_View";

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

        public static DataTable FilterDetainedLicensesData(string combotext, string boxtext)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dp = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM DetainedLicensesView WHERE " + combotext + " LIKE  @boxtext + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@boxtext", boxtext);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dp.Load(reader);

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

            return dp;
        }

        public static bool IsLicenseAlreadyDetained(int licenseid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM DetainedLicenses WHERE LicenseID = @licenseid AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseid", licenseid);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isfound = true;
                }
                else
                    isfound = false;


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

        public static int AddDetainedLicense(int LicenseID, DateTime DetainDate,float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"INSERT INTO dbo.DetainedLicenses
                               (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                            VALUES
                               (@LicenseID,
                               @DetainDate, 
                               @FineFees, 
                               @CreatedByUserID,
                               0
                             );
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
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


            return DetainID;

        }

        public static bool Find(ref int detainid, int licenseid, ref DateTime detaindate, ref int fees, ref int userid,
                ref bool isreleased, ref DateTime releaseddate, ref int releaseduserid, ref int releasappid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseid",licenseid);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    detainid = (int)reader["DetainID"];
                    detaindate = (DateTime)reader["DetainDate"];
                    fees = Convert.ToInt16(reader["FineFees"]);
                    userid = (int)reader["CreatedByUserID"];
                    isreleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] != System.DBNull.Value)
                    {
                        releaseddate = (DateTime)reader["ReleaseDate"];
                    }
                    else
                        releaseddate = DateTime.Now;


                    if (reader["ReleasedByUserID"] != System.DBNull.Value)
                    {
                        releaseduserid = (int)reader["ReleasedByUserID"];
                    }
                    else
                        releaseduserid = 0;


                    if (reader["ReleaseApplicationID"] != System.DBNull.Value)
                    {
                        releasappid = (int)reader["ReleaseApplicationID"];
                    }
                    else
                        releasappid = 0;


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

        public static bool GetDetainedLicenseInfoByID(int DetainID,
          ref int LicenseID, ref DateTime DetainDate,
          ref int FineFees, ref int CreatedByUserID,
          ref bool IsReleased, ref DateTime ReleaseDate,
          ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToInt16(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

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


        public static bool Update(int detainid, int licenseid, DateTime detaindate, int fees,int userid,
                bool isreleased,DateTime releaseddate, int releaseduserid,int releasappid)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE DetainedLicenses SET IsReleased = @isreleased, ReleaseDate = @releaseddate, ReleasedByUserID = @releaseduserid, ReleaseApplicationID = @releaseappid WHERE DetainID = @detainid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@detainid", detainid);
            command.Parameters.AddWithValue("@isreleased", isreleased);
            command.Parameters.AddWithValue("@releaseddate", releaseddate);
            command.Parameters.AddWithValue("@releaseduserid", releaseduserid);
            command.Parameters.AddWithValue("@releaseappid", releasappid);

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

        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
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

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
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


            return IsDetained;
            ;

        }

    }
}
