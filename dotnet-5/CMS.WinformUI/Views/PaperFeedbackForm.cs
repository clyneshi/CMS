using CMS.BL.Services.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS;

public partial class PaperFeedbackForm : Form
{
    private readonly IPaperService _paperService;
    private readonly IApplicationStrategy _applicationStrategy;

    public PaperFeedbackForm(IPaperService paperService, IApplicationStrategy applicationStrategy)
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
        await DisplayPapers();
    }

    private async Task DisplayPapers()
    {
        var papers = (await _paperService
            .GetPapersForAuthorAsync(_applicationStrategy.GetLoggedInUserInfo().User.Id))
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
            await DisplayFeedback(papers.First().Id);
        }
        else
        {
            richTextBox_feedback.Text = string.Empty;
        }
    }

    private async Task DisplayFeedback(int paperId)
    {
        var feedbacks = await _paperService.GetFeedbacksForPaperAsync(paperId);
        richTextBox_feedback.Text = feedbacks.SingleOrDefault()?.Feedback1;
    }

    private async void dataGridView_paper_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            await DisplayFeedback((int)dataGridView_paper.Rows[e.RowIndex].Cells["paperId"].Value);
    }
}
