using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    
    public class clsAppointments
    {

        private enum eMode { Update = 1, Add = 2 };
        private eMode mode;
        public int TestAppointmentID { get; set; }
        public clsTestTypes.eTestType TestTypeid { get; set; }
        public int TestTypeID { get; set; }
        public int LDappID { get; set; }
        public double TestFees { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int UserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestAppID { get; set; }
        public int TestID => _GetTestID();
        public clsApplications RetakeTestAppid { get; set; }


        public clsAppointments()
        {
            TestAppointmentID = 0;
            TestTypeID = 0;
            LDappID = 0;
            TestFees = 0;
            AppointmentDate = DateTime.Now;
            UserID = 0;
            IsLocked = false;

            mode = eMode.Add;
        }

        private clsAppointments(int appointmentid , int testtype, int LDapp, DateTime date, int userid, bool IsLocked)
        {
            this.TestAppointmentID = appointmentid;
            this.TestTypeID = testtype;
            this.LDappID = LDapp;
            this.AppointmentDate = date;
            this.UserID = userid;
            this.IsLocked = IsLocked;

            mode = eMode.Update;
        }

        public static clsAppointments Find(int TestAppointmentID)
        {
            int testtype = 0, LDappID = 0, userid = 0;
            bool islocked = false;
            DateTime appdate = DateTime.Now;
            double fees = 0;

            if (clsAppointmentData.Find(TestAppointmentID, ref testtype, ref LDappID, ref fees, ref appdate,
                ref userid, ref islocked))
                return new clsAppointments(TestAppointmentID, testtype, LDappID, appdate, userid, islocked);
            else
                return null;
        }

        public static DataTable GetAppointementListAccordingToTestID(int testID, string NationalNo,string ClassName)
        {
            return clsAppointmentData.GetAppointmentListData(testID,NationalNo,ClassName);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.eTestType TestTypeID)
        {
            return clsAppointmentData.GetApplicationTestAppointmentsPerTestType(LDappID, (int)TestTypeID);
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID)
        {
            return clsAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public void UpdateIsLocked()
        {
            clsAppointmentData.UpdateIsLocked(TestAppointmentID);
        }

        private bool _AddAppointment()
        {
            TestAppointmentID = clsAppointmentData.AddppointmentData((int)TestTypeid,LDappID,TestFees,AppointmentDate,UserID,IsLocked,RetakeTestAppID);
            return (TestAppointmentID != -1);
        }

        private bool _Update()
        {
            return clsAppointmentData.UpdateAppointmentData(TestAppointmentID, AppointmentDate);
        }

        public bool Save()
        {
            switch (mode)
            {
                case eMode.Add:
                    if (_AddAppointment())
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

        private int _GetTestID()
        {
            return clsAppointmentData.GetTestID(TestAppointmentID);
        }



    }
}
