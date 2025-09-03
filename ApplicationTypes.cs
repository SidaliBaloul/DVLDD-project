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
    public partial class ApplicationTypes : Form
    {
        DataTable dt = clsApplicationTypes.GetApplicationTypesList();

        public ApplicationTypes()
        {
            InitializeComponent();
        }


        private void ApplicationTypes_Load(object sender, EventArgs e)
        {
            dt = clsApplicationTypes.GetApplicationTypesList();
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.RowCount.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 400;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 100;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAppTypes frm = new UpdateAppTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ApplicationTypes_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
