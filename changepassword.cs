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
    public partial class changepassword : Form
    {
        private int _UserID;
        clsUser user1;

        public changepassword(int userid)
        {
            InitializeComponent();

            this._UserID = userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usrPersonInfos1_Load(object sender, EventArgs e)
        {

        }

        private void _ResetValues()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void changepassword_Load(object sender, EventArgs e)
        {
            _ResetValues();
            user1 = clsUser.Find(_UserID);

            if(user1 == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }


            userInfos1.LoadUserInfos(_UserID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user1.Password = textBox2.Text;

            if (user1.Save())
            {
                MessageBox.Show("Data Saved Succefully");
                _ResetValues();
            }
            else
                MessageBox.Show("ERROR !");
        }

        private void userInfos1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Password cannot be blank");
            }
            else
                errorProvider1.SetError(textBox2, null);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Trim() != textBox2.Text.Trim() || string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Password Does Not Match !");
            }
            else
                errorProvider1.SetError(textBox3, null);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Current Password Cannot Be Blank!");
                return;
            }
            else
                errorProvider1.SetError(textBox1, null);


            if (textBox1.Text != user1.Password)
            {
                errorProvider1.SetError(textBox1, "Current Password Incorect");
                textBox1.Focus();
            }
            else
                errorProvider1.Clear();
        }
    }
}
