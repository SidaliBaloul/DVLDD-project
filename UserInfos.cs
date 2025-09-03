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
    public partial class UserInfos : UserControl
    {
        clsUser user1;
        private int _UserID;

        public UserInfos()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            usrPersonInfos1.ClearData();
            label7UserID.Text = "??";
            label7UserName.Text = "??";
            label7IsActive.Text = "??";
        }

        private void _FillUserData()
        {
            label7UserID.Text = user1.UserID.ToString();
            label7UserName.Text = user1.UserName;

            if (user1.isActive)
                label7IsActive.Text = "YES";
            else
                label7IsActive.Text = "NO";

            usrPersonInfos1.LoadPersonInfo(user1.PersonID);
        }

        public void LoadUserInfos(int UserID)
        {
            user1 = clsUser.Find(UserID);

            if(user1 == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void usrPersonInfos1_Load(object sender, EventArgs e)
        {

        }
    }
}
