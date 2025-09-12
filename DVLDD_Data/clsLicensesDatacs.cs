using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsLicensesDatacs
    {
        public static int AddLicenseData(int applicationid,int driverid, int licenseclass,
           DateTime issuedate, DateTime exdate, string notes, int fees, bool isactive, int issuereason,int userid)
        {
            int id = -1;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Licenses VALUES (@applicationid, @driverid, @licenseclass, @issuedate, @exdate, @notes, @fees, @isactive , @issuereason,@userid); SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationid", applicationid);
            command.Parameters.AddWithValue("@driverid", driverid);
            command.Parameters.AddWithValue("@licenseclass", licenseclass);
            command.Parameters.AddWithValue("@issuedate", issuedate);
            command.Parameters.AddWithValue("@exdate", exdate);
            if (notes != "")
            {
                command.Parameters.AddWithValue("@notes", notes);
            }
            else
                command.Parameters.AddWithValue("@notes", System.DBNull.Value);

            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@isactive", isactive);
            command.Parameters.AddWithValue("@issuereason", issuereason);
            command.Parameters.AddWithValue("@userid", userid);

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

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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


            return LicenseID;
        }

        public static bool FindLicenseData(ref int licenseid ,int applicationid,ref int driverid,ref int licenseclass,
           ref DateTime issuedate,ref DateTime exdate,ref string notes,ref int fees,ref bool isactive,ref int issuereason,ref int userid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Licenses WHERE ApplicationID = @applicationid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationid", applicationid);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    licenseid = (int)reader["LicenseID"];
                    driverid = (int)reader["DriverID"];
                    licenseclass = (int)reader["LicenseClass"];
                    issuedate = (DateTime)reader["IssueDate"];
                    exdate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                        notes = "No Notes";

                    fees = Convert.ToInt32(reader["PaidFees"]);
                    isactive = (bool)reader["IsActive"];
                    issuereason = Convert.ToInt16(reader["IssueReason"]);
                    userid = (int)reader["CreatedByUserID"];

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

        public static DataTable GetLicensesList(int driverid)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Licenses WHERE DriverID = @driverid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driverid", driverid);

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

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static bool FindLicenseByIDData(int licenseid,ref int applicationid, ref int driverid, ref int licenseclass,
           ref DateTime issuedate, ref DateTime exdate, ref string notes, ref int fees, ref bool isactive, ref int issuereason, ref int userid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @licenseid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseid", licenseid);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    applicationid = (int)reader["ApplicationID"];
                    driverid = (int)reader["DriverID"];
                    licenseclass = (int)reader["LicenseClass"];
                    issuedate = (DateTime)reader["IssueDate"];
                    exdate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                        notes = "No Notes";

                    fees = Convert.ToInt32(reader["PaidFees"]);
                    isactive = (bool)reader["IsActive"];
                    issuereason = Convert.ToInt16(reader["IssueReason"]);
                    userid = (int)reader["CreatedByUserID"];

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

        public static bool UpdateIsctiveData(int licenseid, bool isactive)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE Licenses SET IsActive = @isactive WHERE LicenseID = @licenseid ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@licenseid", licenseid);
            command.Parameters.AddWithValue("@isactive", isactive);

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

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"UPDATE Licenses
                           SET ApplicationID=@ApplicationID, DriverID = @DriverID,
                              LicenseClass = @LicenseClass,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              Notes = @Notes,
                              PaidFees = @PaidFees,
                              IsActive = @IsActive,IssueReason=@IssueReason,
                              CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
