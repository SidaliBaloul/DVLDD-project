using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public int TestID {  get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public double TestFees { get; set; }

        public eTestType _ID {  get; set; }

        public enum eTestType { VisionTest = 1, WriteTest = 2, StreetTest = 3}

        private clsTestTypes(eTestType ID, int testid , string testname , string testdescription , double testfees)
        {
            TestID = (int)ID;
            TestName = testname;
            TestDescription = testdescription;
            TestFees = testfees;
            this._ID = ID;
        }

        public static clsTestTypes Find(eTestType testtype)
        {
            int testid = 0;
            string testname = "", testdesc = "";
            double fees = 0;

            if (clsTestTypesData.Find((int)testtype, ref testname, ref testdesc, ref fees))
            {
                return new clsTestTypes(testtype,testid, testname, testdesc, fees);
            }
            else
                return null;
        }

        public static DataTable GetTestTypesList()
        {
            return clsTestTypesData.GetAllTestTypesData();
        }

        private bool _Update()
        {
            return clsTestTypesData.UpdateTestData(TestID, TestName, TestDescription, TestFees);
        }

        public bool Save()
        {
            if(_Update())
            {
                return true;
            }
            else
                return false;
        }
    }
}
