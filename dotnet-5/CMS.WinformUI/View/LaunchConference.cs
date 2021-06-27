using CMS.DAL.Models;
using CMS.Service.Global;
using CMS.Service.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class LaunchConference : Form
    {
        private readonly BindingList<Keyword> keywords = new BindingList<Keyword>();
        private readonly IKeywordService _keywordService;
        private readonly IConferenceService _conferenceService;

        public LaunchConference(IKeywordService keywordService, IConferenceService conferenceService)
        {
            _keywordService = keywordService;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            keywords.Clear();
            KeywordDisplay();
            DisplaySelectedKeyword();
        }

        private void KeywordDisplay()
        {
            var topic = _keywordService.GetKeyWords();

            dataGridView1.DataSource = topic;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void DisplaySelectedKeyword()
        {
            listBox1.DataSource = keywords;
            listBox1.DisplayMember = "Name";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                bool find = false;
                foreach (Keyword k in keywords)
                    if (k.Id == (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KeywordId"].Value)
                        find = true;
                if (!find)
                {
                    keywords.Add(new Keyword
                    {
                        Id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KeywordId"].Value,
                        Name = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Name"].Value
                    });
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                keywords.Remove((Keyword)listBox1.SelectedItem);
        }

        private string ConfValidation()
        {
            if (textBox_title.Text.Trim().Equals(""))
                return "Conference Title cannot be empty";
            if (textBox_loc.Text.Trim().Equals(""))
                return "Conference Location cannot be empty";
            if (DateTime.Compare(dateTimePicker_bdate.Value.Date, dateTimePicker_edate.Value.Date) > 0)
                return "Begin date cannot be late than End date";
            if (DateTime.Compare(dateTimePicker_pdeadline.Value.Date, dateTimePicker_bdate.Value.Date) >= 0)
                return "Paper submition date must before Conference begain date";
            if (keywords.Count == 0)
                return "Topic cannot be empty";

            return "";
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string error = ConfValidation();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            var conference = new Conference
            {
                ChairId = GlobalVariable.CurrentUser.Id,
                Title = textBox_title.Text,
                Location = textBox_loc.Text,
                BeginDate = dateTimePicker_bdate.Value.Date,
                EndDate = dateTimePicker_edate.Value.Date,
                PaperDeadline = dateTimePicker_pdeadline.Value.Date
            };

            await _conferenceService.AddConference(conference, keywords.ToList());

            MessageBox.Show("Conference added successfully");
            this.Controls.Clear();
            Init();
        }
    }
}
