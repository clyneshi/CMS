﻿using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Service;
using System;
using System.IO;
using System.Windows.Forms;

namespace CMS
{
    public partial class ReviewPaper : Form
    {
        readonly IPaperService _paperService;

        public ReviewPaper(IPaperService paperService)
        {
            _paperService = paperService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            //paperid = 0;
            var reviewPapers = _paperService.GetPapersForReview(GlobalVariable.CurrentUser.userId, GlobalVariable.UserConference);
            dataGridView1.DataSource = reviewPapers;
            //dataGridView1.Columns[5].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RatingBox.Show() == DialogResult.Yes)
            {
                // TODO: validation
                if (RatingBox.rating != 0 && dataGridView1.CurrentRow.Index >= 0)
                    _paperService.UpdatePaperRating(RatingBox.rating, (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["paperId"].Value);
            }
            Init();
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
                Paper paper = _paperService.GetPaperById(paperid);
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
