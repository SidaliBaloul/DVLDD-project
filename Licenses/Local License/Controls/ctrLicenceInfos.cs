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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_project
{
    public partial class ctrLicenceInfos : UserControl
    {

         
        public event Action<int> OnLicenseselected;
        protected virtual void LicenseSelected(int licenseid)
        {

            Action<int> handler = OnLicenseselected;

            if (handler != null)
            {
                handler(licenseid);
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                groupBox1.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return ctrDriverLicenseInfo1.LicenseID; }
        }

        public clsLicenses SelectedLicenseInfo
        { 
            get 
            {
                return ctrDriverLicenseInfo1.SelectedLicenseInfo; 
            } 
        }


        public ctrLicenceInfos()
        {
            InitializeComponent();
        }

        

        private void ctrDriverLicenseInfo1_Load(object sender, EventArgs e)
        {
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void FindNowWithAuto()
        {
            
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            textBox1.Text = LicenseID.ToString();
            ctrDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
            _LicenseID = ctrDriverLicenseInfo1.LicenseID;

            if (OnLicenseselected != null && FilterEnabled)
                OnLicenseselected(_LicenseID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;

            }
            _LicenseID = int.Parse(textBox1.Text);
            LoadLicenseInfo(_LicenseID);
        }

        public void txtLicenseIDFocus()
        {
            textBox1.Focus();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {

                button1.PerformClick();
            }
        }
    }
}
