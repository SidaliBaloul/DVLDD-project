using DVLD_Business;
using DVLD_project.Properties;
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
using static DVLD_Business.clsTestTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD_project
{
    public partial class ScheduleTest : Form
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.eTestType _TestTypeID = clsTestTypes.eTestType.VisionTest;
        private int _AppointmentID = -1;

        public ScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void ScheduleVisionTest_Load(object sender, EventArgs e)
        {
            ctrScheduletest1.TestTypeID = _TestTypeID;
            ctrScheduletest1.LoadData(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void ctrScheduletest1_Load(object sender, EventArgs e)
        {

        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
