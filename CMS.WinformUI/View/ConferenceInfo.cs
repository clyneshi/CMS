using CMS.Library.Global;
using CMS.Library.Service;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo : Form
    {
        private IPaperService _paperService;
        private IConferenceService _conferenceService;

        public ConferenceInfo(IPaperService paperService, IConferenceService conferenceService)
        {
            _paperService = paperService;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dataGridView1.DataSource = _conferenceService.GetReviewer();

            dataGridView2.DataSource = _paperService.GetPaperConferences();
        }
    }
}
