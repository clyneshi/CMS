using CMS.Library.Global;
using CMS.Library.Service;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo_A : Form
    {
        IUserService _userService;
        IPaperService _paperService;
        public ConferenceInfo_A(IUserService userService, IPaperService paperService, int type)
        {
            _userService = userService;
            _paperService = paperService;
            InitializeComponent();
            Init(type);
        }

        public void Init(int type)
        {
            switch (type)
            {
                case (int)ConferenceViewTypes.ConferenceMembers:
                    dataGridView1.DataSource = DataProcessor.GetConferencesUser();
                    break;
                case (int)ConferenceViewTypes.UserInfo:
                    dataGridView1.DataSource = _userService.GetUserRole();
                    break;
                case (int)ConferenceViewTypes.Papers:
                    dataGridView1.DataSource = _paperService.GetPaperUser();
                    break;
                default:
                    break;
            }
        }
    }
}
