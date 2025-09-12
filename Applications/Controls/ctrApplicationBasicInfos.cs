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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project
{
    public partial class ctrApplicationBasicInfos : UserControl
    {
        clsApplications application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrApplicationBasicInfos()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ctrApplicationBasicInfos_Load(object sender, EventArgs e)
        {

        }

        public void _resetValues()
        {
            _ApplicationID = -1;

            label15.Text = "????";
            label16.Text = "????";
            label17.Text = "????";
            label18.Text = "????";
            label19.Text = "????";
            label20.Text = "????";
            label21.Text = "????";
            label22.Text = "????";
        }

        private void _FillApplicationInfos()
        {
            _ApplicationID = application.AppliID;
            label15.Text = application.AppliID.ToString();
            label16.Text = application.StatusText.ToString();
            label17.Text = application.Fees.ToString();
            label18.Text = application.ApplicationType.AppName.ToString();
            label19.Text = application.person.FullName();
            label20.Text = application.AppDate.ToShortDateString();
            label21.Text = application.LastDateStatus.ToShortDateString();
            label22.Text = application.user.UserName.ToString();
        }

        public void _LoadApplicationInfos(int applicationid)
        {
            application = clsApplications.Find(applicationid);

            if(application == null)
            {
                _resetValues();
                MessageBox.Show("No Application with ApplicationID = " + applicationid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfos();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetailsForm frm = new PersonDetailsForm(application.PersonID);
            frm.ShowDialog();
            _LoadApplicationInfos(_ApplicationID);
        }
    }
}
