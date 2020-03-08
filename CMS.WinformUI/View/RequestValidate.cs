using CMS.Library.Global;
using CMS.Library.Model;
using CMS.Library.Service;
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

        private readonly IUserService _userService;
        private readonly IUserRequestService _userRequestService;
        private readonly IConferenceService _conferenceService;

        public RequestValidate(IUserService userService,
            IUserRequestService userRequest,
            IConferenceService conferenceService)
        {
            _userService = userService;
            _userRequestService = userRequest;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            FindMaxUID();
            ReqDisplay();
        }

        private void ReqDisplay()
        {
            if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Admin)
            {
                var req1 = _userRequestService.GetUserRequest_Admin();
                dataGridView1.DataSource = req1;
                dataGridView1.Columns["roleId"].Visible = false;
            }
            else
            {
                var req2 = _userRequestService.GetUserRequest();
                dataGridView1.DataSource = req2;
                dataGridView1.Columns["roleId"].Visible = false;
            }
        }

        private void FindMaxUID()
        {
            userid = _userService.GetMaxUserId() + 1;
        }

        private void AddUser()
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

            _userService.AddUser(user);
        }

        private void AddConfMember()
        {
            ConferenceMember cm = new ConferenceMember
            {
                confId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["confId"].Value,
                userId = userid
            };

            _conferenceService.AddConferenceMember(cm);
        }

        private void ChangeReqStatus(UserRequestStatus status)
        {
            int id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value;
            _userRequestService.ChangeRequestStatus(id, status);
        }

        private async Task<bool> SendEmail(UserRequestStatus status)
        {
            string email = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value;
            
            await GlobalHelper.SendEmail(email, $"Your registration has been {status.ToString()}");
               
            return true;
        }

        private async void btn_approve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                AddUser();
                if (GlobalVariable.CurrentUser.roleId == (int)RoleTypes.Chair)
                    AddConfMember();
                
                var status = UserRequestStatus.Approved;
                ChangeReqStatus(status);

                if (await SendEmail(status))
                {
                    MessageBox.Show("User registration accepted");
                }

                Init();
            }
        }

        private async void btn_decline_Click(object sender, EventArgs e)
        {
            var status = UserRequestStatus.Declined;
            ChangeReqStatus(status);
            await SendEmail(status);
            MessageBox.Show("User registration rejected");
            Init();
        }
    }
}
