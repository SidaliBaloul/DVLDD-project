using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalLicenses : clsApplications
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsDrivers DriverInfo;
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int LclLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool IsActive {  get; set; }

        public clsInternationalLicenses()
        {
            this.AppTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
            Mode = enMode.AddNew;
        }

        public clsInternationalLicenses(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)

        {
            //this is for the base clase
            base.AppliID = ApplicationID;
            base.PersonID = ApplicantPersonID;
            base.AppDate = ApplicationDate;
            base.AppTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
            base.AppStatus = ApplicationStatus;
            base.LastDateStatus = LastStatusDate;
            base.Fees = PaidFees;
            base.UserID = CreatedByUserID;

            this.LicenseID = InternationalLicenseID;
            this.AppliID = ApplicationID;
            this.DriverID = DriverID;
            this.LclLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpDate = ExpirationDate;
            this.IsActive = IsActive;
            this.UserID = CreatedByUserID;

            this.DriverInfo = clsDrivers.FindByID(this.DriverID);

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this.LicenseID =
                clsInternationalLicensesData.AddNewInternationalLicense(this.AppliID, this.DriverID, this.LclLicenseID,
               this.IssueDate, this.ExpDate,
               this.IsActive, this.UserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            //call DataAccess Layer 

            return clsInternationalLicensesData.UpdateInternationalLicense(
                this.LicenseID, this.AppliID, this.DriverID, this.LclLicenseID,
               this.IssueDate, this.ExpDate,
               this.IsActive, this.UserID);
        }

        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;

            if (clsInternationalLicensesData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID,
            ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                //now we find the base application
                clsApplications Application = clsApplications.Find(ApplicationID);


                return new clsInternationalLicenses(Application.AppliID,
                    Application.PersonID,
                                     Application.AppDate,
                                    (enApplicationStatus)Application.AppStatus, Application.LastDateStatus,
                                     (float)Application.Fees, Application.UserID,
                                     InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID,
                                         IssueDate, ExpirationDate, IsActive);

            }

            else
                return null;

        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GetInternationalLicensesData();

        }

        public bool Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.mode = (clsApplications.eMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalLicensesData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicensesData.GetDriverInternationalLicenses(DriverID);
        }


    }
}
