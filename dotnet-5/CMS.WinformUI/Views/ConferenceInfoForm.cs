using CMS.BL.Services.Interfaces;
using System;
using System.Threading.Tasks;
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
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitAsync();
        }


        public async Task InitAsync()
        {
            dataGridView_conference.DataSource = await _conferenceService.GetReviewersByConferenceAsync();
            dataGridView_paper.DataSource = await _paperService.GetPapersWithConferenceAsync();
        }
    }
}
