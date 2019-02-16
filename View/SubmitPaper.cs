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
    public partial class SubmitPaper : Form
    {
        private Module.CMSsystem cmsm = new Module.CMSsystem();
        private Model.CMSDBEntities cms = new Model.CMSDBEntities();
        private BindingList<keyword> kw = new BindingList<keyword>();

        public void addPaper(int expectedId, string expecdtedTitle, string expectedLength, int expectedConfId, int expectedAuId, string expectedFormat, string expectedFileName, string expectedStatus)
        {
            throw new NotImplementedException();
        }

        // paperid is used to know the paperid before a paper entity is created,
        // in which way the two seperated but conneted table entity can be created
        // in "the same time"
        int paperid = 0;
        byte[] content;
        string fileext = "";
        string filename = "";
        bool paperuploaded = false;

        public SubmitPaper()
        {
            InitializeComponent();
            init();
        }

        private void btn_uploadPaper_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileext = Path.GetExtension(openFileDialog1.FileName);
                filename = Path.GetFileName(openFileDialog1.FileName);
                textBox_filePath.Text = openFileDialog1.FileName;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                content = br.ReadBytes((Int32)fs.Length);
                br.Close();
                fs.Close();
                paperuploaded = true;
            }
        }

        public void init()
        {
            fileext = "";
            filename = "";
            paperuploaded = false;
            findMaxPID();
            keywordDisplay();
            selectedKwDisplay();
        }

        private void findMaxPID()
        {
            // Prepare new paper id
            var max = from pp in cms.Papers
                      select pp.paperId;
            if (max.Count() == 0)
                paperid = 1;
            else
                paperid = max.Max() + 1;
        }

        private void keywordDisplay()
        {
            // ### add orderby
            dataGridView1.DataSource = cms.keywords.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void selectedKwDisplay()
        {
            kw.Clear();
            listBox_keyword.DataSource = kw;
            listBox_keyword.DisplayMember = "keywrdName";
        }

        private void btn_keyAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                bool find = false;
                foreach (keyword k in kw)
                    if (k.keywrdId == (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["keywrdId"].Value)
                        find = true;
                if (!find)
                {
                    kw.Add(new keyword
                    {
                        keywrdId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["keywrdId"].Value,
                        keywrdName = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["keywrdName"].Value
                    });
                    listBox_keyword.SelectedIndex = listBox_keyword.Items.Count - 1;
                }
            }
        }

        private void btn_keyRmv_Click(object sender, EventArgs e)
        {
            keyword k = (keyword)listBox_keyword.SelectedItem;
            kw.Remove(k);
        }

        public void addPaper()
        {
            //Save new paper to Paper table
            Paper paper = new Paper();
            paper.paperId = paperid;
            paper.paperTitle = textBox_paperTitle.Text;
            paper.paperAuthor = textBox_author.Text;
            paper.paperLength = (string)comboBox_paperLength.SelectedItem;
            paper.confId = Module.CMSsystem.user_conf;
            paper.auId = Module.CMSsystem.user_id;
            paper.paperFormat = fileext;
            paper.paperFileName = filename;
            paper.paperStatus = "submitted";

            paper.paperContent = content;
            paper.paperSubDate = DateTime.Today;
            cms.Papers.Add(paper);
            cms.SaveChanges();
        }

        // for testting
        public Paper addPaper1(int id, string title, string author, string length, int confId, int auId, string fformat, string ffilename, string status)
        {
            //Save new paper to Paper table
            Paper paper = new Paper();
            paper.paperId = id;
            paper.paperTitle = title;
            paper.paperAuthor = author;
            paper.paperLength = length;
            paper.confId = confId;
            paper.auId = auId;
            paper.paperFormat = fformat;
            paper.paperFileName = ffilename;
            paper.paperStatus = status;

            paper.paperContent = content;
            paper.paperSubDate = DateTime.Today;
            return paper;
            //cms.Papers.Add(paper);
            //cms.SaveChanges();
        }

        private string paperValidation()
        {
            string error = "";
            var conf = cms.Conferences.Where(c => c.confId == CMS.Module.CMSsystem.user_conf)
                .Select(c => c.paperDeadline).Single();
            if (DateTime.Compare(DateTime.Today, (DateTime)conf) >= 0)
                return error = "Paper submition has finished";
                //if (textBox_paperTitle.Text.Trim().Equals(""))
                //    return error = "Paper Title cannot be empty";
            if (textBox_author.Text.Trim().Equals(""))
                return error = "Paper Author cannot be empty";
            if (comboBox_paperLength.SelectedItem == null)
                return error = "Paper Length cannot be empty";
            if (!paperuploaded)
                return error = "Paper has to be uploaded";
            if (kw.Count == 0)
                return error = "Paper topic cannot be empty";
            return error;
        }

        private void addPaperTopic()
        {
            // Save each keyword in combolist to Topoic table
            foreach (keyword k in kw)
            {
                PaperTopic pt = new PaperTopic();
                pt.paperId = paperid;
                pt.keywrdId = k.keywrdId;
                cms.PaperTopics.Add(pt);
            }
            cms.SaveChanges();
        }

        public List<PaperTopic> addPaperTopic1(int Id, int[] keywrd)
        {
            // Save each keyword in combolist to Topoic table
            List<PaperTopic> pl = new List<PaperTopic>();
            foreach (var k in keywrd)
            {
                PaperTopic pt = new PaperTopic();
                pt.paperId = Id;
                pt.keywrdId = k;
                pl.Add(pt);
            }
            return pl;
        }

        private void btn_savePaper_Click(object sender, EventArgs e)
        {
            string error = paperValidation();
            if (error.Equals(""))
            {
                addPaper();
                addPaperTopic();
                MessageBox.Show("Save successful!");
                cmsm.clearControls(this.Controls);
                init();
            }
            else
                MessageBox.Show(error);
        }

    }
}
