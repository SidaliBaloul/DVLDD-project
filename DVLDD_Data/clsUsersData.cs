using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsUsersData
    {

        public static DataTable GetAllUsersData()
        {
            DataTable dt = new DataTable();
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsUserExist(string username)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM Users WHERE UserName = @username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);

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
        public static bool IsUserExist(int userid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM Users WHERE UserID = @userid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userid", userid);

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

        public static DataTable GetUsersListData()
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Users";
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

        public static DataTable FilterUsersData(string combotext, string boxtext)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dp = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM UsersView WHERE " + combotext + " LIKE  @boxtext + '%'";

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

        public static DataTable GetActiveOrDesactiveData(byte num)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dp = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM UsersView WHERE IsActive = @num";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@num", num);

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

        public static bool FindUser(int userid , ref int personid , ref string username , ref string password , ref bool isactive)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Users WHERE UserID = @userid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userid", userid);

            try
            {
                connection.Open(); 
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    personid = (int)reader["PersonID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isactive = (bool)reader["IsActive"];

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

        public static bool FindByPersonID( ref int userid, int personid, ref string username, ref string password, ref bool isactive)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Users WHERE PersonID = @personid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personid", personid);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userid = (int)reader["UserID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isactive = (bool)reader["IsActive"];

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

        public static bool FindUserByUsernameAndPassword(ref int userid, ref int personid, string username, string password, ref bool isactive)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Users WHERE UserName = @username AND Password = @password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userid = (int)reader["UserID"];
                    personid = (int)reader["PersonID"];
                    isactive = (bool)reader["IsActive"];

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
        public static int AddUserData(int personid , string username,string password,bool isactive)
        {
            int id = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT Users VALUES (@personid ,@username ,@password ,@isactive); SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isactive", isactive);

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

        public static bool UpdateUserData(int userid ,int personid, string username, string password, bool isactive)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE Users SET PersonID = @personid ,UserName = @username ,Password = @password ,IsActive = @isactive WHERE UserID = @userid ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
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

        public static bool IsPersonIDAttached(int personid)
        {
            bool isfound = false;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM Users WHERE PersonID = @personid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personid", personid);

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

        public static bool DeleteUserData(int UserID)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "DELETE Users WHERE UserID = @userid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userid", UserID);


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
