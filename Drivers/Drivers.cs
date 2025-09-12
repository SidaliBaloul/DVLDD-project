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
    public partial class Drivers : Form
    {
        DataTable dt = clsDrivers.GetDriversList();

        public Drivers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Drivers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dt = clsDrivers.GetDriversList();
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.RowCount.ToString();


            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 140;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 320;

                dataGridView1.Columns[4].HeaderText = "Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Active Licenses";
                dataGridView1.Columns[5].Width = 150;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.Text != "None");


            if (comboBox1.Text == "None")
            {
                textBox1.Enabled = false;
            }
            else
                textBox1.Enabled = true;

            textBox1.Text = "";
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                label3.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            label3.Text = dataGridView1.Rows.Count.ToString();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetailsForm frm = new PersonDetailsForm((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            Drivers_Load(null, null);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Driver ID" || comboBox1.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseHistory frm = new LicenseHistory((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
