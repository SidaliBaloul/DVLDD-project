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
    public partial class ctrPersoninfoWithzfilter : UserControl
    {
        private bool DegitsOnly = true;
        private bool FilterEnabled = false;
        private int _PersonID;

        public event Action<int> OnPersonselected;

        protected virtual void PersonSelected(int personid)
        {
            Action<int> handler = OnPersonselected;

            if(handler != null)
            {
                handler(personid);
            }
        }


        private bool _ShowAddPerson = true;

        public bool showaddperson
        {
            get { return _ShowAddPerson; }

            set
            {
                _ShowAddPerson = value;
                button2.Visible = _ShowAddPerson;
            }
        }

        public void FilterFocus()
        {
            textBox1.Focus();
        }

        public bool filterenabled
        {
            get { return FilterEnabled; }

            set
            {
                FilterEnabled = value;
                groupBox1.Enabled = FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return usrPersonInfos1.PersonID; }
        }

        public clsPerson person1
        {
            get { return usrPersonInfos1.person1; }
        }

        public ctrPersoninfoWithzfilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personid)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = personid.ToString();
            FindNow();
        }

        private void ctrPersoninfoWithzfilter_PaddingChanged(object sender, EventArgs e)
        {
            
        }

        private void ctrPersoninfoWithzfilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }


        private void FindNow()
        {
            switch(comboBox1.Text)
            {
                case "Person ID":
                   usrPersonInfos1.LoadPersonInfo(int.Parse(textBox1.Text));
                    break;

                case "National No":
                   usrPersonInfos1.LoadPersonInfo(textBox1.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonselected != null && FilterEnabled)
                OnPersonselected(usrPersonInfos1.PersonID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Fill Data", "Error");
                return;
            }

            FindNow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdateForm frme = new AddUpdateForm();
            frme.DataBack += DataBackEvent;
            frme.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Text = PersonID.ToString();
            usrPersonInfos1.LoadPersonInfo(PersonID);
        }

        private void usrPersonInfos1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";

            if (comboBox1.SelectedIndex == 0)
                DegitsOnly = true;
            else
                DegitsOnly = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DegitsOnly)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError( textBox1,"Field Required !");
            }
            else
                errorProvider1.SetError(textBox1, null);
        }
    }
}
