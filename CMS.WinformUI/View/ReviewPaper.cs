using CMS.Library.Model;
using CMSLibrary.Global;
using CMSLibrary.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace CMS
{
    public partial class ReviewPaper : Form
    {
        public ReviewPaper()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            //paperid = 0;
            var reviewPapers = DataProcessor.GetReviewPaperList();
            dataGridView1.DataSource = reviewPapers;
            //dataGridView1.Columns[5].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RatingBox.Show() == DialogResult.Yes)
            {
                if (RatingBox.rating != 0 && dataGridView1.CurrentRow.Index >= 0)
                    DataProcessor.UpdatePaperRating(RatingBox.rating, (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["paperId"].Value);
            }
            init();
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
                Paper paper = DataProcessor.GetPaperById(paperid);
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
