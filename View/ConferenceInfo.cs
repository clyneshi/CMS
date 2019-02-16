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
    public partial class ConferenceInfo : Form
    {

        private CMSDBEntities cms = new CMSDBEntities();
        private CMSsystem cmsm = new CMSsystem();

        public ConferenceInfo()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            reviewerDisplay();
            paperDisplay();
        }

        private void reviewerDisplay()
        {
            var user = from u in cms.Users
                       join cf in cms.ConferenceMembers on u.userId equals cf.userId
                       join c in cms.Conferences on cf.confId equals c.confId
                       join r in cms.Roles on u.roleId equals r.roleId
                       where c.confId == CMSsystem.user_conf
                       orderby r.roleType
                       select new
                       {
                           u.userId,
                           u.userName,
                           r.roleType
                       };

            dataGridView1.DataSource = user.ToList();
        }

        private void paperDisplay()
        {
            var papers = from p in cms.Papers
                         join c in cms.Conferences on p.confId equals c.confId
                         where c.confId == CMSsystem.user_conf
                         select new
                         {
                             p.paperId,
                             p.paperTitle,
                             p.paperAuthor,
                             p.paperLength,
                             p.paperSubDate
                         };

            dataGridView2.DataSource = papers.ToList();
        }
    }
}
