using DVLD_Business;
using DVLD_project.Properties;
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
    public partial class VisionTest : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.eTestType _TestType = clsTestTypes.eTestType.VisionTest;

        public VisionTest(int LocalDrivingLicenseApplicationID, clsTestTypes.eTestType TestType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypes.eTestType.VisionTest:
                    {
                        label4.Text = "Vision Test Appointments";
                        this.Text = label4.Text;
                        break;
                    }

                case clsTestTypes.eTestType.WriteTest:
                    {
                        label4.Text = "Written Test Appointments";
                        this.Text = label4.Text;
                        break;
                    }
                case clsTestTypes.eTestType.StreetTest:
                    {
                        label4.Text = "Street Test Appointments";
                        this.Text = label4.Text;
                        break;
                    }
            }
        }

        private void VisionTest_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();


            ctrApplicationInfos1.LoadInfosByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dataGridView1.DataSource = _dtLicenseTestAppointments;
            label3.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 150;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenceApp localDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //---
            Test LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                ScheduleTest frm1 = new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                VisionTest_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScheduleTest frm2 = new ScheduleTest
                (LastTest.TestAppointmentInfo.LDappID, _TestType);
            frm2.ShowDialog();
            VisionTest_Load(null, null);
        }

        private void button2Save_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;


            ScheduleTest frm = new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            VisionTest_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            TakeTest frm = new TakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            VisionTest_Load(null, null);
        }
        private void frm_DataBack(object sender, int testpassed)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ctrApplicationInfos1_Load(object sender, EventArgs e)
        {

        }
    }
}
