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

namespace CMS
{
    public partial class ConferenceInfo_A : Form
    {

        private CMSDBEntities cms = new CMSDBEntities();

        public ConferenceInfo_A(int type)
        {
            InitializeComponent();
            init(type);
        }

        public void init(int type)
        {
            if (type == 1)
                confDisplay();
            if (type == 2)
                userDispaly();
            if (type == 3)
                paperDisplay();
        }

        private void confDisplay()
        {
            var conf = from c in cms.Conferences
                       join u in cms.Users on c.chairId equals u.userId
                       select new
                       {
                           c.confId,
                           u.userName,
                           c.confTitle,
                           c.confLocation,
                           c.confBeginDate,
                           c.confEndDate,
                           c.paperDeadline
                       };

            dataGridView1.DataSource = conf.ToList();
        }

        private void userDispaly()
        {
            var user = from u in cms.Users
                       join r in cms.Roles on u.roleId equals r.roleId
                       select new
                       {
                           u.userId,
                           u.userName,
                           r.roleType,
                           u.userEmail,
                           u.userContact
                       };

            dataGridView1.DataSource = user.ToList();
        }

        private void paperDisplay()
        {
            var paper = from p in cms.Papers
                        join u in cms.Users on p.auId equals u.userId
                        select new
                        {
                            p.paperId,
                            u.userName,
                            p.paperTitle,
                            p.paperAuthor,
                            p.paperSubDate,
                            p.paperLength,
                            p.paperStatus
                        };

            dataGridView1.DataSource = paper.ToList();
        }
    }
}
