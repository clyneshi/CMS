using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class test : Form
    {
        private Model.CMSDBEntities cms = new Model.CMSDBEntities();
        public test()
        {
            InitializeComponent();
            init();
        }
        
        public void init()
        {
            dataGridView1.DataSource = cms.Papers.ToList();
            dataGridView1.Columns["paperContent"].Visible = false;
            dataGridView2.DataSource = cms.PaperTopics.ToList();
            dataGridView3.DataSource = cms.PaperReviews.ToList();
            dataGridView4.DataSource = cms.ConferenceTopics.ToList();
        }
    }
}
