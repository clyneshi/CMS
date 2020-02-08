using CMS.Library.Model;
using CMSLibrary.Global;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class RequestValidate : Form
    {

        int userid = 0;
        // userid is used to know the userid before a user entity is created,
        // in which way conference member entity can be created
        // in "the same time" with no worrying query repeart name in different conference

        public RequestValidate()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            findMaxUID();
            ReqDisplay();
        }

        private void ReqDisplay()
        {
            if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Admin)
            {
                var req1 = DataProcessor.GetUserRequest_Admin();
                dataGridView1.DataSource = req1;
                dataGridView1.Columns["roleId"].Visible = false;
            }
            else
            {
                var req2 = DataProcessor.GetUserRequest();
                dataGridView1.DataSource = req2;
                dataGridView1.Columns["roleId"].Visible = false;
            }
        }

        private void findMaxUID()
        {
            userid = DataProcessor.GetMaxUserId() + 1;
        }

        private void addUser()
        {
            User user = new User
            {
                userId = userid,
                userName = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["name"].Value,
                userPasswrd = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["password"].Value,
                userEmail = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value,
                userContact = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["contact"].Value,
                roleId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["roleId"].Value
            };

            DataProcessor.AddUser(user);
        }

        private void addConfMember()
        {
            ConferenceMember cm = new ConferenceMember
            {
                confId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["confId"].Value,
                userId = userid
            };

            DataProcessor.AddConferenceMember(cm);
        }

        private void changeReqStatus(int i)
        {
            int id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value;
            DataProcessor.ChangeRequestStatus(id, i);
        }

        private Boolean sendEmail(int type)
        {
            string email = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value;
            if (type == 1)
                DataProcessor.SendEmail(email, "Your registration has been approved");
            if (type == 2)
                DataProcessor.SendEmail(email, "Your registration has been declined");
            return true;
        }

        private async void btn_approve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                addUser();
                if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Chair)
                    addConfMember();
                changeReqStatus(1);

                Boolean status = await Task.Run(() => sendEmail(1));
                if (status)
                {
                    MessageBox.Show("User accepted");
                }

                Init();
            }
        }

        private void btn_decline_Click(object sender, EventArgs e)
        {
            changeReqStatus(2);
            sendEmail(2);
            MessageBox.Show("User rejected");
            Init();
        }
    }
}
