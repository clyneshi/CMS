using CMSLibrary.Global;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Main : Form
    {
        ConferenceInfo_A cfia;
        ConferenceInfo cfi;
        SubmitPaper sub;
        AssignPaper ap;
        LaunchConference lf;
        ReviewPaper rvp;
        MakeDicision fb;
        RequestValidate rv;
        PaperStatus ps;
        

        public Main()
        {
            InitializeComponent();
            MenuInit(GlobalVariable.CurrentUser.roleId);
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
            txt_status.Text = GlobalVariable.CurrentUser.userName;
        }

        private void strip_user_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
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
                sub = new SubmitPaper();
                FormInit(sub);
            }
            else
            {
                sub.init();
                sub.Activate();
            }
        }

        private void FormInit(Form fm)
        {
            pictureBox1.Visible = false;
            fm.MdiParent = this;
            fm.Show();
            fm.ControlBox = false;
            fm.WindowState = FormWindowState.Minimized;
            fm.WindowState = FormWindowState.Maximized;
        }

        private void strip_conf_luanchConf_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (lf == null)
            {
                lf = new LaunchConference();
                FormInit(lf);
            }
            else
            {
                lf.init();
                lf.Activate();
            }
        }

        private void strip_conf_assignReviewer_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (ap == null)
            {
                ap = new AssignPaper();
                FormInit(ap);
            }
            else
            {
                ap.init();
                ap.Activate();
            }
        }

        private void strip_conf_reviewPaper_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (rvp == null)
            {
                rvp = new ReviewPaper();
                FormInit(rvp);
            }
            else
            {
                rvp.init();
                rvp.Activate();
            }
        }

        private void strip_conf_fnlDecision_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (fb == null)
            {
                fb = new MakeDicision();
                FormInit(fb);
            }
            else
            {
                fb.init();
                fb.Activate();
            }
        }

        private void strip_conf_rqValid_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (rv == null)
            {
                rv = new RequestValidate();
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
                ps = new PaperStatus();
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
            if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Reviewer)
            {
                AccountSetting_R acs = new AccountSetting_R();
                acs.Show();
            }
            else
            {
                AccountSetting acs = new AccountSetting();
                acs.Show();
            }
        }

        private void strip_conf_confInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Admin 
                || GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Chair)
            {
                if (cfia == null)
                {
                    cfia = new ConferenceInfo_A(1);
                    FormInit(cfia);
                }
                else
                {
                    cfia.Init(1);
                    cfia.Activate();
                }
            }
            else
            {
                if (cfi == null)
                {
                    cfi = new ConferenceInfo();
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
                cfia = new ConferenceInfo_A(2);
                FormInit(cfia);
            }
            else
            {
                cfia.Init(2);
                cfia.Activate();
            }
        }

        private void strip_conf_paperInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (cfia == null)
            {
                cfia = new ConferenceInfo_A(3);
                FormInit(cfia);
            }
            else
            {
                cfia.Init(3);
                cfia.Activate();
            }
        }
    }
}
