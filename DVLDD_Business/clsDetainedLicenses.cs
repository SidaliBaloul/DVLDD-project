using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainedLicenses
    {
        private enum eMode { Update = 1, Add = 2 }
        private eMode mode;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public int UserID { get; set; }
        public clsUser CreatedByUserInfo { set; get; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedbyUserID { get; set; }
        public int ReleaseAppID { get; set; }
        public clsUser ReleasedByUserInfo { set; get; }

        public clsDetainedLicenses()
        {
            mode = eMode.Add;
        }

        private clsDetainedLicenses(int detainid, int licenseid, DateTime detaindate, int fees, int userid,
                 bool isreleased, DateTime releaseddate, int releaseduserid, int releasappid)
        {
            DetainID = detainid;
            LicenseID = licenseid;
            DetainDate = detaindate;
            FineFees = fees;
            UserID = userid;
            CreatedByUserInfo = clsUser.Find(userid);
            IsReleased = isreleased;
            ReleaseDate = releaseddate;
            ReleasedbyUserID = releaseduserid;
            ReleasedByUserInfo = clsUser.Find(releaseduserid);
            ReleaseAppID = releasappid;

            mode = eMode.Update;
        }


        public static DataTable GetDetainedLicensesList()
        {
            return clsDetatinedLicensesData.GetDetainedLicensesData();
        }

        public static DataTable FilterDetainedLicenses(string text1, string text2)
        {
            return clsDetatinedLicensesData.FilterDetainedLicensesData(text1, text2);
        }

        public static clsDetainedLicenses Find(int licenseid)
        {
            DateTime detaindate = DateTime.Now;
            DateTime releaseddate = DateTime.Now;
            int detainid = 0, fees = 0, userid = 0, releaseduserid = 0, releasappid = 0;
            bool isreleased = false;

            if (clsDetatinedLicensesData.Find(ref detainid, licenseid, ref detaindate, ref fees, ref userid,
                ref isreleased, ref releaseddate, ref releaseduserid, ref releasappid))
            {
                return new clsDetainedLicenses(detainid, licenseid, detaindate, fees, userid,
                 isreleased, releaseddate, releaseduserid, releasappid);
            }
            else
                return null;
        }
        public static clsDetainedLicenses FindByDetainID(int detainid)
        {
            DateTime detaindate = DateTime.Now;
            DateTime releaseddate = DateTime.Now;
            int licenseid = 0,  userid = 0, releaseduserid = 0, releasappid = 0;
            bool isreleased = false;
            int fees = 0;

            if (clsDetatinedLicensesData.GetDetainedLicenseInfoByID( detainid,ref licenseid, ref detaindate, ref fees, ref userid,
                ref isreleased, ref releaseddate, ref releaseduserid, ref releasappid))
            {
                return new clsDetainedLicenses(detainid, licenseid, detaindate, fees, userid,
                 isreleased, releaseddate, releaseduserid, releasappid);
            }
            else
                return null;
        }

        private bool _Add()
        {
            DetainID = clsDetatinedLicensesData.AddDetainedLicense(LicenseID, DetainDate, FineFees, UserID);

            return (DetainID > -1);
        }

        private bool _Update()
        {
            return clsDetatinedLicensesData.Update(DetainID,LicenseID, DetainDate, FineFees, UserID, IsReleased, ReleaseDate, ReleasedbyUserID, ReleaseAppID);
        }

        public bool Save()
        {
            switch (mode)
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

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetatinedLicensesData.IsLicenseDetained(LicenseID);
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetatinedLicensesData.ReleaseDetainedLicense(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

    }
}
