using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        private enum eModes { Update = 0, Add = 1 }
        private eModes eMode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public clsPerson personinfo { get; set; }

        public clsUser()
        {
            UserID = 0;
            PersonID = 0;
            UserName = "";
            Password = "";
            isActive = true;
            personinfo = new clsPerson();

            eMode = eModes.Add;
        }

        private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            this.isActive = isActive;
            personinfo = clsPerson.Find(personID);

            eMode = eModes.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsersData();
        }

        public static DataTable GetUsersList()
        {
            return clsUsersData.GetUsersListData();
        }

        public static DataTable FilterUsers(string text1, string text2)
        {
            return clsUsersData.FilterUsersData(text1,text2);
        }

        public static DataTable GetActiveOrDesactive(byte num)
        {
            return clsUsersData.GetActiveOrDesactiveData(num);
        }

        public static clsUser Find(int Userid)
        {
            int personid = 0;
            string username = "", password = "";
            bool isactive = false;

            if (clsUsersData.FindUser(Userid, ref personid, ref username, ref password, ref isactive))
            {
                return new clsUser(Userid, personid, username, password, isactive);
            }
            else
                return null;

        }

        public static clsUser FindByPersonID(int personid)
        {
            int userid = 0;
            string username = "", password = "";
            bool isactive = false;

            if (clsUsersData.FindByPersonID(ref userid,personid, ref username, ref password, ref isactive))
            {
                return new clsUser(userid, personid, username, password, isactive);
            }
            else
                return null;

        }

        public static clsUser FindByUserNameAndPassword(string username, string password)
        {
            int personid = 0, userid = 0;
            bool isactive = false;

            if (clsUsersData.FindUserByUsernameAndPassword(ref userid, ref personid,username, password, ref isactive))
            {
                return new clsUser(userid, personid, username, password, isactive);
            }
            else
                return null;

        }

        public static bool IsPersonIDAlreadyAttached(int personid)
        {
            return clsUsersData.IsPersonIDAttached(personid);
        }

        public static bool IsUserExists(string username)
        {
            return clsUsersData.IsUserExist(username);
        }

        public static bool IsUserExists(int userid)
        {
            return clsUsersData.IsUserExist(userid);
        }

        private bool _AddUser()
        {
            UserID = clsUsersData.AddUserData(PersonID, UserName, Password, isActive);

            return (UserID > -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUserData(UserID, PersonID,UserName, Password, isActive);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUserData(UserID);
        }

        public bool Save()
        {
            switch(eMode)
            {
                case eModes.Add:
                    if (_AddUser())
                    {
                        eMode = eModes.Update;
                        return true;
                    }
                    else
                        return false;

                case eModes.Update:
                    if (_UpdateUser())
                        return true;
                    else
                        return false;
            }

            return false;
        }

    }
}
