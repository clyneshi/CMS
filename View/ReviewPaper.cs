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
using System.IO;

namespace CMS
{
    public partial class ReviewPaper : Form
    {
        private Model.CMSDBEntities cms = new Model.CMSDBEntities();

        public ReviewPaper()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            //paperid = 0;
            var paperlist = from p in cms.Papers
                            join pr in cms.PaperReviews on p.paperId equals pr.paperId
                            join cm in cms.ConferenceMembers on pr.userId equals cm.userId
                            where pr.userId == Module.CMSsystem.user_id && cm.confId == Module.CMSsystem.user_conf
                            select new
                            {
                                paperId = p.paperId,
                                paperTitle = p.paperTitle,
                                paperRating = pr.paperRating
                            };
            dataGridView1.DataSource = paperlist.ToList();
            //dataGridView1.Columns[5].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RatingBox.Show() == DialogResult.Yes)
            {
                if (RatingBox.rating != 0 && dataGridView1.CurrentRow.Index >= 0)
                    saveRating(RatingBox.rating, (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["paperId"].Value);
            }
            init();
        }

        private void saveRating(int rating, int ppid)
        {
            PaperReview pr = cms.PaperReviews.FirstOrDefault(p => p.userId == CMS.Module.CMSsystem.user_id && p.paperId == ppid);
            Paper pp = cms.Papers.FirstOrDefault(p => p.paperId == ppid);
            if (pr != null)
            {
                pr.paperRating = rating;
                pp.paperStatus = "being reviewed";
                cms.SaveChanges();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //    paperid = (int)dataGridView1.Rows[e.RowIndex].Cells["paperId"].Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (dataGridView1.RowCount > 0 && dataGridView1.CurrentRow.Index >= 0)
            {
                int paperid = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["paperId"].Value;
                Paper paper = cms.Papers.FirstOrDefault(p => p.paperId == paperid);
                sfd.FileName = paper.paperFileName;
                if (paper.paperFormat.ToUpper().Equals(".PDF"))
                {
                    sfd.Filter = "Data Files PDF|*.pdf";
                    sfd.DefaultExt = "pdf";
                    sfd.AddExtension = true;
                }
                if (paper.paperFormat.ToUpper().Equals(".DOC"))
                {
                    sfd.Filter = "Data Files WORD|*.doc";
                    sfd.DefaultExt = "doc";
                    sfd.AddExtension = true;
                }
                if (paper.paperFormat.ToUpper().Equals(".TXT"))
                {
                    sfd.Filter = "Data Files Text Files|*.txt";
                    sfd.DefaultExt = "txt";
                    sfd.AddExtension = true;
                }

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BinaryWriter bw = new BinaryWriter(File.Create(sfd.FileName));
                    bw.Write(paper.paperContent);
                    bw.Dispose();
                }
            }
        }
    }
}
