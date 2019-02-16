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
    public partial class RequestValidate : Form
    {
        CMSDBEntities cms = new CMSDBEntities();
        CMSsystem cmsm = new CMSsystem();

        int userid = 0;
        // userid is used to know the userid before a user entity is created,
        // in which way conference member entity can be created
        // in "the same time" with no worrying query repeart name in different conference

        public RequestValidate()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            findMaxUID();
            reqDisplay();
        }

        private void reqDisplay()
        {
            if (CMSsystem.user_role == 1)
            {
                var req1 = from r in cms.RegisterRequests
                           join ro in cms.Roles on r.roleId equals ro.roleId
                           where r.roleId == 2 && r.status == "Waiting for approval"
                           select new
                           {
                               r.Id,
                               r.roleId,
                               ro.roleType,
                               r.name,
                               r.contact,
                               r.password,
                               r.email
                           };
                dataGridView1.DataSource = req1.ToList();
                dataGridView1.Columns["roleId"].Visible = false;
            }
            else
            {
                var req2 = from c in cms.Conferences
                           join r in cms.RegisterRequests on c.confId equals r.confId
                           join ro in cms.Roles on r.roleId equals ro.roleId
                           where c.chairId == CMSsystem.user_id && r.roleId != 2 && r.status == "Waiting for approval"
                           select new
                           {
                               r.Id,
                               c.confId,
                               c.confTitle,
                               r.roleId,
                               ro.roleType,
                               r.name,
                               r.contact,
                               r.password,
                               r.email
                           };
                dataGridView1.DataSource = req2.ToList();
                dataGridView1.Columns["roleId"].Visible = false;
            }
        }

        private void findMaxUID()
        {
            var max = from u in cms.Users
                       select u.userId;
            if (max.Count() == 0)
                userid = 1;
            else
                userid = max.Max() + 1;
        }

        private void addUser()
        {
            User user = new User();
            user.userId = userid;
            user.userName = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["name"].Value;
            user.userPasswrd = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["password"].Value;
            user.userEmail = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value;
            user.userContact = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["contact"].Value;
            user.roleId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["roleId"].Value;
            cms.Users.Add(user);
            cms.SaveChanges();
        }

        private void addConfMember()
        {
            ConferenceMember cm = new ConferenceMember();
            cm.confId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["confId"].Value;
            cm.userId = userid;
            cms.ConferenceMembers.Add(cm);
            cms.SaveChanges();
        }

        private void changeReqStatus(int i)
        {
            int id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value;
            RegisterRequest rr = cms.RegisterRequests.FirstOrDefault(r => r.Id == id);
            if (i == 1)
                rr.status = "Approved";
            else if (i == 2)
                rr.status = "Declined";
            cms.SaveChanges();
        }

        private Boolean sendEmail(int type)
        {
            string email = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value;
            if (type == 1)
                cmsm.sendEmail(email, "Your registration has been approved");
            if (type == 2)
                cmsm.sendEmail(email, "Your registration has been declined");
            return true;
        }

        private async void btn_approve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                addUser();
                if (CMSsystem.user_role == 2)
                    addConfMember();
                changeReqStatus(1);

                Boolean status = await Task.Run(()=>sendEmail(1));
                if (status)
                {
                    MessageBox.Show("User accepted");
                }
                
                init();
            }
        }

        private void btn_decline_Click(object sender, EventArgs e)
        {
            changeReqStatus(2);
            sendEmail(2);
            MessageBox.Show("User rejected");
            init();
        }
    }
}
