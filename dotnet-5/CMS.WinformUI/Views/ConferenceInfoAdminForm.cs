using CMS.BL.Enums;
using CMS.BL.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfoAdminForm : Form
    {
        private readonly IUserService _userService;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;

        public ConferenceInfoAdminForm(
            IUserService userService,
            IPaperService paperService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _userService = userService;
            _paperService = paperService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitAsync(_applicationStrategy.GetLoggedInUserInfo().User.RoleId);
        }

        public async Task InitAsync(int type)
        {
            switch (type)
            {
                case (int)ConferenceViewTypesEnum.ConferenceMembers:
                    dataGridView1.DataSource = await _conferenceService.GetConferencesWithChairAsync();
                    break;
                case (int)ConferenceViewTypesEnum.UserInfo:
                    dataGridView1.DataSource = await _userService.GetUsersWithRoleAsync();
                    break;
                case (int)ConferenceViewTypesEnum.Papers:
                    dataGridView1.DataSource = await _paperService.GetPapersWithAuthorAsync();
                    break;
                default:
                    break;
            }
        }
    }
}
