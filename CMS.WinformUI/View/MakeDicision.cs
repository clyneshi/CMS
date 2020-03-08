using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class MakeDicision : Form
    {
        int paperId = 0;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;

        public MakeDicision(IPaperService paperService, IConferenceService conferenceService)
        {
            _paperService = paperService;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            GlobalHelper.ClearControls(this.Controls);
            DisplayConf();
            if (dataGridView1.Rows.Count > 0)
            {
                DisplayPaper((int)dataGridView1.Rows[0].Cells["confId"].Value);
                if (dataGridView2.Rows.Count > 0)
                    DisplayReview((int)dataGridView2.Rows[0].Cells["paperId"].Value);
                else
                    dataGridView3.DataSource = null;
            }
            else
            {
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
            }
        }

        private void DisplayConf()
        {
            var conf = _conferenceService.GetConferenceByChair(GlobalVariable.CurrentUser.userId);

            dataGridView1.DataSource = conf;
        }

        private void DisplayPaper(int conf)
        {
            var paper = _paperService.GetPapersByConference(conf);

            dataGridView2.DataSource = paper;
        }

        private void DisplayReview(int paper)
        {
            var rvw = _paperService.GetPaperReviewByPaper(paper);

            dataGridView3.DataSource = rvw;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DisplayPaper((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);
                if (dataGridView2.RowCount != 0 && dataGridView2.CurrentRow.Index >= 0)
                    DisplayReview((int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value);
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
                DisplayReview((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
                DisplayDecisions((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
            }
            else
                dataGridView3.DataSource = null;
        }

        private void DisplayDecisions(int paper)
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

        private string DecisionCheck()
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
                    fnlDecision = DecisionCheck(),
                    feedback1 = rtextbox_feedback.Text
                };

                _paperService.AddFeedback(fb);

                return true;
            }
            return false;
        }

        private void ChangeStatus()
        {
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            _paperService.UpdatePaperStatus(paperid, DecisionCheck());
        }

        private string FeedbackValidation()
        {
            if (dataGridView2.RowCount == 0 || dataGridView2.CurrentRow.Index < 0)
                return "Paper has not been selected";
            int paperid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value;
            if (_paperService.GetFeedbacksByPaper(paperid).Any())
                return "Feedback already exists, cannot be changed";
            if (rtextbox_feedback.Text.Trim().Equals(""))
                return "Feedback canot be empty";
            if (DecisionCheck().Equals(""))
                return "Decision cannot be empty";
            return "";
        }

        private async Task SendEmail()
        {
            var email = _paperService.GetPaperById(paperId).User.userEmail;
            var decision = DecisionCheck();

            await GlobalHelper.SendEmail(email.ToString(), $"Your paper has been {decision.ToLower()}ed");
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            string error = FeedbackValidation();
            if (error.Equals("") && addFeedback())
            {
                ChangeStatus();
                await SendEmail();
                MessageBox.Show("Save succeeded");
            }
            else
                MessageBox.Show(error);
            Init();
        }
    }
}
