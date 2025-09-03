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
    public partial class UpdateAppTypes : Form
    {
        private int _ApplicationID;
        clsApplicationTypes app1;

        public UpdateAppTypes(int applicationid)
        {
            InitializeComponent();

            _ApplicationID = applicationid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateAppTypes_Load(object sender, EventArgs e)
        {
            app1 = clsApplicationTypes.Find(_ApplicationID);

            if (app1 != null)
            {
                label5.Text = app1.AppID.ToString();
                textBox1.Text = app1.AppName;
                textBox2.Text = app1.AppFees.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            app1.AppName = textBox1.Text;
            app1.AppFees = Convert.ToDouble(textBox2.Text);

            if (app1.Save())
            {
                MessageBox.Show("Data Updated Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error While Updating Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            };
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
            };

            if (!clsValidation.IsNumber(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
            };
        }
    }
}
