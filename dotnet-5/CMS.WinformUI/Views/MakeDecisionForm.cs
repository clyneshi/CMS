using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Global;
using CMS.BL.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.WinformUI.Utils;

namespace CMS
{
    public partial class MakeDecisionForm : Form
    {
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;
        
        private int _selectedId = 0;

        public MakeDecisionForm(
            IPaperService paperService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _paperService = paperService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitAsync();
        }

        public async Task InitAsync()
        {
            await BindGridViewData();
        }

        private async Task BindGridViewData()
        {
            var conferences = (await _conferenceService
                .GetConferencesByChairAsync(_applicationStrategy.GetLoggedInUserInfo().User.Id))
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.Location,
                    x.PaperDeadline,
                    x.BeginDate,
                    x.EndDate
                })
                .ToList();

            dataGridView_conference.DataSource = conferences;

            if (conferences.Any())
            {
                await DisplayPapers(conferences.First().Id);
            }
            else 
            {
                dataGridView_paper.DataSource = null;
                dataGridView_reviewer.DataSource = null;
            }
        }

        private async Task DisplayPapers(int conf)
        {
            var papers = (await _paperService
                .GetPapersForConferenceAsync(conf))
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.Author,
                    x.SubmissionDate,
                    x.Status
                })
                .ToList();

            dataGridView_paper.DataSource = papers;

            if (papers.Any())
                await DisplayReviews(papers.First().Id);
            else
                dataGridView_reviewer.DataSource = null;
        }

        private async Task DisplayReviews(int paper)
        {
            dataGridView_reviewer.DataSource = (await _paperService
                .GetPaperReviewsForPaperAsync(paper))
                .Select(x => new
                {
                    x.Id,
                    x.Paper.Title,
                    x.PaperRating,
                })
                .ToList();
        }

        private async void dataGridView_conference_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await DisplayPapers((int)dataGridView_conference.Rows[e.RowIndex].Cells["Id"].Value);
                if (dataGridView_paper.RowCount != 0 && dataGridView_paper.CurrentRow.Index >= 0)
                    await DisplayReviews((int)dataGridView_paper.Rows[dataGridView_paper.CurrentRow.Index].Cells["Id"].Value);
                else
                    dataGridView_reviewer.DataSource = null;
            }
            else
            {
                dataGridView_paper.DataSource = null;
                dataGridView_reviewer.DataSource = null;
            }
        }

        private async void dataGridView_paper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedId = (int)dataGridView_paper.Rows[e.RowIndex].Cells["Id"].Value;
                await DisplayReviews((int)dataGridView_paper.Rows[e.RowIndex].Cells["Id"].Value);
                await DisplayDecisions((int)dataGridView_paper.Rows[e.RowIndex].Cells["Id"].Value);
            }
            else
                dataGridView_reviewer.DataSource = null;
        }

        private async Task DisplayDecisions(int paper)
        {
            var feedbacks = await _paperService.GetFeedbacksForPaperAsync(paper);

            if (feedbacks.Any())
            {
                rtextbox_feedback.Text = feedbacks.FirstOrDefault().Feedback1;
                foreach (Control c in groupBox1.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb != null && rb.Text.Equals(feedbacks.Single().FinalDecision.Trim()))
                        rb.Checked = true;
                }
            }
        }

        private PaperStatusEnum? GetDecision()
        {
            foreach (var control in groupBox1.Controls)
            {
                var radioButton = control as RadioButton;
                if (radioButton != null 
                    && radioButton.Checked 
                    && Enum.TryParse<PaperStatusEnum>(radioButton.Text, out var decision))
                    return decision;
            }
            return null;
        }

        private async Task<string> ValidateFeedback()
        {
            if (dataGridView_paper.RowCount == 0 || dataGridView_paper.CurrentRow.Index < 0)
                return "Paper has not been selected";
            int Id = (int)dataGridView_paper.Rows[dataGridView_paper.CurrentRow.Index].Cells["Id"].Value;
            if ((await _paperService.GetFeedbacksForPaperAsync(Id)).Any())
                return "Feedback already exists, cannot be changed";
            if (rtextbox_feedback.Text.Trim().Equals(""))
                return "Feedback canot be empty";
            if (GetDecision().Equals(""))
                return "Decision cannot be empty";
            return "";
        }

        private async Task SendEmail()
        {
            var email = (await _paperService.GetPaperByIdAsync(_selectedId)).AuthorNavigation.Email;
            var decision = GetDecision();

            await GlobalHelper.SendEmail(email.ToString(), $"Your paper has been {decision.ToString().ToLower()}ed");
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            string error = await ValidateFeedback();
            if (!error.Equals(""))
            {
                MessageBox.Show(error);
                return;
            }

            var feedback = new Feedback
            {
                Id = _selectedId,
                UserId = _applicationStrategy.GetLoggedInUserInfo().User.Id,
                FinalDecision = GetDecision().ToString(),
                Feedback1 = rtextbox_feedback.Text
            };

            await _paperService.AddFeedbackAsync(feedback);

            // TODO: turn on sending email
            //await SendEmail();

            MessageBox.Show("Save succeeded");
            Controls.ClearData();
            await InitAsync();
        }
    }
}
