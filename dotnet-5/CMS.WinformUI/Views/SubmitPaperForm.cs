using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CMS.WinformUI.Utils;
using System.Threading.Tasks;

namespace CMS
{
    public partial class SubmitPaperForm : Form
    {
        private readonly IKeywordService _keywordService;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;

        private readonly BindingList<Keyword> _selectedKeywords = new BindingList<Keyword>();

        // paperid is used to know the paperid before a paper entity is created,
        // in which way the two seperated but conneted table entity can be created
        // in "the same time"
        private int _paperId;
        private byte[] _content;
        private string _fileType;
        private string _fileName;
        private bool paperUploaded;

        public SubmitPaperForm(IKeywordService keywordService,
            IPaperService paperService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _keywordService = keywordService;
            _paperService = paperService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Init();
        }

        private void btn_uploadPaper_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _fileType = Path.GetExtension(openFileDialog.FileName);
                _fileName = Path.GetFileName(openFileDialog.FileName);
                textBox_filePath.Text = openFileDialog.FileName;
                using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    var binaryReader = new BinaryReader(fileStream);
                    _content = binaryReader.ReadBytes((int)fileStream.Length);
                    binaryReader.Close();
                }
                paperUploaded = true;
            }
        }

        public async Task Init()
        {
            _fileType = "";
            _fileName = "";
            paperUploaded = false;
            _paperId = await _paperService.GetMaxPaperIdAsync() + 1;
            await DisplayKeywords();
            DisplaySelectedKeywords();
        }

        private async Task DisplayKeywords()
        {
            // ### add orderby
            dataGridView_keyword.DataSource = await _keywordService.GetKeyWordsAsync();
            dataGridView_keyword.Columns[0].Visible = false;
            dataGridView_keyword.Columns[3].Visible = false;
            dataGridView_keyword.Columns[4].Visible = false;
            dataGridView_keyword.Columns[5].Visible = false;
        }

        private void DisplaySelectedKeywords()
        {
            _selectedKeywords.Clear();
            listBox_keyword.DataSource = _selectedKeywords;
            listBox_keyword.DisplayMember = "Name";
        }

        private void btn_addKeyword_Click(object sender, EventArgs e)
        {
            var index = dataGridView_keyword.CurrentRow.Index;
            if (index >= 0)
            {
                var find = false;
                foreach (var keyword in _selectedKeywords)
                {
                    if (keyword.Id == (int)dataGridView_keyword.Rows[index].Cells["Id"].Value)
                        find = true;
                }
                if (!find)
                {
                    _selectedKeywords.Add(new Keyword
                    {
                        Id = (int)dataGridView_keyword.Rows[index].Cells["Id"].Value,
                        Name = (string)dataGridView_keyword.Rows[index].Cells["Name"].Value
                    });
                    listBox_keyword.SelectedIndex = listBox_keyword.Items.Count - 1;
                }
            }
        }

        private void btn_removeKeyword_Click(object sender, EventArgs e)
        {
            _selectedKeywords.Remove((Keyword)listBox_keyword.SelectedItem);
        }

        private async Task<string> PaperValidation()
        {
            var deadline = (await _conferenceService.GetConferenceByIdAsync(_applicationStrategy.GetLoggedInUserInfo().ConferenceId.Value)).PaperDeadline;

            if (DateTime.Compare(DateTime.Today, deadline) >= 0)
                return "Paper submition has finished";
            if (textBox_paperTitle.Text.Trim().Equals(""))
                return "Paper Title cannot be empty";
            if (textBox_author.Text.Trim().Equals(""))
                return "Paper Author cannot be empty";
            if (comboBox_paperLength.SelectedItem == null)
                return "Paper Length cannot be empty";
            if (!paperUploaded)
                return "Paper has to be uploaded";
            if (_selectedKeywords.Count == 0)
                return "Paper topic cannot be empty";
            return "";
        }

        private async void btn_savePaper_Click(object sender, EventArgs e)
        {
            string error = await PaperValidation();
            if (!error.Equals(""))
            {
                MessageBox.Show(error);
                return;
            }

            var paper = new Paper
            {
                Id = _paperId,
                Title = textBox_paperTitle.Text,
                Author = textBox_author.Text,
                Length = (string)comboBox_paperLength.SelectedItem,
                ConferenceId = _applicationStrategy.GetLoggedInUserInfo().ConferenceId.Value,
                AuthorId = _applicationStrategy.GetLoggedInUserInfo().User.Id,
                Format = _fileType,
                FileName = _fileName,
                Status = PaperStatusEnum.Submitted.ToString(),
                Content = _content,
                SubmissionDate = DateTime.Today
            };

            var topics = new List<PaperTopic>();
            foreach (var topic in _selectedKeywords)
            {
                topics.Add(new PaperTopic
                {
                    PaperId = _paperId,
                    Id = topic.Id
                });
            }

            await _paperService.AddPaperAsync(paper, topics);

            MessageBox.Show("Successfully submitted paper!");
            Controls.ClearData();
            await Init();
        }
    }
}
