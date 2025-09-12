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
    public partial class UpdateTestTypeForm : Form
    {

        clsTestTypes test1;
        clsTestTypes.eTestType _TestID;

        public UpdateTestTypeForm(clsTestTypes.eTestType Testid)
        {
            InitializeComponent();

            _TestID = Testid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestTypeForm_Load(object sender, EventArgs e)
        {
            test1 = clsTestTypes.Find(_TestID);

            if (test1 != null)
            {
                label6.Text = _TestID.ToString();
                textBox1.Text = test1.TestName;
                textBox2.Text = test1.TestDescription;
                textBox3.Text = test1.TestFees.ToString();
            }
            else

            {
                MessageBox.Show("Could not find Test Type with id = " + _TestID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            test1.TestName = textBox1.Text.Trim();
            test1.TestDescription = textBox2.Text;
            test1.TestFees = Convert.ToDouble(textBox3.Text.Trim());

            if (test1.Save())
            {
                MessageBox.Show("Data Updated Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error While Updating Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Title Can Not Be Blank !");
            }
            else
                errorProvider1.SetError(textBox1, null);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Fees Can Not Be Blank !");
            }
            else
                errorProvider1.SetError(textBox3, null);

            if(!clsValidation.IsNumber(textBox3.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Fees Can Not Be a String !");
            }
            else
                errorProvider1.SetError(textBox3, null);

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Description Can Not Be Blank !");
            }
            else
                errorProvider1.SetError(textBox2, null);
        }
    }
}
