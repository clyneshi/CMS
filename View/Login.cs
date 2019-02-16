using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Model;
using System.Data.SqlClient;

namespace CMS
{
    public partial class Login : Form
    {
        private CMSDBEntities cms = new CMSDBEntities();

        public Login()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            roleDisplay();
            confDisplay();
        }

        private void roleDisplay()
        {
            comboBox_role.DataSource = cms.Roles.ToList();
            comboBox_role.DisplayMember = "roleType";
            comboBox_role.ValueMember = "roleId";
        }

        private void confDisplay()
        {
            comboBox_conf.DataSource = cms.Conferences.ToList();
            comboBox_conf.DisplayMember = "confTitle";
            comboBox_conf.ValueMember = "confId";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (userValidation())
            {
                Module.CMSsystem.user_name = textBox_userName.Text;
                Module.CMSsystem.user_role = (int)comboBox_role.SelectedValue;
                Module.CMSsystem.user_conf = (int)comboBox_conf.SelectedValue;
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Incorrect user info!");
            }
        }
        
        // ###
        private bool userValidation()
        {
            if ((int)comboBox_role.SelectedValue == 1 || (int)comboBox_role.SelectedValue == 2)
            {
                //TO DO: use login infomation retrieve database data
                var user = from users in cms.Users
                           where users.userName == textBox_userName.Text
                           && users.userPasswrd == textBox_passwrd.Text
                           && users.roleId == (int?)comboBox_role.SelectedValue
                           select users;

                if (user.Count() != 0)
                {
                    Module.CMSsystem.user_id = user.Single().userId;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                var user = from users in cms.Users
                           join confm in cms.ConferenceMembers on users.userId equals confm.userId
                           where confm.confId == (int)comboBox_conf.SelectedValue
                           && users.userName == textBox_userName.Text
                           && users.userPasswrd == textBox_passwrd.Text
                           && users.roleId == (int?)comboBox_role.SelectedValue
                           select users;
                if (user.Count() != 0)
                {
                    Module.CMSsystem.user_id = user.Single().userId;
                    return true;
                }
                else
                    return false;
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }

        private void comboBox_role_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBox_role.SelectedValue > 2)
                comboBox_conf.Enabled = true;
            else
                comboBox_conf.Enabled = false;
        }
    }
}
