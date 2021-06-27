using CMS.BL.Services.Interface;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class PaperStatus : Form
    {
        readonly IPaperService _paperService;
        private readonly IApplicationStrategy _applicationStrategy;

        public PaperStatus(IPaperService paperService, IApplicationStrategy applicationStrategy)
        {
            _paperService = paperService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            PaperDisplay();
        }

        private void PaperDisplay()
        {
            var papers = _paperService.GetPapersByAuthor(_applicationStrategy.GetLoggedInUserInfo().User.Id);

            if (papers.Count() > 0)
            {
                dataGridView1.DataSource = papers.Select(
                    p => new
                    {
                        paperId = p.Id,
                        col2 = p.Title,
                        col3 = p.Author,
                        col4 = p.SubmissionDate,
                        col5 = p.Status
                    }).ToList();

                FeedbackDisplay((int)dataGridView1.Rows[0].Cells["paperId"].Value);
            }
        }

        private void FeedbackDisplay(int paperId)
        {
            var feedbacks = _paperService.GetFeedbacksByPaper(paperId);
            if (feedbacks.Count() != 0)
                richTextBox_fb.Text = feedbacks.Single().Feedback1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > 0)
                FeedbackDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["paperId"].Value);
        }
    }
}
