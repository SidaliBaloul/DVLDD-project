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
using System.IO;

namespace DVLD_project
{
    public partial class LoginScreen : Form
    {
        private clsUser user1;
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void SaveDataToFile()
        {
            string path = @"C:\Users\Sidali\Documents\UserNamefile.txt";
            File.WriteAllText(path, textBox1.Text);

            string path2 = @"C:\Users\Sidali\Documents\Passwordfile.txt";
            File.WriteAllText(path2, textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user1 = clsUser.FindByUserNameAndPassword(textBox1.Text.Trim(), textBox2.Text.Trim());

            if(user1 != null)
            {
                if(checkBox1.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(textBox1.Text.Trim(), textBox2.Text.Trim());
                }
                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                if(!user1.isActive)
                {
                    textBox1.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user1;
                this.Hide();
                Form1 frm = new Form1(this);
                frm.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string username = "", password = "";

            if(clsGlobal.GetStoredCredential(ref username, ref password))
            {
                textBox1.Text = username;
                textBox2.Text = password;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;
        }
    }
}
