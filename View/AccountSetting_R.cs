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
    public partial class AccountSetting_R : Form
    {
        private CMSDBEntities cms = new CMSDBEntities();
        private CMSsystem cmsm = new CMSsystem();
        private BindingList<keyword> kw = new BindingList<keyword>();
        private List<keyword> rmk = new List<keyword>();

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
            var kwl = from e in cms.Expertises
                      join k in cms.keywords on e.keywrdId equals k.keywrdId
                      where e.userId == CMSsystem.user_id
                      select new
                      {
                          e.Id,
                          k.keywrdId,
                          k.keywrdName
                      };
            
            foreach(var k in kwl)
            {
                    kw.Add(new keyword { keywrdId = k.keywrdId, keywrdName = k.keywrdName });
            }

            listBox1.DataSource = kw;
            listBox1.DisplayMember = "keywrdName";
            listBox1.ValueMember = "keywrdId";
        }

        private void initForm()
        {
            User user = cms.Users.FirstOrDefault(u => u.userId == CMSsystem.user_id);
            textBox_name.Text = user.userName;
            textBox_email.Text = user.userEmail;
            textBox_cont.Text = user.userContact;
            comboBox_role.Text = cms.Roles.FirstOrDefault(r => r.roleId == user.roleId).roleType;
            if (CMSsystem.user_role > 2)
                comboBox_conf.Text = cms.Conferences.FirstOrDefault(c => c.confId == CMSsystem.user_conf).confTitle;
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
            updateUser();
            updateExpertise();
            MessageBox.Show("Update completed");
        }

        private void updateExpertise()
        {
            var kwl = from e in cms.Expertises
                      join k in cms.keywords on e.keywrdId equals k.keywrdId
                      where e.userId == CMSsystem.user_id
                      select new
                      {
                          e.Id,
                          k.keywrdId,
                          k.keywrdName
                      };

            // find removed keywords then remove it
            List<keyword> tmprmk = new List<keyword>();
            foreach (var k in rmk)
            {
                tmprmk.Add(k);
            }
            foreach (var nk in kw)
            {
                    foreach (var rk in tmprmk)
                        if (rk.keywrdId == nk.keywrdId)
                            rmk.Remove(rk);
            }
            if (rmk.Count != 0)
            {
                foreach (var k in kwl)
                {
                    foreach (var rk in rmk)
                        if (k.keywrdId == rk.keywrdId)
                            cms.Expertises.Remove(cms.Expertises.SingleOrDefault(e => e.keywrdId == k.keywrdId && e.userId == CMSsystem.user_id));
                }
            }
            cms.SaveChanges();

            // add new keywords
            bool find = false;
            foreach (var k in kw)
            {
                find = false;
                foreach (var ok in kwl)
                    if (ok.keywrdId == k.keywrdId)
                        find = true;
                if (!find)
                    cms.Expertises.Add(new Expertise { keywrdId = k.keywrdId, userId = CMSsystem.user_id });
            }
            cms.SaveChanges();
        }

        private void updateUser()
        {
            User user = cms.Users.FirstOrDefault(u => u.userId == CMSsystem.user_id);
            user.userName = textBox_name.Text;
            user.userEmail = textBox_email.Text;
            user.userContact = textBox_cont.Text;
            if (user.userPasswrd == textBox_oPass.Text)
                user.userPasswrd = textBox_nPass.Text;
            cms.SaveChanges();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
