using CMS.BL.Enums;
using CMS.BL.Services.Interface;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CMS
{
    public partial class AccountSettingForm : Form
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;

        public AccountSettingForm(
            IUserService userService,
            IRoleService roleService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _userService = userService;
            _roleService = roleService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitAsync();
        }

        public async Task InitAsync()
        {
            var currentUser = _applicationStrategy.GetLoggedInUserInfo();

            textBox_name.Text = currentUser.User.Name;
            textBox_email.Text = currentUser.User.Email;
            textBox_cont.Text = currentUser.User.Contact;
            comboBox_role.Text = _roleService.GetRoleById(currentUser.User.RoleId).Type;

            if (currentUser.User.RoleId == (int)RoleTypesEnum.Reviewer
                || currentUser.User.RoleId == (int)RoleTypesEnum.Author)
            {
                comboBox_conf.Text = (await _conferenceService.GetConferencesAsync())
                    .FirstOrDefault(c => c.Id == currentUser.ConferenceId).Title;
            }

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
