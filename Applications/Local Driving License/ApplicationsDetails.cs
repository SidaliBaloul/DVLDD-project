using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project
{
    public partial class ApplicationsDetails : Form
    {
        private int _ApplicationID = -1;

        public ApplicationsDetails(int ApplicationID )
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;

        }

        private void ApplicationsDetails_Load(object sender, EventArgs e)
        {
            ctrApplicationInfos1.LoadInfosByLocalApplicationID(_ApplicationID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrApplicationInfos1_Load(object sender, EventArgs e)
        {

        }
    }
}
