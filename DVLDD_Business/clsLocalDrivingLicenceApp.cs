using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenceApp : clsApplications
    {
        private enum eMode { Update = 1, Add = 2 }
        private eMode mode;

        public int AppID { get; set; }
        public int LicenseClassID { get; set; }
        public int applicationID { get; set; }

        public clsLicenceClasses licenseclass;

        public string PersonFullName
        {
            get
            {
                return clsPerson.Find(PersonID).FullName();
            }

        }

        public clsLocalDrivingLicenceApp()
        {
            AppID = 0;
            LicenseClassID = 0;
            applicationID = 0;

            mode = eMode.Add;
        }

        private clsLocalDrivingLicenceApp(int appid , int licenseclassid , int applicationid,int personid, 
            enApplicationStatus appstatus, int userid, int apptypeid, double fees, DateTime lastdate, DateTime appdate)
        {
            AppID = appid;
            LicenseClassID = licenseclassid;
            this.applicationID = applicationid;
            this.AppliID = applicationid;
            this.PersonID = personid;
            this.AppStatus = appstatus;
            this.UserID = userid;
            this.PersonID = apptypeid;
            this.licenseclass = clsLicenceClasses.Find(licenseclassid);
            this.Fees = fees;
            this.LastDateStatus = lastdate;
            this.AppDate = appdate;

            mode = eMode.Update;
        }

        public static DataTable GetLocalLicencesApplications()
        {
            return clsLocalDrivingLicenceAppData.GetAllLocalLicencesApplications();
        }

        public static DataTable FilterLocalLicences(string combotxt , string boxtxt)
        {
            return clsLocalDrivingLicenceAppData.FilterLocalLicences(combotxt, boxtxt);
        }

        public bool DeleteLocalDrivingApplication()
        {

            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenceAppData.Delete(this.AppID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }

        public static clsLocalDrivingLicenceApp FindLocalAppID(int localappid)
        {
            int licenseclassid = 0, applicationid = 0;

            bool isfound = clsLocalDrivingLicenceAppData.FindByLocalAppID(localappid,ref licenseclassid,ref applicationid);

            if(isfound)
            {
                clsApplications application = clsApplications.Find(applicationid);

                return new clsLocalDrivingLicenceApp(localappid,licenseclassid,applicationid,application.PersonID,
                    (enApplicationStatus)application.AppStatus,application.UserID,application.AppTypeID,application.Fees,application.LastDateStatus,application.AppDate);

            }
            else
               return null;
 
        }

        public static clsLocalDrivingLicenceApp FindByApplicationID(int applicationid)
        {
            int licenseclassid = 0, localappid = 0;

            bool isfound = clsLocalDrivingLicenceAppData.FindByApplicationID(ref localappid, ref licenseclassid,applicationid);

            if (isfound)
            {
                clsApplications application = clsApplications.Find(applicationid);

                return new clsLocalDrivingLicenceApp(localappid, licenseclassid, applicationid, application.PersonID,
                    (enApplicationStatus)application.AppStatus, application.UserID, application.AppTypeID, application.Fees, application.LastDateStatus, application.AppDate);

            }
            else
                return null;

        }

        private bool _Add()
        {
            this.AppID = clsLocalDrivingLicenceAppData.AddLocalDrivingLicenseApp(this.AppliID, this.LicenseClassID);

            return (this.AppID != -1);
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenceAppData.Update(AppID, LicenseClassID, applicationID);
        }

        public bool Save()
        {
            base.mode = (clsApplications.eMode)mode;

            if (!base.Save())
                return false;

            switch(mode)
            {
                case eMode.Add:
                    if (_Add())
                    {
                        mode = eMode.Update;
                        return true;
                    }
                    else
                        return false;

                case eMode.Update:
                    if (_Update())
                        return true;
                    else
                        return false;
            }

            return false;
        }

        public bool DoesPassTestType(clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.DoesPassTestType(AppID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestTypes.eTestType CurrentTestType)
        {

            switch (CurrentTestType)
            {
                case clsTestTypes.eTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    return true;

                case clsTestTypes.eTestType.WriteTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.

                    return this.DoesPassTestType(clsTestTypes.eTestType.VisionTest);


                case clsTestTypes.eTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return this.DoesPassTestType(clsTestTypes.eTestType.WriteTest);

                default:
                    return false;
            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.DoesAttendTestType(this.AppID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestTypes.eTestType TestTypeID)
        {
            return clsLocalDrivingLicenceAppData.TotalTrialsPerTest(this.AppID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public bool AttendedTest(clsTestTypes.eTestType TestTypeID)

        {
            return clsLocalDrivingLicenceAppData.TotalTrialsPerTest(this.AppID, (int)TestTypeID) > 0;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID)

        {

            return clsLocalDrivingLicenceAppData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestTypes.eTestType TestTypeID)

        {

            return clsLocalDrivingLicenceAppData.IsThereAnActiveScheduledTest(this.AppID, (int)TestTypeID);
        }

        public Test GetLastTestPerTestType(clsTestTypes.eTestType TestTypeID)
        {
            return Test.FindLastTestPerPersonAndLicenseClass(this.PersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return Test.GetPassedTestCount(this.AppID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return Test.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return Test.PassedAllTests(this.AppID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return Test.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDrivers Driver = clsDrivers.Find(this.PersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDrivers();

                Driver.PersonID = this.PersonID;
                Driver.UserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicenses License = new clsLicenses();
            License.ApplicationID = this.applicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.licenseclass.Validity);
            License.Notes = Notes;
            License.Fees = this.licenseclass.Fees;
            License.Isactive = true;
            License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            License.UserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetCompleted();

                return License.LicenseID;
            }

            else
                return -1;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicenses.GetActiveLicenseIDByPersonID(this.PersonID, this.LicenseClassID);
        }
    }
}
