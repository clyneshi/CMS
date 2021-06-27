using CMS.DAL.Models;
using CMS.Service.Enums;
using CMS.Service.Global;
using CMS.Service.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class AccountSetting : Form
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IConferenceService _conferenceService;

        public AccountSetting(IUserService userService, IRoleService roleService, IConferenceService conferenceService)
        {
            _userService = userService;
            _roleService = roleService;
            _conferenceService = conferenceService;
            InitializeComponent();
            init();
        }

        public void init()
        {
            InitForm();
        }

        private void InitForm()
        {
            User user = GlobalVariable.CurrentUser;

            textBox_name.Text = user.Name;
            textBox_email.Text = user.Email;
            textBox_cont.Text = user.Contact;
            comboBox_role.Text = _roleService.GetRoleById((int)user.RoleId).Type;

            if (GlobalVariable.CurrentUser.RoleId == (int)RoleTypesEnum.Reviewer
                || GlobalVariable.CurrentUser.RoleId == (int)RoleTypesEnum.Author)
                comboBox_conf.Text = _conferenceService.GetConferences().FirstOrDefault(c => c.Id == GlobalVariable.UserConference).Title;
        }

        // TODO: extract validation method

        private string UserEditValidation()
        {
            if (textBox_name.Text.Trim().Equals(""))
                return "User Name cannot be empty";
            if (textBox_email.Text.Trim().Equals(""))
                return "User Email cannot be empty";

            return "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string error = UserEditValidation();
            if (error.Equals(""))
            {
                _userService.UpdateUser(textBox_name.Text, textBox_email.Text, textBox_cont.Text, textBox_oPass.Text, textBox_nPass.Text);
                MessageBox.Show("Update completed");
            }
            else
                MessageBox.Show(error);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
