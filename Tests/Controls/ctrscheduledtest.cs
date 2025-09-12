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
using static DVLD_Business.clsTestTypes;

namespace DVLD_project
{
    public partial class ctrscheduledtest : UserControl
    {
        private clsTestTypes.eTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenceApp _LocalDrivingLicenseApplication;

        public clsTestTypes.eTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypes.eTestType.VisionTest:
                        {
                            label4.Text = "Vision Test";
                            pictureBox1.Image = Resources.vision;
                            break;
                        }

                    case clsTestTypes.eTestType.WriteTest:
                        {
                            label4.Text = "Written Test";
                            pictureBox1.Image = Resources.write;
                            break;
                        }
                    case clsTestTypes.eTestType.StreetTest:
                        {
                            label4.Text = "Street Test";
                            pictureBox1.Image = Resources.road;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsAppointments _TestAppointment;

        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


            _TestAppointment = clsAppointments.Find(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LDappID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label11.Text = _LocalDrivingLicenseApplication.AppID.ToString();
            label12.Text = _LocalDrivingLicenseApplication.licenseclass.ClassName;
            label13.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            label6.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



            label17.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            label16.Text = _TestAppointment.TestFees.ToString();
            label10.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();



        }
        public ctrscheduledtest()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
