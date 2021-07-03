using CMS.BL.Services.Interface;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class PaperFeedbackForm : Form
    {
        private readonly IPaperService _paperService;
        private readonly IApplicationStrategy _applicationStrategy;

        public PaperFeedbackForm(IPaperService paperService, IApplicationStrategy applicationStrategy)
        {
            _paperService = paperService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            DisplayPapers();
        }

        private void DisplayPapers()
        {
            var papers = _paperService
                .GetPapersByAuthor(_applicationStrategy.GetLoggedInUserInfo().User.Id)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Author,
                    p.SubmissionDate,
                    p.Status
                }).ToList();

            dataGridView_paper.DataSource = papers;
            
            if (papers.Any())
            {
                DisplayFeedback(papers.First().Id);
            }
            else
            {
                richTextBox_feedback.Text = string.Empty;
            }
        }

        private void DisplayFeedback(int paperId)
        {
            var feedbacks = _paperService.GetFeedbacksByPaper(paperId);
            richTextBox_feedback.Text = feedbacks.SingleOrDefault()?.Feedback1;
        }

        private void dataGridView_paper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                DisplayFeedback((int)dataGridView_paper.Rows[e.RowIndex].Cells["paperId"].Value);
        }
    }
}
