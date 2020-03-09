using CMS.DAL.Models;
using CMS.Library.Enums;
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
        int selectedPaperId = 0;
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
            DisplayConferenes();
            if (dataGridView1.Rows.Count > 0)
            {
                DisplayPapers((int)dataGridView1.Rows[0].Cells["confId"].Value);
                if (dataGridView2.Rows.Count > 0)
                    DisplayReviews((int)dataGridView2.Rows[0].Cells["paperId"].Value);
                else
                    dataGridView3.DataSource = null;
            }
            else
            {
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
            }
        }

        private void DisplayConferenes()
        {
            dataGridView1.DataSource = _conferenceService
                .GetConferencesByChair(GlobalVariable.CurrentUser.userId)
                .Select(x => new
                {
                    x.confId,
                    x.confTitle,
                    x.confLocation,
                    x.paperDeadline,
                    x.confBeginDate,
                    x.confEndDate
                })
                .ToList();
        }

        private void DisplayPapers(int conf)
        {
            dataGridView2.DataSource = _paperService
                .GetPapersByConference(conf)
                .Select(x => new
                {
                    x.paperId,
                    x.paperTitle,
                    x.paperAuthor,
                    x.paperSubDate,
                    x.paperStatus
                })
                .ToList();
        }

        private void DisplayReviews(int paper)
        {
            dataGridView3.DataSource = _paperService
                .GetPaperReviewsByPaper(paper)
                .Select(x => new
                {
                    x.paperId,
                    x.Paper.paperTitle,
                    x.paperRating,
                })
                .ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DisplayPapers((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);
                if (dataGridView2.RowCount != 0 && dataGridView2.CurrentRow.Index >= 0)
                    DisplayReviews((int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["paperId"].Value);
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
                selectedPaperId = (int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value;
                DisplayReviews((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
                DisplayDecisions((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
            }
            else
                dataGridView3.DataSource = null;
        }

        private void DisplayDecisions(int paper)
        {
            var feedbacks = _paperService.GetFeedbacksByPaper(paper);

            if (feedbacks.Any())
            {
                rtextbox_feedback.Text = feedbacks.FirstOrDefault().feedback1;
                foreach (Control c in groupBox1.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb != null && rb.Text.Equals(feedbacks.Single().fnlDecision.Trim()))
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
            var email = _paperService.GetPaperById(selectedPaperId).User.userEmail;
            var decision = DecisionCheck();

            await GlobalHelper.SendEmail(email.ToString(), $"Your paper has been {decision.ToLower()}ed");
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            string error = FeedbackValidation();
            if (!error.Equals(""))
            {
                MessageBox.Show(error);
                return;
            }

            var decision = DecisionCheck() == "Accept" ? PaperStatusEnum.Accepted : PaperStatusEnum.Declined;

            Feedback feedback = new Feedback
            {
                paperId = selectedPaperId,
                userId = GlobalVariable.CurrentUser.userId,
                fnlDecision = decision.ToString(),
                feedback1 = rtextbox_feedback.Text
            };

            await _paperService.AddFeedback(feedback);

            // TODO: turn on sending email
            //await SendEmail();

            MessageBox.Show("Save succeeded");
            Init();
        }
    }
}
