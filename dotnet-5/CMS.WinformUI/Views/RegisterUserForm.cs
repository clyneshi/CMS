using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Services.Interfaces;
using CMS.WinformUI.Utils;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CMS;

public partial class RegisterUserForm : Form
{
    private readonly IFormUtil _formUtil;
    private readonly IRoleService _roleService;
    private readonly IUserRequestService _userRequestService;
    private readonly IConferenceService _conferenceService;

    public RegisterUserForm(IFormUtil formUtil,
        IRoleService roleService,
        IUserRequestService userRequest,
        IConferenceService conferenceService)
    {
        _formUtil = formUtil;
        _roleService = roleService;
        _userRequestService = userRequest;
        _conferenceService = conferenceService;

        InitializeComponent();
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await Init();
    }

    private async Task Init()
    {
        comboBox_conference.DataSource = await _conferenceService.GetConferencesAsync();
        comboBox_conference.DisplayMember = "Title";
        comboBox_conference.ValueMember = "Id";
        comboBox_conference.SelectedIndex = -1;

        comboBox_role.DataSource = await _roleService.GetRolesAsync();
        comboBox_role.DisplayMember = "Type";
        comboBox_role.ValueMember = "Id";
        comboBox_role.SelectedIndex = -1;
    }

    private void RedirectToLogInView()
    {
        var loginView = _formUtil.GetForm<LoginForm>();
        loginView.Show();
        this.Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
        RedirectToLogInView();
    }

    private void comboBox_role_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if ((int)comboBox_role.SelectedValue == (int)RoleTypesEnum.Chair)
            comboBox_conference.Enabled = false;
        else
            comboBox_conference.Enabled = true;
    }

    private async Task AddRegisterRequest()
    {
        var request = new RegisterRequest();
        if (comboBox_conference.Enabled == true)
            request.ConferenceId = (int)comboBox_conference.SelectedValue;
        request.Name = textBox_name.Text.Trim();
        request.Password = textBox_password.Text;
        request.Email = textBox_email.Text;
        request.Contact = textBox_cont.Text;
        request.Status = UserRequestStatusEnum.Waiting.ToString();
        request.RoleId = (int)comboBox_role.SelectedValue;

        await _userRequestService.AddRegisterRequestAsync(request);
    }

    // TODO: extract validation method
    private string ValidateUserRegister()
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
            && comboBox_conference.SelectedValue == null)
            return "Conference cannot be empty";

        return "";
    }

    private async void btn_submit_Click(object sender, EventArgs e)
    {
        string error = ValidateUserRegister();
        if (error.Equals(""))
        {
            await AddRegisterRequest();
            MessageBox.Show("Successfully sent out registration request!");
            RedirectToLogInView();
        }
        else
            MessageBox.Show(error);
    }
}
