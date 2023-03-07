using CMS.BL.Enums;
using CMS.BL.Services.Interfaces;
using CMS.WinformUI.Utils;
using System;
using System.Windows.Forms;

namespace CMS;

public partial class HomeForm : Form
{
    private readonly IFormUtil _formUtil;
    private readonly IApplicationStrategy _applicationStrategy;

    private ConferenceInfoAdminForm _conferenceInfoAdminView;
    private ConferenceInfoForm _conferenceInfoView;
    private SubmitPaperForm _submitPaperView;
    private AssignPaperForm _assignPaperView;
    private LaunchConferenceForm _launchConferenceView;
    private ReviewPaperForm _reviewPaperView;
    private MakeDecisionForm _makeDecisionView;
    private ReviewRegistrationRequestForm _validateRequestView;
    private PaperFeedbackForm _paperStatusView;

    public HomeForm(IFormUtil formUtil, IApplicationStrategy applicationStrategy)
    {
        _formUtil = formUtil;
        _applicationStrategy = applicationStrategy;

        InitializeComponent();
        MenuInit((RoleTypesEnum)_applicationStrategy.GetLoggedInUserInfo().User.RoleId);
    }

    public void MenuInit(RoleTypesEnum role)
    {
        switch (role)
        {
            case RoleTypesEnum.Admin:
                {
                    ToolStripMenuItem strip_conference_userInfo = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_paperInfo = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_validateRequest = new ToolStripMenuItem();
                    strip_conference_userInfo.Text = "User Information";
                    strip_conference_paperInfo.Text = "Paper Information";
                    strip_conference_validateRequest.Text = "Validate Request";
                    strip_conference.DropDownItems.Add(strip_conference_userInfo);
                    strip_conference.DropDownItems.Add(strip_conference_paperInfo);
                    strip_conference.DropDownItems.Add(strip_conference_validateRequest);
                    strip_conference_validateRequest.Click += new System.EventHandler(strip_conference_validRequest_Click);
                    strip_conference_userInfo.Click += new System.EventHandler(strip_conference_userInfo_Click);
                    strip_conference_paperInfo.Click += new System.EventHandler(strip_conference_paperInfo_Click);
                    break;
                }

            case RoleTypesEnum.Chair:
                {
                    ToolStripMenuItem strip_conference_launchConference = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_assignReviewer = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_makeDecision = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_validateRequest = new ToolStripMenuItem();
                    strip_conference_launchConference.Text = "Launch Conference";
                    strip_conference_assignReviewer.Text = "Assign Reviewer";
                    strip_conference_makeDecision.Text = "Evaluate Paper";
                    strip_conference_validateRequest.Text = "Validate Request";
                    strip_conference.DropDownItems.Add(strip_conference_launchConference);
                    strip_conference.DropDownItems.Add(strip_conference_assignReviewer);
                    strip_conference.DropDownItems.Add(strip_conference_makeDecision);
                    strip_conference.DropDownItems.Add(strip_conference_validateRequest);
                    strip_conference_launchConference.Click += new System.EventHandler(strip_conference_launchConference_Click);
                    strip_conference_assignReviewer.Click += new System.EventHandler(strip_conference_assignReviewer_Click);
                    strip_conference_makeDecision.Click += new System.EventHandler(strip_conference_makeDecision_Click);
                    strip_conference_validateRequest.Click += new System.EventHandler(strip_conference_validRequest_Click);
                    break;
                }

            case RoleTypesEnum.Reviewer:
                {
                    ToolStripMenuItem strip_conference_reviewPaper = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_validateRequest = new ToolStripMenuItem();
                    strip_conference_reviewPaper.Text = "Review Paper";
                    strip_conference.DropDownItems.Add(strip_conference_reviewPaper);
                    strip_conference_reviewPaper.Click += new System.EventHandler(strip_conference_reviewPaper_Click);
                    break;
                }

            case RoleTypesEnum.Author:
                {
                    ToolStripMenuItem strip_conference_submitPaper = new ToolStripMenuItem();
                    ToolStripMenuItem strip_conference_paperStatus = new ToolStripMenuItem();
                    strip_conference_submitPaper.Text = "Submit Paper";
                    strip_conference_paperStatus.Text = "Paper Status";
                    strip_conference.DropDownItems.Add(strip_conference_submitPaper);
                    strip_conference.DropDownItems.Add(strip_conference_paperStatus);
                    strip_conference_submitPaper.Click += new System.EventHandler(strip_conference_submitPaper_Click);
                    strip_conference_paperStatus.Click += new System.EventHandler(strip_conference_paperStatus_Click);
                    break;
                }
        }
    }

    private void MDIParent1_Load(object sender, EventArgs e)
    {
        txt_status.Text = _applicationStrategy.GetLoggedInUserInfo().User.Name;
    }

    private void strip_user_logout_Click(object sender, EventArgs e)
    {
        this.Close();
        var login = _formUtil.GetForm<LoginForm>();
        login.Show();
    }

    private void strip_system_exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private async void strip_conference_submitPaper_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;

        if (_submitPaperView == null)
        {
            _submitPaperView = _formUtil.GetForm<SubmitPaperForm>();
            FormInit(_submitPaperView);
        }
        else
        {
            await _submitPaperView.Init();
            _submitPaperView.Activate();
        }
    }

    private void FormInit(Form form)
    {
        pictureBox1.Visible = false;
        form.MdiParent = this;
        form.Show();
        form.ControlBox = false;
        form.WindowState = FormWindowState.Minimized;
        form.WindowState = FormWindowState.Maximized;
    }

    private async void strip_conference_launchConference_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_launchConferenceView == null)
        {
            _launchConferenceView = _formUtil.GetForm<LaunchConferenceForm>();
            FormInit(_launchConferenceView);
        }
        else
        {
            await _launchConferenceView.Init();
            _launchConferenceView.Activate();
        }
    }

    private async void strip_conference_assignReviewer_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_assignPaperView == null)
        {
            _assignPaperView = _formUtil.GetForm<AssignPaperForm>();
            FormInit(_assignPaperView);
        }
        else
        {
            await _assignPaperView.InitAsync();
            _assignPaperView.Activate();
        }
    }

    private async void strip_conference_reviewPaper_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_reviewPaperView == null)
        {
            _reviewPaperView = _formUtil.GetForm<ReviewPaperForm>();
            FormInit(_reviewPaperView);
        }
        else
        {
            await _reviewPaperView.Init();
            _reviewPaperView.Activate();
        }
    }

    private async void strip_conference_makeDecision_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_makeDecisionView == null)
        {
            _makeDecisionView = _formUtil.GetForm<MakeDecisionForm>();
            FormInit(_makeDecisionView);
        }
        else
        {
            await _makeDecisionView.InitAsync();
            _makeDecisionView.Activate();
        }
    }

    private async void strip_conference_validRequest_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_validateRequestView == null)
        {
            _validateRequestView = _formUtil.GetForm<ReviewRegistrationRequestForm>();
            FormInit(_validateRequestView);
        }
        else
        {
            await _validateRequestView.Init();
            _validateRequestView.Activate();
        }
    }

    private async void strip_conference_paperStatus_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_paperStatusView == null)
        {
            _paperStatusView = _formUtil.GetForm<PaperFeedbackForm>();
            FormInit(_paperStatusView);
        }
        else
        {
            await _paperStatusView.Init();
            _paperStatusView.Activate();
        }
    }

    private void strip_user_settings_Click(object sender, EventArgs e)
    {
        if (_applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Reviewer)
        {
            var accountSetting = _formUtil.GetForm<AccountSettingReviewerForm>();
            accountSetting.Show();
        }
        else
        {
            var accountSetting = _formUtil.GetForm<AccountSettingForm>();
            accountSetting.Show();
        }
    }

    private async void strip_conf_confInfo_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        var loggedInUserInfo = _applicationStrategy.GetLoggedInUserInfo();
        if (loggedInUserInfo.User.RoleId == (int)RoleTypesEnum.Admin
            || loggedInUserInfo.User.RoleId == (int)RoleTypesEnum.Chair)
        {
            if (_conferenceInfoAdminView == null)
            {
                _conferenceInfoAdminView = _formUtil.GetForm<ConferenceInfoAdminForm>();
                FormInit(_conferenceInfoAdminView);
            }
            else
            {
                await _conferenceInfoAdminView.InitAsync((int)ConferenceViewTypesEnum.ConferenceMembers);
                _conferenceInfoAdminView.Activate();
            }
        }
        else
        {
            if (_conferenceInfoView == null)
            {
                _conferenceInfoView = _formUtil.GetForm<ConferenceInfoForm>();
                FormInit(_conferenceInfoView);
            }
            else
            {
                await _conferenceInfoView.InitAsync();
                _conferenceInfoView.Activate();
            }
        }

    }

    private async void strip_conference_userInfo_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_conferenceInfoAdminView == null)
        {
            _conferenceInfoAdminView = _formUtil.GetForm<ConferenceInfoAdminForm>();
            FormInit(_conferenceInfoAdminView);
        }
        else
        {
            await _conferenceInfoAdminView.InitAsync((int)ConferenceViewTypesEnum.UserInfo);
            _conferenceInfoAdminView.Activate();
        }
    }

    private async void strip_conference_paperInfo_Click(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        if (_conferenceInfoAdminView == null)
        {
            _conferenceInfoAdminView = _formUtil.GetForm<ConferenceInfoAdminForm>();
            FormInit(_conferenceInfoAdminView);
        }
        else
        {
            await _conferenceInfoAdminView.InitAsync((int)ConferenceViewTypesEnum.Papers);
            _conferenceInfoAdminView.Activate();
        }
    }
}
