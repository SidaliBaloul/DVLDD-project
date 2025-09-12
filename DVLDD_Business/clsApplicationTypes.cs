using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationTypes
    { //piiiiiww
        public int AppID {  get; set; }
        public string AppName { get; set; }
        public double AppFees { get; set; }

        public clsApplicationTypes()
        {

        }
        private clsApplicationTypes(int appid , string appname , double fees)
        {
            AppID = appid;
            AppName = appname;
            AppFees = fees;
        }

        public static DataTable GetApplicationTypesList()
        {
            return clsApplicationTypesData.GetApplicationTypesData();
        }

        public static clsApplicationTypes Find(int appid)
        {
            string appname = "";
            double appfees = 0;

            if (clsApplicationTypesData.FindApp(appid, ref appname, ref appfees))
            {
                return new clsApplicationTypes(appid, appname, appfees);
            }
            else
                return null;

        }

        private bool _Update()
        {
            return clsApplicationTypesData.UpdateAppData(AppID, AppName, AppFees);
        }

        public bool Save()
        {
            if (_Update())
                return true;
            else
                return false;
        }
    }
}
