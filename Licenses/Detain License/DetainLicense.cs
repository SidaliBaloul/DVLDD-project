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

namespace DVLD_project
{
    public partial class DetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public DetainLicense()
        {
            InitializeComponent();

            
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToShortDateString();
            label15.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrLicenceInfos1_OnLicenseNotselected(int obj)
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
            if (ctrLicenceInfos1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox1.Focus();
            button2Save.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ctrLicenceInfos1.SelectedLicenseInfo.Detain(Convert.ToSingle(textBox1.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            label21.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button2Save.Enabled = false;
            ctrLicenceInfos1.FilterEnabled = false;
            textBox1.Enabled = false;
            linkLabel2.Enabled = true;
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1Close_Click_1(object sender, EventArgs e)
        {

        }

        private void button1Close_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrLicenceInfos1_Load(object sender, EventArgs e)
        {

        }

        private void DetainLicense_Activated(object sender, EventArgs e)
        {
            ctrLicenceInfos1.txtLicenseIDFocus();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);

            };


            if (!clsValidation.IsNumber(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            };
        }
    }
}
