using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDrivers

    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID {  get; set; }
        public int PersonID { get; set; }
        public clsPerson person { get; set; }
        public int UserID { get; set; }
        public DateTime Date {  get; set; }

        public clsDrivers()
        {
            Mode = enMode.AddNew;
        }

        private clsDrivers(int driverid , int personid, int userid, DateTime date)
        {
            this.DriverID = driverid;
            this.PersonID = personid;
            this.UserID = userid;
            this.Date = date;
            this.person = clsPerson.Find(personid);

            Mode = enMode.Update;
        }

        public static clsDrivers FindByID(int DriverID)
        {
            int userid = 0, PersonID = 0;
            DateTime date = DateTime.Now;

            if (clsDriversData.FindDriverByID(DriverID,ref PersonID, ref userid, ref date))
            {
                return new clsDrivers(DriverID, PersonID, userid, date);
            }
            else
                return null;

        }

        public static clsDrivers Find(int PersonID)
        {
            int userid = 0, DriverID = 0;
            DateTime date = DateTime.Now;

            if (clsDriversData.FindDriver(PersonID,ref DriverID, ref userid, ref date))
            {
                return new clsDrivers(DriverID, PersonID, userid, date);
            }
            else
                return null;
        
        }

        public static DataTable FilterDrivers(string text1, string text2)
        {
            return clsDriversData.FilterDrivers(text1, text2);
        }

        public static DataTable GetDriversList()
        {
            return clsDriversData.GetDriversData();
        }

        private bool _Add()
        {
            DriverID = clsDriversData.AddDriverData(PersonID, UserID, Date);

            return (DriverID > -1);
        }

        private bool _Update()
        {
            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.UserID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicenses.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenses.GetDriverInternationalLicenses(DriverID);
        }

    }
}
