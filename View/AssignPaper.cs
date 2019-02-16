using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Model;

namespace CMS
{
    public partial class AssignPaper : Form
    {
        Model.CMSDBEntities cms = new Model.CMSDBEntities();
        BindingList<User> reviewer = new BindingList<User>();
        BindingList<PaperReview> deletlist = new BindingList<PaperReview>();
        int userid = 0;
        int paperid = 0;
        string username = "";
        // tag is used to control whether removal involves in database layer
        // 1 is invovled
        int tag = 0;

        public AssignPaper()
        {
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
            var conf = from c in cms.Conferences
                       where c.chairId == Module.CMSsystem.user_id
                       select new
                       {
                           c.confId,
                           c.confTitle,
                           c.paperDeadline,
                           c.confBeginDate,
                           c.confEndDate
                       };
                       

            dataGridView1.DataSource = conf.ToList();
        }

        public void paperDisplay(int conf)
        {
            var papers = from p in cms.Papers
                         join c in cms.Conferences on p.confId equals c.confId
                         where c.confId == conf
                         select new
                         {
                             p.paperId,
                             p.paperTitle,
                             p.paperAuthor,
                             p.paperLength,
                             p.paperSubDate
                         };

            dataGridView2.DataSource = papers.ToList();
        }

        public void reviewerDisplay(int conf)
        {
            var user = from u in cms.Users
                       join cf in cms.ConferenceMembers on u.userId equals cf.userId
                       join c in cms.Conferences on cf.confId equals c.confId
                         where c.confId == conf && u.roleId == 3
                         select new
                         {
                             u.userId,
                             u.userName
                         };

            dataGridView3.DataSource = user.ToList();
        }

        public void reviewerExpeDisplay(int rvw)
        {
            var kw = from k in cms.keywords
                     join e in cms.Expertises on k.keywrdId equals e.keywrdId
                       where e.userId == rvw
                       select k;

            dataGridView4.DataSource = kw.ToList();
            dataGridView4.Columns["ConferenceTopics"].Visible = false;
            dataGridView4.Columns["Expertises"].Visible = false;
            dataGridView4.Columns["PaperTopics"].Visible = false;
        }

        public void assignedRvwDisplay(int pp)
        {
            var rvw = from r in cms.PaperReviews
                      join u in cms.Users on r.userId equals u.userId
                      where r.paperId == pp
                      select new
                      {
                          u.userId,
                          u.userName
                      };

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
                // return paper list in selected conference
                Paper pp = cms.Papers.FirstOrDefault(p => p.confId == conf);

                if (pp != null)
                {
                    paperDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["confId"].Value);

                    paperid = (int)dataGridView2.Rows[0].Cells["paperId"].Value;
                    PaperReview pr = cms.PaperReviews.FirstOrDefault(p => p.paperId == paperid);
                    if (pr != null)
                        assignedRvwDisplay((int)dataGridView2.Rows[0].Cells["paperId"].Value);
                    else
                        dataGridView5.DataSource = null;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView5.DataSource = null;
                }

                // return reviewer list in selected conference
                var us = from u in cms.Users
                         join cf in cms.ConferenceMembers on u.userId equals cf.userId
                         where u.roleId == 3 && cf.confId == conf
                         select u;

                if (us.Count() != 0)
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

                Expertise expe = cms.Expertises.FirstOrDefault(t => t.userId == userid);
                if (expe != null)
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
                PaperReview pr = cms.PaperReviews.FirstOrDefault(p => p.paperId == paperid);
                if (pr != null)
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
            var assigned = from pr in cms.PaperReviews
                           where pr.paperId == paperid && pr.userId == userid
                           select pr;
            if (assigned.Count() != 0)
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
                    cms.PaperReviews.Remove(cms.PaperReviews.FirstOrDefault(p => p.paperId == pr.paperId && p.userId == pr.userId));
                
            }
            else
                foreach (User u in reviewer)
                {
                    if (cms.PaperReviews.FirstOrDefault(pr => pr.paperId == paperid && pr.userId == u.userId) == null)
                    {
                        PaperReview pr = new PaperReview { paperId = paperid, userId = u.userId };
                        cms.PaperReviews.Add(pr);
                    }
                }

            cms.SaveChanges();
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
            var rvw = from u in cms.Users
                      join pr in cms.PaperReviews on u.userId equals pr.userId
                      where pr.paperId == paperid
                      select u;

            foreach(var r in rvw)
            {
                reviewer.Add(new User { userId = r.userId, userName = r.userName });
            }

            tag = 1;
        }
    }
}
