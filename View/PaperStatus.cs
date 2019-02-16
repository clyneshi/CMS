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
using CMS.Module;

namespace CMS
{
    public partial class PaperStatus : Form
    {
        private CMSDBEntities cms = new CMSDBEntities();

        public PaperStatus()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            paperDisplay();
            //statusDisplay(0);
        }

        private void paperDisplay()
        {
            var pl = from p in cms.Papers
                     where p.auId == CMSsystem.user_id
                     select new
                     {
                         p.paperId,
                         p.paperTitle,
                         p.paperAuthor,
                         p.paperSubDate,
                         p.paperStatus
                     };
            dataGridView1.DataSource = pl.ToList();
            if (pl.Count() > 0)
                feedbackDisplay((int)dataGridView1.Rows[0].Cells["paperId"].Value);
        }

        private void feedbackDisplay(int paper)
        {
            var fb = cms.Feedbacks.Where(f => f.paperId == paper);
            if (fb.Count() != 0)
                richTextBox_fb.Text = fb.Single().feedback1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > 0)
                feedbackDisplay((int)dataGridView1.Rows[e.RowIndex].Cells["paperId"].Value);
        }
    }
}
