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
    public partial class ManageUsers : Form
    {
        DataTable dt;
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsers()
        {
            dt = clsUser.GetAllUsers();
            dataGridView1.DataSource = dt;

            label2.Text = dataGridView1.Rows.Count.ToString();
        }



        private void ManageUsers_Load(object sender, EventArgs e)
        {
            dt = clsUser.GetAllUsers();
            dataGridView1.DataSource = dt;
            comboBox1.SelectedIndex = 0;
            label2.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 350;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 120;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 120;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";

           
            if(comboBox1.SelectedIndex == 5) 
            {
                comboBox2.Visible = true;
                textBox1.Visible = false;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                textBox1.Visible = (comboBox1.SelectedIndex != 0);
                textBox1.Text = "";
                comboBox2.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if(comboBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                label2.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            label2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = comboBox2.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                dt.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            label2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewUser frm = new AddNewUser();
            frm.ShowDialog();
            _RefreshUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
                {
                    e.Handled = true;
                }
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser frm = new AddNewUser();
            frm.ShowDialog();
            _RefreshUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser frm = new AddNewUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageUsers_Load(null, null);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepassword frm = new changepassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageUsers_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon", "Not Available",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsUser.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Deleted Successfully","SUCCEED",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ManageUsers_Load(null, null);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetailsForm frm = new UserDetailsForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
