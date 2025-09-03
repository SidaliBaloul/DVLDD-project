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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_project
{
    public partial class NewLocalDrivingLicence : Form
    {

        private enum eMode { Update = 1, Add = 2 }
        private eMode mode;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenceApp _LocalDrivingLicenseApplication;

        public NewLocalDrivingLicence()
        {
            InitializeComponent();

            mode = eMode.Add;

        }

        public NewLocalDrivingLicence(int AppID)
        {
            InitializeComponent();

            mode = eMode.Update;

            _LocalDrivingLicenseApplicationID = AppID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillComboBox()
        {
            DataTable mt = clsLicenceClasses.GetLicenceClassesList();

            foreach (DataRow row in mt.Rows)
            {
                comboBox1.Items.Add(row[1]);
            }
        }

        private void _ResetDataValues()
        {
            _FillComboBox();

            if (mode == eMode.Add)
            {
                ctrPersoninfoWithzfilter1.filterenabled = true;
                label1.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenceApp();
                ctrPersoninfoWithzfilter1.FilterFocus();
                tabPage2.Enabled = false;

                comboBox1.SelectedIndex = 2;
                label9.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).AppFees.ToString();
                label8.Text = DateTime.Now.ToShortDateString();
                label10.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                label1.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tabPage2.Enabled = true;
                button2.Enabled = true;

            }
        }

        private void _LoadData()
        {
           ctrPersoninfoWithzfilter1.filterenabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrPersoninfoWithzfilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.PersonID);
            label6.Text = _LocalDrivingLicenseApplication.AppID.ToString();
            label8.Text = _LocalDrivingLicenseApplication.AppDate.ToShortDateString();
            comboBox1.SelectedIndex = comboBox1.FindString(clsLicenceClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            label9.Text = _LocalDrivingLicenseApplication.Fees.ToString();
            label10.Text = clsUser.Find(_LocalDrivingLicenseApplication.UserID).UserName;

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrPersoninfoWithzfilter1.LoadPersonInfo(PersonID);


        }

        private void NewLocalDrivingLicence_Load(object sender, EventArgs e)
        {
            _ResetDataValues();

            if(mode == eMode.Update)
                _LoadData();
        }

        private void SaveApplicationData()
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenceClasses.Find(comboBox1.Text).LicenseClassID;


            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplications.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicenses.IsLicenseExistByPersonID(ctrPersoninfoWithzfilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.PersonID = ctrPersoninfoWithzfilter1.PersonID; ;
            _LocalDrivingLicenseApplication.AppDate = DateTime.Now;
            _LocalDrivingLicenseApplication.AppTypeID = 1;
            _LocalDrivingLicenseApplication.AppStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastDateStatus = DateTime.Now;
            _LocalDrivingLicenseApplication.Fees = Convert.ToSingle(label9.Text);
            _LocalDrivingLicenseApplication.UserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                label6.Text = _LocalDrivingLicenseApplication.AppID.ToString();
                //change form mode to update.
                mode = eMode.Update;
                label1.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrPersoninfoWithzfilter1_Load(object sender, EventArgs e)
        {

        }

        private void ctrPersoninfoWithzfilter1_OnPersonselected(int obj)
        {
            _SelectedPersonID = obj;
        }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mode == eMode.Update)
            {
                button2.Enabled = true;
                tabPage2.Enabled = true;
                tabcontrol1.SelectedTab = tabcontrol1.TabPages[1];
                return;
            }


            //incase of add new mode.
            if (ctrPersoninfoWithzfilter1.PersonID != -1)
            {

                button2.Enabled = true;
                tabPage2.Enabled = true;
                tabcontrol1.SelectedTab = tabcontrol1.TabPages[1];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersoninfoWithzfilter1.FilterFocus();
            }

        }

        private void NewLocalDrivingLicence_Activated(object sender, EventArgs e)
        {
            ctrPersoninfoWithzfilter1.FilterFocus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
