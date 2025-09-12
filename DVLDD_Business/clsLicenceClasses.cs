using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenceClasses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAge { get; set; }
        public int Validity { get; set; }
        public int Fees { get; set; }

        public clsLicenceClasses()
        {
            LicenseClassID = 0;
            ClassName = "";
            ClassDescription = "";
            MinimumAge = 0;
            Validity = 0;
            Fees = 0;

            Mode = enMode.AddNew;
        }

        private clsLicenceClasses(int licenseid,string classname,string classdesc,int minage,int validity,int fees)
        {
            LicenseClassID = licenseid;
            ClassName = classname;
            ClassDescription = classdesc;
            MinimumAge = minage;
            Validity = validity;
            Fees = fees;

            Mode = enMode.Update;
        }
        public static clsLicenceClasses Find(int licenseclassid)
        {
            string classname = "", classdescription = "";
            int minage = 0, validity = 0, Fees = 0;

            if(clsLicenceClassesData.Find(licenseclassid,ref classname,ref classdescription,ref minage,ref validity,ref Fees))
            {
                return new clsLicenceClasses(licenseclassid,classname,classdescription,minage,validity,Fees);
            }
            else
                return null;
        }

        public static clsLicenceClasses Find(string classname)
        {
            int licenseclassid = 0;
            string classdescription = "";
            int minage = 0, validity = 0, Fees = 0;

            if (clsLicenceClassesData.Find(ref licenseclassid,classname, ref classdescription, ref minage, ref validity, ref Fees))
            {
                return new clsLicenceClasses(licenseclassid, classname, classdescription, minage, validity, Fees);
            }
            else
                return null;
        }

        public static DataTable GetLicenceClassesList()
        {
            return clsLicenceClassesData.GetLicenceClassesListData();
        }

        private bool _Add()
        {

            this.LicenseClassID = clsLicenceClassesData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAge, this.Validity, this.Fees);


            return (this.LicenseClassID != -1);
        }

        private bool _Update()
        {

            return clsLicenceClassesData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAge, this.Validity, this.Fees);
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

    }

}

