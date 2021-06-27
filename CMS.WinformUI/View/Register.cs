using CMS.DAL.Models;
using CMS.Service.Enums;
using CMS.Service.Service;
using CMS.WinformUI.Utils;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Register : Form
    {
        private readonly IFormUtil _formUtil;
        private readonly IRoleService _roleService;
        private readonly IUserRequestService _userRequestService;
        private readonly IConferenceService _conferenceService;

        public Register(IFormUtil formUtil,
            IRoleService roleService,
            IUserRequestService userRequest,
            IConferenceService conferenceService)
        {
            _formUtil = formUtil;
            _roleService = roleService;
            _userRequestService = userRequest;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            comboBox_conf.DataSource = _conferenceService.GetConferences();
            comboBox_conf.DisplayMember = "Title";
            comboBox_conf.ValueMember = "Id";
            comboBox_conf.SelectedIndex = -1;

            comboBox_role.DataSource = _roleService.GetRoles();
            comboBox_role.DisplayMember = "Type";
            comboBox_role.ValueMember = "Id";
            comboBox_role.SelectedIndex = -1;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            var lg = _formUtil.GetForm<Login>();
            lg.Show();
            this.Close();
        }

        private void comboBox_role_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBox_role.SelectedValue == 2)
            {
                comboBox_conf.Enabled = false;
            }
            else
                comboBox_conf.Enabled = true;
        }

        private bool AddRequest()
        {
            RegisterRequest request = new RegisterRequest();
            if (comboBox_conf.Enabled == true)
                request.ConferenceId = (int)comboBox_conf.SelectedValue;
            request.Name = textBox_name.Text.Trim();
            request.Password = textBox_password.Text;
            request.Email = textBox_email.Text;
            request.Contact = textBox_cont.Text;
            request.Status = UserRequestStatusEnum.Waiting.ToString();
            request.RoleId = (int)comboBox_role.SelectedValue;
            _userRequestService.AddRegisterRequest(request);

            return true;
        }

        // TODO: extract validation method
        private string UserRegValidation()
        {
            if (textBox_name.Text.Trim().Equals(""))
                return "User Name cannot be empty";
            if (textBox_password.Text.Trim().Equals(""))
                return "User Password cannot be empty";
            if (textBox_email.Text.Trim().Equals(""))
                return "User Email cannot be empty";
            if (comboBox_role.SelectedValue == null)
                return "User Role cannot be empty";
            if (((int)comboBox_role.SelectedValue == 3
                || (int)comboBox_role.SelectedValue == 4)
                && comboBox_conf.SelectedValue == null)
                return "Conference cannot be empty";

            return "";
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string error = UserRegValidation();
            if (error.Equals("") && AddRequest() == true)
            {
                MessageBox.Show("Submit Successful!");
                //var lg = _formUtil.CreateForm<Login>();
                //lg.Show();
                this.Close();
            }
            else
                MessageBox.Show(error);
        }
    }
}
