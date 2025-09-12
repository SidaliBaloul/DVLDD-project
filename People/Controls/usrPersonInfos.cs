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
    public partial class usrPersonInfos : UserControl
    {
        private int _PersonID;
        clsPerson person;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson person1
        {
            get { return person; }
        }

        private void _FillImage()
        {
            if (person.Gender == 0)
                pictureBox1.Image = Resources.man;
            else
                pictureBox1.Image = Resources.woman;

            string imagepath = person.ImagePath;

            if(imagepath != "")
                if(File.Exists(imagepath))
                {
                    pictureBox1.ImageLocation = imagepath;
                }
            
        }

        private void FillusrPersonInfoComponents()
        {
            labelid.Text = person.PersonID.ToString();
            _PersonID = person.PersonID;
            labelnam.Text = person.FullName();
            labelnotio.Text = person.NationalNo.ToString();
            labelgend.Text = person.Gender == 0 ? "Male" : "Female";
            labelgmail.Text = person.Email;
            labeladdres.Text = person.Address;
            labeldate.Text = person.DateOfBirth.ToShortDateString();
            labelphon.Text = person.Phone;
            labelcount.Text = person.CountryInfo.CountryName;
            _FillImage();
        }

        public void ClearData()
        {
            labelid.Text = "????";
            labelnam.Text = "????";
            labelnotio.Text = "????";
            labelgend.Text = "????";
            labelgmail.Text = "????";
            labelphon.Text = "????";
            labeladdres.Text = "????";
            labeldate.Text = "????";
            labelcount.Text = "????";
            pictureBox1.Image = Resources.man;
        }

        public void LoadPersonInfo(string nationalno)
        {
            person = clsPerson.FindByNationalNo(nationalno);

            if (person == null)
            {
                MessageBox.Show("Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                return;
            }

            FillusrPersonInfoComponents();
        }
        public void LoadPersonInfo(int personid)
        {
            person = clsPerson.Find(personid);

            if (person == null)
            {
                MessageBox.Show("Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                return;
            }

            FillusrPersonInfoComponents();
        }

        

        public usrPersonInfos()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateForm frmm = new AddUpdateForm(_PersonID);
            frmm.ShowDialog();

            LoadPersonInfo(_PersonID);
            
        }

        private void labelcount_Click(object sender, EventArgs e)
        {

        }

        private void usrPersonInfos_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelgend_Click(object sender, EventArgs e)
        {

        }
    }
}
