using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class Main : Form
    {
        ConferenceInfo_A cfia;
        ConferenceInfo cfi;
        SubmitPaper sub;
        test tst;
        AssignPaper ap;
        LaunchConference lf;
        ReviewPaper rvp;
        MakeDicision fb;
        RequestValidate rv;
        PaperStatus ps;

        public Main()
        {
            InitializeComponent();
            menuInit((int)Module.CMSsystem.user_role);
        }

        public void menuInit(int role)
        {
            if (role == 1)
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
            }
            else if (role == 2)
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
            }
            else if (role ==3)
            {
                ToolStripMenuItem strip_conf_reviewPaper = new ToolStripMenuItem();
                ToolStripMenuItem strip_conf_rqValid = new ToolStripMenuItem();
                strip_conf_reviewPaper.Text = "Review Paper";
                this.strip_confMenu.DropDownItems.Add(strip_conf_reviewPaper);
                strip_conf_reviewPaper.Click += new System.EventHandler(this.strip_conf_reviewPaper_Click);
            }
            else
            {
                ToolStripMenuItem strip_conf_submitPaper = new ToolStripMenuItem();
                ToolStripMenuItem strip_conf_paperStatus = new ToolStripMenuItem();
                strip_conf_submitPaper.Text = "Submit Paper";
                strip_conf_paperStatus.Text = "Paper Status";
                this.strip_confMenu.DropDownItems.Add(strip_conf_submitPaper);
                this.strip_confMenu.DropDownItems.Add(strip_conf_paperStatus);
                strip_conf_submitPaper.Click += new System.EventHandler(this.strip_conf_submitPaper_Click);
                strip_conf_paperStatus.Click += new System.EventHandler(this.strip_conf_paperStatus_Click);
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            txt_status.Text = Module.CMSsystem.user_name;
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
                formInit(sub);
            }
            else
            {
                sub.init();
                sub.Activate();
            }
        }

        private void formInit(Form fm)
        {
            pictureBox1.Visible = false;
            fm.MdiParent = this;
            fm.Show();
            fm.ControlBox = false;
            fm.WindowState = FormWindowState.Minimized;
            fm.WindowState = FormWindowState.Maximized;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (tst == null)
            {
                tst = new test();
                formInit(tst);
            }
            else
            {
                tst.init();
                tst.Activate();
            }
        }

        private void strip_conf_luanchConf_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (lf == null)
            {
                lf = new LaunchConference();
                formInit(lf);
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
                formInit(ap);
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
                formInit(rvp);
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
                formInit(fb);
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
                formInit(rv);
            }
            else
            {
                rv.init();
                rv.Activate();
            }
        }

        private void strip_conf_paperStatus_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (ps == null)
            {
                ps = new PaperStatus();
                formInit(ps);
            }
            else
            {
                ps.init();
                ps.Activate();
            }
        }



        private void strip_user_settings_Click(object sender, EventArgs e)
        {
            if (CMS.Module.CMSsystem.user_role == 3)
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
            if (CMS.Module.CMSsystem.user_role == 1 || CMS.Module.CMSsystem.user_role == 2)
            {
                if (cfia == null)
                {
                    cfia = new ConferenceInfo_A(1);
                    formInit(cfia);
                }
                else
                {
                    cfia.init(1);
                    cfia.Activate();
                }
            }
            else
            {
                if (cfi == null)
                {
                    cfi = new ConferenceInfo();
                    formInit(cfi);
                }
                else
                {
                    cfi.init();
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
                formInit(cfia);
            }
            else
            {
                cfia.init(2);
                cfia.Activate();
            }
        }

        private void strip_conf_paperInfo_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            if (cfia == null)
            {
                cfia = new ConferenceInfo_A(3);
                formInit(cfia);
            }
            else
            {
                cfia.init(3);
                cfia.Activate();
            }
        }



        //private void formInit(Form f, int type)
        //{
        //    if (f == null)
        //    {
        //        switch (type)
        //        {
        //            case 1: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 2: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 3: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 4: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 6: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 7: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 8: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 11: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 16: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 17: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 21: cfi = new ConferenceInfo(); formInit(cfi); break;
        //        }

        //    }
        //    else
        //    {
        //        switch (type)
        //        {
        //            case 1: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 2: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 3: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 4: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 6: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 7: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 8: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 11: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 16: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 17: cfi = new ConferenceInfo(); formInit(cfi); break;
        //            case 21: cfi = new ConferenceInfo(); formInit(cfi); break;
        //        }
        //    }
        //}


    }
}
