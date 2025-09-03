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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Business;

namespace DVLD_project
{
    public partial class LicenseHistory : Form
    {
        private int _PersonID = -1;

        public LicenseHistory()
        {
            InitializeComponent();


        }
        public LicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrPersoninfoWithzfilter1.LoadPersonInfo(_PersonID);
                ctrPersoninfoWithzfilter1.filterenabled = false;
                ctrLicensesHistory1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrPersoninfoWithzfilter1.Enabled = true;
                ctrPersoninfoWithzfilter1.FilterFocus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrLicensesHistory1_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrPersoninfoWithzfilter1_OnPersonselected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrLicensesHistory1.Clear();
            }
            else
                ctrLicensesHistory1.LoadInfoByPersonID(_PersonID);
        }
    }
}
