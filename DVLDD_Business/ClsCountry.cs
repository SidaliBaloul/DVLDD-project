
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data;

namespace DVLD_Business
{
    public class ClsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public ClsCountry()
        {

        }

        private ClsCountry(int countryid, string countryname)
        {
            CountryID = countryid;
            CountryName = countryname;
        }

        public static ClsCountry FindByID(int Countryid)
        {
            string countryname = "";

            bool isfound = ClsCountryData.GetCountryInfoByID(Countryid,ref countryname);

            if (isfound)
                return new ClsCountry(Countryid, countryname);
            else
                return null;

        }

        public static ClsCountry FindByName(string Countryname)
        {
            int countryid = 0;

            bool isfound = ClsCountryData.GetCountryInfoByName( Countryname,ref countryid);

            if (isfound)
                return new ClsCountry(countryid, Countryname);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return ClsCountryData.GetAllCountriesData();
        }

    }
}
