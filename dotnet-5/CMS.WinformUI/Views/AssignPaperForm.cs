using CMS.DAL.Models;
using CMS.BL.Services.Interface;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CMS
{
    public partial class AssignPaperForm : Form
    {
        private readonly IUserService _userService;
        private readonly IKeywordService _keywordService;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;

        readonly BindingList<User> _reviewersToAssign = new BindingList<User>();
        readonly BindingList<PaperReview> _paperReviewsToDelete = new BindingList<PaperReview>();
        
        private int _selectedReviewerId;
        private string _selectedUserName;
        private int _selectedPaperId;
        private bool _removeFromDb;

        public AssignPaperForm(IUserService userService,
            IKeywordService keywordService,
            IPaperService paperService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _userService = userService;
            _keywordService = keywordService;
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
            _selectedReviewerId = 0;
            _reviewersToAssign.Clear();
            listBox_reviewer.DataSource = _reviewersToAssign;
            listBox_reviewer.DisplayMember = "Name";

            await DisplayConferences();
            if (dataGridView_conference.Rows.Count > 0)
            {
                var conferenceId = (int)dataGridView_conference.Rows[0].Cells["Id"].Value;
                await DisplayPapersWithAssignedReviewers(conferenceId);
                await DisplayReviewersWithExpertises(conferenceId);
            }
        }

        private async Task DisplayConferences()
        {
            var conference = (await _conferenceService
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

            dataGridView_conference.DataSource = conference;
        }

        private async Task DisplayPapersWithAssignedReviewers(int conferenceId)
        {
            var papers = (await _paperService
                .GetPapersForConferenceAsync(conferenceId))
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
            {
                _selectedPaperId = papers.First().Id;
                await DisplayAssignedReviewers(papers.First().Id);
            }
            else
            {
                _selectedPaperId = 0;
                dataGridView_assignedReviewer.DataSource = null;
            }
        }

        private async Task DisplayReviewersWithExpertises(int conferenceId)
        {
            var reviewers = (await _userService
                .GetReviewersAsync(conferenceId))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Email
                })
                .ToList();

            dataGridView_reviewer.DataSource = reviewers;

            if (reviewers.Any())
            {
                _selectedReviewerId = reviewers.First().Id;
                await DisplayReviewerExpertise(reviewers.First().Id);
            }
            else
            {
                _selectedReviewerId = 0;
                dataGridView_reviewerExpertise.DataSource = null;
            }
        }

        private async Task DisplayReviewerExpertise(int reviewerId)
        {
            var keywords = (await _keywordService.GetExpertiseByUserAsync(reviewerId))
                .Select(x => x.Keyword).ToList();

            dataGridView_reviewerExpertise.DataSource = keywords;
            dataGridView_reviewerExpertise.Columns["ConferenceTopics"].Visible = false;
            dataGridView_reviewerExpertise.Columns["Expertises"].Visible = false;
            dataGridView_reviewerExpertise.Columns["PaperTopics"].Visible = false;
        }

        private async Task DisplayAssignedReviewers(int paperId)
        {
            var assignedReviewers = (await _userService
                .GetAssignedReviewersByPaperAsync(paperId))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Email
                })
                .ToList();

            dataGridView_assignedReviewer.DataSource = assignedReviewers;

            _removeFromDb = false;
            _paperReviewsToDelete.Clear();
        }

        private async void dataGridView_conference_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // change the paper list according to different conference
            if (e.RowIndex >= 0)
            {
                int conferenceId = (int)dataGridView_conference.Rows[e.RowIndex].Cells["Id"].Value;

                await DisplayPapersWithAssignedReviewers(conferenceId);

                await DisplayReviewersWithExpertises(conferenceId);

                _reviewersToAssign.Clear();
            }
        }

        private async void dataGridView_reviewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // change the expertise list according to different reviewer
            if (e.RowIndex >= 0)
            {
                _selectedReviewerId = (int)dataGridView_reviewer.Rows[e.RowIndex].Cells["Id"].Value;
                _selectedUserName = (string)dataGridView_reviewer.Rows[e.RowIndex].Cells["Name"].Value;

                await DisplayReviewerExpertise((int)dataGridView_reviewer.Rows[e.RowIndex].Cells["Id"].Value);
            }
        }

        private async void dataGridView_paper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedPaperId = (int)dataGridView_paper.Rows[e.RowIndex].Cells["Id"].Value;

                await DisplayAssignedReviewers((int)dataGridView_paper.Rows[e.RowIndex].Cells["Id"].Value);
            }
            _reviewersToAssign.Clear();
        }

        private async void btn_addReviewer_Click(object sender, EventArgs e)
        {
            var existed = false;
            // ## add this to validation control
            // use datasource
            if (await _paperService.GetPaperReviewAsync(_selectedPaperId, _selectedReviewerId) != null)
                existed = true;

            foreach (var reviewer in _reviewersToAssign)
                if (reviewer.Id == _selectedReviewerId)
                    existed = true;

            if (!existed && _selectedReviewerId != 0 && _selectedPaperId != 0)
            {
                _reviewersToAssign.Add(new User 
                { 
                    Id = _selectedReviewerId, 
                    Name = _selectedUserName 
                });
                listBox_reviewer.SelectedIndex = listBox_reviewer.Items.Count - 1;
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (_paperReviewsToDelete.Count != 0)
            {
                foreach (var paperReview in _paperReviewsToDelete)
                    await _paperService.DeletePaperReview(paperReview.PaperId, paperReview.UserId);
            }
            else
                foreach (var reviewer in _reviewersToAssign)
                {
                    if (await _paperService.GetPaperReviewAsync(_selectedPaperId, reviewer.Id) == null)
                    {
                        await _paperService.AddPaperReviewAsync(new PaperReview 
                        { 
                            Id = _selectedPaperId, 
                            UserId = reviewer.Id 
                        });
                    }
                }

            MessageBox.Show("Save successful");
            await InitAsync();
        }

        private void btn_rmvReviewer_Click(object sender, EventArgs e)
        {
            if (_removeFromDb)
            {
                var reviewer = (User)listBox_reviewer.SelectedItem;
                _paperReviewsToDelete.Add(new PaperReview 
                { 
                    PaperId = _selectedPaperId, 
                    UserId = reviewer.Id 
                });
            }
            // ### can improve just using string list to store paperreview id
            _reviewersToAssign.Remove((User)listBox_reviewer.SelectedItem);
        }

        private async void btn_changeRviewer_Click(object sender, EventArgs e)
        {
            _reviewersToAssign.Clear();

            var reviewers = await _userService.GetAssignedReviewersByPaperAsync(_selectedPaperId);

            foreach (var reviewer in reviewers)
            {
                this._reviewersToAssign.Add(new User 
                { 
                    Id = reviewer.Id, 
                    Name = reviewer.Name 
                });
            }

            _removeFromDb = true;
        }
    }
}
