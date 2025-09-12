using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public int Fees { get; set; }
        public bool Isactive { get; set; }
        public int UserID { get; set; }
        public clsDrivers driver {  get; set; }
        public clsLicenceClasses licenseclass { get; set; }
        public enIssueReason IssueReason { set; get; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public clsDetainedLicenses DetainedInfo { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicenses.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.Fees = 0;
            this.Isactive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.UserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicenses(int licenseid,int applicationid,int driverid, int licenseclaSS,DateTime issuedate,
            DateTime exdate, string notes, int fees, bool isactive, enIssueReason IssueReason, int userid)
        {
            LicenseID = licenseid;
            ApplicationID = applicationid;
            DriverID = driverid;
            LicenseClass = licenseclaSS;
            IssueDate = issuedate;
            ExpirationDate = exdate;
            Notes = notes;
            Fees = fees;
            Isactive = isactive;
            this.IssueReason = IssueReason;
            UserID = userid;

            driver = clsDrivers.FindByID(driverid);
            licenseclass = clsLicenceClasses.Find(licenseclaSS);
            DetainedInfo = clsDetainedLicenses.Find(LicenseID);

            Mode = enMode.Update;
        }

        public static DataTable GetDriverLicenses(int driverid)
        {
            return clsLicensesDatacs.GetLicensesList(driverid);
        }

        public static clsLicenses Find(int LicenseID)
        {
            int applicationid = 0, driverid = 0, licenseclass = 0, fees = 0, issuereason = 0, userid = 0;
            DateTime issuedate = DateTime.Now;
            DateTime expdate = DateTime.Now;
            string notes = "";
            bool isactive = false;

            if (clsLicensesDatacs.FindLicenseByIDData(LicenseID,ref applicationid, ref driverid, ref licenseclass,
                ref issuedate, ref expdate, ref notes, ref fees, ref isactive, ref issuereason, ref userid))
            {
                return new clsLicenses(LicenseID, applicationid, driverid, licenseclass, issuedate, expdate, notes, fees, isactive,(enIssueReason)issuereason, userid);
            }
            else
                return null;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesDatacs.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static clsLicenses FindByApplicationID(int applicationid)
        {
            int licenseid = 0, driverid = 0, licenseclass = 0, fees = 0, issuereason = 0, userid = 0;
            DateTime issuedate = DateTime.Now;
            DateTime expdate = DateTime.Now;
            string notes = "";
            bool isactive = false;

            if (clsLicensesDatacs.FindLicenseData(ref licenseid, applicationid, ref driverid, ref licenseclass,
                ref issuedate, ref expdate, ref notes, ref fees, ref isactive, ref issuereason, ref userid))
            {
                return new clsLicenses(licenseid, applicationid, driverid, licenseclass, issuedate, expdate, notes, fees, isactive, (enIssueReason)issuereason, userid);
            }
            else
                return null;
        }

        public bool UpdateIsActive(bool isactive)
        {
            return clsLicensesDatacs.UpdateIsctiveData(LicenseID,isactive);
        }

        private bool _Add()
        {
            LicenseID = clsLicensesDatacs.AddLicenseData(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,Fees,Isactive,(int)IssueReason,UserID);

            return (LicenseID > -1);
        }

        private bool _Update()
        {

            return clsLicensesDatacs.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.Fees,
               this.Isactive, (int)this.IssueReason, this.UserID);
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

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }
        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesDatacs.UpdateIsctiveData(this.LicenseID,false));
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicenses detainedLicense = new clsDetainedLicenses();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToInt16(FineFees);
            detainedLicense.UserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplications Application2 = new clsApplications();

            Application2.PersonID = driver.PersonID;
            Application2.AppDate = DateTime.Now;
            Application2.AppTypeID = (int)5;
            Application2.AppStatus = clsApplications.enApplicationStatus.Completed;
            Application2.LastDateStatus = DateTime.Now;
            Application2.Fees = clsApplicationTypes.Find(5).AppFees;
            Application2.UserID = ReleasedByUserID;

            if (!Application2.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application2.AppliID;

            return DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application2.AppliID);

        }

        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.PersonID = this.driver.PersonID;
            Application.AppDate = DateTime.Now;
            Application.AppTypeID = (int)clsApplications.enApplicationType.RenewDrivingLicense;
            Application.AppStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastDateStatus = DateTime.Now;
            Application.Fees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).AppFees;
            Application.UserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.AppliID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.licenseclass.Fees;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.Fees = this.licenseclass.Fees;
            NewLicense.Isactive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicense.UserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicenses Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.PersonID = this.driver.PersonID;
            Application.AppDate = DateTime.Now;

            Application.AppTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;

            Application.AppStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastDateStatus = DateTime.Now;
            Application.Fees = clsApplicationTypes.Find(Application.AppTypeID).AppFees;
            Application.UserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.AppliID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.Fees = 0;
            NewLicense.Isactive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.UserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

    }
}
