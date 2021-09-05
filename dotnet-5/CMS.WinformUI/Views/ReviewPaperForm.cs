using CMS.BL.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class ReviewPaperForm : Form
    {
        private readonly IPaperService _paperService;
        private readonly IApplicationStrategy _applicationStrategy;

        public ReviewPaperForm(IPaperService paperService, IApplicationStrategy applicationStrategy)
        {
            _paperService = paperService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Init();
        }

        public async Task Init()
        {
            var paperReviews = await _paperService.GetPapersForReviewAsync(_applicationStrategy.GetLoggedInUserInfo().User.Id, _applicationStrategy.GetLoggedInUserInfo().ConferenceId.Value);
            dataGridView_paperReview.DataSource = paperReviews;
            //dataGridView1.Columns[5].Visible = false;
        }

        private async void btn_rate_Click(object sender, EventArgs e)
        {
            if (RatingBoxForm.Show() == DialogResult.Yes)
            {
                // TODO: validation
                var index = dataGridView_paperReview.CurrentRow.Index;
                if (RatingBoxForm.Rating != 0 && index >= 0)
                    await _paperService.UpdatePaperRatingAsync(RatingBoxForm.Rating, (int)dataGridView_paperReview.Rows[index].Cells["paperId"].Value);
            }
            await Init();
        }

        private async void btn_download_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            var index = dataGridView_paperReview.CurrentRow.Index;
            if (index >= 0)
            {
                int paperId = (int)dataGridView_paperReview.Rows[index].Cells["paperId"].Value;
                var paper = await _paperService.GetPaperByIdAsync(paperId);
                saveDialog.FileName = paper.FileName;
                if (paper.Format.ToUpper().Equals(".PDF"))
                {
                    saveDialog.Filter = "Data Files PDF|*.pdf";
                    saveDialog.DefaultExt = "pdf";
                    saveDialog.AddExtension = true;
                }
                if (paper.Format.ToUpper().Equals(".DOC"))
                {
                    saveDialog.Filter = "Data Files WORD|*.doc";
                    saveDialog.DefaultExt = "doc";
                    saveDialog.AddExtension = true;
                }
                if (paper.Format.ToUpper().Equals(".TXT"))
                {
                    saveDialog.Filter = "Data Files Text Files|*.txt";
                    saveDialog.DefaultExt = "txt";
                    saveDialog.AddExtension = true;
                }

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var binaryWriter = new BinaryWriter(File.Create(saveDialog.FileName));
                    binaryWriter.Write(paper.Content);
                    binaryWriter.Dispose();
                }
            }
        }
    }
}
