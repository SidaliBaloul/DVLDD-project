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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project
{
    public partial class ctrLicensesHistory : UserControl
    {
        private int _DriverID;
        private clsDrivers _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;



        public ctrLicensesHistory()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsDrivers.GetLicenses(_DriverID);


            dataGridView1.DataSource = _dtDriverLocalLicensesHistory;
            label2.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Lic.ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "App.ID";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Class Name";
                dataGridView1.Columns[2].Width = 270;

                dataGridView1.Columns[3].HeaderText = "Issue Date";
                dataGridView1.Columns[3].Width = 170;

                dataGridView1.Columns[4].HeaderText = "Expiration Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 110;

            }
        }

        private void _LoadInternationalLicenseInfo()
        {

            _dtDriverInternationalLicensesHistory = clsDrivers.GetInternationalLicenses(_DriverID);


            dataGridView2.DataSource = _dtDriverInternationalLicensesHistory;
            label2.Text = dataGridView2.Rows.Count.ToString();

            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Columns[0].HeaderText = "Int.License ID";
                dataGridView2.Columns[0].Width = 160;

                dataGridView2.Columns[1].HeaderText = "Application ID";
                dataGridView2.Columns[1].Width = 130;

                dataGridView2.Columns[2].HeaderText = "L.License ID";
                dataGridView2.Columns[2].Width = 130;

                dataGridView2.Columns[3].HeaderText = "Issue Date";
                dataGridView2.Columns[3].Width = 180;

                dataGridView2.Columns[4].HeaderText = "Expiration Date";
                dataGridView2.Columns[4].Width = 180;

                dataGridView2.Columns[5].HeaderText = "Is Active";
                dataGridView2.Columns[5].Width = 120;

            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDrivers.FindByID(_DriverID);

            if (_Driver == null)
            {
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }

        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = clsDrivers.Find(PersonID);

            if (_Driver == null)
            {
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }



        private void ctrLicensesHistory_Load(object sender, EventArgs e)
        {

           

        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
