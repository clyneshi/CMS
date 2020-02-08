using CMS.Library.Service;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class PaperStatus : Form
    {
        readonly IPaperService _paperService;

        public PaperStatus(IPaperService paperService)
        {
            _paperService = paperService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            PaperDisplay();
        }

        private void PaperDisplay()
        {
            var papers = _paperService.GetPapersByAuthor();

            if (papers.Count() > 0)
            {
                dataGridView1.DataSource = papers.Select(
                    p => new
                    {
                        paperId = p.paperId,
                        col2 = p.paperTitle,
                        col3 = p.paperAuthor,
                        col4 = p.paperSubDate,
                        col5 = p.paperStatus
                    }).ToList();

                FeedbackDisplay((int)dataGridView1.Rows[0].Cells["paperId"].Value);
            }
        }

        private void FeedbackDisplay(int paperId)
        {
            var feedbacks = _paperService.GetFeedbacksByPaper(paperId);
            if (feedbacks.Count() != 0)
                richTextBox_fb.Text = feedbacks.Single().feedback1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > 0)
                FeedbackDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["paperId"].Value);
        }
    }
}
