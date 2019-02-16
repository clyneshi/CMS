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
using CMS.Module;

namespace CMS
{
    public partial class AccountSetting : Form
    {
        private CMSDBEntities cms = new CMSDBEntities();
        private CMSsystem cmsm = new CMSsystem();


        public AccountSetting()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            initForm();
        }

        private void initForm()
        {
            User user = cms.Users.FirstOrDefault(u => u.userId == CMSsystem.user_id);
            textBox_name.Text = user.userName;
            textBox_email.Text = user.userEmail;
            textBox_cont.Text = user.userContact;
            comboBox_role.Text = cms.Roles.FirstOrDefault(r => r.roleId == user.roleId).roleType;
            if (CMSsystem.user_role > 2)
                comboBox_conf.Text = cms.Conferences.FirstOrDefault(c => c.confId == CMSsystem.user_conf).confTitle;
        }

        private string userEditValidation()
        {
            string error = "";
            if (textBox_name.Text.Trim().Equals(""))
                return error = "User Name cannot be empty";
            if (textBox_email.Text.Trim().Equals(""))
                return error = "User Email cannot be empty";

            return error;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string error = userEditValidation();
            if (error.Equals(""))
            {
                updateUser();
                MessageBox.Show("Update completed");
            }
            else
                MessageBox.Show(error);
        }

        private void updateUser()
        {
            User user = cms.Users.FirstOrDefault(u => u.userId == CMSsystem.user_id);
            user.userName = textBox_name.Text;
            user.userEmail = textBox_email.Text;
            user.userContact = textBox_cont.Text;
            if (user.userPasswrd == textBox_oPass.Text)
                user.userPasswrd = textBox_nPass.Text;
            cms.SaveChanges();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
