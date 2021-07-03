using CMS.BL.Services.Interface;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfoForm : Form
    {
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;

        public ConferenceInfoForm(IPaperService paperService, IConferenceService conferenceService)
        {
            _paperService = paperService;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dataGridView_conference.DataSource = _conferenceService.GetReviewersByConference();
            dataGridView_paper.DataSource = _paperService.GetPapersWithConference();
        }
    }
}
