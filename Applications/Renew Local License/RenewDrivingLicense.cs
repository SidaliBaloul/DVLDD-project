using DVLD_Business;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project
{
    public partial class RenewDrivingLicense : Form
    {

        private int _NewLicenseID = -1;

        public RenewDrivingLicense()
        {
            InitializeComponent();
        }

        private void ctrLicenceInfos1_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }


        private void ctrLicenceInfos1_OnLicenseselected(int obj)
        {
            
        }

        private void RenewDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrLicenceInfos1.txtLicenseIDFocus();


            label9.Text = DateTime.Now.ToShortDateString();
            label10.Text = label19.Text;

            label14.Text = "???";
            label11.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).AppFees.ToString();
            label15.Text = clsGlobal.CurrentUser.UserName;
        }

       

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicenses NewLicense =
                ctrLicenceInfos1.SelectedLicenseInfo.RenewLicense(textBox1.Text.Trim(),
                clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            label21.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            label19.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button2Save.Enabled = false;
            ctrLicenceInfos1.FilterEnabled = false;
            linkLabel2.Enabled = true;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory frm = new LicenseHistory(_NewLicenseID);
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RenewDrivingLicense_Activated(object sender, EventArgs e)
        {
           ctrLicenceInfos1.txtLicenseIDFocus();
        }

        private void ctrLicenceInfos1_OnLicenseselected_1(int obj)
        {
            int SelectedLicenseID = obj;

            label13.Text = SelectedLicenseID.ToString();

            linkLabel1.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            int DefaultValidityLength = ctrLicenceInfos1.SelectedLicenseInfo.licenseclass.Validity;
            label14.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            label17.Text = ctrLicenceInfos1.SelectedLicenseInfo.licenseclass.Fees.ToString();
            label22.Text = (Convert.ToSingle(label11.Text) + Convert.ToSingle(label17.Text)).ToString();
            textBox1.Text = ctrLicenceInfos1.SelectedLicenseInfo.Notes;


            //check the license is not Expired.
            if (!ctrLicenceInfos1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrLicenceInfos1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2Save.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrLicenceInfos1.SelectedLicenseInfo.Isactive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2Save.Enabled = false;
                return;
            }

            button2Save.Enabled = true;
        }
    }
}
