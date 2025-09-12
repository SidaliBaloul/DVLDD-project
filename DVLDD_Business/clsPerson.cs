using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data;


namespace DVLD_Business
{
    public class clsPerson
    {
        private enum eMode { UpdateMode = 1, AddMode = 2}
        private eMode mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }  
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }   
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public ClsCountry CountryInfo;


        public clsPerson()
        {
            PersonID = 0;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            CountryID = 0;
            ImagePath = "";
            CountryInfo = new ClsCountry();

            mode = eMode.AddMode;
        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int gender, string address, string phone, string email, int countryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            CountryID = countryID;
            ImagePath = imagePath;
            CountryInfo = ClsCountry.FindByID(countryID);

            mode = eMode.UpdateMode;
        }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }

        public static clsPerson Find(int PersonID)
        {
            string natio = "", firstn = "", secondn = "", thirdn = "", lastn = "", address = "", phone = "", email = "", imagepath = "";
            DateTime dateof = DateTime.Now;
            int gender = 0, countryid = 0;

            if (clsPersonData.FindPerson(PersonID, ref natio, ref firstn, ref secondn, ref thirdn,
                ref lastn, ref dateof, ref gender, ref address, ref phone, ref email, ref countryid, ref imagepath))
            {
                return new clsPerson(PersonID, natio, firstn, secondn, thirdn,
                 lastn, dateof, gender, address, phone, email, countryid, imagepath);
            }
            else
                return null;
        }

        public static clsPerson FindByNationalNo(string nationalnum)
        {
            string  firstn = "", secondn = "", thirdn = "", lastn = "", address = "", phone = "", email = "", imagepath = "";
            DateTime dateof = DateTime.Now;
            int gender = 0, countryid = 0, personid = 0;

            if (clsPersonData.FindPersonByNationalNo(ref personid,nationalnum, ref firstn, ref secondn, ref thirdn,
                ref lastn, ref dateof, ref gender, ref address, ref phone, ref email, ref countryid, ref imagepath))
            {
                return new clsPerson(personid, nationalnum, firstn, secondn, thirdn,
                 lastn, dateof, gender, address, phone, email, countryid, imagepath);
            }
            else
                return null;
        }
        
        private bool _AddPerson()
        {
            PersonID = clsPersonData.AddPersonInfosAndGetItsID(this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,
                this.LastName,this.DateOfBirth,this.Gender,this.Address,this.Phone,this.Email,this.CountryID,this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return (clsPersonData.UpdatePersonInfos(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath));
            
        }

        public static bool DeletePerson(int personid)
        {
           return clsPersonData.DeletePersonData(personid);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static DataTable FilterPeople(string text1, string text2)
        {
            return clsPersonData.FilterPeople(text1,text2);
        }

        public static bool IsExist(string nationalno)
        {
            return clsPersonData.IsPersonExist(nationalno);
        }

        public bool Save()
        {
            switch(mode)
            {
                case eMode.AddMode:
                    if (_AddPerson())
                    {
                        mode = eMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case eMode.UpdateMode:
                    if(_UpdatePerson())
                        return true;
                    else
                        return false;
            }

            return false;
        }


    }
}
