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
    public partial class ShowLicenseInfo : Form
    {

        private int _LicenseID;
        public ShowLicenseInfo(int licenseid)
        {
            InitializeComponent();

           _LicenseID = licenseid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfo1.LoadLicenseInfo(_LicenseID);
        }
    }
}
