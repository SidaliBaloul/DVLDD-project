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
    public partial class Form1 : Form
    {
        private LoginScreen _Frmm;
        public Form1( LoginScreen frmm)
        {
            InitializeComponent();

            _Frmm = frmm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetailsForm frm = new UserDetailsForm(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changepassword frm = new changepassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void manageAppTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationTypes frm = new ApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypesForm frm = new TestTypesForm();
            frm.ShowDialog();
        }

        private void localDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalLicenceApp frm = new ManageLocalLicenceApp();
            frm.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void newDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicence frm = new NewLocalDrivingLicence();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drivers frm = new Drivers();
            frm.ShowDialog();

        }

        private void internationalLicenceAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInternationalLicenses frm = new ManageInternationalLicenses();
            frm.ShowDialog();
            
        }

        private void globalLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInternationalLicense frm = new AddInternationalLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewDrivingLicense frm = new RenewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementDamagedOrLostLicense frmm = new ReplacementDamagedOrLostLicense();
            frmm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainedLicenses frm = new ManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _Frmm.ShowDialog();
            this.Close();
        }

        private void releaseDetainedLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }
    }
}
