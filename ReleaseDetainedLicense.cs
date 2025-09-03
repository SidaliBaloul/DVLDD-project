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
    public partial class ReleaseDetainedLicense : Form
    {
        private int _SelectedLicenseID = -1;

        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public ReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;

            ctrLicenceInfos1.LoadLicenseInfo(_SelectedLicenseID);
            ctrLicenceInfos1.FilterEnabled = false;
        }

        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrLicenceInfos1_OnLicenseselected(int obj)
        {
            _SelectedLicenseID = obj;

            label13.Text = _SelectedLicenseID.ToString();

            linkLabel1.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (!ctrLicenceInfos1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label5.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).AppFees.ToString();
            label15.Text = clsGlobal.CurrentUser.UserName;

            label21.Text = ctrLicenceInfos1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            label13.Text = ctrLicenceInfos1.SelectedLicenseInfo.LicenseID.ToString();

            label15.Text = ctrLicenceInfos1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            label9.Text = ctrLicenceInfos1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            label11.Text = ctrLicenceInfos1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            label22.Text = (Convert.ToSingle(label5.Text) + Convert.ToSingle(label11.Text)).ToString();

            button2Save.Enabled = true;
        }

        private void ReleaseDetainedLicense_Activated(object sender, EventArgs e)
        {
            ctrLicenceInfos1.txtLicenseIDFocus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory frm = new LicenseHistory(ctrLicenceInfos1.SelectedLicenseInfo.driver.PersonID);
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrLicenceInfos1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID); 

            label10.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button2Save.Enabled = false;
            ctrLicenceInfos1.FilterEnabled = false;
            linkLabel2.Enabled = true;
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
