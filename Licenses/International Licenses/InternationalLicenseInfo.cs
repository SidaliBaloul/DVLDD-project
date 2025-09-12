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
    public partial class InternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID;

        public InternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }

        private void ctrInternationalLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
