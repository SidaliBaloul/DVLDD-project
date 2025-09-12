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
    public partial class PersonDetailsForm : Form
    {

        public PersonDetailsForm(int PersonID)
        {
            InitializeComponent();

            usrPersonInfos1.LoadPersonInfo(PersonID);
        }

        public PersonDetailsForm(string NationalNo)
        {
            InitializeComponent();

            usrPersonInfos1.LoadPersonInfo(NationalNo);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void _LoadData()
        {
            

        }

        private void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void usrPersonInfos1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
