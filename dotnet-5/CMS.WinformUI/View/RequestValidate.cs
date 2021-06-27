using CMS.DAL.Models;
using CMS.Service.Enums;
using CMS.Service.Global;
using CMS.Service.Service;
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
            userid = _userService.GetMaxUserId() + 1;
            DisplayRequests();
        }

        private void DisplayRequests()
        {
            if (GlobalVariable.CurrentUser.RoleId == (int)RoleTypesEnum.Admin)
            {
                var req1 = _userRequestService.GetUserRequestForAdmin(GlobalVariable.CurrentUser.Id);
                dataGridView1.DataSource = req1;
                dataGridView1.Columns["RoleId"].Visible = false;
            }
            else
            {
                var req2 = _userRequestService.GetUserRequestForChair(GlobalVariable.CurrentUser.Id);
                dataGridView1.DataSource = req2;
                dataGridView1.Columns["RoleId"].Visible = false;
            }
        }

        private void AddUser()
        {
            User user = new User
            {
                Id = userid,
                Name = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["name"].Value,
                Password = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["password"].Value,
                Email = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value,
                Contact = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["contact"].Value,
                RoleId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["RoleId"].Value
            };

            _userService.AddUser(user);
        }

        private async Task AddConferenceMember()
        {
            ConferenceMember cm = new ConferenceMember
            {
                ConferenceId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ConferenceId"].Value,
                UserId = userid
            };

            await _conferenceService.AddConferenceMember(cm);
        }

        private async Task ChangeRequestStatus(UserRequestStatusEnum Status)
        {
            int id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value;
            await _userRequestService.ChangeRequestStatus(id, Status);
        }

        private async Task<bool> SendEmail(UserRequestStatusEnum Status)
        {
            string email = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value;

            await GlobalHelper.SendEmail(email, $"Your registration has been {Status.ToString()}");

            return true;
        }

        private async void btn_approve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                AddUser();
                if (GlobalVariable.CurrentUser.RoleId == (int)RoleTypesEnum.Chair)
                    await AddConferenceMember();

                var Status = UserRequestStatusEnum.Approved;
                await ChangeRequestStatus(Status);

                // TODO: Turn on sending email
                //if (await SendEmail(Status))
                //{
                //    MessageBox.Show("User registration accepted");
                //}

                MessageBox.Show("User registration accepted");

                Init();
            }
        }

        private async void btn_decline_Click(object sender, EventArgs e)
        {
            var Status = UserRequestStatusEnum.Declined;
            await ChangeRequestStatus(Status);
            // TODO: turn on sending email
            //await SendEmail(Status);
            MessageBox.Show("User registration rejected");
            Init();
        }
    }
}
