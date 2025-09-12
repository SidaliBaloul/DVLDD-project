using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using System.IO;

namespace DVLD_project
{
    public partial class Form2 : Form
    {
        private static DataTable dt = clsPerson.GetAllPeople();

        private DataTable dt2 = dt.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _RefreshPeopleList()
        {
            dt = clsPerson.GetAllPeople();
            dt2 = dt.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dataGridView1.DataSource = dt2;
            label3.Text = dataGridView1.RowCount.ToString();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            comboBox1.SelectedIndex = 0;
            if (dataGridView1.RowCount > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "National No.";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 140;

                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 140;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 120;

                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 120;

                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 170;
            }

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                dt2.DefaultView.RowFilter = "";
                label3.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                dt2.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                dt2.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            label3.Text = dataGridView1.RowCount.ToString();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.Text != "None");

            if(textBox1.Visible)
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPersonForm()
        {
            AddUpdateForm frm = new AddUpdateForm();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPersonForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateForm frmm = new AddUpdateForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetailsForm frp = new PersonDetailsForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frp.ShowDialog();
            _RefreshPeopleList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Available Currently", "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Available Currently", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddPersonForm();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddPersonForm();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
