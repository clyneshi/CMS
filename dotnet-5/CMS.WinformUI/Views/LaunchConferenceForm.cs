using CMS.DAL.Models;
using CMS.BL.Services.Interface;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CMS.WinformUI.Utils;

namespace CMS
{
    public partial class LaunchConferenceForm : Form
    {
        private readonly IKeywordService _keywordService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;
        
        private readonly BindingList<Keyword> _selectedTopics = new BindingList<Keyword>();

        public LaunchConferenceForm(
            IKeywordService keywordService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _keywordService = keywordService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            _selectedTopics.Clear();
            KeywordDisplay();
            DisplaySelectedKeywords();
        }

        private void KeywordDisplay()
        {
            var topics = _keywordService.GetKeyWords();

            dataGridView_topic.DataSource = topics;
            dataGridView_topic.Columns[0].Visible = false;
            dataGridView_topic.Columns[3].Visible = false;
            dataGridView_topic.Columns[4].Visible = false;
            dataGridView_topic.Columns[5].Visible = false;
        }

        private void DisplaySelectedKeywords()
        {
            listBox_selectedTopic.DataSource = _selectedTopics;
            listBox_selectedTopic.DisplayMember = "Name";
        }

        private void btn_addTopic_Click(object sender, EventArgs e)
        {
            var index = dataGridView_topic.CurrentRow.Index;
            if (index >= 0)
            {
                var find = false;
                foreach (var topic in _selectedTopics)
                {
                    if (topic.Id == (int)dataGridView_topic.Rows[index].Cells["Id"].Value)
                        find = true;
                }
                if (!find)
                {
                    _selectedTopics.Add(new Keyword
                    {
                        Id = (int)dataGridView_topic.Rows[index].Cells["Id"].Value,
                        Name = (string)dataGridView_topic.Rows[index].Cells["Name"].Value
                    });
                    listBox_selectedTopic.SelectedIndex = listBox_selectedTopic.Items.Count - 1;
                }
            }
        }

        private void btn_removeTopic_Click(object sender, EventArgs e)
        {
            if (listBox_selectedTopic.SelectedIndex >= 0)
                _selectedTopics.Remove((Keyword)listBox_selectedTopic.SelectedItem);
        }

        private string ValidateConference()
        {
            if (textBox_title.Text.Trim().Equals(""))
                return "Conference Title cannot be empty";
            if (textBox_location.Text.Trim().Equals(""))
                return "Conference Location cannot be empty";
            if (DateTime.Compare(dateTimePicker_begin.Value.Date, dateTimePicker_end.Value.Date) > 0)
                return "Begin date cannot be late than End date";
            if (DateTime.Compare(dateTimePicker_deadline.Value.Date, dateTimePicker_begin.Value.Date) >= 0)
                return "Paper submition date must before Conference begain date";
            if (_selectedTopics.Count == 0)
                return "Topic cannot be empty";

            return "";
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string error = ValidateConference();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            var conference = new Conference
            {
                ChairId = _applicationStrategy.GetLoggedInUserInfo().User.Id,
                Title = textBox_title.Text,
                Location = textBox_location.Text,
                BeginDate = dateTimePicker_begin.Value.Date,
                EndDate = dateTimePicker_end.Value.Date,
                PaperDeadline = dateTimePicker_deadline.Value.Date
            };

            await _conferenceService.AddConference(conference, _selectedTopics.ToList());

            MessageBox.Show("Conference added successfully");
            Controls.ClearData();
            Init();
        }
    }
}
