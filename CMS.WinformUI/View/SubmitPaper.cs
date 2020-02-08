using CMS.Library.Global;
using CMS.Library.Model;
using CMS.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CMS
{
    public partial class SubmitPaper : Form
    {
        private readonly BindingList<keyword> kw = new BindingList<keyword>();

        // paperid is used to know the paperid before a paper entity is created,
        // in which way the two seperated but conneted table entity can be created
        // in "the same time"
        int paperid = 0;
        byte[] content;
        string fileext = "";
        string filename = "";
        bool paperuploaded = false;
        private readonly IKeywordService _keywordService;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;

        public SubmitPaper(IKeywordService keywordService,
            IPaperService paperService,
            IConferenceService conferenceService)
        {
            _keywordService = keywordService;
            _paperService = paperService;
            _conferenceService = conferenceService;
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
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    content = br.ReadBytes((Int32)fs.Length);
                    br.Close();
                }
                paperuploaded = true;
            }
        }

        public void init()
        {
            fileext = "";
            filename = "";
            paperuploaded = false;
            paperid = _paperService.GetMaxPaperId() + 1;
            keywordDisplay();
            selectedKwDisplay();
        }

        private void keywordDisplay()
        {
            // ### add orderby
            dataGridView1.DataSource = _keywordService.GetKeyWords();
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
            Paper paper = new Paper
            {
                paperId = paperid,
                paperTitle = textBox_paperTitle.Text,
                paperAuthor = textBox_author.Text,
                paperLength = (string)comboBox_paperLength.SelectedItem,
                confId = GlobalVariable.UserConference,
                auId = GlobalVariable.CurrentUser.userId,
                paperFormat = fileext,
                paperFileName = filename,
                paperStatus = "submitted",

                paperContent = content,
                paperSubDate = DateTime.Today
            };

            _paperService.AddPaper(paper);
        }

        private string paperValidation()
        {
            var deadline = _conferenceService.GetConferenceById(GlobalVariable.UserConference).paperDeadline;

            if (DateTime.Compare(DateTime.Today, (DateTime)deadline) >= 0)
                return "Paper submition has finished";
            //if (textBox_paperTitle.Text.Trim().Equals(""))
            //    return error = "Paper Title cannot be empty";
            if (textBox_author.Text.Trim().Equals(""))
                return "Paper Author cannot be empty";
            if (comboBox_paperLength.SelectedItem == null)
                return "Paper Length cannot be empty";
            if (!paperuploaded)
                return "Paper has to be uploaded";
            if (kw.Count == 0)
                return "Paper topic cannot be empty";
            return "";
        }

        private void addPaperTopic()
        {
            // Save each keyword in combolist to Topoic table
            foreach (keyword k in kw)
            {
                PaperTopic pt = new PaperTopic
                {
                    paperId = paperid,
                    keywrdId = k.keywrdId
                };
                _paperService.AddPaperTopic(pt);
            }
        }

        public List<PaperTopic> addPaperTopic1(int Id, int[] keywrd)
        {
            // Save each keyword in combolist to Topoic table
            List<PaperTopic> pl = new List<PaperTopic>();
            foreach (var k in keywrd)
            {
                PaperTopic pt = new PaperTopic
                {
                    paperId = Id,
                    keywrdId = k
                };
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
                GlobalHelper.ClearControls(this.Controls);
                init();
            }
            else
                MessageBox.Show(error);
        }

    }
}
