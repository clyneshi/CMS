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
using System.Net;
using System.Net.Mail;

namespace CMS
{
    public partial class MakeDicision : Form
    {
        Module.CMSsystem cmsm = new Module.CMSsystem();
        Model.CMSDBEntities cms = new CMSDBEntities();
        //int paperid = 0;
        

        public MakeDicision()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            cmsm.clearControls(this.Controls);
            displayConf();
            if (dataGridView1.Rows.Count > 0)
            {
                displayPaper((int)dataGridView1.Rows[0].Cells["confId"].Value);
                if (dataGridView2.Rows.Count > 0)
                    displayReview((int)dataGridView2.Rows[0].Cells["paperId"].Value);
                else
                    dataGridView3.DataSource = null;
            }
            else
            {
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
            }
        }

        private void displayConf()
        {
            var conf = from c in cms.Conferences
                       where c.chairId == Module.CMSsystem.user_id
                       select new
                       {
                           c.confId,
                           c.confTitle,
                           c.paperDeadline,
                           c.confBeginDate,
                           c.confEndDate
                       };

            dataGridView1.DataSource = conf.ToList();
        }

        private void displayPaper(int conf)
        {
            var paper = from p in cms.Papers
                        where p.confId == conf
                        select new
                        {
                            p.paperId,
                            p.paperTitle,
                            p.paperAuthor,
                            p.paperLength,
                            p.paperSubDate
                        };

            dataGridView2.DataSource = paper.ToList();
        }

        private void displayReview(int paper)
        {
            var rvw = from pr in cms.PaperReviews
                      join u in cms.Users on pr.userId equals u.userId
                      where pr.paperId == paper
                      select new
                      {
                          pr.Id,
                          pr.paperId,
                          u.userName,
                          pr.paperRating
                      };

            dataGridView3.DataSource = rvw.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                displayPaper((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);
                if (dataGridView2.RowCount != 0 && dataGridView2.CurrentRow.Index >= 0)
                    displayReview((int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value);
                else
                    dataGridView3.DataSource = null;
            }
            else
            {
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //paperid = (int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value;
                displayReview((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
                displayFnl((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
            }
            else
                dataGridView3.DataSource = null;
        }

        private void displayFnl(int paper)
        {
            if (cms.Feedbacks.Where(f => f.paperId == paper).Count() == 0)
            {
                var fb = from f in cms.Feedbacks
                         where f.paperId == paper
                         select f;
                if (fb.Count() != 0)
                {
                    rtextbox_feedback.Text = fb.SingleOrDefault().feedback1;
                    foreach (Control c in groupBox1.Controls)
                    {
                        RadioButton rb = c as RadioButton;
                        if (rb != null && rb.Text.Equals(fb.Single().fnlDecision.Trim()))
                            rb.Checked = true;
                    }
                }
            }
        }

        private string decisionCheck()
        {
            string decision = "";
            foreach (Control c in groupBox1.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb != null && rb.Checked)
                    decision = rb.Text;
            }
            return decision;
        }

        private bool addFeedback()
        {
            if (dataGridView2.RowCount >= 0 && dataGridView2.CurrentRow.Index >= 0)
            {
                Feedback fb = new Feedback();
                fb.paperId = (int )dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
                fb.userId = Module.CMSsystem.user_id;
                fb.fnlDecision = decisionCheck();
                fb.feedback1 = rtextbox_feedback.Text;
                cms.Feedbacks.Add(fb);
                cms.SaveChanges();
                return true;
            }
            return false;
        }

        private void changeStatus()
        {
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            Paper paper = cms.Papers.Where(p => p.paperId == paperid).Single();
            paper.paperStatus = decisionCheck();
            cms.SaveChanges();
        }

        private string fbValidation()
        {
            string error = "";
            if (dataGridView2.RowCount == 0 || dataGridView2.CurrentRow.Index < 0)
                return error = "Paper has not been selected";
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            if (cms.Feedbacks.Where(f => f.paperId == paperid).Count() > 0)
                return error = "Feedback already exists, cannot be changed";
            if (rtextbox_feedback.Text.Trim().Equals(""))
                return error = "Feedback canot be empty";
            if (decisionCheck().Equals(""))
                return error = "Decision cannot be empty";
            return error;
        }

        private void SendEmail()
        {
            var email = (from u in cms.Users
                         join p in cms.Papers on u.userId equals p.auId
                         where p.paperId == 1
                         select u.userEmail).ToList();

            if (decisionCheck() == "Accept")
                cmsm.sendEmail(email.ToString(), "Your paper has been accepted");
            if (decisionCheck() == "Decline")
                cmsm.sendEmail(email.ToString(), "Your paper has been declined");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string error = fbValidation();
            if (error.Equals("") && addFeedback())
            {
                changeStatus();
                //SendEmail();
                MessageBox.Show("Save succeeded");
            }
            else
                MessageBox.Show(error);
            init();
        }
    }
}
