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
    public partial class AddInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;

        public AddInternationalLicense()
        {
            InitializeComponent();
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.PersonID = ctrLicenceInfos1.SelectedLicenseInfo.driver.PersonID;
            InternationalLicense.AppDate = DateTime.Now;
            InternationalLicense.AppStatus = clsApplications.enApplicationStatus.Completed;
            InternationalLicense.LastDateStatus = DateTime.Now;
            InternationalLicense.Fees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).AppFees;
            InternationalLicense.UserID = clsGlobal.CurrentUser.UserID;

            InternationalLicense.IsActive = true;
            InternationalLicense.DriverID = ctrLicenceInfos1.SelectedLicenseInfo.DriverID;
            InternationalLicense.LclLicenseID = ctrLicenceInfos1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpDate = DateTime.Now.AddYears(1);

            InternationalLicense.UserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            label21.Text = InternationalLicense.AppliID.ToString();
            _InternationalLicenseID = InternationalLicense.LicenseID;
            label12.Text = InternationalLicense.LicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button2Save.Enabled = false;
            ctrLicenceInfos1.FilterEnabled = false;
            linkLabel2.Enabled = true;


        }

        private void ctrLicenceInfos1_Load(object sender, EventArgs e)
        {

        }

        private void AddInternationalLicense_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToShortDateString();
            label10.Text = label9.Text;
            label14.Text = DateTime.Now.AddYears(1).ToShortDateString();
            label11.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).AppFees.ToString();
            label15.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrLicenceInfos1_Load_1(object sender, EventArgs e)
        {

        }

        private void ctrLicenceInfos1_OnLicenseselected(int obj)
        {
            linkLabel2.Enabled=false;
            int SelectedLicenseID = obj;

            label13.Text = SelectedLicenseID.ToString();

            linkLabel1.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ctrLicenceInfos1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ctrLicenceInfos1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkLabel2.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                button2Save.Enabled = false;
                return;
            }

            button2Save.Enabled = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationalLicenseInfo frm = new InternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory frm = new LicenseHistory(ctrLicenceInfos1.SelectedLicenseInfo.driver.PersonID);
            frm.ShowDialog();
        }

        private void ctrLicenceInfos1_OnLicenseNotselected(int obj)
        {
            button2Save.Enabled = false;
        }

        private void AddInternationalLicense_Activated(object sender, EventArgs e)
        {
            ctrLicenceInfos1.txtLicenseIDFocus();
        }
    }
}
