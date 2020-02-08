using CMS.Library.Global;
using CMS.Library.Model;
using CMS.Library.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class AssignPaper : Form
    {
        readonly BindingList<User> reviewer = new BindingList<User>();
        readonly BindingList<PaperReview> deletlist = new BindingList<PaperReview>();
        int userid = 0;
        int paperid = 0;
        string username = "";
        // tag is used to control whether removal involves in database layer
        // 1 is invovled
        int tag = 0;

        private IUserService _userService;
        private IKeywordService _keywordService;
        private IPaperService _paperService;
        private IConferenceService _conferenceService;

        public AssignPaper(IUserService userService, 
            IKeywordService keywordService, 
            IPaperService paperService,
            IConferenceService conferenceService)
        {
            _userService = userService;
            _keywordService = keywordService;
            _paperService = paperService;
            _conferenceService = conferenceService;
            InitializeComponent();
            init();
        }

        public void init()
        {
            userid = 0;
            reviewer.Clear();
            listBox_reviewer.DataSource = reviewer;
            listBox_reviewer.DisplayMember = "userName";

            confDisplay();
            if (dataGridView1.Rows.Count > 0)
            {
                paperDisplay((int)dataGridView1.Rows[0].Cells["confId"].Value);
                reviewerDisplay((int)dataGridView1.Rows[0].Cells["confId"].Value);
            }
            if (dataGridView3.Rows.Count > 0)
                reviewerExpeDisplay((int)dataGridView3.Rows[0].Cells["userId"].Value);
            if (dataGridView2.Rows.Count > 0)
                assignedRvwDisplay((int)dataGridView2.Rows[0].Cells["paperId"].Value);
        }

        private void confDisplay()
        {
            var conf = _conferenceService.GetConferenceByChair(GlobalVariable.CurrentUser.userId);

            dataGridView1.DataSource = conf;
        }

        public void paperDisplay(int conf)
        {
            var papers = _paperService.GetPapersByConference(conf);

            dataGridView2.DataSource = papers;
        }

        public void reviewerDisplay(int conf)
        {
            var reviewers = _userService.GetReviewers();

            dataGridView3.DataSource = reviewers;
        }

        public void reviewerExpeDisplay(int rvw)
        {
            var kw = _keywordService.GetKewordsByUser(rvw);

            dataGridView4.DataSource = kw;
            dataGridView4.Columns["ConferenceTopics"].Visible = false;
            dataGridView4.Columns["Expertises"].Visible = false;
            dataGridView4.Columns["PaperTopics"].Visible = false;
        }

        public void assignedRvwDisplay(int pp)
        {
            var rvw = _userService.GetAssignedReviewersByPaper(pp);

            dataGridView5.DataSource = rvw.ToList();
            tag = 0;
            deletlist.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // change the paper list according to different conference
            if (e.RowIndex >= 0)
            {
                int conf = (int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value;

                if (_paperService.GetPapersByConference(conf).Any())
                {
                    paperDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);

                    paperid = (int)dataGridView2.Rows[0].Cells["paperId"].Value;
                    if (_paperService.GetPaperReviewByPaper(paperid).Any())
                        assignedRvwDisplay((int)dataGridView2.Rows[0].Cells["paperId"].Value);
                    else
                        dataGridView5.DataSource = null;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView5.DataSource = null;
                }

                if (_userService.GetReviewersByConference(conf).Any())
                {
                    reviewerDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);
                    reviewerExpeDisplay((int)dataGridView3.Rows[0].Cells["userId"].Value);
                }
                else
                {
                    dataGridView3.DataSource = null;
                    dataGridView4.DataSource = null;
                }
                reviewer.Clear();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // change the expertise list according to different reviewer
            if (e.RowIndex >= 0)
            {
                userid = (int)dataGridView3.Rows[e.RowIndex].Cells["userId"].Value;
                username = (string)dataGridView3.Rows[e.RowIndex].Cells["userName"].Value;

                if (_keywordService.GetExpertiseByUser(userid).Any())
                    reviewerExpeDisplay((int)dataGridView3.Rows[e.RowIndex].Cells["userId"].Value);
                else
                    dataGridView4.DataSource = null;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                paperid = (int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value;

                if (_paperService.GetPaperReviewByPaper(paperid).Any())
                    assignedRvwDisplay((int)dataGridView2.Rows[e.RowIndex].Cells["paperId"].Value);
                else
                    dataGridView5.DataSource = null;
            }
            reviewer.Clear();
        }

        private void btn_addReviewer_Click(object sender, EventArgs e)
        {
            bool find = false;
            // ## add this to validation control

            if (_paperService.GetPaperReview(paperid, userid) != null)
                find = true;
            else
            {
                foreach (User u in reviewer)
                    if (u.userId == userid)
                        find = true;
            }

            if (!find && userid != 0 && paperid != 0)
            {
                User newreviewer = new User { userId = userid, userName = username };
                reviewer.Add(newreviewer);
                listBox_reviewer.SelectedIndex = listBox_reviewer.Items.Count - 1;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (deletlist.Count != 0)
            {
                foreach (PaperReview pr in deletlist)
                    _paperService.DeletePaperReview(pr.paperId, pr.userId);
            }
            else
                foreach (User u in reviewer)
                {
                    if (_paperService.GetPaperReview(paperid, u.userId) == null)
                    {
                        PaperReview pr = new PaperReview { paperId = paperid, userId = u.userId };
                        _paperService.AddPaperReview(pr);
                    }
                }

            MessageBox.Show("Save successful");
            init();
        }

        private void btn_rmvReviewer_Click(object sender, EventArgs e)
        {
            if (tag == 1)
            {
                User u = (User)listBox_reviewer.SelectedItem;
                deletlist.Add(new PaperReview { paperId = paperid, userId = u.userId });
            }
            // ### can improve just using string list to store paperreview id
            reviewer.Remove((User)listBox_reviewer.SelectedItem);
        }

        private void btn_changeRviewer_Click(object sender, EventArgs e)
        {
            reviewer.Clear();

            var rvw = _userService.GetAssignedReviewersByPaper(paperid);

            foreach (var r in rvw)
            {
                reviewer.Add(new User { userId = r.userId, userName = r.userName });
            }

            tag = 1;
        }
    }
}
