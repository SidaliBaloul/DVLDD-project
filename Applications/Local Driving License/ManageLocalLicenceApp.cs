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
    public partial class ManageLocalLicenceApp : Form
    {
        DataTable dt = clsLocalDrivingLicenceApp.GetLocalLicencesApplications();
        public ManageLocalLicenceApp()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void ManageLocalLicenceApp_Load(object sender, EventArgs e)
        {

            dt = clsLocalDrivingLicenceApp.GetLocalLicencesApplications();
            dataGridView1.DataSource = dt;

            label2.Text = dataGridView1.RowCount.ToString();
            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "L.D.L.AppID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 300;

                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 350;

                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
                dataGridView1.Columns[5].Width = 150;
            }

            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
                textBox1.Clear();
                ManageLocalLicenceApp_Load(null, null);
                
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                label2.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());
            label2.Text = dataGridView1.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicence frm = new NewLocalDrivingLicence();
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenceApp app1 = clsLocalDrivingLicenceApp.FindLocalAppID((int)dataGridView1.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are You Sure You Want To Cancel This Application ", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (app1.CancellApplication())
                {
                    MessageBox.Show("Application Cancelled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageLocalLicenceApp_Load(null, null);
                }

                else
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicence frm = new NewLocalDrivingLicence((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void scheduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
           clsLocalDrivingLicenceApp LocalDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editApplicationToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.AppStatus == clsApplications.enApplicationStatus.New);
            scheduleTestsToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.AppStatus == clsApplications.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteApplicationToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.AppStatus == clsApplications.enApplicationStatus.New);



            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.eTestType.VisionTest); 
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.eTestType.WriteTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.eTestType.StreetTest);

            scheduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.AppStatus == clsApplications.enApplicationStatus.New);

            if (scheduleTestsToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void scheduleVisionTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VisionTest frm = new VisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.eTestType.VisionTest);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionTest frm = new VisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.eTestType.StreetTest);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void scheduleTestsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void scheduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionTest frm = new VisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.eTestType.WriteTest);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueDrivingLicense frm = new IssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenceApp.FindLocalAppID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                ShowLicenseInfo frm = new ShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenceApp localDrivingLicenseApplication = clsLocalDrivingLicenceApp.FindLocalAppID(LocalDrivingLicenseApplicationID);
            LicenseHistory frm = new LicenseHistory(localDrivingLicenseApplication.PersonID);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete This Application","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int AppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenceApp  ldlapp3 = clsLocalDrivingLicenceApp.FindLocalAppID(AppID);

                if (ldlapp3.DeleteLocalDrivingApplication())
                {
                    MessageBox.Show("Application Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageLocalLicenceApp_Load(null, null);
                }
                else
                    MessageBox.Show("ERROR While Deleting", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationsDetails frm = new ApplicationsDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageLocalLicenceApp_Load(null, null);
        }
    }
}
