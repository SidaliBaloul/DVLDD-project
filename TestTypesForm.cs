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
    public partial class TestTypesForm : Form
    {
        private DataTable dt;
        public TestTypesForm()
        {
            InitializeComponent();
        }


        private void TestTypesForm_Load(object sender, EventArgs e)
        {
            dt = clsTestTypes.GetTestTypesList();
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.RowCount.ToString();

            if (dataGridView1.RowCount > 0)
            {

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Description";
                dataGridView1.Columns[2].Width = 400;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTestTypeForm frm = new UpdateTestTypeForm((clsTestTypes.eTestType)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            TestTypesForm_Load(null, null);
        }
    }
}
