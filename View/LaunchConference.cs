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
    public partial class LaunchConference : Form
    {
        private CMSDBEntities cms = new CMSDBEntities();
        private CMSsystem cmsm = new CMSsystem();
        private int confid = 0;
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
            findMaxCID();
            selectedKwDisplay();
        }

        private void findMaxCID()
        {
            var max = from c in cms.Conferences
                      select c.confId;
            if (max.Count() == 0)
                confid = 1;
            else
                confid = max.Max() + 1;
        }

        private void keywordDisplay()
        {
            var topic = from t in cms.keywords
                        select t;

            dataGridView1.DataSource = topic.ToList();
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

        private void addConf()
        {
            Conference conf = new Conference();
            conf.confId = confid;
            conf.chairId = CMSsystem.user_id;
            conf.confTitle = textBox_title.Text;
            conf.confLocation = textBox_loc.Text;
            conf.confBeginDate = dateTimePicker_bdate.Value.Date;
            conf.confEndDate = dateTimePicker_edate.Value.Date;
            conf.paperDeadline = dateTimePicker_pdeadline.Value.Date;
            cms.Conferences.Add(conf);
        }

        private string confValidation()
        {
            string error = "";

            if (textBox_title.Text.Trim().Equals(""))
                return error = "Conference Title cannot be empty";
            if (textBox_loc.Text.Trim().Equals(""))
                return error = "Conference Location cannot be empty";
            if (DateTime.Compare(dateTimePicker_bdate.Value.Date, dateTimePicker_edate.Value.Date) > 0)
                return error = "Begin date cannot be late than End date";
            if (DateTime.Compare(dateTimePicker_pdeadline.Value.Date, dateTimePicker_bdate.Value.Date) >= 0)
                return error = "Paper submition date must before Conference begain date";
            if (kw.Count == 0)
                return error = "Topic cannot be empty";
            return error;
        }

        private void addConfTopic()
        {
            foreach (keyword k in kw)
                cms.ConferenceTopics.Add(new ConferenceTopic { confId = confid, keywrdId = k.keywrdId });
            cms.SaveChanges();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string error = confValidation();
            if (error.Equals(""))
            {
                addConf();
                addConfTopic();
                MessageBox.Show("Conference added successfully");
                cmsm.clearControls(this.Controls);
                init();
            }
            else
                MessageBox.Show(error);
        }
    }
}
