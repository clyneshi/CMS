using CMS.BL.Services.Interface;
using System;
using System.IO;
using System.Windows.Forms;

namespace CMS
{
    public partial class ReviewPaper : Form
    {
        private readonly IPaperService _paperService;
        private readonly IApplicationStrategy _applicationStrategy;

        public ReviewPaper(IPaperService paperService, IApplicationStrategy applicationStrategy)
        {
            _paperService = paperService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            var paperReviews = _paperService.GetPapersForReview(_applicationStrategy.GetLoggedInUserInfo().User.Id, _applicationStrategy.GetLoggedInUserInfo().ConferenceId.Value);
            dataGridView_paperReview.DataSource = paperReviews;
            //dataGridView1.Columns[5].Visible = false;
        }

        private void btn_rate_Click(object sender, EventArgs e)
        {
            if (RatingBox.Show() == DialogResult.Yes)
            {
                // TODO: validation
                var index = dataGridView_paperReview.CurrentRow.Index;
                if (RatingBox.Rating != 0 && index >= 0)
                    _paperService.UpdatePaperRating(RatingBox.Rating, (int)dataGridView_paperReview.Rows[index].Cells["paperId"].Value);
            }
            Init();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            var index = dataGridView_paperReview.CurrentRow.Index;
            if (index >= 0)
            {
                int paperId = (int)dataGridView_paperReview.Rows[index].Cells["paperId"].Value;
                var paper = _paperService.GetPaperById(paperId);
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
