using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;

namespace DVLD_Data
{
    
    public static class clsPersonData
    {

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query =
              @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";




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

        public static DataTable FilterPeople(string combotext , string boxtext)
        {
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";
            DataTable dp = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM View1 WHERE " + combotext + " LIKE  @boxtext + '%'";

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

        public static bool IsPersonExist(string nationalno)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM People WHERE NationalNo = @nationalno";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalno", nationalno);

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
        public static bool IsPersonExist(int personid)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT found=1 FROM View1 WHERE PersonID = @personid";

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


        public static int AddPersonInfosAndGetItsID(string nationalno, string firstname, string secondname, 
            string thirdname, string lastname, DateTime dateofbirth , int gender , string address, 
            string phone , string email , int countryid , string imagepath)
        {

            int id = -1;
            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection( connectionstring);

            string query = "INSERT INTO People VALUES (@nationalno, @firstname, @secondname, @thirdname, @lastname, @dateofbirth, @gender, @address, @phone , @email,@countryid, @imagepath); SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalno",nationalno);
            command.Parameters.AddWithValue("@firstname",firstname);
            command.Parameters.AddWithValue("@secondname",secondname);
            if (thirdname != "")
            {
                command.Parameters.AddWithValue("@thirdname", thirdname);
            }
            else
                command.Parameters.AddWithValue("@thirdname", System.DBNull.Value);
            
            command.Parameters.AddWithValue("@lastname",lastname);
            command.Parameters.AddWithValue("@dateofbirth",dateofbirth);
            command.Parameters.AddWithValue("@gender",gender);
            command.Parameters.AddWithValue("@address",address);
            command.Parameters.AddWithValue("@phone",phone);

            if (email != "")
            {
                command.Parameters.AddWithValue("@email", email);
            }
            else
                command.Parameters.AddWithValue("@email", System.DBNull.Value);
            
            command.Parameters.AddWithValue("@countryid",countryid);

            if (imagepath != "")
            {
                command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inseted))
                {
                    id = inseted;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return id;
        }

        public static bool UpdatePersonInfos(int personid, string nationalno, string firstname, string secondname,
            string thirdname, string lastname, DateTime dateofbirth, int gender, string address,
            string phone, string email, int countryid, string imagepath)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE People SET NationalNo = @nationalno, FirstName = @firstname, SecondName = @secondname, ThirdName = @thirdname, LastName = @lastname, DateOfBirth = @dateofbirth, Gendor = @gender, Address = @address, Phone = @phone , Email = @email, NationalityCountryID = @countryid, ImagePath = @imagepath WHERE PersonID = @personid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@nationalno", nationalno);
            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@secondname", secondname);
            if (thirdname != "")
            {
                command.Parameters.AddWithValue("@thirdname", thirdname);
            }
            else
                command.Parameters.AddWithValue("@thirdname", System.DBNull.Value);

            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);

            if (email != "")
            {
                command.Parameters.AddWithValue("@email", email);
            }
            else
                command.Parameters.AddWithValue("@email", System.DBNull.Value);

            command.Parameters.AddWithValue("@countryid", countryid);

            if (imagepath != "")
            {
                command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);


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

        public static bool FindPerson(int personid, ref string nationalno,ref string firstname,ref string secondname,
            ref string thirdname, ref string lastname, ref DateTime dateofbirth, ref int gender, ref string address,
            ref string phone, ref string email, ref int countryid, ref string imagepath)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM People WHERE PersonID = @personid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personid", personid);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    nationalno = (string)reader["NationalNo"];
                    firstname = (string)reader["FirstName"];
                    secondname = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                    {
                        thirdname = (string)reader["ThirdName"];
                    }
                    else
                        thirdname = "";
                    
                    lastname = (string)reader["LastName"];
                    dateofbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];

                    if (reader["Email"] != System.DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                        email = "";
                    
                    countryid = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                    {
                        imagepath = (string)reader["ImagePath"];
                    }
                    else
                        imagepath = "";
                    

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

        public static bool FindPersonByNationalNo(ref int personid,string nationalno, ref string firstname, ref string secondname,
           ref string thirdname, ref string lastname, ref DateTime dateofbirth, ref int gender, ref string address,
           ref string phone, ref string email, ref int countryid, ref string imagepath)
        {
            bool isfound = false;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM People WHERE NationalNo = @nationalno";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalno", nationalno);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    personid = (int)reader["PersonID"];
                    firstname = (string)reader["FirstName"];
                    secondname = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                    {
                        thirdname = (string)reader["ThirdName"];
                    }
                    else
                        thirdname = "";

                    lastname = (string)reader["LastName"];
                    dateofbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];

                    if (reader["Email"] != System.DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                        email = "";

                    countryid = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                    {
                        imagepath = (string)reader["ImagePath"];
                    }
                    else
                        imagepath = "";


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

        public static bool DeletePersonData(int personid)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database = DVLD;User Id=sa;Password=123456;";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "DELETE People WHERE PersonID = @personid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personid", personid);


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
