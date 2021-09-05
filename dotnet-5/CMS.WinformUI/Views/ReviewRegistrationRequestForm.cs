using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Global;
using CMS.BL.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class ReviewRegistrationRequestForm : Form
    {
        private readonly IUserService _userService;
        private readonly IUserRequestService _userRequestService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;
        
        // userid is used to know the userid before a user entity is created,
        // in which way conference member entity can be created
        // in "the same time" with no worrying query repeart name in different conference
        private int _userId = 0;

        public ReviewRegistrationRequestForm(IUserService userService,
            IUserRequestService userRequest,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _userService = userService;
            _userRequestService = userRequest;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Init();
        }

        public async Task Init()
        {
            _userId = await _userService.GetMaxUserIdAsync() + 1;
            await DisplayRequests();
        }

        private async Task DisplayRequests()
        {
            if (_applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Admin)
            {
                var requests = await _userRequestService.GetRegisterRequestsForAdminAsync(_applicationStrategy.GetLoggedInUserInfo().User.Id);
                dataGridView_request.DataSource = requests;
                dataGridView_request.Columns["RoleId"].Visible = false;
            }
            else
            {
                var requests = await _userRequestService.GetRegisterRequestsForChairAsync(_applicationStrategy.GetLoggedInUserInfo().User.Id);
                dataGridView_request.DataSource = requests;
                dataGridView_request.Columns["RoleId"].Visible = false;
            }
        }

        private async Task AddUserAsync()
        {
            await _userService.AddUserAsync(new User
            {
                Id = _userId,
                Name = (string)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["name"].Value,
                Password = (string)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["password"].Value,
                Email = (string)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["email"].Value,
                Contact = (string)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["contact"].Value,
                RoleId = (int)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["RoleId"].Value
            });

            if (_applicationStrategy.GetLoggedInUserInfo().User.RoleId == (int)RoleTypesEnum.Chair)
            {
                await _conferenceService.AddConferenceMemberAsync(
                    (int)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["ConferenceId"].Value,
                    _userId
                );
            }
        }

        private async Task ChangeRequestStatus(UserRequestStatusEnum Status)
        {
            int id = (int)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["Id"].Value;
            await _userRequestService.ChangeRequestStatusAsync(id, Status);
        }

        private async Task<bool> SendEmail(UserRequestStatusEnum Status)
        {
            string email = (string)dataGridView_request.Rows[dataGridView_request.CurrentRow.Index].Cells["email"].Value;

            await GlobalHelper.SendEmail(email, $"Your registration has been {Status}");

            return true;
        }

        private async void btn_approve_Click(object sender, EventArgs e)
        {
            if (dataGridView_request.CurrentRow.Index >= 0)
            {
                await AddUserAsync();
               
                await ChangeRequestStatus(UserRequestStatusEnum.Approved);

                // TODO: Turn on sending email
                //if (await SendEmail(Status))
                //{
                //    MessageBox.Show("User registration accepted");
                //}

                MessageBox.Show("Accepted user registration request");

                await Init();
            }
        }

        private async void btn_decline_Click(object sender, EventArgs e)
        {
            var Status = UserRequestStatusEnum.Declined;
            await ChangeRequestStatus(Status);
            // TODO: turn on sending email
            //await SendEmail(Status);
            MessageBox.Show("Rejected user registration request");
            await Init();
        }
    }
}
