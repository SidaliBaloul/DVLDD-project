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
using System.Xml.Linq;

namespace DVLD_project
{
    public partial class TakeTest : Form
    {

        private int _AppointmentID;
        private clsTestTypes.eTestType _TestType;

        private int _TestID = -1;
        private Test _Test;


        public TakeTest(int AppointmentID, clsTestTypes.eTestType TestType )
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

    

        private void button1Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            ctrscheduledtest1.TestTypeID = _TestType;

            ctrscheduledtest1.LoadInfo(_AppointmentID);

            if (ctrscheduledtest1.TestAppointmentID == -1)
                button2Save.Enabled = false;
            else
                button2Save.Enabled = true;


            int _TestID = ctrscheduledtest1.TestID;

            if (_TestID != -1)
            {
                _Test = Test.Find(_TestID);

                if (_Test.TestResult)
                   radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                textBox1.Text = _Test.Notes;

                //lblUserMessage.Visible = true;
                radioButton2.Enabled = false;
                radioButton1.Enabled = false;
            }

            else
                _Test = new Test();
        }

        private void button2Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = radioButton1.Checked;
            _Test.Notes = textBox1.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2Save.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
