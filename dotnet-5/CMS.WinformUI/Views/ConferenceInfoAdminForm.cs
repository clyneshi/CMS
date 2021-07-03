using CMS.BL.Enums;
using CMS.BL.Services.Interface;
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
            Init(_applicationStrategy.GetLoggedInUserInfo().User.RoleId);
        }

        public void Init(int type)
        {
            switch (type)
            {
                case (int)ConferenceViewTypesEnum.ConferenceMembers:
                    dataGridView1.DataSource = _conferenceService.GetConferenceWithChair();
                    break;
                case (int)ConferenceViewTypesEnum.UserInfo:
                    dataGridView1.DataSource = _userService.GetUsersWithRole();
                    break;
                case (int)ConferenceViewTypesEnum.Papers:
                    dataGridView1.DataSource = _paperService.GetPapersWithAuthor();
                    break;
                default:
                    break;
            }
        }
    }
}
