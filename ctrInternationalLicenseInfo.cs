using DVLD_Business;
using DVLD_project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_project
{
    
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInternationalLicenses _InternationalLicense;

        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.person.Gender == 0)
                pictureBox2.Image = Resources.man;
            else
                pictureBox2.Image = Resources.woman;

            string ImagePath = _InternationalLicense.DriverInfo.person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox2.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicenses.Find(_InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            label18.Text = _InternationalLicense.LicenseID.ToString();
            label26.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            label19.Text = _InternationalLicense.LclLicenseID.ToString();
            label20.Text = _InternationalLicense.DriverInfo.person.FullName();
            label17.Text = _InternationalLicense.DriverInfo.person.NationalNo;
            label16.Text = _InternationalLicense.DriverInfo.person.Gender == 0 ? "Male" : "Female";
            label25.Text = _InternationalLicense.DriverInfo.person.DateOfBirth.ToShortDateString();

            label24.Text = _InternationalLicense.DriverID.ToString();
            label15.Text = _InternationalLicense.IssueDate.ToShortDateString();
            label23.Text = _InternationalLicense.ExpDate.ToShortDateString();

            _LoadPersonImage();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
