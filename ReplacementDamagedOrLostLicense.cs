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
using static DVLD_Business.clsLicenses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_project
{
    public partial class ReplacementDamagedOrLostLicense : Form
    {
        private int _NewLicenseID = -1;

        public ReplacementDamagedOrLostLicense()
        {
            InitializeComponent();
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void ctrLicenseInfoWithReplacement1_OnLicenseselected(int obj)
        {
            
        }

        private void ctrLicenseInfoWithReplacement1_OnLicenseNotselected(int obj)
        {
          
        }

        private void ReplacementDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            label15.Text = clsGlobal.CurrentUser.UserName;

            radioButton1.Checked = true;
        }

        private enIssueReason _GetIssueReason()
        {


            if (radioButton1.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicenses NewLicense =
               ctrLicenceInfos1.SelectedLicenseInfo.Replace(_GetIssueReason(),
               clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            label21.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            label19.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button2Save.Enabled = false;
            groupBox2.Enabled = false;
            ctrLicenceInfos1.FilterEnabled = false;
            linkLabel2.Enabled = true;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //LicenseHistory frm = new LicenseHistory(_PersonID);
            //frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void ctrLicenseInfoWithReplacement1_OnRadioButtonChanged(int obj)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private int _GetApplicationTypeID()
        {

            if (radioButton1.Checked)

                return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Replacement for Damaged License";
            this.Text = label4.Text;
            label11.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).AppFees.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Replacement for Lost License";
            this.Text = label4.Text;
            label11.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).AppFees.ToString();
        }

        private void ReplacementDamagedOrLostLicense_Activated(object sender, EventArgs e)
        {
            ctrLicenceInfos1.txtLicenseIDFocus();
        }

        private void ctrLicenceInfos1_OnLicenseselected(int obj)
        {
            int SelectedLicenseID = obj;
            label13.Text = SelectedLicenseID.ToString();
            linkLabel1.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            //dont allow a replacement if is Active .
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
