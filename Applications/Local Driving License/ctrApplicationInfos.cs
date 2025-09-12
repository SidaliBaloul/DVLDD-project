using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class ctrApplicationInfos : UserControl
    {
        private clsLocalDrivingLicenceApp _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ctrApplicationInfos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PersonDetailsForm frp = new PersonDetailsForm(PersonID);
            //frp.ShowDialog();
        }

        private void Form_DataBack(object sender, string Personname)
        {
            //ApplicantPerson = Personname;
        }

        private void ctrApplicationInfos_Load(object sender, EventArgs e)
        {

        }

        private void _ResetDefaultValues()
        {
            label6.Text = "????";
            label4.Text = "????";
            label5.Text = "0";

            //ctrApplicationBasicInfos1._resetValues();
        }

        private void _FillApplicationInfos()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            //incase there is license enable the show link.
            linkLabel2.Enabled = (_LicenseID != -1);

            label6.Text = _LocalDrivingLicenseApplication.AppID.ToString();
            label4.Text = clsLicenceClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            label5.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString();
            ctrApplicationBasicInfos1._LoadApplicationInfos(_LocalDrivingLicenseApplication.applicationID);
        }

        public void LoadInfosByLocalApplicationID(int lclappid)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(lclappid);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ApplicationID = " + lclappid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfos();

        }

        public void LoadInfosByApplicationID(int appid)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindByApplicationID(appid);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ApplicationID = " + appid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfos();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ShowLicenseInfo frm = new ShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            //frm.ShowDialog();
        }

        private void ctrApplicationBasicInfos1_Load(object sender, EventArgs e)
        {

        }
    }
}
