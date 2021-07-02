using CMS.BL.Enums;
using CMS.BL.Services.Interface;
using CMS.WinformUI.Utils;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Main : Form
    {
        ConferenceInfo_Admin cfia;
        ConferenceInfo cfi;
        SubmitPaper sub;
        AssignPaper ap;
        LaunchConference lf;
        ReviewPaper rvp;
        MakeDicision fb;
        RequestValidate rv;
        PaperStatus ps;

        private readonly IFormUtil _formUtil;
        private readonly IApplicationStrategy _applicationStrategy;

        public Main(IFormUtil formUtil, IApplicationStrategy applicationStrategy)
        {
            _formUtil = formUtil;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            MenuInit(_applicationStrategy.GetLoggedInUserInfo().User.RoleId);
        }

        public void MenuInit(int? role)
        {
            switch (role)
            {
                case 1:
                    {
                        ToolStripMenuItem strip_conf_userInfo = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_paperInfo = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_rqValid = new ToolStripMenuItem();
                        strip_conf_userInfo.Text = "User Information";
                        strip_conf_paperInfo.Text = "Paper Information";
                        strip_conf_rqValid.Text = "Validate Request";
                        this.strip_confMenu.DropDownItems.Add(strip_conf_userInfo);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_paperInfo);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_rqValid);
                        strip_conf_rqValid.Click += new System.EventHandler(this.strip_conf_rqValid_Click);
                        strip_conf_userInfo.Click += new System.EventHandler(this.strip_conf_userInfo_Click);
                        strip_conf_paperInfo.Click += new System.EventHandler(this.strip_conf_paperInfo_Click);
                        break;
                    }

                case 2:
                    {
                        ToolStripMenuItem strip_conf_luanchConf = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_assignReviewer = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_fnlDecision = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_rqValid = new ToolStripMenuItem();
                        strip_conf_luanchConf.Text = "Launch Conference";
                        strip_conf_assignReviewer.Text = "Assign Reviewer";
                        strip_conf_fnlDecision.Text = "Evaluate Paper";
                        strip_conf_rqValid.Text = "Validate Request";
                        this.strip_confMenu.DropDownItems.Add(strip_conf_luanchConf);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_assignReviewer);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_fnlDecision);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_rqValid);
                        strip_conf_luanchConf.Click += new System.EventHandler(this.strip_conf_luanchConf_Click);
                        strip_conf_assignReviewer.Click += new System.EventHandler(this.strip_conf_assignReviewer_Click);
                        strip_conf_fnlDecision.Click += new System.EventHandler(this.strip_conf_fnlDecision_Click);
                        strip_conf_rqValid.Click += new System.EventHandler(this.strip_conf_rqValid_Click);
                        break;
                    }

                case 3:
                    {
                        ToolStripMenuItem strip_conf_reviewPaper = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_rqValid = new ToolStripMenuItem();
                        strip_conf_reviewPaper.Text = "Review Paper";
                        this.strip_confMenu.DropDownItems.Add(strip_conf_reviewPaper);
                        strip_conf_reviewPaper.Click += new System.EventHandler(this.strip_conf_reviewPaper_Click);
                        break;
                    }

                default:
                    {
                        ToolStripMenuItem strip_conf_submitPaper = new ToolStripMenuItem();
                        ToolStripMenuItem strip_conf_paperStatus = new ToolStripMenuItem();
                        strip_conf_submitPaper.Text = "Submit Paper";
                        strip_conf_paperStatus.Text = "Paper Status";
                        this.strip_confMenu.DropDownItems.Add(strip_conf_submitPaper);
                        this.strip_confMenu.DropDownItems.Add(strip_conf_paperStatus);
                        strip_conf_submitPaper.Click += new System.EventHandler(this.strip_conf_submitPaper_Click);
                        strip_conf_paperStatus.Click += new System.EventHandler(this.strip_conf_paperStatus_Click);
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
            var login = _formUtil.GetForm<Login>();
            login.Show();
        }

        private void strip_system_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void strip_conf_submitPaper_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            if (sub == null)
            {
                sub = _formUtil.GetForm<SubmitPaper>();
                FormInit(sub);
            }
            else
            {
                sub.Init();
                sub.Activate();
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

        private void strip_conf_luanchConf_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (lf == null)
            {
                lf = _formUtil.GetForm<LaunchConference>();
                FormInit(lf);
            }
            else
            {
                lf.Init();
                lf.Activate();
            }
        }

        private void strip_conf_assignReviewer_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (ap == null)
            {
                ap = _formUtil.GetForm<AssignPaper>();
                FormInit(ap);
            }
            else
            {
                ap.Init();
                ap.Activate();
            }
        }

        private void strip_conf_reviewPaper_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (rvp == null)
            {
                rvp = _formUtil.GetForm<ReviewPaper>();
                FormInit(rvp);
            }
            else
            {
                rvp.Init();
                rvp.Activate();
            }
        }

        private void strip_conf_fnlDecision_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (fb == null)
            {
                fb = _formUtil.GetForm<MakeDicision>();
                FormInit(fb);
            }
            else
            {
                fb.Init();
                fb.Activate();
            }
        }

        private void strip_conf_rqValid_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (rv == null)
            {
                rv = _formUtil.GetForm<RequestValidate>();
                FormInit(rv);
            }
            else
            {
                rv.Init();
                rv.Activate();
            }
        }

        private void strip_conf_paperStatus_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (ps == null)
            {
                ps = _formUtil.GetForm<PaperStatus>();
                FormInit(ps);
            }
            else
            {
                ps.Init();
                ps.Activate();
            }
        }

        private void strip_user_settings_Click(object sender, EventArgs e)
        {
            if (_applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Reviewer)
            {
                var acs = _formUtil.GetForm<AccountSetting_R>();
                acs.Show();
            }
            else
            {
                var acs = _formUtil.GetForm<AccountSetting>();
                acs.Show();
            }
        }

        private void strip_conf_confInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (_applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Admin
                || _applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Chair)
            {
                if (cfia == null)
                {
                    cfia = _formUtil.GetForm<ConferenceInfo_Admin>();
                    FormInit(cfia);
                }
                else
                {
                    cfia.Init((int)ConferenceViewTypesEnum.ConferenceMembers);
                    cfia.Activate();
                }
            }
            else
            {
                if (cfi == null)
                {
                    cfi = _formUtil.GetForm<ConferenceInfo>();
                    FormInit(cfi);
                }
                else
                {
                    cfi.Init();
                    cfi.Activate();
                }
            }

        }

        private void strip_conf_userInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (cfia == null)
            {
                cfia = _formUtil.GetForm<ConferenceInfo_Admin>();
                FormInit(cfia);
            }
            else
            {
                cfia.Init((int)ConferenceViewTypesEnum.UserInfo);
                cfia.Activate();
            }
        }

        private void strip_conf_paperInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (cfia == null)
            {
                cfia = _formUtil.GetForm<ConferenceInfo_Admin>();
                FormInit(cfia);
            }
            else
            {
                cfia.Init((int)ConferenceViewTypesEnum.Papers);
                cfia.Activate();
            }
        }
    }
}
