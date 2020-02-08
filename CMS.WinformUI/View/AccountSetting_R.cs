using CMS.Library.Model;
using CMSLibrary.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class AccountSetting_R : Form
    {
        private readonly BindingList<keyword> kw = new BindingList<keyword>();
        private readonly List<keyword> rmk = new List<keyword>();

        public AccountSetting_R()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            initForm();
            keywordDisplay();
            selectedKwDisplay();
        }

        private void keywordDisplay()
        {
            var keywords = DataProcessor.GetKeyWords();

            dataGridView1.DataSource = keywords.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void selectedKwDisplay()
        {
            var kwl = DataProcessor.GetExpertiseKeyword();

            foreach (var k in kwl)
            {
                kw.Add(new keyword { keywrdId = k.KeywrdId, keywrdName = k.KeywrdName });
            }

            listBox1.DataSource = kw;
            listBox1.DisplayMember = "keywrdName";
            listBox1.ValueMember = "keywrdId";
        }

        private void initForm()
        {
            textBox_name.Text = GlobalVariable.CurrentUser.userName;
            textBox_email.Text = GlobalVariable.CurrentUser.userEmail;
            textBox_cont.Text = GlobalVariable.CurrentUser.userContact;
            comboBox_role.Text = DataProcessor.GetRole(GlobalVariable.CurrentUser.roleId).roleType;

            if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Reviewer
                || GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Author)
                comboBox_conf.Text = DataProcessor.GetConferenceById(GlobalVariable.UserConference).confTitle;
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
            {
                rmk.Add(new keyword { keywrdId = (int)listBox1.SelectedValue });
                kw.Remove((keyword)listBox1.SelectedItem);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataProcessor.UpdateUser(textBox_name.Text, textBox_email.Text, textBox_cont.Text, textBox_oPass.Text, textBox_nPass.Text);
            DataProcessor.UpdateExpertise(rmk, kw.ToList());
            MessageBox.Show("Update completed");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
