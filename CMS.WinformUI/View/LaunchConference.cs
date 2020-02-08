using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CMS.Library.Model;
using CMSLibrary.Global;
using CMSLibrary.Model;

namespace CMS
{
    public partial class LaunchConference : Form
    {
        private BindingList<keyword> kw = new BindingList<keyword>();

        public LaunchConference()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            kw.Clear();
            keywordDisplay();
            selectedKwDisplay();
        }

        private void keywordDisplay()
        {
            var topic = DataProcessor.GetKeyWords();

            dataGridView1.DataSource = topic;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void selectedKwDisplay()
        {
            listBox1.DataSource = kw;
            listBox1.DisplayMember = "keywrdName";
        }

        private void btn_add_Click(object sender, EventArgs e)
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
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                kw.Remove((keyword)listBox1.SelectedItem);
        }

        private void addConf(int conferenceId)
        {
            Conference conf = new Conference
            {
                confId = conferenceId,
                chairId = GlobalVariable.CurrentUser.userId,
                confTitle = textBox_title.Text,
                confLocation = textBox_loc.Text,
                confBeginDate = dateTimePicker_bdate.Value.Date,
                confEndDate = dateTimePicker_edate.Value.Date,
                paperDeadline = dateTimePicker_pdeadline.Value.Date
            };

            DataProcessor.AddConference(conf);
        }

        private string confValidation()
        {
            if (textBox_title.Text.Trim().Equals(""))
                return "Conference Title cannot be empty";
            if (textBox_loc.Text.Trim().Equals(""))
                return "Conference Location cannot be empty";
            if (DateTime.Compare(dateTimePicker_bdate.Value.Date, dateTimePicker_edate.Value.Date) > 0)
                return "Begin date cannot be late than End date";
            if (DateTime.Compare(dateTimePicker_pdeadline.Value.Date, dateTimePicker_bdate.Value.Date) >= 0)
                return "Paper submition date must before Conference begain date";
            if (kw.Count == 0)
                return "Topic cannot be empty";

            return "";
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string error = confValidation();
            if (error.Equals(""))
            {
                var conferenceId = DataProcessor.GetMaxConferenceId() + 1;
                addConf(conferenceId);
                DataProcessor.AddConferenceTopic(conferenceId, kw.ToList());
                MessageBox.Show("Conference added successfully");
                DataProcessor.ClearControls(this.Controls);
                init();
            }
            else
                MessageBox.Show(error);
        }
    }
}
