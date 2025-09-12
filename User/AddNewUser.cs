using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class AddNewUser : Form
    {

        private enum eMode { Update = 1, Add = 2}
        private eMode mode;

        int _PersonID = 0;
        int _UserID;
        clsUser user1;

        public AddNewUser()
        {
            InitializeComponent();

            mode = eMode.Add;
        }
        public AddNewUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            mode = eMode.Update;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void _ResetDefaultValues()
        {
            if(mode == eMode.Add)
            {
                label1.Text = "Add New User";
                user1 = new clsUser();
                button2.Enabled = false;
                ctrPersoninfoWithzfilter1.filterenabled = true;
                tabPage2.Enabled = false;
            }
            else
            {
                label1.Text = "Update User";
                button2.Enabled = false;
                ctrPersoninfoWithzfilter1.filterenabled = false;
                tabPage2.Enabled = true;
            }

            label6.Text = "????";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void _LoadData()
        {
            user1 = clsUser.Find(_UserID);

            if(user1 == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }


            ctrPersoninfoWithzfilter1.LoadPersonInfo(user1.PersonID);
            label6.Text = _UserID.ToString();
            textBox1.Text = user1.UserName;
            textBox2.Text = user1.Password;
            textBox3.Text = user1.Password;
            checkBox1.Checked = user1.isActive;


        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (mode == eMode.Update)
                _LoadData();
        }

        private void usrPersonInfos1_Load(object sender, EventArgs e)
        {

        }

        private void ctrPersoninfoWithzfilter1_OnPersonselected(int obj)
        {
            _PersonID = obj;
            MessageBox.Show("PersonId : " +  obj.ToString());
        }


        private void ctrPersoninfoWithzfilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(mode == eMode.Update)
            {
                tabPage2.Enabled = true;
                button2.Enabled = true;
                tabconrole1.SelectedIndex = 1;
                return;
            }

            if (ctrPersoninfoWithzfilter1.PersonID != -1 || ctrPersoninfoWithzfilter1.PersonID != 0)
            {
                if (clsUser.IsPersonIDAlreadyAttached(ctrPersoninfoWithzfilter1.PersonID))
                {
                    MessageBox.Show("This Person Is Already Attached To A User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tabPage2.Enabled = true;
                    button2.Enabled = true;
                    tabconrole1.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Please Search For A Person To Attach ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Leave(object sender, EventArgs e)
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

            user1.PersonID = ctrPersoninfoWithzfilter1.PersonID;
            user1.UserName = textBox1.Text;
            user1.Password = textBox2.Text;
            user1.isActive = (checkBox1.Checked);

            if (user1.Save())
            {
                label6.Text = user1.UserID.ToString();
                mode = eMode.Update;
                label1.Text = "Update User";

                MessageBox.Show("Data Saved Succefully");
                button2.Enabled = false;
            }
            else
                MessageBox.Show("ERROR !");

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabconrole1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrPersoninfoWithzfilter1_Leave(object sender, EventArgs e)
        {
           

        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
          

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if(textBox3.Text != textBox2.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Password Does Not Match !");
            }
            else
                errorProvider1.SetError(textBox3, null);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Password cannot be blank");
            }
            else
                errorProvider1.SetError(textBox2, null);

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            };

            if(mode == eMode.Add)
            {
                if(clsUser.IsUserExists(textBox1.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox1, "username is used by another user");
                }
                else
                    errorProvider1.SetError(textBox1, null);
            }
            else
            {
                if(user1.UserName != textBox1.Text)
                {
                    if (clsUser.IsUserExists(textBox1.Text))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(textBox1, "username is used by another user");
                    }
                    else
                        errorProvider1.SetError(textBox1, null);
                }
            }

        }
    }
}
