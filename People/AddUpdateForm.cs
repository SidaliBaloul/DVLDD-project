using DVLD_Business;
using DVLD_project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class AddUpdateForm : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private enum eModes { UpdateMode = 1, AddMode = 2 }
        private eModes Mode;

        private int _personID;
        clsPerson person1;

        public AddUpdateForm()
        {
            InitializeComponent();

            Mode = eModes.AddMode;
        }

        public AddUpdateForm(int personid)
        {
            InitializeComponent();

            Mode = eModes.UpdateMode;
            _personID = personid;
        }

        private void _FillCountriesCombobox()
        {
            DataTable dtcountries = ClsCountry.GetAllCountries();

            foreach(DataRow row in dtcountries.Rows)
            {
                comboBox1.Items.Add(row[1].ToString());
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesCombobox();

            if(Mode == eModes.AddMode)
            {
                label1Title.Text = "Add New Person";
                person1 = new clsPerson();
            }
            else
            {
                label1Title.Text = "Update Person";
            }

            if (radioButton1.Checked)
            {
                pictureBox1.Image = Resources.man;
            }
            else
                pictureBox1.Image = Resources.woman;


            linkLabelRemove.Visible = (pictureBox1.ImageLocation != null);

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);

            comboBox1.SelectedIndex = comboBox1.FindString("Jordan");

            textBoxFirstName.Text = "";
            textBoxSecondName.Text = "";
            textBoxThirdName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            textBoxEmail.Text = "";
            radioButton1.Checked = true;
            textBoxNationalNo.Text = "";

        }

        private void _LoadData()
        {
            person1 = clsPerson.Find(_personID);

            if(person1 == null)
            {
                MessageBox.Show("Person Selected Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            textBoxFirstName.Text = person1.FirstName;
            textBoxSecondName.Text = person1.SecondName;
            textBoxThirdName.Text = person1.ThirdName;
            textBoxLastName.Text = person1.LastName;
            textBoxNationalNo.Text = person1.NationalNo;
            dateTimePicker1.Value = person1.DateOfBirth;

            if (person1.Gender == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            textBoxPhone.Text = person1.Phone;
            textBoxEmail.Text = person1.Email;
            comboBox1.SelectedIndex = comboBox1.FindString(person1.CountryInfo.CountryName);
            textBoxAddress.Text = person1.Address;

            if (person1.ImagePath != "")
                pictureBox1.ImageLocation = person1.ImagePath;

            linkLabelRemove.Visible = (pictureBox1.ImageLocation != "");

        }


        private void AddUpdateForm_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == eModes.UpdateMode)
                _LoadData();
        }

        private void ctrFillPersonInfos1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandleImagePerson()
        {
            if(person1.ImagePath != pictureBox1.ImageLocation)
            {
                if(person1.ImagePath != "")
                {
                    try
                    {
                        File.Delete(person1.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if(pictureBox1.ImageLocation != null)
                {
                    string sourceimagefile = pictureBox1.ImageLocation.ToString();

                    if(clsUtil.CopyImageToProjectImagesFolder(ref sourceimagefile))
                    {
                        pictureBox1.ImageLocation = sourceimagefile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

           if(!this.ValidateChildren())
           {
                MessageBox.Show("There Is Something Missing , Check Your Data","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
           }

            if (!_HandleImagePerson())
                return;


            int countryid = ClsCountry.FindByName(comboBox1.Text).CountryID;
            person1.FirstName = textBoxFirstName.Text;
            person1.SecondName = textBoxSecondName.Text;
            person1.ThirdName = textBoxThirdName.Text;
            person1.LastName = textBoxLastName.Text;
            person1.NationalNo = textBoxNationalNo.Text;
            person1.DateOfBirth = dateTimePicker1.Value;
            person1.Email = textBoxEmail.Text;
            person1.Phone = textBoxPhone.Text;
            person1.Address = textBoxAddress.Text;

            if (radioButton1.Checked)
                person1.Gender = 0;
            else
                person1.Gender = 1;

            person1.CountryID = countryid;

            if (pictureBox1.ImageLocation != null)
                person1.ImagePath = pictureBox1.ImageLocation.ToString();
            else
                person1.ImagePath = "";

            if(person1.Save())
            {
                label3PersonIDvalue.Text = person1.PersonID.ToString();
                Mode = eModes.UpdateMode;

                label1Title.Text = "Update Person";

                MessageBox.Show("Data Saved Succesfully ","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

                DataBack?.Invoke(this, person1.PersonID);
            }
            else
                MessageBox.Show("Error While Saving Data ","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxNationalNo, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxNationalNo, null);

            if (textBoxNationalNo.Text.Trim() != person1.NationalNo && clsPerson.IsExist(textBoxNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxNationalNo, "This NationalNo Is Already Takken !");
            }
            else
                errorProvider1.SetError(textBoxNationalNo, null);
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(textBoxEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxEmail, "Invalid Email Address Format");
            }
            else
                errorProvider1.SetError(textBoxEmail, null);
        }

        private void textBoxNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && pictureBox1.ImageLocation == null)
                pictureBox1.Image = Resources.man;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && pictureBox1.ImageLocation == null)
                pictureBox1.Image = Resources.woman;
        }

        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               string filepath = openFileDialog1.FileName;
                pictureBox1.Load(filepath);
                linkLabelRemove.Visible = true;
               
            }
        }

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;

            if (radioButton1.Checked)
                pictureBox1.Image = Resources.man;
            else
                pictureBox1.Image = Resources.woman;

            linkLabelRemove.Visible = false;
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxPhone, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxPhone, null);
        }

        private void textBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxAddress, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxAddress, null);
        }

        private void textBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxLastName, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxLastName, null);
        }

        private void textBoxSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSecondName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxSecondName, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxSecondName, null);
        }

        private void textBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxFirstName, "This Field Is Required !");
                return;
            }
            else
                errorProvider1.SetError(textBoxFirstName, null);
        }
    }
}
