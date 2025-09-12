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
    public partial class ctrDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicenses _License;


        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenses SelectedLicenseInfo
        { 
            get { return _License; } 
        }

        private void _LoadPersonImage()
        {
            if (_License.driver.person.Gender == 0)
                pictureBox2.Image = Resources.man;
            else
                pictureBox2.Image = Resources.woman;

            string ImagePath = _License.driver.person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox2 .Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            label19.Text = _License.LicenseID.ToString();
            label26.Text = _License.Isactive ? "Yes" : "No";
            label22.Text = _License.IsDetained ? "Yes" : "No";
            label21.Text = _License.licenseclass.ClassName;
            label20.Text = _License.driver.person.FullName();
            label18.Text = _License.driver.person.NationalNo;
            label17.Text = _License.driver.person.Gender == 0 ? "Male" : "Female";
            label25.Text = _License.driver.person.DateOfBirth.ToShortDateString();

            label24.Text = _License.DriverID.ToString();
            label16.Text = _License.IssueDate.ToShortDateString();
            label23.Text = _License.ExpirationDate.ToShortDateString();
            label15.Text = _License.IssueReasonText;
            label14.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
