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
    public partial class UserDetailsForm : Form
    {
        private int _UserID;

        public UserDetailsForm(int userid)
        {
            InitializeComponent();

            this._UserID = userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            userInfos1.LoadUserInfos(_UserID);
        }

        private void userInfos1_Load(object sender, EventArgs e)
        {

        }
    }
}
