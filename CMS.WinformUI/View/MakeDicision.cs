using CMS.Library.Global;
using CMS.Library.Model;
using CMS.Library.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class MakeDicision : Form
    {
        int paperId = 0;
        IPaperService _paperService;

        public MakeDicision(IPaperService paperService)
        {
            _paperService = paperService;
            InitializeComponent();
            init();
        }

        public void init()
        {
            DataProcessor.ClearControls(this.Controls);
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
            var conf = DataProcessor.GetConferenceByChair(GlobalVariable.CurrentUser.userId);

            dataGridView1.DataSource = conf;
        }

        private void displayPaper(int conf)
        {
            var paper = _paperService.GetPapersByConference(conf);

            dataGridView2.DataSource = paper;
        }

        private void displayReview(int paper)
        {
            var rvw = _paperService.GetPaperReviewByPaper(paper);

            dataGridView3.DataSource = rvw;
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
                paperId = (int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value;
                displayReview((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
                displayFnl((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
            }
            else
                dataGridView3.DataSource = null;
        }

        private void displayFnl(int paper)
        {
            var fb = _paperService.GetFeedbacksByPaper(paper);

            if (fb.Any())
            {
                rtextbox_feedback.Text = fb.FirstOrDefault().feedback1;
                foreach (Control c in groupBox1.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb != null && rb.Text.Equals(fb.Single().fnlDecision.Trim()))
                        rb.Checked = true;
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
                Feedback fb = new Feedback
                {
                    paperId = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value,
                    userId = GlobalVariable.CurrentUser.userId,
                    fnlDecision = decisionCheck(),
                    feedback1 = rtextbox_feedback.Text
                };

                DataProcessor.AddFeedback(fb);

                return true;
            }
            return false;
        }

        private void changeStatus()
        {
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            _paperService.UpdatePaperStatus(paperid, decisionCheck());
        }

        private string fbValidation()
        {
            if (dataGridView2.RowCount == 0 || dataGridView2.CurrentRow.Index < 0)
                return "Paper has not been selected";
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            if (_paperService.GetFeedbacksByPaper(paperid).Any())
                return "Feedback already exists, cannot be changed";
            if (rtextbox_feedback.Text.Trim().Equals(""))
                return "Feedback canot be empty";
            if (decisionCheck().Equals(""))
                return "Decision cannot be empty";
            return "";
        }

        private void SendEmail()
        {
            var email = _paperService.GetPaperById(paperId).User.userEmail;

            if (decisionCheck() == "Accept")
                DataProcessor.SendEmail(email.ToString(), "Your paper has been accepted");
            if (decisionCheck() == "Decline")
                DataProcessor.SendEmail(email.ToString(), "Your paper has been declined");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string error = fbValidation();
            if (error.Equals("") && addFeedback())
            {
                changeStatus();
                SendEmail();
                MessageBox.Show("Save succeeded");
            }
            else
                MessageBox.Show(error);
            init();
        }
    }
}
