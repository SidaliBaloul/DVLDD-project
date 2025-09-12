using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplications;

namespace DVLD_Business
{
    //piiiiwwww
    public class clsApplications
    {
        public enum eMode {Update = 1, Add = 2}
        public eMode mode;

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public int AppliID { get; set; }
        public int PersonID { get; set; }
        public string ApplicantFullName
        {
            get { return person.FullName(); }
        }
        public DateTime AppDate { get; set; }
        public int AppTypeID { get; set; }

        public clsApplicationTypes ApplicationType;
        public enApplicationStatus AppStatus { get; set; }

        public string StatusText
        {
            get
            {
                if (AppStatus == enApplicationStatus.New)
                    return "New";
                else if (AppStatus == enApplicationStatus.Cancelled)
                    return "Cancelled";
                else
                    return "Completed";
            }
        }
        public DateTime LastDateStatus { get; set; }
        public double Fees {  get; set; }
        public int UserID { get; set; }

        public clsUser user;
        public clsPerson person;


        public clsApplications()
        {
            this.AppliID = -1;
            this.PersonID = -1;
            this.AppStatus = 0;
            this.LastDateStatus = DateTime.Now;
            this.Fees = -1;
            this.AppTypeID = -1;
            this.AppDate = DateTime.Now;

            mode = eMode.Add;
        }

        private clsApplications(int appid,int personid, int appstatus, int userid ,int apptypeid,double fees,DateTime lastdate , DateTime appdate)
        {
            AppliID=appid;
            PersonID=personid;
            AppStatus = (enApplicationStatus)appstatus;
            LastDateStatus=lastdate;
            Fees=fees;
            ApplicationType = clsApplicationTypes.Find(apptypeid);
            user = clsUser.Find(userid);
            person = clsPerson.Find(personid);
            AppTypeID=apptypeid;
            AppDate=appdate;

            mode = eMode.Update;
        }

        public static clsApplications Find(int appid)
        {
            int personid = 0, appstatus = 0, userid = 0, apptypeid = 0;
            double fees = 0;
            DateTime lastdate = DateTime.Now , appdate = DateTime.Now;

            if (clsApplicationData.Find(appid, ref personid, ref appstatus, ref userid, ref apptypeid,
                ref fees, ref lastdate, ref appdate))
                return new clsApplications(appid, personid, appstatus, userid, apptypeid, fees, lastdate, appdate);
            else
                return null;

        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.AppliID);
        }

        public bool CancellApplication()
        {
            return clsApplicationData.UpdateStatusData(AppliID, 2);
        }

        public bool SetCompleted()
        {
            return clsApplicationData.UpdateStatusData(this.AppliID, 3);
        }


        public bool UpdateStatus(int ApplicationID, int appstatus)
        {
            return clsApplicationData.UpdateStatusData(ApplicationID, appstatus);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public static bool IsPersonHaveActiveApplication(int personid,int appid)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(personid,appid);
        }

        public bool IsPersonHaveActiveApplication(int apptypeid)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(this.PersonID ,apptypeid);
        }

        public static int GetActiveAppID(int personid, clsApplications.enApplicationType apptype )
        {
            return clsApplicationData.GetActiveApplicationID(personid, (int)apptype);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplications.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }


        private bool _AddApplication()
        {
            AppliID = clsApplicationData.AddApplicationData(PersonID, AppDate, AppTypeID, (int)AppStatus, LastDateStatus, Fees , UserID);

            return (AppliID != -1);
        }

        public bool Save()
        {
            if (_AddApplication())
                return true;
            else
                return false;
        }

    }
}
