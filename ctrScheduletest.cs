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
    public partial class ctrScheduletest : UserControl
    {

        private enum eModes { Vision = 1, Write = 2, Street = 3 }
        private enum eForm { Take = 1, Retake = 2 }
        private enum eType { Update = 1, Add = 2 }

        private eModes mode;
        private eType type;
        private eForm form;

        clsAppointments appointment1;
        clsLocalDrivingLicenceApp ldlapp1;
        private clsTestTypes.eTestType _TestTypeID = clsTestTypes.eTestType.VisionTest;

        int _AppointmentID;
        int ldlapp;

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


        private bool _LoadTestAppointmentData()
        {
            appointment1 = clsAppointments.Find(_AppointmentID);

            if (appointment1 == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _AppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2Save.Enabled = false;
                return false;
            }

            label16.Text = appointment1.TestFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, appointment1.AppointmentDate) < 0)
                dateTimePicker1.MinDate = DateTime.Now;
            else
                dateTimePicker1.MinDate = appointment1.AppointmentDate;

            dateTimePicker1.Value = appointment1.AppointmentDate;

            if (appointment1.RetakeTestAppID == -1)
            {
                label15.Text = "0";
                label18.Text = "N/A";
            }
            else
            {
                label15.Text = appointment1.RetakeTestAppid.Fees.ToString();
                groupBox2.Enabled = true;
                label4.Text = "Schedule Retake Test";
                label18.Text = appointment1.RetakeTestAppID.ToString();

            }
            return true;
        }

        public void LoadData(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            if (AppointmentID == -1)
                type = eType.Add;
            else
                type = eType.Update;

            ldlapp = LocalDrivingLicenseApplicationID;
            _AppointmentID = AppointmentID;
            ldlapp1 = clsLocalDrivingLicenceApp.FindLocalAppID(ldlapp);

            if (ldlapp1 == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + ldlapp.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2Save.Enabled = false;
                return;
            }

            if (ldlapp1.DoesAttendTestType(_TestTypeID))
                form = eForm.Retake;
            else
                form = eForm.Take;

            if (form == eForm.Retake)
            {
                label4.Text = "Retake Schedule Test";
                groupBox2.Enabled = true;
                label15.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).AppFees.ToString();
            }
            else
            {
                label4.Text = "Schedule Test";
                groupBox2.Enabled = false;
                label15.Text = "0";
                label18.Text = "N/A";
            }

            label11.Text = ldlapp.ToString();
            label12.Text = ldlapp1.licenseclass.ClassName;
            label13.Text = ldlapp1.person.FullName();
            label6.Text = ldlapp1.TotalTrialsPerTest(_TestTypeID).ToString();

            if (type == eType.Add)
            {
                dateTimePicker1.MinDate = DateTime.Now;
                label16.Text = clsTestTypes.Find(_TestTypeID).TestFees.ToString();
                appointment1 = new clsAppointments();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }


            label17.Text = (Convert.ToSingle(label16.Text) + Convert.ToSingle(label15.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (type == eType.Add && clsLocalDrivingLicenceApp.IsThereAnActiveScheduledTest(ldlapp, _TestTypeID))
            {
                label19.Visible = true;
                button2Save.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //ifappointmentislockedthatmeansthepersonalreadysatforthistest
            //wecannotupdatelockedappointment
            if (appointment1.IsLocked)
            {
                label19.Visible = true;
                dateTimePicker1.Enabled = false;
                button2Save.Enabled = false;
                return false;

            }
            else
                label19.Visible = false;

            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypes.eTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    label19.Visible = false;

                    return true;

                case clsTestTypes.eTestType.WriteTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!ldlapp1.DoesPassTestType(clsTestTypes.eTestType.VisionTest))
                    {
                        label19.Text = "Cannot Sechule, Vision Test should be passed first";
                        label19.Visible = true;
                        button2Save.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        label19.Visible = false;
                        button2Save.Enabled = true;
                        dateTimePicker1.Enabled = true;
                    }


                    return true;

                case clsTestTypes.eTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!ldlapp1.DoesPassTestType(clsTestTypes.eTestType.WriteTest))
                    {
                        label19.Text = "Cannot Sechule, Vision Test should be passed first";
                        label19.Visible = true;
                        button2Save.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        label19.Visible = false;
                        button2Save.Enabled = true;
                        dateTimePicker1.Enabled = true;
                    }


                    return true;

            }
            return true;

        }

        private void ScheduleVisionTest_Load(object sender, EventArgs e)
        {

        }

        private void ctrScheduletest1_Load(object sender, EventArgs e)
        {

        }

        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (type == eType.Add && form == eForm.Retake)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplications Application = new clsApplications();

                Application.PersonID = ldlapp1.PersonID;
                Application.AppDate = DateTime.Now;
                Application.AppTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                Application.AppStatus = clsApplications.enApplicationStatus.Completed;
                Application.LastDateStatus = DateTime.Now;
                Application.Fees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).AppFees;
                Application.UserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    appointment1.RetakeTestAppID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                appointment1.RetakeTestAppID = Application.AppID;

            }
            return true;
        }

        private void button2Save_Click(object sender, EventArgs e)
        {

        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void ctrScheduletest_Load(object sender, EventArgs e)
        {
            
        }

      

        private void button2Save_Click_1(object sender, EventArgs e)
        {

        }
    }
}
